FdtSharp 0.1
============

A library to read and write Flattened Device Trees in their binary form.

Usage
-----

The usage is very simple:

First, you can create an object of the ``FlattenedDeviceTree`` class by reading a byte blob.
You can also create a new, empty tree and populate it manually. 

Manipulate the tree by adding, changing and removing nodes and properties and write the changed tree back to the blob.

Reading
-------
::
    var blob = File.ReadAllBytes(file.dtb); // or any other way you need
    var fdt = new FlattenedDeviceTree(binaryBlob);
    // fdt is now ready to be manipulated

Writing
-------
::
    var fdt = new FlattenedDeviceTree(); // you can also use existing blob
    ... // fdt manipulation
    var outputBlob = fdt.GetBinaryBlob();

License
-------

The library is released under the MIT license. See the LICENSE file for details.
