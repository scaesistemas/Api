using System;
using ZXing;
using ZXing.Common;
using QRCoder;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using PdfSharpCore.Drawing;
using System.IO;
using PdfSharpCore.Pdf;
using PdfSharpCore.Fonts;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Linq;

namespace SCAE.Service.Services.Boleto
{
    public class BoletoGenerator
    {
        public class MeuFontResolver : IFontResolver
        {
            string IFontResolver.DefaultFontName => null;
            public byte[] GetFont(string faceName)
            {

                var path = Path.Combine(AppContext.BaseDirectory, "Fonts");
                if (faceName == "Helvetica#")
                {
                    // Altere o caminho para onde está seu arquivo TTF
                    return File.ReadAllBytes(Path.Combine(path, "Helvetica.ttf"));
                }
                // else if (faceName == "CourierNew#")
                // {
                //     var fontPath = Path.Combine("Fonts", "cour.ttf");
                //     // Altere o caminho para onde está seu arquivo TTF
                //      return File.ReadAllBytes(Path.Combine(path, "cour.ttf"));
                // }

                throw new InvalidOperationException("Fonte não encontrada: " + faceName);
            }

            public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
            {
                if (familyName.Equals("Helvetica", StringComparison.OrdinalIgnoreCase))
                {
                    return new FontResolverInfo("Helvetica#");
                }
                if (familyName.Equals("Courier New", StringComparison.OrdinalIgnoreCase))
                {
                    return new FontResolverInfo("CourierNew#");
                }

                return null;
            }
        }

        public byte[] ConverterPdfParaBytes(PdfDocument documento)
        {
            using (var stream = new MemoryStream())
            {
                documento.Save(stream, false);
                return stream.ToArray();
            }
        }

        public string ConvertValueInString(decimal value)
        {
            CultureInfo cultureBR = new CultureInfo("pt-BR");
            string strValue = value.ToString("C", cultureBR);  // R$ 1.234,56
            return strValue;
        }

        public byte[] GenerateCarneBoletosPdf(List<BoletoData> boletos, bool gerarComMultaJuros)
        {
            var document = new PdfDocument();
            var boletosPorPagina = 3;
            var totalPages = (int)Math.Ceiling((double)boletos.Count / boletosPorPagina);

            for (int p = 0; p < totalPages; p++)
            {
                var page = document.AddPage();
                page.Size = PdfSharpCore.PageSize.A4;
                var gfx = XGraphics.FromPdfPage(page);

                var offsetsY = new[] { 30, 290, 550 };
                var offsetX = 150;

                for (int j = 0; j < boletosPorPagina; j++)
                {
                    int index = p * boletosPorPagina + j;
                    if (index < boletos.Count)
                    {
                        DrawBoleto(gfx, boletos[index], offsetsY[j], offsetX, gerarComMultaJuros);
                    }
                }
            }

            using (var stream = new MemoryStream())
            {
                document.Save(stream, false);
                return stream.ToArray();
            }
        }

        public string convertDigitablelLineForBarcode(string DigitablelLine)
        {
            string linha = DigitablelLine.Replace(".", "").Replace(" ", "");

            if (linha.Length != 47)
                throw new ArgumentException("A linha digitável deve conter exatamente 47 dígitos.");

            string campo1 = linha.Substring(0, 3);
            string campo2 = linha.Substring(3, 1);
            string campo3 = linha.Substring(4, 5);
            string campo4 = linha.Substring(10, 6);
            string campo5 = linha.Substring(16, 4);
            string campo6 = linha.Substring(21, 10);
            string campo7 = linha.Substring(32, 15);

            string codigoBarras = campo1 + campo2 + campo7 + campo3 + campo4 + campo5 + campo6;

            return codigoBarras;
        }

