using SCAE.Domain.Entities.Financeiro;
using SCAE.Framework.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SCAE.Domain.Models.Geral
{
    public class ExcelParcelaModel
    {
        [Required(ErrorMessage = "O valor do campo Numero é obrigatório")]
        public int Numero { get; set; }
        public int TotalParcelas { get; set; } = 0;

        /// <summary>
        /// "Numero da parcela / Total de parcelas"
        /// </summary>
        public string NumeroTotal { get; set; }
        [Required(ErrorMessage = "O valor do campo Tipo é obrigatório")]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "O valor do campo Data de vencimento é obrigatório")]
        public DateTime DataVencimento { get; set; }

        [Required(ErrorMessage = "O valor do campo Numero do contrato é obrigatório")]
        public string NumeroContrato { get; set; }
        [Required(ErrorMessage = "O valor do campo Situação é obrigatório")]
        public string SituacaoParcela { get; set; }

        [Required(ErrorMessage = "O valor do campo valor é obrigatório")]
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public decimal ValorPago { get; set; }
        public decimal DescontoBaixa { get; set; }
        public decimal JurosBaixa { get; set; }
        public decimal MultaBaixa { get; set; }
        [RequiredIf("SituacaoParcela", "Pago", ErrorMessage = "O campo Forma de Pagamento é obrigatório se a parcela for paga")]
        public string FormaPagamento { get; set; }
        [RequiredIf("SituacaoParcela", "Pago", ErrorMessage = "O campo Conta Corrente é obrigatório se a parcela for paga")]
        public string ContaCorrente { get; set; }
        public decimal JurosDia { get; set; }
        public decimal Multa { get; set; }
        public decimal DescontoVencimento { get; set; }
        public int DiasDescontoVencimento { get; set; }
        public decimal DescontoAntecipacao { get; set; }
        public int DiasAposVencimentoNaoReceber { get; set; }
        public string BaixaCancelada { get; set; }
        public string ParcelaAmortizacao { get; set; }
        public decimal Amortizacao { get; set; }
        public decimal JurosPrice { get; set; }

        public bool IsAmortizacao { get; set; } = false;
        public int Linha { get; set; }
        public int ContratoNumero { get; set; }
        public int ContratoSequencia { get; set; }
        public int ContratoId { get; set; }
        public TipoReceita TipoReceita { get; set; }
    }

    //Excluir depois dos testes

    public class ParcelaModelSimples 
    {
        public int Linha { get; set; }
        public string NumeroContrato { get; set; }
        public string NumeroTotal { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
    }

    //Para trabalhar melhor com expressões Linq ao importar parcelas
    public class ComparadorExcelParcela : IEqualityComparer<ExcelParcelaModel>
    {
        public bool Equals(ExcelParcelaModel x, ExcelParcelaModel y)
        {
            if (x.Linha <= 0 || y.Linha <= 0)
            {
                var mensagemErroBuilder = new StringBuilder("Ocorreu um erro ao comparar os ExcelParcelaModel! ");
                if (x.Linha <= 0)
                    mensagemErroBuilder.AppendLine($"A parcela {x.NumeroTotal} do tipo {x.Tipo} do contrato {x.ContratoSequencia} não possui valor salvo para Linha. ");
                if (y.Linha <= 0)
                    mensagemErroBuilder.AppendLine($"A parcela {y.NumeroTotal} do tipo {y.Tipo} do contrato {y.ContratoSequencia} não possui valor salvo para Linha. ");

                throw new Exception(mensagemErroBuilder.ToString());
            }

            return x.Linha == y.Linha;
        }

        public int GetHashCode([DisallowNull] ExcelParcelaModel obj)
        {
            return obj.Linha;
        }
    }
}
