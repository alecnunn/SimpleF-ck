using System;

namespace Simple_Fuck {
    class Transformer {

        private string _orig;
        private string _src;
        public Transformer(String src) {
            _orig = src;
            _src = _orig.Replace("SHIFT", string.Empty).Replace(" ", string.Empty).Replace("LEFT", "<").Replace("RIGHT", ">").Replace("INPUT", ",").Replace("PRINT", ".").Replace("LOOP(", "[").Replace(")LOOP", "]").Replace("INC", "+").Replace("DEC", "-");
        }

        public override string ToString() {
            return this._src;
        }
    }
}
