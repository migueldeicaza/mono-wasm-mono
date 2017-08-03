/**
 * \file
 *
 * Copyright 2017 Microsoft Corporation.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 */

#ifndef __MONO_MINI_WASM32_H_
#define __MONO_MINI_WASM32_H_

#define MONO_MAX_IREGS 0
#define MONO_MAX_FREGS 0

#define MONO_ARCH_VTABLE_REG 0
#define MONO_ARCH_GSHAREDVT_SUPPORTED 1

struct MonoLMF {
    guint32 previous_lmf;
};

typedef struct {
} MonoCompileArch;

#define MONO_INIT_CONTEXT_FROM_FUNC(ctx, start_func) \
    do { \
    } while(0)

#define MONO_ARCH_INIT_TOP_LMF_ENTRY(lmf) \
    do { \
    } while(0)

#endif // __MONO_MINI_WASM32_H_
