using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class ContaBancariaModel
    {
        public string Codigo { get; set; }
        public int CodigoBanco { get; set; }
        public string Titular { get; set; }
        [MinLength(11), MaxLength(11)] public string? Cpf { get; set; }
        [MinLength(14), MaxLength(14)] public string? Cnpj { get; set; }
        public string Agencia { get; set; }
        public string? DigitoAgencia { get; set; }
        public string Conta { get; set; }
        public string DigitoConta { get; set; }
        public bool Poupanca { get; set; }

        public ContaBancariaModel()
        {
            Poupanca = false;
        }
    }

}
