using System;
using System.Collections.Generic;
using System.IO;

namespace SBF {
    class Program {
        static void Main(string[] args) {
            if(args.Length < 2) {
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
                Console.WriteLine("2.1.0");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\tWebsite:\t");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("www.alecnunn.com");
                Console.ResetColor();
                Console.WriteLine("\n\n");
                Console.WriteLine(
                    "\tUsage:\n\t\tsbf.exe [option] [filename]\n\n\t\tOptions:\n\t\t-i Interpret the file and print output\n\t\t-c Convert the SimpleF*ck script to BrainF*ck");
                Environment.Exit(0);
            } else {


                if(args[0] == "-i") {
                    var txt = File.ReadAllLines(args[1]);
                    Parser p = new Parser();
                    p.LoadTokens(txt);
                    p.ParseTokens();
                    Interpreter i = new Interpreter();
                    i.Interpret(p.ToString());
                } else if(args[0] == "-c") {
                    var txt = File.ReadAllLines(args[1]);
                    Parser p = new Parser();
                    p.LoadTokens(txt);
                    p.ParseTokens();
                    Console.WriteLine(p.ToString());
                }
            }
        }
    }

    class Parser {
        private List<string> tokens = new List<string>();
        private List<char> brainfuck = new List<char>();
        private string code = "";

        public void LoadTokens(string[] src) {
            foreach(string s in src) {
                tokens.Add(s.Trim());
            }
        }

        public void ParseTokens() {
            foreach(string s in tokens) {

                if(s.StartsWith("#")) {
                    continue;
                } else {
                    if (s == "SHIFT LEFT") {
                        brainfuck.Add('<');
                    } else if (s == "SHIFT RIGHT") {
                        brainfuck.Add('>');
                    } else if (s == "PRINT") {
                        brainfuck.Add('.');
                    } else if (s == "INPUT") {
                        brainfuck.Add('.');
                    } else if (s == "LOOP(") {
                        brainfuck.Add('[');
                    } else if (s == ")") {
                        brainfuck.Add(']');
                    } else if (s.StartsWith("INC")) {
                        string[] res = s.Split('(');
                        for (int i = 0; i < int.Parse(res[1].Replace(")", string.Empty)); i++) {
                            brainfuck.Add('+');
                        }
                    } else if (s.StartsWith("DEC")) {
                        string[] res = s.Split('(');
                        for (int i = 0; i < int.Parse(res[1].Replace(")", string.Empty)); i++) {
                            brainfuck.Add('-');
                        }
                    }
                }
            }
            CodeGen();
        }

        private void CodeGen() {
            foreach (char c in brainfuck) {
                code += c;
            }
        }

        public override string ToString() {
            return code;
        }
    }
}
