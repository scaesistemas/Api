using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SCAE.Data.Context;
using SCAE.Domain.Entities.Base;
using SCAE.Domain.Models.Shared;
using SCAE.Service.Interfaces.Shared;

namespace SCAE.Service.Services.Shared
{
    public class ScaeApiContextFactory : IScaeApiContextFactory
    {
        private readonly IConfiguration _configuration;
        private readonly IOptions<BaseSettingModel> _baseSetting;
        private readonly IServiceProvider _serviceProvider;

    public ScaeApiContextFactory(
        IConfiguration configuration,
        IOptions<BaseSettingModel> baseSetting,
        IServiceProvider serviceProvider)
    {
        _configuration = configuration;
        _baseSetting = baseSetting;
        _serviceProvider = serviceProvider;
    }

    public ScaeApiContext Create(Assinante assinante)
    {
        var options = _serviceProvider.GetRequiredService<DbContextOptions<ScaeApiContext>>();
        return new ScaeApiContext(options, assinante, _configuration, _baseSetting);
    }
    }
}