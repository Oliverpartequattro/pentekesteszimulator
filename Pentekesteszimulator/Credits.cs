using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void credits(int speed)
        {
            Console.Clear();

            int h = Console.WindowWidth;

            string[] sorok =
            {
                "A JÁTÉKOT KITALÁLTA:",
                "Roncz Olivér",
                "Süke Benedek",
                "",
                "A JÁTÉKOT KÉSZÍTETTE:",
                "Roncz Olivér",
                "Süke Benedek",
                "",
                "KÜLÖN KÖSZÖNET:",
                "Anyukáinknak, Apukáinknak és a szüleinknek",
                "Az internetnek a segítségért",
                "Pai bá tanár úrnak a felkészítésért és az ösztöndíjért",
                "Tófalvi Zalánnak a credit függvényért",
                "Slo tanárúrnak mert az óráin is ezt csináltuk nem a kutya javascriptet",
                "A Pinterius-Valentino csapatnak",
                "Mindenkinek aki hitt bennünk",
                "",
                "Köszönjük, hogy játszottál a játékunkkal!"
            };

            Console.Clear();
            Console.CursorTop = h;
            Console.WriteLine(new string(' ', (Console.WindowWidth - sorok[0].Length) / 2) + sorok[0]);
            Thread.Sleep(speed);
            for (int i = 1; i < sorok.Length; i++)
            {
                Console.WriteLine();
                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(new string(' ', (Console.WindowWidth - sorok[i].Length) / 2) + sorok[i]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                {
                    Console.WriteLine(new string(' ', (Console.WindowWidth - sorok[i].Length) / 2) + sorok[i]);

                }
                Thread.Sleep(speed);
            }
            for (int i = 0; i < sorok.Length + 22; i++) //mi ez a plusz szám?
            {
                Console.WriteLine();
                Thread.Sleep(speed);
            }

            Console.WriteLine("\n\nBezárhatod a programot.");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }
    }
}