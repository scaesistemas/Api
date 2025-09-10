namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Gateway
{
    public class RetornoModel
    {
        public string Codigo { get; set; }
        public string Url { get; set; }
        public string LinhaDigitavel { get; set; }
        public string ReferenceIdBoleto {get; set;}

        public RetornoModel(string codigo, string url, string linhaDigitavel, string referenceIdBoleto = "")
        {
            Codigo = codigo;
            Url = url;
            LinhaDigitavel = linhaDigitavel;
            ReferenceIdBoleto = referenceIdBoleto;
        }

    }
}
