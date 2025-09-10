using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro
{
    public class ReceitaRepository : CrudRepository<ScaeApiContext, Receita>, IReceitaRepository
    {
        public ReceitaRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Tipo)
            //    .Include(x => x.TipoDocumento)
            //    .Include(x => x.Cliente)
            //    .Include(x => x.Parcelas)
            //        .ThenInclude(y => y.Situacao)
            //    .Include(x => x.Parcelas)
            //        .ThenInclude(y => y.Baixas)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.CentroCusto)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.ContaGerencial);
        }

        private IQueryable<ReceitaParcela> SetInclude(IQueryable<ReceitaParcela> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }
        private IQueryable<ReceitaTransacao> SetInclude(IQueryable<ReceitaTransacao> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public void DetachedParcela(ReceitaParcela parcela )
        {
            _context.Entry(parcela).State = EntityState.Detached;
        }

        private IQueryable<ReceitaBaixa> SetIncludeBaixa(IQueryable<ReceitaBaixa> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }


        public IQueryable<ReceitaParcela> GetParcelaDeContratoEmAberto(DateTime? dataVencimentoMin, DateTime? dataVencimentoMax)
        {
            var query = GetParcelaAllNoInclude()
                .Include(x => x.Receita.Contrato)
                .Include(x => x.Baixas)
                .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)  && x.Receita.ContratoId != null
                       && x.DataVencimento >= dataVencimentoMin.GetValueOrDefault() && x.DataVencimento <= dataVencimentoMax.GetValueOrDefault() );

            return query;
        } 
        public IQueryable<ReceitaParcela> GetParcelaDeContratoEmAberto()
        {
            var query = GetParcelaAllNoInclude()
                .Include(x => x.Receita.Contrato.Situacao)
                .Include(x => x.Receita.Cliente)
                .Include(x => x.Baixas)
                .Include(x => x.Receita.Contrato.Empreendimento)
                .Include(x => x.Receita.Contrato.UnidadePrincipal.Grupo)
                .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id ) && x.Receita.ContratoId != null && x.DataVencimento < DateTime.Today && x.AgrupadorId == null);

            return query;  
        } 

        public IQueryable<ReceitaParcela> GetRelatorioSmsEnviados(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal)
        {
            IQueryable<ReceitaParcela> query = _context.Set<ReceitaParcela>().AsNoTracking();

            if (empresaId.Any())
                query = query.Where(x => empresaId.Contains(x.Receita.EmpresaId));

            if (dataEmissaoInicial != null)
                query = query.Where(x => x.DataEnvioCobrancaSms.Value.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal != null)
                query = query.Where(x => x.DataEnvioCobrancaSms.Value.Date <= dataEmissaoFinal.Value.Date);

            return query;
        }
        public IQueryable<ReceitaParcela> GetRelatorioWppEnviados(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal)
        {
            IQueryable<ReceitaParcela> query = _context.Set<ReceitaParcela>().AsNoTracking();

            if (empresaId.Any())
                query = query.Where(x => empresaId.Contains(x.Receita.EmpresaId));

            if (dataEmissaoInicial != null)
                query = query.Where(x => x.DataEnvioCobrancaWhatsapp.Value.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal != null)
                query = query.Where(x => x.DataEnvioCobrancaWhatsapp.Value.Date <= dataEmissaoFinal.Value.Date);

            return query;
        }

        public IQueryable<ReceitaParcela> GetRelatorioCobrancas(int[] empresaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal)
        {
            IQueryable<ReceitaParcela> query = _context.Set<ReceitaParcela>().AsNoTracking();

            if (empresaId.Any())
                query = query.Where(x => empresaId.Contains(x.Receita.EmpresaId));

            if (dataEmissaoInicial != null || dataEmissaoFinal != null)
            {
                // Convertemos as datas para DateTime padrão antes de usar no filtro
                DateTime? dataInicio = dataEmissaoInicial?.Date;
                DateTime? dataFim = dataEmissaoFinal?.Date;

                query = query.Where(x =>
                    (x.DataEnvioCobranca.HasValue &&
                     (dataInicio == null || x.DataEnvioCobranca >= dataInicio) &&
                     (dataFim == null || x.DataEnvioCobranca <= dataFim))
                    ||
                    (x.DataEnvioCobrancaWhatsapp.HasValue &&
                     (dataInicio == null || x.DataEnvioCobrancaWhatsapp >= dataInicio) &&
                     (dataFim == null || x.DataEnvioCobrancaWhatsapp <= dataFim))
                    ||
                    (x.DataEnvioCobrancaSms.HasValue &&
                     (dataInicio == null || x.DataEnvioCobrancaSms >= dataInicio) &&
                     (dataFim == null || x.DataEnvioCobrancaSms <= dataFim))
                );
            }

            return query;
        }

        public IQueryable<ReceitaParcela> GetParcelaAll(string include = "")
       {
           var query = _context.Set<ReceitaParcela>();

           if (string.IsNullOrEmpty(include))
               return query;

           return SetInclude(query, include);
       }

       public IQueryable<ReceitaTransacao> GetTransacaoAll(string include = "")
       {
           var query = _context.Set<ReceitaTransacao>();

           if (string.IsNullOrEmpty(include))
               return query;

           return SetInclude(query, include);
       }


       public IQueryable<AntecipacaoComprovante> GetAntecipacaoComprovanteAll()
       {
           var query = _context.Set<AntecipacaoComprovante>();

           return query;
       }

       public IQueryable<ReceitaParcela> GetParcelaAllNoInclude()
       {
           return _context.Set<ReceitaParcela>();
       }

       public async Task<ReceitaParcela> GetParcelaByCodigoGatewayAsync(string codigoGateway, string include)
       {
           var query = GetParcelaAll(include);

           return await query.AsNoTracking().SingleOrDefaultAsync(x => x.CodigoZoop.Equals(codigoGateway));
       }

       public async Task<List<ReceitaParcela>> GetParcelaByCentroCusto(int[] listaEmpresaId, int centroCusto,int tipo, DateTime anoInicio, DateTime anoFim)
       {
           IQueryable<ReceitaParcela> _queryParcela = _context.Set<ReceitaParcela>();
           _queryParcela = _queryParcela
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.CentroCusto)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.ContaCorrente);

           //tipo 1 = data de vencimento
           if (tipo == 1)
           {
               _queryParcela = _queryParcela.Where(x => x.DataVencimento >= anoInicio);
               _queryParcela = _queryParcela.Where(x => x.DataVencimento <= anoFim);
           }
           //tipo 2 = data de pagamento
           if (tipo == 2)
           {
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= anoInicio && b.Cancelado == false));
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= anoFim && b.Cancelado == false));
           }


           if (listaEmpresaId.Any())
               _queryParcela = _queryParcela.Where(x => listaEmpresaId.Any(id => id == x.Receita.EmpresaId));


           return await _queryParcela.Where(x => x.Receita.Classificacoes.Any(y => y.CentroCustoId == centroCusto)).ToListAsync();
       }

       public async Task<List<ReceitaParcela>> GetParcelaByContaGerencial(int[] empresaId,int contaGerencial, int tipo, DateTime anoInicio, DateTime anoFim)
       {
           IQueryable<ReceitaParcela> _queryParcela = _context.Set<ReceitaParcela>();
           _queryParcela = _queryParcela
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.CentroCusto)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.ContaCorrente);

           //tipo 1 = data de vencimento
           if (tipo == 1)
           {
               _queryParcela = _queryParcela.Where(x => x.DataVencimento >= anoInicio);
               _queryParcela = _queryParcela.Where(x => x.DataVencimento <= anoFim);
           }
           //tipo 2 = data de pagamento
           if (tipo == 2)
           {
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= anoInicio && b.Cancelado == false));
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= anoFim && b.Cancelado == false));
           }

           if (empresaId.Any())
               _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId));


           return await _queryParcela.Where(x => x.Receita.Classificacoes.Any(y => y.ContaGerencialId == contaGerencial)).ToListAsync();
       }

       public async Task<ReceitaParcela> GetParcelaByIdAsync(int id)
       {
           IQueryable<ReceitaParcela> _queryParcela = _context.Set<ReceitaParcela>();
           _queryParcela = _queryParcela
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Tipo)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.TipoDocumento)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Cliente)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.CentroCusto)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.ContaGerencial)
               .Include(x => x.Situacao)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.FormaPagamento)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.ReceitaBaixaComprovante)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.ContaCorrente)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Contrato);

           return await _queryParcela.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

       public async Task<ReceitaParcela> GetParcelaByIdAsync(int id, string include)
       {
           var query = GetParcelaAll(include);

           return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

       public async Task<ReceitaParcela> GetParcelaByIdTrakingAsync(int id, string include = "")
       {
           var query = GetParcelaAll(include);

           return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

       public async Task RemoveParcela(int id)
       {
           var entity = await GetParcelaByIdAsync(id);

           if (entity == null)
               throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

           _context.Remove(entity);
       }
       public async Task RemoveTransacao(int id)
       {
            var entity = await GetTransacaoAll().FirstOrDefaultAsync(x => x.Id == id);

           if (entity == null)
               throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

           _context.Remove(entity);
       }

       public async Task RemoveBaixa(int id)
       {
           var entity = await GetBaixaByIdTrakingAsync(id);

           if (entity == null)
               throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

           _context.Remove(entity);

       }

       public void InsertParcela(ReceitaParcela parcela)
       {
           _context.Add(parcela);
       }

       public void UpdateParcela(ReceitaParcela parcela)
       {
           _context.Update(parcela);
       }

       public void UpdateListParcela(List<ReceitaParcela> list)
       {
           _context.UpdateRange(list);
       }

       public void UpdateBaixa(ReceitaBaixa baixa)
       {
           _context.Update(baixa);
       }

       public IQueryable<ReceitaClassificacao> GetClassificacaoAll()
       {
           return _context.Set<ReceitaClassificacao>();
       }

       public async Task<AntecipacaoComprovante> GetAntecipacaoComprovanteByParcelaIdTrackingAsync(int parcelaId)
       {
           var query = GetAntecipacaoComprovanteAll();
           return await query.SingleOrDefaultAsync(x => x.ReceitaParcelaId == parcelaId);
       }

       public void InsertAntecipacaoComprovante(AntecipacaoComprovante comprovante)
       {
           _context.Add(comprovante);
       }

       public void UpdateAntecipacaoComprovante(AntecipacaoComprovante comprovante)
       {
           _context.Update(comprovante);
       }

       public IQueryable<ReceitaBaixa> GetBaixaAllNoInclude(string include = "")
       {
           var query = _context.Set<ReceitaBaixa>();

           if (string.IsNullOrEmpty(include))
               return query;

           return SetIncludeBaixa(query, include);
       }

       public async Task<ReceitaBaixa> GetBaixaByIdTrakingAsync(int id)
       {
           return await _context.Set<ReceitaBaixa>().SingleOrDefaultAsync(x => x.Id.Equals(id));
       }
       public async Task<ReceitaBaixa> GetBaixaByIdIncludeTrackingAsync(int id, string include = "")
       {
           var query = SetIncludeBaixa(_context.Set<ReceitaBaixa>(), include);
           return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

       public async Task<ReceitaClassificacao> GetClassificacaoByIdAsync(int id)
       {
           return await _context.Set<ReceitaClassificacao>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
       }

       public async Task RemoveClassificacao(int id)
       {
           var entity = await GetClassificacaoByIdAsync(id);

           if (entity == null)
               throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

           _context.Remove(entity);
       }

       public async Task<object> GetBaixas(int parcelaId)
       {
           return await GetBaixaAllNoInclude()
               .Include(x => x.ContaCorrente)
               .AsNoTracking()
               .Where(x => x.ParcelaId == parcelaId)
               .Select(x => new
               {
                   x.Id,
                   x.ParcelaId,
                   x.ContaCorrenteId,
                   x.ContaCorrente,
                   x.DataPagamento,
                   x.Desconto,
                   x.Juros,
                   x.Valor,
                   x.Total
               }).ToListAsync();
       }

       public async Task<int> ProximoNumeroParcela(int receitaId)
       {
           var receita = await GetByIdAsync(receitaId,"Parcelas") ?? throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

           return receita?.Parcelas?.OrderByDescending(x => x.Parcela)?.Take(1)?
               .SingleOrDefault()?.Parcela + 1 ?? 1;

       }

       public async Task<List<ReceitaParcela>> ObterParcelasFluxoCaixa(int[] empresaId,int tipo,DateTime anoInicio, DateTime anoFim) 
       {

           IQueryable<ReceitaParcela> _queryParcela;
           _queryParcela = _context.ReceitaParcelas.AsNoTracking()
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Tipo)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.CentroCusto)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.ContaGerencial)


               .Where(x => x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id);


           if (empresaId.Any())
               _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId));

           //tipo 1 = data de vencimento
           if (tipo == 1)
           {
                   _queryParcela = _queryParcela.Where(x => x.DataVencimento >= anoInicio);
                   _queryParcela = _queryParcela.Where(x => x.DataVencimento <= anoFim);
           }
           //tipo 2 = data de pagamento
           if (tipo == 2)
           {
                   _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= anoInicio && b.Cancelado == false));
                   _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= anoFim && b.Cancelado == false));
           }

           return await _queryParcela.ToListAsync();

       }




       public async Task<List<ReceitaParcela>> ObterParcelas(int? empreendimentoId, int? tipoReceitaId, int centroCustoId, int contaGerencialId, char? contaGerencialTipo,
           DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
           DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int? formaPagamentoId,int? contaCorrenteId)
       { 
           //IQueryable<ReceitaParcela> queryParcela = _context.ReceitaParcelas
           //    .AsNoTracking()
           //    .Include(x => x.Receita)
           //        .ThenInclude(x => x.Classificacoes)
           //            .ThenInclude(z => z.ContaGerencial)
           //    .Include(x => x.Receita)
           //        .ThenInclude(x => x.Classificacoes)
           //            .ThenInclude(z => z.CentroCusto)
           //    .Include(x => x.Baixas)
           //        .ThenInclude(x => x.ContaCorrente)
           //    .Include(x => x.Situacao)
           //    .Include(x => x.Receita)
           //        .ThenInclude(x => x.Contrato);

           IQueryable<ReceitaParcela> _queryParcela;
           _queryParcela = _context.ReceitaParcelas.AsNoTracking()
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Tipo)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.TipoDocumento)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Cliente)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.CentroCusto)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Classificacoes)
                       .ThenInclude(x => x.ContaGerencial)
               .Include(x => x.Situacao)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.FormaPagamento)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.ContaCorrente)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Contrato)
                       .ThenInclude(x => x.UnidadesAdicionais)
                           .ThenInclude(x => x.Unidade)
                               .ThenInclude(x=>x.Grupo)

               .Where(x => x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id);


           if (empreendimentoId.HasValue)
           {
               _queryParcela = _queryParcela.Where(x => x.Receita.EmpreendimentoId == empreendimentoId || x.Receita.Contrato.UnidadesAdicionais.Any(u => u.Unidade.Grupo.EmpreendimentoId == empreendimentoId));
           }

           if (dataEmissaoInicial.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Receita.DataEmissao >= dataEmissaoInicial);

           if (dataEmissaoFinal.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Receita.DataEmissao <= dataEmissaoFinal);

           if (dataVencimentoInicial.HasValue)
               _queryParcela = _queryParcela.Where(x => x.DataVencimento >= dataVencimentoInicial);

           if (dataVencimentoFinal.HasValue)
               _queryParcela = _queryParcela.Where(x => x.DataVencimento <= dataVencimentoFinal);

           if (dataBaixaInicial.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= dataBaixaInicial && b.Cancelado == false));

           if (dataBaixaFinal.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= dataBaixaFinal && b.Cancelado == false));

           if (centroCustoId > 0)
               _queryParcela = _queryParcela.Where(x => x.Receita.Classificacoes.Any(c => c.CentroCustoId == centroCustoId));

           if (contaGerencialId > 0)
               _queryParcela = _queryParcela.Where(x => x.Receita.Classificacoes.Any(c => c.ContaGerencialId == contaGerencialId));

           if (contaGerencialTipo.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Receita.Classificacoes.Any(c => c.ContaGerencial.Tipo == contaGerencialTipo.Value.ToString()));

           if (tipoReceitaId.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Receita.TipoId == tipoReceitaId);

           if (formaPagamentoId.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.FormaPagamentoId == formaPagamentoId));

           if (contaCorrenteId.HasValue)
               _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.ContaCorrenteId == contaCorrenteId));


           return await _queryParcela.ToListAsync();

       }



       public IQueryable<ReceitaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, bool? pagamentoAutomatico, int? formaPagamento, int? usuarioBaixa, int? clienteId, int[] situacaoParcelaId, int? contratoId, int[] tipoReceitaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
          DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int[] empresaId, int[] tipoAditamentoId, int[] tipoServicoId, int? tipoContrato, int? tipoAmortizacao, int? grupoId, int? unidadePrincipalId)
       {

           IQueryable<ReceitaParcela> _queryParcela;
           _queryParcela = _context.ReceitaParcelas.AsNoTracking()
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Tipo)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Cliente)
               .Include(x => x.Situacao)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.FormaPagamento)
               .Include(x => x.Baixas)
                   .ThenInclude(x => x.Usuario)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Contrato)
                       .ThenInclude(x => x.UnidadePrincipal)
                           .ThenInclude(x => x.Grupo)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Empreendimento)
               .Include(x => x.Receita)
                   .ThenInclude(x => x.Empresa)
               .Include(x => x.Receita)
                  .ThenInclude(x => x.Contrato)
                       .ThenInclude(x => x.TipoAditamento)
               .Include(x => x.TipoServico);
             /*  .Include(x=>x.Receita)
                   .ThenInclude(x=>x.Contrato).
                       ThenInclude(x=>x.HistoricoSituacoes); */



            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => empreendimentoId.Any(id => id == x.Receita.EmpreendimentoId) || x.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));


            if (numeroContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.Numero == numeroContrato);
            }

            if (tipoContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.TipoId == tipoContrato);
            }

            if (tipoAmortizacao.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.TipoAmortizacaoId == tipoAmortizacao);
            }

            if (pagamentoAutomatico.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.Automatica == pagamentoAutomatico));

            if (formaPagamento.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.FormaPagamentoId == formaPagamento));

            if (usuarioBaixa.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.UsuarioId == usuarioBaixa));

            if (clienteId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.ClienteId == clienteId);

            if (situacaoParcelaId.Any())
                _queryParcela = _queryParcela.Where(x => situacaoParcelaId.Any(id => id == x.SituacaoId));
            else
                _queryParcela = _queryParcela.Where(x => x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id);

            if (contratoId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.ContratoId == contratoId);

             if (unidadePrincipalId.HasValue)
              _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.UnidadePrincipalId == unidadePrincipalId);

            if (grupoId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.UnidadePrincipal.GrupoId == grupoId);


            if (dataEmissaoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.DataEmissao.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.DataEmissao.Date <= dataEmissaoFinal.Value.Date);

            if (dataVencimentoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date >= dataVencimentoInicial.Value.Date);

            if (dataVencimentoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataVencimentoFinal.Value.Date);

            if (dataBaixaInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento.Date >= dataBaixaInicial.Value.Date)); 

            if (dataBaixaFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento.Date <= dataBaixaFinal.Value.Date));

            if (tipoReceitaId.Any())
                _queryParcela = _queryParcela.Where(x => tipoReceitaId.Any(tipos => tipos == x.Receita.TipoId));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId));

            if (tipoAditamentoId.Any())
                _queryParcela = _queryParcela.Where(x => tipoAditamentoId.Any(id => id == x.Receita.Contrato.TipoAditamentoId.Value));

            if (tipoServicoId.Any())
                _queryParcela = _queryParcela.Where(x => x.TipoServicoId != null && tipoServicoId.Any(id => id == x.TipoServicoId.Value));

            return _queryParcela;

        }

        public void InsertBaixaComprovante(ReceitaBaixaComprovante comprovantePagamento)
        {
            _context.Add(comprovantePagamento);
        } 

        public IQueryable<Receita> GetRelatorioContratosEmAtraso(int[] empreendimentoId, int? numeroContrato, int? mesesVencimentoInicio, int? mesesVencimentoFim, int? quantidadeParcelasMinima, int? quantidadeParcelasMaxima, int[] empresaId, int? diasVencimentoInicio, int? diasVencimentoFim)
        { 

            var _queryReceita = _context.Receitas.AsNoTracking()
                     .Include(x => x.Contrato)
                        .ThenInclude(x => x.UnidadePrincipal)
                            .ThenInclude(x => x.Grupo) 
                    .Include(x => x.Empreendimento)
                    .Include(x => x.Parcelas)
                        .ThenInclude(x => x.Baixas)
                    .Include(x => x.Cliente)
                     .Include(x => x.Contrato.Empresa)
                    .Include(x => x.Contrato)
                        .ThenInclude(x => x.Situacao)
                    .Include(x => x.Parcelas)
                        .ThenInclude(x => x.Agrupador)
                 .Where(x => x.Contrato != null
                    && x.TipoId == TipoReceita.Titulo.Id
                    && x.Parcelas.Any()
                    && x.Contrato.SituacaoId != SituacaoContrato.Cancelado.Id
                    && x.Contrato.SituacaoId != SituacaoContrato.Aditado.Id
                    && x.Parcelas.Any(x => x.DataVencimento.Date < DateTime.Now.Date
                                        && (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                                        && x.IsAgrupador == false
                                        && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id)));

            if (mesesVencimentoFim.HasValue)
                _queryReceita = _queryReceita
                                    .Where(x => x.Parcelas
                                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) &&(x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) && x.IsAgrupador == false)
                                    .OrderBy(x => x.DataVencimento)
                                    .FirstOrDefault().DataVencimento.Date > DateTime.Now.AddMonths((mesesVencimentoFim.Value + 1) * -1).Date);


            if (diasVencimentoFim.HasValue)
                _queryReceita = _queryReceita.Where(x => x.Parcelas
                                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) && x.IsAgrupador == false)
                                    .OrderBy(x => x.DataVencimento)
                                    .FirstOrDefault().DataVencimento.Date >= DateTime.Now.AddDays(diasVencimentoFim.Value * -1).Date);

            if (quantidadeParcelasMaxima.HasValue)
                _queryReceita = _queryReceita
                    .Where(x => x.Parcelas
                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) 
                    && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) && x.IsAgrupador == false)
                    .Count(x => x.DataVencimento.Date < DateTime.Now.Date) <= quantidadeParcelasMaxima);
           
            if (empreendimentoId.Any())
                _queryReceita = _queryReceita.Where(x => empreendimentoId.Any(id => id == x.Contrato.EmpreendimentoId) || x.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (numeroContrato.HasValue)
                _queryReceita = _queryReceita.Where(x => x.Contrato.Numero == numeroContrato);

            if (empresaId.Any())
                _queryReceita = _queryReceita.Where(x => empresaId.Any(id => id == x.Contrato.EmpresaId));


            if (mesesVencimentoInicio.HasValue)
                _queryReceita = _queryReceita.Where(x => x.Parcelas
                                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) && x.IsAgrupador == false)
                                    .OrderBy(x => x.DataVencimento)
                                    .FirstOrDefault().DataVencimento.Date <= DateTime.Now.AddMonths(mesesVencimentoInicio.Value * -1).Date);

            if (diasVencimentoInicio.HasValue)
                _queryReceita = _queryReceita.Where(x => x.Parcelas
                                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) && x.IsAgrupador == false)
                                    .OrderBy(x => x.DataVencimento)
                                    .FirstOrDefault().DataVencimento.Date <= DateTime.Now.AddDays(diasVencimentoInicio.Value * -1).Date);


            if (quantidadeParcelasMinima.HasValue)
                _queryReceita = _queryReceita
                    .Where(x => x.Parcelas
                    .Where(x => (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id) 
                    && (x.Agrupador == null || x.Agrupador.SituacaoId != SituacaoReceitaParcela.Pago.Id) 
                    && x.IsAgrupador == false)
                    .Count(x => x.DataVencimento.Date < DateTime.Now.Date) >= quantidadeParcelasMinima);

            return _queryReceita;


        }

        public IQueryable<ReceitaParcela> ObterParcelasBoletoCobranca(int[] empreendimentoId, bool? boletoGerado, int? numeroContrato, bool? pagamentoAutomatico, int? clienteId, int[] tipoReceitaId, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
           int[] empresaId, int? sequenciaContrato, DateTime? dataCobrancaInicial, DateTime? dataCobrancaFinal, int[] loteId, int[] quadraId, int[] situacaoParcelaId, DateTime? dataBaixaInicial, DateTime? dataBaixaFinal)
        {

            IQueryable<ReceitaParcela> _queryParcela;
            _queryParcela = _context.ReceitaParcelas.AsNoTracking()
                .Include(x => x.Receita)
                    .ThenInclude(x => x.Tipo)
                .Include(x => x.Receita)
                    .ThenInclude(x => x.Cliente)
                .Include(x => x.Situacao)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.FormaPagamento)
                .Include(x => x.Baixas)
                .Include(x => x.Receita)
                    .ThenInclude(x => x.Contrato)
                        .ThenInclude(x => x.UnidadePrincipal)
                            .ThenInclude(x => x.Grupo)
                .Include(x => x.Receita)
                    .ThenInclude(x => x.Empreendimento)
                .Include(x => x.Receita)
                    .ThenInclude(x => x.Empresa)
                .Include(x => x.Receita)
                   .ThenInclude(x => x.Contrato);


            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => empreendimentoId.Any(id => id == x.Receita.EmpreendimentoId) || x.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (numeroContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.Numero == numeroContrato);
            }
            if (sequenciaContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Receita.Contrato.Sequencia == sequenciaContrato);
            }

            if (pagamentoAutomatico.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.Automatica == pagamentoAutomatico));

            if (clienteId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Receita.ClienteId == clienteId);

            if (dataVencimentoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date >= dataVencimentoInicial.Value.Date);

            if (dataVencimentoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataVencimentoFinal.Value.Date);

            if (dataCobrancaInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataEnvioCobranca >= dataCobrancaInicial.Value.Date);

            if (dataCobrancaFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataEnvioCobranca <= dataCobrancaFinal.Value.Date);

            if (loteId.Any())
                _queryParcela = _queryParcela.Where(x => loteId.Any(id => id == x.Receita.Contrato.UnidadePrincipalId.Value));

            if (quadraId.Any())
                _queryParcela = _queryParcela.Where(x => quadraId.Any(id => id == x.Receita.Contrato.UnidadePrincipal.GrupoId));

            if (tipoReceitaId.Any())
                _queryParcela = _queryParcela.Where(x => tipoReceitaId.Any(tipos => tipos == x.Receita.TipoId));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId));

            if(boletoGerado.HasValue)
                    _queryParcela = boletoGerado == true ? _queryParcela.Where(x => !string.IsNullOrEmpty(x.UrlBoleto)) : _queryParcela.Where(x => string.IsNullOrEmpty(x.UrlBoleto));

            if (situacaoParcelaId.Any())
            {
                _queryParcela = _queryParcela.Where(x => situacaoParcelaId.Any(id => id == x.SituacaoId));
            }
            else
            {
                _queryParcela = _queryParcela.Where(x => x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id);
            }

            if (dataBaixaInicial.HasValue)
            {
                //_queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= dataBaixaInicial));
                _queryParcela = _queryParcela.Where(x => x.Baixas != null && x.Baixas.Any(x => !x.Cancelado) && x.Baixas.Where(x => !x.Cancelado).OrderBy(x=>x.DataPagamento).LastOrDefault().DataPagamento >= dataBaixaInicial);
            }


            if (dataBaixaFinal.HasValue)
            {
                // _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= dataBaixaFinal));
                _queryParcela = _queryParcela.Where(x => x.Baixas != null && x.Baixas.Any(x => !x.Cancelado) && x.Baixas.Where(x => !x.Cancelado).OrderBy(x => x.DataPagamento).LastOrDefault().DataPagamento <= dataBaixaFinal);
               
            }


            return _queryParcela;

        }

        public async Task<int> GetTotalParcelas(int parcelaId)
        {
            var receita = await GetAllNoTracking("Parcelas").Where(x => x.Parcelas.Any(x => x.Id == parcelaId)).FirstOrDefaultAsync();
            return receita.Parcelas.Count(x => x.IsAgrupador == false);

        }
        public async Task<int> ProximoNumero()
        {
            var numerosSafra = await _context.ReceitaParcelas
                .AsNoTracking()
                .Select(x=>x.NossoNumero)
                .Where(x => x != null && x != "")
                .ToListAsync();

            if (numerosSafra == null || numerosSafra.Count() <= 0)
                return 0;

             return numerosSafra.ConvertAll(s => Convert.ToInt32(s)).OrderByDescending(x => x).Take(1)
                .SingleOrDefault() + 1;

           /* var teste3 = teste2.OrderByDescending(x => x).Take(1)
                .SingleOrDefault();
            return int.Parse(_context.ReceitaParcelas.AsNoTracking()
                .OrderByDescending(x => x.NossoNumero).Take(1)
                .SingleOrDefault()?.NossoNumero ?? "-1") + 1; */

        } 

        public IQueryable<ReceitaBaixa> GetBaixasRelatorio(int[] empreendimentoId, int[] empresaId, int[] situacaoParcelaId, bool? isBaixaAutomatica, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal)
        { 
            var baixasQuery = _context
                                    .Set<ReceitaBaixa>()
                                    .Include("Parcela.Receita.Contrato.UnidadePrincipal.Grupo")
                                    .Include("Parcela.Receita.Contrato.Corretores")
                                    .Include("Parcela.Receita.Empreendimento.Proprietarios.Proprietario")
                                    .Include("Parcela.Receita.Empresa")
                                    .Include("Parcela.Receita.Cliente")
                                    .Where(x=>!x.Cancelado && x.Parcela.Receita.ContratoId != null
                                   // && x.Parcela.Receita.TipoId != TipoReceita.Outros.Id
                                    && x.Parcela.Receita.Empreendimento != null
                                    && x.Parcela.Receita.Empreendimento.Proprietarios != null)
                                    .AsNoTracking();

            if(empreendimentoId.Any())
                baixasQuery = baixasQuery.Where(x => empreendimentoId.Any(id => id == x.Parcela.Receita.EmpreendimentoId) || x.Parcela.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaId.Any())
                baixasQuery = baixasQuery.Where(x => empresaId.Any(id => id == x.Parcela.Receita.EmpresaId));


            if (situacaoParcelaId.Any())
                baixasQuery = baixasQuery.Where(x => situacaoParcelaId.Any(id => id == x.Parcela.SituacaoId));

            if (isBaixaAutomatica.HasValue)
                baixasQuery = baixasQuery.Where(x => x.Automatica == isBaixaAutomatica);

            if (dataVencimentoInicial.HasValue)
                baixasQuery = baixasQuery.Where(x => x.Parcela.DataVencimento.Date >= dataVencimentoInicial.Value.Date);

            if (dataVencimentoFinal.HasValue)
                baixasQuery = baixasQuery.Where(x => x.Parcela.DataVencimento.Date <= dataVencimentoFinal.Value.Date);

            if (dataPagamentoInicial.HasValue)
                baixasQuery = baixasQuery.Where(x => x.DataPagamento.Date >= dataPagamentoInicial.Value.Date);

            if (dataPagamentoFinal.HasValue)
                baixasQuery = baixasQuery.Where(x => x.DataPagamento.Date <= dataPagamentoFinal.Value.Date);

            return baixasQuery;
        }

        public decimal CalcularAmortizacaoPorQuantidadeParcela(int id,int quantidadeParcela)
        {
            return  _context.Set<ReceitaParcela>()
                                .Where(x=>x.ReceitaId == id 
                                 && (x.SituacaoId == SituacaoReceitaParcela.Aberto.Id || x.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id )
                                 && !x.IsAgrupador
                                 && !x.IsAntecipador)
                                .OrderBy(x=>x.Parcela).Take(quantidadeParcela).Sum(x=>x.Amortizacao);
            //return 
        }

        public IQueryable<ReceitaParcela> GetParcelasRelatorioVgv(int[] empresasIds, int[] empreendimentosIds, int? ano)
        {
            IQueryable<ReceitaParcela> query = _context
                            .Set<ReceitaParcela>()
                            .Include(x=>x.Receita.Contrato)
                            .Where(x=>x.Receita.Contrato != null && x.AgrupadorId == null && x.AntecipadorId == null)
                            .AsNoTracking();

            if (empresasIds.Any())
                query = query.Where(x => empresasIds.Any(id => id == x.Receita.EmpresaId));

            if (empreendimentosIds.Any())
                query = query.Where(x => empreendimentosIds.Any(id => id == x.Receita.EmpreendimentoId) || x.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentosIds.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));


            if (ano.HasValue && ano != 0)
            {
                int anoInt = ano.Value;
                var dataProcuraInicio = new DateTime(anoInt, 1, 1);
                var dataProcuraFim = new DateTime(anoInt, 12, 31);

                query = query.Where(x => x.DataVencimento >= dataProcuraInicio && x.DataVencimento <= dataProcuraFim);
                // query = query.Where(x => x.DataVencimento.Date.Year >= anoInt && x.DataVencimento.Date.Year <= anoInt);
            }
                
            return query; 
        } 
          
        public IQueryable<ReceitaBaixa> GetRelatorioDimob(int[] situacaoContratoId, int[] empresasIds, int[] empreendimentosIds, string ano)
        {
            DateTime dataInicial = new DateTime(int.Parse(ano), 1, 1);
            DateTime dataFinal = new DateTime(int.Parse(ano), 12, 31);

            var query = _context.Set<ReceitaBaixa>().AsNoTracking();

             
            if(empresasIds.Any())
            {
                query = query.Where(x => empresasIds.Any(id => id == x.Parcela.Receita.Contrato.EmpresaId));
               // query = query.Where(x => x.Parcela.Receita.EmpresaId == empresaId.Value);
            }

            if (empreendimentosIds.Any())
            {
                query = query.Where(x => empreendimentosIds.Any(id => id == x.Parcela.Receita.Contrato.EmpreendimentoId));
                //query = query.Where(baixa => baixa.Parcela.Receita.Contrato.EmpreendimentoId == empreendimentoId.Value || baixa.Parcela.Receita.Contrato.UnidadesAdicionais.Any(x=>x.Unidade.Grupo.EmpreendimentoId == empreendimentoId));
            }

            if (string.IsNullOrEmpty(ano))
            {
                query = query.Where(x => x.Parcela.Receita.ContratoId != null && x.DataPagamento >= dataInicial && x.DataPagamento <= dataFinal && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Cancelado.Id && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Aditado.Id);

            }

            if (situacaoContratoId.Any())
            {
                query = query.Where(x => situacaoContratoId.Any(id => id == x.Parcela.Receita.Contrato.SituacaoId));
            }


            return query;
        }

       
        public IQueryable<ReceitaBaixa> ObterRelatorioEFD(int[] empresasIds, int[] empreendimentosIds, int? clienteId, string? ano, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal)  
        {
            //DateTime dataInicial= new DateTime(int.Parse(ano), 1, 1);
           // DateTime dataFinal = new DateTime(int.Parse(ano), 12, 31);

            var query = _context.Set<ReceitaBaixa>().AsNoTracking();

            if (empresasIds.Any())
            {
                query = query.Where(x => empresasIds.Any(id => id == x.Parcela.Receita.EmpresaId));
            }

            if (empreendimentosIds.Any())
            {
                query = query.Where(x => empreendimentosIds.Any(id => id == x.Parcela.Receita.Contrato.EmpreendimentoId));
            }

             if (clienteId.HasValue)
             {
                  query = query.Where(x => x.Parcela.Receita.ClienteId == clienteId.Value);
             }


            //if (empresaId.HasValue)
            // {
            //     query = query.Where(x => x.Parcela.Receita.EmpresaId == empresaId.Value);
            // }

            if (string.IsNullOrEmpty(ano))
            {
              //  query = query.Where(x => x.Parcela.Receita.ContratoId != null && x.DataPagamento >= dataInicial && x.DataPagamento <= dataFinal && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Cancelado.Id && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Aditado.Id);
            }
           // && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Cancelado.Id && x.Parcela.Receita.Contrato.SituacaoId != SituacaoContrato.Aditado.Id
            if (dataPagamentoInicial.HasValue && dataPagamentoFinal.HasValue)
            {
                query = query.Where(x => x.Parcela.Receita.ContratoId != null && x.DataPagamento >= dataPagamentoInicial && x.DataPagamento <= dataPagamentoFinal );
            }

            return query;
        }

        public async Task SetParcelasDiasPosVencimentoNaoReceberMax()
        {
            await  _context.Database.ExecuteSqlRawAsync("UPDATE financeiro.receitaparcela SET \"EncargoFinanceiro_DiasAposVencimentoNaoReceber\" = '59'");
        }

        public async Task SetDiasNegativacaoDefault()
        {
            await _context.Database.ExecuteSqlRawAsync("update  clientes.contrato set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.receitaparcela set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.antecipacaocomprovante set \"EncargoContrato_DiasNegativacao\"=0 where \"EncargoContrato_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.receitatransacao set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.planopagamentounidade set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.planopagamentomodelo set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.parametrogatway set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");
            await _context.Database.ExecuteSqlRawAsync("update financeiro.contacorrente set \"EncargoFinanceiro_DiasNegativacao\"=0 where \"EncargoFinanceiro_DiasNegativacao\" is null;\r\n");

        }

        #region KPIS
        public IQueryable<ReceitaParcela> KPITotalRecebiveis(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal)
        {
            IQueryable<ReceitaParcela> _queryParcela;
            _queryParcela = _context.ReceitaParcelas.AsNoTracking()
                .Include(x => x.Baixas)
                .Include(x => x.Receita)
                .Where(x=> x.SituacaoId != SituacaoReceitaParcela.Cancelado.Id && x.SituacaoId != SituacaoReceitaParcela.Aditado.Id && x.AgrupadorId == null);


            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => empreendimentoId.Any(id => id == x.Receita.EmpreendimentoId) || x.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId ));

            if (dataInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date >= dataInicial.Value.Date);

            if (dataFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataFinal.Value.Date);

            return _queryParcela;
        }
        public IQueryable<ReceitaParcela> ReceitasPainelReceita(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal)
        {
            IQueryable<ReceitaParcela> _queryParcela;
            _queryParcela = _context.ReceitaParcelas.AsNoTracking()
                .Include(x => x.Receita);



            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => empreendimentoId.Any(id => id == x.Receita.EmpreendimentoId) || x.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Receita.EmpresaId));

            if (dataInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date >= dataInicial.Value.Date);

            if (dataFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataFinal.Value.Date);

            return _queryParcela;
        }

        public IQueryable<ReceitaBaixa> BaixasPainelReceita(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal)
        {
            IQueryable<ReceitaBaixa> _queryBaixa;
            _queryBaixa = _context.Set<ReceitaBaixa>().AsNoTracking().Include(x => x.Parcela).ThenInclude(x => x.Receita).Where(x=> !x.Cancelado);
               




            if (empreendimentoId.Any())
                _queryBaixa = _queryBaixa.Where(x => empreendimentoId.Any(id => id == x.Parcela.Receita.EmpreendimentoId) || x.Parcela.Receita.Contrato.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaId.Any())
                _queryBaixa = _queryBaixa.Where(x => empresaId.Any(id => id == x.Parcela.Receita.EmpresaId));

            if (dataInicial.HasValue)
                _queryBaixa = _queryBaixa.Where(x => x.DataPagamento.Date >= dataInicial.Value.Date);

            if (dataFinal.HasValue)
                _queryBaixa = _queryBaixa.Where(x => x.DataPagamento.Date <= dataFinal.Value.Date);

            return _queryBaixa;
        }

        public IQueryable<ReceitaBaixa> GetFundoReserva(int empreendimentoId)
        {
            IQueryable<ReceitaBaixa> query = _context.Set<ReceitaBaixa>()
                            .Where(x => x.Id != 0);
            if (empreendimentoId != 0)
                query = query.Where(x => x.Parcela.Receita.EmpreendimentoId == empreendimentoId || x.Parcela.Receita.Contrato.UnidadesAdicionais.Any(u => u.Unidade.Grupo.EmpreendimentoId == empreendimentoId));

            return query;
        }
        #endregion

        public async Task<bool> NumeroDocumentoDuplicado(string numeroDocumento)
        {
            if (string.IsNullOrEmpty(numeroDocumento))
                return false;
            return await _context.Receitas.AnyAsync(x => x.NumeroDocumento.ToUpper() == numeroDocumento.ToUpper());
        }
    }
}
