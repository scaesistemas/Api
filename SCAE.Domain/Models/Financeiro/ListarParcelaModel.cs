using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Financeiro
{
    public class ListarParcelaModel : IEntity
    {
        public int EmpresaId { get; set; }
        public string EmpresaNome { get; set; }
        public int Id { get; set; }
        public DateTime DataVencimentoParcela { get; set; } 
        public DateTime? DataPagamentoParcela { get; set; }
        public IEnumerable<int?> ContasCorrentesIds { get; set; }
        public IEnumerable<int> FormasPagamentosIds { get; set; }
        public int? EmpreendimentoId { get; set; }
        public int? ContratoId { get; set; }
        public int SituacaoId { get; set; }
        public string SituacaoNome { get; set; }
        public string NumeroDocumento { get; set; }
        public int ParcelaNumero { get; set; }
        public int ParcelaTotal { get; set; }
        public string ParcelaStr => $"{ParcelaNumero}/{ParcelaTotal}";
        public decimal ValorParcela { get; set; }
        public decimal SaldoParcela { get; set; }
        public decimal ValorPagoParcela {get; set; }
        public bool Conciliado { get; set; }

        public ListarParcelaReceitaModel Receita { get; set; }
        public ListarParcelaDespesaModel Despesa { get; set; }
        public ListarParcelaClassificacaoModel Classificacao { get; set; }


    }


    public class ListarParcelaDespesaModel
    {
        public int Id { get; set; }
        public int? PedidoId { get; set; }
        public int FornecedorId { get; set; }
        public string FornecedorNome { get; set; }
    }

    public class ListarParcelaReceitaModel
    {
        public int Id { get; set; }
        public int? AgrupadorId { get; set; }
        public bool IsAgrupador { get; set; }
        public int? NumeroContrato { get; set; }
        public int? SequenciaContrato { get; set; }
        public string UrlBoleto { get; set; } 
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }

    }

    public class ListarParcelaClassificacaoModel
    {
        public IEnumerable<int> CentrosCustoIds { get; set; }
        public IEnumerable<int> ContasGerenciaisIds { get; set; }
        public IEnumerable<string> CentrosCustoNomes { get; set; }
        public IEnumerable<string> ContasGerenciaisNomes { get; set; }

    }
}
