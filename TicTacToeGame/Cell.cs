namespace TicTacToeGame
{


    /// <summary>
    /// CellState enum would provide state of the cell. Only below states are permitted.
    /// At a time any state value would be permiited for a given player.
    /// i.e. Any empty cell can be modified by each player. But he can not modify other 
    /// player's cell.
    /// </summary>
    enum CellState { Nothing, Cross, Tic};

    /// <summary>
    /// Cell class defines the state of the cell and methods which would alter the 
    /// state off the Cell object.
    /// </summary>
    class Cell
    {

        public CellState Cs;

        public Cell()
        {
            Cs = CellState.Nothing;
        }

        /// <summary>
        /// Set the cell status for each player.
        /// </summary>
        /// <param name="Cs"></param>
        public void SetCellStatus(CellState Cs)
        {
            this.Cs = Cs;
        }

        /// <summary>
        /// Gets or sets the state of the cell to display.
        /// </summary>
        public string Mark(CellState Cs)
        {
            switch (Cs)
            {
                case CellState.Nothing:
                    return " ";
                case CellState.Cross:
                    return "X";
                case CellState.Tic:
                    return "O";
                default:
                    return "";
            }

        }
    }
}
