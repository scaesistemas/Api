using System;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Shared
{
    public class SubcontaScaeModel
    {
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPFCNPJResponsavel { get; set; }
        public EnderecoModel SubcontaEndereco { get; set; }
        public ResponsavelModel? ResponsavelModel { get; set; }
    }
    public class ResponsavelModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string senha { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public EnderecoModel SubcontaResponsavelEndereco { get; set; }
    }
}