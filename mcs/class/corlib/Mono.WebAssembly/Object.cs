using System;
using System.Collections.Generic;

namespace Mono.WebAssembly
{
    public abstract class Object
    {
        private int InternalReference;

        static internal int WrapExpr(string expr)
        {
            var res = Runtime.JavaScriptEval("mono_wasm_wrap_obj(" + expr
                    + ")");
            return res == "undefined" ? -1 : Int32.Parse(res);
        }

        internal Object(string expr)
        {
            InternalReference = WrapExpr(expr);
        }

        internal Object(int reference)
        {
            InternalReference = reference;
        }

        protected string UnwrapExpr()
        {
            return "mono_wasm_unwrap_obj(" + InternalReference + ")";
        }

        protected string InvokeExpr(string expr)
        {
            return UnwrapExpr() + "." + expr;
        }

        protected string Invoke(string expr)
        {
            return Runtime.JavaScriptEval(InvokeExpr(expr));
        }

        protected string[] InvokeArray(string expr, bool wrap_objects)
        {
            string invoke_expr = wrap_objects
                ? ("Array.from(" + InvokeExpr(expr)
                        + ").map(mono_wasm_wrap_obj)")
                : InvokeExpr(expr); 

            var res = Runtime.JavaScriptEval(invoke_expr);

            return res.Length > 0 ? res.Split(',') : new string[0];
        }

        protected string InvokeWithArg(string expr_fmt, Object arg)
        {
            var expr = System.String.Format(expr_fmt, arg.UnwrapExpr());
            return Invoke(expr);
        }

        public override bool Equals(System.Object obj) 
        {
            if (obj == null || GetType() != obj.GetType())  {
                return false;
            }
            return InternalReference == (obj as Object).InternalReference;
        }

        public override int GetHashCode()
        {
            return InternalReference;
        }

    }
}
