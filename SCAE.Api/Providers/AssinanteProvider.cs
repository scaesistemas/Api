using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Context;
using SCAE.Data.Interface.Base;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace SCAE.Api.Providers
{
    public class AssinanteProvider : IAssinanteProvider
    {
        private static IList<Assinante> _tenants;
        private readonly Assinante _tenant;
        private readonly IHttpContextAccessor _accessor;
        public IEnumerable<Assinante> AllTenants => _tenants;
        public SessionAppModel SessionApp { get; }

        public string GetHost(IHttpContextAccessor accessor, bool full)
        {
            if (accessor.HttpContext.Request.Headers.Any(x => x.Key == "HostManual"))
                return accessor.HttpContext.Request.Headers["HostManual"][0].ToString();

            if (accessor.HttpContext.Request.Headers.Any(x => x.Key == "Origin"))
                return full ? new Uri(accessor.HttpContext.Request.Headers["Origin"][0]).AbsoluteUri : new Uri(accessor.HttpContext.Request.Headers["Origin"][0]).Host;
            
            return "localhost";
        }

        public string GetHost(bool full)
        {
            return GetHost(_accessor, full);
        }

        public AssinanteProvider(IHttpContextAccessor accessor, ScaeBaseContext context, IAssinanteRepository assinanteService)
        {
            try
            {
                _accessor = accessor;

                if (accessor.HttpContext == null || _tenants == null)
                {
                    _tenants = context.Assinantes.Include(x => x.Dominios).ToList();
                    return;
                }

                if (_tenants == null)
                    _tenants = context.Assinantes.Include(x => x.Dominios).ToList();

                var host = GetHost(accessor, false);

                var tenant = assinanteService.ObterAssinante(host);
                var excecoes = new string[] { "/api/autenticador/usuario", "/api/autenticador/cliente", "/api/autenticador/corretor", "/api/autenticador/adm", "/api/pessoa/criarusuario", "/api/autenticador/confirmaremail", "/api/autenticador/resetarsenha", "/api/empresa/logo", "/api/ChatBot/ChecarContratosCliente", "/api/ChatBot/GetBoleto", "/api/ChatBot/SalvarImagem", "/api/empreendimento/corretor", "/api/autenticador/assinante/logo" };

                if ("/api/assinante" == accessor.HttpContext.Request.Path.ToString() && accessor.HttpContext.Request.Method == "POST")
                    return;

                _tenant = tenant;


                if (excecoes.Contains(accessor.HttpContext.Request.Path.ToString()))
                    return;

                var identity = accessor.HttpContext.User;

                SessionApp = new SessionAppModel(
                    int.Parse(identity.FindFirst(ClaimTypes.Upn).Value),
                    identity.FindFirst(ClaimTypes.NameIdentifier).Value,
                    identity.FindFirst(ClaimTypes.Name).Value,
                    int.Parse(identity.FindFirst("assinanteId").Value),
                    string.Empty,
                    null
                );

            }
            catch (Exception ex)
            {
                accessor.HttpContext.Response.StatusCode = 500;
                accessor.HttpContext.Response.WriteAsync("Empresa não informado!");

throw new InvalidOperationException("Empresa não informado!" + ex.Message);
            }
        }

        public Assinante GetTenant()
        {
            return _tenant;
        }
    }
}
