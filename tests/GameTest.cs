using System;
using System.Linq;
using minesweeper.contracts;
using Xunit;

namespace minesweeper.tests
{
    public class GameTest
    {
        [Fact]
        public void NewGame()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 1);

			var game = new Game(board, new GameDateProvider(new DateTime(2000,1,1,13,00,00)));
			
			Assert.Equal(0, game.Score);
			Assert.True(game.IsRunning); 
		}

		[Fact]
        public void LostGameWithoutPoints()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 1);

			var game = new Game(board, new GameDateProvider(new DateTime(2000,1,1,13,00,00)));
			
			Assert.Equal(0, game.Score);
			Assert.True(game.IsRunning); 

			game.Play(board.Mines.Single());
			Assert.False(game.IsRunning); 
			Assert.Equal(0, game.Score);
		}		

		[Fact]
        public void WinGameWithPoints()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 1);

			var game = new Game(board, new GameDateProvider(new DateTime(2000,1,1,13,00,00)));
			
			Assert.Equal(0, game.Score);
			Assert.True(game.IsRunning); 

			foreach (var point in board.AllFields.Except(board.Mines))
				game.Play(point);
			Assert.False(game.IsRunning); 
			Assert.True(game.Score > 0);
		}		
    }


	internal class GameDateProvider : IDateProvider {

		private readonly DateTime startTime; 
		private int times; 
		public GameDateProvider(DateTime startTime)
		{
			this.startTime = startTime;
			this.times = 0;
		}

		public DateTime Now {
			get {
				times += 1;
				return startTime.AddMinutes(times);
			}
		}
	}
}
