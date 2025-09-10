using Newtonsoft.Json;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class SubContaModel
    {
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string CPFCNPJResponsavel { get; set; }
        public Endereco SubcontaEndereco { get; set; }
        public Responsavel? ResponsavelModel { get; set; }
    }

    public class Responsavel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string senha { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Endereco SubcontaResponsavelEndereco { get; set; }
    }

}
