using System;
using NUnit.Framework;
using FdtSharp;
using System.IO;

namespace FdtSharpWithTests
{
	[TestFixture]
	public class OpeningTests
	{
		[Test]
		public void ShouldReadHeader()
		{
			var fdt = new FlattenDeviceTree(File.ReadAllBytes(Utilities.GetBinaryLocation("xilinx_zynq_iic.dtb")));
			Assert.AreEqual(17, fdt.Version);
			Assert.AreEqual(16, fdt.LastCompatibleVersion);
		}

	}
}

