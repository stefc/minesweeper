namespace minesweeper {

	public static class BoardFactory {

		public static Board CreateBoard(int height, int width, int mines) {
			return new Board(height: height, width: width, mines: mines);
		}
	}
    
}
