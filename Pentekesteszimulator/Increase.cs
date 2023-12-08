using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Increase(double alc, int happ, int mon, Player1 player) {
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
    }
}
