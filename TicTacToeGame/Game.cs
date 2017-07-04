﻿using System;
using System.Text.RegularExpressions;

namespace TicTacToeGame
{
    class Game
    {
        /// <summary>
        /// Play the game. 
        /// Get two Players Player1 and Player2
        /// Alternate each move between them
        /// After each player made his move, check if it's draw or win.
        /// </summary>
        /// <param name="boardSize"></param>
        /// <param name="winningSeq"></param>
        public static void Play(int boardSize, int winningSeq)
        {
            Console.WriteLine("\t\t************************************");
            Console.WriteLine("\t\tPlaying for board size " + boardSize + " x " + boardSize + " and winning sequnce " + winningSeq);
            Board b = new Board(boardSize, boardSize, winningSeq);
            b.GetBoard();
            Tuple<int, int> move = new Tuple<int, int>(0, 0);
            int count = 0;
            bool gameNotOver = true;
            Console.WriteLine("Player1 and Player2 have to input the location of the board" +
                "where they want to put thier mark next. e.g. 2,3");
            Console.WriteLine("The game board's rows and columns are numbered from 1,1 i.e. the left most cell would be (1,1)");
            do
            {
                if (count % 2 == 0)
                {
                    Console.WriteLine("Player1 move(denoted by x): ");
                    bool valid1 = true;
                    do
                    {
                        move = GetPlayerMove(boardSize);
                        // may be use an enum for Player1 -> x and Player2 -> o
                        valid1 = b.UpdateBoard(move, Players.First);
                        if (!valid1)
                            Console.WriteLine("You have chosen a cell which is marked already." +
                                "Please choose different cell.");
                    } while (!valid1);
                    gameNotOver = DisplayResultOfTheMove(b);
                }
                else
                {
                    Console.WriteLine("Player2 move(denoted by o): ");
                    bool valid2 = true;
                    do
                    {
                        move = GetPlayerMove(boardSize);
                        valid2 = b.UpdateBoard(move, Players.Second);
                        if (!valid2)
                            Console.WriteLine("You have chosen a cell which is marked already." +
                                "Please choose different cell.");
                    } while (!valid2);
                    gameNotOver = DisplayResultOfTheMove(b);
                }
                count++;
            } while (gameNotOver);
        }

        /// <summary>
        /// If the Console user wants to play again.
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            Console.WriteLine("Want to play Again? (y/n):");
            if (Console.ReadKey().KeyChar == 'y')
                return true;
            else
                return false;
        }

        /// <summary>
        /// Method to determin if the entered board size is allowed.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool IsValidateBoardSize(int size)
        {
            if (size < 3 || size > 10)
            { return false; }
            else
            { return true; }
        }

        /// <summary>
        /// Method to alter the winning sequence.
        /// </summary>
        /// <param name="winningLength"></param>
        /// <param name="boardSize"></param>
        /// <returns></returns>
        public static int GetWS(int winningLength, int boardSize)
        {
            Console.WriteLine("\nEnter the winning sequence for the above board size:");
            string op = Console.ReadLine();
            Int32.TryParse(op, out winningLength);
            return winningLength;
        }

        /// <summary>
        /// Method to check if the winning sequence is valid.
        /// </summary>
        /// <param name="seq"></param>
        /// <param name="boardSize"></param>
        /// <returns></returns>
        public static bool IsValidateWS(int seq, int boardSize)
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
        /// Get the player's next move.
        /// </summary>
        /// <param name="boardSize"></param>
        /// <returns></returns>
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
                    Console.WriteLine("Please enter in the correct format i.e. -->  3,5");
                    flag = true;
                }
                else
                {
                    if (!string.IsNullOrEmpty(numbers[0]))
                    {
                        if (!string.IsNullOrEmpty(numbers[1]))
                        {
                            int.TryParse(numbers[0], out f);
                            int.TryParse(numbers[1], out s);
                            if (f <= boardSize && s <= boardSize && f > 0 && s > 0)
                            {
                                return new Tuple<int, int>(f, s);
                            }
                            else
                            {
                                Console.WriteLine("You did not choose the cell within the board.");
                                Console.WriteLine("Choose Again:");
                            }

                        }
                    }
                }
            } while (flag);
            return new Tuple<int, int>(-1, -1);
        }

        /// <summary>
        /// Method to display the result of a move. i.e. Draw, Cross_Won, Nought_Won
        /// </summary>
        /// <param name="b"></param>
        public static bool DisplayResultOfTheMove(Board b)
        {
            //Display the latest state of the game board
            b.GetBoard();
            //check the status of the game
            string result = CheckStatus(b).ToString();
            if (result.Equals("Playing"))
            {
                return true;
            }
            Console.WriteLine(result);
            return false;
        }

        /// <summary>
        /// Calaculate Result of the game.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public static GameState CheckStatus(Board b)
        {
            if (b.IsCellAvailable())
            {

                return WhoWon(b);
            }
            return GameState.Draw;
        }

        /// <summary>
        /// Method to decide the winner.
        /// </summary>
        /// <returns></returns>
        public static GameState WhoWon(Board b)
        {
            return GameState.Playing;
        }
    }
}
