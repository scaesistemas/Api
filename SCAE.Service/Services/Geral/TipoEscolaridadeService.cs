using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Geral;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    public class TipoEscolaridadeService : QueryService<TipoEscolaridade, ITipoEscolaridadeRepository>, ITipoEscolaridadeService
    {
        public TipoEscolaridadeService(ITipoEscolaridadeRepository repository) : base(repository)
        {

        }
    }
}
