using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Clientes;
using SCAE.Migracao.Data;
using SCAE.Migracao.Helper;
using SCAE.Migracao.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace SCAE.Migracao.Services
{
    public class ContratoService
    {
        private readonly ApiService _apiService;

        public ContratoService()
        {
            _apiService = new ApiService();
        }

        public void Migrar(int contratoId, int sequenciaId, bool api)
        {
            using (var context = new MigracaoContext())
            {
                var corretorService = new CorretorService();
                var clienteService = new ClienteService();
                var loteamentoService = new LoteamentoService();
                var recebivelService = new RecebivelService();
                var contaCorrenteService = new ContaCorrenteService();
                var contratos = context.Contratos
                    .AsNoTracking()
                    .Include(x => x.Corretor)
                    .Include(x => x.Cliente)
                    .Include(x => x.ClienteA)
                    .Include(x => x.ClienteB)
                    .Include(x => x.ContaCorrente)
                    .Where(x => x.Id > -1000);
                //.Where(x => x.LoteamentoId != 2 && x.LoteamentoId != 79);
                //.Skip(3000);
                //var j = contratos.ToList();
                //var total = contratos.Count();

                //Console.WriteLine(j.Count);
                //Console.WriteLine(total);
                //return;

                if (contratoId > 0)
                    contratos = contratos.Where(x => x.Id == contratoId);

                if (contratoId > 0 && sequenciaId >= 0)
                    contratos = contratos.Where(x => x.Sequencia == sequenciaId);

                foreach (var contrato in contratos)
                {
                    if (contrato.Sequencia > 0)
                        sequenciaId++;

                    if (!api)
                    {
                        if (Migrado(contrato.Id, contrato.Sequencia))
                            continue;
                    }

                    if (contrato.LoteamentoId == 0)
                        continue;

                    var entity = new Contrato()
                    {
                        EmpresaId = contrato.EmpresaId2, //??
                        CodigoOrigem = contrato.Id,
                        Numero = contrato.Id,
                        Sequencia = contrato.Sequencia,
                        Data = contrato.DataContrato,
                        DataVencimentoOriginal = contrato.DataPrimeiraParcela,
                        PrimeiroVencimento = contrato.DataPrimeiraParcela,
                        MelhorDia = (short)contrato.DiaVencimento,
                        Descricao = "CONTRATO IMPORTADO",
                        Valor = contrato.ValorContrato,
                        Prazo = contrato.QuantidadeParcela,
                        QuantidadeParcela = contrato.QuantidadeParcela,
                        SituacaoId = contrato.SituacaoId,
                        TipoId = contrato.TipoContratoId,
                        TipoProdutoId = TipoProduto.Produto.Id,
                        MesReajuste = contrato.DataContrato.AddMonths(1).AddMonths(1 * -1).Month,
                        PercentualAdiministradora = 0,
                        PeriodicidadeReajuste = 0,
                        PeriodicidadeRenovacao = 0,
                        PrazoContratual = 0,
                        NumeroProcessoJudicial = contrato.NumeroProcesso,
                        TipoProcessoJudicialId = contrato.SituacaoProcessoId > 0 ? contrato.SituacaoProcessoId : null,
                        EmpreendimentoId = api ? loteamentoService.ObterByApiCodigoOrigem(contrato.LoteamentoId) : loteamentoService.ObterByLoteamentoId(contrato.LoteamentoId),
                        UnidadePrincipalId = api ? loteamentoService.ObterUnidadeByApiCodigoOrigem(contrato.LoteId) : loteamentoService.ObterByLoteId(contrato.LoteId),
                        TipoIndiceId = contrato.TipoIndiceId,
                    };

                    if (contrato.IsPersonalizado)
                        entity.EncargoFinanceiro = new Domain.Entities.Financeiro.Encargo(contrato.JurosDia, contrato.MultaMes, contrato.DescontoContrato, contrato.DiasDesconto, contrato.DescontoAntecipacao, 0, 0, 0);
                    else
                        entity.EncargoFinanceiro = new Domain.Entities.Financeiro.Encargo(contrato.ContaCorrente.JurosDia, contrato.ContaCorrente.MultaMes,
                            0, contrato.ContaCorrente.DiasDesconto, contrato.ContaCorrente.DescontoAntecipacao, contrato.ContaCorrente.NaoReceberDias, 0, 0);

                    if (entity.UnidadePrincipalId == 0)
                    {
                        Console.WriteLine($"{contrato.LoteamentoId} - Loteamento inexistente!");
                        continue;
                    }

                    if (contrato.Cliente == null)
                        continue;

                    var clienteId = api ? clienteService.ObterByApiCpfCnpj(contrato.Cliente.CpfCnpjFormatado) : clienteService.ObterByCpfCnpj(contrato.Cliente.CpfCnpjFormatado).Id;

                    entity.Clientes.Add(new ContratoCliente { ClienteId = clienteId });

                    if (contrato.ClienteAId > 0)
                        entity.Clientes.Add(new ContratoCliente { ClienteId = api ? clienteService.ObterByApiCpfCnpj(contrato.ClienteA.CpfCnpjFormatado) : clienteService.ObterByCpfCnpj(contrato.ClienteA.CpfCnpjFormatado).Id });

                    if (contrato.ClienteBId > 0)
                        entity.Clientes.Add(new ContratoCliente { ClienteId = api ? clienteService.ObterByApiCpfCnpj(contrato.ClienteB.CpfCnpjFormatado) : clienteService.ObterByCpfCnpj(contrato.ClienteB.CpfCnpjFormatado).Id });

                    var observacoes = GetObservacoes(contrato.Id, contrato.Sequencia);

                    if (observacoes.Any())
                    {
                        foreach (var observacao in observacoes)
                            entity.Observacoes.Add(new ContratoObservacao(1, observacao.DataCadastro, observacao.Texto));
                    }

                    var imagens = GetImagens(contrato.Id, contrato.Sequencia);

                    if (imagens.Any())
                    {
                        foreach (var imagem in imagens)
                        {
                            if (File.Exists(@$"C:\Dev\Temp\novarical\img\{imagem.Arquivo}"))
                            {
                                var documento = new ContratoDocumento
                                {
                                    Descricao = imagem.Descricao,
                                    Nome = imagem.Arquivo,
                                    Dados = File.ReadAllBytes(@$"C:\Dev\Temp\novarical\img\{imagem.Arquivo}"),
                                    Tipo = "image/jpeg"
                                };

                                documento.Tamanho = documento.Dados.Length;

                                entity.Documentos.Add(documento);
                            }
                        }
                    }

                    var pdfs = GetPdfs(contrato.Id, contrato.Sequencia);

                    if (pdfs.Any())
                    {
                        foreach (var pdf in pdfs)
                        {
                            if (File.Exists(@$"C:\Dev\Temp\novarical\pdf\{pdf.Arquivo}"))
                            {
                                var documento = new ContratoDocumento
                                {
                                    Descricao = pdf.Descricao,
                                    Nome = pdf.Arquivo,
                                    Dados = File.ReadAllBytes(@$"C:\Dev\Temp\novarical\pdf\{pdf.Arquivo}"),
                                    Tipo = "application/pdf",
                                };

                                documento.Tamanho = documento.Dados.Length;

                                entity.Documentos.Add(documento);
                            }
                        }
                    }

                    if (contrato.Corretor != null && contrato.CorretorId != 8722)
                        if (!string.IsNullOrEmpty(contrato.Corretor.CpfCnpj))
                            entity.Corretores.Add(new ContratoCorretor { CorretorId = api ? clienteService.ObterByApiCpfCnpj(contrato.Corretor.CpfCnpjFormatado) : corretorService.ObterByCpfCnpj(contrato.Corretor.CpfCnpjFormatado).Id });

                    var receitas = recebivelService.ObterReceita(contrato.EmpresaId, contrato.EmpresaId2, clienteId, contrato.Id, contrato.Sequencia, entity.EmpreendimentoId, entity.EncargoFinanceiro);

                    if (receitas.Any())
                        receitas.ForEach(x => entity.Receitas.Add(x));

                    if (api)
                        _apiService.Post("contrato", entity);
                    else
                        Salvar(entity);

                    Console.WriteLine("Gravou: {0} - {1}", contrato.Id, contrato.Sequencia);
                }

                Console.WriteLine();
                ConsoleHelper.WriteColor("--> CONTRATOS MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
                Console.WriteLine();

            }
        }

        private void Take(int v)
        {
            throw new NotImplementedException();
        }

        public bool Migrado(int contratoId, int sequencia)
        {
            using var context = new ScaeApiContext();

            return context.Contratos.Any(x => x.CodigoOrigem == contratoId && x.Sequencia == sequencia);
        }

        public Contrato ObterById(int contratoId, int sequencia)
        {
            using var context = new ScaeApiContext();

            return context.Contratos.FirstOrDefault(x => x.CodigoOrigem == contratoId && x.Sequencia == sequencia);
        }

        public Entities.Contrato ObterMigracaoById(int contratoId, int sequencia)
        {
            using var context = new MigracaoContext();

            return context.Contratos.Include(x => x.Cliente).FirstOrDefault(x => x.Id == contratoId && x.Sequencia == sequencia);
        }

        public void Salvar(Contrato entity)
        {
            using var context = new ScaeApiContext();

            context.Contratos.Add(entity);
            context.SaveChanges();

        }

        public List<Entities.ContratoObservacao> GetObservacoes(int contratoId, int sequencia)
        {
            using var context = new MigracaoContext();

            return context.Observacoes.AsNoTracking().Where(x => x.ContratoId == contratoId && x.Sequencia == sequencia).ToList();
        }

        public List<Entities.ContratoImagem> GetImagens(int contratoId, int sequencia)
        {
            using var context = new MigracaoContext();

            return context.Imagens.AsNoTracking().Where(x => x.ContratoId == contratoId && x.Sequencia == sequencia).ToList();
        }

        public List<Entities.ContratoPdf> GetPdfs(int contratoId, int sequencia)
        {
            using var context = new MigracaoContext();

            return context.Pdfs.AsNoTracking().Where(x => x.ContratoId == contratoId && x.Sequencia == sequencia).ToList();
        }

        public int ObterByApiCodigoOrigem(int codigoOrigem, int sequencia)
        {
            var itens = _apiService.Get<ResultData>($"contrato?$filter=codigoOrigem eq {codigoOrigem} and sequencia eq {sequencia}").Items;

            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public string LimparAcentuacao(string s)
        {

            string str = s.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            foreach (char t in str)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            return sb.ToString();

        }

    }
}