using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro.PlanoDePagamento
{
    public class TipoIntervaloParcelaRepository : QueryRepository<ScaeApiContext,TipoIntervaloParcela>, ITipoIntervaloParcelaRepository
    {
        public TipoIntervaloParcelaRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
