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
            Console.CursorVisible = false;

            Console.WriteLine(new string(textCenter("   ___  _        _       _                _                 _                 _   _   _             ")));
            Console.WriteLine(new string(textCenter("  / _ \\/_/ _ __ | |_ ___| | __   ___  ___| |_ ___   ___ ___(_)_ __ ___  _   _| | /_/_| |_ ___  _ __ ")));
            Console.WriteLine(new string(textCenter(" / /_)/ _ \\ '_ \\| __/ _ \\ |/ /  / _ \\/ __| __/ _ \\ / __|_  / | '_ ` _ \\| | | | |/ _` | __/ _ \\| '__|")));
            Console.WriteLine(new string(textCenter("/ ___/  __/ | | | ||  __/   <  |  __/\\__ \\ ||  __/ \\__ \\/ /| | | | | | | |_| | | (_| | || (_) | |   ")));
            Console.WriteLine(new string(textCenter("\\/    \\___|_| |_|\\__\\___|_|\\_\\  \\___||___/\\__\\___| |___/___|_|_| |_| |_|\\__,_|_|\\__,_|\\__\\___/|_|   ")));

            Console.WriteLine("\n");


            if (location != "")
            {
                Console.Write($"Helyszín: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{location}\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            if(player.Alcohol > 4.0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vigyázz, figyelj az alkohol szintedre, mert halál közeli állapotban vagy!\n");
                Console.ForegroundColor = ConsoleColor.White;

            }
            
            if(player.Money < 1500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vigyázz, nagyon kevés pénzed van! Márcsak {player.Money}Ft-od maradt! Ha elfogy vége lesz a züllésnek. És muszály lesz hazasétálnod.\n");
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

            Console.WriteLine($"{question}\n");
            Time(timeMultiplier);

            for (int i = 0; i < options.Length; i++)
            {
                if (i == 0)
                {
                    firstRow = Console.CursorTop;
                }
                //if (i+1 == index)
                //{
                //    greenRowThatWillBeWhite = Console.CursorTop;

                //    Console.ForegroundColor = ConsoleColor.DarkGreen;
                //    Console.BackgroundColor = ConsoleColor.Black;
                //    Console.Write($"\t> ");

                //    Console.BackgroundColor = ConsoleColor.DarkGreen;
                //    Console.ForegroundColor = ConsoleColor.Black;
                //    Console.Write($"{options[i]}");

                //    Console.ForegroundColor = ConsoleColor.DarkGreen;
                //    Console.BackgroundColor = ConsoleColor.Black;
                //    Console.WriteLine($" <");

                //    Console.BackgroundColor = ConsoleColor.Black;
                //    Console.ForegroundColor = ConsoleColor.White;
                //}
                //else
                //{
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"\t  ");


                Console.WriteLine($"{options[i]}");
                //}
            }

            attributeRow = Console.CursorTop;

            updateAttributeDisplay();

            returnCursorTo = Console.CursorTop;

            //Console.WriteLine(greenRow);
            //Console.WriteLine(index);

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

            greenRowThatWillBeWhite = firstRow;
            lastIndex = index;
            rePaint(index, greenRowThatWillBeWhite, whiteRowThatWillBeGreen, options);
            ConsoleKey ret;
            bool continueLoop = true;

            do
            {
                ret = Console.ReadKey(true).Key;

                switch (ret)
                {
                    case ConsoleKey.DownArrow:
                        whiteRowThatWillBeGreen = greenRowThatWillBeWhite;
                        lastIndex = index;
                        index += 1;

                        if (index > options.Length) //lefele tul nagy ezert visszaugrik az elejere
                        {
                            index = 1;
                        }

                        greenRowThatWillBeWhite = index - 1 + firstRow;

                        rePaint(index, greenRowThatWillBeWhite, whiteRowThatWillBeGreen, options);
                        break;

                    case ConsoleKey.UpArrow:
                        whiteRowThatWillBeGreen = greenRowThatWillBeWhite;
                        lastIndex = index;
                        index -= 1;

                        if (index < 1)
                        {
                            index = options.Length;

                        }

                        greenRowThatWillBeWhite = index - 1 + firstRow;

                        rePaint(index, greenRowThatWillBeWhite, whiteRowThatWillBeGreen, options);
                        break;


                    case ConsoleKey.Enter:
                        if (player.Alcohol > 4 && r.Next(1, 5) == 3)
                        {
                            index = r.Next(1, options.Length + 1);
                        }

                        continueLoop = false;
                        break;
                }

            } while (continueLoop);

            whiteRowThatWillBeGreen = 0;
            Console.CursorVisible = true;
            return index;
        }

        

        static void rePaint(int index, int greenToWhiteRow, int whiteToGreenRow, string[] options)
        {
            Console.CursorVisible = false;

            if (whiteRowThatWillBeGreen != 0)
            {
                Console.SetCursorPosition(0, whiteToGreenRow);

                Console.Write($"\t  {options[lastIndex - 1]}  ");
            }

            Console.SetCursorPosition(0, greenToWhiteRow);//zölddé írás koordinátái

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($"\t> ");

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write($"{options[index - 1]}");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write($" <");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;


            Console.SetCursorPosition(0, returnCursorTo);

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

                    if (plugCount > 0)
                    {
                        if (r.Next(0, 2) == 0)
                        {
                            happCol = ConsoleColor.Magenta;
                        }
                        else
                        {
                            happCol = ConsoleColor.DarkMagenta;
                        }
                    }
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
            //Console.WriteLine(text, align:"center");
            return new string(' ', (Console.WindowWidth - text.Length) / 2) + text;
        }
    }
}

//enimál tájp
