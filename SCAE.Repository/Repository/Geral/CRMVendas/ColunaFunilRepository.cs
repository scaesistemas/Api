using SCAE.Data.Context;
using SCAE.Data.Interface.Geral.CRMVendas;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Geral.CRMVendas;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using System.Collections.Generic;
using SCAE.Data.Interface.Geral;

namespace SCAE.Data.Repository.Geral.CRMVendas
{
    public class ColunaFunilRepository : CrudRepository<ScaeApiContext, ColunaFunil>, IColunaFunilRepository
    {
        public ColunaFunilRepository(ScaeApiContext context) : base(context)
        {

        }

    }
}
