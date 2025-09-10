using System;
using System.Collections.Generic;

namespace SCAE.Domain.Models.Clientes
{
    public class ListarContratoModel
    {
        public List<ContratoItemModel> Items { get; set; }
        public long Count { get; set; }
    }

    public class ContratoItemModel
    {
        public int Id { get; set; }
        public string NumeroSequenciaContrato { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteId { get; set; }
        public int SituacaoId { get; set; }
        public string SituacaoNome { get; set; }
        public string TipoProduto { get; set; }
        public int EmpreendimentoId { get; set; }
        public string EmpreendimentoNome { get; set; }
        public string GrupoNome { get; set; }
        public string UnidadeNome { get; set; }
        public DateTime DataContrato { get; set; }
        public int DespesaId { get; set; }
        public int? ContratoAnteriorAditadoId { get; set; }
    }

}

