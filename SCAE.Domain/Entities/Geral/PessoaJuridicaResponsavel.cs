using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral
{
    public class PessoaJuridicaResponsavel
    {
        private Qualificacao _qualificacao;
        public Endereco Endereco;
        [StringLength(100)] public string Nome { get; set; }
        [StringLength(18)] public string CnpjCpf { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        [StringLength(15)] public string OrgaoExpedido { get; set; }
        [StringLength(15)] public string Telefone { get; set; }
        [StringLength(120)] public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataExpedicao { get; set; }
        public int? SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public Qualificacao Qualificacao
        {
            get
            {
                if (_qualificacao == null)
                {
                    _qualificacao = new Qualificacao();
                }
                return _qualificacao;
            }
            private set
            {
                _qualificacao = value;
            }
        }
  

        public PessoaJuridicaResponsavel()
        {
            Endereco = new Endereco();
        }
    }
}
