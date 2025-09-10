using SCAE.Domain.Entities.Geral;
using SCAE.Migracao.Data;
using SCAE.Migracao.Helper;
using SCAE.Migracao.Models;
using System;
using System.Linq;

namespace SCAE.Migracao.Services
{
    public class ClienteService
    {
        private readonly ApiService _apiService;

        public ClienteService()
        {
            _apiService = new ApiService();
        }

        public void Migrar()
        {
            using (var context = new MigracaoContext())
            {

                foreach (var cliente in context.Clientes.Where(x => x.TipoCliente=="Sim" || x.TipoCorretor=="Sim").OrderBy(x => x.Id))
                {
                    if (string.IsNullOrEmpty(cliente.CpfCnpj))
                        continue;

                    var pessoa = ObterByCpfCnpj(cliente.CpfCnpjFormatado);

                    if (pessoa != null)
                        continue;

                    var estadoId = Estado.ObterPorUf(cliente.UF)?.Id ?? Estado.RJ.Id;
                    var municipioId = Municipio.ObterPorNome(estadoId, cliente.Cidade)?.Id ?? 3303500;

                    pessoa = new Pessoa()
                    {
                        EmpresaId = 1,
                        CodigoOrigem = cliente.Id,
                        CnpjCpf = cliente.CpfCnpjFormatado,
                        TipoPessoaId = cliente.TipoPessoa == "Física" ? TipoPessoa.Fisica.Id : TipoPessoa.Juridica.Id,
                        Nome = cliente.Nome,
                        Endereco =
                        {
                            Cep = cliente.CepFormatado,
                            Logradouro = cliente.Endereco,
                            Numero = cliente.Numero,
                            Complemento = cliente.Complemento,
                            Bairro = cliente.Bairro,
                            EstadoId = estadoId,
                            MunicipioId = municipioId
                        },
                        Email = cliente.Email,
                        Telefone = cliente.Telefone1,
                        Rg = cliente.Rg?.Trim(),
                        OrgaoExpedido = cliente.OrgaoExp?.Substring(0, cliente.OrgaoExp.Length > 15 ? 15 : cliente.OrgaoExp.Length),
                        DataExpedicao = cliente.DataExp,
                        DataNascimento = cliente.DataNascimento,
                        SexoId = cliente.Sexo == "Masculino" ? Sexo.Masculino.Id : Sexo.Feminino.Id,
                        IsCliente = cliente.IsCliente,
                        IsCorretor = cliente.IsCorretor,
                    };

                    if (!string.IsNullOrEmpty(cliente.Conjuge?.Nome))
                    {

                        if (cliente.Conjuge.Cpf.Length <= 11)
                        {
                            pessoa.Conjuge = new Domain.Conjuge
                            {
                                Cpf = cliente.Conjuge.CpfFormatado,
                                Nome = cliente.Conjuge.Nome,
                                DataNascimento = cliente.Conjuge.DataNascimento,
                                Rg = cliente.Conjuge.Rg,
                                OrgaoExpedidor = cliente.Conjuge.OrgaoExp
                            };
                        }
                    }

                    Salvar(pessoa);

                    Console.WriteLine("Gravou: {0} - {1} - {2}", pessoa.CnpjCpf, pessoa.Nome, pessoa.CodigoOrigem);
                }

                Console.WriteLine();
                ConsoleHelper.WriteColor("--> CLIENTES MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
                Console.WriteLine();
            }
        }

        public Pessoa ObterByCpfCnpj(string cpfCnpj)
        {
            using var context = new ScaeApiContext();

            return context.Pessoas.SingleOrDefault(x => x.CnpjCpf == cpfCnpj);
        }

        public int ObterByApiCpfCnpj(string cnpjCpf)
        {
            var itens = _apiService.Get<ResultData>($"pessoa/?$filter=cnpjCpf eq '{cnpjCpf}'").Items;

            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public void Salvar(Pessoa pessoa)
        {
            using var context = new ScaeApiContext();

            context.Pessoas.Add(pessoa);
            context.SaveChanges();
        }
    }
}
