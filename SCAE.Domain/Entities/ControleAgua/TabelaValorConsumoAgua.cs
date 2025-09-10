using SCAE.Domain.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.ControleAgua;

[Table("tabelavalorconsumoagua", Schema = "controleagua")]
public class TabelaValorConsumoAgua : IEntity
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public string Nome { get; set; }
    public bool IsPrincipal { get; set; }
    public ICollection<TabelaValorConsumoAguaItem> Itens { get; set; }

    public TabelaValorConsumoAgua()
    {
        Itens = new List<TabelaValorConsumoAguaItem>();
    }

}
