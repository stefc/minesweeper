using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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

			Random rnd = new Random();
			while (this.mines.Count < mines) {
				this.mines = this.mines.Add(new Point(x: rnd.Next(width), y: rnd.Next(height)));
			}
		}

        public IEnumerable<Point> Mines => this.mines;

		public IEnumerable<Point> AllFields => Enumerable.Range(0, Height)
			.SelectMany( y => Enumerable.Range(0, Width )
				.Select( x => new Point(x,y)) );

        internal bool HasBomb(Point point)
        {
            throw new NotImplementedException();
        }
    }
}
