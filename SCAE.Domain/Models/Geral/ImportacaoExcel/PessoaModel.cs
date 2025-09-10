using SCAE.Framework.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class PessoaModel
    {
        [Required(ErrorMessage = "O campo PessoaFisica é obrigatório")]
        public string PessoaFisica { get; set; }

        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(120, ErrorMessage = "O valor do campo EmailPrincipal ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Email é obrigatório")]
        public string EmailPrincipal { get; set; }

        [StringLength(120, ErrorMessage = "O valor do campo SegundoEmail ultrapassou o limite de caracteres")]
        public string SegundoEmail { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Celular ultrapassou o limite de caracteres"), RequiredIf("PessoaFisica", "Não", ErrorMessage = "O campo Celular é obrigatório para pessoa jurídica")]
        public string Celular { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Telefone ultrapassou o limite de caracteres")]
        public string Telefone { get; set; }

        [RequiredIf("PessoaFisica", "Não", ErrorMessage = "O campo Fantasia é obrigatório para pessoa jurídica"), StringLength(100, ErrorMessage = "O valor do campo Fantasia ultrapassou o limite de caracteres")]
        public string Fantasia { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")] 
        public string Tipo { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo CPF/CNPJ ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo CPF/CNPJ é obrigatório")]
        public string CpfCnpj { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo RG ultrapassou o limite de caracteres"), RequiredIf("PessoaFisica", "Sim", ErrorMessage = "O campo RG é obrigatório para pessoa física")]
        public string RG { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Orgao Expedidor ultrapassou o limite de caracteres"), RequiredIf("PessoaFisica", "Sim",ErrorMessage = "O campo OrgaoExpedidor é obrigatório para pessoa física")]
        public string OrgaoExpedidor { get; set; }

        [Required(ErrorMessage = "O campo Data de Expedição é obrigatório"), RequiredIf("PessoaFisica", "Sim", ErrorMessage = "O campo Data da Expedicao é obrigatório para pessoa física")]
        public DateTime DataExpedicao { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Nacionalidade é obrigatório")]
        public string Nacionalidade { get; set; }

        public decimal RendaBruta { get; set; }
        public decimal RendaLiquida { get; set; }

        [RequiredIf("PessoaFisica", "Sim", ErrorMessage = "O campo Estado Civil é obrigatório para pessoa física")]
        public string EstadoCivil { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [StringLength(2, ErrorMessage = "O valor do campo UF ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo UF é obrigatório")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo Municipio é obrigatório")] 
        public string Municipio { get; set; }
        [StringLength(40, ErrorMessage = "O valor do campo Banco ultrapassou o limite de caracteres")]
        public string Banco { get; set; }

        [StringLength(10, ErrorMessage = "O valor do campo AgenciaNumero ultrapassou o limite de caracteres")]
        public string AgenciaNumero { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo AgenciaDigito ultrapassou o limite de caracteres")]
        public string AgenciaDigito { get; set; }

        [StringLength(10, ErrorMessage = "O valor do campo ContaNumero ultrapassou o limite de caracteres")]
        public string ContaNumero { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo ContaDigito ultrapassou o limite de caracteres")]
        public string ContaDigito { get; set; }

        public string ChavePix { get; set; }

        [StringLength(100, ErrorMessage = "O valor do campo ConjugeNome ultrapassou o limite de caracteres")]
        public string ConjugeNome { get; set; }

        [StringLength(14, ErrorMessage = "O valor do campo ConjugeCPF ultrapassou o limite de caracteres")]
        public string ConjugeCPF { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo ConjugeRG ultrapassou o limite de caracteres")]
        public string ConjugeRG { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo ConjugeOrgaoExpedidor ultrapassou o limite de caracteres")]
        public string ConjugeOrgaoExpedidor { get; set; }

        public DateTime ConjugeDataNascimento { get; set; }
        public string CRECI { get; set; }
    }
}
