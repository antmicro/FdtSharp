using System;

namespace FdtSharp
{
	public sealed class FlattenDeviceTree
	{
		public FlattenDeviceTree(byte[] treeData)
		{
			ReadHeader(treeData);
		}

		public uint Version { get; private set; }
		public uint LastCompatibleVersion { get; private set; }

		private void ReadHeader(byte[] treeData)
		{
			var magic = Utilities.ReadUintBigEndian(treeData, 0);
			if(magic != Magic)
			{
				throw new InvalidOperationException(string.Format("Wrong magic encountered: {0}, should be {1}.", magic, Magic));
			}
			Version = Utilities.ReadUintBigEndian(treeData, 20);
			LastCompatibleVersion = Utilities.ReadUintBigEndian(treeData, 24);
		}

		private const uint Magic = 0xd00dfeed;
	}
}

