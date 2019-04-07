using System.Collections.Generic;

namespace minesweeper {

    public class Board
    {
        internal readonly int Height;
        internal readonly int Width;
        internal readonly IEnumerable<object> Mines;
    }
}
