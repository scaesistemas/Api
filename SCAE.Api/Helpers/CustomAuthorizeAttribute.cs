using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SCAE.Api.Helpers
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _roles;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var provider = context.HttpContext.User.Claims;

            if(provider.Count() == 0)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var roleProvider = provider.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;

            var rawRoles = _roles.Split(',');
            var computedRoles = new List<object>();

            foreach (var role in rawRoles)
            {
                computedRoles.Add(role.Trim());
            }

            var hasAuthorization = computedRoles.Contains(roleProvider);

            if (hasAuthorization)
                return;

            context.Result = new ForbidResult();
            return;
        }

        public CustomAuthorizeAttribute(string roles)
        {
            _roles = roles;
        }
    }
}
