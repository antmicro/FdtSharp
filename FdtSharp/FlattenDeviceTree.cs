using System;
using System.Collections.Generic;

namespace FdtSharp
{
	public sealed class FlattenDeviceTree
	{
		public FlattenDeviceTree()
		{
			ReservationBlocks = new List<ReservationBlock>();
		}

		public FlattenDeviceTree(byte[] treeData) : this()
		{
			ReadHeader(treeData);
		}

		public uint Version { get; private set; }
		public uint LastCompatibleVersion { get; private set; }
		public uint BootCPUPhysicalId { get; private set; }

		public ICollection<ReservationBlock> ReservationBlocks { get; private set; }

		private void ReadHeader(byte[] treeData)
		{
			var magic = Utilities.ReadUintBigEndian(treeData, 0);
			if(magic != Magic)
			{
				throw new InvalidOperationException(string.Format("Wrong magic encountered: {0}, should be {1}.", magic, Magic));
			}
			Version = Utilities.ReadUintBigEndian(treeData, 20);
			LastCompatibleVersion = Utilities.ReadUintBigEndian(treeData, 24);
			BootCPUPhysicalId = Utilities.ReadUintBigEndian(treeData, 28);

			// TODO: check for total size vs array size
			var stringsOffset = (int)Utilities.ReadUintBigEndian(treeData, 12);
			var stringsSize = (int)Utilities.ReadUintBigEndian(treeData, 32);
			var stringsData = new ArraySegment<byte>(treeData, stringsOffset, stringsSize);

			var reservationBlockOffset = (int)Utilities.ReadUintBigEndian(treeData, 16);
			ReadMemoryReservationBlocks(treeData, reservationBlockOffset);
		}

		private void ReadMemoryReservationBlocks(byte[] treeData, int reservationBlockOffset)
		{
			ReservationBlock currentBlock;
			do
			{
				currentBlock = new ReservationBlock(Utilities.ReadUlongBigEndian(treeData, reservationBlockOffset),
					Utilities.ReadUlongBigEndian(treeData, reservationBlockOffset + 8));
				reservationBlockOffset += 16;
				ReservationBlocks.Add(currentBlock);
			}
			while(currentBlock != default(ReservationBlock));
		}

		private const uint Magic = 0xd00dfeed;
	}
}

