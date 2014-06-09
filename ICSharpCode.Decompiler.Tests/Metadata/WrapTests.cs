using ICSharpCode.Decompiler.Metadata;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Tests.Metadata
{
	[TestFixture]
	public class WrapTests
	{
		[Test]
		public void DefaultOfStructCollectionIsEmpty()
		{ 
			var asm = typeof(Module).Assembly;
            foreach (var type in asm.GetExportedTypes().Where(t => t.IsValueType && t.Name.EndsWith("Collection"))) {
				dynamic collection = Activator.CreateInstance(type);
				Assert.IsFalse(collection.GetEnumerator().MoveNext(), "default(" + type.Name + ") is not empty");
				Assert.IsFalse(((IEnumerable)collection).GetEnumerator().MoveNext(), "default(" + type.Name + ") is not empty (non-generic enumerator)");
			}
		}
	}
}
