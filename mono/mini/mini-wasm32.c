/**
 * \file
 *
 * Copyright 2017 Microsoft Corporation.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 */

#include "mini.h"

void
mono_arch_init (void)
{
}

void
mono_arch_cpu_init (void)
{
}

guint32
mono_arch_cpu_optimizations (guint32 *exclude_mask)
{
	return 0;
}

void
mono_arch_finish_init (void)
{
}

void
mono_arch_register_lowlevel_calls (void)
{
}

char *mono_wasm_js_eval_imp (const char *expr, int *exception_raised);

MonoString *
mono_wasm_js_eval (MonoString *expr)
{
    const char *expr_str = mono_string_to_utf8 (expr);
    int exception_raised = 0;
    char *res = mono_wasm_js_eval_imp (expr_str, &exception_raised);
    g_assert (res != NULL);

    MonoString *mono_res = NULL;
    if (exception_raised == 1) {
        char msg[1000];
        snprintf (msg, sizeof (msg),
                "Given expression `%s' could not be evaluated: %s", expr_str,
                res);
        mono_set_pending_exception (mono_get_exception_argument ("expr", msg));
    }
    else {
        mono_res = mono_string_new (mono_domain_get (), res);
    }
    free (res);
    return mono_res;
}
