using SCAE.Data.Context;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Interface.Financeiro.PlanoDePagamento;
using SCAE.Data.Repository.Shared;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Data.Repository.Financeiro.PlanoDePagamento
{
    public class TipoPlanoPagamentoRepository : QueryRepository<ScaeApiContext, TipoPlanoPagamento>, ITipoPlanoPagamentoRepository
    {
        public TipoPlanoPagamentoRepository(ScaeApiContext context) : base(context)
        {

        }
    }
}
