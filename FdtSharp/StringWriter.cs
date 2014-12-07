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
			alreadyWritten = new Dictionary<string, int>();
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
			if(alreadyWritten.ContainsKey(str))
			{
				return alreadyWritten[str];
			}
			var index = result.Count;
			alreadyWritten.Add(str, index);
			result.AddRange(str.NullTerminated());
			return index;
		}

		private readonly List<byte> result;
		private readonly Dictionary<string, int> alreadyWritten;
	}
}

