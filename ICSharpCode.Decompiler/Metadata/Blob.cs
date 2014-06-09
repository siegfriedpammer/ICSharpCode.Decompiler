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
	}
}
