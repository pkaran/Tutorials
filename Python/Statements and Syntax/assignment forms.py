"""
TOPIC : Assignment Forms
"""

a,b,c = 1,2,3   # Tuple assignment (positional)     same as (a,b,c) = (1,2,3)  both operands are tuples !
print(a,b,c)

[a,b,c] = [4,5,6]   # List assignment (positional)
print(a,b,c)

a, b, c, d = 'spam'     # Sequence assignment,  a = s, b = p and so on ...
print(a,b,c,d)

a = b = c = -2      # a,b and c refer to the same object
print(a,b,c)

"""
Sequences allow you to store multiple values in an organized and efficient fashion.
There are three kinds of sequences in Python: strings, lists and tuples. Dictionaries and sets are containers for sequential data.

any type of sequence (really, iterable) can be assigned on the right as long as it is of the same
length as the sequence on the left.

Technically speaking, sequence assignment actually supports any iterable object on the
right, not just any sequence. This is a more general category that includes collections
both physical (e.g., lists) and virtual (e.g., a file’s lines), which was defined briefly in
Chapter 4 and has popped up in passing ever since. We’ll firm up this term when we
explore iterables in Chapter 14 and Chapter 20.
"""
(a,b,c) = 'lol'     # string on right need to be of length 3 ! no more, no less
print(a,b,c)

[a,b,c] = (89, 90, 91)
print(a,b,c)

(a,b), c = "SP", "AM"
print(a,b,c)

for (a, b, c) in [(1, 2, 3), (4, 5, 6)]: print(a,b,c)   # implicit sequence assignment

"""
the starred name is assigned a list, which collects all items in the sequence not assigned
to other names

NOTE : Only one star expression is allowed per assignment !
       starred assignment target must be in a list or tuple
"""
a, *b, c = "spam"       # Extended Sequence Unpacking
print(a, b, c)

*a, b, c = (1,2,3,4,5)       # Extended Sequence Unpacking
print(a, b, c)

a, b, *c = "spa"       # Extended Sequence Unpacking, BOUNDARY CASE !!!!  c will get ['a']
print(a, b, c)

a, b, *c = "sp"       # Extended Sequence Unpacking, BOUNDARY CASE !!!!  c will get []
print(a, b, c)

a, *b, c = "sp"       # Extended Sequence Unpacking, BOUNDARY CASE !!!!  b will get []
print(a, b, c)

"""
>>> *a = seq
SyntaxError: starred assignment target must be in a list or tuple

>>> *a, = seq
>>> a
[1, 2, 3, 4]
"""