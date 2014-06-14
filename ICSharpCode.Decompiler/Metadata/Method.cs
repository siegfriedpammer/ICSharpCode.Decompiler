using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

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

		public SRM.MethodBodyBlock GetBody()
		{
			if (this.RelativeVirtualAddress == 0)
				return null;
			return module.peReader.GetMethodBody(this.RelativeVirtualAddress);
		}
    }
}
