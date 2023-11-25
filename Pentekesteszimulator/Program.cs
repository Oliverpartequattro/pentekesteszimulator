using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading;

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
                case 3:
                    //Kulfold();
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

        #region varos
        static void Varos()
        {
            Increase(0, 2, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "A Putri Pályaudvaron vagy.", " ", "Hová mész tovább?", options, player);

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

        #region szorakozohely
        static void Szorakozohely()
        {
            int chance = r.Next(0, 100);
            Increase(r.Next(30, 60) / 100.0, 10, -1190, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Az \"éj hölgye\" ", "Vissza a városba" };
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba", "Odamész ahhoz az aranyos lányhoz" };
                choice = Display($"Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Megláttál egy aranyos lányt.", "Mit teszel?", options, player);
            }
            else
            {
                choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", " ", "Mit teszel?", options, player);
            }
            switch (choice)
            {
                case 1:
                    if (chance <= 100)
                    {
                        worlds[r.Next(0, worlds.Length)]();
                    }
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

        static void EjHolgye()
        {
            int chance = r.Next(0, 100);
            Increase(0, 30, -10000, player); //alkohol boldogság pénz
            string[] options = new string[]{ "Megmutatom neki a Fortnite Battle Passomat.",};
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Felül leszek", "Alul leszek", "Elmenekülök", };
                choice = Display($"Cigiszagú panel", "Felvitt a fizetős \"hölgy\" a paneljébe.", "Nagyobb neki, mint neked.", "Mit teszel?", options, player);
            }
            else
            {
                choice = Display("Cigiszagú panel", "Felvitt egy cigiszagú panelbe, ahol 3 férfi fehér csíkokat szív az asztalról.", " ", "Mit teszel?", options, player);
            }
            switch (choice)
            {
                case 1:
                    DisplayEnd(false, "Cigiszagú panel", "A fortika reszelés után megbánva hazamentél, mert elvesztetted a vbucksjaidat.");
                    break;
                case 2:
                    DisplayEnd(false, "Cigiszagú panel", "Az incidens után alig tudtál menni, annyira fájt a hátsó feled, megbántad az estét.");
                    break;
                case 3:
                    Varos();
                    break;
            }
        }

        static void IngyenesNeni()
        {
            int chance = r.Next(0, 100);
            Increase(0, 50, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Hazaviszed", "Elutasítod és inkább iszol egyet"};
            int choice;
           choice = Display("Happy Hours Nightclub", "Beszélgettél a lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", options, player);
            switch (choice)
            {
                case 1:
                   if(chance <= 10) { 
                    DisplayEnd(false, "Győrzámoly, Szerencse utca 9", "A helyes lány titokban egy szerb bérgyilkos volt, akit LISTA küldött rád, kitömött emberi próbababát csinált belőled.");
                    }
                    else
                    {
                        DisplayEnd(true, "Győrzámoly, Szerencse utca 9", "A kellemes kamatyolás után egymás mellett keltetek fel, majd elment az első busszal.");
                    }
                    break;
                case 2:
                    Szorakozohely();
                    break;
            }
        }
        #endregion //szorakozohely

        #region kocsma
        static void Kocsma()
        {
            Increase(r.Next(30, 60) / 100.0, 10, -800, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Fej vagy írás", "Vissza a városba" };
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy.", " ", "Mit teszel?", options, player);

            switch (choice)
            {
                case 1:
                    Kocsma();
                    break;

                case 2:
                    FejVagyIras();
                    break;

                case 3:
                    Varos();
                    break;
            }
        }

        static void FejVagyIras()
        {
            Increase(0, 0, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Játék", "Vissza a pulthoz"};
            int choice = Display("Vörös Farkas Pub", "Egy lista ember??? vállalta a \"Fej Vagy Írás\" kihívásod.", " ", "Mi a következő lépésed?", options, player);

            static string FlipCoin()
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 2);
                return randomNumber == 0 ? "Fej" : "Írás";
            }

            switch (choice)
            {
                case 1:
                    int bet;
                    Console.WriteLine("Mennyi pénzt raksz fel?");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out bet))
                    {
                        Console.WriteLine($"{bet} Ft-ot tettél fel.");

                        Console.WriteLine("Fej vagy Írás?");
                        string userChoice = Console.ReadLine();

                        if (userChoice.Equals("Fej", StringComparison.OrdinalIgnoreCase) || userChoice.Equals("Írás", StringComparison.OrdinalIgnoreCase))
                        {
                            string result = FlipCoin();
                            Console.WriteLine("\nAz eredmény:");
                            string text = $"............... {result} --> ";
                            int delay = 300;
                            foreach (char c in text)
                            {
                                Console.Write(c);
                                Thread.Sleep(delay);
                            }

                            if (char.ToLower(userChoice[0]) == char.ToLower(result[0]))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Nyertél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, 30, bet, player); //alkohol boldogság pénz
                                Thread.Sleep(1000);
                                FejVagyIras();
                            }
                            else
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine($"Vesztettél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, -30, - bet, player); //alkohol boldogság pénz
                                Thread.Sleep(2000);
                                FejVagyIras();
                            }
                        }
                        else
                        {
                            int pickpocket = r.Next(0, 1501);
                            Console.WriteLine($"A lista ember??? felpofozott (lista), mert a {userChoice} nem Fej, és nem is Írás.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
                            Increase(0, -30, -pickpocket, player); //alkohol boldogság pénz
                            Thread.Sleep(50);

                            Console.Write("Most kelsz fel");
                            string text = "...............";
                            int delay = 300;
                            foreach (char c in text)
                            {
                                Console.Write(c);
                                Thread.Sleep(delay);
                            }
                            FejVagyIras();
                        }
                                        
            }

                    else
                    {
                        int pickpocket = r.Next(0, 1501);
                        Console.WriteLine($"A lista ember??? felpofozott (lista), mert a {bet} közelsem egy szám.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
                        Increase(0, -30, - pickpocket, player); //alkohol boldogság pénz
                        Thread.Sleep(50);

                        Console.Write("Most kelsz fel");
                        string text = "...............";
                        int delay = 300;
                        foreach (char c in text)
                        {
                            Console.Write(c);
                            Thread.Sleep(delay);
                        }
                        FejVagyIras();
                    }
                    
                    break;

                case 2:
                    Kocsma();
                    break;
            }
        }
        #endregion //kocsma

        #region supermarket
        static void Supermarket()
        {
            int chance = r.Next(0, 100);
            Increase(r.Next(30, 60) / 100.0, 10, -300, player); //alkohol boldogság pénz
            string[] options = new string[] { "Veszel egy sört", "Vissza a városba" };
            int choice;
            if (chance <= 70)
            {
                options = new string[] { "Veszel egy sört", "Vissza a városba", "Odamész az alter lányhoz" };
                choice = Display("Zuszi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", "Megpillantasz egy alter lányt, ahogy éppen a Jagermaisterért nyúl. (LISTA)", "Mit teszel?", options, player);
            }
            else
            {
                choice = Display("Zuszi néni supermarkete", "A supermarketben vagy.", " ", "Mit teszel?", options, player);
            }

            switch (choice)
            {
                case 1:
                    Supermarket();
                    break;

                case 2:
                    Varos();
                    break;

                case 3:
                    AlterLany();
                    break;
            }
        }

        static void AlterLany()
        {
            int chance = r.Next(0, 100);
            Increase(0, 50, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Hazaviszed", "Elutasítod és inkább magányos maradsz" };
            int choice;
            choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", options, player);
            switch (choice)
            {
                case 1:
                    if (chance <= 10)
                    {
                        DisplayEnd(false, "Győrzámoly, Szerencse utca 9", "Az alter lány titokban egy szerb bérgyilkos volt, akit LISTA küldött rád, kitömött emberi próbababát csinált belőled.");
                    }
                    else if (chance <= 80)
                    {
                        ViccesGomba();
                    }
                    else
                    {
                        DisplayEnd(true, "Győrzámoly, Szerencse utca 9", "A kellemes kamatyolás után egymás mellett keltetek fel, majd elment az első busszal.");
                    }
                    break;
                case 2:
                    Supermarket();
                    break;
            }
        }
        static void ViccesGomba()
        {
            //egy fuggveny lista???? kulon helyekrol es opciokrol!%!%!%!%
        }


        #endregion //supermarket

        #endregion //varos

        #region falu
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
        #endregion //falu


    }
}