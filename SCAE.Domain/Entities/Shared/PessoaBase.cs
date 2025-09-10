using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Helper;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Shared
{
    public class PessoaBase : IEntity
    {
        public int Id { get; set; }
        public bool PessoaJuridica { get; set; }
        [MaxLength(18)] public string CpfCnpj { get; set; }
        [MaxLength(120), Required] public string Nome { get; set; }
        #region PJ
        [MaxLength(120)] public string NomeFantasia { get; set; }
        [MaxLength(15)] public string InscricaoEstadual { get; set; }
        [MaxLength(15)] public string InscricaoMunicipal { get; set; }
        #endregion
        [Required] public DateTime DataCriacao { get; set; }
        public Endereco Endereco { get; set; }
        [MaxLength(15)] public string Telefone1 { get; set; }
        [MaxLength(15)] public string Telefone2 { get; set; }
        [MaxLength(120)] public string Email { get; set; }
        public bool Ativo { get; set; }

        public string CpfCnpjLimpo => StringHelper.LimparCpfCnpj(CpfCnpj);
        public string CpfCnpjNome => $"{CpfCnpj} - {Nome}";
        public string TelefoneNome => $"{Telefone1} - {Nome}";

        public PessoaBase()
        {
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public PessoaBase(PessoaBase pessoa) : this()
        {
            Id = pessoa.Id;
            PessoaJuridica = pessoa.PessoaJuridica;
            CpfCnpj = pessoa.CpfCnpj;
            Nome = pessoa.Nome;
            NomeFantasia = pessoa.NomeFantasia;
            InscricaoEstadual = pessoa.InscricaoEstadual;
            InscricaoMunicipal = pessoa.InscricaoMunicipal;
            DataCriacao = pessoa.DataCriacao;
            Endereco = pessoa.Endereco;
            Telefone1 = pessoa.Telefone1;
            Telefone2 = pessoa.Telefone2;
            Email = pessoa.Email;
            Ativo = pessoa.Ativo;
        }
    }
}
