using SCAE.Data.Interface.Almoxarifado;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.OrcamentoObras;
using SCAE.Domain.Models.Almoxarifado;
using SCAE.Service.Interfaces.Almoxarifado;
using SCAE.Service.Services.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Almoxarifado
{
    public class MovimentacaoService : CrudService<Movimentacao, IMovimentacaoRepository>, IMovimentacaoService
    {
        public MovimentacaoService(IMovimentacaoRepository repository) : base(repository)
        {
        }
    }
}
