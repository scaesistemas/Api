using SCAE.Domain.Entities.Geral;
using SCAE.Migracao.Data;
using SCAE.Migracao.Helper;
using SCAE.Migracao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Migracao.Services
{
    public class FornecedorService
    {
        private readonly ApiService _apiService;

        public FornecedorService()
        {
            _apiService = new ApiService();
        }

        public void Migrar()
        {
            using (var context = new MigracaoContext())
            {

                foreach (var fornecedor in context.Fornecedores.OrderBy(x => x.Id))
                {
                    if (string.IsNullOrEmpty(fornecedor.CpfCnpj))
                        continue;

                    var pessoaId = ObterByApiCpfCnpj(fornecedor.CpfCnpjFormatado);

                    if (pessoaId > 0)
                        continue;

                    var estadoId = Estado.ObterPorUf(fornecedor.UF)?.Id ?? Estado.RJ.Id;
                    var municipioId = Municipio.ObterPorNome(estadoId, fornecedor.Cidade)?.Id ?? 3303500;

                    var pessoa = new Pessoa()
                    {
                        EmpresaId = 1,
                        CodigoOrigem = fornecedor.Id,
                        CnpjCpf = fornecedor.CpfCnpjFormatado,
                        TipoPessoaId = fornecedor.TipoPessoa == "Física" ? TipoPessoa.Fisica.Id : TipoPessoa.Juridica.Id,
                        Nome = fornecedor.Nome,
                        Endereco =
                        {
                            Cep = fornecedor.CepFormatado,
                            Logradouro = fornecedor.Endereco,
                            Numero = fornecedor.Numero,
                            Complemento = fornecedor.Complemento,
                            Bairro = fornecedor.Bairro,
                            EstadoId = estadoId,
                            MunicipioId = municipioId
                        },
                        Email = fornecedor.Email,
                        Telefone = fornecedor.Telefone1,
                        IsFornecedor = true,
                        SexoId = Sexo.Masculino.Id
                    };

                    Salvar(pessoa);

                    Console.WriteLine("Gravou: {0} - {1} - {2}", pessoa.CnpjCpf, pessoa.Nome, pessoa.CodigoOrigem);
                }

                Console.WriteLine();
                ConsoleHelper.WriteColor("--> FORNECEDORES MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
                Console.WriteLine();
            }
        }

        public int ObterByApiCpfCnpj(string cnpjCpf)
        {
            var itens = _apiService.Get<ResultData>($"pessoa/?$filter=cnpjCpf eq '{cnpjCpf}'").Items;

            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public void Salvar(Pessoa pessoa)
        {
            _apiService.Post("pessoa", pessoa);
        }
    }
}
