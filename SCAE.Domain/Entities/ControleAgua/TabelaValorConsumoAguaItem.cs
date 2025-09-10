using SCAE.Domain.Interfaces.Shared;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.ControleAgua;

[Table("tabelavalorconsumoaguaitem", Schema = "controleagua")]

public class TabelaValorConsumoAguaItem : IEntity
{
    public int Id { get; set; }
    public int TabelaId { get; set; }
    public TabelaValorConsumoAgua Tabela { get; set; }
    public string Nome { get; set; }
    public int FaixaConsumoInicial { get; set; }
    public int FaixaConsumoFinal { get; set; }
    public decimal Valor { get; set; }
    public bool IsValorFixo { get; set; }

}
