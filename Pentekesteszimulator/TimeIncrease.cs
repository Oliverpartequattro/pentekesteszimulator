using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Time(double multiplier, Player1 player)
        {
            Random r = new Random();
            double time = Math.Floor( r.Next(30, 51) * multiplier);

            if(multiplier != 0)
            {
                int cardiacArrest = r.Next(0, 201);
                if (cardiacArrest == 42) //fortika
                {
                    DisplayEnd(false, "None", "Hirtelen szúró fájdalmat érzel a mellkasod bal oldalán. Szívrohamban eltávozol.");
                }
            }

            Increase((-0.1 * (time / 60)), 0, 0, player);

            string[] arr = player.Time.Split(":");
            int min = (int)Math.Floor(time % 60);
            int hour = (int)Math.Floor(time / 60);

            int newHour = (int)Convert.ToInt32(arr[0]) + hour;
            int newMin = (int)Convert.ToInt32(arr[1]) + min;

            if (newMin >= 60)
            {
                newHour += newMin / 60;
                newMin %= 60;
            }

            if(newHour >= 24)
            {
                newHour = 0;
            }

            if(newMin < 10)
            {
                player.Time = $"{newHour}:0{newMin}";
            }
            else
            {
                player.Time = $"{newHour}:{newMin}";
            }

            if (newHour > 6 && newHour <= 12)
            {
                DisplayEnd(true, "None", "Nagyon késő van. fáradtan hazatérsz épségben.");
            }

        }
    }
}
