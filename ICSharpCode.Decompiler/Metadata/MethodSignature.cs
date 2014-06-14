using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public enum MethodCallingConvention : byte
	{
		Default = SRM.SignatureHeader.DefaultCall,
		C = SRM.SignatureHeader.CCall,
		StdCall = SRM.SignatureHeader.StdCall,
		ThisCall = SRM.SignatureHeader.ThisCall,
		FastCall = SRM.SignatureHeader.FastCall,
		VarArg = SRM.SignatureHeader.VarArgCall
	}

	public struct MethodSignature
	{
		byte signatureHeader;
		public readonly uint GenericParamCount;
		public readonly TypeSignature ReturnType;
		public readonly TypeSignatureCollection ParameterTypes;

		public MethodSignature(Blob blob)
		{
			var reader = blob.GetReader();
			this = new MethodSignature(ref reader);
		}

		internal MethodSignature(ref BlobReader reader)
		{
			this.signatureHeader = reader.ReadByte();
			if ((signatureHeader & SRM.SignatureHeader.Generic) != 0) {
				// GENERIC
				this.GenericParamCount = Signature.ReadCompressedUInt32(ref reader);
			} else {
				GenericParamCount = 0;
			}
			uint paramCount = Signature.ReadCompressedUInt32(ref reader);
			this.ReturnType = new TypeSignature(ref reader);
			this.ParameterTypes = new TypeSignatureCollection(ref reader, paramCount);
		}

		public MethodCallingConvention CallingConvention
		{
			get { return (MethodCallingConvention)(signatureHeader & SRM.SignatureHeader.CallingConventionMask); }
		}

		public bool HasThis
		{
			get { return (signatureHeader & SRM.SignatureHeader.HasThis) != 0; }
		}

		public bool ExplicitThis
		{
			get { return (signatureHeader & SRM.SignatureHeader.ExplicitThis) != 0; }
		}
	}
}
