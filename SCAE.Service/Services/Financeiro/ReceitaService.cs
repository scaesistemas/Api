using Microsoft.AspNetCore.JsonPatch;
using SCAE.Data.Interface.Financeiro;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Financeiro;
using SCAE.Service.Services.Shared;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Financeiro;

public class ReceitaService : CrudService<Receita, IReceitaRepository>, IReceitaService
{
    public ReceitaService(IReceitaRepository repository) : base(repository)
    {
    }

    public override async Task Put(Receita entity)
    {
        var domain = await Get(entity.Id);

        if (domain.NumeroDocumento != entity.NumeroDocumento && await _repository.NumeroDocumentoDuplicado(entity.NumeroDocumento))
            throw new BadRequestException("A identificação do documento já encontra-se cadastrada no sistema");

        await base.Put(entity);
    }

    public override async Task Post(Receita receita)
    {
        if (await _repository.NumeroDocumentoDuplicado(receita.NumeroDocumento))
            throw new BadRequestException("A identificação do documento já encontra-se cadastrada no sistema");

        await base.Post(receita);
    }

    public override async Task Patch(int id, JsonPatchDocument<Receita> model, string include)
    {
        var domain = string.IsNullOrEmpty(include) ? await GetTracking(id) : await GetTracking(id, include);

        if (domain == null)
            throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

        var numeroDocumentoAnterior = domain.NumeroDocumento;
        model.ApplyTo(domain);

        if (domain.NumeroDocumento != numeroDocumentoAnterior && await _repository.NumeroDocumentoDuplicado(domain.NumeroDocumento))
            throw new BadRequestException("A identificação do documento já encontra-se cadastrada no sistema");

        await SaveChangesAsync();
    }

    public IQueryable<ReceitaBaixa> GetBaixaAllNoInclude(string include = "")
    {
        return _repository.GetBaixaAllNoInclude(include);
    }

    public IQueryable<ReceitaParcela> GetParcelaAll(string include = "")
    {
        return _repository.GetParcelaAll(include);
    }

    public IQueryable<ReceitaTransacao> GetTransacaoAll(string include = "")
    {
        return _repository.GetTransacaoAll(include);
    }

    public IQueryable<ReceitaParcela> GetParcelaAllNoInclude()
    {
        return _repository.GetParcelaAllNoInclude();
    }

    public IQueryable<ReceitaClassificacao> GetClassificacaoAll()
    {
        return _repository.GetClassificacaoAll();
    }
}