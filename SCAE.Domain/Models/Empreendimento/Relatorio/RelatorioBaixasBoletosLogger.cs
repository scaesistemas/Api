using System.Collections.Generic;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{
    public class RelatorioBaixasBoletosLogger
    {
        public List<RelatorioBaixasBoleto> ListaLogger {get; set;}
    }
    public class RelatorioBaixasBoleto{
        public string Dominio { get; set; }
        public string NomeEmpresa {get; set;}
        public int QuantidadeBoletosGerados {get; set;}
        public int QuantidadeParcelasPagas {get; set;}
        public string InstituicaoFinanceira {get; set;}
    }
}