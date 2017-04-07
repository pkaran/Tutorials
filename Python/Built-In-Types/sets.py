"""
TOPIC: Sets

sets do not have a positional ordering, and so are not sequences—their order is
arbitrary and may vary per Python release

As iterable containers, sets can also be used in operations such as len, for loops, and
list comprehensions.

Are Python sets mutable?
Yes: "mutable" means that you can change the object. For example, integers are not mutable: you cannot change the number 1 to
 mean anything else. You can, however, add elements to a set, which mutates it.

3 ways of creating sets:
s = set ('string')
s = {12,2 1}
s = {i*2 for i in 'spam'}
"""
s = set("abcdef")
print(s)
s1= set("abc")

#set expressions below DO NOT allow non set arguments
print(s - s1)   #difference
print(s | s1)   #union
print(s & s1)   #intersection
print(s ^ s1)   #in one but not both
print(s > s1)   #superset
print(s < s1)   #subset

# do not convert list and string to set for membership testing
print('e' in 'ece')
print(1 in [10, 23])

print(s1)
s1.add("new")
print(s1)
s1.remove('a')
print(s1)
s1.update(s)            # merge : in place union
print(s1)

s1 = s1.union(['holahola'])
print(s1)
s1 = s1.intersection(["no", "matches"])   #set methods allow non set members including any iterable
print(s1)

a = {'asa'}     # new syntax for creating a set object supported in 3.X and 2.7
print(a)

# use syntax below for creating an empty set
print(type({}))
s = set()       #empty set
print(type(s))

# sets can contain only hashable (immutable) objects !
# thus, dictionaries and lists cannot be added to sets. But tuples are okay !

s.add((1,2,3))
print(s)
#s.add([1,2,3])         # this will generate an error AND / OR exit with code 1 instead of exiting with code 0

"""
Sets themselves are mutable too, and so cannot be nested in
other sets directly; if you need to store a set inside another set, the frozenset built-in
call works just like set but creates an immutable set that cannot change and thus can
be embedded in other sets.
"""

#new way of creating set : set comprehension
s = {i * 2 for i in "spam"}
print(s)