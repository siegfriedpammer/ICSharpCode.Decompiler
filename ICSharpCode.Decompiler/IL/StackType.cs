using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	/// <summary>
	/// A type for the purpose of stack analysis.
	/// </summary>
	enum StackType
	{
		Unknown = 0,
		/// <summary>32-bit integer</summary>
		I4 = 1,
		/// <summary>64-bit integer</summary>
		I8 = 2,
		/// <summary>native-size integer</summary>
		I = 3,
		/// <summary>Floating point number</summary>
		F = 4,
		/// <summary>Another stack type. Includes objects, value types, function pointers, ...</summary>
		O = 5,
		/// <summary>A managed pointer</summary>
		Ref = 6,
		/// <summary>Represents the lack of a stack slot</summary>
		Void = 7
	}
}
