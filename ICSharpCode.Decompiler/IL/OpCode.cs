using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	enum OpCode
	{
		Nop,
		/// <summary>Invalid opcode.</summary>
		Invalid,
		/// <summary>
		/// Unary operator that expects an input of type I4.
		/// Pushes 1 (of type I4) if the input value is 0. Otherwise, pushes 0 (of type I4).
		/// </summary>
		LogicNot,
		Add,
		BitAnd,
		Arglist,
		/// <summary>
		/// <c>if (cond) goto target;</c>
		/// Depending on the phase, this is represented by an UnresolvedBranchInstruction or TODO. 
		/// </summary>
		ConditionalBranch,
		/// <summary>
		/// <c>goto target;</c>
		/// Depending on the phase, this is represented by an UnresolvedBranchInstruction or TODO. 
		/// </summary>
		Branch,
		Break,
		Ceq,
		Cgt,
		Cgt_Un,
		Clt,
		Clt_Un,
		Call,
		Ckfinite,
		Conv,
		Div,
		Dup,
	}
}
