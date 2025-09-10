using Microsoft.EntityFrameworkCore;


namespace SCAE.Domain.Entities.ControleAgua;

[Owned]
public class QualidadeAguaDocumento : Arquivo
{
    public string Descricao { get; set; }

}
