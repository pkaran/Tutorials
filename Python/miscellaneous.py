a,b = 2,3       # multi assignment in one line
print(a," ", b)

"""
TOPIC : Variables and Objects

A variable never has any type information or constraints associated with it.
Variables are generic in nature; they always simply refer to a particular object at a particular point in time.

Each object also has two standard header fields: a type designator used to
mark the type of the object, and a reference counter used to determine when it’s OK to
reclaim the object.

Type designator:
Objects, on the other hand, know what type they are—each object contains a header
field that tags the object with its type. The integer object 3, for example, will contain
the value 3, plus a type designator that tells Python that the object is an integer (strictly
speaking, a pointer to an object called int, the name of the integer type).
Because objects know their types, variables don’t have to.

Reference counter:
a counter in every object that keeps track of the number of references currently pointing to that object.
As soon as (and exactly when) this counter drops to zero, the object’s memory space is automatically reclaimed.

Garbage collection in python:
Whenever a variable is assigned to a new object, the space
held by the prior object is reclaimed if it is not referenced by any other name(variable) or object.
This automatic reclamation of objects’ space is known as garbage collection, and makes
life much simpler for programmers of languages like Python that support it
In standard Python (a.k.a. CPython), the space is reclaimed immediately,
as soon as the last reference to an object is removed.
"""

# a         # variables need to be assigned before they can be used
# print(a)

a = 23  # Variable a becomes a reference to the object 23 (23 is stored in memory which a points to)
print(type(a))  # types are classes, see output
if(type(a) == int):     # compare using type name
    print("a is an int")

b = a   # variables a and b wind up referencing the same object (that is, pointing to the same chunk of memory)

L = [1,2,3]
M = [1,2,3]

print(L == M)       # returns rue if both objects have same values
print(L is M)       # returns true only if the variables refer(point) to the same object

# python caches small integers and strings (both are immutable objects)
#thus, small ints and strings might not be reclaimed by garbage collector even when their Reference counter is 0
a = 3
b = 3
print(a is b)     #this might return true, even though two objects seem different, python might assign the same immutable object(3) to b as well

"""
TOPIC : dir() and help()
"""

print(dir())        # dir() returns a list of all variables in the current scope

print(dir(str))     # dir(object) returns a list of attributes for object passed to it

print(help(str))   # will return info for all attributes of str object

print(help(str.join))   # will return info for "join" attribute of str object

import math
#print(help(math.pi))   # this is same as print(help(float)) since pi is a float object

"""
The eval function, treats strings as though they
were Python code. Therefore, it actually compiles and runs the string as a piece of a program,
and it assumes the string being run comes from a trusted source—a clever user might be able to
submit a string that deletes files on your machine, so be careful with this call
"""
print(eval('0x40')) #0x40 = 64