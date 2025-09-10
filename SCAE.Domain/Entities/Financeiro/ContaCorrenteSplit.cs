using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("contacorrentesplit", Schema = "financeiro")]
    public class ContaCorrenteSplit
    {
        public int Id { get; set; }
        public int ParametroGatewayId { get; set; }
        public ParametroGatway ParametroGateway { get; set; }
        public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public bool IsPercentual { get; set; }
        public decimal Valor { get; set; }
    }
}
