using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    internal class Program
    {

        static bool gameOver;

        static int newChoice;
        static string playerChose;
        static void Main(string[] args)
        {
            gameOver = false;
            string[] options = { "Main", "Forest", "Castle" };

            Console.WriteLine("Welcome to Town");
            Console.WriteLine("Please make a choice:");
            Console.WriteLine("");
            Console.WriteLine("");

            newChoice = Choice(true, options);
            playerChose = options[newChoice];
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("Player chose " + playerChose);
            Console.ReadKey(true);

            while (gameOver == false)
            {

            }
        }
        public static int Choice(bool canCancel, params string[] options)
        {

            int startX = Console.CursorLeft;
            int startY = Console.CursorTop;
            const int optionsPerLine = 1;

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            do
            {
                // Console.Clear();
                Console.SetCursorPosition(startX, startY);

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == currentSelection)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.WriteLine(" " + options[i]);

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
    }
}
