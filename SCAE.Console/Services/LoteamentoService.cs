using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;
using SCAE.Migracao.Data;
using SCAE.Migracao.Helper;
using SCAE.Migracao.Models;
using System;
using System.Globalization;
using System.Linq;

namespace SCAE.Migracao.Services
{
    public class LoteamentoService
    {
        private readonly ApiService _apiService;

        public LoteamentoService()
        {
            _apiService = new ApiService();
        }

        public void Migrar()
        {
            using (var context = new MigracaoContext())
            {

                foreach (var loteamento in context.Loteamentos
                    .Include(x => x.Quadras)
                        .ThenInclude(y => y.Lotes)
                    //.Where(x => x.Id != 2 && x.Id != 79))
                    .Where(x => x.Id != -10000))
                {
                    var empreendimento = ObterById(loteamento.Id);

                    if (empreendimento != null)
                        continue;

                    var estadoId = Estado.ObterPorUf(loteamento.UF)?.Id ?? Estado.RJ.Id;
                    var municipioId = Municipio.ObterPorNome(estadoId, loteamento.Cidade)?.Id ?? 3303500;

                    empreendimento = new Empreendimento()
                    {
                        EmpresaId = 1,
                        CodigoOrigem = loteamento.Id,
                        Nome = loteamento.Nome,
                        Endereco =
                        {
                            Cep = loteamento.CepFormatado,
                            Logradouro = loteamento.Endereco,
                            Numero = loteamento.Numero,
                            Complemento = loteamento.Complemento,
                            Bairro = loteamento.Bairro,
                            EstadoId = estadoId,
                            MunicipioId = municipioId
                        },
                        Legalizacao = new LegalizacaoEmpreendimento
                        {
                            Rgi = loteamento.RGI,
                            NumeroProcesso = loteamento.Processo,
                            Matricula = loteamento.Matricula,
                            OrgaoEmissor = loteamento.LegalizacaoOrgao,
                        },
                        Infraestrutura = new EmpreendimentoInfraestrutura
                        {
                            Descricao = loteamento.InfraEstrutura,
                            AreaRua = loteamento.AreaRuas,
                        },
                        TipoId = TipoEmpreendimento.Loteamento.Id
                    };

                    foreach (var quadra in loteamento.Quadras)
                    {
                        var grupo = new Grupo
                        {
                            CodigoOrigem = quadra.Id,
                            Nome = quadra.Codigo
                        };

                        foreach (var lote in quadra.Lotes)
                        {
                            var unidade = new Unidade
                            {
                                CodigoOrigem = lote.Id,
                                Codigo = lote.Codigo,
                                Nome = lote.Codigo,
                                TipoId = TipoUnidade.Lote.Id,
                                SituacaoId = lote.SituacaoId,
                                Endereco =
                                {
                                    Cep = lote.CepFormatado,
                                    Logradouro = lote.Endereco,
                                    Bairro = loteamento.Bairro,
                                    EstadoId = estadoId,
                                    MunicipioId = municipioId
                                },
                                Lote = new Lote
                                {
                                    Dimensao = new DimensaoLote
                                    {
                                        Curva = ConvertToDecimal(lote.DimensaoCurva),
                                        Frente = ConvertToDecimal(lote.DimensaoFrente),
                                        Fundo = ConvertToDecimal(lote.DimensaoFundos),
                                        LadoDireito = ConvertToDecimal(lote.DimensaoDireito),
                                        LadoEsquerdo = ConvertToDecimal(lote.DimensaoEsquerdo),
                                    }
                                }
                            };

                            grupo.Unidades.Add(unidade);
                        }

                        empreendimento.Grupos.Add(grupo);
                    }

                    Salvar(empreendimento);

                    Console.WriteLine("Gravou: {0} - {1}", empreendimento.Nome, empreendimento.CodigoOrigem);
                }

                Console.WriteLine();
                ConsoleHelper.WriteColor("--> EMPREENDIMENTO MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
                Console.WriteLine();

            }
        }

        public Empreendimento ObterById(int id)
        {
            using var context = new ScaeApiContext();

            return context.Empreendimentos.SingleOrDefault(x => x.CodigoOrigem == id);
        }

        public int ObterByApiCodigoOrigem(int codigoOrigem)
        {
            var itens = _apiService.Get<ResultData>($"empreendimento?$filter=codigoOrigem eq {codigoOrigem}").Items;
            
            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public int ObterUnidadeByApiCodigoOrigem(int codigoOrigem)
        {
            var itens = _apiService.Get<ResultData>($"empreendimento/unidade?$filter=codigoOrigem eq {codigoOrigem}").Items;

            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public void Salvar(Empreendimento empreendimento)
        {
            using var context = new ScaeApiContext();

            context.Empreendimentos.Add(empreendimento);
            context.SaveChanges();
        }

        private decimal ConvertToDecimal(string valor)
        {
            var nfi = new CultureInfo("pt-BR", false).NumberFormat;

            valor = valor.Replace("/", ",").Replace("O", "0").Replace("-", "").Replace(",,", ",");

            try
            {
                return !string.IsNullOrEmpty(valor) ? decimal.Parse(valor, nfi) : 0;
            }
            catch
            {
                Console.WriteLine(valor);
                return 0;
            }
        }

        public int ObterByLoteId(int loteId)
        {
            using var context = new ScaeApiContext();

            return context.Unidades.SingleOrDefault(x => x.CodigoOrigem == loteId)?.Id ?? 0;
        }

        public int ObterByLoteamentoId(int loteamentoId)
        {
            using var context = new ScaeApiContext();

            return context.Empreendimentos.SingleOrDefault(x => x.CodigoOrigem == loteamentoId)?.Id ?? 0;
        }
    }
}
