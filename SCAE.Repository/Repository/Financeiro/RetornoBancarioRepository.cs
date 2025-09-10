using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro
{
    public class RetornoBancarioRepository : CrudRepository<ScaeApiContext, RetornoBancario>, IRetornoBancarioRepository
    {
        public RetornoBancarioRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
