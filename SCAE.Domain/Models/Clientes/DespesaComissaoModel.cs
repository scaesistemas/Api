using System;
using System.Collections.Generic;
using SCAE.Domain.Entities.Clientes;

namespace SCAE.Domain.Models.Clientes
{
    public class DespesaComissaoModel
    {
      public Contrato Contrato { get; set; }
      public List<Comissoes> ParcelaComissoesCorretores { get; set; }
    }

    public class Comissoes {
      public int CorretorId { get; set; }
      public List<LigacaoParcelaDespesa> LigacaoParcelas { get; set; }
    }
  public class LigacaoParcelaDespesa
  {
    public int TipoReceitaId { get; set; }
    public int NumeroParcelaReceita { get; set; }
    public int NumeroParcelaDespesa { get; set; }
    public DateTime DataDeVencimento { get; set; }
  }
}