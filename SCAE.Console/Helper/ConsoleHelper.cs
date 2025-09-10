using System;

namespace SCAE.Migracao.Helper
{
    public class ConsoleHelper
    {
        public static void WriteColor(string texto, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(texto);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
