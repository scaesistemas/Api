using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class BeneficiarioModel
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EnderecoModel Endereco { get; set; }
        public string Categoria { get; set; }

        public BeneficiarioModel()
        {
            Endereco = new EnderecoModel();
        }

        public string PrimeiroNome()
        {
            return !string.IsNullOrEmpty(Nome) ? Nome.Substring(0, Nome.IndexOf(" ")).Trim() : string.Empty;
        }

        public string SobreNome()
        {
            return !string.IsNullOrEmpty(Nome) ? Nome.Substring(Nome.IndexOf(" ")).Trim() : string.Empty;
        }
    }

    public class BeneficiarioProprietarioModel
    {
        [MinLength(11), MaxLength(11)] public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EnderecoModel Endereco { get; set; }
        public DateTime DataNascimento { get; set; }

        public BeneficiarioProprietarioModel()
        {
            Endereco = new EnderecoModel();
        }

        public string PrimeiroNome()
        {
            return !string.IsNullOrEmpty(Nome) ? Nome.Substring(0, Nome.IndexOf(" ")).Trim() : string.Empty;
        }

        public string SobreNome()
        {
            return !string.IsNullOrEmpty(Nome) ? Nome.Substring(Nome.IndexOf(" ")).Trim() : string.Empty;
        }
    }

    public class BeneficiarioPessoaFisicaModel : BeneficiarioModel
    {
        [MinLength(11), MaxLength(11)] public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public BancoInfo? Banco { get; set; }

        public BeneficiarioPessoaFisicaModel() : base()
        {
           Banco = new BancoInfo();
        }
    }

    public class BeneficiarioPessoaJuridicaModel : BeneficiarioModel
    {
        [MinLength(14), MaxLength(18)] public string Cnpj { get; set; }
        public BeneficiarioProprietarioModel Proprietario { get; set; }
        public DateTime DataNascimento { get; set; }
        public BancoInfo? Banco { get; set; }

        public BeneficiarioPessoaJuridicaModel() : base()
        {
            Proprietario = new BeneficiarioProprietarioModel();
            Banco = new BancoInfo();
        }
    }

}

