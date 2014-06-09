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
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Diagnostics;
using SRM = System.Reflection.Metadata;
namespace ICSharpCode.Decompiler.Metadata
{
	public partial struct TypeDefinition : IEquatable<TypeDefinition>
	{
		readonly ModuleDefinition module;
		SRM.TypeHandle handle;

		internal TypeDefinition(ModuleDefinition module, SRM.TypeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeDefinition.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this TypeDefinition.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.TypeAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.TypeAttributes);
				var target = module.metadata.GetTypeDefinition(handle);
				return target.Attributes;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeDefinition(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public NamespaceDefinition Namespace {
			get {
				if (handle.IsNil)
					return default(NamespaceDefinition);
				var target = module.metadata.GetTypeDefinition(handle);
				return new NamespaceDefinition(module, target.Namespace);
			}
		}
		public System.Reflection.Metadata.Handle BaseType {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetTypeDefinition(handle);
				return target.BaseType;
			}
		}

		public TypeDefinition GetDeclaringType()
		{
			if (handle.IsNil)
				return default(TypeDefinition);
			var target = module.metadata.GetTypeDefinition(handle);
			return new TypeDefinition(module, target.GetDeclaringType());
		}
		public GenericParameterCollection GetGenericParameters()
		{
			if (handle.IsNil)
				return default(GenericParameterCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new GenericParameterCollection(module, target.GetGenericParameters());
		}
		public MethodCollection GetMethods()
		{
			if (handle.IsNil)
				return default(MethodCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new MethodCollection(module, target.GetMethods());
		}
		public FieldCollection GetFields()
		{
			if (handle.IsNil)
				return default(FieldCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new FieldCollection(module, target.GetFields());
		}
		public PropertyCollection GetProperties()
		{
			if (handle.IsNil)
				return default(PropertyCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new PropertyCollection(module, target.GetProperties());
		}
		public EventCollection GetEvents()
		{
			if (handle.IsNil)
				return default(EventCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new EventCollection(module, target.GetEvents());
		}
		public IEnumerable<TypeDefinition> GetNestedTypes()
		{
			if (handle.IsNil)
				return default(IEnumerable<TypeDefinition>);
			var target = module.metadata.GetTypeDefinition(handle);
			return target.GetNestedTypes().Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle));
		}
		public MethodImplCollection GetMethodImplementations()
		{
			if (handle.IsNil)
				return default(MethodImplCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new MethodImplCollection(module, target.GetMethodImplementations());
		}
		public System.Reflection.Metadata.InterfaceHandleCollection GetImplementedInterfaces()
		{
			if (handle.IsNil)
				return default(System.Reflection.Metadata.InterfaceHandleCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return target.GetImplementedInterfaces();
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}
		public DeclarativeSecurityAttributeCollection GetDeclarativeSecurityAttributes()
		{
			if (handle.IsNil)
				return default(DeclarativeSecurityAttributeCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return new DeclarativeSecurityAttributeCollection(module, target.GetDeclarativeSecurityAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is TypeDefinition && Equals((TypeDefinition)obj);
		}

		public bool Equals(TypeDefinition other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct NamespaceDefinition : IEquatable<NamespaceDefinition>
	{
		readonly ModuleDefinition module;
		SRM.NamespaceHandle handle;

		internal NamespaceDefinition(ModuleDefinition module, SRM.NamespaceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this NamespaceDefinition.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this NamespaceDefinition.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetNamespaceDefinition(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public NamespaceDefinition Parent {
			get {
				if (handle.IsNil)
					return default(NamespaceDefinition);
				var target = module.metadata.GetNamespaceDefinition(handle);
				return new NamespaceDefinition(module, target.Parent);
			}
		}
		public IEnumerable<NamespaceDefinition> NamespaceDefinitions {
			get {
				if (handle.IsNil)
					return default(IEnumerable<NamespaceDefinition>);
				var target = module.metadata.GetNamespaceDefinition(handle);
				return target.NamespaceDefinitions.Select(new Func<SRM.NamespaceHandle, NamespaceDefinition>(module.FromHandle));
			}
		}
		public IEnumerable<TypeDefinition> TypeDefinitions {
			get {
				if (handle.IsNil)
					return default(IEnumerable<TypeDefinition>);
				var target = module.metadata.GetNamespaceDefinition(handle);
				return target.TypeDefinitions.Select(new Func<SRM.TypeHandle, TypeDefinition>(module.FromHandle));
			}
		}
		public IEnumerable<TypeForwarder> TypeForwarders {
			get {
				if (handle.IsNil)
					return default(IEnumerable<TypeForwarder>);
				var target = module.metadata.GetNamespaceDefinition(handle);
				return target.TypeForwarders.Select(new Func<SRM.TypeForwarderHandle, TypeForwarder>(module.FromHandle));
			}
		}


		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is NamespaceDefinition && Equals((NamespaceDefinition)obj);
		}

		public bool Equals(NamespaceDefinition other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct MethodImpl : IEquatable<MethodImpl>
	{
		readonly ModuleDefinition module;
		SRM.MethodImplementationHandle handle;

		internal MethodImpl(ModuleDefinition module, SRM.MethodImplementationHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MethodImpl.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this MethodImpl.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public TypeDefinition Type {
			get {
				if (handle.IsNil)
					return default(TypeDefinition);
				var target = module.metadata.GetMethodImpl(handle);
				return new TypeDefinition(module, target.Type);
			}
		}
		public System.Reflection.Metadata.Handle MethodBody {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetMethodImpl(handle);
				return target.MethodBody;
			}
		}
		public System.Reflection.Metadata.Handle MethodDeclaration {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetMethodImpl(handle);
				return target.MethodDeclaration;
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetMethodImpl(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is MethodImpl && Equals((MethodImpl)obj);
		}

		public bool Equals(MethodImpl other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct AssemblyFile : IEquatable<AssemblyFile>
	{
		readonly ModuleDefinition module;
		SRM.AssemblyFileHandle handle;

		internal AssemblyFile(ModuleDefinition module, SRM.AssemblyFileHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this AssemblyFile.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this AssemblyFile.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public bool ContainsMetadata {
			get {
				if (handle.IsNil)
					return default(bool);
				var target = module.metadata.GetAssemblyFile(handle);
				return target.ContainsMetadata;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetAssemblyFile(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public Blob HashValue {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetAssemblyFile(handle);
				return new Blob(module, target.HashValue);
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetAssemblyFile(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is AssemblyFile && Equals((AssemblyFile)obj);
		}

		public bool Equals(AssemblyFile other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct AssemblyReference : IEquatable<AssemblyReference>
	{
		readonly ModuleDefinition module;
		SRM.AssemblyReferenceHandle handle;

		internal AssemblyReference(ModuleDefinition module, SRM.AssemblyReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this AssemblyReference.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this AssemblyReference.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Version Version {
			get {
				if (handle.IsNil)
					return default(System.Version);
				var target = module.metadata.GetAssemblyReference(handle);
				return target.Version;
			}
		}
		public System.Reflection.AssemblyFlags Flags {
			get {
				if (handle.IsNil)
					return default(System.Reflection.AssemblyFlags);
				var target = module.metadata.GetAssemblyReference(handle);
				return target.Flags;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetAssemblyReference(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public string Culture {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetAssemblyReference(handle);
				return module.metadata.GetString(target.Culture);
			}
		}
		public Blob PublicKeyOrToken {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetAssemblyReference(handle);
				return new Blob(module, target.PublicKeyOrToken);
			}
		}
		public Blob HashValue {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetAssemblyReference(handle);
				return new Blob(module, target.HashValue);
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetAssemblyReference(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is AssemblyReference && Equals((AssemblyReference)obj);
		}

		public bool Equals(AssemblyReference other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Constant : IEquatable<Constant>
	{
		readonly ModuleDefinition module;
		SRM.ConstantHandle handle;

		internal Constant(ModuleDefinition module, SRM.ConstantHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Constant.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Constant.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public ConstantType Type {
			get {
				if (handle.IsNil)
					return default(ConstantType);
				var target = module.metadata.GetConstant(handle);
				return (ConstantType)target.Type;
			}
		}
		public Blob Value {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetConstant(handle);
				return new Blob(module, target.Value);
			}
		}
		public System.Reflection.Metadata.Handle Parent {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetConstant(handle);
				return target.Parent;
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetConstant(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Constant && Equals((Constant)obj);
		}

		public bool Equals(Constant other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct CustomAttribute : IEquatable<CustomAttribute>
	{
		readonly ModuleDefinition module;
		SRM.CustomAttributeHandle handle;

		internal CustomAttribute(ModuleDefinition module, SRM.CustomAttributeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this CustomAttribute.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this CustomAttribute.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.Metadata.Handle Constructor {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetCustomAttribute(handle);
				return target.Constructor;
			}
		}
		public System.Reflection.Metadata.Handle Parent {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetCustomAttribute(handle);
				return target.Parent;
			}
		}
		public Blob Value {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetCustomAttribute(handle);
				return new Blob(module, target.Value);
			}
		}


		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is CustomAttribute && Equals((CustomAttribute)obj);
		}

		public bool Equals(CustomAttribute other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct DeclarativeSecurityAttribute : IEquatable<DeclarativeSecurityAttribute>
	{
		readonly ModuleDefinition module;
		SRM.DeclarativeSecurityAttributeHandle handle;

		internal DeclarativeSecurityAttribute(ModuleDefinition module, SRM.DeclarativeSecurityAttributeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this DeclarativeSecurityAttribute.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this DeclarativeSecurityAttribute.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.DeclarativeSecurityAction Action {
			get {
				if (handle.IsNil)
					return default(System.Reflection.DeclarativeSecurityAction);
				var target = module.metadata.GetDeclarativeSecurityAttribute(handle);
				return target.Action;
			}
		}
		public System.Reflection.Metadata.Handle Parent {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetDeclarativeSecurityAttribute(handle);
				return target.Parent;
			}
		}
		public Blob PermissionSet {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetDeclarativeSecurityAttribute(handle);
				return new Blob(module, target.PermissionSet);
			}
		}


		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is DeclarativeSecurityAttribute && Equals((DeclarativeSecurityAttribute)obj);
		}

		public bool Equals(DeclarativeSecurityAttribute other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Event : IEquatable<Event>
	{
		readonly ModuleDefinition module;
		SRM.EventHandle handle;

		internal Event(ModuleDefinition module, SRM.EventHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Event.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Event.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetEvent(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public System.Reflection.EventAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.EventAttributes);
				var target = module.metadata.GetEvent(handle);
				return target.Attributes;
			}
		}
		public System.Reflection.Metadata.Handle Type {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetEvent(handle);
				return target.Type;
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetEvent(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}
		public EventMethodHandles GetAssociatedMethods()
		{
			if (handle.IsNil)
				return default(EventMethodHandles);
			var target = module.metadata.GetEvent(handle);
			return new EventMethodHandles(module, target.GetAssociatedMethods());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Event && Equals((Event)obj);
		}

		public bool Equals(Event other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Field : IEquatable<Field>
	{
		readonly ModuleDefinition module;
		SRM.FieldHandle handle;

		internal Field(ModuleDefinition module, SRM.FieldHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Field.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Field.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetField(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public System.Reflection.FieldAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.FieldAttributes);
				var target = module.metadata.GetField(handle);
				return target.Attributes;
			}
		}
		public Blob Signature {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetField(handle);
				return new Blob(module, target.Signature);
			}
		}

		public Constant GetDefaultValue()
		{
			if (handle.IsNil)
				return default(Constant);
			var target = module.metadata.GetField(handle);
			return new Constant(module, target.GetDefaultValue());
		}
		public int GetRelativeVirtualAddress()
		{
			if (handle.IsNil)
				return default(int);
			var target = module.metadata.GetField(handle);
			return target.GetRelativeVirtualAddress();
		}
		public int GetOffset()
		{
			if (handle.IsNil)
				return default(int);
			var target = module.metadata.GetField(handle);
			return target.GetOffset();
		}
		public Blob GetMarshallingDescriptor()
		{
			if (handle.IsNil)
				return default(Blob);
			var target = module.metadata.GetField(handle);
			return new Blob(module, target.GetMarshallingDescriptor());
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetField(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Field && Equals((Field)obj);
		}

		public bool Equals(Field other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct GenericParameter : IEquatable<GenericParameter>
	{
		readonly ModuleDefinition module;
		SRM.GenericParameterHandle handle;

		internal GenericParameter(ModuleDefinition module, SRM.GenericParameterHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this GenericParameter.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this GenericParameter.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.Metadata.Handle Parent {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetGenericParameter(handle);
				return target.Parent;
			}
		}
		public System.Reflection.GenericParameterAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.GenericParameterAttributes);
				var target = module.metadata.GetGenericParameter(handle);
				return target.Attributes;
			}
		}
		public int Index {
			get {
				if (handle.IsNil)
					return default(int);
				var target = module.metadata.GetGenericParameter(handle);
				return target.Index;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetGenericParameter(handle);
				return module.metadata.GetString(target.Name);
			}
		}

		public GenericParameterConstraintCollection GetConstraints()
		{
			if (handle.IsNil)
				return default(GenericParameterConstraintCollection);
			var target = module.metadata.GetGenericParameter(handle);
			return new GenericParameterConstraintCollection(module, target.GetConstraints());
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetGenericParameter(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is GenericParameter && Equals((GenericParameter)obj);
		}

		public bool Equals(GenericParameter other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct GenericParameterConstraint : IEquatable<GenericParameterConstraint>
	{
		readonly ModuleDefinition module;
		SRM.GenericParameterConstraintHandle handle;

		internal GenericParameterConstraint(ModuleDefinition module, SRM.GenericParameterConstraintHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this GenericParameterConstraint.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this GenericParameterConstraint.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public GenericParameter Parameter {
			get {
				if (handle.IsNil)
					return default(GenericParameter);
				var target = module.metadata.GetGenericParameterConstraint(handle);
				return new GenericParameter(module, target.Parameter);
			}
		}
		public System.Reflection.Metadata.Handle Type {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetGenericParameterConstraint(handle);
				return target.Type;
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetGenericParameterConstraint(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is GenericParameterConstraint && Equals((GenericParameterConstraint)obj);
		}

		public bool Equals(GenericParameterConstraint other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct ManifestResource : IEquatable<ManifestResource>
	{
		readonly ModuleDefinition module;
		SRM.ManifestResourceHandle handle;

		internal ManifestResource(ModuleDefinition module, SRM.ManifestResourceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this ManifestResource.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this ManifestResource.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Int64 Offset {
			get {
				if (handle.IsNil)
					return default(System.Int64);
				var target = module.metadata.GetManifestResource(handle);
				return target.Offset;
			}
		}
		public System.Reflection.ManifestResourceAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.ManifestResourceAttributes);
				var target = module.metadata.GetManifestResource(handle);
				return target.Attributes;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetManifestResource(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public System.Reflection.Metadata.Handle Implementation {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetManifestResource(handle);
				return target.Implementation;
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetManifestResource(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is ManifestResource && Equals((ManifestResource)obj);
		}

		public bool Equals(ManifestResource other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct MemberReference : IEquatable<MemberReference>
	{
		readonly ModuleDefinition module;
		SRM.MemberReferenceHandle handle;

		internal MemberReference(ModuleDefinition module, SRM.MemberReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MemberReference.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this MemberReference.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.Metadata.Handle Parent {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetMemberReference(handle);
				return target.Parent;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetMemberReference(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public Blob Signature {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetMemberReference(handle);
				return new Blob(module, target.Signature);
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetMemberReference(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is MemberReference && Equals((MemberReference)obj);
		}

		public bool Equals(MemberReference other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Method : IEquatable<Method>
	{
		readonly ModuleDefinition module;
		SRM.MethodHandle handle;

		internal Method(ModuleDefinition module, SRM.MethodHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Method.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Method.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetMethod(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public Blob Signature {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetMethod(handle);
				return new Blob(module, target.Signature);
			}
		}
		public int RelativeVirtualAddress {
			get {
				if (handle.IsNil)
					return default(int);
				var target = module.metadata.GetMethod(handle);
				return target.RelativeVirtualAddress;
			}
		}
		public System.Reflection.MethodAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.MethodAttributes);
				var target = module.metadata.GetMethod(handle);
				return target.Attributes;
			}
		}
		public System.Reflection.MethodImplAttributes ImplAttributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.MethodImplAttributes);
				var target = module.metadata.GetMethod(handle);
				return target.ImplAttributes;
			}
		}

		public ParameterCollection GetParameters()
		{
			if (handle.IsNil)
				return default(ParameterCollection);
			var target = module.metadata.GetMethod(handle);
			return new ParameterCollection(module, target.GetParameters());
		}
		public GenericParameterCollection GetGenericParameters()
		{
			if (handle.IsNil)
				return default(GenericParameterCollection);
			var target = module.metadata.GetMethod(handle);
			return new GenericParameterCollection(module, target.GetGenericParameters());
		}
		public MethodImport GetImport()
		{
			if (handle.IsNil)
				return default(MethodImport);
			var target = module.metadata.GetMethod(handle);
			return new MethodImport(module, target.GetImport());
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetMethod(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}
		public DeclarativeSecurityAttributeCollection GetDeclarativeSecurityAttributes()
		{
			if (handle.IsNil)
				return default(DeclarativeSecurityAttributeCollection);
			var target = module.metadata.GetMethod(handle);
			return new DeclarativeSecurityAttributeCollection(module, target.GetDeclarativeSecurityAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Method && Equals((Method)obj);
		}

		public bool Equals(Method other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct MethodSpecification : IEquatable<MethodSpecification>
	{
		readonly ModuleDefinition module;
		SRM.MethodSpecificationHandle handle;

		internal MethodSpecification(ModuleDefinition module, SRM.MethodSpecificationHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MethodSpecification.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this MethodSpecification.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.Metadata.Handle Method {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetMethodSpecification(handle);
				return target.Method;
			}
		}
		public Blob Signature {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetMethodSpecification(handle);
				return new Blob(module, target.Signature);
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetMethodSpecification(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is MethodSpecification && Equals((MethodSpecification)obj);
		}

		public bool Equals(MethodSpecification other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Parameter : IEquatable<Parameter>
	{
		readonly ModuleDefinition module;
		SRM.ParameterHandle handle;

		internal Parameter(ModuleDefinition module, SRM.ParameterHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Parameter.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Parameter.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.ParameterAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.ParameterAttributes);
				var target = module.metadata.GetParameter(handle);
				return target.Attributes;
			}
		}
		public int SequenceNumber {
			get {
				if (handle.IsNil)
					return default(int);
				var target = module.metadata.GetParameter(handle);
				return target.SequenceNumber;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetParameter(handle);
				return module.metadata.GetString(target.Name);
			}
		}

		public Constant GetDefaultValue()
		{
			if (handle.IsNil)
				return default(Constant);
			var target = module.metadata.GetParameter(handle);
			return new Constant(module, target.GetDefaultValue());
		}
		public Blob GetMarshallingDescriptor()
		{
			if (handle.IsNil)
				return default(Blob);
			var target = module.metadata.GetParameter(handle);
			return new Blob(module, target.GetMarshallingDescriptor());
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetParameter(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Parameter && Equals((Parameter)obj);
		}

		public bool Equals(Parameter other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct Property : IEquatable<Property>
	{
		readonly ModuleDefinition module;
		SRM.PropertyHandle handle;

		internal Property(ModuleDefinition module, SRM.PropertyHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Property.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this Property.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetProperty(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public System.Reflection.PropertyAttributes Attributes {
			get {
				if (handle.IsNil)
					return default(System.Reflection.PropertyAttributes);
				var target = module.metadata.GetProperty(handle);
				return target.Attributes;
			}
		}
		public Blob Signature {
			get {
				if (handle.IsNil)
					return default(Blob);
				var target = module.metadata.GetProperty(handle);
				return new Blob(module, target.Signature);
			}
		}

		public Constant GetDefaultValue()
		{
			if (handle.IsNil)
				return default(Constant);
			var target = module.metadata.GetProperty(handle);
			return new Constant(module, target.GetDefaultValue());
		}
		public CustomAttributeCollection GetCustomAttributes()
		{
			if (handle.IsNil)
				return default(CustomAttributeCollection);
			var target = module.metadata.GetProperty(handle);
			return new CustomAttributeCollection(module, target.GetCustomAttributes());
		}
		public PropertyMethodHandles GetAssociatedMethods()
		{
			if (handle.IsNil)
				return default(PropertyMethodHandles);
			var target = module.metadata.GetProperty(handle);
			return new PropertyMethodHandles(module, target.GetAssociatedMethods());
		}

		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is Property && Equals((Property)obj);
		}

		public bool Equals(Property other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct TypeForwarder : IEquatable<TypeForwarder>
	{
		readonly ModuleDefinition module;
		SRM.TypeForwarderHandle handle;

		internal TypeForwarder(ModuleDefinition module, SRM.TypeForwarderHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeForwarder.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this TypeForwarder.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeForwarder(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public NamespaceDefinition Namespace {
			get {
				if (handle.IsNil)
					return default(NamespaceDefinition);
				var target = module.metadata.GetTypeForwarder(handle);
				return new NamespaceDefinition(module, target.Namespace);
			}
		}
		public AssemblyReference Implementation {
			get {
				if (handle.IsNil)
					return default(AssemblyReference);
				var target = module.metadata.GetTypeForwarder(handle);
				return new AssemblyReference(module, target.Implementation);
			}
		}


		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is TypeForwarder && Equals((TypeForwarder)obj);
		}

		public bool Equals(TypeForwarder other)
		{
			return module == other.module && handle == other.handle;
		}
	}
	public partial struct TypeReference : IEquatable<TypeReference>
	{
		readonly ModuleDefinition module;
		SRM.TypeReferenceHandle handle;

		internal TypeReference(ModuleDefinition module, SRM.TypeReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeReference.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public bool IsNil {
			get { return handle.IsNil; }
		}

		/// <summary>
		/// Gets the metadata token associated with this TypeReference.
		/// </summary>
		public int MetadataToken {
			get { 
				if (handle.IsNil)
					return 0;
				return SRM.Ecma335.MetadataTokens.GetToken(module.metadata, handle); 
			}
		}

		public System.Reflection.Metadata.Handle ResolutionScope {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.Handle);
				var target = module.metadata.GetTypeReference(handle);
				return target.ResolutionScope;
			}
		}
		public string Name {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeReference(handle);
				return module.metadata.GetString(target.Name);
			}
		}
		public string Namespace {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeReference(handle);
				return module.metadata.GetString(target.Namespace);
			}
		}


		public override int GetHashCode()
		{
			if (module != null)
				return module.GetHashCode() ^ handle.GetHashCode();
			else
				return 0;
		}

		public override bool Equals(object obj)
		{
			return obj is TypeReference && Equals((TypeReference)obj);
		}

		public bool Equals(TypeReference other)
		{
			return module == other.module && handle == other.handle;
		}
	}

	partial class ModuleDefinition
	{
		public TypeDefinition FromHandle(SRM.TypeHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new TypeDefinition(this, handle);
		}
		public NamespaceDefinition FromHandle(SRM.NamespaceHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new NamespaceDefinition(this, handle);
		}
		public MethodImpl FromHandle(SRM.MethodImplementationHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new MethodImpl(this, handle);
		}
		public AssemblyFile FromHandle(SRM.AssemblyFileHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new AssemblyFile(this, handle);
		}
		public AssemblyReference FromHandle(SRM.AssemblyReferenceHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new AssemblyReference(this, handle);
		}
		public Constant FromHandle(SRM.ConstantHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Constant(this, handle);
		}
		public CustomAttribute FromHandle(SRM.CustomAttributeHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new CustomAttribute(this, handle);
		}
		public DeclarativeSecurityAttribute FromHandle(SRM.DeclarativeSecurityAttributeHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new DeclarativeSecurityAttribute(this, handle);
		}
		public Event FromHandle(SRM.EventHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Event(this, handle);
		}
		public Field FromHandle(SRM.FieldHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Field(this, handle);
		}
		public GenericParameter FromHandle(SRM.GenericParameterHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new GenericParameter(this, handle);
		}
		public GenericParameterConstraint FromHandle(SRM.GenericParameterConstraintHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new GenericParameterConstraint(this, handle);
		}
		public ManifestResource FromHandle(SRM.ManifestResourceHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new ManifestResource(this, handle);
		}
		public MemberReference FromHandle(SRM.MemberReferenceHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new MemberReference(this, handle);
		}
		public Method FromHandle(SRM.MethodHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Method(this, handle);
		}
		public MethodSpecification FromHandle(SRM.MethodSpecificationHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new MethodSpecification(this, handle);
		}
		public Parameter FromHandle(SRM.ParameterHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Parameter(this, handle);
		}
		public Property FromHandle(SRM.PropertyHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new Property(this, handle);
		}
		public TypeForwarder FromHandle(SRM.TypeForwarderHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new TypeForwarder(this, handle);
		}
		public TypeReference FromHandle(SRM.TypeReferenceHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new TypeReference(this, handle);
		}
	}
}