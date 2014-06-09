using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public partial class ModuleDefinition
	{
		internal readonly PEReader peReader;
		internal readonly SRM.MetadataReader metadata;

		public PEHeaders PEHeaders
		{
			get { return peReader.PEHeaders; }
		}

		/// <summary>
		/// Returns true if this module is an assembly; false if it is a secondary module of a multi-module assembly.
		/// </summary>
		public bool IsAssembly
		{
			get
			{
				return metadata.IsAssembly;
			}
		}

		public AssemblyReferenceCollection AssemblyReferences
		{
			get
			{
				return new AssemblyReferenceCollection(this, metadata.AssemblyReferences);
			}
		}

		public TypeDefinition ModuleType
		{
			get
			{
				return new TypeDefinition(this, MetadataTokens.TypeHandle(0));
			}
		}

		/// <summary>
		/// Returns a blob reader that reads starting from an relative virtual address in the PE image.
		/// </summary>
		/// <param name="peReader">PE reader</param>
		/// <param name="relativeVirtualAddress">The starting relative virtual address.
		/// If this parameter is 0, returns a BlobReader with length 0.</param>
		/// <param name="size">The maximum size to read. If this is bigger than the section size, the resulting reader
		/// will be limited to the section size.</param>
		public SRM.BlobReader ReadFromRVA(int relativeVirtualAddress, int size = int.MaxValue)
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

		public SRM.BlobReader ReadFromRVA(DirectoryEntry directory)
		{
			return ReadFromRVA(directory.RelativeVirtualAddress, directory.Size);
		}
	}
}
