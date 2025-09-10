using SCAE.Framework.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class UnidadeModel
    {
        [Required(ErrorMessage = "O campo Id é obrigatório")]
        public int Id { get; set; }

        [StringLength(150, ErrorMessage = "O valor do campo Nome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Situacao é obrigatório")]
        public string Situacao { get; set; }

        [Required(ErrorMessage = "O campo Tipo é obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O campo EmpreendimentoId é obrigatório")]
        public int EmpreendimentoId { get; set; }

        [StringLength(25, ErrorMessage = "O valor do campo GrupoNome ultrapassou o limite de caracteres"), Required(ErrorMessage = "O campo GrupoNome é obrigatório")]
        public string GrupoNome { get; set; }

        public decimal Valor { get; set; }
        public string Descricao { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo Matricula ultrapassou o limite de caracteres")]
        public string Matricula { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo RGI ultrapassou o limite de caracteres")]
        public string RGI { get; set; }

        [StringLength(45, ErrorMessage = "O valor do campo Processo ultrapassou o limite de caracteres")]
        public string Processo { get; set; }

        [StringLength(45, ErrorMessage = "O valor do campo Orgao ultrapassou o limite de caracteres")]
        public string OrgaoEmissor { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo NumeroLivro ultrapassou o limite de 15 caracteres")]
        public string NumeroLivro { get; set; }

        [StringLength(25, ErrorMessage = "O valor do campo Cartorio ultrapassou o limite de 25 caracteres")]

        public string Cartorio { get; set; }

        [RequiredIf("Cartorio", null, ErrorMessage = "O campo CartorioUF é obrigatório se o nome do cartório foi inserido", IsInverted = true), StringLength(2, ErrorMessage = "O valor do campo CartorioUF ultrapassou o limite de 2 caracteres")]
        public string CartorioUF { get; set; }

        [RequiredIf("Cartorio", null, ErrorMessage = "O campo CartorioMunicipio é obrigatório se o nome do cartório foi inserido", IsInverted = true), StringLength(25, ErrorMessage = "O valor do campo CartorioMunicipio ultrapassou o limite de 25 caracteres")]
        public string CartorioMunicipio { get; set; }

        public decimal Frente { get; set; }
        public decimal LadoDireito { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public decimal Fundos { get; set; }
        public decimal AreaTotal { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de 09 caracteres")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de 80 caracteres"), RequiredIf("CEP",null, IsInverted = true, ErrorMessage = "O campo Logradouro é obrigatório se o campo CEP foi inserido")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de 60 caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de 60 caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de 60 caracteres"), RequiredIf("CEP", null, IsInverted = true, ErrorMessage = "O campo Bairro é obrigatório se o campo CEP foi inserido")]
        public string Bairro { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo UF ultrapassou o limite de 02 caracteres"), RequiredIf("CEP", null, IsInverted = true, ErrorMessage = "O campo UF é obrigatório se o campo CEP foi inserido")]
        public string UF { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Município ultrapassou o limite de 60 caracteres"), RequiredIf("CEP", null, IsInverted = true, ErrorMessage = "O campo Municipio é obrigatório se o campo CEP foi inserido")]
        public string Municipio { get; set; }
    }
}
