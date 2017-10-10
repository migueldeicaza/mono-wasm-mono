using System;

namespace Mono.WebAssembly
{
    public class HtmlElement : HtmlNode
    {
        public HtmlElement(string expr) : base(expr) {}

        public string InnerText
        {
            get {
                return Invoke("innerText");
            }

            set {
                Invoke("innerText = \"" + value + "\"");
            }
        }
    }
}
