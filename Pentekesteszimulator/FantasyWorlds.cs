using System;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public delegate void FantasyWorlds();

        public static FantasyWorlds[] methodArray = new FantasyWorlds[]
        {
            FantasyWorld1,
            FantasyWorld2,
            FantasyWorld3,
            FantasyWorld4,
            FantasyWorld5,
        };

        public static void FantasyWorld()
        {
            Random random = new Random();

            int randomIndex = random.Next(0, methodArray.Length);

            methodArray[randomIndex]();

            Console.ReadLine();
        }

        public static void FantasyWorld1()
        {
            Console.WriteLine("This is Method 1");
        }

        public static void FantasyWorld2()
        {
            Console.WriteLine("This is Method 2");
        }

        public static void FantasyWorld3()
        {
            Console.WriteLine("This is Method 3");
        }

        public static void FantasyWorld4()
        {
            Console.WriteLine("This is Method 4");
        }

        public static void FantasyWorld5()
        {
            Console.WriteLine("This is Method 5");
        }
    }
}
