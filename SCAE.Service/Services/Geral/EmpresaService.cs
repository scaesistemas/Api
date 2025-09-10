using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Geral;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Models.Global;
using SCAE.Domain.Models.Zoop;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral
{
    public class EmpresaService : CrudService<Empresa, IEmpresaRepository>, IEmpresaService
    {
        public EmpresaService(IEmpresaRepository repository) : base(repository)
        {
        }

        public override async Task Post(Empresa entity)
        {
            if (Get().Any(x => x.CpfCnpj == entity.CpfCnpj))
                throw new BadRequestException("Já existe uma Empresa com esse CNPJ!");

            await base.Post(entity);
        }

        public override async Task Patch(int id, JsonPatchDocument<Empresa> model, string include)
        {

            var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

            if (domain == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            model.ApplyTo(domain);

            await SaveChangesAsync();
        }

        public override async Task Put(Empresa entity)
        {
            await base.Put(entity);
        }

    }
}
