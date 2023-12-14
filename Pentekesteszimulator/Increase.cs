using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Increase(double alc, int happ, int mon) {
            player.Alcohol += alc;
            player.Money += mon;

            if (player.Happiness + happ >= 100)
            {
                player.Happiness = 100; //goto
            }
            else
            {
                player.Happiness += happ;
            }

            if (player.Alcohol + alc < 0)
            {
                player.Alcohol = 0;
            }
            else
            {
                player.Alcohol += alc;
            }

        }

        public static int carDeath(double alc, int hrsprs)
        {
            double rawResult = (alc * 25 * hrsprs) / (20 * r.Next(80, 121) / 10);
            int roundedResult = (int)Math.Round(rawResult);
            return Math.Min(roundedResult, 100);
        }
    }
}
