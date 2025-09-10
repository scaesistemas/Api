using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Compras;

[Table("pedido", Schema = "compras")]
public class Pedido : IEntity
{
    public int Id { get; set; }
    public int EmpresaId { get; set; }
    public Empresa Empresa { get; set; }
    public int OrcamentoId { get; set; }
    public Orcamento Orcamento { get; set; }
    public int TipoId { get; set; }
    public TipoProduto Tipo { get; set; }
    public int FornecedorId { get; set; }
    public Pessoa Fornecedor { get; set; }
    public int SituacaoFreteId { get; set; }
    public SituacaoFrete SituacaoFrete { get; set; }
    public DateTime DataEmissao { get; set; }
    public DateTime? DataEntrega { get; set; }
    public string Conferente { get; set; }
    public decimal Frete { get; set; }
    public Despesa Despesa { get; set; }
    public int? DespesaId { get; set; }
    public int SituacaoGeralPedidoItensId => ChecarSituacaoItens();
    //public int CentroCustoId { get; set; }
    //public CentroCusto CentroCusto { get; set; }
    //public int ContaGerencialId { get; set; }
    //public ContaGerencial ContaGerencial { get; set; }
    public ICollection<PedidoItem> Itens { get; set; }
    public ICollection<PedidoClassificacao> Classificacoes { get; set; }
    public ICollection<PedidoXMLArquivo> ArquivosXML {  get; set; }
    public bool RecebidoPorXML {  get; set; }

    public Pedido()
    {
        DataEmissao = DateTime.Now;
        Itens = new List<PedidoItem>();
        ArquivosXML = new List<PedidoXMLArquivo>();
        SituacaoFreteId = SituacaoFrete.SemFrete.Id;
    }

    int ChecarSituacaoItens()
    {
        if (Itens == null || Itens.Count <= 0)
            return SituacaoPedidoItem.RecebidoIntegral.Id;

        if (Itens.All(x => x.SituacaoId == SituacaoPedidoItem.RecebidoIntegral.Id))
            return SituacaoPedidoItem.RecebidoIntegral.Id;

        if (Itens.Any(x => x.SituacaoId == SituacaoPedidoItem.RecebidoIntegral.Id || x.SituacaoId == SituacaoPedidoItem.RecebidoParcial.Id))
            return SituacaoPedidoItem.RecebidoParcial.Id;

        return SituacaoPedidoItem.Pendente.Id;
    }
}
