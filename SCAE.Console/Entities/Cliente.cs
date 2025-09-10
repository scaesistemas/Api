using Microsoft.EntityFrameworkCore;
using SCAE.Framework.Helper;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_cadastros")]
    public class Cliente
    {
        [Column("idCadastro")] public int Id { get; set; }
        public string Nome { get; set; }
        [Column("CPF_CNPJ")] public string CpfCnpj { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        public string Rg { get; set; }
        public string OrgaoExp { get; set; }
        public DateTime? DataExp { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string TipoPessoa { get; set; }
        public string TipoCliente { get; set; }
        public string TipoCorretor { get; set; }
        public bool IsCliente => TipoCliente == "Sim";
        public bool IsCorretor => TipoCorretor == "Sim";
        public Conjuge Conjuge { get; set; }

        public string CpfCnpjFormatado => StringHelper.FormataCpfCnpj(CpfCnpj);
        public string CepFormatado => StringHelper.FormataCep(Cep);
    }

    [Owned]
    public class Conjuge
    {
        [Column("Conjuge")] public string Nome { get; set; }
        [Column("CPFConjuge")] public string Cpf { get; set; }
        //public string Cep { get; set; }
        //public string Endereco { get; set; }
        //public string Numero { get; set; }
        //public string Complemento { get; set; }
        //public string Bairro { get; set; }
        //public string UF { get; set; }
        //public string Cidade { get; set; }
        //public string Email { get; set; }
        //public string Telefone1 { get; set; }
        //public string Telefone2 { get; set; }
        //public string Telefone3 { get; set; }
        [Column("RGConjuge")] public string Rg { get; set; }
        [Column("OrgaoExpCJ")] public string OrgaoExp { get; set; }
        //public DateTime? DataExp { get; set; }
        [Column("DataNascConjuge")] public DateTime? DataNascimento { get; set; }

        public string CpfFormatado => StringHelper.FormataCpfCnpj(Cpf);
    }
}
