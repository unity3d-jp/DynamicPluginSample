#ifndef	PLUGINSOURCES_TYPES_H_WED_JAN_25_09_48_02_2017
#define	PLUGINSOURCES_TYPES_H_WED_JAN_25_09_48_02_2017

#if defined(_WIN32) || defined(_WIN64)
#  include <cstdint>
#else
#  include <stdint.h>
#endif

#if defined(_WIN32) || defined(_WIN64) || defined(_PS4) || defined(_PSVITA)
#  define DLLAPI extern __declspec(dllexport)
#else
#  define DLLAPI extern
#endif

#endif	/* PLUGINSOURCES_TYPES_H_WED_JAN_25_09_48_02_2017 */
