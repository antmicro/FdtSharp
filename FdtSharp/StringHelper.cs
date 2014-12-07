using System;

namespace FdtSharp
{
	internal sealed class StringHelper
	{
		public StringHelper(ArraySegment<byte> data)
		{
			this.data = data;
		}

		public string GetString(int index)
		{
			index += data.Offset;
			return Utilities.ReadNullTerminatedString(data.Array, ref index);
		}

		private readonly ArraySegment<byte> data;
	}
}

