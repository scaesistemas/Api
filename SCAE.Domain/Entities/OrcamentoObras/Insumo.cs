using SCAE.Domain.Entities.Almoxarifado;
using SCAE.Domain.Interfaces.Shared;
using SCAE.Framework.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace SCAE.Domain.Entities.OrcamentoObras
{
    [Table("insumo", Schema = "orcamentoobras")]
    public class Insumo : IEntity
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int TipoId { get; set; }
        public TipoInsumo Tipo { get; private set; }
        public int UnidadeId { get; set; }
        public UnidadeMedida Unidade { get; private set; }
        public int OrigemId { get; set; }
        public OrigemDados Origem { get; private set; }
        [Required]public InsumoEstado Estado { get; set; }
        public string Observacao { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        
        public Insumo()
        {
            Estado = new InsumoEstado();
        }

        public static PropertyInfo PegarPropriedadePorNome<T>(string nome, bool primeiraMaiuscula = true)
        {
            if (nome != null)
            {
                var nomePropriedade = StringHelper.PadronizarPrimeiraMaiuscula(StringHelper.RemoverAcentos(nome), primeiraMaiuscula, false);
                return typeof(T).GetProperty(nomePropriedade);
            }
            else
            {
                return null;
            }
        }

    }
}
