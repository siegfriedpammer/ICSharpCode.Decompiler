using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler
{
	static class MetadataExtensions
	{
		/// <summary>
		/// Returns a blob reader that reads starting from an relative virtual address in the PE image.
		/// </summary>
		/// <param name="peReader">PE reader</param>
		/// <param name="relativeVirtualAddress">The starting relative virtual address.
		/// If this parameter is 0, returns a BlobReader with length 0.</param>
		/// <param name="size">The maximum size to read. If this is bigger than the section size, the resulting reader
		/// will be limited to the section size.</param>
		public static unsafe BlobReader ReadFromRVA(this PEReader peReader, int relativeVirtualAddress, int size = int.MaxValue)
		{
			if (relativeVirtualAddress == 0)
				return default(BlobReader);
			int sectionIndex = peReader.PEHeaders.GetContainingSectionIndex(relativeVirtualAddress);
			if (sectionIndex < 0)
				return default(BlobReader);
			var section = peReader.PEHeaders.SectionHeaders[sectionIndex];
			int offsetInSection = relativeVirtualAddress - section.VirtualAddress;
			size = Math.Min(size, section.VirtualSize - offsetInSection);
			int offsetInImage = section.PointerToRawData + offsetInSection;
			peReader.GetEntireImage(out IntPtr pointer, out int imageSize);
			size = Math.Min(size, imageSize - offsetInImage);
			return new BlobReader(pointer + offsetInImage, size);
		}

		public static unsafe BlobReader ReadFromRVA(this PEReader peReader, DirectoryEntry directory)
		{
			return ReadFromRVA(peReader, directory.RelativeVirtualAddress, directory.Size);
		}
	}
}
