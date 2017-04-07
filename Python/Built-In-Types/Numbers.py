"""
Numeric types include:
• Integer and floating-point objects
• Complex number objects
• Decimal: fixed-precision objects
• Fraction: rational number objects
• Sets: collections with numeric operations
• Booleans: true and false
• Built-in functions and modules: round, math, random, etc.
• Expressions; unlimited integer precision; bitwise operations; hex, octal, and binary formats
• Third-party extensions: vectors, libraries, visualization, plotting, etc.

Ways of processing numeric objects:
Expression operators : +, -, *, /, >>, **, &, etc.
Built-in mathematical functions : pow, abs, round, int, hex, bin, etc.
Utility modules : random, math, etc.
"""

"""
TOPIC : Integers

Integers have unlimited precision—they can grow to have as many digits as your memory space allows.
Because Python must do extra work to support their extended precision, integer math
is usually substantially slower than normal when numbers grow large. However, if you
need the precision, the fact that it’s built in for you to use will likely outweigh its
performance penalty.

Integers may be coded in decimal (base 10), hexadecimal (base 16), octal (base 8), or binary (base 2):
Hex literals start with 0x or 0X, followed by a string of hexadecimal digits (0–9 and A–F)
Octal literals start with a leading 0o or 0O (zero and lower- or uppercase letter o), followed by a string of digits (0–7)
Binary literals begin with a leading 0b or 0B, followed by binary digits (0–1)
"""

a = 10

# three functions below convert an integer to its representation string in these three bases
print(bin(a))
print(hex(a))
print(oct(a))

# int(str, base) converts a string to an integer per a given base
a = int("11", 2)
print(a)

a = float(a)    #if a is 3, a now is 3.0
a = int(a)      #if a is 3.14, a now is 3   truncation occurs !

a = 2 + 2.2     # integer + float = float ,  float + complex number = complex number
                #The less complex of the two operands is promoted to the more complex one before performing operations

i = (2 ** 100) #** is used for exponents, this line means 2 ^ 100
print(len(str(i)))  #number of digits in i

a = 10
b = 20
c = b / a   # performs true division, returning a float result that includes any remainder, regardless of operand types
print(c)
c = b // a  # performs floor division, which truncates the remainder and returns an integer for integer operands or a float if any operand is a float
print(c)
a = 2
b = -5.0
# important line below:
c = b // a  # since one of the operand is float, float is returned. !!  This will print -3.0 [ floor of -2.5 is -3] !!
print(c)

print(2.0 > 1)      # 1 converted to 1.0

# comparison can be chained in python:
x = 2
y = 4
z = 6
print(x < y < z)        # same as x < y and y < z
print(1 == 2 < 3)       # same as 1 == 2 and 2 < 3  Not same as: False < 3 (which means 0 < 3, which is true!)

x = 0b1
print(x << 2)       #pre : 0001   post : 0100

x = 37      #32  = 0b100101
print(x.bit_length())   #will output 6 [0b not included !, 0b is not written in memory]

"""
TOPIC : Floating point literals

Floating-point numbers have a decimal point and/or an optional signed exponent introduced by an e or E and followed by an optional sign.
Floating-point numbers are implemented as C “doubles” in standard CPython, and therefore get as much precision
as the C compiler used to build the Python interpreter gives to doubles.
"""

# limitation of float (not unique to python):
print (1.1 + 2.2 == 3.3)  # floating-point numbers cannot represent some values exactly due to their limited number of bits

"""
TOPIC : Decimals

Functionally, decimals are like floating-point numbers, but they have a fixed number of decimal points. Hence, decimals
are fixed-precision floating-point values.

For example, with decimals, we can have a floating-point value that always retains just
two decimal digits. Furthermore, we can specify how to round or truncate the extra
decimal digits beyond the object’s cutoff. Although it generally incurs a performance
penalty compared to the normal floating-point type since do not map as closely to computer hardware as floating-point numbers,
the decimal type is well suited to representing fixed-precision quantities like sums of money and can help you achieve
better numeric accuracy.
"""

print(0.1 + 0.1 + 0.1 - 0.3)    # will output : 5.551115123125783e-17 since floating-point numbers cannot represent some values exactly due to their limited number of bits

import decimal
print(decimal.Decimal('0.1') + decimal.Decimal('0.1') + decimal.Decimal('0.1') - decimal.Decimal('0.3'))

# When decimals of different precision are mixed in expressions,
# Python converts up to the largest number of decimal digits automatically

a = decimal.Decimal('0.1') + decimal.Decimal('0.10') + decimal.Decimal('0.10') - decimal.Decimal('0.30')
print(a)

#it’s also possible to create a decimal object from a floating point object
#conversion is exact but can sometimes yield a large default number of digits, unless they are fixed per the next section:
print(decimal.Decimal(0.1) + decimal.Decimal(0.1) + decimal.Decimal(0.1) - decimal.Decimal(0.3)) # will output : 2.775557561565156540423631668E-17

# TIP : In Python 3.3 and later, the decimal module was also optimized to improve its performance radically: the reported speedup for the
# new version is 10X to 100X, depending on the type of program benchmarked

# The precision is applied globally for all decimals created in the calling thread
decimal.getcontext().prec = 2       #now we will have 2 precession points ! i.e. 0.00 [2 digits after decimal point]
print(decimal.Decimal(0.1) + decimal.Decimal(0.1) + decimal.Decimal(0.1) - decimal.Decimal(0.3))    #closer to 0, but not 0.00 !

# better to pass on string to Decimal() constructor since passing on floats does not give required results (especially in monetary applications)

#it’s also possible to reset precision temporarily by using the with context manager statement.
# The precision is reset to its original value on statement exit
with decimal.localcontext() as ctx:
    ctx.prec = 5
    print(decimal.Decimal('1.00') / decimal.Decimal('3.00'))

print(decimal.Decimal('1.00') / decimal.Decimal('3.00'))

"""
TOPIC : Fractions
"""
from fractions import Fraction

print(Fraction('0.25'))
print(Fraction(4,6))        #Fraction(numerator, denominator), will gcd to 2/3