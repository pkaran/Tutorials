//the preprocessor directive below causes the preprocessor to replace the line below with contents of iostream file
#include <iostream> // a PREPROCESSOR directive
#include "main.h"
/*
Files such as iostream are called include files (because they are included in other files) or
header files (because they are included at the beginning of a file). See OneNote section "Header Files" for more details
*/

//preprocessor repaces symbolic constants (such as CON below) during preprocessing
#define CON	"\nthis is a string constant"

/*
TOPIC : Function header

A C++ program should provide a prototype for each function used in the program
A function prototype does for functions what a variable declaration does for variables:
It tells what types are involved i.e. return type and types of arguments
*/

//int function(int);

/*
function definition = function header + function body
function header is : int main()
function body is enclosed within {} brackets
*/

int function(int arg)
{
	return arg + 1;
}

//need to explicitly mention return type for a function in C++ (unlike C)
//if nothing is passed as argument/parameter, void is assumend
//main MUST have int as return type
//When you run a C++ program, execution always begins at the beginning of the main() function
int main()
{
	//use cout in std namespace
	std::cout << "Come up and C++ me some time " << function(1) << CON; // cout object represents output stream. Here, we are adding the string to the output stream

	using namespace std; // as a result of using directive, you can use names defined in the std namespace without using the "std::" prefix

	/*
	endl guarantees the output will be flushed (in, this case, immediately displayed onscreen) before the program moves on.
	You don’t get that guarantee with "\n", which means that it is possible on some systems in some circumstances a prompt might not be 
	displayed until after you enter the information being prompted for
	
	What does flushing mean ?

	When you output to a stream from your program, it does not go immediately to the file or terminal. It will be put into a buffer, where it will 
	be held until there is enough data to be worth outputting - for example, a full block to file on disk. If you are outputting to a terminal, 
	this can be disconcerting: part or all of the output may not appear, even if it was asking a question to which a reply is needed.

	Flushing the output stream forces all output to be written out, so that it is in a disk file or appears on the screen. 
	This is occasionally what is needed. But it should not be done if not needed: the buffering was for a purpose, and too much flushing can slow a 
	program down.
	*/
	cout << endl; // start a new line

	cout << "You won't regret it!" << endl; // more output

	data_types();

	cin.get();		// cin object represents input stream of characters towards the program. 
	//cin >> intVar;		//this is also possible and valid

	/*
	The return value for main should indicate how the program exited. Normal exit is generally represented by a 0 return value from main. 
	Abnormal termination is usually signalled by a non-zero return but "there is no standard for how non-zero codes are interpreted".
	*/
	//return 0;		ISO C++ Standard will implicitly provide "return 0;" at end of main function (only for main and not for any other functions !)
}

