using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Base
{
    public class TipoTermoEmpresaRepository : QueryRepository<ScaeBaseContext, TipoTermoEmpresa>, ITipoTermoEmpresaRepository
    {
        public TipoTermoEmpresaRepository(ScaeBaseContext context) : base(context)
        {
        }
    }
}
