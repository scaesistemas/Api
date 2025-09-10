using SCAE.Domain.Interfaces.Shared;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("origemlead", Schema = "geral")]
    public class OrigemLead : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(40), Required] public string Nome { get; set; }

        [NotMapped] public static OrigemLead CorretorManual => new(1, "Corretor - Manual");
        [NotMapped] public static OrigemLead EmpresaManual => new(2, "Empresa - Manual");

        public OrigemLead()
        {

        }
        public OrigemLead(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static OrigemLead[] ObterDados()
        {
            return new OrigemLead[]
            {
                CorretorManual,
                EmpresaManual,
            };
        }


    }
}
