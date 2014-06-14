using ICSharpCode.Decompiler.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	static class ILTypeExtensions
	{
		public static ImmutableArray<StackType> GetStackTypes(this TypeSignatureCollection typeSignatureCollection)
		{
			var result = new StackType[typeSignatureCollection.Count];
			int i = 0;
			foreach (var typeSig in typeSignatureCollection) {
				result[i++] = GetStackType(typeSig);
			}
			return ImmutableArray.Create(result);
		}

		public static StackType GetStackType(this TypeSignature typeSig)
		{
			return typeSig.SkipModifiers().TypeCode.GetStackType();
        }

		public static StackType GetStackType(this SignatureTypeCode typeCode)
		{
			switch (typeCode) {
				case SignatureTypeCode.Boolean:
				case SignatureTypeCode.Char:
				case SignatureTypeCode.SByte:
				case SignatureTypeCode.Byte:
				case SignatureTypeCode.Int16:
				case SignatureTypeCode.UInt16:
				case SignatureTypeCode.Int32:
				case SignatureTypeCode.UInt32:
					return StackType.I4;
				case SignatureTypeCode.Int64:
				case SignatureTypeCode.UInt64:
					return StackType.I8;
				case SignatureTypeCode.IntPtr:
				case SignatureTypeCode.UIntPtr:
				case SignatureTypeCode.Pointer:
					return StackType.I;
				case SignatureTypeCode.Single:
				case SignatureTypeCode.Double:
					return StackType.F;
				case SignatureTypeCode.ByReference:
					return StackType.Ref;
				case SignatureTypeCode.Void:
					return StackType.Void;
				default:
					return StackType.O;
			}
		}

		public static StackType GetStackType(this PrimitiveType primitiveType)
		{
			return ((SignatureTypeCode)primitiveType).GetStackType();
		}
	}
}
