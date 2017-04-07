/*
C source code files have an extension of .c

********************************************
TOPIC: Comments
********************************************
//this is a single line comment
C also supports multiline comment (like the one in which this line is enclosed)

********************************************
TOPIC: Primitive Data Types and Literals
********************************************

!!!!NOTE: size of data types are machine dependent

****char: 1 byte, capable of holding 1 character 
ex: char c = 'A';
	char c = 65;    //since A has value 65 in ASCII character set
A character represents a character constant (such as 'A') by storing an integer value equal to the numerical value of 
character in machine's character set

For portability, specify use of char as int data as signed or unsigned.
For use of char as character, C ensures that the char is interpreted as a positive value

bit pattern representations can also be assigned to a char.Example:

char a = '\ooo' where o is one of the three octal digits (0...7) such as '\013' for vertical tab
char a = '\xhh' where h is one or more hex digits (0...9, a....f, A...F) such as '\xb' for vertical tab

***int - an integer 

varities : short int, long int		NOTE: no need to specify int keyword when using long or short
short is often 16 bits, long is often 32 bits, int is either 16 or 32 bits

each compiler is free to choose any size for short, int, long as long as they follow the following restrictions:
1. short and int are atleast 16 bits long
2. long is atleast 32 bits long
3. short is no longer than int which is no longer than long

!!!!!!!NOTE: signed [range: - 2^n to 2^n-1] and unsigned [range: 0 to 2^n] modifiers can be applied to both char as well as int types
char without any modifier can be either signed or unsigned depending on implementation

A long int is written with a l or L in the end. EX: 123456789L or 123456789l
Unsigned numbers need to have a U or u at the end.  Ex: 123456789uL or 123456789UL

integer can be specified as decimal, octal (leading 0) or hexadecimal (leading 0x or 0X).
Note: octal and hexadecimal representations can be unsigned as well by adding U or u at the end just like base 10 representation

An integer too big to fit an int will be taken as a long

float - single precision floating point 

double - double precision floating point
quantifier long can be applied before double i.e. long double which is extended precision floating point

!!!!!!!NOTE: As with ints, size of float, double as well as long double are machine dependent. 
float, double and long double can represent 1, 2 or 3 distinct sizes

floating point literals are double by default and can be written in standard (123.2) or scientific form (1.232e2)
f or F indicates a float value ex: 123.2F or 123.3f
l or L indicates a long double ex: 123.12L or 123.12l

********************************************
TOPIC: Operators
********************************************

Arithmetic operators:

+, -, *, /, % (modulus operator)
*****NOTE:   % operator cannot be applied to float or double
direction of truncation for /, sign of result for % for negative operands, overflow and underflow are machine dependent

&& and || are short circuit operators (just like java). Once truthhood is established, evaluation stops

********************************************
TOPIC: String literals
********************************************

String literal such as "hello\n" is stored as a char array containing the string itself and a "\0" to mark the end
Thus, array containing "hello\n" looks like [h e l l o \n \0]
thus, storage of string is +1 than the storage required by characters in string

********************************************
TOPIC: Initialization of variables
********************************************
Automatic variabels (i.e. variables decleared in a function) with no explicit initialization are assigned garbage (undifined) values
External and static variables are initiazlied to 0 by default
*/

/*
#include <file> : This form is used for system header files
#include "file.h" : This form is used for header files of your own program

<file> tells the compiler to look where system include files are held. Usually UNIX systems store files in  $\backslash$usr$\backslash$include$\backslash$ directory.

"file.h" looks for a file in the current directory (where program was run from)

Check out OneNote for more info
*/
#include <stdio.h>
#include "test.h"		//copy all contents of test.h into main.c

/*
********************************************
TOPIC: Preprocessor inclusion
********************************************

check out OneNote!
*/

/*
********************************************
TOPIC: macro
********************************************

macros can be used to represent any character, number or string
For example below, any occurance of STRING_CONSTANT is replaced with "anySequenceOfCharacters1"
scope of a constant is from its definition to end of the source file
*/
#define STRING_CONSTANT "anySequenceOfCharacters" ", including 1" \
						"this is continuation of STRING_CONSTANT" //strings are concatnated during compile time, place \ at end for multiline macro
						
#define NUMERIC_CONSTANT -2121.42
#define CHARACTER_CONSTANT '1'

//The other major use of the preprocessor is to define macros. The advantage of a macro is that it can be type-neutral (this can also be a disadvantage, of course), 
//and it's inlined directly into the code, so there isn't any function call overhead.

