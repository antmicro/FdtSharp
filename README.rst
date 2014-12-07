FdtSharp 0.1
============

A library to read and (not yet) write Flattened Device Trees in their binary form.

Usage
-----

The usage is very simple:

First, you can create an object of the ``FlattenedDeviceTree`` class by reading a byte blob.
You can also create a new, empty tree and populate it manually. 

Manipulate the tree by adding, changing and removing nodes and properties and write the changed tree back to the blob (the last part is not implemented yet at the moment of writing).

License
-------

The library is released under the MIT license. See the LICENSE file for details.
