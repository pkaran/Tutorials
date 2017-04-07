# in python, end of line is end of statement, no need of terminating ';'
# even if ; is used, no error will be caused
x = 1

if 3 > 2 < 5:
    print('lol')    # End of indentation is end of block

if (3 > 2 < 5):     # para optional, usually omitted in Python !
    print('lol')

# Backslashes allow continuations... cannot have any comments after \
if 3 > 2 \
    < 5:
    print('lol')

y = 0

if (not(y == 0)) and 1 / y : print('short circuit')

# all objects have an inherent Boolean true or false value
if [] : print("empty objects are False")
if () : print("empty objects are False")
if "" : print("empty strings are False")
if None : print("None is False")
if 0 : print("0 is False")

"""
TOPIC : The if/else Ternary Expression

A = Y if X else Z
Python runs expression Y only if X turns out to be true, and runs expression Z only if X turns out to be false.
"""
A = 't' if 'spam' else 'f'
print(A)
print('t' if '' else 'f')       # return t if "" else return 'f'

i = 10
while(i):
    i = i - 1
else:
    print("Runs if and only if the loop is exited normally (i.e., without hitting a break)")

i = 1
while(i):
    i = i + 1
    if(i == 5): break
else:
    print("*** Runs if and only if the loop is exited normally (i.e., without hitting a break)")

"""
TOPIC : for loop

for target in object:       # Assign object items to target
    statements                  # Repeated loop body: use target
else:                       # Optional else part
    statements                  # If we didn't hit a 'break'

When Python runs a for loop, it assigns the items in the iterable object to the target
one by one and executes the loop body for each.
"""

for i in 'spam': print(i)   # Iterate over a string
for i in [] : print("this will not execute")    # Iterate over a list
for ((a, b), c) in (((1, 2), 3), ((4, 5), 6)): print(a, b, c)   # Iterate over a tuple
d = {'a' : 5, 'b' : 6}
for i in  d : print (i, " = ", d[i])        # Iterate over a dict

"""
you can chain together only simple statements, like assignments, prints, and function calls.
Compound statements like if tests and while loops must still appear on lines of their own
"""
a = 1; b = 2; print(a,b)    # Three statements on one line

# a = 1; if a == 1: print(a)    # error

# any code enclosed in parentheses (()), square brackets ([]), or curly braces ({}) can span multiple lines !
list = [
    1,
    2,
    3
]

# no need for statements to be in nested block. body of a compound statement can instead appear on
# the same line as the header in Python, after the colon:
if a == 1: print("a = ", a); print("b = ", b)

# the line "while True:" is referred to as header statement. Every kind of loop has such header statement
while True:
    reply = input('Enter text:')
    if reply == 'stop':
        break
    elif not reply.isdigit():       # !(negation) does not work in python, use not keyword instead
        print('Bad!' * 8)
    else:
        print(int(reply) ** 2)
print('Bye')

a = []
while a: print("this will never execute since the list is empty !")

# python does not support i++ or ++i

# python does not support switch statements, however following can be used :
choice = 'ham'
d = {'spam' : 1232.23, 'lol' : 23232, 'ham' : 32323}
switch_equivalent = d[choice]
print(switch_equivalent)
# handling default value
switch_equivalent = d.get('asa', 'Bad choice')
print(switch_equivalent)