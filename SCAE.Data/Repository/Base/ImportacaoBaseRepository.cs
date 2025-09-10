using SCAE.Data.Context;
using SCAE.Repository.Interface.Base;
using SCAE.Repository.Repository.Shared;
using SCAE.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Repository.Repository.Base
{
    public class ImportacaoBaseRepository : CrudRepository<ScaeBaseContext, IndiceBase>, IImportacaoBaseRepository
    {
        public ImportacaoBaseRepository(ScaeBaseContext context) : base(context)
        {
        }
    }
}
