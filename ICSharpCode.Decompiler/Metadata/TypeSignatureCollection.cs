using System;
using System.Collections;
using System.Collections.Generic;
using SRM = System.Reflection.Metadata;

namespace ICSharpCode.Decompiler.Metadata
{
	public struct TypeSignatureCollection : IReadOnlyCollection<TypeSignature>
	{
		private int paramCount;
		SRM.BlobReader storedReader;

		public readonly int SentinelIndex;

		internal TypeSignatureCollection(ref SRM.BlobReader reader, uint paramCount)
		{
			this.paramCount = (int)paramCount;
			this.storedReader = reader;
			// Scan the collection for the sentinel position, and advance the reader to the position after the collection
			this.SentinelIndex = (int)paramCount;
            for (uint i = 0; i < paramCount;) {
				if (new TypeSignature(ref reader).TypeCode == SignatureTypeCode.Sentinel) {
					if (this.SentinelIndex != this.paramCount)
						throw new BadImageFormatException("Found multiple sentinels");
					this.SentinelIndex = (int)i;
					// the sentinel doesn't consume an index in the collection, and is not counted by paramCount
				} else {
					i++;
				}
			}
		}

		public int Count
		{
			get { return paramCount; }
		}

		public Enumerator GetEnumerator()
		{
			return new Enumerator(ref storedReader, paramCount);
		}

		IEnumerator<TypeSignature> IEnumerable<TypeSignature>.GetEnumerator()
		{
			return new Enumerator(ref storedReader, paramCount);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(ref storedReader, paramCount);
		}

		public struct Enumerator : IEnumerator<TypeSignature>
		{
			SRM.BlobReader reader;
			int remainingCount;
			TypeSignature current;

			public Enumerator(ref SRM.BlobReader reader, int paramCount)
			{
				this.reader = reader;
				this.remainingCount = paramCount;
				this.current = default(TypeSignature);
			}

            public TypeSignature Current
			{
				get { return current; }
			}

			public bool MoveNext()
			{
				if (remainingCount == 0)
					return false;
				remainingCount--;
				current = new TypeSignature(ref reader);
				return true;
			}

			object IEnumerator.Current
			{
				get { return current; }
			}
			
			void IDisposable.Dispose()
			{
			}

			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}
		}
	}
}