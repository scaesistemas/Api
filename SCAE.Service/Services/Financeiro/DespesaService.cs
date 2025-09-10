using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SCAE.Data.Interface.Financeiro;
using SCAE.Data.Repository.Financeiro;
using SCAE.Domain;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Entities.Compras;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Models.Clientes;
using SCAE.Domain.Models.Financeiro;
using SCAE.Domain.Models.Shared;
using SCAE.Domain.Models.Zoop;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Shared;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro
{
    public class DespesaService : CrudService<Despesa, IDespesaRepository>, IDespesaService
    {        public DespesaService(IDespesaRepository repository) : base(repository)
        {
        }
    }
}

