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
using System.Linq;
using SRM = System.Reflection.Metadata;
namespace ICSharpCode.Decompiler.Metadata
{
	public partial struct AssemblyFileCollection : IEnumerable<AssemblyFile>
	{
		readonly Module module;
		SRM.AssemblyFileHandleCollection handleCollection;

		internal AssemblyFileCollection(Module module, SRM.AssemblyFileHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this AssemblyFileCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<AssemblyFile> IEnumerable<AssemblyFile>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.AssemblyFileHandle, AssemblyFile>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.AssemblyFileHandle, AssemblyFile>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.AssemblyFileHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.AssemblyFileHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct AssemblyReferenceCollection : IEnumerable<AssemblyReference>
	{
		readonly Module module;
		SRM.AssemblyReferenceHandleCollection handleCollection;

		internal AssemblyReferenceCollection(Module module, SRM.AssemblyReferenceHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this AssemblyReferenceCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<AssemblyReference> IEnumerable<AssemblyReference>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.AssemblyReferenceHandle, AssemblyReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.AssemblyReferenceHandle, AssemblyReference>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.AssemblyReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.AssemblyReferenceHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct CustomAttributeCollection : IEnumerable<CustomAttribute>
	{
		readonly Module module;
		SRM.CustomAttributeHandleCollection handleCollection;

		internal CustomAttributeCollection(Module module, SRM.CustomAttributeHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this CustomAttributeCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<CustomAttribute> IEnumerable<CustomAttribute>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.CustomAttributeHandle, CustomAttribute>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.CustomAttributeHandle, CustomAttribute>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.CustomAttributeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.CustomAttributeHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct DeclarativeSecurityAttributeCollection : IEnumerable<DeclarativeSecurityAttribute>
	{
		readonly Module module;
		SRM.DeclarativeSecurityAttributeHandleCollection handleCollection;

		internal DeclarativeSecurityAttributeCollection(Module module, SRM.DeclarativeSecurityAttributeHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this DeclarativeSecurityAttributeCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<DeclarativeSecurityAttribute> IEnumerable<DeclarativeSecurityAttribute>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.DeclarativeSecurityAttributeHandle, DeclarativeSecurityAttribute>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.DeclarativeSecurityAttributeHandle, DeclarativeSecurityAttribute>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.DeclarativeSecurityAttributeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.DeclarativeSecurityAttributeHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct EventCollection : IEnumerable<Event>
	{
		readonly Module module;
		SRM.EventHandleCollection handleCollection;

		internal EventCollection(Module module, SRM.EventHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this EventCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Event> IEnumerable<Event>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.EventHandle, Event>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.EventHandle, Event>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.EventHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.EventHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct FieldCollection : IEnumerable<Field>
	{
		readonly Module module;
		SRM.FieldHandleCollection handleCollection;

		internal FieldCollection(Module module, SRM.FieldHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this FieldCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Field> IEnumerable<Field>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.FieldHandle, Field>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.FieldHandle, Field>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.FieldHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.FieldHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct GenericParameterCollection : IEnumerable<GenericParameter>
	{
		readonly Module module;
		SRM.GenericParameterHandleCollection handleCollection;

		internal GenericParameterCollection(Module module, SRM.GenericParameterHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this GenericParameterCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<GenericParameter> IEnumerable<GenericParameter>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.GenericParameterHandle, GenericParameter>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.GenericParameterHandle, GenericParameter>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.GenericParameterHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.GenericParameterHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct GenericParameterConstraintCollection : IEnumerable<GenericParameterConstraint>
	{
		readonly Module module;
		SRM.GenericParameterConstraintHandleCollection handleCollection;

		internal GenericParameterConstraintCollection(Module module, SRM.GenericParameterConstraintHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this GenericParameterConstraintCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<GenericParameterConstraint> IEnumerable<GenericParameterConstraint>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.GenericParameterConstraintHandle, GenericParameterConstraint>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.GenericParameterConstraintHandle, GenericParameterConstraint>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.GenericParameterConstraintHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.GenericParameterConstraintHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct ManifestResourceCollection : IEnumerable<ManifestResource>
	{
		readonly Module module;
		SRM.ManifestResourceHandleCollection handleCollection;

		internal ManifestResourceCollection(Module module, SRM.ManifestResourceHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this ManifestResourceCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<ManifestResource> IEnumerable<ManifestResource>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.ManifestResourceHandle, ManifestResource>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.ManifestResourceHandle, ManifestResource>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.ManifestResourceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.ManifestResourceHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct MemberReferenceCollection : IEnumerable<MemberReference>
	{
		readonly Module module;
		SRM.MemberReferenceHandleCollection handleCollection;

		internal MemberReferenceCollection(Module module, SRM.MemberReferenceHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this MemberReferenceCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<MemberReference> IEnumerable<MemberReference>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.MemberReferenceHandle, MemberReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.MemberReferenceHandle, MemberReference>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.MemberReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.MemberReferenceHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct MethodCollection : IEnumerable<Method>
	{
		readonly Module module;
		SRM.MethodHandleCollection handleCollection;

		internal MethodCollection(Module module, SRM.MethodHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this MethodCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Method> IEnumerable<Method>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.MethodHandle, Method>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.MethodHandle, Method>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.MethodHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.MethodHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct ParameterCollection : IEnumerable<Parameter>
	{
		readonly Module module;
		SRM.ParameterHandleCollection handleCollection;

		internal ParameterCollection(Module module, SRM.ParameterHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this ParameterCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Parameter> IEnumerable<Parameter>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.ParameterHandle, Parameter>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.ParameterHandle, Parameter>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.ParameterHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.ParameterHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct PropertyCollection : IEnumerable<Property>
	{
		readonly Module module;
		SRM.PropertyHandleCollection handleCollection;

		internal PropertyCollection(Module module, SRM.PropertyHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this PropertyCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<Property> IEnumerable<Property>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.PropertyHandle, Property>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.PropertyHandle, Property>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.PropertyHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.PropertyHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct TypeForwarderCollection : IEnumerable<TypeForwarder>
	{
		readonly Module module;
		SRM.TypeForwarderHandleCollection handleCollection;

		internal TypeForwarderCollection(Module module, SRM.TypeForwarderHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this TypeForwarderCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeForwarder> IEnumerable<TypeForwarder>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeForwarderHandle, TypeForwarder>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeForwarderHandle, TypeForwarder>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.TypeForwarderHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.TypeForwarderHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct TypeReferenceCollection : IEnumerable<TypeReference>
	{
		readonly Module module;
		SRM.TypeReferenceHandleCollection handleCollection;

		internal TypeReferenceCollection(Module module, SRM.TypeReferenceHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this TypeReferenceCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeReference> IEnumerable<TypeReference>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeReferenceHandle, TypeReference>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeReferenceHandle, TypeReference>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.TypeReferenceHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.TypeReferenceHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
	public partial struct TypeDefinitionCollection : IEnumerable<TypeDefinition>
	{
		readonly Module module;
		SRM.TypeHandleCollection handleCollection;

		internal TypeDefinitionCollection(Module module, SRM.TypeHandleCollection handleCollection)
		{
			this.module = module;
			this.handleCollection = handleCollection;
		}

		/// <summary>
		/// Gets the module containing this TypeDefinitionCollection.
		/// </summary>
		public Module ContainingModule {
			get { return module; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(module, handleCollection.GetEnumerator());
		}

		IEnumerator<TypeDefinition> IEnumerable<TypeDefinition>.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.handleCollection.Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle)).GetEnumerator();
		}

		public struct Enumerator
		{
			readonly Module module;
			SRM.TypeHandleCollection.Enumerator handleEnumerator;

			internal Enumerator(Module module, SRM.TypeHandleCollection.Enumerator handleEnumerator)
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
				return handleEnumerator.MoveNext();
			}
		}
	}
}