        private void DrawBoleto(XGraphics gfx, BoletoData data, double offsetY, double offsetX, bool gerarComMultaJuros)
        {
            var penBlack = new XPen(XColors.Black, 0.5);
            var fontText = new XFont("Helvetica", 7, XFontStyle.Regular);
            var fontTextLight = new XFont("Helvetica", 8, XFontStyle.Regular);
            var instructionsFont = new XFont("Helvetica", 6, XFontStyle.Regular);
            var fontTextTitle = new XFont("Helvetica", 12, XFontStyle.Bold);
            var fontTextRegular = new XFont("Helvetica", 9, XFontStyle.Regular);
            var fontTextCode = new XFont("Helvetica", 9, XFontStyle.Bold);

            var zokilogo = XImage.FromFile(data.ZokiLogoPath);
            gfx.DrawImage(zokilogo, 50, offsetY + 10, 60, 20);

            gfx.DrawString("Vencimento", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 42));
            gfx.DrawString($"{data.Vencimento:dd/MM/yyyy}", fontTextCode, XBrushes.Black, new XPoint(80, offsetY + 42));
            gfx.DrawString("Agência/Conta", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 58));
            gfx.DrawString($"{data.Agency}/{data.Account}", fontTextCode, XBrushes.Black, new XPoint(30, offsetY + 70));
            gfx.DrawString("Nosso Número:", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 85));
            gfx.DrawString($"{data.ZokiCode}", fontTextCode, XBrushes.Black, new XPoint(30, offsetY + 97));
            gfx.DrawString("Parcela N°:", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 120));
            gfx.DrawString($"{data.InstallmentNumber}", fontTextCode, XBrushes.Black, new XPoint(80, offsetY + 120));
            gfx.DrawString($"(=) Valor", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 145));
            gfx.DrawString($"{ConvertValueInString(data.Value)}", fontTextCode, XBrushes.Black, new XPoint(80, offsetY + 145));

            string cedenteMin = data.Cedente;
            if (cedenteMin.Length > 38)
            {
                cedenteMin = cedenteMin.Substring(0, 38);
            }

            cedenteMin = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cedenteMin.ToLower());

            string addressMin = data.CedenteAddress;
            if (addressMin.Length > 38)
            {
                addressMin = addressMin.Substring(0, 30);
            }

            addressMin = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cedenteMin.ToLower());

            gfx.DrawString($"{cedenteMin}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 165));
            gfx.DrawString($"CNPJ: {data.CedenteDocument}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 175));
            gfx.DrawString($"{addressMin}, {data.CedenteNumber}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 185));
            gfx.DrawString($"{data.CedenteBairro}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 195));
            gfx.DrawString($"{data.CedenteCity}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 205));
            gfx.DrawString($"{data.CedenteState} - {data.SacadoCep}", instructionsFont, XBrushes.Black, new XPoint(30, offsetY + 215));

            byte[] imageBytesLogoBank = Convert.FromBase64String(data.BankLogoPath);
            string tempPathLogoBank = Path.GetTempFileName();
            File.WriteAllBytes(tempPathLogoBank, imageBytesLogoBank);
            var banklogo = XImage.FromFile(tempPathLogoBank);

            gfx.DrawImage(banklogo, offsetX, offsetY + 10, 60, 20);
            gfx.DrawString($"{data.BankCode}-{data.CodeCoin}", fontTextTitle, XBrushes.Black, new XPoint(offsetX + 70, offsetY + 29));
            gfx.DrawString($"{data.DigitablelLine}", fontTextRegular, XBrushes.Black, new XPoint(offsetX + 156, offsetY + 29));

            gfx.DrawString("Local de pagamento: ", fontTextLight, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 42));
            gfx.DrawString($"Pagar preferencialmente no Banco {data.BankName}", fontText, XBrushes.Black, new XPoint(offsetX + 80, offsetY + 42));

            gfx.DrawString($"{data.Cedente} - {data.CedenteDocument}", fontText, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 58));
            gfx.DrawString($"{data.CedenteAddress}, {data.CedenteNumber} - {data.CedenteBairro} - {data.CedenteCity} - {data.CedenteState}  - {data.CedenteCep}", fontText, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 70));

            gfx.DrawString("Data Doc: ", fontTextLight, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 85));
            gfx.DrawString($"{data.DocDate:dd/MM/yyyy}", fontText, XBrushes.Black, new XPoint(offsetX + 42, offsetY + 85));

            gfx.DrawString("Doc Nº:", fontTextLight, XBrushes.Black, new XPoint(offsetX + 150, offsetY + 85));
            gfx.DrawString($"{data.DocCode}", fontText, XBrushes.Black, new XPoint(offsetX + 182, offsetY + 85));

            gfx.DrawString("Nosso Nº:", fontTextLight, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 100));
            gfx.DrawString($"{data.ZokiCode}", fontText, XBrushes.Black, new XPoint(offsetX + 42, offsetY + 100));

            gfx.DrawString("Vencimento:", fontTextLight, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 120));
            gfx.DrawString($"{data.Vencimento:dd/MM/yyyy}", fontTextRegular, XBrushes.Black, new XPoint(offsetX + 50, offsetY + 120));

            gfx.DrawString("Valor:", fontTextLight, XBrushes.Black, new XPoint(offsetX + 150, offsetY + 120));
            gfx.DrawString($"{ConvertValueInString(data.Value)}", fontTextRegular, XBrushes.Black, new XPoint(offsetX + 172, offsetY + 120));

            gfx.DrawString("Pagador:", fontTextLight, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 143));
            gfx.DrawString($"{data.Sacado} - {data.SacadoDocument}", fontText, XBrushes.Black, new XPoint(offsetX + 40, offsetY + 143));
            gfx.DrawString($"{data.SacadoAddress}, {data.SacadoNumber} - {data.SacadoBairro}", fontText, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 155));
            gfx.DrawString($"{data.SacadoCity} - {data.SacadoState} - {data.SacadoCep}", fontText, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 167));

            gfx.DrawString("Instruções:", fontText, XBrushes.Black, new XPoint(offsetX + 4, offsetY + 181));
            var instrucao = new StringBuilder();
            var instrucoes = new List<string>();
            if (!string.IsNullOrEmpty(data.InstructionOne))
            {
                instrucao.Append($"{data.InstructionOne}");
            }
            if (!string.IsNullOrEmpty(data.InstructionTwo))
            {
                instrucao.AppendLine($" | {data.InstructionTwo}");
            }
            if (!string.IsNullOrEmpty(data.InstructionThree))
            {
                instrucao.AppendLine($"{data.InstructionThree}");
            }
            if (data.Desconto > 0)
            {
                instrucao.AppendLine($"Conceder desconto de R$ {data.Desconto} até {data.DataDesconto.ToString("dd/MM/yyyy")}");
            }
            if (gerarComMultaJuros)
            {
                instrucao.AppendLine($"Após vencimento, cobrar multa de {data.Multa}% e juros de {data.Juros}% ao dia.");
            }
            if (data.Protesto > 0)
            {
                instrucao.AppendLine($"Após {data.Protesto} dias sujeito a protesto.");
            }
            if (!string.IsNullOrEmpty(data.InstructionFour))
                instrucoes.Add(data.InstructionFour);

            if (!string.IsNullOrEmpty(data.InstructionFive))
                instrucoes.Add(data.InstructionFive);

            if (!string.IsNullOrEmpty(data.InstructionSix))
                instrucoes.Add(data.InstructionSix);

            if (instrucoes.Any())
                instrucao.AppendLine(string.Join(" | ", instrucoes));

            var linhas = instrucao.ToString().Split(Environment.NewLine);

            double alturaInstrucao = offsetY + 189;
            foreach (var linha in linhas)
            {
                gfx.DrawString(linha, instructionsFont, XBrushes.Black, new XPoint(offsetX + 4, alturaInstrucao));
                alturaInstrucao += instructionsFont.GetHeight();
            }

            // PIX QR Code
            if (string.IsNullOrEmpty(data.PixQrString))
            {
                gfx.DrawString("Simplifique seu pagamento ", fontText, XBrushes.Black, new XPoint(offsetX + 310, offsetY + 130));
                gfx.DrawString("e escolha o PIX!", fontText, XBrushes.Black, new XPoint(offsetX + 328, offsetY + 140));
            }
            else
            {
                var qrGenerator = new QRCodeGenerator();
                var qrData = qrGenerator.CreateQrCode(data.PixQrString, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new PngByteQRCode(qrData);
                var qrBytes = qrCode.GetGraphic(15);

                using (var msQr = new MemoryStream(qrBytes))
                {
                    var qrImage = XImage.FromStream(() => msQr);
                    gfx.DrawString("Pague com PIX", fontText, XBrushes.Black, new XPoint(offsetX + 320, offsetY + 80));
                    gfx.DrawImage(qrImage, offsetX + 300, offsetY + 85, 100, 100);
                }
            }

            // barcode
            var codeBar = convertDigitablelLineForBarcode(data.Barcode);
            var barcodeWriter = new BarcodeWriter<Image<Rgba32>>
            {
                Format = BarcodeFormat.ITF,
                Options = new EncodingOptions
                {
                    Width = 600,
                    Height = 40,
                    Margin = 0
                },
                Renderer = new ZXing.ImageSharp.Rendering.ImageSharpRenderer<Rgba32>()
            };

            var barcodeImageSharp = barcodeWriter.Write(codeBar);
            using var ms = new MemoryStream();
            barcodeImageSharp.Save(ms, new PngEncoder());
            ms.Position = 0;
            var barcodeImage = XImage.FromStream(() => ms);
            gfx.DrawImage(barcodeImage, offsetX, offsetY + 225);

            if (offsetY < 550)
            {
                gfx.DrawString("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ", fontTextLight, XBrushes.Black, new XPoint(30, offsetY + 265));
            }

            //horizontal lines lateral
            gfx.DrawLine(penBlack, 26, offsetY + 32, 145, offsetY + 32);
            gfx.DrawLine(penBlack, 26, offsetY + 48, 145, offsetY + 48);
            gfx.DrawLine(penBlack, 26, offsetY + 75, 145, offsetY + 75);
            gfx.DrawLine(penBlack, 26, offsetY + 105, 145, offsetY + 105);
            gfx.DrawLine(penBlack, 26, offsetY + 130, 145, offsetY + 130);
            gfx.DrawLine(penBlack, 26, offsetY + 155, 145, offsetY + 155);
            gfx.DrawLine(penBlack, 26, offsetY + 222, 145, offsetY + 222);

            //vertical lines lateral
            gfx.DrawLine(penBlack, 26, offsetY + 32, 26, offsetY + 222);
            gfx.DrawLine(penBlack, 145, offsetY + 32, 145, offsetY + 222);

            //horizontal lines in
            gfx.DrawLine(penBlack, 152, offsetY + 32, 560, offsetY + 32);
            gfx.DrawLine(penBlack, 152, offsetY + 48, 560, offsetY + 48);
            gfx.DrawLine(penBlack, 152, offsetY + 75, 430, offsetY + 75);
            gfx.DrawLine(penBlack, 152, offsetY + 90, 430, offsetY + 90);
            gfx.DrawLine(penBlack, 152, offsetY + 105, 430, offsetY + 105);
            gfx.DrawLine(penBlack, 152, offsetY + 130, 430, offsetY + 130);
            gfx.DrawLine(penBlack, 152, offsetY + 174, 430, offsetY + 174);
            gfx.DrawLine(penBlack, 152, offsetY + 222, 560, offsetY + 222);

            //vertical lines Dash
            var penBlackDash = new XPen(XColors.Black, 1);
            penBlackDash.DashStyle = XDashStyle.Dash;
            gfx.DrawLine(penBlackDash, 148, offsetY + 10, 148, offsetY + 255);

        }

        // void DrawDashedLine(XGraphics gfx, XPen pen, PointF p1, PointF p2, float dashLength = 5f, float gapLength = 3f)
        // {

        //     float dx = p2.X - p1.X;
        //     float dy = p2.Y - p1.Y;
        //     float length = (float)Math.Sqrt(dx * dx + dy * dy);
        //     float vx = dx / length;
        //     float vy = dy / length;

        //     float progress = 0;

        //     while (progress < length)
        //     {
        //         float sx = p1.X + vx * progress;
        //         float sy = p1.Y + vy * progress;

        //         progress += dashLength;
        //         if (progress > length) progress = length;

        //         float ex = p1.X + vx * progress;
        //         float ey = p1.Y + vy * progress;

        //         gfx.DrawLine(pen, sx, sy, ex, ey);

        //         progress += gapLength;
        //     }
        // }

        public byte[] GenerateBoletoComPixPdf(BoletoData data, bool gerarComMultaJuros)
        {
            const int deslocamentoY = -40;

            XPoint P(double x, double y) => new XPoint(x, y + deslocamentoY);
            XBrush darkerYellow = new XSolidBrush(XColor.FromArgb(255, 204, 153, 0));


            var document = new PdfDocument();
            var page = document.AddPage();
            page.Size = PdfSharpCore.PageSize.A4;
            var gfx = XGraphics.FromPdfPage(page);
            XPen penBlack = new XPen(XColors.Black, 1);
            XPen yellowPen = new XPen(XColors.Yellow, 2);

            XPen dashedPen = new XPen(XColors.Black, 1);
            dashedPen.DashStyle = XDashStyle.Dash;

            var fontTextLight = new XFont("Helvetica", 9, XFontStyle.Regular);
            var fontText = new XFont("Helvetica", 8, XFontStyle.Regular);
            var instructionsFont = new XFont("Helvetica", 7, XFontStyle.Regular);
            var fontTextRegular = new XFont("Helvetica", 10, XFontStyle.Regular);
            var fontTextSubtitleBoldRegular = new XFont("Helvetica", 10, XFontStyle.Regular);
            var fontTextSubtitleBold = new XFont("Helvetica", 10, XFontStyle.Bold);
            var fontTextTitle = new XFont("Helvetica", 12, XFontStyle.Bold);


            if (!string.IsNullOrEmpty(data?.CedenteLogoPath))
            {
                var cedentelogo = XImage.FromFile(data.CedenteLogoPath);

                double maxWidth = 70;
                double maxHeight = 70;

                double originalWidth = cedentelogo.PixelWidth;
                double originalHeight = cedentelogo.PixelHeight;

                double ratioX = maxWidth / originalWidth;
                double ratioY = maxHeight / originalHeight;
                double ratio = Math.Min(ratioX, ratioY);

                double scaledWidth = originalWidth * ratio;
                double scaledHeight = originalHeight * ratio;

                double x = 20 + (maxWidth - scaledWidth) / 2;
                double y2 = 10 + (maxHeight - scaledHeight) / 2;

                gfx.DrawImage(cedentelogo, x, y2, scaledWidth, scaledHeight);
            }

            var zokilogo = XImage.FromFile(data.ZokiLogoPath);
            gfx.DrawImage(zokilogo, 445, 25, 120, 30);

            gfx.DrawLine(penBlack, 20, 120 + deslocamentoY, 570, 120 + deslocamentoY);

            int y = 165 + deslocamentoY;
            gfx.DrawLine(penBlack, 20, y + 10, 570, y + 10);

            y += 12;

            gfx.DrawString("BENEFICIÁRIO FINAL:", fontTextSubtitleBold, darkerYellow, P(30, y));
            y += 14;
            gfx.DrawString($"{data.Cedente} - CNPJ:{data.CedenteDocument}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));
            y += 14;
            gfx.DrawString($"{data.CedenteAddress}, {data.CedenteNumber} - {data.CedenteBairro} - {data.CedenteCity} - {data.CedenteState}  - {data.CedenteCep}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));


            y += 14;
            gfx.DrawLine(penBlack, 20, y + 25, 570, y + 25);

            y += 12;

            gfx.DrawString("PAGADOR:", fontTextSubtitleBold, darkerYellow, P(30, y));
            y += 14;
            gfx.DrawString(data.Sacado, fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));
            y += 14;
            gfx.DrawString($"{data.SacadoAddress} - {data.SacadoNumber} - {data.SacadoBairro}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));
            y += 14;
            gfx.DrawString($"{data.SacadoCity} - {data.SacadoState} - CEP: {data.SacadoCep}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));

            y += 26;

            // REFERENTE A
            gfx.DrawString("REFERENTE A:", fontTextSubtitleBold, darkerYellow, P(30, y));
            y += 14;
            gfx.DrawString($"Contrato: {data.ContractCode} - {data.ContractType} - Parcela: {data.InstallmentNumber} de {data.TotalInstallmentsNumbers}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));
            y += 14;
            gfx.DrawString($"Loteamento: {data.EnterpriseName}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));
            y += 14;
            gfx.DrawString($"Quadra: {data.Block} - Lote: {data.Lot}", fontTextSubtitleBoldRegular, XBrushes.Black, P(30, y));



            // PIX QR Code
            if (string.IsNullOrEmpty(data.PixQrString))
            {
                string message = "Simplifique seu pagamento e escolha o PIX!";
                double yMessage = 330;

                XSize size = gfx.MeasureString(message, fontText);

                double pageWidth = gfx.PageSize.Width;
                double x = (pageWidth - size.Width) / 2;

                gfx.DrawString(message, fontText, XBrushes.Black, new XPoint(x, yMessage));
            }
            else
            {
                gfx.DrawRectangle(XBrushes.LightGray, 0, 280, page.Width, 160);

                string textoPix = "PAGUE VIA PIX";
                XSize tamanhoTexto = gfx.MeasureString(textoPix, fontTextTitle);
                double paddingX = 8;
                double paddingY = 4;
                double largura = tamanhoTexto.Width + 2 * paddingX;
                double altura = tamanhoTexto.Height + 2 * paddingY;
                double xBotao = 100;
                double yBotao = 310;

                double radius = 6;

                var path = new XGraphicsPath();
                path.AddArc(xBotao, yBotao, radius * 2, radius * 2, 180, 90);
                path.AddArc(xBotao + largura - radius * 2, yBotao, radius * 2, radius * 2, 270, 90);
                path.AddArc(xBotao + largura - radius * 2, yBotao + altura - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(xBotao, yBotao + altura - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseFigure();

                gfx.DrawPath(XPens.Black, XBrushes.Black, path);
                gfx.DrawString(textoPix, fontTextTitle, XBrushes.Yellow, new XPoint(xBotao + paddingX, yBotao + paddingY + tamanhoTexto.Height - 2));

                // OUTROS TEXTOS
                gfx.DrawString("Agora você também pode pagar", fontTextRegular, XBrushes.Black, new XPoint(80, 348));
                gfx.DrawString("nossos boletos via Pix.", fontTextRegular, XBrushes.Black, new XPoint(104, 360));
                gfx.DrawString("Basta abrir o APP e escanear", fontTextRegular, XBrushes.Black, new XPoint(85, 380));
                gfx.DrawString("o QR Code. Experimente!", fontTextRegular, XBrushes.Black, new XPoint(95, 392));

                var qrGenerator = new QRCodeGenerator();
                var qrData = qrGenerator.CreateQrCode(data.PixQrString, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new PngByteQRCode(qrData);
                var qrBytes = qrCode.GetGraphic(15);

                using (var msQr = new MemoryStream(qrBytes))
                {
                    var qrImage = XImage.FromStream(() => msQr);
                    gfx.DrawRectangle(yellowPen, 368, 298, 124, 124);
                    gfx.DrawImage(qrImage, 370, 300, 120, 120);
                }
            }

            gfx.DrawString("VENCIMENTO", fontTextSubtitleBold, darkerYellow, new XPoint(30, 464));
            gfx.DrawString(data.Vencimento.ToString("dd/MM/yyyy"), fontText, XBrushes.Black, new XPoint(30, 480));

            gfx.DrawString("VALOR", fontTextSubtitleBold, darkerYellow, new XPoint(160, 464));
            gfx.DrawString($"{ConvertValueInString(data.Value)}", fontText, XBrushes.Black, new XPoint(160, 480));

            gfx.DrawString("LINHA DIGITÁVEL", fontTextSubtitleBold, darkerYellow, new XPoint(300, 464));
            gfx.DrawString(data.DigitablelLine, fontText, XBrushes.Black, new XPoint(300, 480));

            gfx.DrawLine(dashedPen, 10, 500, 580, 500);

            byte[] imageBytesLogoBank = Convert.FromBase64String(data.BankLogoPath);
            string tempPathLogoBank = Path.GetTempFileName();
            File.WriteAllBytes(tempPathLogoBank, imageBytesLogoBank);
            var banklogo = XImage.FromFile(tempPathLogoBank);

            gfx.DrawImage(banklogo, 30, 503, 80, 26);
            gfx.DrawString($"{data.BankCode}-{data.CodeCoin}", fontTextTitle, XBrushes.Black, new XPoint(180, 528));
            gfx.DrawString($"{data.DigitablelLine}", fontTextRegular, XBrushes.Black, new XPoint(274, 528));
            gfx.DrawString("Local de pagamento: ", fontTextLight, XBrushes.Black, new XPoint(34, 544));
            gfx.DrawString($"Pagar preferencialmente no Banco {data.BankName}", fontText, XBrushes.Black, new XPoint(120, 544));

            gfx.DrawString($"{data.Cedente} - {data.CedenteDocument}", fontText, XBrushes.Black, new XPoint(34, 560));
            gfx.DrawString($"{data.CedenteAddress}, {data.CedenteNumber} - {data.CedenteBairro}", fontText, XBrushes.Black, new XPoint(34, 572));
            gfx.DrawString($"{data.CedenteCity} - {data.CedenteState}  - {data.CedenteCep}", fontText, XBrushes.Black, new XPoint(34, 584));

            gfx.DrawString("Data do Doc.", fontTextLight, XBrushes.Black, new XPoint(34, 600));
            gfx.DrawString($"{data.DocDate.ToString("dd/MM/yyyy")}", fontText, XBrushes.Black, new XPoint(34, 612));
            gfx.DrawString("N° do Documento", fontTextLight, XBrushes.Black, new XPoint(130, 600));
            gfx.DrawString($"{data.DocCode}", fontText, XBrushes.Black, new XPoint(130, 612));
            gfx.DrawString("Espécie do Doc.", fontTextLight, XBrushes.Black, new XPoint(230, 600));
            gfx.DrawString("DV", fontText, XBrushes.Black, new XPoint(230, 612));
            gfx.DrawString("Data do Proces.", fontTextLight, XBrushes.Black, new XPoint(320, 600));
            gfx.DrawString($"{DateTime.Now.ToString("dd/MM/yyyy")}", fontText, XBrushes.Black, new XPoint(320, 612));

            gfx.DrawString("Carteira", fontTextLight, XBrushes.Black, new XPoint(34, 627));
            gfx.DrawString($"{data.Wallet}", fontText, XBrushes.Black, new XPoint(34, 639));
            gfx.DrawString("Espécie da Moeda", fontTextLight, XBrushes.Black, new XPoint(150, 627));
            gfx.DrawString("R$", fontText, XBrushes.Black, new XPoint(150, 639));
            gfx.DrawString("Valor da Moeda", fontTextLight, XBrushes.Black, new XPoint(270, 627));
            gfx.DrawString(" - ", fontText, XBrushes.Black, new XPoint(270, 639));

            gfx.DrawString("Instruções:", fontTextLight, XBrushes.Black, new XPoint(34, 653));
            var instrucao = new StringBuilder();
            var instrucoes = new List<string>();
            if (!string.IsNullOrEmpty(data.InstructionOne))
            {
                instrucao.Append($"{data.InstructionOne}");
            }
            if (!string.IsNullOrEmpty(data.InstructionTwo))
            {
                instrucao.AppendLine($" | {data.InstructionTwo}");
            }
            if (!string.IsNullOrEmpty(data.InstructionThree))
            {
                instrucao.AppendLine($"{data.InstructionThree}");
            }
            if (data.Desconto > 0)
            {
                instrucao.AppendLine($"Conceder desconto de R$ {data.Desconto} até {data.DataDesconto.ToString("dd/MM/yyyy")}");
            }
            if (gerarComMultaJuros)
            {
                instrucao.AppendLine($"Após vencimento, cobrar multa de {data.Multa}% e juros de {data.Juros}% ao dia.");
            }
            if (data.Protesto > 0)
            {
                instrucao.AppendLine($"Após {data.Protesto} dias sujeito a protesto.");
            }
            if (!string.IsNullOrEmpty(data.InstructionFour))
                instrucoes.Add(data.InstructionFour);

            if (!string.IsNullOrEmpty(data.InstructionFive))
                instrucoes.Add(data.InstructionFive);

            if (!string.IsNullOrEmpty(data.InstructionSix))
                instrucoes.Add(data.InstructionSix);

            if (instrucoes.Any())
                instrucao.AppendLine(string.Join(" | ", instrucoes));



            var linhas = instrucao.ToString().Split(Environment.NewLine);

            double alturaInstrucao = 662;
            foreach (var linha in linhas)
            {
                gfx.DrawString(linha, instructionsFont, XBrushes.Black, new XPoint(34, alturaInstrucao));
                alturaInstrucao += instructionsFont.GetHeight(); // ou um valor fixo, tipo 14
            }

            gfx.DrawString("Pagador:", fontTextLight, XBrushes.Black, new XPoint(34, 722));
            gfx.DrawString($"{data.Sacado} - {data.SacadoDocument}", fontText, XBrushes.Black, new XPoint(74, 722));
            gfx.DrawString($"{data.SacadoAddress}, {data.SacadoNumber} - {data.SacadoBairro}", fontText, XBrushes.Black, new XPoint(34, 734));
            gfx.DrawString($"{data.SacadoCity} - {data.SacadoState}  - {data.SacadoCep}", fontText, XBrushes.Black, new XPoint(34, 746));

            gfx.DrawString($"Vencimento: ", fontTextLight, XBrushes.Black, new XPoint(424, 544));
            gfx.DrawString($"{data.Vencimento.ToString("dd/MM/yyyy")}", fontText, XBrushes.Black, new XPoint(494, 544));

            gfx.DrawString("Agência/Conta", fontTextLight, XBrushes.Black, new XPoint(424, 564));
            gfx.DrawString($"{data.Agency}/{data.Account}", fontText, XBrushes.Black, new XPoint(424, 576));

            gfx.DrawString("Nosso Número:", fontTextLight, XBrushes.Black, new XPoint(424, 600));
            gfx.DrawString($"{data.ZokiCode}", fontText, XBrushes.Black, new XPoint(424, 612));

            gfx.DrawString($"Valor (=)", fontTextLight, XBrushes.Black, new XPoint(424, 627));
            gfx.DrawString($"{ConvertValueInString(data.Value)}", fontText, XBrushes.Black, new XPoint(424, 639));

            //horizontal lines
            gfx.DrawLine(penBlack, 30, 532, 555, 532);
            gfx.DrawLine(penBlack, 30, 550, 555, 550);
            gfx.DrawLine(penBlack, 30, 590, 555, 590);
            gfx.DrawLine(penBlack, 30, 617, 555, 617);
            gfx.DrawLine(penBlack, 30, 643, 555, 643);
            gfx.DrawLine(penBlack, 30, 711, 555, 711);
            gfx.DrawLine(penBlack, 30, 750, 555, 750);

            //vertical lines
            gfx.DrawLine(penBlack, 30, 532, 30, 750);
            gfx.DrawLine(penBlack, 126, 590, 126, 617);
            gfx.DrawLine(penBlack, 146, 618, 146, 642);
            gfx.DrawLine(penBlack, 226, 590, 226, 617);
            gfx.DrawLine(penBlack, 267, 618, 267, 642);
            gfx.DrawLine(penBlack, 317, 590, 317, 617);
            gfx.DrawLine(penBlack, 420, 532, 420, 644);
            gfx.DrawLine(penBlack, 555, 532, 555, 750);

            string messageAuth = "autenticação mecânica - Ficha de Compensação";
            gfx.DrawString(messageAuth, fontText, XBrushes.Black, new XPoint(360, 759));

            var codeBar = convertDigitablelLineForBarcode(data.Barcode);
            var barcodeWriter = new BarcodeWriter<Image<Rgba32>>
            {
                Format = BarcodeFormat.ITF,
                Options = new EncodingOptions
                {
                    Width = 799,
                    Height = 50,
                    Margin = 0,
                },
                Renderer = new ZXing.ImageSharp.Rendering.ImageSharpRenderer<Rgba32>()
            };

            var barcodeImageSharp = barcodeWriter.Write(codeBar);

            using (var ms = new MemoryStream())
            {
                barcodeImageSharp.Save(ms, new PngEncoder());
                ms.Position = 0;
                var barcodeImage = XImage.FromStream(() => ms);
                gfx.DrawImage(barcodeImage, 10, 770);
            }

            var pdfBytes = ConverterPdfParaBytes(document);

            return pdfBytes;
        }
    }
}

public class BoletoData
{
    public string ZokiLogoPath { get; set; }
    public string ZokiCode { get; set; }
    public DateTime DocDate { get; set; }
    public string BankLogoPath { get; set; }
    public string Cedente { get; set; }
    public string CedenteAddress { get; set; } = "";
    public string CedenteNumber { get; set; } = "";
    public string CedenteBairro { get; set; } = "";
    public string CedenteCity { get; set; } = "";
    public string CedenteState { get; set; } = "";
    public string CedenteCep { get; set; } = "";
    public string CedenteDocument { get; set; }
    public string CedenteLogoPath { get; set; }
    public string BankCode { get; set; }
    public string BankName { get; set; }
    public string CodeCoin { get; set; }
    public string DigitablelLine { get; set; }
    public string Barcode { get; set; }
    public string Agency { get; set; }
    public string Account { get; set; }
    public string Wallet { get; set; }
    public string Sacado { get; set; }
    public string SacadoDocument { get; set; }
    public string SacadoAddress { get; set; }
    public string SacadoNumber { get; set; }
    public string SacadoBairro { get; set; }
    public string SacadoCity { get; set; }
    public string SacadoState { get; set; }
    public string SacadoCep { get; set; }
    public string DocCode { get; set; }
    public string ContractCode { get; set; }
    public string ContractType { get; set; }
    public string InstallmentNumber { get; set; }
    public string TotalInstallmentsNumbers { get; set; }
    public string EnterpriseName { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
    public string InstructionOne { get; set; }
    public string InstructionTwo { get; set; }
    public string InstructionThree { get; set; }
    public string InstructionFour { get; set; }
    public string InstructionFive { get; set; }
    public string InstructionSix { get; set; }
    public DateTime Vencimento { get; set; }
    public DateTime DataDesconto { get; set; }
    public decimal Value { get; set; }
    public string PixQrString { get; set; }
    public string PixTxId { get; set; }
    public decimal Multa { get; set; }
    public decimal Juros { get; set; }
    public decimal Desconto { get; set; }
    public int Protesto { get; set; }
}
