using System;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral
{
    public class ExcelContratoModel
    {
        [Required(ErrorMessage = "O valor do campo Numero do contrato é obrigatório")]
        //public int NumeroContrato { get; set; }
        public string NumeroContrato { get; set; }
        public int Numero { get; set; }
        public int Sequencia { get; set; }
        [StringLength(18, ErrorMessage = "O valor do campo empresa Cnpj ultrapassou o limite de 18 caracteres"), Required(ErrorMessage = "O campo cnpj é obrigatório")]
        public string EmpresaCNPJ { get; set; }
        public string SituacaoContrato { get; set; }
        public string TipoAditamentoContrato { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo primeiro cliente Cpf/Cnpj ultrapassou o limite de 18 caracteres"), Required(ErrorMessage = "O campo primeiro cliente Cpf/Cnpj é obrigatório")]
        public string PrimeiroClienteCpfCnpj { get; set; }
        public string SegundoClienteCpfCnpj { get; set; }
        public string TerceiroClienteCpfCnpj { get; set; }

        [StringLength(18, ErrorMessage = "O valor do campo primeiro corretor Cpf/Cnpj ultrapassou o limite de 18 caracteres"), Required(ErrorMessage = "O campo primeiro corretor Cpf/Cnpj é obrigatório")]
        public string PrimeiroCorretorCpfCnpj { get; set; }
        public decimal PrimeiroCorretorPercentual { get; set; }
        public string SegundoCorretorCpfCnpj { get; set; }
        public decimal SegundoCorretorPercentual { get; set; }
        public string TerceiroCorretorCpfCnpj { get; set; }
        public decimal TerceiroCorretorPercentual{ get; set; }

        [Required(ErrorMessage = "O valor do campo Id da unidade do contrato é obrigatório")]
        public int UnidadeId { get; set; }

        [Required(ErrorMessage = "O valor do campo Data do contrato é obrigatório")]
        public DateTime DataContrato { get; set; }

        [Required(ErrorMessage = "O valor do campo Indice é obrigatório")]
        public string Indice { get; set; }

        [Required(ErrorMessage = "O valor do campo intervalo de reajuste é obrigatório")]
        public string IntervaloReajuste { get; set; }

        [Required(ErrorMessage = "O valor do campo mes é obrigatório")]
        public string MesReajuste { get; set; }

        [Required(ErrorMessage = "O valor do campo Ano do primeiro reajuste é obrigatório")]
        public int AnoPrimeiroReajuste { get; set; }

        [Required(ErrorMessage = "O valor do campo tabela é obrigatório")]
        public string Tabela { get; set; }
        public decimal JurosPrice { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public decimal JurosDia { get; set; }
        public decimal Multa { get; set; }
        public decimal DescontoVencimento { get; set; }
        public int DiasDescontoVencimento { get; set; }
        public decimal DescontoAntecipacao { get; set; }
        public int DiasAposVencimentoNaoReceber { get; set; }
        

    }
}
