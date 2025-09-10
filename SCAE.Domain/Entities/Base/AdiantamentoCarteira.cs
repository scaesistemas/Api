using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Base
{
    [Table("adiantamentocarteira", Schema = "base")]
    public class AdiantamentoCarteira : IEntity
    {
        public int Id { get; set; }
        public int AssinanteId { get; set; }
        [NotMapped]
        public int EmpresaSolicitanteId { get; set; }
        public EmpresaSolicitante EmpresaSolicitante { get; set; }
        public string Objetivo { get; set; }
        public decimal Valor { get; set; }
        public DateTime PrimeiroMesParcela { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public int QuantidadeParcelas { get; set; }
        public decimal ValorParcela { get; set; }
        public int TipoAdiantamentoCarteiraId { get; set; }
        public TipoAdiantamentoCarteira TipoAdiantamentoCarteira { get; set; }
        public int SituacaoAdiantamentoCarteiraId { get; set; }
        public SituacaoAdiantamentoCarteira SituacaoAdiantamentoCarteira { get; set; }
        public ICollection<ContratoAdiantamento> AdiantamentoContratos  { get; set; }
        public ICollection<SplitPagamentoBase> SplitPagamentos { get; set; }

        public decimal ValorContratado => ValorParcela * QuantidadeParcelas;

        public AdiantamentoCarteira()
        {
            AdiantamentoContratos = new List<ContratoAdiantamento>();
            SplitPagamentos = new List<SplitPagamentoBase>();
        }
    }
}
