using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public partial class Module
	{
		internal readonly PEReader peReader;
        internal readonly SRM.MetadataReader metadata;

		public TypeDefinition ModuleType
		{
			get
			{
				return new TypeDefinition(this, MetadataTokens.TypeHandle(0));
			}
		}
	}
}
