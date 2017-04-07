s = 'spam\n'

print(len(s))   #\n counts as 1

"""TOPIC: slicing and indexing strings"""

print(s[1])
print(s[1:3])   #array[x:y]  x is inclusive, y is NOT inclusive!
print(s[:2])    #same as s[0:2]
print(s[1:])    #same as s[1:len(s)], here len(s) = 4, 4 is NOT inclusive!

print(s[-1])        #last character
print(s[0:-1])      #same as s[0:-1]
print(s[:])         #same as  s[0:len(s)]

"""TOPIC: string operations"""

s = s + s + s      #concatnation
print(s)
a = "a"         #repetition
print(a*10)

#s[0] = 'z'     #this is not possible since strings are immutable objects
#line.rstrip().split(',')    it strips before it splits because Python runs from left to right

"""TOPIC: string formatting

Strings also support an advanced
substitution operation known as formatting, available as both an expression (the original)
and a string method call (new as of 2.6 and 3.0); the second of these allows you
to omit relative argument value numbers as of 2.7 and 3.1
"""

print('%s, eggs, and %s' % ('spam', 'SPAM!'))           # Formatting expression
print('{0}, eggs, and {1}'.format('spam', 'SPAM!'))     # Formatting method (2.6+, 3.0+)
print('{}, eggs, and {}'.format(1, 'SPAM!'))       # Numbers optional (2.7+, 3.1+)

"""TOPIC: Miscellaneous"""

# multilineString = "\nthis\nis\nmulti line\nstring\n"    note the first and last implicit \n !
#we cannot add any comments between """ """
multilineString = """
this
is
multi line
string
"""
print(multilineString)

path = r"C:\text\new"       #raw string literals start with the letter r and are useful for strings like directory paths on Windows
                            # they suppress escape sequences (like \n)
print(path)