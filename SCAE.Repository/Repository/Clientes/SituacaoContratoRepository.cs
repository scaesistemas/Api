using SCAE.Data.Context;
using SCAE.Data.Interface.Clientes;
using SCAE.Data.Interface.Shared;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Clientes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Clientes
{
    public class SituacaoContratoRepository : QueryRepository<ScaeApiContext, SituacaoContrato>, ISituacaoContratoRepository
    {
        public SituacaoContratoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
