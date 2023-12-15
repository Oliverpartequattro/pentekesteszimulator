using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection.Emit;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void DisplayEnd(bool good, string location, string description, ConsoleColor colorDefault = ConsoleColor.Red)
        {

            if (colorDefault != ConsoleColor.Red)
            {
                Console.ForegroundColor = colorDefault;
            }
            else if (good)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            if (colorDefault == ConsoleColor.Green)
            {
                Console.ForegroundColor = GetRandomConsoleColor();
            }
            Console.Clear();

            Console.WriteLine(new string(textCenter("             @@                        ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("             @@                        ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("                                       ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("@@@  @@@  @@@@@@@@   @@@@@@@@  @@@@@@@@")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("@@@  @@@  @@@@@@@@  @@@@@@@@@  @@@@@@@@")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("@@!  @@@  @@!       !@@        @@!     ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("!@!  @!@  !@!       !@!        !@!     ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("@!@  !@!  @!!!:!    !@! @!@!@  @!!!:!  ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("!@!  !!!  !!!!!:    !!! !!@!!  !!!!!:  ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter(":!:  !!:  !!:       :!!   !!:  !!:     ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter(" ::!!:!   :!:       :!:   !::  :!:     ")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("  ::::     :: ::::   ::: ::::   :: ::::")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("   ::      : :: ::    :: :: :   : :: ::")));
            Thread.Sleep(50);
            Console.WriteLine(new string(textCenter("                                       ")));
            Thread.Sleep(50);


            Console.WriteLine("\n");

            if (location != "None")
            {
                Console.Write($"Helyszín: ");

                Console.WriteLine($"{location}\n");
            }

            Console.WriteLine($"A játék végének oka: {description}\n");


            if (colorDefault == ConsoleColor.Green)
            {
                Console.WriteLine("Bezárhatod a programot.");
                Thread.Sleep(1500);

                DisplayEnd(good, location, description, ConsoleColor.Green);

            }

            Console.CursorVisible = false;

            Console.WriteLine("Nyomj entert a kilépéshez!\nNyomj C-t a creditek megjelenítéséhez!\n");
            ConsoleKey ret;
            do
            {
                ret = Console.ReadKey(true).Key;
            } while (ret != ConsoleKey.Enter && ret != ConsoleKey.C);

            if(ret == ConsoleKey.C)
            {
                Console.ForegroundColor = ConsoleColor.White;
                credits(201);
                
            }

            Console.WriteLine("Bezárhatod a programot.");


            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);

            //Console.WriteLine("Szeretnél újrakezdeni? (I/N)");
            //string valasz = Console.ReadLine().ToLower();

            //if (valasz == "i")
            //{
            //    goto Paibá háza;
            //}

        }

        public static ConsoleColor GetRandomConsoleColor()
        {
            // Get all available console colors
            ConsoleColor[] consoleColors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

            // Exclude the two dark colors (black and dark blue)
            consoleColors = Array.FindAll(consoleColors, c => c != ConsoleColor.Black && c != ConsoleColor.DarkBlue);

            // Generate a random index
            Random random = new Random();
            int randomIndex = random.Next(consoleColors.Length);

            // Return the random color
            return consoleColors[randomIndex];
        }
    }
}
