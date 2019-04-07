using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace minesweeper
{

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

        internal int CountBombs(Point point)
        {
            return Mines.Intersect(GetNeighbarhood(point)).Count();
        }

		private IEnumerable<Point> GetPossibleNeighbarhood(Point point) { 
			yield return new Point(point.X-1, point.Y-1);
			yield return new Point(point.X,   point.Y-1);
			yield return new Point(point.X+1, point.Y-1);
			yield return new Point(point.X-1, point.Y);
			yield return new Point(point.X+1, point.Y);
			yield return new Point(point.X-1, point.Y+1);
			yield return new Point(point.X,   point.Y+1);
			yield return new Point(point.X+1, point.Y+1);
		}

		private IEnumerable<Point> GetNeighbarhood(Point point) { 
			return AllFields.Intersect(GetPossibleNeighbarhood(point));
		}

        internal bool HasBomb(Point point) => Mines.Contains(point);
    }
}
