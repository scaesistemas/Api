using SCAE.Domain.Entities.Clientes.ContratoDigitalNS;
using System.Collections.Generic;

namespace SCAE.Api.Models.Clientes
{
    public class CadastrarSignatariosModel
    {
        public List<int> SignatariosIds { get; set; }
        public string DFourSignDocumentId { get; set; }
        public CadastrarSignatariosModel() 
        {
            SignatariosIds = new List<int>();
        }
    }
}
