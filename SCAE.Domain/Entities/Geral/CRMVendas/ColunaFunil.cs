using SCAE.Domain.Entities.Empreendimento;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.Geral.CRMVendas
{
    [Table("colunafunil", Schema = "geral")]
    public class ColunaFunil : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Posicao { get; set; }
        public ColunaFunil ColunaFunilPai { get; set; }
        public int? ColunaFunilPaiId { get; set; }

        public ICollection<Lead> Leads { get; set; }
        public ICollection<Reserva> Reservas { get; set; }

        [NotMapped]
        public List<ColunaFunil> Children { get; set; }

        public bool Ativo {  get; set; }

        public ColunaFunil()
        {
            Leads = new List<Lead>();
        }
    }
}
