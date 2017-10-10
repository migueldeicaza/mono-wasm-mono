using System;

namespace Mono.WebAssembly
{
    public class HtmlWindow
    {
        public void Alert(string alertText)
        {
            Runtime.JavaScriptEval("alert(\"" + alertText + "\")");
        }

        public bool Confirm(string confirmText)
        {
            return Runtime.JavaScriptEval("confirm(\"" + confirmText + "\")") == "true";
        }

        public string Prompt(string promptText)
        {
            return Runtime.JavaScriptEval("prompt(\"" + promptText + "\")");
        }

        public string Eval(string code)
        {
            return Runtime.JavaScriptEval(code);
        }
    }
}
