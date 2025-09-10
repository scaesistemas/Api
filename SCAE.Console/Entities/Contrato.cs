using SCAE.Domain.Entities.Clientes;
using SCAE.Domain.Entities.Financeiro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Migracao.Entities
{
    [Table("cl_contratos")]
    public class Contrato
    {
        [Column("idContrato"), Key] public int Id { get; set; }
        [Key] public int Sequencia { get; set; }
        public DateTime DataContrato { get; set; }
        public int DiaVencimento { get; set; }
        [Column("idEmpresa")] public int EmpresaId { get; set; }
        public int EmpresaId2 => ObterEmpresaId(EmpresaId);
        [Column("idLoteamento")] public int LoteamentoId { get; set; }
        [Column("idLote")] public int LoteId { get; set; }
        [Column("idCadastro")] public int? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        [Column("idClienteA")] public int? ClienteAId { get; set; }
        public Cliente ClienteA { get; set; }
        [Column("idClienteB")] public int? ClienteBId { get; set; }
        public Cliente ClienteB { get; set; }
        [Column("idCorretor")] public int? CorretorId { get; set; }
        public Cliente Corretor { get; set; }
        [Column("idConta")] public int? ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        [Column("VenctoParcelas")] public DateTime DataPrimeiraParcela { get; set; }
        [Column("QtdeParcela")] public int QuantidadeParcela { get; set; }
        [Column("VrParcela")] public decimal ValorParcela { get; set; }
        [NotMapped] public string NumeroProcesso { get; set; }
        [NotMapped] [Column("idSituacaoProcesso")] public int? SituacaoProcessoId { get; set; }
        public string Situacao { get; set; }
        public int SituacaoId => ObterSituacao(Situacao);
        public string TipoContrato { get; set; }
        public int TipoContratoId => ObterTipoContrato(TipoContrato);
        [Column("idIndice")] public int IndiceId { get; set; }
        public int TipoIndiceId => ObterIndice(IndiceId);
        public decimal ValorContrato => 0;//QuantidadeParcela * ValorContrato;

        public string Personalizado { get; set; }
        public bool IsPersonalizado => Personalizado == "Sim" || Personalizado == "on";
        public decimal JurosDia { get; set; }
        public decimal MultaMes { get; set; }
        public decimal Desconto { get; set; }
        public int DiasDesconto { get; set; }
        public decimal DescontoContrato { get; set; }
        public decimal DescontoAntecipacao { get; set; }

        public Contrato()
        {
            
        }

        private int ObterSituacao(string nome)
        {
            if (nome == "Cancelado")
                return SituacaoContrato.Cancelado.Id;

            if (nome == "Quitado")
                return SituacaoContrato.Quitado.Id;

            if (nome == "Aditado")
                return SituacaoContrato.Aditado.Id;

            if (nome == "Jurídico")
                return SituacaoContrato.Juridico.Id;

            if (nome == "Cobrança")
                return SituacaoContrato.Cobranca.Id;

            return SituacaoContrato.EmAndamento.Id;
        }

        private int ObterTipoContrato(string nome)
        {
            if (nome == "Venda de Terreno")
                return 1;

            if (nome == "Venda de Casa")
                return 2;

            if (nome == "Transferência")
                return 3;

            if (nome == "Acordo Comum")
                return 4;

            if (nome == "Acordo com Transferência")
                return 5;

            if (nome == "Acordo Medição")
                return 6;

            if (nome == "Acordo Judicial")
                return 7;

            if (nome == "Acordo com Possuidor")
                return 8;

            if (nome == "Aluguel - Aditamento")
                return 9;

            if (nome == "Aluguel - Novo")
                return 10;

            return SituacaoContrato.EmAndamento.Id;
        }

        private int ObterIndice(int indiceId)
        {
            switch (indiceId)
            {
                case 1:
                    return TipoIndice.SalarioMinimo.Id;
                case 2:
                    return TipoIndice.INPC.Id;
                case 5:
                    return TipoIndice.UFIR.Id;
                case 6:
                    return TipoIndice.IGPM.Id;
                case 12:
                    return TipoIndice.INCC.Id;
                //case 12:
                //    return TipoIndice.Selic.Id; //?
                default:
                    return TipoIndice.ParcelaFixa.Id;
            }
        }

        public int ObterEmpresaId(int id)
        {
            switch (id)
            {
                case 1:
                case 2:
                case 14:
                    return 1;
                case 19:
                    return 2;
                default:
                    return 0;
            }
        }
    }
}
