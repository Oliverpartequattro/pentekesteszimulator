using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

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

            Console.CursorVisible = false;
            
            Console.WriteLine("Nyomj entert a kilépéshez!\n");
            ConsoleKey ret;
            do
            {
                ret = Console.ReadKey(true).Key;
            } while (ret != ConsoleKey.Enter);

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
    }
}
