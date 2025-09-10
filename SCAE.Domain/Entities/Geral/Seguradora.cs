using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Geral
{
    [Table("seguradora", Schema = "geral")]
    public class Seguradora : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        [StringLength(100), Required] public string Nome { get; set; }
        [StringLength(100)] public string Fantasia { get; set; }
        public int TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        [StringLength(18), Required] public string CnpjCpf { get; set; }
        [StringLength(15)] public string InscricaoMunicipal { get; set; }
        [StringLength(15)] public string InscricaoEstadual { get; set; }
        [StringLength(15)] public string Susep { get; set; }
        [StringLength(15)] public string CodigoSeguradora { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<SeguradoraContato> Contatos { get; set; }

        public Seguradora()
        {
            Contatos = new List<SeguradoraContato>();
        }
    }
}