#define forever for(;;)
#define max(A, B) ((A) > (B) ? (A) : (B))	//macro with arguments, any type of argument will work so long as they are consistent
//for above macro, we can use it like this: x = max(p+q, r+s); the preprocessor will replace x = max(p+q, r+s) with x = ((p+q) > (r+s) ? (p+q) : (r+s))

/*
Tips for using macros correctly:

#define MULT(x, y) x * y
int z = MULT(3 + 2, 4 + 2);     // this will be evaluated as 3 + 2 * 4 + 2;
Thus, use brackets for arguments so that if an expression is given, it is evaluated first and then the specified operation is performed
Correct use:
#define MULT(x, y) (x) * (y)
// now MULT(3 + 2, 4 + 2) will expand to (3 + 2) * (4 + 2)

#define ADD_FIVE(a) (a) + 5
int x = ADD_FIVE(3) * 3;
// this expands to (3) + 5 * 3, so 5 * 3 is evaluated first
// Now x is 18, not 24!
Correct use:
#define ADD_FIVE(a) ((a) + 5)

********************************************
TOPIC: #undef
********************************************
The #undef directive undefines a constant or preprocessor macro defined previously using #define.
A macro must be undefined before being redefined to a different value.

Example:

#define E 2.71828
int e_squared = E * E;
#undef E

Usually, #undef is used to scope a preprocessor constant into a very limited region--this is done to avoid leaking the constant 
(for example, changing a single letter like E would be dangerous across a large program, but in a short scope, it is comparatively safe. 
#undef is the only way to create this scope since the preprocessor does not understand block scopes defined with { and }.

********************************************
TOPIC: using macros for debugging
********************************************
#define dpirnt(expr)    printf(#expr " = %g\n", expr)
invoked as dprint(x\y);     will be expanded to printf("x/y" " = %g\n", x/y);
*/

/*
********************************************
TOPIC: enumeration constant
********************************************

enumeration constant is a list of constant integer values.
first constant gets a value of 0 by default
Only constant integers can be stored !!
Cannot have two constants with same name in one enum
*/
enum boolean {NO, YES};		//NO has value 0 and YES has value 1 and so on
enum escape {BELL = '\a', TAB = '\t'};		//chars are stored as constant int values
enum months{JAN = 1, FEB, MAR};		//jan is 1, feb is 2, mar is 3
									// Changing default values of enum elements
enum thisIsPossible{can =20, assign = 23, any = 22312, numbers = 2121, to = 232, constants = 32323};

/*
********************************************
TOPIC: External Variable
********************************************

//storage is set aside for all external variables
//external variables can be accessed by any function:
//if external variable is defined(as below) in the same source file and before its use in a function, then there is no need to use extern keyword
//if external variable is used in a function residing in a file which is different from the file where external variable is defined,
//explicit keyword must be used ex :

//f() is in a file different from the file where thisIsAnExternalVariable is defined
void f(){

	extern int thisIsAnExternalVariable;
}

external variables (including arrays) are implicitly initialized to 0 by default
*/
int thisIsAnExternalVariable;			//assigned a value of 0 by default
//all elements are initialized to 0, char array will be intialized to '\0' (i.e. all elementswill be \0)
int thisIsAnExternalArray[10];			//need to assign a size except when declearing with extern i.e. extern int thisIsAnExternalIntArray[]; like below:

extern int thisIsAnExternalIntArray[];

//********************************************
//TOPIC: function prototypes/decleration
//********************************************
/*
function prototypes below, they should be before a function which makes a call to the corresponding prototyped functions
if the function definition appears before any calls, you can omit the separate declaration (prototype); the definition itself acts as a declaration.
*/
void control_statements();
int read_next_character_from_text_stream();
void print_int_as_char();
void read_from_file();
void arraysDemo(const int this_is_a_formal_argument);
void type_conversion_casting();

//execution of a program begins with function called main
//if no return type is mentioned, int is assumed
//argc is command line arguments counter
//argv is 
void main(int argc, char *argv[]){ 

	printf("Storage size for int : %d \n", sizeof(int));

	arraysDemo(2);

	//multiple variable decleration
	int a = 1, b = 2, c = 3, d;			//d is given a garbage value, d cannot be used without being initialized

	//********************************************
	//TOPIC: constant variables - can be used with variables and arrays
	//********************************************
	const double PI = 3.14;			//value of PI cannot be changed since it is a constant
	const char msg[] = "warning";	//elements of array cannot be altered

	//test_external_var is visible only after the decleration below even if it is defined below main
	extern int test_external_var;

	//library function printf is called by main
	//test_extern is in test.h, no need to use extern to access global variables in .h files
	printf("%s : %i\n", STRCONST, test_extern);

	test();

	control_statements();
}

