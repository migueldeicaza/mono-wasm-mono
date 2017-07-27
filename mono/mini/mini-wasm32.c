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
