using SCAE.Domain.Entities.Empreendimento;
using SCAE.Framework.Helper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace SCAE.Migracao.Entities
{
    [Table("cl_lotes")]
    public class Lote
    {
        [Column("idLote")] public int Id { get; set; }
        [Column("idQuadra")] public int QuadraId { get; set; }
        [Column("CodigoLote")] public string Codigo { get; set; }
        [Column("SituacaoLote")] public string Situacao { get; set; }
        public int SituacaoId => ObterSituacao(Situacao);
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string CepFormatado => StringHelper.FormataCep(Cep);

        [Column("DimFrente")] public string DimensaoFrente { get; set; }
        [Column("DimFundos")] public string DimensaoFundos { get; set; }
        [Column("DimLadoEsquerdo")] public string DimensaoEsquerdo { get; set; }
        [Column("DimLadoDireito")] public string DimensaoDireito { get; set; }
        [Column("DimCurva")] public string DimensaoCurva { get; set; }

        private int ObterSituacao(string nome)
        {
            if (nome == "Vendido" || nome == "Quitado")
                return SituacaoUnidade.Vendido.Id;

            if (nome == "Disponível")
                return SituacaoUnidade.Disponivel.Id;

            if (nome == "Indisponível")
                return SituacaoUnidade.Indisponivel.Id;

            if (nome == "Reservado")
                return SituacaoUnidade.Reservado.Id;

            if (nome == "Penhorado")
                return SituacaoUnidade.Penhorado.Id;

            if (nome == "Invadido")
                return SituacaoUnidade.Invadido.Id;

            return SituacaoUnidade.Disponivel.Id;
        }
    }
}
