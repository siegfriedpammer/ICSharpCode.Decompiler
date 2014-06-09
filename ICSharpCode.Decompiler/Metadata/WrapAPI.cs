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
using System.Diagnostics;
using SRM = System.Reflection.Metadata;
namespace ICSharpCode.Decompiler.Metadata
{
	public partial struct AssemblyFile : IEquatable<AssemblyFile>
	{
		readonly Module module;
		SRM.AssemblyFileHandle handle;

		internal AssemblyFile(Module module, SRM.AssemblyFileHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this AssemblyFile.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.AssemblyReferenceHandle handle;

		internal AssemblyReference(Module module, SRM.AssemblyReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this AssemblyReference.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.ConstantHandle handle;

		internal Constant(Module module, SRM.ConstantHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Constant.
		/// </summary>
		public Module ContainingModule {
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

		public System.Reflection.Metadata.ConstantType Type {
			get {
				if (handle.IsNil)
					return default(System.Reflection.Metadata.ConstantType);
				var target = module.metadata.GetConstant(handle);
				return target.Type;
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
		readonly Module module;
		SRM.CustomAttributeHandle handle;

		internal CustomAttribute(Module module, SRM.CustomAttributeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this CustomAttribute.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.DeclarativeSecurityAttributeHandle handle;

		internal DeclarativeSecurityAttribute(Module module, SRM.DeclarativeSecurityAttributeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this DeclarativeSecurityAttribute.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.EventHandle handle;

		internal Event(Module module, SRM.EventHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Event.
		/// </summary>
		public Module ContainingModule {
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
		public System.Reflection.Metadata.EventMethodHandles GetAssociatedMethods()
		{
			if (handle.IsNil)
				return default(System.Reflection.Metadata.EventMethodHandles);
			var target = module.metadata.GetEvent(handle);
			return target.GetAssociatedMethods();
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
		readonly Module module;
		SRM.FieldHandle handle;

		internal Field(Module module, SRM.FieldHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Field.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.GenericParameterHandle handle;

		internal GenericParameter(Module module, SRM.GenericParameterHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this GenericParameter.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.GenericParameterConstraintHandle handle;

		internal GenericParameterConstraint(Module module, SRM.GenericParameterConstraintHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this GenericParameterConstraint.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.ManifestResourceHandle handle;

		internal ManifestResource(Module module, SRM.ManifestResourceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this ManifestResource.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.MemberReferenceHandle handle;

		internal MemberReference(Module module, SRM.MemberReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MemberReference.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.MethodHandle handle;

		internal Method(Module module, SRM.MethodHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Method.
		/// </summary>
		public Module ContainingModule {
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
		public System.Reflection.Metadata.MethodImport GetImport()
		{
			if (handle.IsNil)
				return default(System.Reflection.Metadata.MethodImport);
			var target = module.metadata.GetMethod(handle);
			return target.GetImport();
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
		readonly Module module;
		SRM.MethodSpecificationHandle handle;

		internal MethodSpecification(Module module, SRM.MethodSpecificationHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this MethodSpecification.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.ParameterHandle handle;

		internal Parameter(Module module, SRM.ParameterHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Parameter.
		/// </summary>
		public Module ContainingModule {
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
		readonly Module module;
		SRM.PropertyHandle handle;

		internal Property(Module module, SRM.PropertyHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this Property.
		/// </summary>
		public Module ContainingModule {
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
		public System.Reflection.Metadata.PropertyMethodHandles GetAssociatedMethods()
		{
			if (handle.IsNil)
				return default(System.Reflection.Metadata.PropertyMethodHandles);
			var target = module.metadata.GetProperty(handle);
			return target.GetAssociatedMethods();
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
		readonly Module module;
		SRM.TypeForwarderHandle handle;

		internal TypeForwarder(Module module, SRM.TypeForwarderHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeForwarder.
		/// </summary>
		public Module ContainingModule {
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
		public string Namespace {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeForwarder(handle);
				return module.metadata.GetString(target.Namespace);
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
		readonly Module module;
		SRM.TypeReferenceHandle handle;

		internal TypeReference(Module module, SRM.TypeReferenceHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeReference.
		/// </summary>
		public Module ContainingModule {
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
	public partial struct TypeDefinition : IEquatable<TypeDefinition>
	{
		readonly Module module;
		SRM.TypeHandle handle;

		internal TypeDefinition(Module module, SRM.TypeHandle handle)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.handle = handle;
		}

		/// <summary>
		/// Gets the module containing this TypeDefinition.
		/// </summary>
		public Module ContainingModule {
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
		public string Namespace {
			get {
				if (handle.IsNil)
					return default(string);
				var target = module.metadata.GetTypeDefinition(handle);
				return module.metadata.GetString(target.Namespace);
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
		public System.Reflection.Metadata.MethodImplementationHandleCollection GetMethodImplementations()
		{
			if (handle.IsNil)
				return default(System.Reflection.Metadata.MethodImplementationHandleCollection);
			var target = module.metadata.GetTypeDefinition(handle);
			return target.GetMethodImplementations();
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

	partial class Module
	{
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
		public TypeDefinition FromHandle(SRM.TypeHandle handle)
		{
			if (handle.IsNil)
				throw new ArgumentNullException("handle");
			return new TypeDefinition(this, handle);
		}
	}
}