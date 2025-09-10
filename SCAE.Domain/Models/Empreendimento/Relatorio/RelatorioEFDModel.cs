using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioEFDModel
    {
        public List<RelEFDModel> Lista { get; set; }
        public decimal TotalPago { get; set; }
        public decimal TotalContrato {  get; set; }
    }

    public class RelEFDModel
    {
        public string EmpreendimentoNome {get; set; }
        public string UnidadeNome { get; set; }
        
        public string QuadraNome { get; set; }

        public string NumeroSeguenciaContrato { get; set; }

        public string NomeCliente { get; set; }

        public string CpfCnpjCliente { get; set; }

        public DateTime DataContrato { get; set; }

        public decimal TotalContrato {get; set; }

        public string SituacaoNome {  get; set; }   

        public decimal TotalPago { get; set; }


    }
}