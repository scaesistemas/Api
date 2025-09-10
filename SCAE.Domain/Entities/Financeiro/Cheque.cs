using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("cheque", Schema = "financeiro")]
    public class Cheque : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        //[Column("idCheque")] public int Id { get; set; }
        //[Column("idBanco")] public int BancoId { get; set; }
        //public string Agencia { get; set; }
        //public string ContaCorrente { get; set; }
        //public string ChequeNumero { get; set; }
        //public string Titular { get; set; }
        //[Column("CPF_CNPJ")] public string CpfCnpj { get; set; }
        //public string ClienteDesde { get; set; }
        //public string Origem { get; set; }
        //public DateTime DataCheque { get; set; }
        //public DateTime? DataCompensacao { get; set; }
        //public decimal Valor { get; set; }
        ////[JsonConverter(typeof(StringEnumConverter))] public EnumSituacaoCheque Situacao { get; set; }
        //[Column("idChequesDevolucao")] public int ChequeDevolucaoId { get; set; }
        //[Column("idContrato")] public int ContratoId { get; set; }
        //[Column("ContratoSeq")] public int ContratoSequencia { get; set; }
        //[Column("idCliente")] public int ClienteId { get; set; }
        ////public Pessoa Cliente { get; set; }
        //public string Observacao { get; set; }
        //public DateTime DataCadastro { get; set; }
        //public string Operador { get; set; }
        //public string OperadorUpDate { get; set; }
        //public DateTime DataUpDate { get; set; }
    }
}
