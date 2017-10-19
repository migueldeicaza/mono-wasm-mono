using System;
using System.Collections.Generic;

namespace Mono.WebAssembly
{
    public class HtmlElement : HtmlNode
    {
        internal HtmlElement(string expr) : base(expr) {}
        internal HtmlElement(int reference) : base(reference) {}

        internal static List<HtmlElement>
            ListFromReferences(string[] references)
        {
            var list = new List<HtmlElement>();

            foreach (var reference in references) {
                list.Add(new HtmlElement(Int32.Parse(reference)));
            }

            return list;
        }

        internal static HtmlElement ElementOrNull(string expr)
        {
            int reference = WrapExpr(expr);
            if (reference == -1) {
                return null;
            }
            return new HtmlElement(reference);
        }

        public string Id
        { 
            get { 
                return Invoke("id");
            }
            set {
                Invoke("id = \"" + value + "\"");
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
                return ElementOrNull(InvokeExpr("parentElement"));
            }
        }

        public List<HtmlElement> Children
        {
            get {
                var references = InvokeArray("children", true);

                return HtmlElement.ListFromReferences(references);
            }
        }

        public void AppendChild(HtmlElement e)
        {
            InvokeWithArg("appendChild({0})", e);
        }

        public void RemoveChild(HtmlElement e)
        {
            InvokeWithArg("removeChild({0})", e);
        }

        public string[] AttributeNames
        {
            get {
                return InvokeArray("getAttributeNames()", false);
            }
        }

        public string GetAttribute(string name)
        {
            return Invoke("getAttribute(\"" + name + "\")");
        }

        public void SetAttribute(string name, string value)
        {
            Invoke("setAttribute(\"" + name + "\", \"" + value + "\")");
        }

        public void RemoveAttribute(string name)
        {
            Invoke("removeAttribute(\"" + name + "\")");
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
