using DocumentFormat.OpenXml.Office2010.ExcelAc;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.OrcamentoObras
{
    public interface IOrcamentoEtapaService : ICrudService<OrcamentoEtapa>
    {
        Task<List<OrcamentoEtapa>> TreeView(int orcamentoId);
    }
}
