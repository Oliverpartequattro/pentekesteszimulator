using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pentekesteszimulator
{
    partial class Program
    {
        public static Player1 player = new Player1();
        public static Random r = new Random();
        public static string opponent;
        public static string weapon;
        public static int index = 1;
        public static int allBeer = r.Next(6, 31);
        public static int beerCount = 0;
        public static int badCount = 0;
        public static int goodCount = 0;
        public static int beersInRow = 0;
        public static int deathChance = 0;
        public static int greenRowThatWillBeWhite;
        public static int whiteRowThatWillBeGreen;
        public static int firstRow;
        public static int lastIndex;
        public static int returnCursorTo;
        public static int attributeRow;
        public static int lastRow;
        public static bool boughtBeer = false;
        public static bool alcPlusTime = false;
        public static bool beatenByFather = false;
        public static bool beatenByMother = false;
        public static bool requested = false;
        public static bool metil = r.Next(1, 4) == 1;
        public static bool stopCountdown = false;
        public static bool bloodAlc = false;
        public static bool voltCsoves = false;
        public static bool notNumTwice = false;
        public static bool bigNumTwice = false;
        public static string[] wheel = { "0", "32", "15", "19", "4", "21", "2", "25", "17", "34", "6", "27", "13", "36", "11", "30", "8", "23", "10", "5", "24", "16", "33", "1", "20", "14", "31", "9", "22", "18", "29", "7", "28", "12", "35", "3", "26" }; //borzasztó
    }
}
