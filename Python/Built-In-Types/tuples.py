"""
tuples are sequences, like lists, but they are immutable, like strings
Tuples are used when you don't want data in it to be modified.
Tuples can be used as keys of a dictionary. We cannot used lists since keys need to be immutable.

Because tuples are immutable, you cannot change the size of a tuple without making a copy.
"""

"""
TOPIC : creating tuple
"""

T = ()          # empty tuple
T = (1,)        # tuple with only one object
print(T)
T = (1,2,3,4)
T1 = 1,2,3,4,"this way works as well"
print(T1)

print(len(T))

T3 = tuple('spam')
print("T3 = ", T3)

"""
TOPIC : tuple operations
"""

# + and * operations work just like they work on lists
print(T + (5,6))
print(T * 3)

# indexing operations
print(T[0])
#T[0] = 34      #this will result in error since tuples are immutable

print("T[0:4] = ", T[0:4])

# in operation
if 23242 in T:
    # index(value) return first index of value. Raises ValueError if the value is not present.
    print(T.index(23242))   #error will be generated if object not in tuple, thus check before using index()

print(T.count(424))       # 424 appears 0 times in tuple

t = ([1,2], 'asa')
t[0][0] = 13131         # tuple is immutable, but objects in a tuple can still be changed if they are mutable
print(t)

"""
TOPIC : None place holders : used to initialize names and objects
"""

a = (None,)
a = a * 10
print(a)