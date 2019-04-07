using System;
using Xunit;

namespace minesweeper.tests
{
    public class SetUpBoardTest
    {
        [Fact]
        public void SetUpBoardBeginner()
        {
			var board = BoardFactory.CreateBoard(height: 9, width: 9, mines: 10);

			Assert.Equal(9, board.Height);
			Assert.Equal(9, board.Width);
			Assert.Equal(10, board.Mines.Count());
        }
    }
}
