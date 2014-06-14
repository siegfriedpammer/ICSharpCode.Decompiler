using ICSharpCode.Decompiler.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	enum PrimitiveType : byte
	{
		None = SignatureTypeCode.Invalid,
		I1 = SignatureTypeCode.SByte,
		I2 = SignatureTypeCode.Int16,
		I4 = SignatureTypeCode.Int32,
		I8 = SignatureTypeCode.Int64,
		R4 = SignatureTypeCode.Single,
		R8 = SignatureTypeCode.Double,
		U1 = SignatureTypeCode.Byte,
		U2 = SignatureTypeCode.UInt16,
		U4 = SignatureTypeCode.UInt32,
		U8 = SignatureTypeCode.UInt64,
		I = SignatureTypeCode.IntPtr,
		U = SignatureTypeCode.UIntPtr,
	}
}
