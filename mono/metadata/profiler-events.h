/*
 * Licensed to the .NET Foundation under one or more agreements.
 * The .NET Foundation licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
 */

/*
 * To #include this file, #define the following macros first:
 *
 * MONO_PROFILER_EVENT_0(name, type)
 * MONO_PROFILER_EVENT_1(name, type, arg1_type, arg1_name)
 * MONO_PROFILER_EVENT_2(name, type, arg1_type, arg1_name, arg2_type, arg2_name)
 * MONO_PROFILER_EVENT_3(name, type, arg1_type, arg1_name, arg2_type, arg2_name, arg3_type, arg3_name)
 * MONO_PROFILER_EVENT_4(name, type, arg1_type, arg1_name, arg2_type, arg2_name, arg3_type, arg3_name, arg4_type, arg4_name)
 *
 * To add new callbacks to the API, simply add a line in this file and use
 * MONO_PROFILER_RAISE to raise the event wherever. If you need more arguments
 * then the current macros provide, add another macro and update all areas
 * where the macros are used.
 */

MONO_PROFILER_EVENT_0(runtime_initialized, RuntimeInitialized)
MONO_PROFILER_EVENT_0(runtime_shutdown_begin, RuntimeShutdownBegin)
MONO_PROFILER_EVENT_0(runtime_shutdown_end, RuntimeShutdownEnd)

MONO_PROFILER_EVENT_1(context_loaded, ContextLoaded, MonoAppContext *, context)
MONO_PROFILER_EVENT_1(context_unloaded, ContextUnloaded, MonoAppContext *, context)

MONO_PROFILER_EVENT_1(domain_loading, DomainLoading, MonoDomain *, domain)
MONO_PROFILER_EVENT_1(domain_loaded, DomainLoaded, MonoDomain *, domain)
MONO_PROFILER_EVENT_1(domain_unloading, DomainUnloading, MonoDomain *, domain)
MONO_PROFILER_EVENT_1(domain_unloaded, DomainUnloaded, MonoDomain *, domain)
MONO_PROFILER_EVENT_2(domain_name, DomainName, MonoDomain *, domain, const char *, name)

MONO_PROFILER_EVENT_1(jit_begin, JitBegin, MonoMethod *, method)
MONO_PROFILER_EVENT_1(jit_failed, JitFailed, MonoMethod *, method)
MONO_PROFILER_EVENT_2(jit_done, JitDone, MonoMethod *, method, MonoJitInfo *, jinfo)
MONO_PROFILER_EVENT_2(jit_chunk_created, JitChunkCreated, const mono_byte *, chunk, uintptr_t, size)
MONO_PROFILER_EVENT_1(jit_chunk_destroyed, JitChunkDestroyed, const mono_byte *, chunk)
MONO_PROFILER_EVENT_4(jit_code_buffer, JitCodeBuffer, const mono_byte *, buffer, uint64_t, size, MonoProfilerCodeBufferType, type, const void *, data)

MONO_PROFILER_EVENT_1(class_loading, ClassLoading, MonoClass *, klass)
MONO_PROFILER_EVENT_1(class_failed, ClassFailed, MonoClass *, klass)
MONO_PROFILER_EVENT_1(class_loaded, ClassLoaded, MonoClass *, klass)

MONO_PROFILER_EVENT_1(image_loading, ModuleLoading, MonoImage *, image)
MONO_PROFILER_EVENT_1(image_failed, ModuleFailed, MonoImage *, image)
MONO_PROFILER_EVENT_1(image_loaded, ModuleLoaded, MonoImage *, image)
MONO_PROFILER_EVENT_1(image_unloading, ModuleUnloading, MonoImage *, image)
MONO_PROFILER_EVENT_1(image_unloaded, ModuleUnloaded, MonoImage *, image)

