using ICSharpCode.Decompiler.IL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	/// <summary>
	/// Represents a mapping from handles to the places where they are used.
	/// This can be used to efficiently find all usages of a type or method.
	/// </summary>
	public class HandleUsageTable
	{
		readonly ModuleDefinition module;

		internal HandleUsageTable(ModuleDefinition module)
		{
			this.module = module;
			foreach (var methodHandle in module.metadata.MethodDefinitions) {
				ScanMethod(methodHandle);
			}
		}

		private void ScanMethod(MethodHandle methodHandle)
		{
			var method = module.metadata.GetMethod(methodHandle);
			if (method.RelativeVirtualAddress == 0)
				return;
			var body = module.peReader.GetMethodBody(method.RelativeVirtualAddress);
			foreach (var exceptionRegion in body.ExceptionRegions) {
				Add(exceptionRegion.CatchType, methodHandle);
			}
			foreach (var type in body.GetLocalVariableTypes(module.metadata)) {
				ScanTypeSig(type, methodHandle);
			}
			var reader = body.GetILReader();
			while (reader.RemainingBytes > 0) {
				ILOpCode code = ILReader.ReadOpCode(ref reader);
				switch (code.GetOperandType()) {
					case OperandType.None:
						break;
					case OperandType.ShortBrTarget:
					case OperandType.ShortI:
					case OperandType.ShortVar:
						reader.ReadByte();
						break;
					case OperandType.Var:
						reader.ReadInt16();
						break;
					case OperandType.BrTarget:
					case OperandType.I:
					case OperandType.ShortR:
						reader.ReadInt32();
						break;
					case OperandType.I8:
					case OperandType.R:
						reader.ReadInt64();
						break;
					case OperandType.Field:
					case OperandType.Method:
					case OperandType.Sig:
					case OperandType.String:
					case OperandType.Tok:
					case OperandType.Type:
						Add(ILReader.ReadMetadataToken(ref reader), methodHandle);
						break;
					case OperandType.Switch:
						throw new NotImplementedException();
					default:
						throw new NotSupportedException();
				}
			}
		}

		private void ScanTypeSig(TypeSignature type, MethodHandle methodHandle)
		{
			throw new NotImplementedException();
		}

		private void Add(Handle handle, MethodHandle methodHandle)
		{
			if (handle.IsNil)
				return;
			if (handle.HandleType == HandleType.TypeSpecification) {
				var blobHandle = module.metadata.GetSignature((TypeSpecificationHandle)handle);
				var reader = module.metadata.GetReader(blobHandle);
				ScanTypeSig(new TypeSignature(ref reader), methodHandle);
				return;
			}
			throw new NotImplementedException();
		}
	}
}
