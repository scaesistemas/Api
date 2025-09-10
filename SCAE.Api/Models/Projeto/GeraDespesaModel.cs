using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;

namespace SCAE.Api.Models.Projeto
{
    public class GeraDespesaModel
    {
        public DateTime DataPrimeiroVencimento { get; set; }
        public int TipoDocumentoId { get; set; }
        public int PrazoDiasParcela { get; set; }
        public int QuantidadeParcela { get; set; }
    }
}
