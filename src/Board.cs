using System.Collections.Generic;
using System.Collections.Immutable;
using minesweeper.common;

namespace minesweeper {

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

    public class Board
    {
		public int Height { get; private set; }
		public int  Width { get; private set; }
        private readonly ImmutableHashSet<Point> mines;

		public Board(int width, int height, int mines)
		{
			this.Width = width;
			this.Height = height;

			this.mines = ImmutableHashSet<Point>.Empty;
		}

        public IEnumerable<Point> Mines => this.mines;
    }
}
