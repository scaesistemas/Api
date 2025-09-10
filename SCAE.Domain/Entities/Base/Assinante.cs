using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Base
{
    [Table("assinante", Schema = "base")]
    public class Assinante : PessoaBase
    {
        public virtual ICollection<AssinanteContato> Contatos { get; set; }
        public AssinanteTermo AssinanteTermo { get; set; }
        public AssinanteContato ContatoPrincipal => Contatos?.FirstOrDefault(x => x.Principal);
        public ICollection<AssinanteDominio> Dominios { get; set; }
        public AssinanteDominio DominioPrincipal => Dominios?.FirstOrDefault(x => x.Principal);
        [MaxLength(20), Required] public string SubDominio { get; set; }
        public EmpresaResponsavel Responsavel { get; set; }

        [NotMapped] public bool GerarZoop { get; set; }
        public string DFourSignSafeId { get; set; }
        public Assinante() : base()
        {
            GerarZoop = true;
            Contatos = new List<AssinanteContato>();
            Dominios = new List<AssinanteDominio>();
        }
    }
}