using SCAE.Domain.Entities.Financeiro;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("fn_receber")]
    public class Recebivel
    {
        [Column("idReceber")] public int Id { get; set; }
        [Column("idEmpresa")] public int EmpresaId { get; set; }
        [Column("idContrato")] public int ContratoId { get; set; }
        public int Sequencia { get; set; }
        public string NumeroDocumento { get; set; }
        public int Parcela { get; set; }
        public DateTime DataEmissao { get; set; }
        [Column("Vencimento")] public DateTime DataVencimento { get; set; }
        [Column("Pagamento")] public DateTime? DataPagamento { get; set; }
        public decimal Juros { get; set; }
        public decimal Multa { get; set; }
        public decimal Descontos { get; set; }
        public decimal ValorParcela { get; set; }
        public decimal ValorPago { get; set; }
        public string Situacao { get; set; }
        public int SituacaoId => ObterSituacao(Situacao);
        public int IdFormaPagto { get; set; }
        public int FormaPagamentoId => ObterFormaPagamentoRical(IdFormaPagto);

        private int ObterSituacao(string nome)
        {
            if (nome == "A Receber" || nome == "Vencida")
                return SituacaoReceitaParcela.Aberto.Id;

            if (nome == "Recebida")
                return SituacaoReceitaParcela.Pago.Id;

            if (nome == "Parcial")
                return SituacaoReceitaParcela.PagoParcialmente.Id;

            if (nome == "Cancelada")
                return SituacaoReceitaParcela.Cancelado.Id;

            return -1;
        }

        private int ObterFormaPagamento(int id)
        {
            switch (id)
            {
                case 2: //BAIXA AUTOMATICA
                    return 1;
                case 28: //BOLETO - BAIXA MANUAL
                    return 1;
                case 23: //CARTÃO DE CRÉDITO
                    return 3;
                case 24: //CARTÃO DE DÉBITO
                    return 4;
                case 27: //CHEQUE
                    return 15;
                case 25: //CREEME
                    return 5;
                case 1: //DINHEIRO
                    return 6;
                case 21: //PARCELA GRATUITA
                    return 7;
                case 18: // TRANSFERÊNCIA BANCÁRIA
                    return 12;
                default:
                    return 11;
            }
        }

        private int ObterFormaPagamentoJCV(int id)
        {
            switch (id)
            {
                case 10: //BAIXA AUTOMATICA
                    return 1;
                case 11: //BOLETO - BAIXA MANUAL
                    return 1;
                case 3: //CARTÃO DE CRÉDITO
                    return 3;
                case 8: //CARTÃO DE DÉBITO
                    return 4;
                case 5: //CHEQUE
                    return 15;
                case 7: //DEPOSITO
                    return 8;
                case 1: //DINHEIRO
                    return 6;
                case 6: // TRANSFERÊNCIA BANCÁRIA
                    return 12;
                case 9: // CONTRATOS ANTIGOS
                    return 9;
                default:
                    return 11;
            }
        }

        private int ObterFormaPagamentoHelena(int id)
        {
            switch (id)
            {
                case 2: //BAIXA AUTOMATICA
                    return 1;
                case 28: //BOLETO - BAIXA MANUAL
                    return 1;
                case 23: //CARTÃO DE CRÉDITO
                    return 3;
                case 24: //CARTÃO DE DÉBITO
                    return 4;
                case 27: //CHEQUE
                    return 15;
                case 25: //TRANFERENCIA DE CRÉDITO
                    return 5;
                case 1: //DINHEIRO
                    return 6;
                case 21: //PARCELA GRATUITA
                    return 7;
                case 17: // CONTRATOS ANTIGOS
                    return 9;
                case 18: // TRANSFERÊNCIA BANCÁRIA
                    return 12;
                default:
                    return 11;
            }
        }

        private int ObterFormaPagamentoLagos(int id)
        {
            switch (id)
            {
                case 1:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    return id;
                default:
                    return 31;
            }
        }

        private int ObterFormaPagamentoRical(int id)
        {
            switch (id)
            {
                case 1:
                case 17:
                case 18:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                    return id;
                default:
                    return 30;
            }
        }
    }
}
