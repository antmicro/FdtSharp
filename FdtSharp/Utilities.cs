using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace FdtSharp
{
	internal static class Utilities
	{
		public static uint ReadUintBigEndian(byte[] array, int index)
		{
			return unchecked((uint)IPAddress.NetworkToHostOrder((int)BitConverter.ToUInt32(array, index)));
		}

		public static ulong ReadUlongBigEndian(byte[] array, int index)
		{
			return unchecked((ulong)IPAddress.NetworkToHostOrder((long)BitConverter.ToUInt64(array, index)));
		}

		public static string ReadNullTerminatedString(byte[] array, ref int index)
		{
			var stringAsBytes = new List<byte>();
			while(index < array.Length)
			{
				var byteToAdd = array[index];
				index++;
				if(byteToAdd == 0)
				{
					return Encoding.UTF8.GetString(stringAsBytes.ToArray());
				}
				stringAsBytes.Add(byteToAdd);
			}
			throw new InvalidOperationException("Encountered never ending string.");
		}
	}
}

