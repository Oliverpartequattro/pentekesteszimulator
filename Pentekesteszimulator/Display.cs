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
        public static int Display(string location, string description, string question, string[] options, Player1 player)
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

            Console.WriteLine($"{description}\n");

            Console.WriteLine($"{question}\n");

            Time(player);

            for (int i = 0; i < options.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\t{i + 1}. ");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"{options[i]}");


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
                DisplayEnd(false, "None", "Öngyilkos lettél");
            }
            else if(player.Money <= 0)
            {
                DisplayEnd(false, "None", "Csóró lettél");
            }

            int ret;
            do{ 
            } while (!(int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out ret) && ret >= 1 && ret <= options.Length));

            return ret;
        }

        static void writePlayer(string text, int len)
        {
            if (text[text.Length-1] == 't') //pénz
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                Console.Write(words[0] + " ");

                Console.ForegroundColor = ConsoleColor.Black;

                if (int.Parse(words[1]) >= 4000)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                }
                else if (int.Parse(words[1]) <= 2000)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(words[1] + " ");
                Console.Write(words[2]);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else if (text[text.Length - 1] == 'k') // alkohol
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                Console.Write(words[0] + " ");
                Console.Write(words[1] + " ");

                Console.ForegroundColor = ConsoleColor.Black;

                if (double.Parse(words[2]) >= 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (double.Parse(words[2]) >= 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if (double.Parse(words[2]) >= 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.Write(words[2] + " ");
                Console.Write(words[3]);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else // boldogság
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                Console.Write(words[0] + " ");

                Console.ForegroundColor = ConsoleColor.Black;

                if (int.Parse(words[1]) >= 80)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                else if (int.Parse(words[1]) >= 60)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (int.Parse(words[1]) >= 40)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (int.Parse(words[1]) >= 20)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(words[1]);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static string textCenter(string text)
        {
            return new string(' ', (Console.WindowWidth - text.Length) / 2) + text;
        }
    }
}
