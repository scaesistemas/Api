using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro
{
    public class ContaGerencialService : CrudService<ContaGerencial, IContaGerencialRepository>, IContaGerencialService
    {
        public ContaGerencialService(IContaGerencialRepository repository) : base(repository)
        {
        }
    }
}
