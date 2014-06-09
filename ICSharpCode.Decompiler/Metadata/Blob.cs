using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	public struct Blob
	{
		readonly Module module;
		readonly BlobHandle handle;

		public Blob(Module module, BlobHandle handle)
		{
			this.module = module;
			this.handle = handle;
		}

		static readonly byte[] emptyByteArray = new byte[0];

		public byte[] GetBytes()
		{
			if (module == null)
				return emptyByteArray;
			return module.metadata.GetBytes(handle);
		}

		public BlobReader GetReader()
		{
			if (module == null)
				return default(BlobReader);
			return module.metadata.GetReader(handle);
		}
	}
}
