using System;

namespace Simple_Fuck {
    class Interpreter {
        private static readonly int BUFFER = 65535;
        private int pointer { get; set; }
        private bool print { get; set; }
        private int[] buffer = new int[BUFFER];

        public Interpreter() {
            this.pointer = 0;
            this.Reset();
        }

        public void Reset() {
            Array.Clear(this.buffer, 0, this.buffer.Length);
        }

        public void Interpret(string src) {
            int i = 0;
            int max = src.Length;
            while (i < max) {
                switch (src[i]) {
                    case '>': {
                            this.pointer++;
                            if (this.pointer >= BUFFER) {
                                this.pointer = 0;
                            }
                            break;
                        }
                    case '<': {
                            this.pointer--;
                            if (this.pointer < 0) {
                                this.pointer = BUFFER - 1;
                            }
                            break;
                        }
                    case '.': {
                            Console.Write((char)this.buffer[this.pointer]);
                            break;
                        }
                    case '+': {
                            this.buffer[this.pointer]++;
                            break;
                        }
                    case '-': {
                            this.buffer[this.pointer]--;
                            break;
                        }
                    case '[': {
                            if (this.buffer[this.pointer] == 0) {
                                int loop = 1;
                                while (loop > 0) {
                                    i++;
                                    char c = src[i];
                                    if (c == '[') {
                                        loop++;
                                    } else if (c == ']') {
                                        loop--;
                                    }
                                }
                            }
                            break;
                        }
                    case ']': {
                            int loop = 1;
                            while (loop > 0) {
                                i--;
                                char c = src[i];
                                if (c == '[') {
                                    loop--;
                                } else if (c == ']') {
                                    loop++;
                                }
                            }
                            i--;
                            break;
                        }
                    case ',': {
                            ConsoleKeyInfo key = Console.ReadKey(this.print);
                            this.buffer[this.pointer] = (int)key.KeyChar;
                            break;
                        }
                }
                i++;
            }
        }
    }
}
