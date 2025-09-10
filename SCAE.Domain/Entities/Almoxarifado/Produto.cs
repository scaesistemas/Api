using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Almoxarifado
{
    [Table("produto", Schema = "almoxarifado")]
    public class Produto : IEntity
    {
        private byte[] _foto;

        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [MaxLength(25), Required] public string Codigo { get; set; }
        [MaxLength(80), Required] public string Nome { get; set; }
        public string Descricao { get; set; }
        public int GrupoId { get; set; }
        public GrupoProduto Grupo { get; set; }
        public int TipoId { get; set; }
        public TipoProduto Tipo { get; set; }
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
        public decimal UltimaCompraPreco { get; set; }
        public DateTime? UltimaCompraData { get; set; }
        public int? UltimaCompraFornecedorId { get; set; }
        public Pessoa UltimaCompraFornecedor { get; set; }
        public decimal PrecoCustoMedio { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueCritico { get; set; }
        public decimal Peso { get; set; }
        public decimal Volume { get; set; }
        public decimal Saldo => AlmoxarifadoItens.Sum(x => x.Quantidade);
        //public byte[] Foto { get; set; }
        public byte[] Foto { get { return null; } set { _foto = value; } }
        [Required] public bool Ativo { get; set; }

        public ICollection<AlmoxarifadoItem> AlmoxarifadoItens { get; set; }
        public ICollection<ProdutoFornecedor> Fornecedores { get; set; }

        public string CodigoNome => $"{Codigo} - {Nome}";
        public string CodigoNomeSaldo => $"{Codigo} - {Nome} - {Saldo}";
        public string IdNome => $"{Id} - {Nome}";
        public string IdNomeSaldo => $"{Id} - {Nome} - {Saldo}";

        public byte[] GetFoto()
        {
            return _foto;
        }

        public Produto()
        {
            Ativo = true;
            AlmoxarifadoItens = new List<AlmoxarifadoItem>();
            Fornecedores = new List<ProdutoFornecedor>();
        }


        [Table("produtofornecedor", Schema = "almoxarifado")]
        public class ProdutoFornecedor : IEntity
        {
            public int Id { get; set; }
            public int ProdutoId { get; set; }
            public Produto Produto { get; set; }
            public int FornecedorId { get; set; }
            public Pessoa Fornecedor { get; set; }
            public string Codigo { get; set; }
        }
    }
}
