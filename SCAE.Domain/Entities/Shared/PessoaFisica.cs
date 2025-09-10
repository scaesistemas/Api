using SCAE.Framework.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Shared
{
    public class PessoaFisica
    {
        [MaxLength(14)] public string Cpf { get; set; }
        [MaxLength(120)] public string Nome { get; set; }
        [MaxLength(15)] public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }
        public string NomeDaMae { get; set; }

        public string TelefoneLimpo => StringHelper.LimparTelefone(Telefone);
        public string CpfLimpo => StringHelper.LimparCpfCnpj(Cpf);

        public PessoaFisica()
        {
            Endereco = new Endereco();
            NomeDaMae = "";
        }
    }
}
