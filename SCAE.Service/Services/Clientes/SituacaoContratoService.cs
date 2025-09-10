using SCAE.Data.Interface.Clientes;
using SCAE.Domain.Entities.Clientes;
using SCAE.Service.Interfaces.Clientes;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Clientes
{
    public class SituacaoContratoService : QueryService<SituacaoContrato, ISituacaoContratoRepository>, ISituacaoContratoService
    {
        public SituacaoContratoService(ISituacaoContratoRepository repository) : base(repository)
        {
        }
    }
}
