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
    }
}