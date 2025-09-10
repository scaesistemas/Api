using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("remessa", Schema = "financeiro")]
    public class Remessa : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int NumeroSequencia { get; set; }
        public DateTime DataCriacao { get; set; }
        public int TipoId { get; set; }
        public TipoRemessa Tipo { get; set; }
        public ArquivoRemessaDocumento Documento { get; set; }
        public bool IsProcessado { get; set; }
        public int TipoCnab { get; set; }
        public ICollection<ReceitaTransacao> Transacoes { get; set; }

        public Remessa() 
        {
            Transacoes = new List<ReceitaTransacao>();
        }


    }
}
