namespace SCAE.Domain.Models.Financeiro.ApiFinanceiro.Banco
{
    public class RetornoModel
    {
        public string PDFBoleto { get; set; }
        public string QrCode { get; set; }
        public string LinhaDigitavel { get; set; }
        public string NossoNumero { get; set; }
        public string CodigoBarra { get; set; }

        public RetornoModel()
        {

        }
        public RetornoModel(string pdfBoleto, string qrCode, string nossoNumero, string codigoBarra)
        {
            PDFBoleto = pdfBoleto;
            QrCode = qrCode;
            NossoNumero = nossoNumero;
            CodigoBarra = codigoBarra;
        }

        public RetornoModel(string pdfBoleto, string qrCode, string linhaDigitavel, string nossoNumero, string codigoBarra) : this(pdfBoleto, qrCode, nossoNumero, codigoBarra)
        {
            LinhaDigitavel = linhaDigitavel;
        }
    }
}
