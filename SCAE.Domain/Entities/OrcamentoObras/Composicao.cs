using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("composicao", Schema = "orcamentoobras")]
    public class Composicao : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int UnidadeId { get; set; }
        public UnidadeMedida Unidade { get; private set; }
        public int ClasseId { get; set; }
        public ClasseComposicao Classe { get; private set; }
        public int TipoId { get; set; }
        public TipoComposicao Tipo { get; private set; }
        public int OrigemId { get; set; }
        public OrigemDados Origem { get; private set; }
        [Required] public InsumoEstado Estado { get; set; }
        public ICollection<ComposicaoItem> Itens { get; set; }
        public string Observacao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public decimal ValorDesonerado => Estado.valorDesonerado;
        public decimal ValorNaoDesonerado => Estado.ObterValorNaoDesonerado(12);
        
        // Se o front quiser
        //[NotMapped]
        //public Estado estado = null;
        //public InsumoEstadoValor EstadoValor => PropriedadeHelper.PegarPropriedadePorNome<InsumoEstado>(estado.Nome).GetValue(Estado) as InsumoEstadoValor;
        public Composicao()
        {
            Itens = new List<ComposicaoItem>();
            Estado = new InsumoEstado();
        }
    }
}
