using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Projeto;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Projeto
{
    public class MedicaoService : CrudService<Medicao, IMedicaoRepository>, IMedicaoService
    {
               public MedicaoService(IMedicaoRepository repository) : base(repository)
        {
         }

    }
}
