using Microsoft.AspNetCore.Http;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Models.Shared;
using System.Collections.Generic;

namespace SCAE.Data.Interface.Provider
{
    public interface IAssinanteProvider
    {
        string GetHost(IHttpContextAccessor accessor, bool full = false);
        string GetHost(bool full = false);
        Assinante GetTenant();
        IEnumerable<Assinante> AllTenants { get; }
        SessionAppModel SessionApp { get; }
    }
}
