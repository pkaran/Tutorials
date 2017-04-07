//********************************************
//TOPIC: Static variables and fucntions
//********************************************

/*
static variables can only be accessed by functions in this file
they cannot be accessed in any other file

In C, a variable that is stored statically is assigned an address at build time. It is, therefore, always safe to use a pointer to such a variable.

static vars are initialized to 0 be default

a variable with same name can be defined in other file without any conflict !
*/
static int thisIsAStaticVar = 323;

/*
a static function is invisible in any outside file

a function with same name can be defined in other file without any conflict !
*/
void static staticFuction() {

	/*
	a static variable inside a function never goes out of existance even after the function call is over
	it continues to exist even after a function call
	thus, it provides a permanenent private storage for the function it is defined in

	static vars are initialized only once when the block (fucntion in this case) is entered the first time
	*/
	static int thisIsAStaticAutomaticVariable = 2;

	printf("From staticFuction() in main2.c");
}

void test()
{
	int test_extern = 21;

	printf("From test() which is defined in main2.c and decleared in test.h %i", thisIsAStaticVar);
}

/*
********************************************
TOPIC : Register variables
********************************************
register vars are to be placed in registers but compiler is free to ignore the advice
only arguments and automatic variables can be register variables
NOT POSSIBLE TO TAKE ADDRESS OF A REGISTER VAR!
*/
void register_var_demo(register int arg) {

	//register varibles are given garbage values
	register int test;
}

//register int test;	global variables cannot be assigned a register keyword

/*
********************************************
TOPIC : Pointers
********************************************

Pointer is a variable that contains address of a variable
*/
void pointer_demo() {

	//********************************************
	//TOPIC: pointer basics
	//********************************************

	int i = 23, z[10];

	//int pointer
	int *ip;

	//& gives address of an object in memory, & can only be applied to objects in memory i.e. variables and arrays
	//it cannot be applied to expressions, constatns or register variables
	ip = &i;	//ip points to i

	//* is dereferencing operator which accesses the objects pointed to by the pointer/
	int y = *ip;	//y is now 23

	*ip = 0;		//i is now 0

	ip = &z[0];		//ip points to z[0]
	ip = z;			//same as ip = &z[0];
	//z = ip;       //cannot do this
	
	//no matter the data type of pointer, p = p + 1 is always going to point to the next element in array
	ip = ip + 1;	//ip points to z[1]
	i = *(ip - 1);	//i is given value of z[0]

	ip = z;			//ip now points to z[0], the begining of array z. ip = z is same as ip = &(z[0]);

	//void swap(int *x, int *y); is a function, call it like this: swap(&x, &y);
	//void test(int[] s); int a[10]; test(a);	//Actually a pointer to the first element is passed to the function.

	//********************************************
	//TOPIC: pointer and strings
	//********************************************

	char aMessage[] = "This is a string";	//has '\0' at the end
	char *pMessage = "This is a string";	//pMessage points to the char 'T'
	printf("%s", pMessage);					//This will print "This is a string". When a pointer to char is used in such a way, string is printed starting from the char the pointer
											//points to ('T' in this case) until a '\0' is encountered

	char *pArray[10];		//an array of 10 char pointers,  pArray[i] is a char pointer and *pArray[i] is the character that it points to

	//months is an array of char pointers where each string (in initializer) is assigned to corresponding pointers in array
	static char *months[] = {
		"Illegal month",
		"January",
		"Feb",
		"And so on ..."
	};

	//********************************************
	//TOPIC: void pointers
	//********************************************
	//void pointers can store address of any data type variable
	//compiler has no idea what kind of data type a void pointer is pointing to
	//It is capable of storing address of any data type

	void *ptr;    // ptr is declared as Void pointer

	int inum = 10;

	ptr = &inum;  // ptr has address of integer data

	printf("%d", *((int*) ptr));		//this will print 10. We are first cating ptr to an int pointer and then dereferencing it
	//********NOTE: you can't derefence a void pointer or do arithmetic on it

}