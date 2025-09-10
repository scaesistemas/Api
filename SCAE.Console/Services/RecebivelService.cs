using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Migracao.Data;
using SCAE.Migracao.Entities;
using SCAE.Migracao.Helper;
using SCAE.Migracao.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCAE.Migracao.Services
{
    public class RecebivelService
    {
        private readonly ApiService _apiService;

        public RecebivelService()
        {
            _apiService = new ApiService();
        }

        public int ObterByApiContratoId(int contratoId, int tipoReceitaId)
        {
            var itens = _apiService.Get<ResultData>($"receita?$filter=tipoId eq {tipoReceitaId} and contratoId eq {contratoId}").Items;

            return itens.FirstOrDefault()?.Id ?? 0;
        }

        public void MigrarParcelasByApy(int empresaId, int numeroContrato, int sequencia)
        {
            using var context = new MigracaoContext();
            var contratoId = new ContratoService().ObterByApiCodigoOrigem(numeroContrato, sequencia);

            #region Parcelas
            var recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == numeroContrato && x.Sequencia == sequencia && x.Parcela < 400);
            var receitaId = ObterByApiContratoId(contratoId, TipoReceita.Titulo.Id);

            foreach (var recebivel in recebiveis)
            {
                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                _apiService.Post($"receita/{receitaId}/parcela", parcela);
            }

            #endregion

            #region 700 - Serviços
            recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == numeroContrato && x.Sequencia == sequencia && x.Parcela >= 700 && x.Parcela <= 799);
            receitaId = ObterByApiContratoId(contratoId, TipoReceita.Outros.Id);

            foreach (var recebivel in recebiveis)
            {
                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                _apiService.Post($"receita/{receitaId}/parcela", parcela);
            }
            #endregion

            #region 900 - Entrada
            recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == numeroContrato && x.Sequencia == sequencia && x.Parcela >= 900 && x.Parcela <= 999);
            receitaId = ObterByApiContratoId(contratoId, TipoReceita.TituloEntrada.Id);

            foreach (var recebivel in recebiveis)
            {
                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                _apiService.Post($"receita/{receitaId}/parcela", parcela);
            }

            #endregion

            Console.WriteLine();
            ConsoleHelper.WriteColor("--> PARCELAS MIGRADOS COM SUCESSO <--", ConsoleColor.Green);
            Console.WriteLine();
        }

        public List<Receita> ObterReceita(int empresaId, int empresaId2, int clienteId,  int contratoId, int sequencia, int empreendimentoId, Encargo encargo)
        {
            using var context = new MigracaoContext();

            var receitas = new List<Receita>();

            #region Parcelas
            var recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == contratoId && x.Sequencia == sequencia && x.Parcela < 400);

            var receita = new Receita()
            {
                EmpresaId = empresaId2,
                ClienteId = clienteId,
                EmpreendimentoId = empreendimentoId,
                Valor = recebiveis.Sum(x => x.ValorParcela),
                TipoId = TipoReceita.Titulo.Id,
                TipoDocumentoId = 1
            };

            foreach (var recebivel in recebiveis)
            {
                receita.NumeroDocumento = recebivel.NumeroDocumento;
                receita.DataEmissao = recebivel.DataEmissao;

                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                    EncargoFinanceiro = encargo
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                receita.Parcelas.Add(parcela);
            }

            receitas.Add(receita);
            #endregion

            #region 700 - Serviços
            recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == contratoId && x.Sequencia == sequencia && x.Parcela >= 700 && x.Parcela <= 799);

            receita = new Receita()
            {
                EmpresaId = empresaId2,
                ClienteId = clienteId,
                EmpreendimentoId = empreendimentoId,
                Valor = recebiveis.Sum(x => x.ValorParcela),
                TipoId = TipoReceita.Outros.Id,
                TipoDocumentoId = 1
            };

            foreach (var recebivel in recebiveis)
            {
                receita.NumeroDocumento = recebivel.NumeroDocumento;
                receita.DataEmissao = recebivel.DataEmissao;

                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                receita.Parcelas.Add(parcela);
            }

            receitas.Add(receita);
            #endregion

            #region 800 - Aditamento
            recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == contratoId && x.Sequencia == sequencia && x.Parcela >= 800 && x.Parcela <= 899);

            receita = new Receita()
            {
                EmpresaId = empresaId2,
                ClienteId = clienteId,
                EmpreendimentoId = empreendimentoId,
                Valor = recebiveis.Sum(x => x.ValorParcela),
                TipoId = TipoReceita.TituloHonorarios.Id,
                TipoDocumentoId = 1
            };

            foreach (var recebivel in recebiveis)
            {
                receita.NumeroDocumento = recebivel.NumeroDocumento;
                receita.DataEmissao = recebivel.DataEmissao;

                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                receita.Parcelas.Add(parcela);
            }

            receitas.Add(receita);
            #endregion

            #region 900 - Entrada
            recebiveis = context.Recebiveis.AsNoTracking().Where(x => x.EmpresaId == empresaId && x.ContratoId == contratoId && x.Sequencia == sequencia && x.Parcela >= 900 && x.Parcela <= 999);

            receita = new Receita()
            {
                EmpresaId = empresaId2,
                ClienteId = clienteId,
                EmpreendimentoId = empreendimentoId,
                Valor = recebiveis.Sum(x => x.ValorParcela),
                TipoId = TipoReceita.TituloEntrada.Id,
                TipoDocumentoId = 1
            };

            foreach (var recebivel in recebiveis)
            {
                receita.NumeroDocumento = recebivel.NumeroDocumento;
                receita.DataEmissao = recebivel.DataEmissao;

                var parcela = new ReceitaParcela()
                {
                    Parcela = recebivel.Parcela,
                    DataVencimento = recebivel.DataVencimento,
                    DataVencimentoOriginal = recebivel.DataVencimento,
                    Valor = recebivel.ValorParcela,
                    SituacaoId = recebivel.SituacaoId == -1 ? SituacaoReceitaParcela.Aberto.Id : recebivel.SituacaoId,
                };

                if (parcela.SituacaoId == SituacaoReceitaParcela.Pago.Id || parcela.SituacaoId == SituacaoReceitaParcela.PagoParcialmente.Id)
                {
                    var baixa = new ReceitaBaixa
                    {
                        DataPagamento = recebivel.DataPagamento.HasValue ? recebivel.DataPagamento.Value : recebivel.DataVencimento,
                        Valor = recebivel.ValorParcela,
                        Desconto = recebivel.Descontos,
                        Juros = recebivel.Juros,
                        Multa = recebivel.Multa,
                        FormaPagamentoId = recebivel.FormaPagamentoId,
                        ContaCorrenteId = 1,
                        UsuarioId = 1
                    };

                    parcela.Baixas.Add(baixa);
                }

                receita.Parcelas.Add(parcela);
            }

            receitas.Add(receita);
            #endregion

            return receitas;
        }

    }
}
