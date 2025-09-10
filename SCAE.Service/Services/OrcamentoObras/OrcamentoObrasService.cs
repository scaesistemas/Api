using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.JsonPatch;
using SCAE.Data.Interface.OrcamentoObras;
using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Service.Interfaces.OrcamentoObras;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;

namespace SCAE.Service.Services.OrcamentoObras
{
    public class OrcamentoObrasService : CrudService<Domain.Entities.OrcamentoObras.OrcamentoObras, IOrcamentoObrasRepository>, IOrcamentoObrasService
    {
        IOrcamentoEtapaService _etapaService;
        IOrcamentoEtapaRepository _etapaRepository;
        public OrcamentoObrasService(IOrcamentoObrasRepository repository, IOrcamentoEtapaRepository etapaRepository, IOrcamentoEtapaService etapaService) : base(repository)
        {
            _etapaService = etapaService;
            _etapaRepository = etapaRepository;
        }

        public async override Task Post(Domain.Entities.OrcamentoObras.OrcamentoObras entity)
        {
            await base.Post(entity);
        }

        public async override Task Patch(int id, JsonPatchDocument<Domain.Entities.OrcamentoObras.OrcamentoObras> model, string include)
        {
            await base.Patch(id, model, include);
        }

        //public override async Task<Domain.Entities.OrcamentoObras.OrcamentoObras> Get(int id, string include)
        //{
        //    var orcamento = base.Get(id, include);
        //    orcamento.Result.Etapas = await _etapaService.TreeView(id);
        //    return orcamento.Result;
        //}
    }
}
