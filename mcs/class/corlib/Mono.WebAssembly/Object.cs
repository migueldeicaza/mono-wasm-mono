using System;

namespace Mono.WebAssembly
{
    public abstract class Object
    {
        private string InternalReference;

        public Object(string expr)
        {
            InternalReference = Runtime.JavaScriptEval("mono_wasm_wrap_obj(" + expr + ")");
        }

        protected string InvokeExpr(string expr)
        {
            return "mono_wasm_unwrap_obj(" + InternalReference + ")." + expr;
        }

        protected string Invoke(string expr)
        {
            return Runtime.JavaScriptEval(InvokeExpr(expr));
        }
    }
}
