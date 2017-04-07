"""
File objects are Python code’s main interface to external files on your computer

They can be used to read and write text memos, audio clips, Excel documents, saved email
messages, and whatever else you happen to have stored on your machine
"""

"""
TOPIC : Creating / writing to a Unicode text file

This creates a file in the current directory and writes text to it (the filename can be a
full directory path if you need to access a file elsewhere on your computer)
"""

# built-in open function creates a Python file object
f = open('data.txt', 'w')   # Make a new file in output mode ('w' is write)
print(f.write("hello\nworld"))     # Return number of items written in Python 3.X
f.close()                            # Close to flush output buffers to disk

"""
TOPIC : Reading a Unicode text file
"""

f = open('data.txt', 'r')   # 'r' (read) is the default processing mode, i.e. okay to not pass it and use this instead : open('data.txt')
text = f.read()             # read entire file into string
print("Following is read from file :\n", text, "\n--------------------")
print(text.split())


"""
#best way to read a file today is to not read it at all—files provide an iterator that automatically reads line by
# line in for loops and other contexts
# method below loads line by line in memory versus loading the whole file in memory at once

iterators run at C language speed inside Python, whereas the while loop version runs Python
byte code through the Python virtual machine. So don't use while loops to read from file
"""
i = 1
for line in open('data.txt'):               # best way to read a file line by line
    print("{}. ".format(i), line)
    i += 1

# read file char by char
print("\nread file char by char")
for i in open('data.txt').read(): print(i)

"""
Python supports two kind of files: Binary Byte files and Unicode Text files

text files represent content as normal str strings and perform Unicode encoding and decoding automatically when writing and reading data,
while binary files represent content as a special bytes string and allow you to access file content unaltered

Python’s struct module can both create and unpack packed binary data—raw bytes that record values that are not Python objects—to be
written to a file in binary mode.

NOTE : skipping binary byte file
"""
