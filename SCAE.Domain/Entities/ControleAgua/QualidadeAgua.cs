using Microsoft.EntityFrameworkCore;
using SCAE.Domain.Entities.Geral;
using SCAE.Domain.Interfaces.Shared;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SCAE.Domain.Entities.ControleAgua;

[Table("qualidadeagua", Schema = "controleagua")]
public class QualidadeAgua : IEntity
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }
    public DadosAgua MaximoExigido { get; set; }
    public DadosAgua AmostraRealizada { get; set; }
    public QualidadeAguaDocumento Documento { get; set; }
    public int? UsuarioId { get; set; }
    public Usuario Usuario { get; set; }

}

[Owned]
public class DadosAgua
{
    public decimal Turbidez { get; set; }
    public decimal Cor { get; set; }
    public decimal Cloro { get; set; }
    public decimal PH { get; set; }
    public decimal Fluoreto { get; set; }

}




