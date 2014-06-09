using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	class Type
	{
		public static implicit operator Type(TypeReference typeRef)
		{
			throw new NotSupportedException();
		}

		public static implicit operator Type(TypeDefinition typeRef)
		{
			throw new NotSupportedException();
		}

		public static implicit operator Type(SRM.Handle handle)
		{
			throw new NotSupportedException();
		}
	}
}
