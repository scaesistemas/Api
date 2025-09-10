using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class CobrancaModel
    {
        public List<Cobranca> cobrancas  {get; set;}

        public CobrancaModel(){
            cobrancas = new List<Cobranca>();
        }
    }

    public class Cobranca{
       public int AssinanteId { get; set; }
        public int ParcelaId { get; set; }
        public int TransacaoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool Erro { get; set; }
        public bool IsCobranca { get; set; }
        public bool IsBaixa {  get; set; }
        public bool IsEmissaoBoleto { get; set; }
        public bool IsCancelamento { get; set; }
        public bool IsCRM { get; set; }

        public Cobranca()
        {
            DataHora = DateTime.Now;
            Erro = false;
        }
    }
}