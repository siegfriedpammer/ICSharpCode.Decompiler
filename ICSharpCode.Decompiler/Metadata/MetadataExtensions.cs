using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SRM = System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	/// <summary>
	/// Extension methods for System.Reflection.Metadata
	/// </summary>
	public static class MetadataExtensions
	{
		/// <summary>
		/// Returns a blob reader that reads starting from an relative virtual address in the PE image.
		/// </summary>
		/// <param name="peReader">PE reader</param>
		/// <param name="relativeVirtualAddress">The starting relative virtual address.
		/// If this parameter is 0, returns a BlobReader with length 0.</param>
		/// <param name="size">The maximum size to read. If this is bigger than the section size, the resulting reader
		/// will be limited to the section size.</param>
		public static SRM.BlobReader ReadFromRVA(this PEReader peReader, int relativeVirtualAddress, int size = int.MaxValue)
		{
			if (relativeVirtualAddress == 0)
				return default(SRM.BlobReader);
			int sectionIndex = peReader.PEHeaders.GetContainingSectionIndex(relativeVirtualAddress);
			if (sectionIndex < 0)
				return default(SRM.BlobReader);
			var section = peReader.PEHeaders.SectionHeaders[sectionIndex];
			int offsetInSection = relativeVirtualAddress - section.VirtualAddress;
			size = Math.Min(size, section.VirtualSize - offsetInSection);
			int offsetInImage = section.PointerToRawData + offsetInSection;
			peReader.GetEntireImage(out IntPtr pointer, out int imageSize);
			size = Math.Min(size, imageSize - offsetInImage);
			return new SRM.BlobReader(pointer + offsetInImage, size);
		}

		public static SRM.BlobReader ReadFromRVA(this PEReader peReader, DirectoryEntry directory)
		{
			return ReadFromRVA(peReader, directory.RelativeVirtualAddress, directory.Size);
		}

		public static TypeName GetTypeName(this SRM.MetadataReader metadata, ExportedTypeRow exportedType)
		{
			string namespaceName = metadata.GetString(exportedType.TypeNamespace);
			string name = metadata.GetString(exportedType.TypeName);
			SRM.Handle implementation = exportedType.Implementation;
			TableIndex tableIndex;
			if (!MetadataTokens.TryGetTableIndex(implementation.HandleType, out tableIndex))
				throw new BadImageFormatException();
			switch (tableIndex) {
				case TableIndex.AssemblyRef:
				case TableIndex.File:
					return new TypeName(implementation, namespaceName, name);
				case TableIndex.ExportedType:
					int rowNumber = metadata.GetRowNumber(implementation);
					ExportedTypeRow declaringType = metadata.GetExportedType(unchecked((uint)rowNumber));
					return metadata.GetTypeName(declaringType).NestedType(name);
				default:
					throw new BadImageFormatException();
			}
		}

		public static string ToHexString(this Handle handle)
		{
			return "0x" + MetadataTokens.GetToken(handle).ToString("x8");
		}
	}
}
