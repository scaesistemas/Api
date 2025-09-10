using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Shared
{
    public class Contato
    {
        [StringLength(100)] public string Nome { get; set; }
        [StringLength(15)] public string Celular { get; set; }
        [StringLength(15)] public string Telefone { get; set; }
        [StringLength(10)] public string Ramal { get; set; }
        public string Email { get; set; }
    }
}
