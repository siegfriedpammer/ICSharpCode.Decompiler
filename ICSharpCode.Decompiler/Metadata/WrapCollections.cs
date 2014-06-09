// Copyright (c) 2014 Daniel Grunwald
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SRM = System.Reflection.Metadata;
namespace ICSharpCode.Decompiler.Metadata
{
	public partial struct TypeDefinitionCollection : IReadOnlyCollection<TypeDefinition>
	{
		readonly ModuleDefinition module;
		SRM.TypeHandleCollection handleCollection;

		internal TypeDefinitionCollection(ModuleDefinition module, SRM.TypeHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeDefinition> IEnumerable<TypeDefinition>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeDefinition>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeDefinition>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.TypeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.TypeHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public TypeDefinition Current {
				get {
					return new TypeDefinition(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct MethodImplCollection : IReadOnlyCollection<MethodImpl>
	{
		readonly ModuleDefinition module;
		SRM.MethodImplementationHandleCollection handleCollection;

		internal MethodImplCollection(ModuleDefinition module, SRM.MethodImplementationHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<MethodImpl> IEnumerable<MethodImpl>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<MethodImpl>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MethodImplementationHandle, MethodImpl>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<MethodImpl>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MethodImplementationHandle, MethodImpl>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.MethodImplementationHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.MethodImplementationHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public MethodImpl Current {
				get {
					return new MethodImpl(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct AssemblyFileCollection : IReadOnlyCollection<AssemblyFile>
	{
		readonly ModuleDefinition module;
		SRM.AssemblyFileHandleCollection handleCollection;

		internal AssemblyFileCollection(ModuleDefinition module, SRM.AssemblyFileHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<AssemblyFile> IEnumerable<AssemblyFile>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<AssemblyFile>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.AssemblyFileHandle, AssemblyFile>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<AssemblyFile>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.AssemblyFileHandle, AssemblyFile>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.AssemblyFileHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.AssemblyFileHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public AssemblyFile Current {
				get {
					return new AssemblyFile(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct AssemblyReferenceCollection : IReadOnlyCollection<AssemblyReference>
	{
		readonly ModuleDefinition module;
		SRM.AssemblyReferenceHandleCollection handleCollection;

		internal AssemblyReferenceCollection(ModuleDefinition module, SRM.AssemblyReferenceHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<AssemblyReference> IEnumerable<AssemblyReference>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<AssemblyReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.AssemblyReferenceHandle, AssemblyReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<AssemblyReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.AssemblyReferenceHandle, AssemblyReference>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.AssemblyReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.AssemblyReferenceHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public AssemblyReference Current {
				get {
					return new AssemblyReference(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct CustomAttributeCollection : IReadOnlyCollection<CustomAttribute>
	{
		readonly ModuleDefinition module;
		SRM.CustomAttributeHandleCollection handleCollection;

		internal CustomAttributeCollection(ModuleDefinition module, SRM.CustomAttributeHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<CustomAttribute> IEnumerable<CustomAttribute>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<CustomAttribute>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.CustomAttributeHandle, CustomAttribute>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<CustomAttribute>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.CustomAttributeHandle, CustomAttribute>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.CustomAttributeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.CustomAttributeHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public CustomAttribute Current {
				get {
					return new CustomAttribute(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct DeclarativeSecurityAttributeCollection : IReadOnlyCollection<DeclarativeSecurityAttribute>
	{
		readonly ModuleDefinition module;
		SRM.DeclarativeSecurityAttributeHandleCollection handleCollection;

		internal DeclarativeSecurityAttributeCollection(ModuleDefinition module, SRM.DeclarativeSecurityAttributeHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<DeclarativeSecurityAttribute> IEnumerable<DeclarativeSecurityAttribute>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<DeclarativeSecurityAttribute>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.DeclarativeSecurityAttributeHandle, DeclarativeSecurityAttribute>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<DeclarativeSecurityAttribute>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.DeclarativeSecurityAttributeHandle, DeclarativeSecurityAttribute>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.DeclarativeSecurityAttributeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.DeclarativeSecurityAttributeHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public DeclarativeSecurityAttribute Current {
				get {
					return new DeclarativeSecurityAttribute(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct EventCollection : IReadOnlyCollection<Event>
	{
		readonly ModuleDefinition module;
		SRM.EventHandleCollection handleCollection;

		internal EventCollection(ModuleDefinition module, SRM.EventHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Event> IEnumerable<Event>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Event>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.EventHandle, Event>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Event>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.EventHandle, Event>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.EventHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.EventHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public Event Current {
				get {
					return new Event(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct FieldCollection : IReadOnlyCollection<Field>
	{
		readonly ModuleDefinition module;
		SRM.FieldHandleCollection handleCollection;

		internal FieldCollection(ModuleDefinition module, SRM.FieldHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Field>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.FieldHandle, Field>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Field>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.FieldHandle, Field>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.FieldHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.FieldHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public Field Current {
				get {
					return new Field(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct GenericParameterCollection : IReadOnlyCollection<GenericParameter>
	{
		readonly ModuleDefinition module;
		SRM.GenericParameterHandleCollection handleCollection;

		internal GenericParameterCollection(ModuleDefinition module, SRM.GenericParameterHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<GenericParameter> IEnumerable<GenericParameter>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<GenericParameter>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.GenericParameterHandle, GenericParameter>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<GenericParameter>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.GenericParameterHandle, GenericParameter>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.GenericParameterHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.GenericParameterHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public GenericParameter Current {
				get {
					return new GenericParameter(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct GenericParameterConstraintCollection : IReadOnlyCollection<GenericParameterConstraint>
	{
		readonly ModuleDefinition module;
		SRM.GenericParameterConstraintHandleCollection handleCollection;

		internal GenericParameterConstraintCollection(ModuleDefinition module, SRM.GenericParameterConstraintHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<GenericParameterConstraint> IEnumerable<GenericParameterConstraint>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<GenericParameterConstraint>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.GenericParameterConstraintHandle, GenericParameterConstraint>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<GenericParameterConstraint>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.GenericParameterConstraintHandle, GenericParameterConstraint>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.GenericParameterConstraintHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.GenericParameterConstraintHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public GenericParameterConstraint Current {
				get {
					return new GenericParameterConstraint(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct ManifestResourceCollection : IReadOnlyCollection<ManifestResource>
	{
		readonly ModuleDefinition module;
		SRM.ManifestResourceHandleCollection handleCollection;

		internal ManifestResourceCollection(ModuleDefinition module, SRM.ManifestResourceHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<ManifestResource> IEnumerable<ManifestResource>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<ManifestResource>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.ManifestResourceHandle, ManifestResource>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<ManifestResource>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.ManifestResourceHandle, ManifestResource>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.ManifestResourceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.ManifestResourceHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public ManifestResource Current {
				get {
					return new ManifestResource(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct MemberReferenceCollection : IReadOnlyCollection<MemberReference>
	{
		readonly ModuleDefinition module;
		SRM.MemberReferenceHandleCollection handleCollection;

		internal MemberReferenceCollection(ModuleDefinition module, SRM.MemberReferenceHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<MemberReference> IEnumerable<MemberReference>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<MemberReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MemberReferenceHandle, MemberReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<MemberReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MemberReferenceHandle, MemberReference>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.MemberReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.MemberReferenceHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public MemberReference Current {
				get {
					return new MemberReference(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct MethodCollection : IReadOnlyCollection<Method>
	{
		readonly ModuleDefinition module;
		SRM.MethodHandleCollection handleCollection;

		internal MethodCollection(ModuleDefinition module, SRM.MethodHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Method> IEnumerable<Method>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Method>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MethodHandle, Method>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Method>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.MethodHandle, Method>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.MethodHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.MethodHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public Method Current {
				get {
					return new Method(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct ParameterCollection : IReadOnlyCollection<Parameter>
	{
		readonly ModuleDefinition module;
		SRM.ParameterHandleCollection handleCollection;

		internal ParameterCollection(ModuleDefinition module, SRM.ParameterHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Parameter> IEnumerable<Parameter>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Parameter>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.ParameterHandle, Parameter>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Parameter>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.ParameterHandle, Parameter>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.ParameterHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.ParameterHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public Parameter Current {
				get {
					return new Parameter(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct PropertyCollection : IReadOnlyCollection<Property>
	{
		readonly ModuleDefinition module;
		SRM.PropertyHandleCollection handleCollection;

		internal PropertyCollection(ModuleDefinition module, SRM.PropertyHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Property> IEnumerable<Property>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Property>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.PropertyHandle, Property>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<Property>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.PropertyHandle, Property>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.PropertyHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.PropertyHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public Property Current {
				get {
					return new Property(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct TypeForwarderCollection : IEnumerable<TypeForwarder>
	{
		readonly ModuleDefinition module;
		SRM.TypeForwarderHandleCollection handleCollection;

		internal TypeForwarderCollection(ModuleDefinition module, SRM.TypeForwarderHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}


		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeForwarder> IEnumerable<TypeForwarder>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeForwarder>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeForwarderHandle, TypeForwarder>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeForwarder>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeForwarderHandle, TypeForwarder>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.TypeForwarderHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.TypeForwarderHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public TypeForwarder Current {
				get {
					return new TypeForwarder(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct TypeReferenceCollection : IReadOnlyCollection<TypeReference>
	{
		readonly ModuleDefinition module;
		SRM.TypeReferenceHandleCollection handleCollection;

		internal TypeReferenceCollection(ModuleDefinition module, SRM.TypeReferenceHandleCollection handleCollection)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handleCollection = handleCollection;
		}

		public int Count {
			get {
				return module != null ? handleCollection.Count : 0;
			}
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeReference> IEnumerable<TypeReference>.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeReferenceHandle, TypeReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (module == null)
				return Enumerable.Empty<TypeReference>().GetEnumerator();
			return this.handleCollection.Select(new Func<SRM.TypeReferenceHandle, TypeReference>(module.FromHandle)).GetEnumerator();
		}
		
		public struct Enumerator
		{
			readonly ModuleDefinition module;
			SRM.TypeReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(ModuleDefinition module, SRM.TypeReferenceHandleCollection.Enumerator handleEnumerator)
			{
				this.module = module;
				this.handleEnumerator = handleEnumerator;
			}
			
			public TypeReference Current {
				get {
					return new TypeReference(module, handleEnumerator.Current);
				}
			}

			public bool MoveNext()
			{
				if (module == null)
					return false;
				return handleEnumerator.MoveNext();
			}
		}
	}
}