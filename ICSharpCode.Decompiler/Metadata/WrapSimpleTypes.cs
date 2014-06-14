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
	public partial struct AssemblyDefinition
	{
		readonly ModuleDefinition module;
		SRM.AssemblyDefinition wrapped;

		internal AssemblyDefinition(ModuleDefinition module, SRM.AssemblyDefinition wrapped)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.wrapped = wrapped;
		}
		
		/// <summary>
		/// Gets the module containing this AssemblyDefinition.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public System.Reflection.AssemblyHashAlgorithm HashAlgorithm {
			get {
				return wrapped.HashAlgorithm;
			}
		}
		public System.Version Version {
			get {
				return wrapped.Version;
			}
		}
		public System.Reflection.AssemblyFlags Flags {
			get {
				return wrapped.Flags;
			}
		}
		public string Name {
			get {
				return module.metadata.GetString(wrapped.Name);
			}
		}
		public string Culture {
			get {
				return module.metadata.GetString(wrapped.Culture);
			}
		}
		public Blob PublicKey {
			get {
				return new Blob(module, wrapped.PublicKey);
			}
		}

		public CustomAttributeCollection GetCustomAttributes()
		{
			return new CustomAttributeCollection(module, wrapped.GetCustomAttributes());
		}
		public DeclarativeSecurityAttributeCollection GetDeclarativeSecurityAttributes()
		{
			return new DeclarativeSecurityAttributeCollection(module, wrapped.GetDeclarativeSecurityAttributes());
		}
	}
	public partial struct EventMethodHandles
	{
		readonly ModuleDefinition module;
		SRM.EventMethodHandles wrapped;

		internal EventMethodHandles(ModuleDefinition module, SRM.EventMethodHandles wrapped)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.wrapped = wrapped;
		}
		
		/// <summary>
		/// Gets the module containing this EventMethodHandles.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public Method AddOn {
			get {
				return new Method(module, wrapped.AddOn);
			}
		}
		public Method RemoveOn {
			get {
				return new Method(module, wrapped.RemoveOn);
			}
		}
		public Method Fire {
			get {
				return new Method(module, wrapped.Fire);
			}
		}

	}
	public partial struct ExceptionRegion
	{
		readonly ModuleDefinition module;
		SRM.ExceptionRegion wrapped;

		internal ExceptionRegion(ModuleDefinition module, SRM.ExceptionRegion wrapped)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.wrapped = wrapped;
		}
		
		/// <summary>
		/// Gets the module containing this ExceptionRegion.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public ExceptionRegionKind Kind {
			get {
				return (ExceptionRegionKind)wrapped.Kind;
			}
		}
		public int TryOffset {
			get {
				return wrapped.TryOffset;
			}
		}
		public int TryLength {
			get {
				return wrapped.TryLength;
			}
		}
		public int HandlerOffset {
			get {
				return wrapped.HandlerOffset;
			}
		}
		public int HandlerLength {
			get {
				return wrapped.HandlerLength;
			}
		}
		public int FilterOffset {
			get {
				return wrapped.FilterOffset;
			}
		}
		public System.Reflection.Metadata.Handle CatchType {
			get {
				return wrapped.CatchType;
			}
		}

	}
	public partial struct MethodImport
	{
		readonly ModuleDefinition module;
		SRM.MethodImport wrapped;

		internal MethodImport(ModuleDefinition module, SRM.MethodImport wrapped)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.wrapped = wrapped;
		}
		
		/// <summary>
		/// Gets the module containing this MethodImport.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public System.Reflection.MethodImportAttributes Attributes {
			get {
				return wrapped.Attributes;
			}
		}
		public string Name {
			get {
				return module.metadata.GetString(wrapped.Name);
			}
		}
		public ModuleReference Module {
			get {
				return new ModuleReference(module, wrapped.Module);
			}
		}

	}
	public partial struct PropertyMethodHandles
	{
		readonly ModuleDefinition module;
		SRM.PropertyMethodHandles wrapped;

		internal PropertyMethodHandles(ModuleDefinition module, SRM.PropertyMethodHandles wrapped)
		{
			Debug.Assert(module != null);
			this.module = module;
			this.wrapped = wrapped;
		}
		
		/// <summary>
		/// Gets the module containing this PropertyMethodHandles.
		/// </summary>
		public ModuleDefinition ContainingModule {
			get { return module; }
		}

		public Method Getter {
			get {
				return new Method(module, wrapped.Getter);
			}
		}
		public Method Setter {
			get {
				return new Method(module, wrapped.Setter);
			}
		}

	}

	public enum ConstantType : byte
	{
		Invalid = SRM.ConstantType.Invalid,
		Boolean = SRM.ConstantType.Boolean,
		Char = SRM.ConstantType.Char,
		SByte = SRM.ConstantType.SByte,
		Byte = SRM.ConstantType.Byte,
		Int16 = SRM.ConstantType.Int16,
		UInt16 = SRM.ConstantType.UInt16,
		Int32 = SRM.ConstantType.Int32,
		UInt32 = SRM.ConstantType.UInt32,
		Int64 = SRM.ConstantType.Int64,
		UInt64 = SRM.ConstantType.UInt64,
		Single = SRM.ConstantType.Single,
		Double = SRM.ConstantType.Double,
		String = SRM.ConstantType.String,
		NullReference = SRM.ConstantType.NullReference,
	}
	public enum ExceptionRegionKind : ushort
	{
		Catch = SRM.ExceptionRegionKind.Catch,
		Filter = SRM.ExceptionRegionKind.Filter,
		Finally = SRM.ExceptionRegionKind.Finally,
		Fault = SRM.ExceptionRegionKind.Fault,
	}
	public enum MetadataKind : int
	{
		Ecma335 = SRM.MetadataKind.Ecma335,
		WindowsMetadata = SRM.MetadataKind.WindowsMetadata,
		ManagedWindowsMetadata = SRM.MetadataKind.ManagedWindowsMetadata,
	}
	public enum SignatureTypeCode : byte
	{
		Invalid = SRM.SignatureTypeCode.Invalid,
		Void = SRM.SignatureTypeCode.Void,
		Boolean = SRM.SignatureTypeCode.Boolean,
		Char = SRM.SignatureTypeCode.Char,
		SByte = SRM.SignatureTypeCode.SByte,
		Byte = SRM.SignatureTypeCode.Byte,
		Int16 = SRM.SignatureTypeCode.Int16,
		UInt16 = SRM.SignatureTypeCode.UInt16,
		Int32 = SRM.SignatureTypeCode.Int32,
		UInt32 = SRM.SignatureTypeCode.UInt32,
		Int64 = SRM.SignatureTypeCode.Int64,
		UInt64 = SRM.SignatureTypeCode.UInt64,
		Single = SRM.SignatureTypeCode.Single,
		Double = SRM.SignatureTypeCode.Double,
		String = SRM.SignatureTypeCode.String,
		Pointer = SRM.SignatureTypeCode.Pointer,
		ByReference = SRM.SignatureTypeCode.ByReference,
		GenericTypeParameter = SRM.SignatureTypeCode.GenericTypeParameter,
		Array = SRM.SignatureTypeCode.Array,
		GenericTypeInstance = SRM.SignatureTypeCode.GenericTypeInstance,
		TypedReference = SRM.SignatureTypeCode.TypedReference,
		IntPtr = SRM.SignatureTypeCode.IntPtr,
		UIntPtr = SRM.SignatureTypeCode.UIntPtr,
		FunctionPointer = SRM.SignatureTypeCode.FunctionPointer,
		Object = SRM.SignatureTypeCode.Object,
		SZArray = SRM.SignatureTypeCode.SZArray,
		GenericMethodParameter = SRM.SignatureTypeCode.GenericMethodParameter,
		RequiredModifier = SRM.SignatureTypeCode.RequiredModifier,
		OptionalModifier = SRM.SignatureTypeCode.OptionalModifier,
		TypeHandle = SRM.SignatureTypeCode.TypeHandle,
		Sentinel = SRM.SignatureTypeCode.Sentinel,
		Pinned = SRM.SignatureTypeCode.Pinned,
	}

	partial class ModuleDefinition
	{
		public System.String MetadataVersion {
			get {
				return metadata.MetadataVersion;
			}
		}
		public MetadataKind MetadataKind {
			get {
				return (MetadataKind)metadata.MetadataKind;
			}
		}
		public bool IsAssembly {
			get {
				return metadata.IsAssembly;
			}
		}
		public AssemblyReferenceCollection AssemblyReferences {
			get {
				return new AssemblyReferenceCollection(module, metadata.AssemblyReferences);
			}
		}
		public TypeDefinitionCollection TypeDefinitions {
			get {
				return new TypeDefinitionCollection(module, metadata.TypeDefinitions);
			}
		}
		public TypeReferenceCollection TypeReferences {
			get {
				return new TypeReferenceCollection(module, metadata.TypeReferences);
			}
		}
		public CustomAttributeCollection CustomAttributes {
			get {
				return new CustomAttributeCollection(module, metadata.CustomAttributes);
			}
		}
		public DeclarativeSecurityAttributeCollection DeclarativeSecurityAttributes {
			get {
				return new DeclarativeSecurityAttributeCollection(module, metadata.DeclarativeSecurityAttributes);
			}
		}
		public MemberReferenceCollection MemberReferences {
			get {
				return new MemberReferenceCollection(module, metadata.MemberReferences);
			}
		}
		public ManifestResourceCollection ManifestResources {
			get {
				return new ManifestResourceCollection(module, metadata.ManifestResources);
			}
		}
		public AssemblyFileCollection AssemblyFiles {
			get {
				return new AssemblyFileCollection(module, metadata.AssemblyFiles);
			}
		}
		public TypeForwarderCollection TypeForwarders {
			get {
				return new TypeForwarderCollection(module, metadata.TypeForwarders);
			}
		}
		public MethodCollection MethodDefinitions {
			get {
				return new MethodCollection(module, metadata.MethodDefinitions);
			}
		}
		public FieldCollection FieldDefinitions {
			get {
				return new FieldCollection(module, metadata.FieldDefinitions);
			}
		}
		public EventCollection EventDefinitions {
			get {
				return new EventCollection(module, metadata.EventDefinitions);
			}
		}
		public PropertyCollection PropertyDefinitions {
			get {
				return new PropertyCollection(module, metadata.PropertyDefinitions);
			}
		}

		public AssemblyDefinition GetAssemblyDefinition()
		{
			return new AssemblyDefinition(module, metadata.GetAssemblyDefinition());
		}
	}
}