using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using SCAE.Service.Interfaces.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IParametroService : ICrudService<Parametro>
    {
        Task<Parametro> GetFirst(int empresaId);
        Task EnviarSms(int cobrancaId, bool enviarSms);
        Task DefinirGatewayPrincipal(int gatewayId);
        IQueryable<Parametro> GetAllByEmpresaId(int empresaId);
        Task<ParametroGatway> GetGatewayByIdNoInclude(int gatewayId);
        Task CriarSubConta(int id, int tipoGatewayId, SubContaModel subcontaModel);
        Task<SubcontaConsultaModel> ConsultarSubconta(int id, int tipoGatewayId);
        Task EnviarDocumentoSubconta(int id, int tipoGatewayId, SubcontaDocumentoScaeModel documentos);
    }
}
