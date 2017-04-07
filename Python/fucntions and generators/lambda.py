addition = lambda n1 , n2 : n1 + n2

print(addition([1,2,3], [4,5,6]))

printt = lambda n = 'default' : n + n

print(printt())

def makeActions():
    acts = []
    for i in range(5): # Tries to remember each i
        acts.append(lambda x: i ** x) # But all remember same last i!
    return acts

acts = makeActions()
print(tuple(acts[i](2) for i in range(5)))  # All are 4 ** 2, 4=value of last i, which is UNEXPECTED

def makeActions2():
    acts = []
    for i in range(5): # Tries to remember each i
        acts.append(lambda x, i = i : i ** x)           # ********************** VV IMP *****************************
    return acts

acts = makeActions2()
print(tuple(acts[i](2) for i in range(5)))  # All are i ** 2