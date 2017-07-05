using System;

namespace TicTacToeGame
{
    /// <summary>
    /// GameState enum would provide possible outcomes of the Game.
    /// </summary>
    enum GameState { Playing, Draw, Nought_Won, Cross_Won };

    enum Players { First, Second };

    /// <summary>
    /// Gets of sets the state of the board and decides the outcome of the Game.
    /// </summary>
    class Board
    {
        public int Rows;
        public  int Cols;
        public int WinningSequence;
        public Cell[][] cells;
        /// <summary>
        /// Board creation will set number of rows and cols and array of Cell class.
        /// </summary>
        public Board(int Row, int Col, int ws)
        {
            Rows = Row;
            Cols = Col;
            WinningSequence = ws;
            cells = new Cell[Row][];
            for(int i=0; i<Row; i++)
            {
                cells[i] = new Cell[Col];
            }
            //
            for(int j=0; j<Row; j++)
            {
                for(int k=0; k<Col; k++)
                {
                    cells[j][k] = new Cell();
                }
            }

        }

        public bool IsCellAvailable()
        {
            for(int i=0; i<Rows; i++)
            {
                for(int j=0; j<Cols; j++)
                {
                    if(cells[i][j].Cs == CellState.Nothing)
                    { return true; }
                }
            }
            return false;
        }

        public void GetBoard()
        {
            for (int row = 0; row < Rows; ++row)
            {
                Console.WriteLine();
                Console.Write("\t\t");
                for (int col = 0; col < Cols; ++col)
                {
                    var d = cells[row][col].Mark(cells[row][col].Cs);
                    Console.Write(" "+d+" ");
                    if (col < Cols - 1) Console.Write("|");
                }
                Console.WriteLine();
                if (row < Rows - 1)
                {
                    Console.Write("\t\t");
                    for (int col = 0; col < Cols; ++col)
                    {

                        
                        Console.Write(" __ ");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool UpdateBoard(Tuple<int,int> move, Players p)
        {
            if (cells[move.Item1 -1][move.Item2 -1].Cs == CellState.Nothing)
            {
                if (p == Players.First)
                {
                    cells[move.Item1 - 1][move.Item2 - 1].Cs = CellState.Cross;
                }
                else
                {
                    cells[move.Item1 - 1][move.Item2 - 1].Cs = CellState.Tic;
                }
                return true;
            }
            return false;
        }

        

        

         
    }
}
