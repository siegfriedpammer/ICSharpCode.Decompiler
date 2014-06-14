using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	public enum OperandType : byte
	{
		None,
		/// <summary>The operand is a 8-bit integer branch target.</summary>
		ShortBrTarget,
		/// <summary>The operand is a 8-bit integer.</summary>
		ShortI,
		/// <summary>The operand is a 8-bit variable or parameter index.</summary>
		ShortVar,
		/// <summary>The operand is a 16-bit variable or parameter index.</summary>
		Var,
		/// <summary>The operand is a 32-bit integer branch target.</summary>
		BrTarget,
		/// <summary>The operand is a 32-bit integer.</summary>
		I,
		/// <summary>The operand is a 32-bit floating point number.</summary>
		ShortR,
		/// <summary>The operand is a 64-bit integer.</summary>
		I8,
		/// <summary>The operand is a 64-bit floating point number.</summary>
		R,
		/// <summary>The operand is a 32-bit metadata field token.</summary>
		Field,
		/// <summary>The operand is a 32-bit metadata method token.</summary>
		Method,
		/// <summary>The operand is a 32-bit metadata signature token.</summary>
		Sig,
		/// <summary>The operand is a 32-bit metadata string token.</summary>
		String,
		/// <summary>The operand is a 32-bit metadata token.</summary>
		Tok,
		/// <summary>The operand is a 32-bit metadata type token.</summary>
		Type,
		/// <summary>The operand is ???.</summary>
		Switch,
	}
}
