using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Entities.Geral
{
    [Owned]
    public class EmpresaDocumentoItem : Arquivo
    {
        [MaxLength(45)] public string CodigoZoop { get; set; }
        public string Descricao { get; set; }
    }
}
