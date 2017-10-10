using System;

namespace Mono.WebAssembly
{
    public class HtmlPage
    {
        public static BrowserInformation BrowserInformation
        {
            get {
                return new BrowserInformation() {
                    Name = Runtime.JavaScriptEval("navigator.appName"),
                    BrowserVersion = Runtime.JavaScriptEval("navigator.appVersion"),
                    UserAgent = Runtime.JavaScriptEval("navigator.userAgent"),
                    Platform = Runtime.JavaScriptEval("navigator.platform"),
                    CookiesEnabled = Runtime.JavaScriptEval("navigator.cookieEnabled") == "true",
                    ProductName = Runtime.JavaScriptEval("navigator.appCodeName")
                };
            }
        }

        public static HtmlWindow Window
        {
            get {
                return new HtmlWindow("window");
            }
        }
    }
}