//test_external_var is invisible to functions above (like main)
//in order for the functions above to access it, there has to be an extern decleration in that function
int test_external_var;

//formal parameters are the one's in the function definition, ex : this_is_a_formal_argument below
//actual parameters are the one's passed on to a function call
//example: int actual_para = 2; arraysDemo(actual_para); where actual_para is an actual argument 
//NOTE : EVERY argument (of any type) is passed by value
//NOTE: int C, unlike java, array notation is int a[]; and NOT int []a;
//local arrays NEED to be initialized, otherwise they are intialized to undefined (garbage) values
void arraysDemo(const int this_is_a_formal_argument) {

	//declearing array of 10 ints
	int z[10] = {1, 2, 3};		//remaining elements will be assigned 0
	int f[] = { 2,3,4,5,4 };	//no need to specify size

	//int i[];		Need to specify size

	for (int i = 0; i < 10; i++)
	{
		//z[i] = i;	//initializing all ints in array to index number
		printf("z[%i] = %i, thisIsAnExternalArray[%i] = %i\n", i, z[i], i, thisIsAnExternalArray[i]);
	}

	//********************************************
	//TOPIC: Multi dimensional array
	//********************************************

	int a[3][4] = {
		{ 0, 1, 2, 3 } ,   /*  initializers for row indexed by 0 */
		{ 4, 5, 6, 7 } ,   /*  initializers for row indexed by 1 */
		{ 8, 9, 10, 11 }   /*  initializers for row indexed by 2 */
	};

	//array below and up are the same
	int sameAs_a_[3][4] = { 0,1,2,3,4,5,6,7,8,9,10,11 };

	//arrays are contiguous in memory. Above array is stored as "01234567891011" where 0 is at &a[0][0]

	char test[1][5];
	//test[0] = "heyt";		//cannot do this, multidimensional array of chars cannot hold strings. Only characters !
}

void type_conversion_casting() {

	int i = 1;

	//automatic conversion takes place when a narrower data type is converted into a wider data type such that no information loss occurs
	float f = i;

	//expressions that might loose values such as assiging a longer int type to a shorter one or assiging a foat to int might draw an error message but are not illegal
	i = f;
}

void control_statements() 
{
	int a, b = 3, c = 4;
	a = (b > c) ? b : c;	//b and c shall be of the same type, if not, type conversion will take place if possible

	//no need for {} if only one statement
	if (0) printf("This will never print");
	else if(1) printf("This will print\n");
	else printf("This will never print");

	//a null statement is fine
	if (1);

	/*
	The expression used in a switch statement must have an integral or enumerated type, or be of a class type in which the class has a single conversion 
	function to an integral or enumerated type.

	NOTE: control flow falls through to other cases (even if they have untrue case values) if no break statement is present in the true switch statement
	*/
	switch (1)
	{
	case 1:
		printf("This will print\n");
		//break;
	case 2:									//NOTE: case 2 and (all cases below) will be executed since no break statement is in case 1
		printf("This will not print if break is present in case 1");
		//break;
	default:
		printf("This default statement will not print if break is present in case 2");

		//for, while, do while, break and continue statements same as Java

		for (int a = 2, b = 3;;a++ , b++) {

			//neevr ending loop since second expression is always taken as true
		}

		do {
			//never ending do while loop
		} while (1);

		
		//labels and goto statement structure:

		/*
		goto label;

		label:
		//code
		*/
		
		//Upon execution, a goto statement causes the program to continue on the line following the label statement, 
		//so long as the label is within the same scope as the goto statement. (You cannot, for instance, jump into the middle of a function from a different 
		//function by using goto.) The use of goto is frowned on in most instances because it is conducive to spaghetti code; however, it can be useful for 
		//escaping from multiple embedded loops or cleanly handling errors in one place.
		
	}
}

//********************************************
//TOPIC: block structure
//********************************************
void blockDemo() {

	int i = 3;

	{
		int i = 3;
	}

	printf("test() from main.c");
}

//utility functions

int read_next_character_from_text_stream()
{
	//getchar reads the next character in input stream and returns it as an int
	return getchar();
}

void print_int_as_char()
{
	while (1)
	{
		int c = getchar();
		//putchar prints an integer as character
		putchar(c);
	}
}

void read_from_file()
{
	//we use int instead of char since we need to hold all characters as well as EOF
	int c;

	//EOF is an integer constant defined in <stdio.h> and is returned when there is no more input
	while (c = getchar() != EOF)
	{
		putchar(c);
	}
}