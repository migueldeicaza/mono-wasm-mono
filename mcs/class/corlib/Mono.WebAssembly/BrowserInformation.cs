using System;

namespace Mono.WebAssembly
{
    public class BrowserInformation : Object
    {
        internal BrowserInformation(string expr) : base(expr) {}

        public string Name
        {
            get {
                return Invoke("appName");
            }
        }

        public string BrowserVersion
        {
            get {
                return Invoke("appVersion");
            }
        }

        public string UserAgent
        {
            get {
                return Invoke("userAgent");
            }
        }

        public string Platform
        {
            get {
                return Invoke("platform");
            }
        }

        public bool CookiesEnabled
        {
            get {
                return Invoke("cookieEnabled") == "true";
            }
        }

        public string ProductName
        {
            get {
                return Invoke("appCodeName");
            }
        }
    }
} 
