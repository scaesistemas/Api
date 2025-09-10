using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("etapa", Schema = "projeto")]
    public class Etapa : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(20)] [Required(AllowEmptyStrings = true)] public string Codigo { get; set; }
        [StringLength(60)] [Required] public string Nome { get; set; }
        public string CodigoDescricao => $"{Codigo} - {Nome}";
        public Etapa EtapaPai { get; set; }
        public int? EtapaPaiId { get; set; }
        public int? TipoEmpreendimentoId { get; set; }
        public TipoEmpreendimento TipoEmpreendimento { get; set; }


        [Required] public bool Ativo { get; set; }

        [NotMapped]
        public List<Etapa> Children { get; set; }
    }

}
