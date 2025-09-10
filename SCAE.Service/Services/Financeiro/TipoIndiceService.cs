using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;

namespace SCAE.Service.Services.Financeiro
{
    public class TipoIndiceService : CrudService<TipoIndice, ITipoIndiceRepository>, ITipoIndiceService
    {
        public TipoIndiceService(ITipoIndiceRepository repository) : base(repository)
        {

        }

        public override async Task Patch(int id, JsonPatchDocument<TipoIndice> model, string include)
        {
            var tipoIndice = await Get(id);
            if (tipoIndice == null)
                throw new NotFoundException("TipoIndice não encontrado!");

            if (tipoIndice.EdicaoBloqueada)
                throw new BadRequestException($"Não é possível editar TipoIndice {tipoIndice.Nome}!");

            var opNome = model.Operations.FirstOrDefault(op => op.path.Equals("/Nome", StringComparison.OrdinalIgnoreCase));

            if (opNome != null)
                throw new BadRequestException("Não é possível alterar nome principal de TipoIndice");

            var opId = model.Operations.FirstOrDefault(op => op.path.Equals("/Id", StringComparison.OrdinalIgnoreCase));

            if (opId != null)
                throw new BadRequestException("Não é possível alterar Id de TipoIndice");

            await base.Patch(id, model, include);
        }

        public override async Task Put(TipoIndice entity)
        {
            var tipoIndice = await Get(entity.Id);

            if (tipoIndice == null)
                throw new NotFoundException($"TipoIndice não encontrado para atualização {entity.Id}");
            
            if(tipoIndice.EdicaoBloqueada)
                throw new BadRequestException($"TipoIndice de Id {entity.Id} não pode ser alterado!");

            entity.Nome = tipoIndice.Nome;

            await base.Put(entity);
        }

        public override Task Delete(TipoIndice entity)
        {
            throw new BadRequestException("Não é possível deletar um TipoIndice");
        }

        public override Task Delete(int id)
        {
            throw new BadRequestException("Não é possível deletar um TipoIndice");
        }

        public override Task Post(TipoIndice entity)
        {
            throw new BadRequestException("Não é possível cadastrar um novo TipoIndice");
        }

        public override Task Post(TipoIndice entity, bool saveChanges = true)
        {
            throw new BadRequestException("Não é possível cadastrar um novo TipoIndice");
        }
    }
}
