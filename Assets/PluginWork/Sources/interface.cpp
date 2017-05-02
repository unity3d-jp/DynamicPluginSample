#include <stdio.h>
#include <math.h>
#include "interface.hpp"

extern "C" {

float
foo(float value)
{
	return value * 3.0f;
}

} // extern "C" {
/*
 * End of interface.cpp
 */
