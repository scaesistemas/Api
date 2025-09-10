using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PdfSharpCore.Fonts;
using SCAE.Api.Extensions;
using SCAE.Data.Context;
using SCAE.Domain.Models.Clientes.ContratoDigitalNS;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro;
using SCAE.Domain.Models.Financeiro.Gateway;
using SCAE.Domain.Models.Shared;
using Sentry;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

if (!builder.Environment.IsDevelopment())
{

    builder.WebHost.UseSentry(o =>
        {
            o.Dsn = "https://6911d2aa83dff57a408b3690522f2983@o4509679545679872.ingest.us.sentry.io/4509679547187200";
#if (DEBUG)
            o.Debug = false;
#else
            o.Debug = true;
#endif
            o.TracesSampleRate = 1.0;
        });
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString());
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Api SCAE",
        Version = "v1",
        Description = "Web API com funcionalidades de gest�o.",
        Contact = new OpenApiContact
        {
            Name = "Renan Matos",
            Email = "renan@giomtecnologia.com.br",
        },
    });

    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SCAE.Api.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "SCAE.Framework.xml"));
});
builder.Services.AddInjections();
builder.Services.AddJwt(builder.Configuration);

builder.Services.Configure<ZoopSettingModel>(builder.Configuration.GetSection("ZoopSettings"));
builder.Services.Configure<SafraSettingModel>(builder.Configuration.GetSection("SafraSettings"));
builder.Services.Configure<BaseSettingModel>(builder.Configuration.GetSection("BaseSettings"));
builder.Services.Configure<WebhookFinanceiroAuthorization>(builder.Configuration.GetSection("WebhookFinanceiroAuthorization"));
builder.Services.Configure<ApiKeysContainerModel>(builder.Configuration.GetSection("ApiKeysContainer"));
builder.Services.Configure<SmsSettingModel>(builder.Configuration.GetSection("SmsSettings"));
builder.Services.Configure<TelegramSettingModel>(builder.Configuration.GetSection("TelegramSettings"));
builder.Services.Configure<GalaxPaySettingModel>(builder.Configuration.GetSection("GalaxPaySettings"));
builder.Services.Configure<DFourSignSettingModel>(builder.Configuration.GetSection("DFourSignSettings"));
builder.Services.Configure<ApiFinanceiroSettingModel>(builder.Configuration.GetSection("ApiFinanceiroSettings"));
builder.Services.Configure<LoggerSettingModel>(builder.Configuration.GetSection("LoggerSettings"));
builder.Services.Configure<GedSettingModel>(builder.Configuration.GetSection("GedSettings"));
builder.Services.Configure<BucketAwsModel>(builder.Configuration.GetSection("BucketAws"));

builder.Services.AddDbContext<ScaeBaseContext>(options => options.UseNpgsql("Host=127.0.0.1;Port=5432;Pooling=true;Database=scaedev-base;User Id=postgres;Password=DB@ccess;"));
builder.Services.AddDbContext<ScaeApiContext>();


builder.Services.AddControllers(mvc => mvc.EnableEndpointRouting = false).AddODataNewtonsoftJson().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.UseCamelCasing(true);
}).AddOData(options =>
{
    options.Select().Expand().Filter().OrderBy().Count().SetMaxTop(null);
});

builder.Services.AddCors(o => o.AddPolicy("CorsLibera", builder =>
{
    builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocumentTitle = "Documenta��o - API SCAE";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api SCAE V1");
});

UpdateDatabase(app);

if (GlobalFontSettings.FontResolver.DefaultFontName == "Arial")
{
    GlobalFontSettings.FontResolver = new SCAE.Service.Services.Boleto.BoletoGenerator.MeuFontResolver();
}

app.EnsureMigrationsRun();
app.UseCors("CorsLibera");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();


static void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<ScaeBaseContext>())
        {
            context.Database.Migrate();
        }
    }

    using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<ScaeApiContext>())
        {
            context.Database.Migrate();
        }
    }


}