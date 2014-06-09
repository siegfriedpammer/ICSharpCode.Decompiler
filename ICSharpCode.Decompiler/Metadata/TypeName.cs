using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata
{
	/// <summary>
	/// Represents a metadata type name.
	/// </summary>
	public struct TypeName : IEquatable<TypeName>
	{
		readonly Handle assembly;
		readonly string namespaceName;
		readonly string topLevelName;
		readonly ImmutableArray<string> nestedTypeNames;

		/// <summary>
		/// The containing assembly.
		/// </summary>
		public Handle Assembly { get { return assembly; } }
		public string Namespace { get { return namespaceName; } }
		public string TopLevelName { get { return topLevelName; } }
		public ImmutableArray<string> NestedTypeNames { get { return nestedTypeNames; } }

		public bool IsNested
		{
			get { return NestedTypeNames.Length > 0; }
		}

		/// <summary>
		/// Gets the name of this type.
		/// If this type is nested, returns the innermost type name.
		/// </summary>
		public string Name
		{
			get { return NestedTypeNames.LastOrDefault() ?? TopLevelName; }
		}

		public TypeName(Handle assembly, string reflectionName)
		{
			if (reflectionName == null) {
				throw new ArgumentNullException("reflectionName");
			}
			this.assembly = assembly;
			int plus = reflectionName.IndexOf('+');
			string nsAndTopLevelName;
			if (plus >= 0) {
				string[] parts = reflectionName.Split('+');
				nsAndTopLevelName = parts[0];
				nestedTypeNames = ImmutableArray.Create(parts, 1, parts.Length - 1);
			} else {
				nsAndTopLevelName = reflectionName;
			}
			int dot = nsAndTopLevelName.LastIndexOf('.');
			if (dot < 0) {
				this.namespaceName = null;
				this.topLevelName = nsAndTopLevelName;
			} else {
				this.namespaceName = nsAndTopLevelName.Substring(0, dot);
				this.topLevelName = nsAndTopLevelName.Substring(dot + 1);
			}
		}

		public TypeName(Handle assembly, string namespaceName, string name)
		{
			if (name == null)
				throw new ArgumentNullException("name");
			this.assembly = assembly;
			this.namespaceName = namespaceName ?? string.Empty;
			this.topLevelName = name;
			this.nestedTypeNames = ImmutableArray<string>.Empty;
		}

		public TypeName(Handle assembly, string namespaceName, string topLevelName, ImmutableArray<string> nestedTypeNames)
		{
			if (topLevelName == null)
				throw new ArgumentNullException("topLevelName");
			this.assembly = assembly;
			this.namespaceName = namespaceName ?? string.Empty;
			this.topLevelName = topLevelName;
			this.nestedTypeNames = nestedTypeNames;
		}

		/// <summary>
		/// For nested types, gets the name of the declaring type.
		/// </summary>
		public TypeName GetDeclaringType()
		{
			if (nestedTypeNames.Length == 0)
				throw new InvalidOperationException();
			return new TypeName(assembly, namespaceName, topLevelName, nestedTypeNames.RemoveAt(nestedTypeNames.Length - 1));
		}

		/// <summary>
		/// Creates a nested type name.
		/// </summary>
		public TypeName NestedType(string name)
		{
			return new TypeName(assembly, namespaceName, topLevelName, nestedTypeNames.Add(name));
		}

		public override string ToString()
		{
			StringBuilder b = new StringBuilder();
			if (!string.IsNullOrEmpty(namespaceName)) {
				b.Append(namespaceName);
				b.Append('.');
			}
			b.Append(topLevelName);
			foreach (string nestedType in nestedTypeNames) {
				b.Append('+');
				b.Append(nestedType);
			}
			return b.ToString();
		}

		public override bool Equals(object obj)
		{
			return obj is TypeName && Equals((TypeName)obj);
		}

		public bool Equals(TypeName other)
		{
			if (assembly != other.assembly
				|| topLevelName != other.topLevelName
				|| namespaceName != other.namespaceName
				|| nestedTypeNames.Length != other.nestedTypeNames.Length)
				return false;
			for (int i = 0; i < nestedTypeNames.Length; i++) {
				if (nestedTypeNames[i] != other.nestedTypeNames[i])
					return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = assembly.GetHashCode();
				hash += namespaceName != null ? namespaceName.GetHashCode() * 27 : 0;
				hash += (topLevelName != null ? topLevelName.GetHashCode() : 0);
				foreach (string nestedTypeName in nestedTypeNames) {
					hash *= 31;
					hash += nestedTypeName.GetHashCode();
				}
				return hash;
			}
		}

		public static bool operator ==(TypeName left, TypeName right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(TypeName left, TypeName right)
		{
			return !left.Equals(right);
		}
	}
}
