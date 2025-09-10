using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioDimobModel
    {
        public List<RelDimobModel> Dimob { get; set; }
        public decimal TotalValorPagoNoAno { get; set; }
    }

    public class RelDimobModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public int? NumeroContrato { get; set; }
        public DateTime? DataContrato { get; set; }
        public string TipoImovel { get; set; }
        public decimal ValorTotalContrato { get; set; }
        public decimal ValorPagoNoAno { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Uf { get; set; }
        public string Municipio { get; set; }

        public string EmpreendimentoNome { get; set; }
        public string Cep { get; set; }

        public string EmpresaNome {get; set; }
    }
}
