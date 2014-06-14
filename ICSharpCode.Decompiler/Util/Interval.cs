using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler
{
	/// <summary>
	/// Represents an interval.
	/// Note that both the start and end positions are inclusive.
	/// </summary>
	public struct Interval(public readonly int Start, public readonly int End)
	{
		public static readonly Interval Empty = new Interval(0, -1);

		public int Length
		{
			get { return End - Start + 1; }
		}

		public bool Contains(int val)
		{
			return Start <= val && val <= End;
		}

		public override string ToString()
		{
			return string.Format("({0} to {1})", Start, End);
		}
	}

	/// <summary>
	/// An immutable set of integers, that is implemented as a list of intervals.
	/// </summary>
	public struct IntegerSet(public readonly ImmutableArray<Interval> Intervals)
	{
		public bool IsEmpty
		{
			get { return Intervals.IsDefaultOrEmpty; }
		}

		public bool Contains(int val)
		{
			// TODO: use binary search
            foreach (Interval v in Intervals) {
				if (v.Start <= val && val <= v.End)
					return true;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Join(",", Intervals);
		}
	}
}
