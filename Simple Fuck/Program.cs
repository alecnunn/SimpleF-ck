#region Copyright
/*
The MIT License (MIT)

Copyright (c) 2014 Alec Nunn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
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
