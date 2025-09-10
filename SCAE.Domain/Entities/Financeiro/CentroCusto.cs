using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("centrodecusto", Schema = "financeiro")]
    public class CentroCusto : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(20)] [Required(AllowEmptyStrings = true)] public string Codigo { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        public string CodigoDescricao => $"{Codigo} - {Nome}";
        public CentroCusto CentroCustoPai { get; set; }
        public int? CentroCustoPaiId { get; set; }
        [Required] public bool Ativo { get; set; }

        [NotMapped] 
        public List<CentroCusto> Children { get; set; }

    }
}
