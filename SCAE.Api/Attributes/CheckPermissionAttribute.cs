using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SCAE.Domain.Entities.Geral;
using System;
using System.Linq;

namespace SCAE.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CheckPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private Permissoes[] _permission;
        public CheckPermissionAttribute(params Permissoes[] permission)  
        {
            _permission = permission;

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            bool success;

            if (!user.Identity.IsAuthenticated)
                return;

            //if (context.Filters.Any(item => item is IAllowAnonymousFilter))
            //    return;
            
            var usuarioPermissoes = JsonConvert.DeserializeObject<Permissoes[]>(user.FindFirst("permissoes").Value);
            int[] array = { 8000, 000, 555, 666 };

            if (usuarioPermissoes == null)
                success = false;
            
            else
            {
                if (usuarioPermissoes.Any(x => x == Permissoes.Master || x == Permissoes.Administrador))
                    return;


                success = _permission.ToList().Any(usuarioPermissoes.Contains);
            }

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
