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
	class WrapTests
	{
		[Test]
		public void DefaultOfStructCollectionIsEmpty()
		{
			var asm = typeof(Module).Assembly;
            foreach (var type in asm.GetExportedTypes().Where(t => t.IsValueType && t.Name.EndsWith("Collection"))) {
				var collection = (IEnumerable)Activator.CreateInstance(type);
				foreach (var element in collection)
					Assert.Fail("default(" + type.Name + ") is not empty");
			}
		}
	}
}
