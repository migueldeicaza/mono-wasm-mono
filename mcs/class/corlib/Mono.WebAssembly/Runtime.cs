using System;
using System.Runtime.CompilerServices;

namespace Mono.WebAssembly
{
    public class Runtime
    {
        [MethodImplAttribute (MethodImplOptions.InternalCall)]
        public static extern string JavaScriptEval (string expr);
    }
}
