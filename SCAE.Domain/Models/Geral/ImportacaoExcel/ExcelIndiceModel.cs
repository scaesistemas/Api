using System.ComponentModel.DataAnnotations;

namespace SCAE.Domain.Models.Geral.ImportacaoExcel
{
    public class ExcelIndiceModel
    {
        [Required(ErrorMessage = "O valor do campo Indice é obrigatório")]
        public string Indice { get; set; }

        [Required(ErrorMessage = "O valor do campo Dia é obrigatório")]
        public int Dia { get; set; }

        [Required(ErrorMessage = "O valor do campo Mes é obrigatório")]
        public int Mes { get; set; }

        [Required(ErrorMessage = "O valor do campo Ano é obrigatório")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O valor do campo IndiceMensal é obrigatório")]
        public decimal IndiceMensal { get; set; }

        [Required(ErrorMessage = "O valor do campo Acumulado é obrigatório")]
        public decimal Acumulado { get; set; }

        public decimal Avulso { get; set; }

        [Required(ErrorMessage = "O valor do campo AplicarNegativo é obrigatório")]
        public string AplicarNegativo { get; set; }
    }
}
