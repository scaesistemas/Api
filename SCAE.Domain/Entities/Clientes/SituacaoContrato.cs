
using SCAE.Domain.Entities.Financeiro;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Clientes
{
    [Table("situacaocontrato", Schema = "clientes")]
    public class SituacaoContrato : IEntity
    {
        
            [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)] 
            public int Id { get; set; }
            [StringLength(60), Required] public string Nome { get; set; }
            [NotMapped] public static SituacaoContrato EmAndamento => new SituacaoContrato(1, "Em andamento");
            [NotMapped] public static SituacaoContrato Cobranca => new SituacaoContrato(2, "Cobrança");
            [NotMapped] public static SituacaoContrato Juridico => new SituacaoContrato(3, "Jurídico");
            [NotMapped] public static SituacaoContrato Prejuizo => new SituacaoContrato(4, "Prejuízo");
            [NotMapped] public static SituacaoContrato Cancelado => new SituacaoContrato(5, "Cancelado");
            [NotMapped] public static SituacaoContrato Quitado => new SituacaoContrato(6, "Quitado");
            [NotMapped] public static SituacaoContrato Aditado => new SituacaoContrato(7, "Aditado");
            [NotMapped] public static SituacaoContrato ComProcesso => new SituacaoContrato(8, "Com processo");
            [NotMapped] public static SituacaoContrato PendenteAprovacao => new SituacaoContrato(9, "Pendente de aprovação");
            [NotMapped] public static SituacaoContrato PropostaDevolvida => new SituacaoContrato(10, "Proposta devolvida");



        public SituacaoContrato(int id, string nome)
            {
                Id = id;
                Nome = nome;
            }

            public static SituacaoContrato[] ObterDados()
            {
                return new SituacaoContrato[]
                {
                    EmAndamento,
                    Cobranca,
                    Juridico,
                    Prejuizo,
                    Cancelado,
                    Quitado,
                    Aditado,
                    ComProcesso,
                    PendenteAprovacao,
                    PropostaDevolvida
                };
            }

        public static SituacaoContrato ObterPorNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == nome.ToUpper());
        }

    }
}
