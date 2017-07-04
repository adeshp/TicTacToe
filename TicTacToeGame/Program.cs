using System;
using System.Text.RegularExpressions;

namespace TicTacToeGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 3;
            int boardSize = 3;
            int winningLength = 3;
            bool continueFlag = true;
            Console.Clear();

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
                        play(boardSize, winningLength);
                        continueFlag = playAgain();
                        break;
                    case 2:
                        Console.WriteLine("Enter the board size between 3 to 10");
                        op = Console.ReadLine();
                        Int32.TryParse(op, out boardSize);
                        if (isValidateBoardSize(boardSize))
                        {
                            Console.WriteLine("---- Entered Board size accepted. -----");
                            Console.WriteLine("Do you want to change winning sequence length? (y/any key):");
                            if (Console.ReadKey().KeyChar == 'y')
                            {
                                winningLength = GetWS(winningLength, boardSize);
                                if (!isValidateWS(winningLength, boardSize))
                                {
                                    Console.Write("\nThis wining seq length is not valid.");
                                    Console.WriteLine("Hint: Try giving seq length greater than the half of the size of board.");
                                    continueFlag = playAgain();
                                }
                                else
                                {
                                    play(boardSize, winningLength);
                                    continueFlag = playAgain();
                                }
                            }
                            else
                            {
                                //set the winning seq as the size of the board.
                                Console.WriteLine("\nSetting default value to the winning seq.....");
                                winningLength = boardSize;
                                play(boardSize, winningLength);
                                continueFlag = playAgain();
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("You did not enter correct board size.!!");
                            continueFlag = playAgain();
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

        public static bool isValidateBoardSize(int size)
        {
            if (size < 3 || size > 10)
            { return false; }
            else
            { return true; }
        }

        public static int GetWS(int winningLength, int boardSize)
        {
            Console.WriteLine("\nEnter the winning sequence for the above board size:");
            string op = Console.ReadLine();
            Int32.TryParse(op, out winningLength);
            return winningLength;
        }

        public static bool isValidateWS(int seq, int boardSize)
        {
            if (seq > Convert.ToInt32(Math.Ceiling((decimal)boardSize / 2)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// If the player wants to play again.
        /// </summary>
        /// <returns></returns>
        public static bool playAgain()
        {
            Console.WriteLine("Want to play Again? (y/n):");
            if (Console.ReadKey().KeyChar == 'y')
                return true;
            else
                return false;
        }

        /// <summary>
        /// Play the game. Get two Players Player1 and Player2
        /// Alternate each move between them
        /// After each player played his move, check if it's draw or win.
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="winningSeq"></param>
        public static void play(int boardSize, int winningSeq)
        {
            Console.WriteLine("\t\t************************************");
            Console.WriteLine("\t\tPlaying for board size "+ boardSize+ " x " + boardSize + " and winning sequnce " + winningSeq);
            Board b = new Board(boardSize, boardSize);
            b.getBoard();
            string p1, p2;
            Tuple<int, int> Player1 = new Tuple<int, int>(0, 0);
            Tuple<int, int> Player2 = new Tuple<int, int>(0, 0);
            int count = 0;
            Console.WriteLine("Player1 and Player2 have to input the location of the board" +
                "where they want to put thier mark next. e.g. 2,3"
                +"The game board's rows and columns are numbered from 1,1 i.e. the left most cell would be (1,1)");
            do
            {
                if(count %2 == 0)
                {
                    Console.WriteLine("Player1 move(denoted by x): ");
                    Player1 = GetPlayerMove(boardSize);
                    //update the board.

                    //check if it's a draw or win.

                }
                else
                {
                    Console.WriteLine("Player2 move(denoted by o): ");
                    Player1 = GetPlayerMove(boardSize);
                    //update the board.

                    //check if it's a draw or win.

                }
            } while (false);
            //Console.WriteLine

            
        }

        public static Tuple<int, int> GetPlayerMove(int boardSize)
        {
            bool flag = true;
            int f = -1, s = -1;
            do
            {
                string str = Console.ReadLine();
                string[] numbers = Regex.Split(str, @"\D+");
                if (numbers.Length != 2)
                {
                    Console.WriteLine("Please enter in the correct format and within the bounds of the board i.e. -->  3,5");
                    flag = true;
                }
                else
                {
                    if(!string.IsNullOrEmpty(numbers[0]))
                    {
                        if(!string.IsNullOrEmpty(numbers[1]))
                        {
                            int.TryParse(numbers[0], out f);
                            int.TryParse(numbers[0], out s);
                            if(f <= boardSize && s <= boardSize)
                            {
                                return new Tuple<int, int>(f, s);
                            }
                            
                        }
                    }
                }


            } while (flag);
            return new Tuple<int, int>(-1,-1);
        }



    }
}
