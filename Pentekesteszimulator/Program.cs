using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Channels;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        private static Player1 player = new Player1();
        private static Random r = new Random();

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Otthon();

        }

        public static void Otthon()
        {
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choice = Display("Győrzámoly, Szerencse utca 9", "Fájó fejjel kelsz fel egy fura középkorban játszódó álom után, úgy érzed, mintha 2000 évet időutaztál volna, ezért úgy döntesz, hogy berúgsz.", " ", "Milyen járművel indulsz el?", options, player);

            switch (choice)
            {
                case 1:
                    Busz();
                    break;
                case 2:
                    Auto();
                    break;
                case 3:
                    Bicikli();
                    break;

            }

        }

        static void Busz()
        {
            Increase(0, -10, -300, player);
            string[] options = new string[] { "Város", "Falu" };
            int choice = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", " ", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Varos();
                    break;
                case 2:
                    Falu();
                    break;
            }

        }

        static void Auto()
        {
            Increase(0, 0, -300, player);
            string[] options = new string[] { "Város", "Falu" };
            int choice = Display("Garázs", "Úgy döntöttél autóval indulsz útnak.", " ", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Varos();
                    break;
                case 2:
                    Falu();
                    break;
            }
        }

        static void Bicikli()
        {
            Increase(0, 2, 0, player);
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", " ", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Falu();
                    break;
            }
        }
        static void Varos()
        {
            Increase(0, 2, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "A Putri Pályaudvaron vagy", " ", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Szorakozohely();
                    break;

                case 2:
                    Kocsma();
                    break;

                case 3:
                    Supermarket();
                    break;
            }
        }
        static void Szorakozohely()
        {
            int chance = r.Next(0, 100);
            Increase(r.Next(30, 60) / 100.0, 10, -1190, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Az \"éj hölgye\" ", "Vissza a városba" };
            int choice;
            if (chance <= 40)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                choice = Display($"Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Megláttál egy aranyos lányt", "Mit teszel?", options, player);
                Console.ResetColor();
                options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba", "Odamész ahhoz az aranyos lányhoz" };
            }
            else
            {
                choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", " ", "Mit teszel?", options, player);
            }
            switch (choice)
            {
                case 1:
                    Szorakozohely();
                    break;
                case 2:
                    EjHolgye();
                    break;
                case 3:
                    Varos();
                    break;
                case 4:

                    break;
            }
        }

        static void EjHolgye()
        {
            int chance = r.Next(0, 100);
            Increase(0, 5, -10000, player); //alkohol boldogság pénz
            string[] options = new string[] { "Elmész vele a panelba" };
            if (chance <= 100)
            {
                options = new string[] { "Elmész vele a panelba", "Elmenekülsz" };
            }
            else
            {

            }

            int choice = Display("Az éj hölgye", "Igénybe vetted az éjszaka hölgyének szolgáltatásait", " ", "Mit teszel?", options, player);

            switch (choice)
            {

                case 1:
                    DisplayEnd(false, "Cigiszagú panel", "Kurelás");
                    break;
                case 2:
                    Console.WriteLine("masodik");
                    break;
                case 3:
                    Varos();
                    break;
                case 4:

                    break;
            }
        }



        static void Kocsma()
        {
            Increase(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Fej vagy írás", "Vissza a városba" };
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy", " ", "Mit teszel?", options, player);

            switch (choice)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;
            }
        }
        static void Supermarket()
        {
            Increase(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Fej vagy írás", "Vissza a városba" };
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy", " ", "Mit teszel?", options, player);

            switch (choice)
            {
                case 1:

                    break;

                case 2:

                    break;

                case 3:

                    break;
            }
        }

        static void Falu()
        {
            Increase(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", " ","Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Falu();
                    break;
            }
        }


    }
}