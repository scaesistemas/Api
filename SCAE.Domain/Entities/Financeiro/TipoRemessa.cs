using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tiporemessa", Schema = "financeiro")]
    public class TipoRemessa : IEntity
    {
        public int Id { get; set; }
        [Required] public string Nome { get; set; }

        [NotMapped] public static TipoRemessa Registrar => new TipoRemessa(1, "Registrar");
        [NotMapped] public static TipoRemessa Cancelar => new TipoRemessa(2, "Cancelar");


        public TipoRemessa(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static TipoRemessa[] ObterDados() 
        {
            return new TipoRemessa[]
            {
                Registrar,
                Cancelar
            };
        }
    }
}
