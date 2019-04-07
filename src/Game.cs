using System;
using System.Collections.Immutable;
using System.Linq;
using minesweeper.contracts;

namespace minesweeper
{
    internal class Game
    {
        private readonly Board board;
        private readonly IDateProvider dateProvider;
        private bool isRunning;

		private int score;

		private  ImmutableHashSet<Point> checkedFields;

        public Game(Board board, IDateProvider dateProvider)
        {
            this.board = board;
			this.dateProvider = dateProvider;
			this.isRunning = true;
			this.score = 0;
			this.checkedFields = ImmutableHashSet<Point>.Empty;
        }

		public int Score => this.score;

		public bool IsRunning => this.isRunning;

        internal void Play(Point point)
        {
            if (board.HasBomb(point))
				this.isRunning = false; 
			else {
				if (!this.checkedFields.Contains(point)) {
					this.checkedFields = this.checkedFields.Add(point);
					this.score+= 1;
					this.isRunning = this.board.FreeFields.Except(this.checkedFields).Count() > 0;  
				}
			}
        }
    }
}
