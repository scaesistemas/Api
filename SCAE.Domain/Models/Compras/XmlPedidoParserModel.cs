using Microsoft.AspNetCore.Http;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Clientes;
using System.Collections.Generic;
using System.IO;

namespace SCAE.Domain.Models.Compras;

public class XmlPedidoParserModel
{
   // public byte[] ArquivoXml { get; set; }
    //public string ArquivoNome { get; set }
    public Arquivo ArquivoXml {  get; set; }
    public string FornecedorCNPJ { get; set; }
    public List<XmlItemPedidoParserModel> Itens { get; set; }

    public XmlPedidoParserModel()
    {
        Itens = new List<XmlItemPedidoParserModel>();
    }
}
public class XmlItemPedidoParserModel
{
    public string Codigo { get; set; }
    public string Nome { get; set; }
    public decimal Valor { get; set; }
    public decimal Quantidade { get; set; }

    #region Auxiliar no mapeamento do produto no sistema
    public int? ProdutoId { get; set; }
    public Produto? ProdutoSugestao { get; set; }
    public bool CodigoJaRegistrado => ProdutoId != null;
    #endregion

}
