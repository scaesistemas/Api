using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCAE.Domain.Models.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Service.Interfaces.Financeiro
{
    public interface IReguaCobrancaService : ICrudService<ReguaCobranca>
    {
        Task<ReguaCobrancaModel> GetReguaCobranca(int id, int page, int pageSize);
        Task<ReguaCobrancaModel> GetReguaCobrancaById(int id);
        Task DeleteEtapa(int EtapaId);
    }
}
