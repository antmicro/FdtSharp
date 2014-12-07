using System;
using System.Net;

namespace FdtSharp
{
	internal static class Utilities
	{
		public static uint ReadUintBigEndian(byte[] array, int index)
		{
			return unchecked((uint)IPAddress.NetworkToHostOrder((int)BitConverter.ToUInt32(array, index)));
		}
	}
}

