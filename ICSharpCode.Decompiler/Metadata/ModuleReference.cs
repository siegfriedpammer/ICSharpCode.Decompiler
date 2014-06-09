using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public struct ModuleReference : IEquatable<ModuleReference>
	{
		readonly ModuleDefinition module;
		SRM.ModuleReferenceHandle handle;

		internal ModuleReference(ModuleDefinition module, SRM.ModuleReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MethodImpl.
		/// </summary>
		public ModuleDefinition ContainingModule
		{
			get { return module; }
		}

		public bool IsNil
		{
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this MethodImpl.
		/// </summary>
		public int MetadataToken
		{
			get
			{
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle);
			}
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public string Name
		{
			get
			{
				if (module == null)
					return null;
				var stringHandle = module.metadata.GetModuleReferenceName(handle);
				return module.metadata.GetString(stringHandle);
			}
		}

		public override bool Equals(object obj)
		{
			return obj is ModuleReference && Equals((ModuleReference)obj);
		}

		public bool Equals(ModuleReference other)
		{
			return module == other.module && handle == other.handle;
		}
	}
}
