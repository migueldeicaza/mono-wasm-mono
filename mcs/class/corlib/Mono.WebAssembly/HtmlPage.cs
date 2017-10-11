using System;

namespace Mono.WebAssembly
{
    public class HtmlPage
    {
        public static BrowserInformation BrowserInformation
        {
            get {
                return new BrowserInformation("navigator");
            }
        }

        public static HtmlWindow Window
        {
            get {
                return new HtmlWindow("window");
            }
        }

        public static HtmlDocument Document
        {
            get {
                return new HtmlDocument("document");
            }
        }
    }
}
