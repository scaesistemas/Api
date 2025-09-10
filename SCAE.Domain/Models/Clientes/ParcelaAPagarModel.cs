using System;

namespace SCAE.Domain.Models.Clientes
{
    public class ParcelaAPagarModel
    {
        public int Id { get; set; }
        public string NumeroContrato { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string TipoReceita { get; set; }
        public int NumeroParcela { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public int SituacaoId { get; set; }
        public string urlBoleto { get; set; }
        public string codigoZoop { get; set; }
        public int? tipoGatewayId { get; set; }
        public int tipoOperacaoId { get; set; }
        public string CodigoBarra { get; set; }

    }
}
