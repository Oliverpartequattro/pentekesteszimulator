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
        public static int Display(string location, string description, string extra, string question, Player1 player, int index, double timeMultiplier, string[] options)
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

            if(player.Alcohol > 4.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vigyázz, figyelj az alkohol szintedre, mert halál közeli állapotban vagy!\n");
                Console.ForegroundColor = ConsoleColor.White;

            }
            
            if(player.Money < 1500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vigyázz, nagyon kevés pénzed van! Márcsak {player.Money}Ft-od maradt! Ha elfogy vége lesz a züllésnek.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if (player.Happiness < 25)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Nagyon boldogtalan vagy öngyilkos gondolatok kezdenek el terjengeni a fejedben. \nTipp: Csinálj valami felvidíttót.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine($"{description}\n");

            if (extra != " ")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{extra}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            //else if (extra[0] == '\\' && extra[1] == 'p')
            //{
            //    Console.WriteLine($"{description}\n");

            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine($"{extra}\n");
            //    Console.ForegroundColor = ConsoleColor.White;

            //    Console.WriteLine($"{question}\n");
            //}

            Console.WriteLine($"{question}\n");
            Time(timeMultiplier, player);

            for (int i = 0; i < options.Length; i++)
            {
                if (i+1 == index)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"\t> ");

                    cursorPositions.Add(new List<int> { Console.CursorLeft, Console.CursorTop });

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
                    Console.Write($"\t  ");

                    cursorPositions.Add(new List<int> { Console.CursorLeft, Console.CursorTop });

                    Console.WriteLine($"{options[i]}");
                }
            }

            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
            Console.WriteLine(textCenter("Játékos Tulajdonságai:") + "\n");

            int length = $"Pénz: {Convert.ToString(player.Money)} Ft".Length + $"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék".Length + $"Boldogság: {Convert.ToString(player.Happiness)}".Length;
            
            writePlayer($"Pénz: {Convert.ToString(player.Money)} Ft", length);
            writePlayer($"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék", length);
            writePlayer($"Boldogság: {Convert.ToString(player.Happiness)}", length);

            Console.WriteLine("\n");
            Console.WriteLine(textCenter("Idő: " + player.Time));

            Console.WriteLine();

            if (player.Alcohol >= 5.2)
            {
                DisplayEnd(false, "None", "Hányingered van és akadozik a beszéded. Egyensúlyérzéked bizonytalan, könnyen megbotlassz és össze esel a földön. A pulzusod lassulni kezd és habzó szájjal meghalsz a földön.");
            }
            else if(player.Happiness <= 0)
            {
                DisplayEnd(false, "None", "Annyira szomorkás lett az életed hogy elvetted a saját életed.");
            }
            else if(player.Money <= 0)
            {
                DisplayEnd(false, "None", "Elfogyott az összes pénzed. Még időben elindulsz hogy gyalog hazaérj.");
            }

            ConsoleKey ret;
            do
            {
                ret = Console.ReadKey(true).Key;
            } while (ret != ConsoleKey.DownArrow && ret != ConsoleKey.UpArrow && ret != ConsoleKey.Enter);

            if(index == 1)
            {
                switch (ret)
                {
                    case (ConsoleKey.UpArrow):
                        return Display(location, description, extra, question, player, options.Length, 0, options);
                    case (ConsoleKey.DownArrow):
                        return Display(location, description, extra, question, player, index + 1, 0, options);
                }
            }
            else if (index == options.Length) 
            {
                switch (ret)
                {
                    case (ConsoleKey.UpArrow):
                        return Display(location, description, extra, question, player, index - 1, 0, options);
                    case (ConsoleKey.DownArrow):
                        return Display(location, description, extra, question, player, 1, 0, options);
                }
            }
            else
            {
                switch (ret)
                {
                    case (ConsoleKey.UpArrow):
                        return Display(location, description, extra, question, player, index-1, 0, options);
                    case (ConsoleKey.DownArrow):
                        return Display(location, description, extra, question, player, index+1, 0, options);
                }
            }

            if (player.Alcohol > 4 && r.Next(1, 5) == 3)
            {
                index = r.Next(1, options.Length + 1);
            }

            return index;
        }

        static void writePlayer(string text, int len)
        {
            if (text[text.Length-1] == 't') //pénz
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                int monLen = text.Length;
                ConsoleColor monCol;

                Console.ForegroundColor = ConsoleColor.Black;

                if (int.Parse(words[1]) >= 4000)
                {
                    monCol = ConsoleColor.Green;
                }
                else if (int.Parse(words[1]) <= 2000)
                {
                    monCol = ConsoleColor.Red;
                }
                else
                {
                    monCol = ConsoleColor.White;
                }

                double color = Math.Round(monLen / 5000.0 * player.Money, MidpointRounding.AwayFromZero);

                for (int i = 0; i < monLen; i++)
                {
                    if (i <= color)
                    {
                        Console.BackgroundColor = monCol;
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
            else if (text[text.Length - 1] == 'k') // alkohol
            {
                string[] words = text.Split(' ');
                Console.Write(new string(' ', (Console.WindowWidth - len) / 4));
                int alcLen = text.Length;
                ConsoleColor alcCol;

                Console.ForegroundColor = ConsoleColor.Black;

                if (double.Parse(words[2]) >= 4)
                {
                    alcCol = ConsoleColor.Red;
                }
                else if (double.Parse(words[2]) >= 3)
                {
                    alcCol = ConsoleColor.DarkYellow;
                }
                else if (double.Parse(words[2]) >= 1)
                {
                    alcCol = ConsoleColor.Yellow;
                }
                else
                {
                    alcCol = ConsoleColor.White;
                }

                double color = Math.Round(alcLen / 5.0* player.Alcohol, MidpointRounding.AwayFromZero);

                for (int i = 0; i < alcLen; i++)
                {
                    if (i <= color)
                    {
                        Console.BackgroundColor = alcCol;
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

                double color = Math.Round(happLen / 100.0 * player.Happiness, MidpointRounding.AwayFromZero);

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
