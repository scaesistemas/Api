using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SCAE.Data.Context;
using SCAE.Data.Interface.Empreendimento;
using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Empreendimento;
using SCAE.Domain.Models.Empreendimento.Relatorio;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SCAE.Data.Repository.Empreendimento
{
    public class EmpreendimentoRepository : CrudRepository<ScaeApiContext, Domain.Entities.Empreendimento.Empreendimento>, IEmpreendimentoRepository
    {
        private readonly IPlanoPagamentoRepository _planoPagamentoRepository;
        public EmpreendimentoRepository(ScaeApiContext context, IPlanoPagamentoRepository planoPagamentoRepository) : base(context)
        {
            _planoPagamentoRepository = planoPagamentoRepository;
        }

        private IQueryable<Unidade> SetIncludeUnidade(IQueryable<Unidade> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        private IQueryable<Grupo> SetIncludeGrupo(IQueryable<Grupo> query, string include)
        {
            if (string.IsNullOrEmpty(include))
                return query;

            var includes = include.Split(",");

            foreach (var item in includes)
                query = query.Include(item.Trim());

            return query;
        }

        public async Task<List<UnidadeFoto>> GetUnidadeFotos(int unidadeId)
        {
            return await _context.Set<UnidadeFoto>().AsNoTracking()
                .Where(x => x.UnidadeId == unidadeId).ToListAsync();
        }

        public async Task<Unidade> GetUnidadeTraking(int unidadeId, string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);

            return await query.SingleOrDefaultAsync(x => x.Id == unidadeId);
        }

        public IQueryable<Unidade> GetUnidadesAllTracking(string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);
            return query;
        }

        public async Task<Unidade> GetUnidadeByKmlId(string unidadeKmlId, string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);

            return await query.SingleOrDefaultAsync(x => x.KmlId == unidadeKmlId);
        }

        public async Task<bool> UnidadeKmlIdDuplicado(string unidadeKmlId)
        {
            return await _context.Unidades.AnyAsync(x => x.KmlId == unidadeKmlId);
        }

        public async Task<Unidade> GetUnidade(int unidadeId, string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);

            return await query.AsNoTracking().SingleOrDefaultAsync(x => x.Id == unidadeId);
        }

        public IQueryable<Unidade> GetUnidade(string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);

            return query.AsNoTracking();
        }
        public IQueryable<Unidade> GetUnidadeTracking(string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>(), include);

            return query;
        }

        public IQueryable<Unidade> GetUnidadeByIdsTracking(List<int> ids, string include = "")
        {
            var query = SetIncludeUnidade(_context.Set<Unidade>().Where(unidade => ids.Any(x => x == unidade.Id)), include);

            return query;
        }

        public async Task<RelatorioCompletoUnidade> UnidadeRelatorio(int? unidadeId, int[] empreendimentoId, int[] empresaId, int[] situacaoId, int? grupoId, int? contratoId, int? clienteId)
        {
            var relatorio = new RelatorioCompletoUnidade();
            var query = _context.Unidades.AsNoTracking();

            if (unidadeId.HasValue)
                query = query.Where(x => x.Id == unidadeId.Value);

            if (empreendimentoId.Any())
                query = query.Where(x => empreendimentoId.Any(id => id == x.Grupo.EmpreendimentoId));

            if (empresaId.Any())
                query = query.Where(x => empresaId.Any(id => id == x.Grupo.Empreendimento.EmpresaId));

            if (situacaoId.Any())
                query = query.Where(x => situacaoId.Any(id => id == x.SituacaoId));


            if (grupoId.HasValue)
                query = query.Where(x => x.GrupoId == grupoId.Value);



            var unidades = await query.
                        Select(x => new UnidadeModel
                        {
                            Id = x.Id,
                            Nome = x.Nome,
                            Situacao = x.Situacao.Nome,
                            SituacaoId = x.SituacaoId,
                            GrupoNome = x.Grupo.Nome,
                            Empreendimento = new EmpreendimentoModel { Id = x.Grupo.EmpreendimentoId, EmpreendimentoNome = x.Grupo.Empreendimento.Nome },
                            valor = x.ValorVenda,

                            //EmpreendimentoNome = x.Grupo.Empreendimento.Nome
                        }).ToListAsync();

            var contratos = await _context.Contratos.AsNoTracking()
                .Where(x => x.SituacaoId == SituacaoContrato.EmAndamento.Id || x.SituacaoId == SituacaoContrato.Cobranca.Id || x.SituacaoId == SituacaoContrato.Juridico.Id || x.SituacaoId == SituacaoContrato.Prejuizo.Id || x.SituacaoId == SituacaoContrato.Quitado.Id || x.SituacaoId == SituacaoContrato.ComProcesso.Id || x.SituacaoId == SituacaoContrato.PendenteAprovacao.Id)
                .Select(x => new ContratoModel
                {
                    Id = x.Id,
                    UnidadeId = x.UnidadePrincipalId,
                    UnidadesAdicionais = x.UnidadesAdicionais,
                    Numero = x.Numero,
                    Clientes = x.Clientes.Select(x => x.Cliente).Select(y => new ContratoClienteModel { Id = y.Id, Nome = y.NomeCnpjCpf }).ToList()
                }).ToListAsync();


            foreach (var unidade in unidades)
            {
                var contrato = contratos.FirstOrDefault(x => x.UnidadeId == unidade.Id || x.UnidadesAdicionais.Any(y => y.UnidadeId == unidade.Id));
                relatorio.ListaUnidades.Add(new UnidadeRelatorioModel()
                {
                    Contrato = contrato,
                    Unidade = unidade
                });
            }

            var situacaoMap = new Dictionary<int, Action<TotalSituacaoUnidade>>
{
                { SituacaoUnidade.Vendido.Id, t => t.TotalUnidadeVendida++ },
                { SituacaoUnidade.Disponivel.Id, t => t.TotalUnidadeDisponivel++ },
                { SituacaoUnidade.Indisponivel.Id, t => t.TotalUnidadeIndisponivel++ },
                { SituacaoUnidade.Reservado.Id, t => t.TotalUnidadeReservada++ },
                { SituacaoUnidade.Invadido.Id, t => t.TotalUnidadeInvadido++ },
                { SituacaoUnidade.Penhorado.Id, t => t.TotalUnidadePenhorado++ },
                { SituacaoUnidade.Caucionado.Id, t => t.TotalUnidadeCaucionado++ }
            };

            foreach (var item in relatorio.ListaUnidades)
            {
                if (situacaoMap.TryGetValue(item.Unidade.SituacaoId, out var incrementAction))
                {
                    incrementAction(relatorio.TotaisSitucaoUnidades);
                }
            }

            //foreach (var item in relatorio)
            //{
            //    item.TotaisSitucaoUnidades.TotalUnidadeVendida += item.Unidade.SituacaoId == SituacaoUnidade.Vendido.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadeDisponivel += item.Unidade.SituacaoId == SituacaoUnidade.Disponivel.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadeIndisponivel += item.Unidade.SituacaoId == SituacaoUnidade.Indisponivel.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadeReservada += item.Unidade.SituacaoId == SituacaoUnidade.Reservado.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadeInvadido += item.Unidade.SituacaoId == SituacaoUnidade.Invadido.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadePenhorado += item.Unidade.SituacaoId == SituacaoUnidade.Penhorado.Id ? 1 : 0;
            //    item.TotaisSitucaoUnidades.TotalUnidadeCaucionado += item.Unidade.SituacaoId == SituacaoUnidade.Caucionado.Id ? 1 : 0;
            //}
            //var relatorio = unidades.GroupJoin(contratos, u => u.Id, c => c.UnidadeId, (u, c) => new { Unidade = u, Contrato = c }).SelectMany(x => x.Contrato.DefaultIfEmpty(), (u, c) => new UnidadeRelatorioModel { Unidade = u.Unidade, Contrato = c });

            if (contratoId.HasValue)
                relatorio.ListaUnidades = relatorio.ListaUnidades.Where(x => x.Contrato?.Id == contratoId.Value).ToList();

            if (clienteId.HasValue)
                relatorio.ListaUnidades = relatorio.ListaUnidades.Where(x => x.Contrato?.Clientes.Any(x => x.Id == clienteId) == true).ToList();

            relatorio.ListaUnidades = relatorio.ListaUnidades.OrderBy(x => TreeViewHelper.PadNumbers(x.Unidade.Empreendimento.EmpreendimentoNome)).ThenBy(x => TreeViewHelper.PadNumbers(x.Unidade.GrupoNome)).ThenBy(x => TreeViewHelper.PadNumbers(x.Unidade.Nome)).ToList(); //.ThenBy(x => x.Unidade.Id);

            return relatorio;

        }

        public async Task<List<SCAE.Domain.Entities.Empreendimento.Empreendimento>> GetAllByEmpresa(int empresaId)
        {
            return await GetAll().Where(x => x.EmpresaId == empresaId).ToListAsync();
        }

        public IQueryable<Grupo> GetGruposByEmpreendimento(int id)
        {
            return _context.Set<Grupo>().Where(x => x.EmpreendimentoId == id);
        }
        public IQueryable<Unidade> GetUnidadesByGrupo(int grupoId)
        {
            return _context.Set<Unidade>().Where(x => x.GrupoId == grupoId);
        }

        public async Task RemoveGrupo(int grupoId)
        {
            var entity = await GetGrupoByIdAsync(grupoId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task RemoveUnidade(int unidadeId)
        {
            var entity = await GetUnidade(unidadeId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task RemovePlanoPagamentoUnidade(int id)
        {
            var entity = await _context.Set<PlanoPagamentoUnidade>().FirstOrDefaultAsync(x => x.UnidadeId == id);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<PlanoPagamentoUnidade> GetPlanoPagamentoUnidade(int unidadeId)
        {
            var entity = await _context.Set<PlanoPagamentoUnidade>().AsNoTracking().FirstOrDefaultAsync(x => x.UnidadeId == unidadeId);

            //if (entity == null)
            //    throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            return entity;
        }
        public async Task RegistrarPlanoPagamentoUnidadeNoGerar(int unidadeId, int ModeloPlanoPagamentoId)
        {
            var planoUnidade = await GetPlanoPagamentoUnidade(unidadeId);
            var planoDePagamento = await _planoPagamentoRepository.GetByIdAsync(ModeloPlanoPagamentoId);
            var unidade = await GetUnidadesAllTracking().FirstOrDefaultAsync(x => x.Id == unidadeId);

            if (planoUnidade == null && unidade != null)
            {
                unidade.ModeloPlanoPagamentoId = ModeloPlanoPagamentoId;
                unidade.PlanoPagamento = new PlanoPagamentoUnidade(planoDePagamento, unidadeId);
                await SaveChangesAsync();
            }
        }
        public async Task RemoveLadoAdicionalUnidade(int ladoAdicionalId)
        {
            var entity = await _context.LadosAdicionais.FindAsync(ladoAdicionalId);

            if (entity == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            _context.Remove(entity);
        }

        public async Task<Grupo> GetGrupoByIdTrackingAsync(int grupoId, string include = "")
        {
            return await GetGrupoAll(include).Where(x => x.Id.Equals(grupoId)).SingleOrDefaultAsync();
        }
        public async Task<Grupo> GetGrupoByIdAsync(int grupoId, string include = "")
        {
            return await GetGrupoAll(include).AsNoTracking().Where(x => x.Id.Equals(grupoId)).SingleOrDefaultAsync();
        }

        public IQueryable<Grupo> GetGrupoAll(string include = "")
        {
            var query = _context.Set<Grupo>();

            if (string.IsNullOrEmpty(include))
                return query;

            return SetIncludeGrupo(query, include);
        }

        public void UpdateGrupo(Grupo grupo)
        {
            _context.Update(grupo);
        }

        public void UpdateUnidade(Unidade unidade)
        {
            _context.Update(unidade);
        }

        public void UpdateUnidadeList(List<Unidade> list)
        {
            _context.UpdateRange(list);
        }

        public async Task InsertGrupo(Grupo grupo)
        {
            await _context.AddAsync(grupo);
        }
         
        public IQueryable<IptuRelatorioModel> IptuRelatorio(int? empreendimentoId, int? grupoId, int? unidadeId, int? clienteId, int[] empresaId)
        {
            var _contratoQuery = _context
                                     .Set<Contrato>()
                                     .Include("UnidadePrincipal.Grupo")
                                     .Include("UnidadePrincipal.Lote")
                                     .Include("Clientes.Cliente.Endereco.Municipio")
                                     .Include("Empreendimento")
                                     .Include("Clientes.Cliente.Endereco.Estado")
                                     .Include("UnidadePrincipal.Legalizacao")
                                     .Include("Empresa")
                                     .AsNoTracking();

            if (empreendimentoId.HasValue)
                _contratoQuery = _contratoQuery.Where(x => x.EmpreendimentoId == empreendimentoId || x.UnidadesAdicionais.Any(u => u.Unidade.Grupo.EmpreendimentoId == empreendimentoId));

            if (grupoId.HasValue)
                _contratoQuery = _contratoQuery.Where(x => x.UnidadePrincipal.GrupoId == grupoId.Value);

            if (unidadeId.HasValue)
                _contratoQuery = _contratoQuery.Where(x => x.UnidadePrincipalId == unidadeId.Value);

              if (empresaId.Any())
                _contratoQuery = _contratoQuery.Where(x => empresaId.Any(id => id == x.EmpresaId));

            //   if (empresaId.HasValue)
            //   _contratoQuery = _contratoQuery.Where(x => x.EmpresaId == empresaId.Value);

            var _relatorioQuery = from contrato in _contratoQuery
                                  from cliente in contrato.Clientes
                                  where clienteId.HasValue ? clienteId.Value == cliente.ClienteId : true
                                  select new IptuRelatorioModel
                                  {
                                      ClienteNomeCPF = cliente.Cliente.NomeCnpjCpf,
                                      EmpreendimentoNome = contrato.Empreendimento.Nome,
                                      EmpresaNome = contrato.Empresa.Nome,
                                      GrupoNome = contrato.UnidadePrincipal.Grupo.Nome,
                                      UnidadeNome = contrato.UnidadePrincipal.Nome,
                                      UnidadeAreaTotal = contrato.UnidadePrincipal.Lote != null && contrato.UnidadePrincipal.Lote.Dimensao != null ? contrato.UnidadePrincipal.Lote.Dimensao.Frente * contrato.UnidadePrincipal.Lote.Dimensao.LadoEsquerdo : 0,
                                      ClienteLogradouro = cliente.Cliente.Endereco.Logradouro,
                                      ClienteCidade = cliente.Cliente.Endereco.Municipio.Nome,
                                      ClienteUf = cliente.Cliente.Endereco.Estado.Uf,
                                      ClienteBairro = cliente.Cliente.Endereco.Bairro,
                                      ClienteCep = cliente.Cliente.Endereco.Cep,
                                      UnidadeMatricula = contrato.UnidadePrincipal.Legalizacao != null ? contrato.UnidadePrincipal.Legalizacao.Matricula : ""
                                  };

            return _relatorioQuery;
        }

        public IQueryable<EmpreendimentoProprietario> GetProprietarioAll(int[] empreendimentoId, int[] empresaId)
        {
            var query = _context.Set<EmpreendimentoProprietario>().Include("Proprietario,Empreendimento").AsNoTracking();

            if (empreendimentoId.Any())
                query = query.Where(x => empreendimentoId.Any(id => id == x.EmpreendimentoId));

            if (empresaId.Any())
                query = query.Where(x => empresaId.Any(id => id == x.Empreendimento.EmpresaId));


            return query;
        }

        public IQueryable<Unidade> GetUnidadeRelatorioVgv(int[] empresasIds, int[] empreendimentosIds)
        {
            var query = _context.Set<Unidade>()
                            .Where(x => x.SituacaoId == SituacaoUnidade.Disponivel.Id).AsNoTracking();

            if (empresasIds.Any())
                query = query.Where(x => empresasIds.Any(id => id == x.Grupo.Empreendimento.EmpresaId));

            if (empreendimentosIds.Any())
                query = query.Where(x => empreendimentosIds.Any(id => id == x.Grupo.EmpreendimentoId));

            return query;
        }

        public bool IsUnidadesDisponiveis(List<int> UnidadesASeremVerificadasIds)
        {
            return !GetUnidadeByIdsTracking(UnidadesASeremVerificadasIds).AsNoTracking().Any(x => x.SituacaoId == SituacaoUnidade.Vendido.Id);
        }

        public async Task InsertList(List<Domain.Entities.Empreendimento.Empreendimento> list)
        {
            await _context.AddRangeAsync(list);
        }

        public void RemoveList(List<Domain.Entities.Empreendimento.Empreendimento> list)
        {
            _context.RemoveRange(list);
        }

        public void UpdateList(List<Domain.Entities.Empreendimento.Empreendimento> list)
        {
            _context.UpdateRange(list);
        }
         
        public IQueryable<Domain.Entities.Empreendimento.Empreendimento> GetConfrontanteRelatorio2(int[] empreendimentoId, int[] empresaId, int? grupoId, int? unidadeId)
        {

           IQueryable<Domain.Entities.Empreendimento.Empreendimento> query;
             query = _context.Set<Domain.Entities.Empreendimento.Empreendimento>().AsNoTracking()
                .Include(x => x.Empresa)
                .Include(x => x.Grupos)
                    .ThenInclude(x => x.Unidades) 
                        .ThenInclude(x => x.Lote)
                .Include(x => x.Grupos)
                    .ThenInclude(x => x.Unidades) 
                        .ThenInclude(x => x.Imovel);




            //    if (empreendimentoId.Any())
            //     query = query.Where(x => empreendimentoId.Any(id => id == x.Id));

            //  if (grupoId.HasValue)
            //    query = query.Where(x => x.Grupos.Any(g => g.Id == grupoId.Value));

          //  if (grupoId.HasValue)
           //     query = query.Where(x => x.Grupos.Any(g => g.Id == grupoId.Value)); 
            
           // if (unidadeId.HasValue)
            //    query = query.Where(x => x.Grupos.Any(grupo => grupo.Unidades.Any(unidade => unidade.Id == unidadeId.Value)));


           // if (empresaId.Any())
              //  query = query.Where(x => empresaId.Any(id => id == x.EmpresaId));
//
         
            return query;

        }

        public IQueryable<Domain.Entities.Empreendimento.Empreendimento> GetConfrontanteRelatorio(int[] empreendimentoId, int[] empresaId, int? grupoId, int? unidadeId)
        {

            IQueryable<Domain.Entities.Empreendimento.Empreendimento> query;
            query = _context.Set<Domain.Entities.Empreendimento.Empreendimento>().AsNoTracking()
               .Include(x => x.Empresa)
               .Include(x => x.Grupos)
                   .ThenInclude(x => x.Unidades)
                       .ThenInclude(x => x.Lote)
               .Include(x => x.Grupos)
                   .ThenInclude(x => x.Unidades)
                       .ThenInclude(x => x.Imovel);




            if (empreendimentoId.Any())
                    query = query.Where(x => empreendimentoId.Any(id => id == x.Id));


            if (grupoId.HasValue)
                 query = query.Where(x => x.Grupos.Any(g => g.Id == grupoId.Value));

            //  if (grupoId.HasValue)
            //     query = query.Where(x => x.Grupos.Any(g => g.Id == grupoId.Value)); 

            // if (unidadeId.HasValue)
            //    query = query.Where(x => x.Grupos.Any(grupo => grupo.Unidades.Any(unidade => unidade.Id == unidadeId.Value)));


            // if (empresaId.Any())
            //  query = query.Where(x => empresaId.Any(id => id == x.EmpresaId));
            //

            return query;

        }


        public IQueryable<LadoAdicional> GetLadosAdicionaisByEmpreendimentoId(int empreendimentoId)
        {
            return _context.Set<LadoAdicional>()
                           .Include(x => x.Lote)
                               .ThenInclude(x => x.Unidade)
                                   .ThenInclude(x => x.Grupo)
                           .Where(x => x.EmpreendimentoId == empreendimentoId || x.Lote.Unidade.Grupo.EmpreendimentoId == empreendimentoId);
        }

        public void RemoverLadosAdicionais(List<LadoAdicional> ladosAdiciais)
        {
            _context.RemoveRange(ladosAdiciais);
        }

        public IQueryable<Unidade> GetUnidadePainelVendas(int[] empreendimentosIds, int[] empresasIds, DateTime? dataInicial, DateTime? dataFinal)
        {
            var query = _context.Set<Unidade>().AsNoTracking();

            if (empresasIds.Any())
                query = query.Where(x => empresasIds.Any(id => id == x.Grupo.Empreendimento.EmpresaId));

            if (empreendimentosIds.Any())
                query = query.Where(x => empreendimentosIds.Any(id => id == x.Grupo.EmpreendimentoId));


            return query;
        }
    }
}
