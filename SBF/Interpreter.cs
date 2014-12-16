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

namespace SBF {
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
