using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSharpCode.Decompiler.IL
{
	/// <summary>
	/// Represents a decoded IL instruction
	/// </summary>
	abstract class ILInstruction(public readonly OpCode OpCode)
	{
		public static readonly ILInstruction Nop = new SimpleInstruction(OpCode.Nop, StackType.Void);

		/// <summary>
		/// Gets the ILRange for this instruction alone, ignoring the operands.
		/// </summary>
		public Interval ILRange;

		/// <summary>
		/// Gets the number of stack elements that get popped when executing this node.
		/// </summary>
		public abstract int StackPopCount { get; }

		/// <summary>
		/// Gets the stack type pushed by this instruction.
		/// </summary>
		public abstract StackType PushType { get; }

		/// <summary>
		/// Gets whether this instruction peeks at the top value of the stack.
		/// If this instruction also pops elements from the stack, this property refers to the top value
		/// left after the pop operations.
		/// </summary>
		public abstract bool IsPeeking { get; }
	}

	/// <summary>
	/// A instruction that could not be decoded correctly.
	/// Invalid instructions may appear in unreachable code.
	/// </summary>
	class InvalidInstruction() : ILInstruction(OpCode.Invalid)
	{
		public override int StackPopCount { get { return 0; } }
		public override StackType PushType { get { return StackType.Void; } }
		public override bool IsPeeking { get { return false; } }
	}

	/// <summary>
	/// A simple instruction that does not pop any elements from the stack.
	/// </summary>
	class SimpleInstruction(OpCode opCode, StackType pushType) : ILInstruction(opCode)
	{
		public override int StackPopCount { get { return 0; } }
		public override StackType PushType { get; } = pushType;
		public override bool IsPeeking { get { return false; } }
	}

	abstract class UnaryInstruction(OpCode opCode) : ILInstruction(opCode)
	{
		public ILInstruction Operand;

		public override int StackPopCount
		{
			get { return Operand?.StackPopCount ?? 1; }
		}

		public override bool IsPeeking { get { return Operand != null && Operand.IsPeeking; } }
	}

	abstract class BinaryInstruction(OpCode opCode) : ILInstruction(opCode)
	{
		public ILInstruction Left;
		public ILInstruction Right;

		public override int StackPopCount
		{
			get
			{
				return (Left?.StackPopCount ?? 1) + (Right?.StackPopCount ?? 1);
			}
		}

		public override bool IsPeeking { get { return Left != null && Left.IsPeeking; } }
	}

	class BinaryNumericInstruction(OpCode opCode, StackType opType, StackType pushType, OverflowMode overflowMode)
		: BinaryInstruction(opCode)
	{
		public readonly StackType OpType = opType;
		public override StackType PushType { get; } = pushType;
		public readonly OverflowMode OverflowMode = overflowMode;
	}

	/// <summary>
	/// Special instruction for unresolved branches.
	/// Created by ILReader phase, replaced with TODO when building basic blocks.
	/// </summary>
	class UnresolvedConditionalBranchInstruction(public ILInstruction Condition, public int TargetILOffset) : ILInstruction(OpCode.ConditionalBranch)
	{
		public override int StackPopCount { get { return Condition?.StackPopCount ?? 1; } }
		public override StackType PushType { get { return StackType.Void; } }
		public override bool IsPeeking { get { return Condition != null && Condition.IsPeeking; } }
	}

	/// <summary>
	/// Special instruction for unresolved branches.
	/// Created by ILReader phase, replaced with TODO when building basic blocks.
	/// </summary>
	class UnresolvedBranchInstruction(public int TargetILOffset) : ILInstruction(OpCode.Branch)
	{
		public override int StackPopCount { get { return 0; } }
		public override StackType PushType { get { return StackType.Void; } }
		public override bool IsPeeking { get { return false; } }
	}

	class CkfiniteInstruction() : ILInstruction(OpCode.Ckfinite)
	{
		public override int StackPopCount { get { return 0; } }
		public override StackType PushType { get { return StackType.Void; } }
		public override bool IsPeeking { get { return true; } }
	}

	public enum OverflowMode : byte
	{
		/// <summary>Don't check for overflow, treat integers as signed.</summary>
		None = 0,
		/// <summary>Check for overflow, treat integers as signed.</summary>
		Ovf = 1,
		/// <summary>Don't check for overflow, treat integers as unsigned.</summary>
		Un = 2,
		/// <summary>Check for overflow, treat integers as unsigned.</summary>
		Ovf_Un = 3
	}

	class LogicNotInstruction() : UnaryInstruction(OpCode.LogicNot)
	{
		public override StackType PushType { get { return StackType.I4; } }
	}

	class ConvInstruction(
		public readonly StackType FromType, public readonly PrimitiveType ToType, public readonly OverflowMode ConvMode
	) : UnaryInstruction(OpCode.Conv)
	{
		public override StackType PushType { get { return ToType.GetStackType(); } }
	}

	class DupInstruction(StackType elementOnStack) : ILInstruction(OpCode.Dup)
	{
		public override int StackPopCount { get { return 0; } }
		public override StackType PushType { get; } = elementOnStack;
        public override bool IsPeeking { get { return true; } }
	}

}
