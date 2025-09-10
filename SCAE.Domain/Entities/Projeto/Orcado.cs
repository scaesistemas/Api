using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCAE.Domain.Entities.Projeto
{
    [Table("orcado", Schema = "projeto")]
    public class Orcado : IEntity
    {
        public int Id { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpreendimentoId { get; set; }
        public Empreendimento.Empreendimento Empreendimento { get; set; }
        public ICollection<OrcadoItem> Itens { get; set; }

        public Orcado()
        {
            Itens = new List<OrcadoItem>();
        }
    }
}
