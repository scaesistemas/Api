using SCAE.Framework.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelEmpreendimentoModel
    {
        [Required(ErrorMessage = "O valor do campo Id é obrigatório")]
        public int Id { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo Cpf/Cnpj ultrapassou o limite de 18 caracteres"), Required(ErrorMessage = "O campo Cpf/Cnpj é obrigatório")]
        public string EmpresaCpfCnpj { get; set; }

        [StringLength(200, ErrorMessage = "O valor do campo Nome ultrapassou o limite de 200 caracteres"), Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O valor do campo Tipo é obrigatório")]
        public string Tipo { get; set; }
        public decimal PercentualAdm { get; set; }

        [StringLength(09, ErrorMessage = "O valor do campo CEP ultrapassou o limite de 09 caracteres"), Required(ErrorMessage = "O campo CEP é obrigatório")]
        public string CEP { get; set; }

        [StringLength(80, ErrorMessage = "O valor do campo Logradouro ultrapassou o limite de 80 caracteres"), Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public string Logradouro { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Numero ultrapassou o limite de 60 caracteres")]
        public string Numero { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Complemento ultrapassou o limite de 60 caracteres")]
        public string Complemento { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Bairro ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public string Bairro { get; set; }

        [StringLength(02, ErrorMessage = "O valor do campo UF ultrapassou o limite de 02 caracteres"), Required(ErrorMessage = "O campo UF é obrigatório")]
        public string UF { get; set; }

        [StringLength(60, ErrorMessage = "O valor do campo Município ultrapassou o limite de 60 caracteres"), Required(ErrorMessage = "O campo Município é obrigatório")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "O campo CpfCnpj do 1º Proprietario é obrigatório"), StringLength(18, ErrorMessage = "O valor do CpfCnpj do 1º Proprietario ultrapassou o limite de 18 caracteres")]
        public string CpfCnpjProprietario1 { get; set; }

        [Required(ErrorMessage = "O campo participação do 1º Proprietario é obrigatório")]
        public decimal ParticipacaoProprietario1 { get; set; }
        [StringLength(18, ErrorMessage = "O valor do CpfCnpj do 2º Proprietario ultrapassou o limite de 18 caracteres")]
        public string CpfCnpjProprietario2 { get; set; }
        public decimal ParticipacaoProprietario2 { get; set; }
        [StringLength(18, ErrorMessage = "O valor do CpfCnpj do 3º Proprietario ultrapassou o limite de 18 caracteres")]
        public string CpfCnpjProprietario3 { get; set; }
        public decimal ParticipacaoProprietario3 { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo Matricula ultrapassou o limite de caracteres")]
        public string Matricula { get; set; }

        [StringLength(25, ErrorMessage = "O valor do campo Inscricao Cadastral ultrapassou o limite de 20 caracteres")]
        public string InscricaoCadastral { get; set; }

        [StringLength(20, ErrorMessage = "O valor do campo RGI ultrapassou o limite de 20 caracteres")]
        public string RGI { get; set; }

        [StringLength(45, ErrorMessage = "O valor do campo Processo ultrapassou o limite de 45 caracteres")]
        public string Processo { get; set; }

        [StringLength(45, ErrorMessage = "O valor do campo OrgaoEmissor ultrapassou o limite de 45 caracteres")]
        public string OrgaoEmissor { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo NumeroLivro ultrapassou o limite de 15 caracteres")]
        public string NumeroLivro { get; set; }

        [StringLength(15, ErrorMessage = "O valor do campo EscrituraLavrada ultrapassou o limite de 15 caracteres")]
        public string EscrituraLavrada { get; set; }
        [StringLength(25, ErrorMessage = "O valor do campo Cartorio ultrapassou o limite de 25 caracteres")]
        public string Cartorio { get; set; }
        [RequiredIf("Cartorio", null, ErrorMessage = "O campo CartorioUF é obrigatório se o nome do cartório foi inserido", IsInverted =true), StringLength(2, ErrorMessage = "O valor do campo CartorioUF ultrapassou o limite de 2 caracteres")]
        public string CartorioUF { get; set; }

        [RequiredIf("Cartorio", null, ErrorMessage = "O campo CartorioMunicipio é obrigatório se o nome do cartório foi inserido", IsInverted = true), StringLength(25, ErrorMessage = "O valor do campo CartorioMunicipio ultrapassou o limite de 25 caracteres")]
        public string CartorioMunicipio { get; set; }
        public string Descricao { get; set; }
        public decimal AreaDasUnidades { get; set; }
        public decimal AreaVerde { get; set; }
        public decimal AreaDasRuas { get; set; }
        public decimal AreaDoProprietario { get; set; }
        public decimal OutrasAreas { get; set; }
        public decimal AreaDaPrefeitura { get; set; }
        public decimal Frente { get; set; }
        public decimal LadoDireito { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public decimal Fundos { get; set; }
        public decimal AreaTotal { get; set; }
    }
}
