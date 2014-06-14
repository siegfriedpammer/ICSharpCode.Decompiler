using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.IL
{
	class ILReader
	{
		public static ILOpCode ReadOpCode(ref SRM.BlobReader reader)
		{
			byte b = reader.ReadByte();
			if (b == 0xfe)
				return (ILOpCode)(0x100 | reader.ReadByte());
			else
				return (ILOpCode)b;
		}

		internal static SRM.Handle ReadMetadataToken(ref SRM.BlobReader reader)
		{
			return SRM.Ecma335.MetadataTokens.Handle(reader.ReadInt32());
		}
	}
}
