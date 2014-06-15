using Mono.Cecil.Cil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Disassembler
{
	static class CecilExtensions
	{
		/// <summary>
		/// Gets the (exclusive) end offset of this instruction.
		/// </summary>
		public static int GetEndOffset(this Instruction inst)
		{
			if (inst == null)
				throw new ArgumentNullException("inst");
			return inst.Offset + inst.GetSize();
		}

		public static bool IsUnconditionalBranch(this OpCode opcode)
		{
			if (opcode.OpCodeType == OpCodeType.Prefix)
				return false;
			switch (opcode.FlowControl) {
				case FlowControl.Branch:
				case FlowControl.Throw:
				case FlowControl.Return:
					return true;
				case FlowControl.Next:
				case FlowControl.Call:
				case FlowControl.Cond_Branch:
					return false;
				default:
					throw new NotSupportedException(opcode.FlowControl.ToString());
			}
		}
	}
}
