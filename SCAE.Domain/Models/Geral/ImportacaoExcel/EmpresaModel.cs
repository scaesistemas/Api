using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class EmpresaModel
    {
        [StringLength(18, ErrorMessage = "O valor do campo CNPJ ultrapassou o limite de 18 caracteres"), Required(ErrorMessage = "O campo CNPJ é obrigatório")]
        public string CNPJ { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo RazaoSocial ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo RazaoSocial é obrigatório")]
        public string RazaoSocial { get; set; }

        [StringLength(30, ErrorMessage = "O valor do campo Fantasia ultrapassou o limite de 30 caracteres"), Required(ErrorMessage = "O campo Fantasia é obrigatório")]
        public string Fantasia { get; set; }

        [StringLength(16, ErrorMessage = "O valor do campo Celular ultrapassou o limite de 16 caracteres"), Required(ErrorMessage = "O campo Celular é obrigatório")]
        public string Celular { get; set; }

        [StringLength(120, ErrorMessage = "O valor do campo Email ultrapassou o limite de 120 caracteres"), Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        [StringLength(11, ErrorMessage = "O valor do campo InscricaoMunicipal ultrapassou o limite de 11 caracteres")]
        public string InscricaoMunicipal { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo InscricaoEstadual ultrapassou o limite de 09 caracteres")]
        public string InscricaoEstadual { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de 9 caracteres"), Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de 80 caracteres"), Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de 60 caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de 60 caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo UF ultrapassou o limite de 2 caracteres"), Required(ErrorMessage = "O campo UF é obrigatório")]
        public string UF { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Municipio ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo Municipio é obrigatório")]
        public string MunicipioNome { get; set; }

        [StringLength(120, ErrorMessage = "O valor do campo NomeResponsavel ultrapassou o limite de 120 caracteres"), Required(ErrorMessage = "O campo NomeResponsavel é obrigatório")]
        public string NomeResponsavel { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo SobrenomeResponsavel ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo SobrenomeResponsavel é obrigatório")]
        public string SobrenomeResponsavel { get; set; }

        [StringLength(14, ErrorMessage = "O valor do campo CPFResponsavel ultrapassou o limite de 14 caracteres"), Required(ErrorMessage = "O campo CPFResponsavel é obrigatório")]
        public string CPFResponsavel { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEPResponsavel ultrapassou o limite de 09 caracteres"), Required(ErrorMessage = "O campo CEPResponsavel é obrigatório")]
        public string CEPResponsavel { get; set; }

        [Required(ErrorMessage = "O campo DataNascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo LogradouroResponsavel ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo LogradouroResponsavel é obrigatório")]
        public string LogradouroResponsavel { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo NumeroResponsavel ultrapassou o limite de caracteres")]
        public string NumeroResponsavel { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo ComplementoResponsavel ultrapassou o limite de caracteres")]
        public string ComplementoResponsavel { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo BairroResponsavel ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo BairroResponsavel é obrigatório")]
        public string BairroResponsavel { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo UFResponsavel ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo UFResponsavel é obrigatório")]
        public string UFResponsavel { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Municipio Responsável ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo MunicipioNomeResponsavel é obrigatório")]
        public string MunicipioNomeResponsavel { get; set; }

    }
}
