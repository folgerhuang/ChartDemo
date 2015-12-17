/*
 * MATLAB Compiler: 5.1 (R2014a)
 * Date: Mon Aug 31 17:01:39 2015
 * Arguments: "-B" "macro_default" "-B" "csharedlib:mymagic" "-W" "lib:mymagic"
 * "-T" "link:lib" "mymagic.m" "-C" 
 */

#ifndef __mymagic_h
#define __mymagic_h 1

#if defined(__cplusplus) && !defined(mclmcrrt_h) && defined(__linux__)
#  pragma implementation "mclmcrrt.h"
#endif
#include "mclmcrrt.h"
#ifdef __cplusplus
extern "C" {
#endif

#if defined(__SUNPRO_CC)
/* Solaris shared libraries use __global, rather than mapfiles
 * to define the API exported from a shared library. __global is
 * only necessary when building the library -- files including
 * this header file to use the library do not need the __global
 * declaration; hence the EXPORTING_<library> logic.
 */

#ifdef EXPORTING_mymagic
#define PUBLIC_mymagic_C_API __global
#else
#define PUBLIC_mymagic_C_API /* No import statement needed. */
#endif

#define LIB_mymagic_C_API PUBLIC_mymagic_C_API

#elif defined(_HPUX_SOURCE)

#ifdef EXPORTING_mymagic
#define PUBLIC_mymagic_C_API __declspec(dllexport)
#else
#define PUBLIC_mymagic_C_API __declspec(dllimport)
#endif

#define LIB_mymagic_C_API PUBLIC_mymagic_C_API


#else

#define LIB_mymagic_C_API

#endif

/* This symbol is defined in shared libraries. Define it here
 * (to nothing) in case this isn't a shared library. 
 */
#ifndef LIB_mymagic_C_API 
#define LIB_mymagic_C_API /* No special import/export declaration */
#endif

extern LIB_mymagic_C_API 
bool MW_CALL_CONV mymagicInitializeWithHandlers(
       mclOutputHandlerFcn error_handler, 
       mclOutputHandlerFcn print_handler);

extern LIB_mymagic_C_API 
bool MW_CALL_CONV mymagicInitialize(void);

extern LIB_mymagic_C_API 
void MW_CALL_CONV mymagicTerminate(void);



extern LIB_mymagic_C_API 
void MW_CALL_CONV mymagicPrintStackTrace(void);

extern LIB_mymagic_C_API 
bool MW_CALL_CONV mlxMymagic(int nlhs, mxArray *plhs[], int nrhs, mxArray *prhs[]);



extern LIB_mymagic_C_API bool MW_CALL_CONV mlfMymagic(int nargout, mxArray** y, mxArray* x);

#ifdef __cplusplus
}
#endif
#endif
