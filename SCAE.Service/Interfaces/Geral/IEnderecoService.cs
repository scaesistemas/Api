using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.Geral
{
    public interface IEnderecoService
    {
        IQueryable<Estado> ObterEstados();
        Task<Estado> ObterEstado(int id);
        IQueryable<Municipio> ObterMunicipios(int estadoId);
        Task<Municipio> ObterMunicipio(int id);
        Task<EnderecoModel> ObterPorCep(string cep);
    }
}
