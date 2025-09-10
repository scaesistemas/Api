using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class LeadModel
    {
        [StringLength(100, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Data de Cadastro do lead é obrigatório")]
        public DateTime DataCadastroLead { get; set; }
        
        [StringLength(120, ErrorMessage = "O valor do campo EmailPrincipal ultrapassou o limite de caracteres")]
        public string EmailPrincipal { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Celular ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo de celular é obrigatório")]
        public string Celular { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Telefone ultrapassou o limite de caracteres")]
        public string Telefone { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo CPF/CNPJ ultrapassou o limite de caracteres")]
        public string CpfCnpj { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo RG ultrapassou o limite de caracteres")]
        public string RG { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo Orgao Expedidor ultrapassou o limite de caracteres")]
        public string OrgaoExpedidor { get; set; }

        public DateTime DataExpedicao { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Nacionalidade { get; set; }
        public decimal RendaBruta { get; set; }
        public decimal RendaLiquida { get; set; }
        public string EstadoCivil { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de caracteres")]
        public string Bairro { get; set; }

        [StringLength(2, ErrorMessage = "O valor do campo UF ultrapassou o limite de caracteres")]
        public string UF { get; set; }

        [Required(ErrorMessage = "O campo Municipio é obrigatório")] 
        public string Municipio { get; set; }
    }
}