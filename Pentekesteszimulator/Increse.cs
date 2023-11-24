using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static void Increse(double alc, int happ, int mon, Player1 player) {
            player.Alcohol += alc;
            player.Happiness += happ;
            player.Money += mon;
        }
    }
}
