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

            Console.WriteLine("Welcome to Town");
            Console.WriteLine("Please make a choice:");
            Console.WriteLine("");
            Console.WriteLine("");

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

            int startX = (Console.CursorLeft + 1);
            int startY = Console.CursorTop;
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
    }
}
