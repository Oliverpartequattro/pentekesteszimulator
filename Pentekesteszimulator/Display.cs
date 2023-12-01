using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static int Display(string location, string description, string extra, string question, Player1 player, bool timeStopped, int index, double timeMultiplier, string[] options)
        {
            Console.Clear();
            Console.WriteLine(new string(textCenter("   ___  _        _       _                _                 _                 _   _   _             ")));
            Console.WriteLine(new string(textCenter("  / _ \\/_/ _ __ | |_ ___| | __   ___  ___| |_ ___   ___ ___(_)_ __ ___  _   _| | /_/_| |_ ___  _ __ ")));
            Console.WriteLine(new string(textCenter(" / /_)/ _ \\ '_ \\| __/ _ \\ |/ /  / _ \\/ __| __/ _ \\ / __|_  / | '_ ` _ \\| | | | |/ _` | __/ _ \\| '__|")));
            Console.WriteLine(new string(textCenter("/ ___/  __/ | | | ||  __/   <  |  __/\\__ \\ ||  __/ \\__ \\/ /| | | | | | | |_| | | (_| | || (_) | |   ")));
            Console.WriteLine(new string(textCenter("\\/    \\___|_| |_|\\__\\___|_|\\_\\  \\___||___/\\__\\___| |___/___|_|_| |_| |_|\\__,_|_|\\__,_|\\__\\___/|_|   ")));

            Console.WriteLine("\n");

            Console.Write($"Helyszín: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{location}\n");
            Console.ForegroundColor = ConsoleColor.White;

            if (extra == " ")
            {
                Console.WriteLine($"{description}\n");

                Console.WriteLine($"{question}\n");
            }
            else
            {
            
                    Console.WriteLine($"{description}\n");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{extra}\n");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine($"{question}\n");
            }

            if (!timeStopped)
            {
                Time(timeMultiplier, player);
            }

            for (int i = 0; i < options.Length; i++)
            {
                if (i+1 == index)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"\t> ");

                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"{options[i]}");

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($" <");

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t  {options[i]}");
                }
            }
            Console.WriteLine();

            Console.WriteLine(new string('-', Console.WindowWidth));
            Console.WriteLine(textCenter("Játékos Tulajdonságai:"));
            Console.WriteLine();

            int length = $"Pénz: {Convert.ToString(player.Money)} Ft".Length + $"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék".Length + $"Boldogság: {Convert.ToString(player.Happiness)}".Length;
            
            writePlayer($"Pénz: {Convert.ToString(player.Money)} Ft", length);
            writePlayer($"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék", length);
            writePlayer($"Boldogság: {Convert.ToString(player.Happiness)}", length);

            Console.WriteLine("\n");
            Console.WriteLine(textCenter("Idő: " + player.Time));



            Console.WriteLine();


            if (player.Alcohol >= 5.2)
            {
                DisplayEnd(false, "None", "Alkoholmérgezés");
            }
            else if(player.Happiness <= 0)
            {
                DisplayEnd(false, "None", "Annyira szomorkás lett az életed hogy öngyilkos lettél");
            }
            else if(player.Money <= 0)
            {
                DisplayEnd(false, "None", "Csóró lettél");
            }

            ConsoleKey ret;
            do
            {
                ret = Console.ReadKey(true).Key;
            } while (ret != ConsoleKey.DownArrow && ret != ConsoleKey.UpArrow && ret != ConsoleKey.Enter);

            switch (ret)
            {
                case (ConsoleKey.DownArrow):
                    return Display(location, description, extra, question, player, true, index+1, 1, options);
                case (ConsoleKey.UpArrow):
                    return Display(location, description, extra, question, player, true, index-1, 1, options);
            }

            return index;
        }

        static void writePlayer(string text, int len)
        {
            if (text[text.Length-1] == 't') //pénz
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                Console.Write(words[0] + " ");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;

                if (int.Parse(words[1]) >= 4000)
                {
                    Console.BackgroundColor= ConsoleColor.Green;
                }
                else if (int.Parse(words[1]) <= 2000)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.Write(words[1] + " ");
                Console.Write(words[2]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else if (text[text.Length - 1] == 'k') // alkohol
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                Console.Write(words[0] + " ");
                Console.Write(words[1] + " ");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Black;

                if (double.Parse(words[2]) >= 4)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else if (double.Parse(words[2]) >= 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }
                else if (double.Parse(words[2]) >= 1)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }

                Console.Write(words[2] + " ");
                Console.Write(words[3]);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;

            }
            else // boldogság
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                int happLen = text.Length;
                ConsoleColor happCol;

                Console.ForegroundColor = ConsoleColor.Black;

                if (int.Parse(words[1]) >= 80)
                {
                    happCol = ConsoleColor.DarkGreen;
                }
                else if (int.Parse(words[1]) >= 60)
                {
                    happCol = ConsoleColor.Green;
                }
                else if (int.Parse(words[1]) >= 20)
                {
                    happCol = ConsoleColor.Yellow;
                }
                else
                {
                    happCol = ConsoleColor.Red;
                }

                double color = Math.Round(13.0 / 100.0 * player.Happiness, MidpointRounding.AwayFromZero);

                for (int i = 0; i < happLen; i++)
                {
                    if (i <= color)
                    {
                        Console.BackgroundColor = happCol;
                        Console.Write(text[i]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(text[i]);
                    }
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        static string textCenter(string text)
        {
            return new string(' ', (Console.WindowWidth - text.Length) / 2) + text;
        }
    }
}
