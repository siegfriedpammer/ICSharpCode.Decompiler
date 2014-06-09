using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	[Flags]
	public enum MetadataOptions
	{
		None = 0,
		CopyImageToMemory = 1,
		ApplyWindowsRuntimeProjections = 2,
	}
}
