using Microsoft.EntityFrameworkCore;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Finance.Implementations;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Services.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class InsumoService : CrudService<Insumo, IInsumoRepository>, IInsumoService
    {
        public InsumoService(IInsumoRepository repository) : base(repository)
        {
        }
    }
}
