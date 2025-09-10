using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SCAE.Data.Repository.Clientes
{
    public class ContratoRepository : CrudRepository<ScaeApiContext, Contrato>, IContratoRepository
    {
        public ContratoRepository(ScaeApiContext context) : base(context)
        {
            //_query = _query
            //    .Include(x => x.Unidade)
            //        .ThenInclude(x => x.Proprietarios)
            //    .Include(x => x.Unidade)
            //        .ThenInclude(x => x.Grupo)
            //            .ThenInclude(x => x.Empreendimento)
            //    .Include(x => x.Tipo)
            //        .ThenInclude(x => x.TipoOperacao)
            //    .Include(x => x.TipoProduto)
            //    .Include(x => x.Clientes)
            //        .ThenInclude(x => x.Cliente)
            //    .Include(x => x.Corretores)
            //        .ThenInclude(x => x.Corretor)
            //    .Include(x => x.Despesas)
            //    .Include(x => x.Vistorias)
            //        .ThenInclude(x => x.Fotos)
            //    .Include(x => x.Documentos)
            //    .Include(x => x.Empresa)
            //    .Include(x => x.Indice)
            //        .ThenInclude(x => x.TipoIndice)
            //    .Include(x => x.Receitas)
            //        .ThenInclude(t => t.Parcelas)
            //    .Include(x => x.Despesas)
            //        .ThenInclude(x => x.Parcelas)
            //    .Include(x => x.Receitas)
            //        .ThenInclude(x => x.Parcelas)
            //            .ThenInclude(x => x.Baixas)
            //                .ThenInclude(x => x.ContaCorrente)
            //                    .ThenInclude(x => x.Banco)
            //    .Include(x => x.EncargosFinanceiros);
        }

        public List<Contrato> GetAllTracking()
        {
            return GetAll().AsTracking().ToList();

        }
        public IQueryable<Contrato> GetContratoByCliente(int clienteId)
        {
            var contratos = GetAll()
                .Include(x => x.Empreendimento)
                    .Include(x => x.UnidadePrincipal).ThenInclude(y => y.Grupo)
                        .Include(x => x.Receitas).ThenInclude(y => y.Parcelas).ThenInclude(z => z.Baixas).ThenInclude(w => w.FormaPagamento)
                            .Where(x => x.Clientes.Any(y => y.ClienteId == clienteId));

            return contratos;
        }

        private IQueryable<ContratoDigital> SetIncludeContratoDigital(IQueryable<ContratoDigital> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public int ProximoNumero()
        {
            return _context.Contratos.AsNoTracking()
                .OrderByDescending(x => x.Numero).Take(1)
                .SingleOrDefault()?.Numero + 1 ?? 1;
        }

        public int ProximaSequencia(int numero)
        {
            return _context.Contratos.AsNoTracking()
                .Where(x => x.Numero == numero)
                .OrderByDescending(x => x.Sequencia).Take(1)
                .SingleOrDefault()?.Sequencia + 1 ?? 1;
        }

        public IQueryable<ContratoDigital> GetContratoDigitalAll(string include = "")
        {
            var query = _context.Set<ContratoDigital>();

            if (string.IsNullOrEmpty(include))
                return query;

            return SetIncludeContratoDigital(query, include);
        }

        public async Task<ContratoDigital> GetContratoDigitalByIdAsync(int contratoDigitalId, string include = "")
        {
            var query = GetContratoDigitalAll(include);
            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(contratoDigitalId));
        }
        public async Task<ContratoDigital> GetContratoDigitalByIdTrackingAsync(int contratoDigitalId, string include = "")
        {
            var query = GetContratoDigitalAll(include);
            return await query.SingleOrDefaultAsync(x => x.Id.Equals(contratoDigitalId));
        }

        public async Task UpdateContratoDigital(ContratoDigital contratoDigital)
        {
            _context.Update(contratoDigital);
        }

        public IQueryable<SignatarioContratoDigital> GetSignatariosAll()
        {
            return _context.Set<SignatarioContratoDigital>().Include("Cliente");
        }

        public async Task<SignatarioContratoDigital> GetSignatarioByIdNoIncludeAsync(int id)
        {
            return _context.Set<SignatarioContratoDigital>().SingleOrDefault(x => x.Id.Equals(id));
        }

        public async Task RemoveSignatario(int id)
        {
            var entity = await GetSignatarioByIdNoIncludeAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task<ContratoDigital> GetContratoDigitalByDFourSignId(string dFourSignDocumentId, string include = "")
        {
            var query = GetContratoDigitalAll(include);

            return await query.SingleOrDefaultAsync(x => x.DFourSignDocumentId == dFourSignDocumentId);
        }

        public async Task RemoveContratoDigital(int id)
        {
            var entity = await GetContratoDigitalByIdAsync(id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public IQueryable<ContratoDigital> GetRelatorioContratoDigital(int[] empresasIds, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataEnvioAssinaturaInicial, DateTime? dataEnvioAssinaturaFinal, DateTime? dataAssinaturaInicial, DateTime? dataAssinaturaFinal)
        {
            IQueryable<ContratoDigital> query = _context.Set<ContratoDigital>().Include(x => x.Contrato).AsNoTracking();

            if (empresasIds.Any())
                query = query.Where(x => empresasIds.Contains(x.Contrato.EmpresaId));

            if (dataEmissaoInicial != null)
                query = query.Where(x => x.DataEmissao.Date >= dataEmissaoInicial.Value.Date);

            if (dataEmissaoFinal != null)
                query = query.Where(x => x.DataEmissao.Date <= dataEmissaoFinal.Value.Date);

            if (dataAssinaturaInicial != null)
                query = query.Where(x => x.DataFinalizado.Value.Date >= dataAssinaturaInicial.Value.Date);

            if (dataAssinaturaFinal != null)
                query = query.Where(x => x.DataFinalizado.Value.Date <= dataAssinaturaFinal.Value.Date);

            if (dataEnvioAssinaturaInicial != null)
                query = query.Where(x => x.DataUploadDocumento.Value.Date >= dataEnvioAssinaturaInicial.Value.Date);

            if (dataEnvioAssinaturaFinal != null)
                query = query.Where(x => x.DataUploadDocumento.Value.Date <= dataEnvioAssinaturaFinal.Value.Date);

            return query;
        }

        public async Task<ContratoUnidadeAdicional> GetContratoUnidadeAdicional(int contratoUnidadeAdicionalId, string include = "")
        {
            var query = SetIncludeContratoUnidadeAdicional(_context.Set<ContratoUnidadeAdicional>(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id == contratoUnidadeAdicionalId);
        }

        public async Task RemoveContratoUnidadeAdicional(int contratoUnidadeAdicionalId)
        {
            var entity = await GetContratoUnidadeAdicional(contratoUnidadeAdicionalId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        private IQueryable<ContratoUnidadeAdicional> SetIncludeContratoUnidadeAdicional(IQueryable<ContratoUnidadeAdicional> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public async Task InsertList(List<Contrato> list)
        {
            await _context.AddRangeAsync(list);
        }

        public void UpdateList(List<Contrato> list)
        {
            _context.UpdateRange(list);
        }
         
        public IQueryable<Contrato> RelatorioGeralVendas(int[] empreendimentoIds, int[] empresaIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal, int? numeroContrato, int? idCliente, int? situacaoContrato, DateTime? dataSituacaoInicial, DateTime? dataSituacaoFinal)
        {
            IQueryable<Contrato> query = _context.Contratos.AsNoTracking()
                                            .Include(x => x.UnidadePrincipal)
                                                    .ThenInclude(x => x.Grupo)
                                                    .ThenInclude(x => x.Empreendimento)
                                                    .Include(x => x.HistoricoSituacoes)
                                            .Include(x => x.UnidadesAdicionais)
                                            .Include(x => x.Clientes)
                                                .ThenInclude(y => y.Cliente)
                                                    .ThenInclude(y => y.Endereco.Municipio)
                                                        .ThenInclude(y => y.Estado)
                                            .Include(x => x.UnidadePrincipal)
                                            .Include(x => x.Situacao)
                                            .Include(x => x.Receitas)
                                                .ThenInclude(x => x.Parcelas)
                                                    .ThenInclude(x => x.Baixas)
                                            .Where(x => x.Clientes.Any());


            if (empreendimentoIds.Any())
                query = query.Where(x => empreendimentoIds.Any(id => id == x.EmpreendimentoId) || x.UnidadesAdicionais.Any(x => empreendimentoIds.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaIds.Any())
                query = query.Where(x => empresaIds.Any(id => id == x.EmpresaId));

            if (dataContratoInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataContratoInicial.Value.Date);

            if (dataContratoFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataContratoFinal.Value.Date);

            if (numeroContrato.HasValue)
                query = query.Where(x => x.Numero == numeroContrato.Value);

            if (situacaoContrato.HasValue)
                query = query.Where(x => x.SituacaoId == situacaoContrato.Value);

            if (idCliente.HasValue)
                query = query.Where(x => x.Clientes.Any(cliente => cliente.ClienteId == idCliente));

            if (dataSituacaoInicial.HasValue)
                query = query.Where(x => x.HistoricoSituacoes.OrderBy(x => x.DataAlteracao.Date).LastOrDefault().DataAlteracao.Date >= dataSituacaoInicial.Value.Date);

            if (dataSituacaoFinal.HasValue)
                query = query.Where(x => x.HistoricoSituacoes.OrderBy(x => x.DataAlteracao.Date).LastOrDefault().DataAlteracao.Date <= dataSituacaoFinal.Value.Date);

            return query;
        }


        public IQueryable<Contrato> RelatorioGerencialCarteira(int[] empreendimentoIds, int[] empresaIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal, int? numeroContrato, int? idCliente, int? situacaoContrato, int? grupoId, int? unidadePrincipalId)
        {
            IQueryable<Contrato> query = _context.Contratos.AsNoTracking()
                                      
                                             //   .ThenInclude(x => x.Grupo)
                                                   // .ThenInclude(x => x.Empreendimento)
                                          //  .Include(x => x.UnidadesAdicionais)
                                           // .Include(x => x.Clientes)
                                              //  .ThenInclude(y => y.Cliente)
                                                    //.ThenInclude(y => y.Endereco.Municipio)
                                                       // .ThenInclude(y => y.Estado)
                                           // .Include(x => x.UnidadePrincipal)
                                           // .Include(x => x.Situacao)
                                            .Include(x => x.Receitas)
                                                //.ThenInclude(x => x.Parcelas)
                                                  //  .ThenInclude(x => x.Baixas)
                                            .Where(x => x.Clientes.Any());
            

            if (empreendimentoIds.Any())
                query = query.Where(x => empreendimentoIds.Any(id => id == x.EmpreendimentoId) || x.UnidadesAdicionais.Any(x => empreendimentoIds.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));

            if (empresaIds.Any())
                query = query.Where(x => empresaIds.Any(id => id == x.EmpresaId));

            if (dataContratoInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataContratoInicial.Value.Date);

            if (dataContratoFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataContratoFinal.Value.Date);

            if (numeroContrato.HasValue)
                query = query.Where(x => x.Numero == numeroContrato.Value);

            if (situacaoContrato.HasValue)
                query = query.Where(x => x.SituacaoId == situacaoContrato.Value);


            if (unidadePrincipalId.HasValue)
                query = query.Where(x => x.UnidadePrincipalId == unidadePrincipalId.Value);


            if (grupoId.HasValue)
                query = query.Where(x => x.UnidadePrincipal.GrupoId == grupoId.Value);


            if (idCliente.HasValue)
                query = query.Where(x => x.Clientes.Any(cliente => cliente.ClienteId == idCliente));

            return query;
        }


        public IQueryable<Contrato> AditadosRelatorioReceita(int[] empreendimentoId, int[] empresaId, DateTime? dataInicial, DateTime? dataFinal)
        {
            IQueryable<Contrato> query = _context.Contratos.AsNoTracking()
                                            .Include(x => x.UnidadePrincipal)
                                                .ThenInclude(x => x.Grupo)
                                                    .ThenInclude(x => x.Empreendimento)
                                            .Include(x => x.UnidadesAdicionais)
                                            .Include(x => x.UnidadePrincipal)
                                            .Include(x => x.Situacao)
                                            .Include(x => x.TipoAditamento)
                                            .Where(x => x.Situacao.Id == SituacaoContrato.Aditado.Id);

            if (empreendimentoId.Any())
                query = query.Where(x => empreendimentoId.Any(id => id == x.EmpreendimentoId) || x.UnidadesAdicionais.Any(x => empreendimentoId.Any(id => id == x.Unidade.Grupo.EmpreendimentoId)));
            if (empresaId.Any())
                query = query.Where(x => empresaId.Any(id => id == x.EmpresaId));
            if (dataInicial.HasValue)
                query = query.Where(x => x.Data.Date >= dataInicial.Value.Date);
            if (dataFinal.HasValue)
                query = query.Where(x => x.Data.Date <= dataFinal.Value.Date);

            return query;
        }

        public async Task InsertContratoDigital(ContratoDigital model)
        {
            await _context.AddAsync(model);
            await SaveChangesAsync();
        }
    }
}
