using System;
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

		public IEnumerable<Point> GetNeighborhood() { 
			yield return new Point(X-1, Y-1);
			yield return new Point(X,   Y-1);
			yield return new Point(X+1, Y-1);
			yield return new Point(X-1, Y);
			yield return new Point(X+1, Y);
			yield return new Point(X-1, Y+1);
			yield return new Point(X,   Y+1);
			yield return new Point(X+1, Y+1);
		}
    }
}
