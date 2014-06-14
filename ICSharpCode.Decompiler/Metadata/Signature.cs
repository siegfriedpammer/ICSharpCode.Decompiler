using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	class Signature
	{
		public static uint ReadCompressedUInt32(ref BlobReader reader)
		{
			uint val;
			if (reader.TryReadCompressedUInt32(out val))
				return val;
			else
				throw new BadImageFormatException("Could not read compressed uint32");
		}

		internal static void SkipUIntList(ref BlobReader reader)
		{
			uint length = ReadCompressedUInt32(ref reader);
			for (uint i = 0; i < length; i++) {
				ReadCompressedUInt32(ref reader);
			}
		}
	}
}
