using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Boleto;
using SCAE.Service.Interfaces.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IRemessaService : ICrudService<Remessa>
    {
        Task<ArquivoRemessaDocumento> SalvarEProcessar(Remessa entity, EnumTipoArquivo enumTipoArquivo);
        Task<ArquivoRemessaDocumento> Processar(int remessaId, EnumTipoArquivo enumTipoArquivo);
    }
}
