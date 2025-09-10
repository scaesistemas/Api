using SCAE.Domain.Interfaces.Shared;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using SCAE.Framework.Helper;

namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("motivocancelamentoreserva", Schema = "geral")]
    public class MotivoCancelamentoReserva : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(60), Required] public string Nome { get; set; }

        [NotMapped] public static MotivoCancelamentoReserva NaoInformado => new(1, "Não informado");
        [NotMapped] public static MotivoCancelamentoReserva Vendido => new(2, "Imóvel vendido");
        [NotMapped] public static MotivoCancelamentoReserva Caro => new(3, "Achou caro");
        [NotMapped] public static MotivoCancelamentoReserva ValorParcelaAlta => new(4, "Valor da parcela alta");
        [NotMapped] public static MotivoCancelamentoReserva ValorEntradaAlta => new(5, "Valor da entrada alta");
        [NotMapped] public static MotivoCancelamentoReserva TaxaJurosAlta => new(6, "Taxa de juros alta");
        [NotMapped] public static MotivoCancelamentoReserva EntradaEParcelaAlta => new(7, "Entrada e parcela alta");
        [NotMapped] public static MotivoCancelamentoReserva PropostaRecusada => new(8, "Proposta recusada");
        [NotMapped] public static MotivoCancelamentoReserva NaoDeuRetorno => new(9, "Não deu retorno");
        [NotMapped] public static MotivoCancelamentoReserva ComprouEmOutroLocal => new(10, "Comprou em outro local (Concorrente)");
        [NotMapped] public static MotivoCancelamentoReserva ComprouOutroImovel => new(11, "Comprou outro imovel");
        [NotMapped] public static MotivoCancelamentoReserva CondominioLoteamentoFechado => new(12, "Por ser condomínio ou loteamento fechado");
        [NotMapped] public static MotivoCancelamentoReserva ObrasNaoConcluidas => new(13, "Obras não concluídas");
        [NotMapped] public static MotivoCancelamentoReserva DimensaoImovel => new(14, "Dimensões do imóvel");
        [NotMapped] public static MotivoCancelamentoReserva LocalizacaoImovel => new(15, "Localização do imóvel");
        [NotMapped] public static MotivoCancelamentoReserva TopografiaImovel => new(16, "Topografia do imóvel");
        [NotMapped] public static MotivoCancelamentoReserva NaoConseguiuFinanciar => new(17, "Não conseguiu financiar");
        [NotMapped] public static MotivoCancelamentoReserva NaoEnquadrouMCMV => new(18, "Não enquadrou no MCMV");
        [NotMapped] public static MotivoCancelamentoReserva SemOfertaImovel => new(19, "Sem oferta do imóvel");
        [NotMapped] public static MotivoCancelamentoReserva VendasNaoIniciadas => new(20, "Vendas não Iniciadas");
        [NotMapped] public static MotivoCancelamentoReserva OutrosMotivos => new(21, "Outros motivos");
        [NotMapped] public static MotivoCancelamentoReserva InteresseLoteComercial => new(22, "Interesse em lote comercial");
        [NotMapped] public static MotivoCancelamentoReserva SemInteresseCompra => new(23, "Sem interesse na compra");
        [NotMapped] public static MotivoCancelamentoReserva Expirado => new(24, "Expirado");




        public MotivoCancelamentoReserva()
        {

        }
        public MotivoCancelamentoReserva(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static MotivoCancelamentoReserva[] ObterDados()
        {
            return new MotivoCancelamentoReserva[]
            {
                NaoInformado,
                Vendido,
                Caro,
                ValorParcelaAlta,
                ValorEntradaAlta,
                TaxaJurosAlta,
                EntradaEParcelaAlta,
                PropostaRecusada,
                NaoDeuRetorno,
                ComprouEmOutroLocal,
                ComprouOutroImovel,
                CondominioLoteamentoFechado,
                ObrasNaoConcluidas,
                DimensaoImovel,
                LocalizacaoImovel,
                TopografiaImovel,
                NaoConseguiuFinanciar,
                NaoEnquadrouMCMV,
                SemOfertaImovel,
                VendasNaoIniciadas,
                OutrosMotivos,
                InteresseLoteComercial,
                SemInteresseCompra,
                Expirado
            };
        }

        public static List<MotivoCancelamentoReserva> ObterDadosOrdenados()
        {
            return ObterDados()
                    .OrderBy(x => TreeViewHelper.PadNumbers(x.Nome)).ToList();
        }


    }
}
