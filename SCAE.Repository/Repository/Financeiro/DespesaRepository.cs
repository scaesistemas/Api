using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Data.Context;
using SCAE.Data.Repository.Shared;
using SCAE.Data.Interface.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Clientes;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SCAE.Data.Repository.Financeiro
{
    public class DespesaRepository : CrudRepository<ScaeApiContext, Despesa>, IDespesaRepository
    {
       // private IQueryable<DespesaParcela> _queryParcela;
      //  private IQueryable<DespesaClassificacao> _queryClassificacao;

        public DespesaRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Tipo)
            //    .Include(x => x.TipoDocumento)
            //    .Include(x => x.Fornecedor)
            //    .Include(x => x.Parcelas)
            //        .ThenInclude(y => y.Situacao)
            //    .Include(x => x.Parcelas)
            //        .ThenInclude(y => y.Baixas)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.CentroCusto)
            //    .Include(x => x.Classificacoes)
            //        .ThenInclude(x => x.ContaGerencial);

         /*   _queryParcela = context.Set<DespesaParcela>();
            _queryParcela = _queryParcela
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Tipo)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.TipoDocumento)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Fornecedor)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(x => x.CentroCusto)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(x => x.ContaGerencial)
                .Include(x => x.Situacao)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.FormaPagamento)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.ContaCorrente);

            _queryClassificacao = context.Set<DespesaClassificacao>();  */
        }

        private IQueryable<DespesaParcela> SetInclude(IQueryable<DespesaParcela> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        private IQueryable<DespesaBaixa> SetIncludeBaixa(IQueryable<DespesaBaixa> query, string include) 
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        private IQueryable<DespesaClassificacao> SetIncludeClassificacao(IQueryable<DespesaClassificacao> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public IQueryable<DespesaParcela> GetParcelaAll (string include = "")
        {
            var query = _context.Set<DespesaParcela>();

            if (string.IsNullOrEmpty(include))
                return query;

            
            return SetInclude(query, include);
        }
        public IQueryable<DespesaParcela> GetParcelaAllAsNoTracking (string include = "")
        {
            var query = _context.Set<DespesaParcela>();

            if (string.IsNullOrEmpty(include))
                return query.AsNoTracking();


            return SetInclude(query, include).AsNoTracking();
        }

        public async Task<List<DespesaParcela>> GetParcelaAllByCentroCustoAsNoTracking(int centroCustoId,string include = "")
        {
     
            var query = GetAllNoTracking(include).Include("Parcelas").Where(x => x.Classificacoes.Select(y => y.CentroCustoId).Contains(centroCustoId)).SelectMany(x => x.Parcelas);


            return await query.ToListAsync();
        }

        public async Task<List<DespesaParcela>> GetParcelaAllByContaGerencialAsNoTracking(int contaGerencialId, string include = "")
        {
            var query = GetAllNoTracking(include).Include("Parcelas").Where(x => x.Classificacoes.Select(y => y.ContaGerencialId).Contains(contaGerencialId)).SelectMany(x => x.Parcelas);


            return await query.ToListAsync();
        }

        public IQueryable<DespesaParcela> GetParcelaAllNoInclude()
        {
            return _context.Set<DespesaParcela>();
        }

        public async Task<DespesaParcela> GetParcelaByIdAsync(int id, string include = "")
        {
            var query = SetInclude(GetParcelaAllNoInclude(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<DespesaParcela> GetParcelaByIdTrakingAsync(int id, string include = "")
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

        public void UpdateParcela(DespesaParcela parcela)
        {
            _context.Update(parcela);
        }

        public void UpdateBaixa(DespesaBaixa baixa)
        {
            _context.Update(baixa);
        }

        public IQueryable<DespesaClassificacao> GetClassificacaoAll()
        {
            return _context.Set<DespesaClassificacao>();//_queryClassificacao;
        }

        public IQueryable<DespesaBaixa> GetBaixaAllNoInclude()
        {
            return _context.Set<DespesaBaixa>();
        }
        public IQueryable<DespesaBaixa> GetBaixaAll(string include = "") 
        {

            var query = _context.Set<DespesaBaixa>();

            if (string.IsNullOrEmpty(include))
                return query; 

            return SetIncludeBaixa(query, include);
        }

        public async Task<DespesaBaixa> GetBaixaByIdTrakingAsync(int id)
        {
            return await _context.Set<DespesaBaixa>().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
        public async Task<DespesaClassificacao> GetDespesaClassificacaoByIdTracking(int id) 
        {
            return await _context.Set<DespesaClassificacao>().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<DespesaParcela>> GetParcelasByCentroCusto(int[] empresaId,int centroCusto, int tipo, DateTime anoInicio, DateTime anoFim)
        {
            IQueryable<DespesaParcela> queryParcela = _context.DespesaParcelas
                .AsNoTracking()
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.ContaGerencial)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.CentroCusto)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.ContaCorrente)
                .Include(x => x.Situacao);


            if (empresaId.Any())
                queryParcela = queryParcela.Where(x => empresaId.Any(id => id == x.Despesa.EmpresaId));


            //tipo 1 = data de vencimento
            if (tipo == 1)
            {
                queryParcela = queryParcela.Where(x => x.DataVencimento >= anoInicio);
                queryParcela = queryParcela.Where(x => x.DataVencimento <= anoFim);
            }
            //tipo 2 = data de pagamento
            if (tipo == 2)
            {
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= anoInicio && b.Cancelado == false));
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= anoFim && b.Cancelado == false));
            }


            return await queryParcela.Where(x => x.Despesa.Classificacoes.Any(y => y.CentroCustoId == centroCusto)).ToListAsync();

        }

        public async Task<List<DespesaParcela>> GetParcelasByContaGerencial(int[] empresaId, int contaGerencial, int tipo, DateTime anoInicio, DateTime anoFim)
        {
            IQueryable<DespesaParcela> queryParcela = _context.DespesaParcelas
                .AsNoTracking()
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.ContaGerencial)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.CentroCusto)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.ContaCorrente)
                .Include(x => x.Situacao);


            if (empresaId.Any())
                queryParcela = queryParcela.Where(x => empresaId.Any(id => id == x.Despesa.EmpresaId));


            //tipo 1 = data de vencimento
            if (tipo == 1)
            {
                queryParcela = queryParcela.Where(x => x.DataVencimento >= anoInicio);
                queryParcela = queryParcela.Where(x => x.DataVencimento <= anoFim);
            }
            //tipo 2 = data de pagamento
            if (tipo == 2)
            {
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= anoInicio && b.Cancelado == false));
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= anoFim && b.Cancelado == false));
            }


            return await queryParcela.Where(x => x.Despesa.Classificacoes.Any(y => y.ContaGerencialId == contaGerencial)).ToListAsync();

        }

        public async Task<List<DespesaParcela>> ObterParcelas(int? empreendimentoId,int? despesaOrigemId,int centroCustoId, int contaGerencialId, char? contaGerencialTipo,
            DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
            DateTime? dataBaixaInicial, DateTime? dataBaixaFinal,int? formaPagamentoId, int? contaCorrenteId)
        {
            IQueryable<DespesaParcela> queryParcela = _context.DespesaParcelas
                .AsNoTracking()
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.ContaGerencial)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Classificacoes)
                        .ThenInclude(z => z.CentroCusto)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.ContaCorrente)
                .Include(x => x.Situacao);


            if (empreendimentoId.HasValue)
                queryParcela = queryParcela.Where(x => x.Despesa.EmpreendimentoId == empreendimentoId);

            if (despesaOrigemId.HasValue)
                queryParcela = queryParcela.Where(x => x.Despesa.OrigemId == despesaOrigemId);

            if (dataEmissaoInicial.HasValue)
                queryParcela = queryParcela.Where(x => x.Despesa.DataEmissao >= dataEmissaoInicial);

            if (dataEmissaoFinal.HasValue)
                queryParcela = queryParcela.Where(x => x.Despesa.DataEmissao <= dataEmissaoFinal);

            if (dataVencimentoInicial.HasValue)
                queryParcela = queryParcela.Where(x => x.DataVencimento >= dataVencimentoInicial);

            if (dataVencimentoFinal.HasValue)
                queryParcela = queryParcela.Where(x => x.DataVencimento <= dataVencimentoFinal);

            if (dataBaixaInicial.HasValue)
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento >= dataBaixaInicial && b.Cancelado == false));

            if (dataBaixaFinal.HasValue)
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento <= dataBaixaFinal && b.Cancelado == false));

            if (centroCustoId > 0)
                queryParcela = queryParcela.Where(x => x.Despesa.Classificacoes.Any(c => c.CentroCustoId == centroCustoId));

            if (contaGerencialId > 0)
                queryParcela = queryParcela.Where(x => x.Despesa.Classificacoes.Any(c => c.ContaGerencialId == contaGerencialId));

            if (contaGerencialTipo.HasValue)
                queryParcela = queryParcela.Where(x => x.Despesa.Classificacoes.Any(c => c.ContaGerencial.Tipo == contaGerencialTipo.Value.ToString()));

            if (formaPagamentoId.HasValue)
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.FormaPagamentoId == formaPagamentoId));

            if (contaCorrenteId.HasValue)
                queryParcela = queryParcela.Where(x => x.Baixas.Any(b => b.ContaCorrenteId == contaCorrenteId));

            return await queryParcela.ToListAsync();

        }

        public async Task<DespesaDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _context.Set<DespesaDocumento>().AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<DespesaClassificacao> GetClassificacaoByIdAsync(int id,string include = "")
        {
            var query = SetIncludeClassificacao(_context.Set<DespesaClassificacao>().AsNoTracking(),include);
            return await query.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<List<DespesaDocumento>> GetDocumentos(int despesaId)
        {
            return await _context.Set<DespesaDocumento>().AsNoTracking()
                .Where(x => x.DespesaId == despesaId)
                .Select(x => new DespesaDocumento(
                    x.Id,
                    x.DespesaId,
                    x.Nome,
                    x.Tamanho,
                    x.Tipo
                )).ToListAsync();
        }

        public async Task RemoveDocumento(int id)
        {
            var entity = await GetDocumentoByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
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
                .Include(x => x.Comprovante)
                .AsNoTracking()
                .Where(x => x.ParcelaId == parcelaId)
                .Select(x => new {
                    x.Id,
                    x.ParcelaId,
                    x.ContaCorrenteId,
                    x.ContaCorrente,
                    x.DataPagamento,
                    x.Desconto,
                    x.Juros,
                    x.Valor,
                    x.Total,
                    Comprovante = new
                    {
                        x.Comprovante.Nome,
                        x.Comprovante.Tamanho,
                        x.Comprovante.Tipo
                    }
                }).ToListAsync();
        }

        public IQueryable<DespesaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, int? formaPagamento, int? usuarioBaixa, int? fornecedorId, int[] situacaoParcelaId, int? contratoId, int[] tipoDespesaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal,
    DateTime? dataBaixaInicial, DateTime? dataBaixaFinal, int[] empresaId, int[] tipoAditamentoId, int? despesaId, string numeroDocumento, int[] centroCustoId, int[] contaGerencialId,int? contaCorrenteId)
        { 

            IQueryable<DespesaParcela> _queryParcela;
            _queryParcela = _context.DespesaParcelas.AsNoTracking()
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Tipo)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Fornecedor)
                .Include(x => x.Situacao)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.FormaPagamento)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.Usuario)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Contrato)
                        .ThenInclude(x => x.UnidadePrincipal)
                            .ThenInclude(x => x.Grupo)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Empreendimento)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Empresa)
                .Include(x => x.Despesa)
                   .ThenInclude(x => x.Contrato)
                        .ThenInclude(x => x.TipoAditamento)
                 .Include(x => x.Baixas)
                    .ThenInclude(x => x.Parcela)
                 .Include(x=>x.Baixas)
                    .ThenInclude(x=>x.ContaCorrente);


            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoId.Any(id => id == x.Despesa.EmpreendimentoId.Value));

            if (numeroContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Despesa.Contrato.Numero == numeroContrato);
            }

            //if (pagamentoAutomatico.HasValue)
            //    _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.Automatica == pagamentoAutomatico));

            if (formaPagamento.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.FormaPagamentoId == formaPagamento));

            if (usuarioBaixa.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.UsuarioId == usuarioBaixa));

            if (contaCorrenteId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.ContaCorrenteId == contaCorrenteId));

            if (fornecedorId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.FornecedorId == fornecedorId);

            if (situacaoParcelaId.Any())
                _queryParcela = _queryParcela.Where(x => situacaoParcelaId.Any(id => id == x.SituacaoId));
            else
                _queryParcela = _queryParcela.Where(x => x.SituacaoId != SituacaoDespesaParcela.Cancelado.Id); //&& x.SituacaoId != SituacaoDespesaParcela.Aditado.Id);

            if (contratoId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.ContratoId == contratoId);

            if (dataEmissaoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.DataEmissao.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.DataEmissao.Date <= dataEmissaoFinal.Value.Date);

            if (dataVencimentoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date >= dataVencimentoInicial.Value.Date);

            if (dataVencimentoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataVencimentoFinal.Value.Date);

            if (dataBaixaInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento.Date >= dataBaixaInicial.Value.Date));

            if (dataBaixaFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento.Date <= dataBaixaFinal.Value.Date));

            if (tipoDespesaId.Any())
                _queryParcela = _queryParcela.Where(x => tipoDespesaId.Any(tipos => tipos == x.Despesa.TipoId));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Despesa.EmpresaId));

            if (tipoAditamentoId.Any())
                _queryParcela = _queryParcela.Where(x => tipoAditamentoId.Any(id => id == x.Despesa.Contrato.TipoAditamentoId.Value));

            if (despesaId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DespesaId == despesaId);

            if (!string.IsNullOrEmpty(numeroDocumento))
                _queryParcela = _queryParcela.Where(x => x.Despesa.NumeroDocumento.ToUpper() == numeroDocumento.ToUpper()) ;

            if(centroCustoId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.Classificacoes.Any(x => centroCustoId.Any(id => id == x.CentroCustoId)));

            if (contaGerencialId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.Classificacoes.Any(x => contaGerencialId.Any(id => id == x.ContaGerencialId)));

            return _queryParcela;

        }
        public IQueryable<DespesaParcela> ObterParcelasDetalhadas(int[] empreendimentoId, int? numeroContrato, int? formaPagamento, int? usuarioBaixa, int? fornecedorId, int[] situacaoParcelaId, int? contratoId, int[] tipoDespesaId, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, int[] anos, int[] meses,
                                            int[] empresaId, int[] tipoAditamentoId, int? despesaId, string numeroDocumento, int[] centroCustoId, int[] contaGerencialId, int? contaCorrenteId, bool filtrarVencimento, bool filtrarPagamento)
        {

            IQueryable<DespesaParcela> _queryParcela;
            _queryParcela = _context.DespesaParcelas.AsNoTracking()
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Tipo)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Fornecedor)
                .Include(x => x.Situacao)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.FormaPagamento)
                .Include(x => x.Baixas)
                    .ThenInclude(x => x.Usuario)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Contrato)
                        .ThenInclude(x => x.UnidadePrincipal)
                            .ThenInclude(x => x.Grupo)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Empreendimento)
                .Include(x => x.Despesa)
                    .ThenInclude(x => x.Empresa)
                .Include(x => x.Despesa)
                   .ThenInclude(x => x.Contrato)
                        .ThenInclude(x => x.TipoAditamento)
                 .Include(x => x.Baixas)
                    .ThenInclude(x => x.Parcela)
                 .Include(x => x.Baixas)
                    .ThenInclude(x => x.ContaCorrente);


            if (empreendimentoId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoId.Any(id => id == x.Despesa.EmpreendimentoId.Value));

            if (numeroContrato.HasValue)
            {
                _queryParcela = _queryParcela.Where(x => x.Despesa.Contrato.Numero == numeroContrato);
            }

            //if (pagamentoAutomatico.HasValue)
            //    _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.Automatica == pagamentoAutomatico));

            if (formaPagamento.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.FormaPagamentoId == formaPagamento));

            if (usuarioBaixa.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.UsuarioId == usuarioBaixa));

            if (contaCorrenteId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(x => x.ContaCorrenteId == contaCorrenteId));

            if (fornecedorId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.FornecedorId == fornecedorId);

            if (situacaoParcelaId.Any())
                _queryParcela = _queryParcela.Where(x => situacaoParcelaId.Any(id => id == x.SituacaoId));
            else
                _queryParcela = _queryParcela.Where(x => x.SituacaoId != SituacaoDespesaParcela.Cancelado.Id); //&& x.SituacaoId != SituacaoDespesaParcela.Aditado.Id);

            if (contratoId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.ContratoId == contratoId);

            if (dataEmissaoInicial.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.DataEmissao.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal.HasValue)
                _queryParcela = _queryParcela.Where(x => x.Despesa.DataEmissao.Date <= dataEmissaoFinal.Value.Date);

            if (filtrarVencimento)
                _queryParcela = _queryParcela.Where(x => anos.Contains(x.DataVencimento.Year) && meses.Contains(x.DataVencimento.Month));

            // if (dataVencimentoFinal.HasValue)
            //     _queryParcela = _queryParcela.Where(x => x.DataVencimento.Date <= dataVencimentoFinal.Value.Date);

            if (filtrarPagamento)
                _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => anos.Contains(b.DataPagamento.Year) && meses.Contains(b.DataPagamento.Month)));

            // if (dataBaixaFinal.HasValue)
            //     _queryParcela = _queryParcela.Where(x => x.Baixas.Any(b => b.DataPagamento.Date <= dataBaixaFinal.Value.Date));

            if (tipoDespesaId.Any())
                _queryParcela = _queryParcela.Where(x => tipoDespesaId.Any(tipos => tipos == x.Despesa.TipoId));

            if (empresaId.Any())
                _queryParcela = _queryParcela.Where(x => empresaId.Any(id => id == x.Despesa.EmpresaId));

            if (tipoAditamentoId.Any())
                _queryParcela = _queryParcela.Where(x => tipoAditamentoId.Any(id => id == x.Despesa.Contrato.TipoAditamentoId.Value));

            if (despesaId.HasValue)
                _queryParcela = _queryParcela.Where(x => x.DespesaId == despesaId);

            if (!string.IsNullOrEmpty(numeroDocumento))
                _queryParcela = _queryParcela.Where(x => x.Despesa.NumeroDocumento.ToUpper() == numeroDocumento.ToUpper());

            if (centroCustoId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.Classificacoes.Any(x => centroCustoId.Any(id => id == x.CentroCustoId)));

            if (contaGerencialId.Any())
                _queryParcela = _queryParcela.Where(x => x.Despesa.Classificacoes.Any(x => contaGerencialId.Any(id => id == x.ContaGerencialId)));

            return _queryParcela;

        }

        public async Task InsertList(List<Despesa> list) 
        {
            await _context.AddRangeAsync(list);
        }

        public void UpdateList(List<Despesa> list) 
        {
            _context.UpdateRange(list);
        }

        public void RemoveList(List<Despesa> list)
        {
            _context.RemoveRange(list);
        }

        public void UpdateListParcela(List<DespesaParcela> list) 
        {
            _context.UpdateRange(list);
        }

        public IQueryable<DespesaParcela> RelatorioComissoesCorretor(int corretorId,int[] empreendimentoIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal)
        {
            IQueryable<DespesaParcela> queryParcela;

            queryParcela = _context.DespesaParcelas.AsNoTracking()
                                    .Include(x => x.Despesa)
                                        .ThenInclude(x => x.Contrato)
                                            .ThenInclude(x => x.HistoricoSituacoes)
                                    .Include(x => x.Despesa)
                                        .ThenInclude(x => x.Contrato)
                                            .ThenInclude(x => x.Clientes)
                                                .ThenInclude(x => x.Cliente)
                                    .Include(x => x.Baixas).Where(x => x.Despesa.ContratoId != null && x.Despesa.Contrato.HistoricoSituacoes.Any(x =>x.SituacaoId == SituacaoContrato.EmAndamento.Id) && x.Despesa.FornecedorId == corretorId);

            if (empreendimentoIds.Any())
                queryParcela = queryParcela.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(id => id == x.Despesa.EmpreendimentoId.Value));

            if (dataContratoInicial.HasValue)
                queryParcela = queryParcela.Where(x => x.DataVencimento.Date >= dataContratoInicial.Value.Date);
            
            if (dataContratoFinal.HasValue)
                queryParcela = queryParcela.Where(x => x.DataVencimento.Date <= dataContratoFinal.Value.Date);

            return queryParcela;
        }

        public async Task<bool> NumeroDocumentoDuplicado(Despesa despesa)
        {
            if (despesa == null || despesa.ContratoId != null)
                return false;

            var despesaFornecedor = await _context.Despesas.AnyAsync(x => x.NumeroDocumento.ToUpper() == despesa.NumeroDocumento.ToUpper() && x.Fornecedor.Id == despesa.FornecedorId);

            return despesaFornecedor;
        }


        public  IQueryable<DespesaParcela> PainelDespesaRelatorio(int[] empresaId, int[] empreendimentoId)
        {
            IQueryable<DespesaParcela> queryParcela;

             queryParcela = _context.DespesaParcelas.AsNoTracking().Include(x => x.Despesa);

            if (empreendimentoId.Any())
            {
                queryParcela = queryParcela.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoId.Any (y=> y == x.Despesa.EmpreendimentoId.Value));
            }

            if (empresaId.Any())
            {
                queryParcela = queryParcela.Where(x => empresaId.Any(y => y == x.Despesa.EmpresaId));
            }

            // Retornar a consulta resultante/
            return  queryParcela;
        }
        public IQueryable<DespesaBaixa> ObterBaixasDespesa(int[] empresaId, int[] empreendimentoId) 
        {

            IQueryable<DespesaBaixa> queryBaixa;

            queryBaixa = _context.DespesaBaixas.AsNoTracking().Include(x => x.Parcela).ThenInclude(x => x.Despesa);

            if (empreendimentoId.Any())
            {
                queryBaixa = queryBaixa.Where(x => x.Parcela.Despesa.EmpreendimentoId.HasValue && 
                                                    empreendimentoId.Any(y => y == x.Parcela.Despesa.EmpreendimentoId.Value));
            }

            if (empresaId.Any())
            {
                queryBaixa = queryBaixa.Where(x => empresaId.Any(y => y == x.Parcela.Despesa.EmpresaId));
            }

            // Retornar a consulta resultante/
            return queryBaixa;
        }

        public IQueryable<DespesaClassificacao> GetClassificacoesByCentroCusto(int centroCustoId,string include = "")
        {
            return SetIncludeClassificacao( GetClassificacaoAll().Where(x => x.CentroCustoId == centroCustoId),include);
        }

        public IQueryable<DespesaClassificacao> GetClassificacoesByContaGerencial(int contaGerencialId, string include = "")
        {
            return SetIncludeClassificacao(GetClassificacaoAll().Where(x => x.ContaGerencialId == contaGerencialId), include);
        }

        public IQueryable<DespesaParcela> GetParcelasRelatorios(int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal)
        {
            var query = _context
                           .DespesaParcelas
                           .AsNoTracking()
                           .Where(x => x.SituacaoId != SituacaoDespesaParcela.Cancelado.Id);

            if (empreendimentoIds.Length != 0)
            {
                query = query.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Despesa.EmpreendimentoId));
            }

            if(empresaIds.Length != 0)
            {
                query = query.Where(x => empresaIds.Any(empresa => empresa == x.Despesa.EmpresaId));
            }

            if(dataInicial.HasValue)
            {
                query = query.Where(x => x.DataVencimento.Date >= dataInicial.Value.Date);
            }

            if (dataFinal.HasValue)
            {
                query = query.Where(x => x.DataVencimento.Date <= dataFinal.Value.Date);
            }

            return query;

        }
        public IQueryable<DespesaParcela> GetAllParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataVencimentoInicial, DateTime? dataVencimentoFinal, DateTime? DataEmissaoInicial, DateTime? DataEmissaoFinal, DateTime? DataBaixaInicial, DateTime? DataBaixaFinal)
        {
            var query = _context
                          .DespesaParcelas
                          .Include("Baixas")
                          .AsNoTracking()
                          .Where(x => x.Situacao.Id != 2);

            if (empreendimentoIds.Length != 0)
            {
                query = query.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Despesa.EmpreendimentoId));
            }

            if (empresaIds.Length != 0)
            {
                query = query.Where(x => empresaIds.Any(empresa => empresa == x.Despesa.EmpresaId));
            }

            if (dataVencimentoInicial.HasValue)
            {
                query = query.Where(x => x.DataVencimento.Date >= dataVencimentoInicial.Value.Date);
            }

            if (dataVencimentoFinal.HasValue)
            {
                query = query.Where(x => x.DataVencimento.Date <= dataVencimentoFinal.Value.Date);
            }

            if (DataEmissaoInicial.HasValue)
            {
                query = query.Where(x => x.Despesa.DataEmissao.Date >= DataEmissaoInicial.Value.Date);
            }

            if (DataEmissaoFinal.HasValue)
            {
                query = query.Where(x => x.Despesa.DataEmissao.Date <= DataEmissaoFinal.Value.Date);
            }
            if (DataBaixaInicial.HasValue)
            {
                query = query.Where(x => x.Baixas.Any(x => x.DataPagamento >= DataBaixaInicial.Value.Date));
            }

            if (DataBaixaFinal.HasValue)
            {
                query = query.Where(x => x.Baixas.Any(x => x.DataPagamento <= DataBaixaFinal.Value.Date));
            }

            return query.Where(x => x.Despesa.Classificacoes.Any(x => x.Id == classificacaoId));
          }

        public IQueryable<DespesaParcela> GetAllParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? DataEmissaoInicial, DateTime? DataEmissaoFinal, int[] anos, int[] meses, bool filtrarVencimento, bool filtrarPagamento)
        {
            var query = _context
                          .DespesaParcelas
                          .Include("Baixas")
                          .AsNoTracking()
                          .Where(x => x.Situacao.Id != 2);

            if (empreendimentoIds.Length != 0)
            {
                query = query.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Despesa.EmpreendimentoId));
            }

            if (empresaIds.Length != 0)
            {
                query = query.Where(x => empresaIds.Any(empresa => empresa == x.Despesa.EmpresaId));
            }

            if (filtrarVencimento)
            {
                query = query.Where(x => anos.Contains(x.DataVencimento.Date.Year) && meses.Contains(x.DataVencimento.Date.Month));
            }

            if (DataEmissaoInicial.HasValue)
            {
                query = query.Where(x => x.Despesa.DataEmissao.Date >= DataEmissaoInicial.Value.Date);
            }

            if (DataEmissaoFinal.HasValue)
            {
                query = query.Where(x => x.Despesa.DataEmissao.Date <= DataEmissaoFinal.Value.Date);
            }
            if (filtrarPagamento)
            {
                query = query.Where(x => x.Baixas.Any(x => anos.Contains(x.DataPagamento.Date.Year) && meses.Contains(x.DataPagamento.Date.Month)));
            }

            return query.Where(x => x.Despesa.Classificacoes.Any(x => x.Id == classificacaoId));
        }

        public IQueryable<DespesaBaixa> GetBaixasRelatorios(int[] empreendimentoIds, int[] empresaIds, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal)
        {
            var query = _context
                           .DespesaBaixas
                           .AsNoTracking()
                           .Where(x => x.Cancelado == false);

            if (empreendimentoIds.Length != 0)
            {
                query = query.Where(x => x.Parcela.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Parcela.Despesa.EmpreendimentoId));
            }

            if (empresaIds.Length != 0)
            {
                query = query.Where(x => empresaIds.Any(empresa => empresa == x.Parcela.Despesa.EmpresaId));
            }

            if (dataPagamentoInicial.HasValue)
            {
                query = query.Where(x => x.DataPagamento.Date >= dataPagamentoInicial.Value.Date);
            }

            if (dataPagamentoFinal.HasValue)
            {
                query = query.Where(x => x.DataPagamento.Date <= dataPagamentoFinal.Value.Date);
            }

            return query;

        }

        public IQueryable<DespesaParcela> GetParcelasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal)
        {
           return GetParcelasRelatorios(empreendimentoIds, empresaIds, dataInicial, dataFinal).Where(x=>x.Despesa.Classificacoes.Any(x=>x.Id == classificacaoId));           
        }

        public IQueryable<DespesaBaixa> GetBaixasByClassificacao(int classificacaoId, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal)
        {
            return GetBaixasRelatorios(empreendimentoIds, empresaIds, dataInicial, dataFinal).Where(x => x.Parcela.Despesa.Classificacoes.Any(x => x.Id == classificacaoId));
        }

        public List<DespesaParcela> FiltrarParcelasRelatorio(List<DespesaParcela> parcelas, int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal)
        {
            var parcelasFiltradas = parcelas.Where(x => x.SituacaoId != SituacaoDespesaParcela.Cancelado.Id);

            if (empreendimentoIds.Length != 0)
            {
                parcelasFiltradas = parcelasFiltradas.Where(x => x.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Despesa.EmpreendimentoId));
            }
            if (empresaIds.Length != 0)
            {
                parcelasFiltradas = parcelasFiltradas.Where(x => empresaIds.Any(empresa => empresa == x.Despesa.EmpresaId));
            }
            if (dataInicial.HasValue)
            {
                parcelasFiltradas = parcelasFiltradas.Where(x => x.DataVencimento.Date >= dataInicial.Value.Date);
            }
            if (dataFinal.HasValue)
            {
                parcelasFiltradas = parcelasFiltradas.Where(x => x.DataVencimento.Date <= dataFinal.Value.Date);
            }
            return parcelasFiltradas.ToList();
        }

        public List<DespesaBaixa> FiltrarBaixasRelatorio(List<DespesaBaixa> baixas, int[] empreendimentoIds, int[] empresaIds, DateTime? dataPagamentoInicial, DateTime? dataPagamentoFinal)
        {
            var baixasFiltradas = baixas.Where(x => x.Cancelado == false);

            if (empreendimentoIds.Length != 0)
            {
                baixasFiltradas = baixasFiltradas.Where(x => x.Parcela.Despesa.EmpreendimentoId.HasValue && empreendimentoIds.Any(empreendimento => empreendimento == x.Parcela.Despesa.EmpreendimentoId));
            }
            if (empresaIds.Length != 0)
            {
                baixasFiltradas = baixasFiltradas.Where(x => empresaIds.Any(empresa => empresa == x.Parcela.Despesa.EmpresaId));
            }
            if (dataPagamentoInicial.HasValue)
            {
                baixasFiltradas = baixasFiltradas.Where(x => x.DataPagamento.Date >= dataPagamentoInicial.Value.Date);
            }
            if (dataPagamentoFinal.HasValue)
            {
                baixasFiltradas = baixasFiltradas.Where(x => x.DataPagamento.Date <= dataPagamentoFinal.Value.Date);
            }
            return baixasFiltradas.ToList();
        }

    }
}
