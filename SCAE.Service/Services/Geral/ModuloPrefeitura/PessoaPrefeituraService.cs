using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SCAE.Data.Interface.Geral;
using SCAE.Data.Interface.Geral.ModuloPrefeitura;
using SCAE.Data.Interface.Provider;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Geral.ModuloPrefeitura;
using SCAE.Framework.Exceptions;
using SCAE.Framework.Helper;
using SCAE.Service.Interfaces.Base;
using SCAE.Service.Interfaces.Clientes.ContratoDigitalNS;
using SCAE.Service.Interfaces.Financeiro.ApiFinanceiro;
using SCAE.Service.Interfaces.Financeiro.Gateway;
using SCAE.Service.Interfaces.Geral;
using SCAE.Service.Interfaces.Geral.ModuloPrefeitura;
using SCAE.Service.Services.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Geral.ModuloPrefeitura
{
    public class PessoaPrefeituraService : CrudService<PessoaPrefeitura, IPessoaPrefeituraRepository>, IPessoaPrefeituraService
    {
        public PessoaPrefeituraService(IPessoaPrefeituraRepository repository) : base(repository)
        {
        }

        public async Task<List<PessoaPrefeituraDocumento>> GetDocumentos(int pessoaId)
        {
            return await _repository.GetDocumentos(pessoaId);
        }

        public async Task<PessoaPrefeituraDocumento> GetDocumentoByIdAsync(int id)
        {
            return await _repository.GetDocumentoByIdAsync(id);
        }

        public override async Task Post(PessoaPrefeitura entity)
        {

            if (Get().Any(x => x.CnpjCpf == entity.CnpjCpf))
                throw new BadRequestException("Já existe uma pessoa com esse CPF/CNPJ!");

            if (!CnpjCpfHelper.IsCPFCNPJValido(entity.CnpjCpf))
                throw new BadRequestException("CPF ou CNPJ inválido");

            await base.Post(entity);
        }

        public async Task<PessoaPrefeitura> GetByUserId(int usuarioId)
        {
            return await _repository.GetByUserId(usuarioId);
        }

        public async Task<PessoaPrefeitura> GetByCPF(string cpf, string include = "")
        {
            return await _repository.GetByCPF(cpf, include);
        }

        public async Task ExcluirPessoas()
        {
            var clientes = await _repository.GetAll().ToListAsync();

            foreach (var cliente in clientes)
            {
                _repository.Remove(cliente);
            }
            await SaveChangesAsync();
        }

        public async Task PostList(List<PessoaPrefeitura> list, bool saveChanges = true)
        {
            await _repository.InsertList(list);

            if (saveChanges)
                await SaveChangesAsync();
        }
    }
}
