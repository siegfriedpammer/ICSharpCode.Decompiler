using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	partial struct TypeDefinition
	{
		public ImmutableArray<TypeDefinition> GetNestedTypes()
		{
			var module = this.module;
			if (module == null)
				return default(ImmutableArray<TypeDefinition>);
			var target = module.metadata.GetTypeDefinition(handle);
			return target.GetNestedTypes().Select(h => new TypeDefinition(module, h)).ToImmutableArray();
		}

		public bool GetTypeLayout(out uint size, out uint packingSize)
		{
			if (module == null) {
				size = 0;
				packingSize = 0;
				return false;
			}
			var target = module.metadata.GetTypeDefinition(handle);
			return target.GetTypeLayout(out size, out packingSize);
		}

		public Method GetTypeInitializer()
		{
			foreach (var method in this.GetMethods()) {
				if (method.IsTypeInitializer)
					return method;
			}
			return default(Method);
		}

	}
}
