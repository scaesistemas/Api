using System.Collections.Generic;
using System.Threading.Tasks;
using SCAE.Data.Interface.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;

namespace SCAE.Data.Interface.Geral.CRMVendas
{
    public interface ILeadRepository : ICrudRepository<Lead>
    {
        int ProximaPosicao(int colunaFunilId = -1);
        Task<List<LeadDocumento>> GetDocumentos(int leadId);
        Task<LeadDocumento> GetDocumentoByIdAsync(int id);
        Task InsertList(List<Lead> list);
        Task<Lead> GetByCPF(string cpf,string include="");
    }
}
