using System.Collections.Generic;
using minesweeper.common;

namespace minesweeper
{
    public class Point : ValueObject
	{
		public int X { get; }
		public int Y { get; }

		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}

		protected override IEnumerable<object> GetAtomicValues()
		{
			yield return this.X;
			yield return this.Y;
		}
	}
}
