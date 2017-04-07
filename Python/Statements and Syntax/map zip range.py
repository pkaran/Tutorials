zip_object = zip([1,2,3], [4,5,6], [7,8,9])     # zip returns a iterable/iterator (object is both)
print(zip_object)
print(next(zip_object))
print(list(zip_object))

map_object = map(abs, (-1,0,1))     # map returns a iterable/iterator (object is both)
print(map_object)
print(next(map_object))
print(list(map_object))

range_object = range(0,10)      # range returns a iterable object
print(range_object)
print(list(range_object))
# print(next(range_object))     # this will cause an error

i = iter(range_object)
print(list(i))