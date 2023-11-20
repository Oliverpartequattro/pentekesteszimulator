using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    internal partial class Player1
    {
        public int Money { get; set; }
        public int Alcohol { get; set; }
        public int Happiness { get; set; }
        public string Time { get; set; }

        public Player1()
        {
            Money = 5000; // Ft
            Alcohol = 0; // vérezrelék

            Random r = new Random();
            Happiness = r.Next(20, 41); // 100-ból

            Time = "17:00";
        }
    }
}

