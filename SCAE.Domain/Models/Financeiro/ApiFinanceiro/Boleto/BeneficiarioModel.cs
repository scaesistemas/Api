using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;

namespace SCAE.Financeiro.Api.Models.Boleto.Shared
{
    public class BeneficiarioModel
    {
        public string Codigo { get; set; }
        public string CodigoDigito { get; set; }
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string Conta { get; set; }
        public string ContaDigito { get; set; }
        public string Carteira { get; set; }
        public string CarteiraDigito { get; set; }

        public EnderecoModel Endereco { get; set; }

        public BeneficiarioModel()
        {
            Endereco = new EnderecoModel();
            AgenciaDigito = "0";
        }
    }
}
