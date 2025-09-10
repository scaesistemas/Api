using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Domain.Models.Empreendimento;
using SCAE.Domain.Models.Empreendimento.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Empreendimento
{
    public interface IEmpreendimentoRepository : ICrudRepository<Domain.Entities.Empreendimento.Empreendimento>
    {
        Task<List<UnidadeFoto>> GetUnidadeFotos(int unidadeId);
        Task<Unidade> GetUnidadeTraking(int unidadeId, string include = "");
        IQueryable<Unidade> GetUnidadeTracking(string include = "");
        IQueryable<Unidade> GetUnidadesAllTracking(string include = "");
        Task<Unidade> GetUnidade(int unidadeId, string include = "");
        IQueryable<Unidade> GetUnidade(string include = "");
        Task<RelatorioCompletoUnidade> UnidadeRelatorio(int? unidadeId, int[] empreendimentoId, int[] empresaId, int[] situacaoId, int? grupoId, int? contratoId, int? clienteId);
        Task<List<SCAE.Domain.Entities.Empreendimento.Empreendimento>> GetAllByEmpresa(int empresaId);
        IQueryable<Grupo> GetGruposByEmpreendimento(int id);
        IQueryable<Unidade> GetUnidadesByGrupo(int grupoId);
        Task RemoveGrupo(int grupoId);
        Task RemoveUnidade(int unidadeId);
        Task RemovePlanoPagamentoUnidade(int id);
        Task RegistrarPlanoPagamentoUnidadeNoGerar(int unidadeId, int ModeloPlanoPagamentoId);
        Task<Grupo> GetGrupoByIdTrackingAsync(int grupoId, string include = "");
        Task<Grupo> GetGrupoByIdAsync(int grupoId, string include = "");
        Task<PlanoPagamentoUnidade> GetPlanoPagamentoUnidade(int unidadeId);
        IQueryable<Grupo> GetGrupoAll(string include = "");
        void UpdateGrupo(Grupo grupo);
        void UpdateUnidade(Unidade unidade);
        void UpdateUnidadeList(List<Unidade> list);
        Task InsertGrupo(Grupo grupo); 
        IQueryable<IptuRelatorioModel> IptuRelatorio(int? empreendimentoId, int? grupoId, int? unidadeId, int? clienteId, int[] empresaId);
        Task RemoveLadoAdicionalUnidade(int ladoAdicionalId);
        Task<Unidade> GetUnidadeByKmlId(string unidadeKmlId, string include = "");
        Task<bool> UnidadeKmlIdDuplicado(string unidadeKmlId);
        IQueryable<EmpreendimentoProprietario> GetProprietarioAll(int[] empreendimentoId, int[] empresaId);
        IQueryable<Unidade> GetUnidadeRelatorioVgv(int[] empresasIds, int[] empreendimentosIds);
        IQueryable<Unidade> GetUnidadeByIdsTracking(List<int> ids, string include = "");
        bool IsUnidadesDisponiveis(List<int> ids);
        Task InsertList(List<Domain.Entities.Empreendimento.Empreendimento> list);
        void RemoveList(List<Domain.Entities.Empreendimento.Empreendimento> list);
        void UpdateList(List<Domain.Entities.Empreendimento.Empreendimento> list);
        IQueryable<Domain.Entities.Empreendimento.Empreendimento> GetConfrontanteRelatorio(int[] empreendimentoId, int[] empresaId, int? grupoId, int? unidadeId);
        IQueryable<LadoAdicional> GetLadosAdicionaisByEmpreendimentoId(int empreendimentoId);
        void RemoverLadosAdicionais(List<LadoAdicional> LadosAdiciais);
         
    }
}
