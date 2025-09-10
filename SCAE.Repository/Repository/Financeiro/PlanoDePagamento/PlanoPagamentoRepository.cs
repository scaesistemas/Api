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
    public class PlanoPagamentoRepository : CrudRepository<ScaeApiContext, PlanoPagamentoModelo>, IPlanoPagamentoRepository
    {
        public PlanoPagamentoRepository(ScaeApiContext context) : base(context)
        {
        }
    }
}
