using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        private static Player1 player = new Player1();

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Otthon();

        }

        public static void Otthon()
        {
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choise = Display("Otthon", "Péntek este van. Otthon vagy.", "Milyen járművel indulsz el?", options, player);

            switch (choise)
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
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choise = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", "Hová mész tovább?", options, player);

            switch (choise)
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

        static void Auto()
        {
            Increse(0, 0, -300, player);
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choise = Display("Garázs", "Úgy döntöttél autóval indulsz útnak.", "Hová mész tovább?", options, player);

            switch (choise)
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

        static void Bicikli()
        {
            Increse(0, 5, 0, player);
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choise = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", "Hová mész tovább?", options, player);

            switch (choise)
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
    }
}