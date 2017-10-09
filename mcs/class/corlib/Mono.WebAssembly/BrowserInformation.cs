using System;

namespace Mono.WebAssembly
{
    public class BrowserInformation
    {
        public string Name { get; internal set; }
        public string BrowserVersion { get; internal set; }
        public string UserAgent { get; internal set; }
        public string Platform { get; internal set; }
        public bool CookiesEnabled { get; internal set; }
        public string ProductName { get; internal set; }
    }
} 
