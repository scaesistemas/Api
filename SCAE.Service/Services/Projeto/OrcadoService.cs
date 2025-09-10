using SCAE.Data.Interface.Almoxarifado;
using SCAE.Data.Interface.Projeto;
using SCAE.Domain.Entities.Projeto;
using SCAE.Domain.Models.Projeto;
using SCAE.Service.Interfaces.Projeto;
using SCAE.Service.Services.Shared;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SCAE.Framework.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using SCAE.Framework.Helper;

namespace SCAE.Service.Services.Projeto
{
    public class OrcadoService : CrudService<Orcado, IOrcadoRepository>, IOrcadoService
    {
        public OrcadoService(IOrcadoRepository repository) : base(repository)
        {
        }
    }
}

    
