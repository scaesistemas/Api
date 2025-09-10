using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral
{
    [Table("pessoafamiliar", Schema = "geral")]
    public class PessoaFamiliar : IEntity
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
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
