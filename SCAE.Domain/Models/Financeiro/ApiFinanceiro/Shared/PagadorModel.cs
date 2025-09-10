using SCAE.Framework.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared
{
    public class PagadorModel
    {
        public string Codigo { get; set; }
        [MinLength(11), MaxLength(18)] public string CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EnderecoModel Endereco { get; set; }
        public DateTime DataNascimento {get; set;}
        public BancoInfo? banco {get; set;}

        public PagadorModel()
        {
            Endereco = new EnderecoModel();
        }

        public string CpfCnpjLimpo()
        {
            return StringHelper.LimparCpfCnpj(CpfCnpj);
        }

        
    }
    public class BancoInfo{
            public string Agencia { get; set; }
            public string NumeroConta { get; set; }
            public string CodigoBanco { get; set; }
            public string ChavePix { get; set; }
        }

}



