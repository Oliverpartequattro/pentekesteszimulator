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
            int choice = Display("Győrzámoly, Szerencse utca 9", "Fájó fejjel kelsz fel, úgy érzed, mintha 2000 évet utaztál volna, ezért úgy döntesz, hogy berúgsz.", "Milyen járművel indulsz el?", options, player);

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
            Increse(0, -10, -300, player);
            string[] options = new string[] { "Város", "Falu" };
            int choice = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", "Hová mész tovább?", options, player);

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
            Increse(0, 0, -300, player);
            string[] options = new string[] { "Város", "Falu" };
            int choice = Display("Garázs", "Úgy döntöttél autóval indulsz útnak.", "Hová mész tovább?", options, player);

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
            Increse(0, 2, 0, player);
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Falu();
                    break;
            }
        }
        static void Varos()
        {
            Increse(0, 2, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "A Putri Pályaudvaron vagy", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Szorakozohely();
                    break;

                case 2:
                    Kocsma();
                    break;

                case 3:
                    
                    break;
            }
        }
        static void Szorakozohely()
        {
            int chance = r.Next(0, 100);
            Increse(r.Next(30,60) / 100.0, 10, -1190, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba" };
            if (chance <= 40)
            {
                options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba", "Odamész ahhoz az aranyos lányhoz" };
            }

            int choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Mit teszel?", options, player);

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
                    IngyenesNeni();
                    break;
            }
        }

        

        static void Kocsma()
        {
            Increse(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Fej vagy írás", "Vissza a városba" };
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy", "Mit teszel?", options, player);

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
            Increse(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", "Hová mész tovább?", options, player);

            switch (choice)
            {
                case 1:
                    Falu();
                    break;
            }
        }


    }
}