using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Domain.Entities.Geral
{
    [Table("empreendimentopessoa", Schema = "geral")]
    public class EmpreendimentoPessoa
    {
        public int Id { get; set; }
        public int EmpreendimentoId { get; set; }
        public SCAE.Domain.Entities.Empreendimento.Empreendimento Empreendimento { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }


        public string Cargo { get; set; }

    }
}
