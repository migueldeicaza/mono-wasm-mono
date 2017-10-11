using System;
using System.Collections.Generic;

namespace Mono.WebAssembly
{
    public class HtmlElement : HtmlNode
    {
        public HtmlElement(string expr) : base(expr) {}

        public string Id
        { 
            get { 
                return Invoke("id");
            }
        }

        public string TagName
        { 
            get { 
                return Invoke("tagName");
            }
        }

        public string ClassName
        { 
            get { 
                return Invoke("className");
            }

            set {
                Invoke("className = \"" + value + "\"");
            }
        }

        public HtmlElement Parent
        {
            get {
                return new HtmlElement(InvokeExpr("parent"));
            }
        }

        public List<HtmlElement> Children
        {
            get {
                var list = new List<HtmlElement>();

                var count = Int32.Parse(Invoke("children.length"));

                for (int i = 0; i < count; i++) {
                    list.Add(new HtmlElement(InvokeExpr("children[" + i + "]")));
                }

                return list;
            }
        }

        public string[] AttributeNames
        {
            get {
                var res = Invoke("getAttributeNames()");
                return res.Length > 0 ? res.Split(',') : new string[0];
            }
        }

        public string GetAttribute(string name)
        {
            return Invoke("getAttribute(\"" + name + "\")");
        }

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
