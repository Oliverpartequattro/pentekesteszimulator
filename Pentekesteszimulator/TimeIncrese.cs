using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Time(Player1 player)
        {
            Random r = new Random();
            int time = r.Next(30, 61);

            string[] arr = player.Time.Split(":");
            int min = time % 60;
            int hour = time / 60;

            int newHour = Convert.ToInt32(arr[0]) + hour;
            int newMin = Convert.ToInt32(arr[1]) + min;

            if (newMin >= 60)
            {
                newHour += newMin / 60;
                newMin %= 60;
            }

            if(newMin < 10)
            {
                player.Time = $"{newHour}:0{newMin}";
            }
            else
            {
                player.Time = $"{newHour}:{newMin}";
            }

        }
    }
}
