using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public partial class ModuleDefinition : IDisposable
	{
		internal PEReader peReader;
		internal SRM.MetadataReader metadata;
		MetadataOptions options;
		readonly ModuleDefinition module;

		public ModuleDefinition(string fileName, MetadataOptions options = MetadataOptions.None) : this()
		{
			if ((options & MetadataOptions.CopyImageToMemory) != 0) {
				using (var fs = File.OpenRead(fileName)) {
					Init(new PEReader(fs, PEStreamOptions.PrefetchEntireImage), options);
				}
			} else {
				Init(new PEReader(File.OpenRead(fileName)), options);
			}
		}

		public ModuleDefinition(ImmutableArray<byte> peImage, MetadataOptions options = MetadataOptions.None) : this()
		{
			Init(new PEReader(peImage), options);
		}

		private ModuleDefinition()
		{
			this.module = this;
			this.handleUsageTableLazyTask = new Lazy<Task<HandleUsageTable>>(() => Task.Run(() => new HandleUsageTable(this)));
		}

		void Init(PEReader peReader, MetadataOptions options)
		{
			if (peReader == null)
				throw new ArgumentNullException("peReader");
			this.peReader = peReader;
			this.options = options;
			SRM.MetadataReaderOptions srmOptions = 0;
			if ((options & MetadataOptions.ApplyWindowsRuntimeProjections) != 0)
				srmOptions |= SRM.MetadataReaderOptions.ApplyWindowsRuntimeProjections;
            this.metadata = peReader.GetMetadataReader(srmOptions);
        }

		internal ModuleDefinition(SRM.MetadataReader metadata, MetadataOptions options)
		{
			if (metadata == null)
				throw new ArgumentNullException("metadata");
			this.peReader = null;
			this.metadata = metadata;
			this.module = this;
			this.options = options;
		}

		public void Dispose()
		{
			metadata = null;
			if (peReader != null) {
				peReader.Dispose();
				peReader = null;
			}
		}

		public PEHeaders PEHeaders
		{
			get { return peReader != null ? peReader.PEHeaders : null; }
		}

		public MetadataOptions Options
		{
			get { return options; }
		}

#region Members from struct ModuleDefinition
		public int Generation
		{
			get { return metadata.GetModuleDefinition().Generation; }
		}

		public string Name
		{
			get { return metadata.GetString(metadata.GetModuleDefinition().Name);  }
		}

		public Guid Mvid
		{
			get { return metadata.GetGuid(metadata.GetModuleDefinition().Mvid); }
		}

		public Guid GenerationId
		{
			get { return metadata.GetGuid(metadata.GetModuleDefinition().GenerationId); }
		}

		public Guid BaseGenerationId
		{
			get { return metadata.GetGuid(metadata.GetModuleDefinition().BaseGenerationId); }
		}
		#endregion

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

		readonly Lazy<Task<HandleUsageTable>> handleUsageTableLazyTask;

		public Task<HandleUsageTable> GetHandleUsageTableAsync()
		{
			return handleUsageTableLazyTask.Value;
		}
	}
}
