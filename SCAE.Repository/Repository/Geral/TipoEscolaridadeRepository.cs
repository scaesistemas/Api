using SCAE.Data.Context;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Geral
{
    public class TipoEscolaridadeRepository : QueryRepository<ScaeApiContext, TipoEscolaridade>, ITipoEscolaridadeRepository
    {
        public TipoEscolaridadeRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
