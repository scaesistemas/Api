using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Financeiro.PlanoDePagamento;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Entities.Shared;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("unidade", Schema = "empreendimento")]
    public class Unidade : IEntity
    {
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public Grupo Grupo { get; set; }

        [MaxLength(15)] public string Codigo { get; set; }
        [MaxLength(150), Required] public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public Imovel Imovel { get; set; }
        public Jazigo Jazigo { get; set; }
        public Lote Lote { get; set; }
        public int SituacaoId { get; set; }
        public SituacaoUnidade Situacao { get; set; }
        public int TipoId { get; set; }
        public TipoUnidade Tipo { get; set; }
        public string DestinoLixo { get; set; }
        public string EnergiaEletrica { get; set; }
        public string Iptu { get; set; }
        public string FormaAquisicaoUnidade { get; set; }
        public string Edificacao { get; set; }
        public bool RegularizacaoFundiaria { get; set; }
        public string AbastecimentoAgua { get; set; }
        public string EscoamentoSanitario { get; set; }
        public int Ocupacoes { get; set; }
        public string Descricao { get; set; }
        public int? ConstrutoraId { get; set; }
        public Pessoa Construtora { get; set; }
        public int? AdministradoraId { get; set; }
        public Pessoa Administradora { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal TaxaAdmMensal { get; set; }
        public decimal ValorIndicacao { get; set; }
        public decimal PercentualIndicacao { get; set; }
        public DisponibilidadeOperaoUnidade DisponibilidadeOperacao { get; set; }
        public MapaCoordenada MapaCoordenada { get; set; }
        public LegalizacaoUnidade Legalizacao { get; set; }
        public ConfrontanteUnidade Confrontante { get; set; }
        public ICollection<ConfrontanteAdicional> ConfrontantesAdicionais { get; set; }
        public int? CodigoOrigem { get; set; }
        public string KmlId { get; set; }
        public PlanoPagamentoUnidade PlanoPagamento { get; set; }
        public int? ModeloPlanoPagamentoId { get; set; }
        public PlanoPagamentoModelo ModeloPlanoPagamento { get; set; }
        public bool AtualizarComPlanoPagamentoModelo { get; set; }
        public decimal ValorTotalUnidade => CalculoValorTotalPlanoPagamento();
        public decimal ValorEntradaPlanoPagamento => CalculoValorReceitaPlanoPagamento(PlanoPagamento?.Entrada ?? null);
        public decimal ValorIntermediariaPlanoPagamento => CalculoValorReceitaPlanoPagamento(PlanoPagamento?.Intermediaria ?? null);
        public decimal ValorFinanciamentoPlanoPagamento => CalculoFinanciamentoPlanoPagamento();




        public ICollection<UnidadeFoto> Fotos { get; set; }
        public ICollection<UnidadeProprietario> Proprietarios { get; set; }
        public ICollection<UnidadeVicio> Vicios { get; set; }
        public ICollection<Reserva> Reservas { get; set; }


        public Unidade()
        {
            Endereco = new Endereco();
            SituacaoId = SituacaoUnidade.Disponivel.Id;
            Reservas = new List<Reserva>();
            Confrontante = new ConfrontanteUnidade();
        }

        private decimal CalculoValorTotalPlanoPagamento()
        {
            if (PlanoPagamento == null)
                return 0;

            if (PlanoPagamento.TipoValorTotalId == TipoPlanoPagamento.ValorFixo.Id)
                return PlanoPagamento.ValorUnidade;

            if (Lote != null)
                return Lote.Dimensao.AreaTotal * PlanoPagamento.ValorMetroQuadrado;

            if (Imovel != null)
                return Imovel.Infraestrutura.Dimensao.AreaTerreno * PlanoPagamento.ValorMetroQuadrado;

            return 0;
        }

        private decimal CalculoValorReceitaPlanoPagamento(ReceitaPlanoPagamento receitaPlanoPagamento)
        {
            if (receitaPlanoPagamento == null)
                return 0;

            if (receitaPlanoPagamento.TipoId == TipoPlanoPagamento.ValorFixo.Id)
                return receitaPlanoPagamento.Valor;

            if (receitaPlanoPagamento.TipoId == TipoPlanoPagamento.PercentualValorTotal.Id)
                return (receitaPlanoPagamento.PorcentagemValorTotal * ValorTotalUnidade) / 100;

            return 0;
        }
        private decimal CalculoFinanciamentoPlanoPagamento()
        {
            return (ValorTotalUnidade - ValorEntradaPlanoPagamento - ValorIntermediariaPlanoPagamento) > 0 ? ValorTotalUnidade - ValorEntradaPlanoPagamento - ValorIntermediariaPlanoPagamento : 0;
        }
    }

    [Owned]
    public class DisponibilidadeOperaoUnidade
    {
        public bool Venda { get; set; }
        public bool Locacao { get; set; }
    }

    [Owned]
    public class MapaCoordenada
    {
        public decimal? X { get; set; }
        public decimal? Y { get; set; }
        public int? ZoomStep { get; set; }
    }

    public class LegalizacaoUnidade : Legalizacao
    {
    }

    [Owned]
    public class ConfrontanteUnidade
    {
        public string FrenteNome { get; set; }
        public decimal Frente { get; set; }
        public string FundoNome { get; set; }
        public decimal Fundo { get; set; }
        public string LadoEsquerdoNome { get; set; }
        public decimal LadoEsquerdo { get; set; }
        public string LadoDireitoNome { get; set; }
        public decimal LadoDireito { get; set; }

        public ConfrontanteUnidade()
        {

        }

    }

    public class ComparadorUnidade : IEqualityComparer<Unidade>
    {
        public bool Equals(Unidade x, Unidade y)
        {
            // Compara se os Ids são iguais
            return x != null && y != null && x.Id == y.Id;
        }

        public int GetHashCode(Unidade obj)
        {
            // Utiliza o Id para gerar o código hash
            return obj.Id.GetHashCode();
        }
    }
}
