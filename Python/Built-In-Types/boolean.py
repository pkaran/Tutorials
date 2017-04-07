a = False
print(type(a))
print(a == 0)
a = True
print(a == 1)
"""
the names True and False are instances of bool, which is in turn just a subclass
(in the object oriented sense) of the built-in integer type int.
"""

print(isinstance(True, int))
print(1 + True)