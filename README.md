# FdtSharp 0.1

A library to read and write (not yet) Flatten Device Trees in their binary
form.

## Overview

The approach is simple. First, you can create an object of the
`FlattenDeviceTree` class by reading a byte blob. You can also create a new
tree which will be empty in the beginning. After that you can manipulate tree,
by adding, changing and removing nodes and properties. Then you can write
changed tree back to blob. Last part is not implemented yet at the moment of
writing.

## License

See the LICENSE file for details.
