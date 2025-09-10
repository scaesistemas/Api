using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Base
{
    [Table("assinantedominio", Schema = "base")]
    public class AssinanteDominio : IEntity
    {
        public int Id { get; set; }
        public int AssinanteId { get; set; }
        [MaxLength(255), Required] public string Nome { get; set; }
        [Required] public bool Principal { get; set; }

        public AssinanteDominio(string nome, bool principal)
        {
            Nome = nome;
            Principal = principal;
        }
    }
}
