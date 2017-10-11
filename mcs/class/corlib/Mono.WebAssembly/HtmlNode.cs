using System;
using System.Collections.Generic;

namespace Mono.WebAssembly
{
    public abstract class HtmlNode : Object
    {
        public HtmlNode(string expr) : base(expr) {}
        public HtmlNode(int reference) : base(reference) {}

        public List<HtmlElement> GetElementsByTagName(string name)
        {
            var references = InvokeArray("getElementsByTagName(\"" + name
                    + "\")", true);

            return HtmlElement.ListFromReferences(references); 
        }

        public List<HtmlElement> GetElementsByClassName(string name)
        {
            var references = InvokeArray("getElementsByClassName(\"" + name
                    + "\")", true);

            return HtmlElement.ListFromReferences(references); 
        }
    }
}
