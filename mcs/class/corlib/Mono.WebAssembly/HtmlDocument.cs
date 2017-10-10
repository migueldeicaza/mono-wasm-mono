using System;

namespace Mono.WebAssembly
{
    public class HtmlDocument : HtmlNode
    {
        public HtmlDocument(string expr) : base(expr) {}

        public string Location
        {
            get {
                return Invoke("location");
            }
        }

        public HtmlElement GetElementById(string id)
        {
            return new HtmlElement(InvokeExpr("getElementById(\"" + id + "\")"));
        }
    }
}
