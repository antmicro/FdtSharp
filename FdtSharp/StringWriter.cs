using System;
using System.Collections.Generic;
using System.Linq;

namespace FdtSharp
{
	internal sealed class StringWriter
	{
		public StringWriter()
		{
			result = new List<byte>();
		}

		public List<byte> Result
		{
			get
			{
				return result.ToList();
			}
		}

		public int PutString(string str)
		{
			var index = result.Count;
			result.AddRange(str.NullTerminated());
			return index;
		}

		private readonly List<byte> result;
	}
}

