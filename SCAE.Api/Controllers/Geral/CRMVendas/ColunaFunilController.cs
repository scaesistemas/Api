using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using SCAE.Domain.Entities.Geral.CRMVendas;
using SCAE.Service.Interfaces.Geral.CRMVendas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SCAE.Domain.Models.Geral.CRMVendas;
using SCAE.Framework.Exceptions;
using System.Threading.Tasks;
using System;
using System.Security.Claims;
using SCAE.Framework.Helper;

namespace SCAE.Api.Controllers.Geral.CRMVendas
{
    [AllowAnonymous]
    public class ColunaFunilController : MasterCrudController<ColunaFunil>
    {
        public readonly IColunaFunilService _service;
        public ColunaFunilController(ILogger<ColunaFunilController> logger, IColunaFunilService service) : base(logger, service) 
        {
            _service = service;
        }

    }

}
