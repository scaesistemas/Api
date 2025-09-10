using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SCAE.Domain.Entities.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CheckPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private Permissoes[] _permission;
      //  private readonly Type _typeTeste;
        public CheckPermissionAttribute( params Permissoes[] permission)
        {
            _permission = permission;
           // _typeTeste = type;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
                return;

            if (context.Filters.Any(item => item is IAllowAnonymousFilter))
                return;
            
            var usuarioPermissoes = JsonConvert.DeserializeObject<Permissoes[]>(user.FindFirst("permissoes").Value);

             if (usuarioPermissoes.Any(x => x == Permissoes.Master))
             return;


             var success = _permission.ToList().Any(usuarioPermissoes.Contains);
            if (!success)
            {

                context.Result = new JsonResult(new
                {
                    Message = "Você não tem acesso a este recurso!"
                })
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };

                return;
            }

            return;
        }
    }
}
