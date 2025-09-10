using SCAE.Domain.Entities.Geral;
using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain
{
    public class Conjuge
    {

        private Qualificacao _qualificacao;
        [StringLength(14)]       
        public string Cpf { get; set; }
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(15)] public string Rg { get; set; }
        public DateTime? DataEmissaoRg { get; set; }
        [StringLength(15)] public string OrgaoExpedidor { get; set; }
        [StringLength(100)] public string NomePai { get; set; }
        [StringLength(100)] public string NomeMae { get; set; }
        //public Qualificacao Qualificacao { get; set; }
        public decimal? RendaBruta { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Dependente { get; set; }
        public int? SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public string? Telefone { get; set; }

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

        public Conjuge() 
        { 
           //Qualificacao = new Qualificacao();
        }
    }
}
