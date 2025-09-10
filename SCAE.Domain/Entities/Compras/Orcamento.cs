using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Compras
{
    [Table("orcamento", Schema = "compras")]
    public class Orcamento : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int ClassificacaoId { get; set; }
        public TipoProduto Classificacao { get; set; }
        public string Descricao { get; set; }
        //public int? CentroCustoId { get; set; }
        //public CentroCusto CentroCusto { get; set; }
        //public int? ContaGerencialId { get; set; }
        //public ContaGerencial ContaGerencial { get; set; }
        public ICollection<OrcamentoFornecedor> Fornecedores { get; set; }
        public ICollection<OrcamentoDocumento> Documentos { get; set; }
        public ICollection<OrcamentoItem> Itens { get; set; }
        public decimal ValorTotal => Total();
        public int SituacaoId { get; set; }
        public SituacaoOrcamento Situacao { get; set; }
        public OrcamentoAprovacao Aprovacao { get; set; }

        public string Observacao { get; set; }

        public decimal Total()
        {
            //foreach (var item in Itens)
            //{
            //    foreach (var itemFornecedor in item.ItemFornecedores)
            //    {
            //        itemFornecedor.ValorTotal = item.Quantidade * itemFornecedor.ValorUnitario;
            //    }
            //}

            //foreach (var fornecedor in Fornecedores)
            //{
            //    fornecedor.Total = (from x in Itens
            //                        from y in x.ItemFornecedores
            //                        where
            //                             y.FornecedorId == fornecedor.FornecedorId
            //                        select y.ValorTotal).Sum();
            //}

            return 0;
        }

        public Orcamento()
        {
            Aprovacao = new OrcamentoAprovacao();
            Itens = new List<OrcamentoItem>();
            Fornecedores = new List<OrcamentoFornecedor>();
            Documentos = new List<OrcamentoDocumento>();
        }
    }

    [Owned]
    public class OrcamentoAprovacao
    {
        public bool Aprovado { get; set; }
        public DateTime? DataHora { get; set; }
        public int? UsuarioId { get; set; }

        public OrcamentoAprovacao()
        {
            Aprovado = false;
        }
    }
}
