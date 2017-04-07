x = 100 # global scope, other module need to import this file to access x
z = 3

l = [x for x in range(0,5)]     # x in local to expression itself
print(l)
print(x)

def test():
    x = 3   # this will overwrite x in global scope
    y = 3   # local scope, its scope is function in which it is defined

    """
    When you use an unqualified name inside a function, Python searches up to four
    scopes—the local (L) scope, then the local scopes of any enclosing (E) defs and
    lambdas, then the global (G) scope, and then the built-in (B) scope—and stops at
    the first place the name is found. If the name is not found during this search, Python
    reports an error.

    built-in scope <- global scope <- enclosing functions’ local scopes <- local scope
    NOTE : First occurence wins ! Search stars from local scope !
    """
    # print(var)    # python will search for var as stated above

    return x + y + z

print(test())
print(x)

def test1():
    #len = 23               # len here will hide builtin scope's len() method and thus cause error in line below
    print(len("asas"))      # Note : no need to explicitly mention return, None will be returned implicitly

print(test1())

x = 88

def func():
    global x
    x = 99      # Global X: outside def

func()
print(x) # Prints 99

"""
TOPIC : avoid using global variables

X = 99

def func1():
    global X
    X = 88

def func2():
    global X
    X = 77

print(X)        # value printed will be time dependent based upon if any functions above are called

TOPIC : MINIMIZE cross file changes

# first.py
X = 99 # This code doesn't know about second.py

# second.py
import first
print(first.X) # OK: references a name in another file
first.X = 88 # But changing it can be too subtle and implicit

NOTE : Use an accessor function to change a value in other file so it gets updated as well

# first.py
X = 99
def setX(new): # Accessor make external changes explit
    global X # And can manage access in a single place
    X = new

# second.py
import first
first.setX(88) # Call the function instead of changing directly
"""

X = 99 # Global scope name: not used

def f1():
    X = 88 # Enclosing def local
    def f2():
        print(X) # Reference made in nested def

    f2()

f1() # Prints 88: enclosing def local

"""
TOPIC : returning function
"""

def f1():
    X = 88

    def f2():
        print(X) # Remembers X in enclosing def scope

    return f2 # Return f2 but don't call it

#f2()   # NOTE : Cannot access f2 since f2 is limited to f1's local scope
action = f1() # Make, return function
action() # Call it now: prints 88

"""
TOPIC : Closer or Function Factory
"""

def maker(N):
    def action(X): # Make and return action
        return X ** N # action retains N from enclosing scope
    return action

f2 = maker(2)
f3 = maker(3)
print(f2(2))
print(f3(2))