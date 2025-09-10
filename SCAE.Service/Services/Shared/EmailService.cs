using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Shared;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared
{
    public class EmailService : IEmailService
    {
        public string GerarCorpo(string usuario, string corpoEmail, string assinatura)
        {
            var body = string.Empty;

            using (var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "/Template/TemplateEmailScae.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("{usuario}", usuario);
                body = body.Replace("{corpoEmail}", corpoEmail);
                body = body.Replace("{assinatura}", assinatura);
            }

            return body;
        }

        public string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero, string linkBoleto, string dominio, string caminhoLogo, string empresaNome, string empresaNumero, string empresaEmail )
        {
            var body = string.Empty;

            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Template/Cobranca/Template{layoutId:D2}.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("$cliente_nome$", clienteNome);
                body = body.Replace("$dataVencimento$", dataVencimento);
                body = body.Replace("$contrato_numero$", contratoNumero);
                body = body.Replace("$link_boleto$", linkBoleto);
                body = body.Replace("cliente-$subDominio_nome$.scae.adm.br", dominio);
                body = body.Replace("$empresa_nome$", empresaNome);
                body = body.Replace("$empresa_numero$", empresaNumero);
                body = body.Replace("$empresa_email$", empresaEmail);

                if(!string.IsNullOrEmpty(caminhoLogo))
                    body = body.Replace("$empresa_logo$", $"<img src=\"{caminhoLogo}\" style=\"width: 140px;\">");

                else
                    body = body.Replace("$empresa_logo$", "");
            }

            return body;
        }

        public string GerarCorpoCobranca(int layoutId, string clienteNome, string dataVencimento, string contratoNumero, string linhaDigitavel, string qrCode, string dominio, string caminhoLogo, string empresaNome, string empresaNumero, string empresaEmail )
        {
            var body = string.Empty;

            using (var reader = new StreamReader($"{AppDomain.CurrentDomain.BaseDirectory}/Template/Cobranca/Template{layoutId:D2}.html"))
            {
                body = reader.ReadToEnd();
                body = body.Replace("$cliente_nome$", clienteNome);
                body = body.Replace("$dataVencimento$", dataVencimento);
                body = body.Replace("$contrato_numero$", contratoNumero);
                body = body.Replace("$cliente-$subDominio_nome$.scae.adm.br", dominio);
                body = body.Replace("$empresa_nome$", empresaNome);
                body = body.Replace("$empresa_numero$", empresaNumero);
                body = body.Replace("$empresa_email$", empresaEmail);

                var pagamentoTexto = $"você poderá realizar o pagamento com:<br>Linha digitável: {linhaDigitavel}<br>";
                pagamentoTexto += string.IsNullOrEmpty(qrCode) ? "<br>" : $"QrCode: {qrCode}<br><br>";

                body = body.Replace("<a href=\"$link_boleto$\" target=\"_blank\" style=\"color: #F6631E; font-weight: bold;\">clique aqui</a> para pegar seu boleto.", pagamentoTexto);

                if(!string.IsNullOrEmpty(caminhoLogo))
                    body = body.Replace("$empresa_logo$", $"<img src=\"{caminhoLogo}\" style=\"width: 140px;\">");

                else
                    body = body.Replace("$empresa_logo$", "");
            }

            return body;
        }

        public async Task EnviarEmail(string destinatario, string assunto, string corpo)
        {
            await EnviarEmail(
                "no-reply@scae.adm.br",
                "SCAE",
                destinatario,
                assunto,
                corpo,
                "smtp.mailgun.org",
                2525,
                false,
                "postmaster@mg.scae.adm.br",
                ""
            );
        }
        //alow
        public async Task EnviarEmail(string remetente, string remetenteNome, string destinatario, string assunto, string corpo, string clienteSMTP, int portaSMTP, bool usarSSL, string credencialUsuario, string credencialSenha)
        {
            if (string.IsNullOrEmpty(remetente))
                throw new BadRequestException("Remetente encontra-se vazio");

            if (string.IsNullOrEmpty(destinatario))
                throw new BadRequestException("Destinatario encontra-se vazio");

            var mensagem = new MailMessage(new MailAddress(remetente, remetenteNome), new MailAddress(destinatario))
            {
                IsBodyHtml = true,
                Subject = assunto,
                Body = corpo
            };

            if (string.IsNullOrEmpty(clienteSMTP))
                throw new BadRequestException("Cliente SMTP encontra-se vazio");

            SmtpClient client = new SmtpClient(clienteSMTP, portaSMTP);

            client.EnableSsl = usarSSL;

            NetworkCredential cred = new NetworkCredential(credencialUsuario, credencialSenha);

            client.Credentials = cred;

            await client.SendMailAsync(mensagem);
        }

    }
}
