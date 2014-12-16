using System;
using System.IO;

namespace Simple_Fuck {
    class Program {
        static void Main(string[] args) {

            if(args.Length < 1) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
 ███████╗██╗███╗   ███╗██████╗ ██╗     ███████╗███████╗        ██████╗██╗  ██╗
 ██╔════╝██║████╗ ████║██╔══██╗██║     ██╔════╝██╔════╝▄ ██╗▄ ██╔════╝██║ ██╔╝
 ███████╗██║██╔████╔██║██████╔╝██║     █████╗  █████╗   ████╗ ██║     █████╔╝ 
 ╚════██║██║██║╚██╔╝██║██╔═══╝ ██║     ██╔══╝  ██╔══╝  ▀╚██╔▀ ██║     ██╔═██╗ 
 ███████║██║██║ ╚═╝ ██║██║     ███████╗███████╗██║       ╚═╝  ╚██████╗██║  ██╗
 ╚══════╝╚═╝╚═╝     ╚═╝╚═╝     ╚══════╝╚══════╝╚═╝             ╚═════╝╚═╝  ╚═╝");
                Console.WriteLine("");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\tAuthor:\t\tAlec Nunn");
                Console.Write("\tVersion:\t");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1.0.0");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tWebsite:\t");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("www.alecnunn.com");
                Console.ResetColor();
                Console.WriteLine("\n\n");
                Console.WriteLine("\tPlease use the following syntax:\n\t\tsbf.exe <file>");
                Console.Read();
                Environment.Exit(0);
            } else {
                var t = new Transformer(File.ReadAllText(args[0]));
                var i = new Interpreter();
                try {
                    i.Interpret(t.ToString());
                } catch (Exception ex) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(ex.Message);
                }
                Console.Read();   
            }
        }
    }
}
