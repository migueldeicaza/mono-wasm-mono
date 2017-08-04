/**
 * \file
 *
 * Copyright 2017 Microsoft Corporation.
 *
 * Licensed under the MIT license. See LICENSE file in the project root for full license information.
 */

#include <config.h>
#include <glib.h>
#include <mono/metadata/appdomain.h>
#include <mono/utils/w32api.h>

void
mono_console_init (void)
{
}

MonoBoolean
ves_icall_System_ConsoleDriver_Isatty (HANDLE handle)
{
	return TRUE;
}

MonoBoolean
ves_icall_System_ConsoleDriver_SetEcho (MonoBoolean want_echo)
{
	return TRUE;
}

MonoBoolean
ves_icall_System_ConsoleDriver_SetBreak (MonoBoolean want_break)
{
	return TRUE;
}

gint32
ves_icall_System_ConsoleDriver_InternalKeyAvailable (gint32 timeout)
{
	return 0;
}

MonoBoolean
ves_icall_System_ConsoleDriver_TtySetup (MonoString *keypad, MonoString *teardown, MonoArray **control_chars, int **size)
{
	return TRUE;
}
