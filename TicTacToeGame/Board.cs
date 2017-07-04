using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    /// <summary>
    /// GameState enum would provide possible outcomes of the Game.
    /// </summary>
    enum GameState { Playing, Draw, Tic_Won, Cross_Won };

    /// <summary>
    /// Gets of sets the state of the board and decides the outcome of the Game.
    /// </summary>
    class Board
    {
        private int Rows;
        private int Cols;
        int currentRow, currentCol;
        Cell[][] cells;
        /// <summary>
        /// Board creation will set number of rows and cols and array of Cell class.
        /// </summary>
        public Board(int Row, int Col)
        {
            Rows = Row;
            Cols = Col;
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
                    { return false; }
                }
            }
            return true;
        }

        public void isDraw()
        {
            if (IsCellAvailable())
                Console.WriteLine("The Game is Draw");
        }

        public void getBoard()
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
    }
}
