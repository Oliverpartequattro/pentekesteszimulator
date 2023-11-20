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

            int length = $"Pénz: {Convert.ToString(player.Money)} Ft".Length + $"Véralkohol szint: {Convert.ToString(player.Alcohol)} ezrelék".Length + $"Boldogság: {Convert.ToString(player.Happiness)}".Length;
            Console.Write(writePlayer($"Pénz: {Convert.ToString(player.Money)} Ft", length));
            Console.Write(writePlayer($"Véralkohol szint: {Convert.ToString(player.Alcohol)} ezrelék", length));
            Console.Write(writePlayer($"Boldogság: {Convert.ToString(player.Happiness)}", length));

            Console.WriteLine("\n");
            Console.WriteLine(textCenter("Idő: " + player.Time));



            Console.WriteLine();

            int ret;
            do{ 
            } while (!(int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out ret) && ret >= 1 && ret <= options.Length));

            return ret;
        }

        static string writePlayer(string text, int len)
        {
            return new string(' ', (Console.WindowWidth - len) / 4) + text;
        }

        static string textCenter(string text)
        {
            return new string(' ', (Console.WindowWidth - text.Length) / 2) + text;
        }
    }
}
