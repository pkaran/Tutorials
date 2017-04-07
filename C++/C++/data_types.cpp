#include<iostream>
#include<climits>

using std::cout;


void data_types()
{
	/*
	TOPIC : Integers (short, int, long, long long)

	A short integer is at least 16 bits wide.
	An int integer is at least as big as short.
	A long integer is at least 32 bits wide and at least as big as int.
	A long long integer is at least 64 bits wide and at least as big as long

	the climits header file (or, for older implementations, the limits.h header file)
	contains information about integer type limits.
	*/
	
	//1 byte = 8 bits on most system (use climits.h to find out since 1 byte may not equal to 8 bits on every system)
	cout << "Bits per pyte = " << CHAR_BIT << "\n";

	cout << "long long size (in bytes) = " << sizeof(long long) << ", min = " << LLONG_MIN
		<< ", max = " << LLONG_MAX;

	/*
	If you don’t initialize a variable that is defined inside a function, the variable’s value is
	indeterminate (unknown). That means the value is whatever happened to be sitting at that memory
	location prior to the creation of the variable.

	Using uninitialized local variables is an error !!!
	*/
	unsigned int a;		//each of the 4 int types can be unsigned 

	//cout << "\nValue of a which is undefined inside a function = " << a;	// this will cause error

	/*
	TOPIC : Overflow and underflow

	The exact behavior on overflow/underflow is only specified for unsigned types.
	For normal signed integer types instead the C++ standard simply says than anything can happen.

	For unsigned types, overflow and underflow leads to following value:
	overflow_underflow_value mod range,  where range is 2 ^ 16 for a 2 byte (16 bits) short
	*/

	short sh = SHRT_MAX;		// Maximum short value (SHRT_MAX is defined in climits)
	unsigned short ush = 0;

	cout << "\nshort = " << sh << ", unsigned short = " << ush;
	sh += 1;
	ush -= 1;
	cout << "\nshort = " << sh << ", unsigned short = " << ush;

	/*
	TOPIC : Literals

	Leading 0x or 0X hexadeciaml (base 16)
	If the first digit is 0 and the second digit is in the range 1–7, the number is base 8 (octal)

	cout << "Number is " << 32;

	In the statement above, 32 is stored as an int.

	A decimal integer without a suffix (like 32 in example above) is represented by the smallest of the following 
	types that can hold it: int, long, or long long. On a computer system using a 16-bit int and a 32-bit long, 
	20000 is represented as type int, 40000 is represented as long, and 3000000000 is represented as long long.

	int a = 131L;	//long
	int b = 131UL;	// unsigned long
	int c = 131LL;	// long long
	int d = 232ULL;	// unsigned long long

	A hexadecimal or octal integer without a suffix is represented by the smallest
	of the following types that can hold it: int, unsigned int, long, unsigned long, long
	long, or unsigned long long.The same computer system that represents 40000 as long
	represents the hexadecimal equivalent 0x9C40 as an unsigned int.That’s because hexadecimal is 
	frequently used to express memory addresses, which intrinsically are unsigned.
	So unsigned int is more appropriate than long for a 16-bit address
	*/

	ush = 42;

	cout << std::hex;	//hex is a part of namespace std and so are dec and oct
	cout << "\n42 in hex is " << ush;
	cout << std::dec;

	/*
	TOPIC : char type

	char type is another integer type. It’s guaranteed to be large enough to represent the entire
	range of basic symbols—all the letters, digits, punctuation, and the like—for the target
	computer system.
	*/

	//chars can be represented using their base 10 or base 16 representation
	//Example, '\n' can be represented as '\10'
	cout << '\x7' ;		//7 (dec)  0x7 - codes for \a (alert)    NOTE : '\a' is same as '\x7

	cout << "\nEnter 2 digit number = __\b\b";		// '\b' moves cursor one char back

	cout << "Year = " << 1213;	//1213 (literal) is an int constant by default.
	cout << "Year = " << 1213l;	//An l or L suffix on an integer means the integer is a type long constant,
	cout << "Year = " << 999999999999999999;	//a u or U suffix indicates an unsigned int constant
	//NOTE : No need to explicitly add an 'll' or 'l' behind a large constant. 
	//Constants will be represented with type which fits best (int, long, long long)
	/*
	A hexadecimal or octal integer without a suffix is represented by the smallest
	of the following types that can hold it: int, unsigned int, long, unsigned long, long
	long, or unsigned long long.

	A decimal integer without a suffix is represented by the smallest of the following types that can hold it: int,
	long, or long long.
	*/

	//TOPIC : Boolean

	bool b = 11;		// any non-zero number is true
	bool bb = 0;	   // 0 is false

	b = false;
	b = true;

	// ToPIC : constants

	/*
	If your background is in C, you might feel that the #define statement, which is discussed earlier, 
	already does the job adequately. But const is better. For one thing, it lets you specify the type explicitly. 
	Second, you can use C++’s scoping rules to limit the definition to particular functions or files.
	Third, you can use const with more elaborate types, such as arrays and structures,
	*/

	const int Month = 12;		// const values cannot be changed once assigned. First letter of constants are capital

	/*
	TOPIC : float

	main points are that floating-point numbers let you represent fractional, very large, and
	very small values
	*/

	float a = 1.1f;
	a = 3.45E-6;		// a = 3.45 * 10 ^ -6  [scientific form]

	double b = 121.1;
	long double c = 12.1l;

	/*
	In effect, the C and C++ requirements for significant digits amount to float being at
	least 32 bits, double being at least 48 bits and certainly no smaller than float, and long
	double being at least as big as double.All three can be the same size.Typically, however,
	float is 32 bits, double is 64 bits, and long double is 80, 96, or 128 bits.Also the range
	in exponents for all three types is at least –37 to +37.You can look in the cfloat or
	float.h header files to find the limits for your system. (cfloat is the C++ version of the
	C float.h file.)

	2.45E20F // a float constant
	2.345324E28 // a double constant
	2.2L // a long double constant
	*/

}