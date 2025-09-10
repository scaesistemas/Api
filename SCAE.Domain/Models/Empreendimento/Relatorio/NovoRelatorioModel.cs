using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Empreendimento.Relatorio
{

    public class RelatorioParcelasComissaoModel
    {
        public List<RelatorioParcelasComissaoItemModel> Itens;

        public RelatorioParcelasComissaoModel(List<RelatorioParcelasComissaoItemModel> lista)
        {
            Itens = lista;
        }

    }

    public class RelatorioParcelasComissaoItemModel
    {
        public string EmpresaNome { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string Grupo { get; set; }
        public string Unidade { get; set; }
        public string SituacaoContrato { get; set; }
        public int? PropostaId { get; set; }
        public string ClienteNome { get; set; }
        public string CorretorNome { get; set; }
        public DateTime? DataProposta { get; set; }
        public decimal ValorBase { get; set; }
        public decimal PorcentagemComissao { get; set; }
        public decimal ValorTotalComissao { get; set; }
        public DateTime? DataBaixaParcela { get; set; }
        public string ParcelaTotal { get; set; } // Ex: "6/7"
        public int? ComissaoId { get; set; } // DespesaId
        public decimal ValorParcela { get; set; }
    }
}