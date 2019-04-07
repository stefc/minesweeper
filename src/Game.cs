using System;
using minesweeper.contracts;

namespace minesweeper
{
    internal class Game
    {
        private readonly Board board;
        private readonly IDateProvider dateProvider;
        private bool isRunning;

        public Game(Board board, IDateProvider dateProvider)
        {
            this.board = board;
			this.dateProvider = dateProvider;
			this.isRunning = true;
        }

		public int Score => 0;

		public bool IsRunning => this.isRunning;

        internal void Play(Point point)
        {
            if (board.HasBomb(point))
				this.isRunning = false; 
        }
    }
}
