using SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared;

namespace SCAE.Financeiro.Api.Models.Boleto.Shared
{
    public class PagadorModel
    {
        public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public EnderecoModel Endereco { get; set; }

        public PagadorModel()
        {
            Endereco = new EnderecoModel();
        }
    }
}

