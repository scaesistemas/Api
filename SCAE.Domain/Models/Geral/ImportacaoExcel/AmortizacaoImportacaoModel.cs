using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    //classe criada para lidar com importação de amortizações
    public class AmortizacaoImportacaoModel
    {
        public int NumeroParcela {  get; set; }
        public int SituacaoReceitaParcelaGeradaId { get; set; }
        public int SituacaoReceitaParcelaAmortizadaId => SituacaoReceitaParcelaGeradaId == SituacaoReceitaParcela.Aberto.Id ? SituacaoReceitaParcela.AmortizadoPendente.Id : SituacaoReceitaParcela.Amortizado.Id;
    }
}
