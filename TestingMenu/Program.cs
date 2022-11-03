using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {
        static int newChoice;
        static string playerChose;
        static void Main(string[] args)
        {
            string[] options = { "Village", "Castle", "Forest" };

            int origWidth;
            int origHeight;

            origWidth = Console.WindowWidth;
            origHeight = Console.WindowHeight;

            Console.SetWindowSize(120, 40);
            Console.BufferHeight = Console.WindowHeight;

            GameFrame();

            newChoice = Choice(true, options);
            if (newChoice == -1)
            {
                playerChose = "nothing";
            }
            else
            {
                playerChose = options[newChoice];
            }
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("Player chose " + playerChose);
            Console.ReadKey(true);

        }
        public static int Choice(bool canCancel, params string[] options)
        {

            int startX = 3; // (Console.CursorLeft + 1);
            int startY = 33; // Console.CursorTop;
            const int optionsPerLine = 1;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                Console.SetCursorPosition(startX, startY);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }

                    Console.WriteLine(" " + options[i] + " ");

                    Console.SetCursorPosition(startX, Console.CursorTop);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= optionsPerLine)
                                currentSelection -= optionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + optionsPerLine < options.Length)
                                currentSelection += optionsPerLine;
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            if (canCancel)
                                return -1;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            return currentSelection;
        }

        static void GameFrame()
        {
            Console.SetCursorPosition(1, 1);

            // Console.Write("│┤╡╢←╕╣║╗╝╜╛┐╚╔╩╦╠═╬╧╔╩╦╠═╬╧╨╤╥╙╘╒╓╫╪┘┌█▄");╟╞╟╞┼──
            
            Console.Write("╔");
            
            for(int i = 0; i < 117; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╗");

            for(int i = 2; i < 31; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("║");

                for(int x = 0; x < 117; x++)
                {
                    Console.Write(" ");
                }

                Console.Write("║");
            }

            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write("╟");

            for (int i = 0; i < 117; i++)
            {
                Console.Write("─");
            }

            Console.Write("╢");

            for (int i = 32; i < 37; i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("║");

                for (int x = 0; x < 117; x++)
                {
                    Console.Write(" ");
                }

                Console.Write("║");
            }


            Console.SetCursorPosition(1, Console.CursorTop);
            Console.Write("╚");

            for (int i = 0; i < 117; i++)
            {
                Console.Write("═");
            }

            Console.WriteLine("╝");
        }
    }
}
