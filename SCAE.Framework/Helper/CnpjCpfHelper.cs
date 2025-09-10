using System;
using System.Linq;

namespace SCAE.Framework.Helper
{
    public class CnpjCpfHelper
    {
        /// <summary>
        /// Formatar uma string CNPJ
        /// </summary>
        /// <param name="cnpj">string CNPJ sem formatacao</param>
        /// <returns>string CNPJ formatada</returns>
        /// <example>Recebe '99999999999999' Devolve '99.999.999/9999-99'</example>
        public static string FormataCNPJ(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
                return cnpj;

            return Convert.ToUInt64(cnpj).ToString(@"00\.000\.000\/0000\-00");
        }
         
        /// <summary>
        /// Formatar uma string CPF
        /// </summary>
        /// <param name="cpf">string CPF sem formatacao</param>
        /// <returns>string CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99'</example>
        public static string FormataCPF(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return cpf;

            return Convert.ToUInt64(cpf).ToString(@"000\.000\.000\-00");
        }

        /// <summary>
        /// Formatar uma string CNPJ ou CPF (que será dectada automaticamente)
        /// </summary>
        /// <param name="cnpjCpf">string CNPJ ou CPF sem formatacao</param>
        /// <returns>string CNPJ ou CPF formatada</returns>
        /// <example>Recebe '99999999999' Devolve '999.999.999-99' ou '99999999999999' Devolve '99.999.999/9999-99'</example>
        public static string Formata(string cnpjCpf)
        {
            if (string.IsNullOrEmpty(cnpjCpf))
                return cnpjCpf;

            return cnpjCpf.Length > 11 ? FormataCNPJ(cnpjCpf) : FormataCPF(cnpjCpf);
        }


        public static string LimparCpfCnpj(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return cpf;
                
            return new string(cpf.Where(char.IsDigit).ToArray());
        }

        public static string LimparEFormatarCpfCnpj(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
                return cpf;

            string CpfCnpjlimpo = LimparCpfCnpj(cpf);
            return Formata(CpfCnpjlimpo);
        }

        public static bool IsCPFValido(string cpf)
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

        public static bool IsCnpjValido(string cnpj)
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

        public static bool IsCPFCNPJValido(string cpfCnpj)
        {
            string CpfCnpjlimpo = LimparCpfCnpj(cpfCnpj);
            return CpfCnpjlimpo.Length > 11 ? IsCnpjValido(CpfCnpjlimpo) : IsCPFValido(CpfCnpjlimpo);
        }
    }
}
