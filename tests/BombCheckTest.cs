using System;
using System.Linq;
using Xunit;

namespace minesweeper.tests
{
    public class BombCheckTest
    {
        [Fact]
        public void EmptyBoard()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 0);

			var allFields = board.AllFields;

			Assert.Equal(9, allFields.Count());
			Assert.Equal(0, board.Mines.Count());
			Assert.True(allFields.All( point => !board.HasBomb(point)));
        
		}

        [Fact]
        public void FullBoard()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 9);

			var allFields = board.AllFields;

			Assert.Equal(9, allFields.Count());
			Assert.Equal(9, board.Mines.Count());
			Assert.True(allFields.All( point => board.HasBomb(point)));
        }

        [Fact]
        public void CountBombsInNeighbarhood()
        {
			var board = BoardFactory.CreateBoard(height: 3, width: 3, mines: 9);
			Assert.Equal(4*3+4*5+1*8, 
				board.AllFields
					.Select( point => board.CountBombs(point))
					.Sum());
        }
    }
}
