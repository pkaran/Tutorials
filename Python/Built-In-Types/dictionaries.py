"""
Dictionaries are not sequences at all, but are instead known as mappings. Mappings
are also collections of other objects, but they store objects by key instead of by relative
position. In fact, mappings don’t maintain any reliable left-to-right order; they simply
map keys to associated values. Dictionaries, the only mapping type in Python’s core
objects set, are also mutable

Each key can have just one associated value, but that value can be a collection of multiple objects if needed,
and a given value can be stored under any number of keys.

You can change dictionaries in place by assigning to indexes (they are mutable)

dictionaries are implemented as hash tables (data structures that support very fast
retrieval), which start small and grow on demand. Moreover, Python employs optimized hashing algorithms to find keys,
so retrieval is quick. Like lists, dictionaries store object references (not copies, unless you ask for them explicitly).

Keys need not always be strings. Our examples so far have used strings as keys,
but any other immutable objects work just as well. For instance, you can use integers as keys, which makes the dictionary
look much like a list (when indexing, at
least). Tuples may be used as dictionary keys too, allowing compound key values
—such as dates and IP addresses—to have associated values. User-defined class
instance objects (discussed in Part VI) can also be used as keys, as long as they have
the proper protocol methods; roughly, they need to tell Python that their values
are “hashable” and thus won’t change, as otherwise they would be useless as fixed
keys. Mutable objects such as lists, sets, and other dictionaries don’t work as keys,
but are allowed as values.
"""

"""
TOPIC : Ways of creating a dictionary
"""

a = {}      # empty dictionary
print(a)
a = dict()  # empty dictionary
print(a)

d  = {"key" : "value", "key1" : ["this" , "is", "key 1"]}
d[1] = 'numbers as keys are okay'   # adding / changing keys

print("d = ", d)

# requires all keys to be strings
bob1 = dict(name='Bob', job='dev', age =40)
print("bob1 = ", bob1)

bob2 = dict(zip(['name', 'job', 'age'], ['Bob', 'dev', 40]))    # zipping makes form below convenient to use
print("bob2 = ", bob2)

bob3 = dict([('name', 'Bob'), ('age', 40)])
print("bob3 = ", bob3)

# dictionary comprehension
d = {}
d = {val : val*2 for val in "spam"}

print(d)

"""
TOPIC : Dictionary operations
"""

# get value associated with key 'age'
print(bob2['age'])

# in operation
#print(d['not a key'])   #Referencing a nonexistent key is an error
if not 'not a key' in d:    #use this test and only then try getting value corresponding to the key
    print("'not a key' is not in d")

# fetch by key
print(d.get('le', 'this_default_will_be_returned'))
print(d.get('le'))      # None will be returned if no key exist

# remove by key
"""
remove specified key and return the corresponding value.
If key is not found, "no such key exist to remove it" is returned if given, otherwise KeyError is raised
"""
print(d.pop('le', "no such key exist to remove it"))    # pop method deletes a key from a dictionary and returns the value it had

# get all keys and values
"""
keys(), values() and items() return view objects

View objects are iterable, which simply means objects that generate result items one
at a time, instead of producing the result list all at once in memory. Besides being
iterable, dictionary views also retain the original order of dictionary components, reflect
future changes to the dictionary, and may support set operations. On the other hand,
because they are not lists, they do not directly support operations like indexing or the
list sort method, and do not display their items as a normal list when printed

to force the methods listed above to return a list instead, use list(dict.keys())

3.X’s view objects returned by the keys method are set like and support common set operations such as intersection and union;
 values views are not set-like, but items results are if their (key, value) pairs are unique and hashable (immutable).
"""

print(list(d.keys()))
A = {1:2, 5:3}
print(d.keys() | A) # union operation on view object and dict
print(d.keys() | {1,6}) # union operation on view object and set
print(list(d.values()))
print(list(d.items()))

#browsing dictionary
for key in d:
    print(key, " : " , d[key])

# update method merges the keys and values of one dictionary into another, blindly
# overwriting values of the same key if there’s a clash
d.update(bob1)

#Sorting keys
list = list(bob2.keys())
print("list : ", list)
list.sort()
print("list after sorting : ", list)

#another way of sorting using sorted() method
list = [i for i in sorted(bob1.keys())]
print(list)

# using zipping to create a dictionary

keys = ['a', 'b', 'c']
values = [1,2,3]
d = {a : b for (a,b) in zip(keys, values)}
print(d)

d = {}
d = dict(zip(keys, values))     # OR simply pass the zipped keys/values lists to the built-in dict constructor call
print(d)