using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Empreendimento
{
    [Table("grupo", Schema = "empreendimento")]
    public class Grupo : IEntity
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento Empreendimento { get; set; }
        [Required, MaxLength(60)] public string Nome { get; set; }
        public int? CodigoOrigem { get; set; }
        public int QuantidadeUnidade => Unidades?.Count ?? 0; 
        public ICollection<Unidade> Unidades { get; set; }

        //totais por tipo de unidade
        #region totaisPorSituacaoUnidade
        public int QuantidadeUnidadesVendido => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Vendido.Id) ?? 0;
        public int QuantidadeUnidadesDisponivel => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Disponivel.Id) ?? 0;
        public int QuantidadeUnidadesIndisponivel => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Indisponivel.Id) ?? 0;
        public int QuantidadeUnidadesReservado => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Reservado.Id) ?? 0;
        public int QuantidadeUnidadesInvadido => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Invadido.Id) ?? 0;
        public int QuantidadeUnidadesPenhorado => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Penhorado.Id) ?? 0;
        public int QuantidadeUnidadesCaucionado => Unidades?.Count(x => x.SituacaoId == SituacaoUnidade.Caucionado.Id) ?? 0;
        #endregion

        public Grupo()
        {
            Unidades = new List<Unidade>();
        }
    }
}
