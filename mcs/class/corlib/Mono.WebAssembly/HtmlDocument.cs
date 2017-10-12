using System;

namespace Mono.WebAssembly
{
    public class HtmlDocument : HtmlNode
    {
        internal HtmlDocument(string expr) : base(expr) {}

        public string Location
        {
            get {
                return Invoke("location");
            }
        }

        public HtmlElement DocumentElement
        {
            get {
                return new HtmlElement(InvokeExpr("documentElement"));
            }
        }

        public HtmlElement Body
        {
            get {
                return new HtmlElement(InvokeExpr("body"));
            }
        }

        public HtmlElement GetElementById(string id)
        {
            return new HtmlElement(InvokeExpr("getElementById(\"" + id + "\")"));
        }
    }
}
