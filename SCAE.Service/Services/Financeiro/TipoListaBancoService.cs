using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Repository.Interface.Financeiro;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class TipoListaBancoService : QueryService<TipoListaBanco, ITipoListaBancoRepository>, ITipoListaBancoService
    {
        public TipoListaBancoService(ITipoListaBancoRepository repository) : base(repository)
        {
        }

    }
}