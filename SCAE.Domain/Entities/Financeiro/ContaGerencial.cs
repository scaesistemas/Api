using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("contagerencial", Schema = "financeiro")]
    public class ContaGerencial : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(20)] [Required(AllowEmptyStrings = true)] public string Codigo { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        public string CodigoDescricao => $"{Codigo} - {Nome}";
        [Column(TypeName = "char")] [Required] public string Tipo { get; set; }
        public int? ContaGerencialPaiId { get; set; }
        public ContaGerencial ContaGerencialPai { get; set; }
        [Required] public bool Ativo { get; set; }
        [NotMapped] //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ContaGerencial> Children { get; set; }

        public ContaGerencial()
        {
            Ativo = true;
        }

        public ContaGerencial(int id, string codigo, string nome, string tipo) : this()
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Tipo = tipo;
        }
    }
}
