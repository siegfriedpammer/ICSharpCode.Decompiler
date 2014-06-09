using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.Metadata.Tests
{
	[TestFixture]
	public class WrapTests
	{
		[Test]
		public void DefaultOfStructCollectionIsEmpty()
		{ 
			var asm = typeof(ModuleDefinition).Assembly;
            foreach (var type in asm.GetExportedTypes().Where(t => t.IsValueType && t.Name.EndsWith("Collection"))) {
				dynamic collection = Activator.CreateInstance(type);
				Assert.IsFalse(collection.GetEnumerator().MoveNext(), "default(" + type.Name + ") is not empty");
				Assert.IsFalse(((IEnumerable)collection).GetEnumerator().MoveNext(), "default(" + type.Name + ") is not empty (non-generic enumerator)");
				if (type.GetProperty("Count") != null)
					Assert.AreEqual(0, collection.Count, "default(" + type.Name + ").Count should be 0");
            }
		}
	}
}
