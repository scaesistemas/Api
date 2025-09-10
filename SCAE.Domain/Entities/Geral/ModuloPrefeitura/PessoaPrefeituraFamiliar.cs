using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Geral.ModuloPrefeitura
{
    [Table("pessoaprefeiturafamiliar", Schema = "geral")]
    public class PessoaPrefeituraFamiliar : IEntity
    {
        public int Id { get; set; }
        public int? PessoaPrefeituraId { get; set; }
        public PessoaPrefeitura PessoaPrefeitura { get; set; }
        public int? EscolaridadeId { get; set; }
        public TipoEscolaridade Escolaridade { get; set; }
        public int GrauParentescoId { get; set; }
        public GrauParentesco GrauParentesco { get; set; }
        [StringLength(14)] public string Cpf { get; set; }
        [StringLength(100)] public string Nome { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        [StringLength(15)] public string OrgaoExpedidor { get; set; }
        [StringLength(15)] public string Telefone { get; set; }
        public decimal RendaBruta { get; set; }
        public decimal RendaLiquida { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Dependente { get; set; }
        public int? ProfissaoId { get; set; }
        public Profissao Profissao { get; set; }
    }
}
