using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Clientes.ContratoDigital;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Data.Interface.Clientes
{
    public interface IContratoRepository : ICrudRepository<Contrato>
    {
        IQueryable<Contrato> GetContratoByCliente(int clienteId);
        int ProximoNumero();
        int ProximaSequencia(int numero);
        List<Contrato> GetAllTracking();
        Task UpdateContratoDigital(ContratoDigital contratoDigital);
        Task<ContratoDigital> GetContratoDigitalByIdAsync(int contratoDigitalId, string include = "");
        Task<ContratoDigital> GetContratoDigitalByIdTrackingAsync(int contratoDigitalId, string include = "");
        IQueryable<ContratoDigital> GetContratoDigitalAll(string include = "");
        IQueryable<SignatarioContratoDigital> GetSignatariosAll();
        Task RemoveSignatario(int id);
        Task<ContratoDigital> GetContratoDigitalByDFourSignId(string dFourSignDocumentId, string include = "");
        Task RemoveContratoDigital(int id);
        IQueryable<ContratoDigital> GetRelatorioContratoDigital(int[] empresasIds, DateTime? dataEmissaoInicial, DateTime? dataEmissaoFinal, DateTime? dataEnvioAssinaturaInicial, DateTime? dataEnvioAssinaturaFinal, DateTime? dataAssinaturaInicial, DateTime? dataAssinaturaFinal);
        Task RemoveContratoUnidadeAdicional(int contratoUnidadeAdicionalId);
        Task<ContratoUnidadeAdicional> GetContratoUnidadeAdicional(int contratoUnidadeAdicionalId, string include = "");
        Task InsertList(List<Contrato> list);
        void UpdateList(List<Contrato> list);
        IQueryable<Contrato> RelatorioGeralVendas(int[] empreendimentoIds, int[] empresaIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal, int? numeroContrato, int? idCliente, int? situacaoContrato, DateTime? dataSituacaoInicial, DateTime? dataSituacaoFinal);

        IQueryable<Contrato> RelatorioGerencialCarteira(int[] empreendimentoIds, int[] empresaIds, DateTime? dataContratoInicial, DateTime? dataContratoFinal, int? numeroContrato, int? idCliente, int? situacaoContrato, int? grupoId, int? unidadePrincipalId);
        IQueryable<Contrato> AditadosRelatorioReceita(int[] empreendimentoIds, int[] empresaIds, DateTime? dataInicial, DateTime? dataFinal);
        Task InsertContratoDigital(ContratoDigital model);
    }
}
