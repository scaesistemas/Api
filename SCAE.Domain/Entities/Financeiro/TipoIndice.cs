using Microsoft.AspNetCore.SignalR;
using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SCAE.Domain.Entities.Financeiro
{
    [Table("tipoindice", Schema = "financeiro")]
    public class TipoIndice : IEntity
    {
        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [StringLength(60), Required] public string Nome { get; set; }
        [StringLength(60), Required] public string NomeEditavel { get; set; }
        public bool EdicaoBloqueada { get; set; }
        public bool Criado { get; set; }
        [NotMapped] public static TipoIndice IGPM => new TipoIndice(1, "IGP-M (FGV)", true, true);
        [NotMapped] public static TipoIndice INCC => new TipoIndice(3, "INCC (FGV)", true, true);
        [NotMapped] public static TipoIndice INPC => new TipoIndice(4, "INPC (IBGE)", true, true);
        [NotMapped] public static TipoIndice ParcelaFixa => new TipoIndice(5, "PARCELAS FIXAS", true, true);
        [NotMapped] public static TipoIndice SalarioMinimo => new TipoIndice(6, "SALÁRIO MÍNIMO", true, true);
        [NotMapped] public static TipoIndice UFIR => new TipoIndice(7, "UFIR", true, true);
        [NotMapped] public static TipoIndice IPCA => new TipoIndice(8, "IPCA", true, true);
        [NotMapped] public static TipoIndice Outro => new TipoIndice(9, "Outro", true, true);
        [NotMapped] public static TipoIndice NovoTipoIndice1 => new TipoIndice(10, "Novo Tipo Indice 1", false);
        [NotMapped] public static TipoIndice NovoTipoIndice2 => new TipoIndice(11, "Novo Tipo Indice 2", false);
        [NotMapped] public static TipoIndice NovoTipoIndice3 => new TipoIndice(12, "Novo Tipo Indice 3", false);
        [NotMapped] public static TipoIndice NovoTipoIndice4 => new TipoIndice(13, "Novo Tipo Indice 4", false);
        [NotMapped] public static TipoIndice NovoTipoIndice5 => new TipoIndice(14, "Novo Tipo Indice 5", false);
        [NotMapped] public static TipoIndice NovoTipoIndice6 => new TipoIndice(15, "Novo Tipo Indice 6", false);
        [NotMapped] public static TipoIndice NovoTipoIndice7 => new TipoIndice(16, "Novo Tipo Indice 7", false);


        public TipoIndice(int id, string nome, bool edicaoBloqueada, bool criado = false)
        {
            Id = id;
            Nome = nome;
            NomeEditavel = nome;
            EdicaoBloqueada = edicaoBloqueada;
            Criado = criado;
        }

        public static TipoIndice[] ObterDados()
        {
            return new TipoIndice[]
            {
                IGPM,
                INCC,
                INPC,
                ParcelaFixa,
                SalarioMinimo,
                UFIR,
                IPCA,
                Outro,
                NovoTipoIndice1,
                NovoTipoIndice2,
                NovoTipoIndice3,
                NovoTipoIndice4,
                NovoTipoIndice5,
                NovoTipoIndice6,
                NovoTipoIndice7,
            };
        }

        public static TipoIndice ObterPorNome(string indice)
        {
            if (string.IsNullOrEmpty(indice))
                return null;

            return ObterDados().SingleOrDefault(x => x.Nome.ToUpper() == indice.ToUpper());
        }
    }
}
