using System;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Clear();
            Begin();
        }

        /// <summary>
        /// Method to fire off events.
        /// </summary>
        public static void Begin()
        {
            int option = 3;
            int boardSize = 3;
            int winningLength = 3;
            bool continueFlag = true;
            do
            {
                Console.WriteLine("****** Welcome to Tic Tac Toe. ******");
                Console.WriteLine("Please enter option number from below if you wish to customize:");
                Console.WriteLine("1. Play.");
                Console.WriteLine("2. Change the board size. (Default size is 3x3.)");
                Console.WriteLine("3. Exit.");
                String op = Console.ReadLine();
                Int32.TryParse(op, out option);
                switch (option)
                {
                    case 1:
                        Game.Play(boardSize, winningLength);
                        continueFlag = Game.PlayAgain();
                        break;
                    case 2:
                        Console.WriteLine("Enter the board size between 3 to 10");
                        op = Console.ReadLine();
                        Int32.TryParse(op, out boardSize);
                        if (Game.IsValidateBoardSize(boardSize))
                        {
                            Console.WriteLine("---- Entered Board size accepted. -----");
                            Console.WriteLine("Do you want to change winning sequence length? (y/any key):");
                            if (Console.ReadKey().KeyChar == 'y')
                            {
                                winningLength = Game.GetWS(winningLength, boardSize);
                                if (!Game.IsValidateWS(winningLength, boardSize))
                                {
                                    Console.Write("\nThis wining seq length is not valid.");
                                    Console.WriteLine("Hint: Try giving seq length greater than the half of the size of board.");
                                    continueFlag = Game.PlayAgain();
                                }
                                else
                                {
                                    Game.Play(boardSize, winningLength);
                                    continueFlag = Game.PlayAgain();
                                }
                            }
                            else
                            {
                                //set the winning seq as the size of the board.
                                Console.WriteLine("\nSetting default value to the winning seq.....");
                                winningLength = boardSize;
                                Game.Play(boardSize, winningLength);
                                continueFlag = Game.PlayAgain();
                            }

                        }
                        else
                        {
                            Console.WriteLine("You did not enter correct board size.!!");
                            continueFlag = Game.PlayAgain();
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice!!");
                        continueFlag = true;
                        break;
                }
                Console.Clear();
            } while (continueFlag);
        }

       

    }
}