MONO_PROFILER_EVENT_1(assembly_loading, AssemblyLoading, MonoAssembly *, assembly)
MONO_PROFILER_EVENT_1(assembly_loaded, AssemblyLLoaded, MonoAssembly *, assembly)
MONO_PROFILER_EVENT_1(assembly_unloading, AssemblyLUnloading, MonoAssembly *, assembly)
MONO_PROFILER_EVENT_1(assembly_unloaded, AssemblyLUnloaded, MonoAssembly *, assembly)

MONO_PROFILER_EVENT_1(method_enter, MethodEnter, MonoMethod *, method)
MONO_PROFILER_EVENT_1(method_leave, MethodLeave, MonoMethod *, method)
MONO_PROFILER_EVENT_2(method_exception_leave, MethodExceptionLeave, MonoMethod *, method, MonoObject *, exception)
MONO_PROFILER_EVENT_1(method_free, MethodFree, MonoMethod *, method)
MONO_PROFILER_EVENT_1(method_begin_invoke, MethodBeginInvoke, MonoMethod *, method)
MONO_PROFILER_EVENT_1(method_end_invoke, MethodEndInvoke, MonoMethod *, method)

MONO_PROFILER_EVENT_1(exception_throw, ExceptionThrow, MonoObject *, exception)
MONO_PROFILER_EVENT_4(exception_clause, ExceptionClause, MonoMethod *, method, uint32_t, index, MonoExceptionEnum, type, MonoObject *, exception)

MONO_PROFILER_EVENT_2(gc_event, GCEvent, MonoProfilerGCEvent, event, uint32_t, generation)
MONO_PROFILER_EVENT_1(gc_allocation, GCAllocation, MonoObject *, object)
MONO_PROFILER_EVENT_2(gc_moves, GCMoves, MonoObject *const *, objects, uint64_t, count)
MONO_PROFILER_EVENT_1(gc_resize, GCResize, uintptr_t, size)
MONO_PROFILER_EVENT_3(gc_handle_created, GCHandleCreated, uint32_t, handle, MonoGCHandleType, type, MonoObject *, object)
MONO_PROFILER_EVENT_2(gc_handle_deleted, GCHandleDeleted, uint32_t, handle, MonoGCHandleType, type)
MONO_PROFILER_EVENT_0(gc_finalizing, GCFinalizing)
MONO_PROFILER_EVENT_0(gc_finalized, GCFinalized)
MONO_PROFILER_EVENT_1(gc_finalizing_object, GCFinalizingObject, MonoObject *, object)
MONO_PROFILER_EVENT_1(gc_finalized_object, GCFinalizedObject, MonoObject *, object)

/*
 * This callback provides very low quality data and doesn't really match how
 * roots are actually handled in the runtime. It will be replaced with a more
 * sensible callback in the future. **This will be a breaking change.**
 *
 * In the meantime, you must define MONO_PROFILER_UNSTABLE_GC_ROOTS to be able
 * to use this interface.
 */
#ifdef MONO_PROFILER_UNSTABLE_GC_ROOTS
MONO_PROFILER_EVENT_4(gc_roots, GCRoots, MonoObject *const *, roots, const MonoProfilerGCRootType *, types, const uintptr_t *, extra, uint64_t, count)
#endif

MONO_PROFILER_EVENT_1(monitor_contention, MonitorContention, MonoObject *, object)
MONO_PROFILER_EVENT_1(monitor_failed, MonitorFailed, MonoObject *, object)
MONO_PROFILER_EVENT_1(monitor_acquired, MonitorAcquired, MonoObject *, object)

MONO_PROFILER_EVENT_1(thread_started, ThreadStarted, uintptr_t, tid)
MONO_PROFILER_EVENT_1(thread_stopped, ThreadStopped, uintptr_t, tid)
MONO_PROFILER_EVENT_2(thread_name, ThreadName, uintptr_t, tid, const char *, name)

MONO_PROFILER_EVENT_2(sample_hit, SampleHit, const mono_byte *, ip, const void *, context)

MONO_PROFILER_EVENT_3(iomap_report, IOMap, const char *, report, const char *, old_path, const char *, new_path)
