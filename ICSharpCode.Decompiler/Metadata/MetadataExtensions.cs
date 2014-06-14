using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using SRM = System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	/// <summary>
	/// Extension methods for System.Reflection.Metadata
	/// </summary>
	public static class MetadataExtensions
	{
		/// <summary>
		/// Workaround for inconsistent naming; used by the generated code.
		/// </summary>
		internal static SRM.MethodImpl GetMethodImpl(this SRM.MetadataReader metadata, MethodImplementationHandle handle)
		{
			return metadata.GetMethodImplementation(handle);
		}

		public static TypeName GetTypeName(this SRM.MetadataReader metadata, ExportedTypeRow exportedType)
		{
			string namespaceName = metadata.GetString(exportedType.TypeNamespace);
			string name = metadata.GetString(exportedType.TypeName);
			SRM.Handle implementation = exportedType.Implementation;
			TableIndex tableIndex;
			if (!MetadataTokens.TryGetTableIndex(implementation.HandleType, out tableIndex))
				throw new BadImageFormatException();
			switch (tableIndex) {
				case TableIndex.AssemblyRef:
				case TableIndex.File:
					return new TypeName(implementation, namespaceName, name);
				case TableIndex.ExportedType:
					int rowNumber = metadata.GetRowNumber(implementation);
					ExportedTypeRow declaringType = metadata.GetExportedType(unchecked((uint)rowNumber));
					return metadata.GetTypeName(declaringType).NestedType(name);
				default:
					throw new BadImageFormatException();
			}
		}

		public static string ToHexString(this Handle handle)
		{
			return "0x" + MetadataTokens.GetToken(handle).ToString("x8");
		}

		public static TypeSignatureCollection GetLocalVariableTypes(this MethodBodyBlock body, MetadataReader metadata)
		{
			if (body == null)
				throw new ArgumentNullException("body");
			if (body.LocalSignature.IsNil)
				return new TypeSignatureCollection();
			var localSigBlobHandle = metadata.GetLocalSignature(body.LocalSignature);
			var localSigReader = metadata.GetReader(localSigBlobHandle);
			if (localSigReader.ReadByte() != SRM.SignatureHeader.LocalVar)
				throw new BadImageFormatException();
			var count = localSigReader.ReadUInt16();
			return new TypeSignatureCollection(ref localSigReader, count);
		}
	}
}
