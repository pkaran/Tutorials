"""
Lists preserve order and they have no fixed size.
They are also mutable—unlike strings. lists are mutable (i.e., can be changed in place)

Fetching an item from a Python list is about as fast as indexing a C array; in fact,
lists really are arrays inside the standard Python interpreter, not linked structures.

*************IMP : review Gotchas in Onenote
"""

"""
TOPIC : Ways of creating a list
"""

L1 = [] # empty list
print("this is an empty list : ", L1)
L1 = list()
print("this is an empty list as well : {}".format(L1))

L1 = [2,3,4, [-1, -2]]    # a list can have any number of objects of any types, including list in list (nested list)
print("length of L1 = ", len(L1))
print(L1[3])        # will return [-1, -2]
print(L1[3:4])      # will return [[-1, -2]]    REMEMBER: slicing will return objects wrapped in lists !

L1 = list("list")   # List of an iterable’s items
print(L1)           # ****************** Important one !

L1 = list(range(-4,4))   # list of successive integers
print(L1)           # ****************** Important one !

"""
    Sub-TOPIC : List Comprehension

    Moreover, depending on your Python and code, list comprehensions
might run much faster than manual for loop statements (often roughly twice as fast)
because their iterations are performed at C language speed inside the interpreter, rather
than with manual Python code. Especially for larger data sets, there is often a major
performance advantage to using this expression.
"""
l = [i*2 for i in "spam"]
print("l = {}".format(l))
l = [i*5 for i in "lol" if i == 'o']
print(l)

M = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
sum_of_rows = list(map(sum,M))      # applies a function to items in a sequence and collects all the results in a new list
print(sum_of_rows)

"""
TOPIC : Changing lists in place

Changing lists in place means modify the list object directly—overwriting
its former value—without requiring that you make a new copy, as you had to for strings
"""
print("\nTOPIC : Changing lists in place\n")
M = [1,2,3]
print("M = ", M)
M[1:2] = [4,5]      # Replacement/insertion, delete item at M[1]
print(M)
M[1:1] = [6,7]      # Insertion (replace nothing) at M[1]
print(M)
M[(len(M) - 2) : (len(M) - 1)] = []    # Deletion (insert nothing)
print(M)

# M[0:1] = 12      #this will cause an error, can only assign an iterable
# L3[12] = 'a'      # automatic range checking is conducted, this line will cause an error

"""
TOPIC : List operations
"""
print("\nTOPIC : List operations\n")

# slicing and indexing works just like strings
L2 = L1[:]      # deep copy of L1
L3 = L1[:-1]    #remember, [a:b] b is not inclusive but a is
print(L3)

# *(repeat) and +(concatenation) operations work just like strings, both of them will create a new list !!
print("L1 + L3 = {}".format(L1 + L3))   # order is preserved unlike sets !
print("L3 * 2 (L3 remains unchanged unless assigned to self) = {}".format(L3*2))

# membership operation works with lists
print("-4 in L1 = ", -4 in L1)

#list iteration
for i in L3:
    print("this is in L3 : ", i)

L3.append("This is a string")   #inserts at the end
print("L3 after appending = {}".format(L3))

L3.insert(0, -12)
print("L3 after inserting -12 at position 0 = {}".format(L3))

L3.extend("lol")    # add multiple items at the end, !! important : watch the output !!
print("After extending 'lol' = {}".format(L3))

poped = L3.pop(0)   #pop item at position 0
print("L3 after poping at position 0 = {} and item popped = {}".format(L3, poped))

L3.remove("This is a string")   #remove "This is a string"
print("L3 after removing 'This is a string'  = {}".format(L3))

L3.reverse()
print(L3)

L3[0] = "new one"   # works just like an array
print(L3)

# augmented assignments
L = [1,2,3,4,5]
L += [6,7]      # same as L.extend([6,7])    output : [1,2,3,4,5,6,7]
                # L.extend(iterable) -> None -- extend list by appending elements from the iterable
print(L)
L = []
L += 'spam'
print(L)

L = []
#L = L + 'asa'   # can only concatenate list (not "str") to list     this will cause error !

# zipping two list

""""
TOPIC : Zipping two lists

Return a zip object whose .__next__() method returns a tuple where
 |  the i-th element comes from the i-th iterable argument.  The .__next__()
 |  method continues until the shortest iterable in the argument sequence
 |  is exhausted and then it raises StopIteration.

 NOTE : arguments for lists can be any iterable
        We can zip more than 2 objects
"""

L1 = [1,2,3]
L2 = [5,6]

print(list(zip(L1, L2)))