using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	public struct TypeSignature
	{
		const SignatureTypeCode ELEMENT_TYPE_VALUETYPE = (SignatureTypeCode)17;
		const SignatureTypeCode ELEMENT_TYPE_CLASS = (SignatureTypeCode)18;
		const byte FLAG_VALUETYPE = 0x80;

		readonly SignatureTypeCode signatureHeader;
		readonly BlobReader reader;

		public TypeSignature(Blob blob)
		{
			BlobReader reader = blob.GetReader();
			this = new TypeSignature(ref reader);
		}

		internal TypeSignature(ref BlobReader reader)
		{
			this.signatureHeader = (SignatureTypeCode)reader.ReadByte();
			this.reader = reader;
			switch (signatureHeader) {
				case SignatureTypeCode.Void:
				case SignatureTypeCode.Boolean:
				case SignatureTypeCode.Char:
				case SignatureTypeCode.SByte:
				case SignatureTypeCode.Byte:
				case SignatureTypeCode.Int16:
				case SignatureTypeCode.UInt16:
				case SignatureTypeCode.Int32:
				case SignatureTypeCode.UInt32:
				case SignatureTypeCode.Int64:
				case SignatureTypeCode.UInt64:
				case SignatureTypeCode.Single:
				case SignatureTypeCode.Double:
				case SignatureTypeCode.String:
				case SignatureTypeCode.TypedReference:
				case SignatureTypeCode.IntPtr:
				case SignatureTypeCode.UIntPtr:
                case SignatureTypeCode.Object:
				case SignatureTypeCode.Sentinel:
					break;	 // nothing to do for simple types
				case SignatureTypeCode.Pointer:
				case SignatureTypeCode.ByReference:
				case SignatureTypeCode.SZArray:
				case SignatureTypeCode.Pinned:
					new TypeSignature(ref reader);	 // skip element type
					break;
				case SignatureTypeCode.GenericTypeParameter:
				case SignatureTypeCode.GenericMethodParameter:
					Signature.ReadCompressedUInt32(ref reader);
					break;
				case SignatureTypeCode.GenericTypeInstance:
					reader.ReadByte();	 // isValueType
					reader.ReadTypeHandle(); // elementType
					uint arity = Signature.ReadCompressedUInt32(ref reader);
					new TypeSignatureCollection(ref reader, arity);	// typeArguments
					break;
				case SignatureTypeCode.FunctionPointer:
					new MethodSignature(ref reader);
					break;
				case SignatureTypeCode.Array:
					new TypeSignature(ref reader);	 // skip element type
					Signature.ReadCompressedUInt32(ref reader);	// skip rank
					Signature.SkipUIntList(ref reader);	// skip sizes
					Signature.SkipUIntList(ref reader);	// skip low_bounds
					break;
				case SignatureTypeCode.RequiredModifier:
				case SignatureTypeCode.OptionalModifier:
					reader.ReadTypeHandle(); // modifierType
					new TypeSignature(ref reader);	 // elementType
					break;
				case ELEMENT_TYPE_CLASS:
				case ELEMENT_TYPE_VALUETYPE:
					reader.ReadTypeHandle();
					break;
				default:
					throw new BadImageFormatException("Invalid type signature");
			}
		}

		public SignatureTypeCode TypeCode
		{
			get
			{
				if (signatureHeader == ELEMENT_TYPE_CLASS || signatureHeader == ELEMENT_TYPE_VALUETYPE) {
					return SignatureTypeCode.TypeHandle;
				}
				return signatureHeader;
			}
		}

		public TypeSignature SkipModifiers()
		{
			if (!IsModifier(signatureHeader))
				return this;
			BlobReader r = this.reader;
			do {
				r.ReadTypeHandle();
			} while (IsModifier((SignatureTypeCode)PeekByte(r)));
			return new TypeSignature(ref r);
		}

		private static bool IsModifier(SignatureTypeCode typeCode)
		{
			return typeCode == SignatureTypeCode.OptionalModifier || typeCode == SignatureTypeCode.RequiredModifier;
		}

		private static byte PeekByte(BlobReader r)
		{
			// because the BlobReader is passed by value, this method peeks instead of reading
			return r.ReadByte();
		}
	}
}
