using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Service.Services.Shared
{
    public class IPWhitelistAttributeService : ActionFilterAttribute
    {
        private readonly string[] _allowedIPs;

        public IPWhitelistAttributeService(IConfiguration configuration)
        {
            _allowedIPs = configuration.GetSection("AllowedIPs").Get<string[]>();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
    {
        var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
        
        if (remoteIp == null)
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.Forbidden,
                Content = "IP não autorizado."
            };
            return;
        }

        // Converte IPv6 compatível com IPv4 para IPv4 puro
        if (remoteIp.IsIPv4MappedToIPv6)
        {
            remoteIp = remoteIp.MapToIPv4();
        }

        var remoteIpString = remoteIp.ToString();

        if (!_allowedIPs.Contains(remoteIpString))
        {
            context.Result = new ContentResult
            {
                StatusCode = (int)HttpStatusCode.Forbidden,
                Content = $"IP {remoteIpString} não autorizado na whitelist."
            };
            return;
        }

        base.OnActionExecuting(context);
    }
    }
}