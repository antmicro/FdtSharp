========
FdtSharp
========

Copyright (c) 2014-2021 `Antmicro <https://www.antmicro.com>`_

A library to read and write Flattened Device Trees in their binary form.

Usage
-----

The usage is very simple:

First, you can create an object of the ``FlattenedDeviceTree`` class by reading a byte blob.
You can also create a new, empty tree and populate it manually. 

Manipulate the tree by adding, changing and removing nodes and properties and write the changed tree back to the blob.

Reading
-------

To read the FDT file, use::

    var blob = File.ReadAllBytes(file.dtb); // or any other way you need
    var fdt = new FlattenedDeviceTree(binaryBlob);

Manipulating
------------

For a newly created tree, or one just read from file, you can
access the root node via the ``Root`` property; then each node contains two
collections:

- ``Subnodes`` - containing subnodes;
- ``Properties`` - containing objects of the ``Property`` class.

A ``Property`` is a general node entry (also called property in the
specification) which has its name and data. Data is available as a byte array or
a null terminated string. Other useful types will be implemented when needed.

Writing
-------

To write the tree into a file::

    // fdt is a FlattenedDeviceTree object
    var outputBlob = fdt.GetBinaryBlob();

License
-------

The library is released under the MIT license. See the LICENSE file for details.
