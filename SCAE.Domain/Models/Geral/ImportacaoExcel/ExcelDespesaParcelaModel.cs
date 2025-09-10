using SCAE.Domain.Entities.Financeiro;
using System;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelDespesaParcelaModel
    {
        //Despesa
        public int? DespesaId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? DataEmissao { get; set; }
        public string TipoDocumento { get; set; }
        public decimal? ValorDespesa { get; set; }
        public string CpfCnpjFornecedor { get; set; }
        public string CnpjEmpresa { get; set; }
        public int? EmpreendimentoCodigoOrigem { get; set; }
        public string Observacao { get; set; }
        
        //DespesaParcela
        public int? NumeroParcela { get; set; }
        public decimal? ValorParcela { get; set; }
        public decimal? ValorPago { get; set; }
        public string FormaPagamento { get; set; }
        public string ContaCorrente { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string SituacaoParcela { get; set; }
        public DateTime? VencimentoParcela { get; set; }
        public string BaixaCancelada { get; set; }

        //Classificacoes
        public string CentroCusto1 { get; set; }
        public string CodigoContaGerencial1 { get; set; }
        public string ContaGerencial1 { get; set; }
        public decimal? ValorClassificacao1 { get; set; }

        public string CentroCusto2 { get; set; }
        public string CodigoContaGerencial2 { get; set; }
        public string ContaGerencial2 { get; set; }
        public decimal? ValorClassificacao2 { get; set; }

        public string CentroCusto3 { get; set; }
        public string CodigoContaGerencial3 { get; set; }
        public string ContaGerencial3 { get; set; }
        public decimal? ValorClassificacao3 { get; set; }

        //Para saber de qual linha é o objeto em Importacao Service
        public int Linha { get; set; }

        //Guarda buscas no banco de dados para não precisar buscar novamente
        public Despesa DespesaSistema { get; set; }
        public DespesaParcela ParcelaSistema { get; set; }
        public int TipoDocumentoIdSistema { get; set; }
        public int FornecedorIdSistema { get; set; }
        public int EmpresaIdSistema { get; set; }
        public int CentroCustoId1Sistema { get; set; }
        public int CentroCustoId2Sistema { get; set; }
        public int CentroCustoId3Sistema { get; set; }
        public int ContaGerencialId1Sistema { get; set; }
        public int ContaGerencialId2Sistema { get; set; }
        public int ContaGerencialId3Sistema { get; set; }

    }
}
