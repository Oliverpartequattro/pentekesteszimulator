using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void updateAttributeDisplay()
        {
            lastRow = Console.CursorTop;

            Console.SetCursorPosition(0, attributeRow);

            Console.WriteLine("\n" + new string('-', Console.WindowWidth));
            Console.WriteLine(textCenter("Játékos Tulajdonságai:") + "\n");
            int length = $"Pénz: {Convert.ToString(player.Money)} Ft".Length + $"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék".Length + $"Boldogság: {Convert.ToString(player.Happiness)}".Length;
            writePlayer($"Pénz: {Convert.ToString(player.Money)} Ft", length);
            writePlayer($"Véralkohol szint: {Convert.ToString(Math.Round(player.Alcohol, 2))} ezrelék", length);
            writePlayer($"Boldogság: {Convert.ToString(player.Happiness)}", length);
            Console.WriteLine("\n");
            Console.WriteLine(textCenter("Idő: " + player.Time));

            Console.WriteLine();
            if (lastRow > Console.CursorTop)
            {
                Console.SetCursorPosition(0, lastRow);
            }

        }
    }
}
