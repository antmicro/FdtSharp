using System;
using NUnit.Framework;
using FdtSharp;
using System.IO;

namespace FdtSharpWithTests
{
	[TestFixture]
	public class WritingTests
	{
		[Test]
		public void ShouldRewriteProperTree()
		{
			var fdt = new FlattenDeviceTree(File.ReadAllBytes(Utilities.GetBinaryLocation("xilinx_zynq_iic.dtb")));
			fdt.GetBinaryBlob();
		}
	}
}

