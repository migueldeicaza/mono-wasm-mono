using System;

namespace Mono.WebAssembly
{
    public class HtmlWindow : Object
    {
        public HtmlWindow(string expr) : base(expr) {}

        public void Alert(string alertText)
        {
            Invoke("alert(\"" + alertText + "\")");
        }

        public bool Confirm(string confirmText)
        {
            return Invoke("confirm(\"" + confirmText + "\")") == "true";
        }

        public string Prompt(string promptText)
        {
            return Invoke("prompt(\"" + promptText + "\")");
        }

        public string Eval(string code)
        {
            return Invoke("eval(" + code + ")");
        }
    }
}
