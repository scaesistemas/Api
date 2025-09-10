using SCAE.Domain.Entities.Geral;
using SCAE.Migracao.Data;
using SCAE.Migracao.Helper;
using System;
using System.Linq;

namespace SCAE.Migracao.Services
{
    public class CorretorService
    {
        public void Migrar()
        {
            using (var context = new MigracaoContext())
            {

                foreach (var corretor in context.Corretores)
                {
                    if (string.IsNullOrEmpty(corretor.CpfCnpj))
                        continue;

                    var pessoa = ObterByCpfCnpj(corretor.CpfCnpjFormatado);

                    if (pessoa != null)
                        continue;

                    var estadoId = Estado.ObterPorUf(corretor.UF)?.Id ?? Estado.RJ.Id;
                    var municipioId = Municipio.ObterPorNome(estadoId, corretor.Cidade)?.Id ?? 3303500;

                    pessoa = new Pessoa()
                    {
                        EmpresaId = 1,
                        CodigoOrigem = corretor.Id,
                        CnpjCpf = corretor.CpfCnpjFormatado,
                        TipoPessoaId = corretor.TipoPessoa == "Física" ? TipoPessoa.Fisica.Id : TipoPessoa.Juridica.Id,
                        Nome = corretor.Nome,
                        Endereco =
                        {
                            Cep = corretor.CepFormatado,
                            Logradouro = corretor.Endereco,
                            Numero = corretor.Numero,
                            Complemento = corretor.Complemento,
                            Bairro = corretor.Bairro,
                            EstadoId = estadoId,
                            MunicipioId = municipioId
                        },
                        Email = corretor.Email,
                        Telefone = corretor.Telefone1,
                        Rg = corretor.Rg?.Trim(),
                        OrgaoExpedido = corretor.OrgaoExp?.Substring(0, corretor.OrgaoExp.Length > 15 ? 15 : corretor.OrgaoExp.Length),
                        DataExpedicao = corretor.DataExp,
                        IsCorretor = true,
                    };

                    Salvar(pessoa);

                    Console.WriteLine("Gravou: {0} - {1} - {2}", pessoa.CnpjCpf, pessoa.Nome, pessoa.CodigoOrigem);
                }

                Console.WriteLine();
                ConsoleHelper.WriteColor("--> CORRETOR MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
                Console.WriteLine();

            }
        }

        public Pessoa ObterByCpfCnpj(string cpfCnpj)
        {
            using var context = new ScaeApiContext();

            return context.Pessoas.SingleOrDefault(x => x.CnpjCpf == cpfCnpj);
        }

        public void Salvar(Pessoa pessoa)
        {
            using var context = new ScaeApiContext();

            context.Pessoas.Add(pessoa);
            context.SaveChanges();
        }
    }
}
