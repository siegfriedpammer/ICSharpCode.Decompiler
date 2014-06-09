using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	partial struct Method
	{
		public bool IsStatic
		{
			get
			{
				return (this.Attributes & MethodAttributes.Static) != 0;
			}
		}

		public bool IsTypeInitializer
		{
			get
			{
				return this.IsStatic && this.Name == ".cctor";
			}
		}
    }
}
