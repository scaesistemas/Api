using SCAE.Migracao.Services;
using System;

namespace SCAE.Migracao
{
    class Program
    {
        private static void MontaMenu()
        {
            Console.WriteLine("-------------------------------");
            Console.Write("|           ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("MENU");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("               |");
            Console.WriteLine("-------------------------------");

            Console.WriteLine("1) Migrar Cliente");
            Console.WriteLine("2) Migrar Corretor");
            Console.WriteLine("3) Migrar Empreendimento");
            Console.WriteLine("4) Migrar Contrato");
            Console.WriteLine("5) Migrar Receita");
            Console.WriteLine("6) Migrar Fornecedor");
            Console.WriteLine("7) Migrar Despesa");
            Console.WriteLine("0) Sair");
        }

        static void Main(string[] args)
        {
            var menu = string.Empty;

            while (menu != "0")
            {
                MontaMenu();
                menu = Console.ReadLine();
                var contratoId = string.Empty;
                var contratoSequencia = string.Empty;
                var empresaId = 0;

                switch (menu)
                {
                    case "1":
                        new ClienteService().Migrar();
                        break;
                    case "2":
                        new CorretorService().Migrar();
                        break;
                    case "3":
                        new LoteamentoService().Migrar();
                        break;
                    case "4":
                        Console.Write("Digite o número do contrato: ");
                        contratoId = Console.ReadLine();
                        Console.Write("Digite o sequência do contrato: ");
                        contratoSequencia = Console.ReadLine();
                        Console.Write("Importação via API: (S/N)");
                        var api = Console.ReadLine() == "S";
                        new ContratoService().Migrar(!string.IsNullOrEmpty(contratoId) ? int.Parse(contratoId) : 0,
                            !string.IsNullOrEmpty(contratoSequencia) ? int.Parse(contratoSequencia) : 0, api);
                        break;
                    case "5":
                        Console.Write("Digite o número do contrato: ");
                        contratoId = Console.ReadLine();
                        Console.Write("Digite o sequência do contrato: ");
                        contratoSequencia = Console.ReadLine();
                        Console.Write("Digite o id da empresa antiga: ");
                        empresaId = int.Parse(Console.ReadLine());
                        new RecebivelService().MigrarParcelasByApy(empresaId,  
                            !string.IsNullOrEmpty(contratoId) ? int.Parse(contratoId) : 0,
                            !string.IsNullOrEmpty(contratoSequencia) ? int.Parse(contratoSequencia) : 0);
                        break;
                    case "6":
                        new FornecedorService().Migrar();
                        break;
                    case "7":
                        new DespesaService().MigrarByApi();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
