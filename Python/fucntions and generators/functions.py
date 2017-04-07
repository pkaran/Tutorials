"""
The def statement creates a function object and assigns it to a name
Below, function object is created and name "twice" is assigned to it

the return statement consists of an optional object value expression that gives the function’s result. If the
value is omitted, return sends back a None.
"""

def twice(a):
    a = a * 2
    return a              # send back None

print(twice(10))        # function call

double = twice
print(double('as'))    # here function was assigned to a different name and called through the new name

"""
defs are not evaluated until they are reached and run, and the code inside defs is not
evaluated until the functions are later called. Thus, def Executes at Runtime
"""

power = 3

if power == 2:
    def power(a):
        return a**2
else:
    def power(a):
        return a**3

print(power(2))

"""
TOPIC : Polymorphism in Python

As we just saw, the very meaning of the expression x * y in our simple times function
depends completely upon the kinds of objects that x and y are—thus, the same function
can perform multiplication in one instance and repetition in another. Python leaves it
up to the objects to do something reasonable for the syntax. Really, * is just a dispatch
mechanism that routes control to the objects being processed

This sort of type-dependent behavior is known as polymorphism, a term we first met
in Chapter 4 that essentially means that the meaning of an operation depends on the
objects being operated upon. Because it’s a dynamically typed language, polymorphism
runs rampant in Python. In fact, every operation is a polymorphic operation in Python:
printing, indexing, the * operator, and much more.

Moreover, if the objects passed in do not support this expected interface, Python will
detect the error when the * expression is run and raise an exception automatically. It’s
therefore usually pointless to code error checking ourselves. In fact, doing so would
limit our function’s utility, as it would be restricted to work only on objects whose types
we test for
"""

def intersect(seq1, seq2):
    res = []
    for x in seq1:  # Scan seq1
        if x in seq2:  # Common item?
            res.append(x)
    return res

"""
Like all good functions in Python, intersect is polymorphic. That is, it works on arbitrary types, as long as
they support the expected object interface:
"""

print(intersect("spam", 'spac'))
print(intersect([1,2,3], [1,5,3]))

# print(intersect(1,2))     # this will cause an error

def test(string):
    string = 'asa'
    return

L = 'lol'
test(L)
print(L)        # L will not change after the function is called

# Arguments are passed by assignment (value) in python
def test(list):
    list[0] = 'asa'


    """
    TOPIC : Local variables
    local variable— name that is visible only to code inside the function def and that exists only while the function runs
    """
    a = 10  # this is a local variable

    return

L = [0,1]
test(L)         # Arguments are passed by assignment (value) in python
print(L)        # L will change after function call

def printt(s = 'default string'):
    print(s)

printt()
printt('not default')