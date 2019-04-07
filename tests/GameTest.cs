using System;
using System.Linq;
using Xunit;

namespace minesweeper.tests
{
    public class GameTest
    {
        [Fact]
        public void NewGame()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 1);

			var game = new Game(board);
			
			Assert.Equal(0, game.Score);
			Assert.True(game.IsRunning); 
		}

    }
}
