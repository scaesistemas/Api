using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCAE.Framework.Helper
{
    public class StringHelper
    {
        public static string LimparAcentuacao(string s)
        {

            var str = s.Normalize(NormalizationForm.FormD);

            var sb = new StringBuilder();

            foreach (char t in str)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(t);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(t);
                }
            }
            return sb.ToString();

        }

        public static string LimparCpfCnpj(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static string LimparTelefone(string s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        }

        public static string RemoverHifen(string s) // limparCep
        {
            return string.IsNullOrEmpty(s) ? string.Empty : s.Replace("-", "");
        }

        public static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpj.Length != 14)
                return false;

            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        public static bool IsCpfCnpj(string cpfcnpj)
        {
            return IsCpfCnpj(cpfcnpj, false);
        }

        public static bool IsCpfCnpj(string cpfCnpj, bool vazio)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return vazio;
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string Sequencia, SoNumero;

                SoNumero = Regex.Replace(cpfCnpj, "[^0-9]", string.Empty);

                //verificando se todos os numeros são iguais
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;

                // se a quantidade de dígitos numérios for igual a 11
                // iremos verificar como CPF
                if (SoNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }
                // se a quantidade de dígitos numérios for igual a 14
                // iremos verificar como CNPJ
                else if (SoNumero.Length == 14)
                {
                    Sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }
                // CPF ou CNPJ inválido se
                // a quantidade de dígitos numérios for diferente de 11 e 14
                else return false;
            }
        }

        public static string LimparHifenDescricao(string s)
        {
            var sNovo = s.Trim();

            if (sNovo.StartsWith("-"))
                sNovo = sNovo.Remove(0, 1);

            if (sNovo.EndsWith("-"))
                sNovo = sNovo.Remove(sNovo.Length - 2, sNovo.Length - 1);

            return sNovo;
        }

        public static string FormataValor(decimal valor)
        {
            return valor.ToString("N2").Replace(",", "").Replace(".", "");
        }

        public static string FormataCpfCnpj(string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return cpfCnpj;

            var aux = cpfCnpj.Replace("-", "").Replace(".", "").Replace("/", "");

            return aux.Length <= 11 ? 
                Convert.ToUInt64(aux).ToString(@"000\.000\.000\-00") : 
                Convert.ToUInt64(aux).ToString(@"00\.000\.000\/0000\-00");
        }

        public static string FormataCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
                return cep;

            if (cep.IndexOf('-') > -1)
                return cep;

            if (cep.Trim().Length > 8)
                cep = cep.Trim().Substring(0, 8);

            return Convert.ToUInt64(cep).ToString(@"00000\-000");
        }

        public static bool ValidarEmail(string email)
        {
            string regex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";//@"^[^@\s]+@[^@\s]+\.$";

            return Regex.IsMatch(email,regex, RegexOptions.IgnoreCase);
        }

        public static bool IsTelefone(string telefone)
        {
            Regex telefoneRegex = new Regex(@"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$");
            return telefoneRegex.IsMatch(telefone);
        }

        public static string PadronizarPrimeiraMaiuscula(string text, bool primeiraMaiuscula = false, bool comEspaco = true)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.ToCharArray();

            var spaceFound = primeiraMaiuscula;
            foreach (var letter in arrayText)
            {
                if (letter.ToString().Equals(" "))
                {
                    spaceFound = true;
                    if (comEspaco)
                        sbReturn.Append(" ");
                }
                else if (spaceFound)
                {
                    sbReturn.Append(letter.ToString().ToUpper());
                    spaceFound = false;
                }
                else
                {
                    sbReturn.Append(letter.ToString().ToLower());
                }
            }
            return sbReturn.ToString();
        }
        public static string RemoverAcentos(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            Console.WriteLine();
            return sbReturn.ToString();
        }

        public static string TransformarArrayIdString(List<int> listIds)
        {
            var textoRetorno = new StringBuilder();
            textoRetorno.Append("[ ");
            var counter = 0;
            foreach(var id in listIds)
            {
                counter++;
                textoRetorno.Append($" {id}");
                if(counter < listIds.Count)
                    textoRetorno.Append($",");
            }
            textoRetorno.Append(" ]");

            return textoRetorno.ToString();
        } 
    }
}
