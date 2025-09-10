using Microsoft.EntityFrameworkCore;

namespace SCAE.Domain.Entities.Shared
{
    [Owned]
    public class BancoInfo{
        public string Agencia { get; set; }
        public string NumeroConta { get; set; }
        public string CodigoBanco { get; set; }
        public string ChavePix { get; set; }
    }
}