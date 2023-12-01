using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;

namespace Pentekesteszimulator
{

    //nem kibelezett class
    internal partial class Program
    {
        private static Player1 player = new Player1();
        private static bool timeStopped = false;
        private static int index = 1;
        private static Random r = new Random();
        private static int allBeer = r.Next(6, 31);
        private static int beerCount = 0;
        private static string opponent;
        private static bool boughtBeer = false;
        private static bool alcPlusTime = false;



        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Otthon();
        }

        public static void Otthon()
        {
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "Fájó fejjel kelsz fel egy fura középkorban játszódó álom után, úgy érzed, mintha 2000 évet időutaztál volna, ezért úgy döntesz, hogy berúgsz.", " ", "Milyen járművel indulsz el?", player, timeStopped, index, options);
            if (choice <= 0 || choice >= 4)
            {
                DisplayEnd(true, "", "bjan vam");
            }
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
            int choice = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", " ", "Hová mész tovább?", player, timeStopped, index, options);

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
            string[] options = new string[] { "Város", "Falu", "Elhagyod az országot" };
            int choice = Display("Garázs", "Úgy döntöttél autóval indulsz útnak.", " ", "Hová mész tovább?", player, timeStopped, index, options);

            switch (choice)
            {
                case 1:
                    Varos();
                    break;
                case 2:
                    Falu();
                    break;
                case 3:
                    Kulfold();
                    break;
            }
        }

        static void Bicikli()
        {
            Increase(0, 2, 0, player);
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", " ", "Hová mész tovább?", player, timeStopped, index, options);

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
            int choice = Display("Putri Pályaudvar", "A Putri Pályaudvaron vagy.", " ", "Hová mész tovább?", player, timeStopped, index, options);

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
                choice = Display($"Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Megláttál egy aranyos lányt.", "Mit teszel?", player, timeStopped, index, options);
            }
            else
            {
                choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", " ", "Mit teszel?", player, timeStopped, index, options);
            }
            switch (choice)
            {
                case 1:
                    if (chance <= 10)
                    {
                        VarazsGomba();
                    }
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

        static void EjHolgye()
        {
            int chance = r.Next(0, 100);
            Increase(0, 30, -10000, player); //alkohol boldogság pénz
            string[] options = new string[]{ "Megmutatom neki a Fortnite Battle Passomat.",};
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Felül leszek", "Alul leszek", "Elmenekülök", };
                choice = Display($"Cigiszagú panel", "Felvitt a fizetős \"hölgy\" a paneljébe.", "Nagyobb neki, mint neked.", "Mit teszel?", player, timeStopped, index, options);
            }
            else
            {
                choice = Display("Cigiszagú panel", "Felvitt egy cigiszagú panelbe, ahol 3 férfi fehér csíkokat szív az asztalról.", " ", "Mit teszel?", player, timeStopped, index, options);
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
           choice = Display("Happy Hours Nightclub", "Beszélgettél a lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", player, timeStopped, index, options);
            switch (choice)
            {
                case 1:
                   if(chance <= 10) { 
                    DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", $"A helyes lány titokban egy szerb bérgyilkos volt, akit {RandomPerson()} küldött rád, kitömött emberi próbababát csinált belőled.");
                    }
                    else
                    {
                        DisplayEnd(true, "Győrzámoly, Szerencse utca 22/B", "A kellemes kamatyolás után egymás mellett keltetek fel, majd elment az első busszal.");
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
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy.", " ", "Mit teszel?", player, timeStopped, index, options);

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
            string opponent = RandomPerson();
            Increase(0, 0, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Játék", "Vissza a pulthoz"};
            int choice = Display("Vörös Farkas Pub", $"{opponent} vállalta a \"Fej Vagy Írás\" kihívásod.", " ", "Mi a következő lépésed?", player, true, index, options);

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
                    ulong bigNum;
                    Console.WriteLine("Mennyi pénzt raksz fel?");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out bet) && bet > player.Money)
                    {
                        Console.WriteLine($"\n{opponent} átnézte a zsebeidet és nincs ennyi pénzed. {opponent} megfenyeget, ne próbálkozz a csalással.\nMegértetted?");
                        Console.ReadKey(true);

                        FejVagyIras();
                    }
                    else if (int.TryParse(input, out bet))
                    {
                        Console.WriteLine($"{bet} Ft-ot tettél fel.\n");

                        Console.WriteLine("Fej vagy Írás?");
                        string userChoice = Console.ReadLine();

                        bool isValid = false;
                        if (userChoice.Equals("Fej", StringComparison.OrdinalIgnoreCase) || userChoice.Equals("Írás", StringComparison.OrdinalIgnoreCase) || userChoice.Equals("Irás", StringComparison.OrdinalIgnoreCase) || userChoice.Equals("Iras", StringComparison.OrdinalIgnoreCase) || userChoice.Equals("Íras", StringComparison.OrdinalIgnoreCase))
                        {
                            isValid = true;
                            if (char.ToLower(userChoice[0]) == 'i'){
                                userChoice = "í";
                            }
                            if (userChoice.Length >= 3 && char.ToLower(userChoice[2]) == 'a')
                            {
                                userChoice = "í";
                            }
                        }
                        

                        if (isValid)
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
                                Console.ReadKey(true);

                                FejVagyIras();
                            }
                            else
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine($"Vesztettél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, -30, - bet, player); //alkohol boldogság pénz
                                Thread.Sleep(2000);
                                Console.ReadKey(true);

                                FejVagyIras();
                            }
                        }
                        else
                        {
                            int pickpocket = r.Next(0, 1501);
                            Console.WriteLine($"{opponent} {RandomMoveOpponent()}, mert a(z) \"{userChoice}\" nem Fej, és nem is Írás.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
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
                            Console.ReadKey(true);

                            FejVagyIras();
                        }                
                    }
                    else if (ulong.TryParse(input, out bigNum)){
                        Console.WriteLine($"\nEz túl nagy szám {opponent}-nek, nem tudja feldolgozni. Azt hiszi csalni akarsz ezért {RandomMoveOpponent()}.");
                        Increase(0, -30, 0, player);

                        Console.Write("Most kelsz fel");
                        string text = "...............";
                        int delay = 300;
                        foreach (char c in text)
                        {
                            Console.Write(c);
                            Thread.Sleep(delay);
                        }
                        Console.ReadKey(true);

                        FejVagyIras();
                    }
                    else
                    {
                        int pickpocket = r.Next(0, 1501);
                        Console.WriteLine($"{opponent}  {RandomMoveOpponent()} , mert a(z) \"{input}\" közelsem egy szám.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
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
                        Console.ReadKey(true);

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
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", "Megpillantasz egy alter lányt, ahogy éppen a Jagermaisterért nyúl.", "Mit teszel?", player, timeStopped, index, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", " ", "Mit teszel?", player, timeStopped, index, options);
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
            int chance = r.Next(0, 101);
            Increase(0, 50, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { $"Hazaviszed", "Elutasítod és inkább magányos maradsz" };
            int choice;
            if (chance <= 80)
            {
                options = new string[] { "Hazaviszed", "Elutasítod és inkább magányos maradsz", "Gombásztok" };
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", $"A zsebében ott lapul {r.Next(3,11)} gramm varázsgomba", "Mit teszel?", player, timeStopped, index, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", player, timeStopped, index, options);
            }  
            switch (choice)
            {
                case 1:
                    if (chance <= 10)
                    {
                        DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", $"Az alter lány titokban egy szerb bérgyilkos volt, akit {RandomPerson()} küldött rád, kitömött emberi próbababát csinált belőled.");
                    }
                    else
                    {
                        DisplayEnd(true, "Győrzámoly, Szerencse utca 22/B", "A kellemes kamatyolás után egymás mellett keltetek fel, majd elment az első busszal.");
                    }
                    break;
                    case 2:
                    Supermarket();
                    break;
                case 3:
                    VarazsGomba();
                    break;
            }
        }

        static void VarazsGomba()
        {
            worlds [r.Next(0, worlds.Length)]();
        }

        #endregion //supermarket

        #endregion //varos

        #region falu
        static void Falu()
        {
            string drinkMan = RandomPerson();
            int chance = r.Next(0, 100);
            Increase(0, 5, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Sarki bolt", "Haverok", "Falusi kocsma" };
            int choice;
            if (chance <= 10)
            {
                options = new string[] { "Sarki bolt", "Haverok", "Falusi kocsma", "Maradok vele inni" };
                choice = Display("Dorozsmai faluközpont", "A 20km-es főútat végigszenvedve a faluközpontba jutsz.", $"Egy {drinkMan} \"vegyes házit\" kínál.", "Hová mész tovább?", player, true, index, options);
            }
            else
            {
                choice = Display("Dorozsmai faluközpont", "A 20km-es főútat végigszenvedve a faluközpontba jutsz.", " ", "Hová mész tovább?", player, true, index, options);
            }
            switch (choice)
            {
                case 1:
                    SarkiBolt();
                    break;
                case 2:
                    if (boughtBeer == true)
                    {
                        Haverok();
                    }
                    else
                    {
                        Console.WriteLine("Nem vettél sört a sarki boltban, üres kézzel nem illik beállítani!");
                        Console.WriteLine("Visszamész a faluba...");
                        Console.ReadKey();
                        Falu();
                    }
                    
                    break;
                case 3:
                    FalusiKocsma();
                    break;
                case 4:
                    if (chance % 10 == 0) 
                    {
                        DisplayEnd(false, "Dorozsmai faluközpont", $"{drinkMan} által kínált \"vegyes házi\" fagyálló volt. Továbbindultál utadra, de menetközben leálltak a veséid, és összeestél.");
                    }
                    else 
                    {
                        Increase(r.Next(70, 120) / 100.0, 20, 0, player);
                        Falu();
                    }
                    break;
            }
        }

        #region SarkiBolt
        static void SarkiBolt()
        {
            boughtBeer = true;
            beerCount++;
            allBeer ++;
            Time(player);
            Increase(0, 1, -500, player); //alkohol boldogság pénz
            string[] options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba" };
            int choice;
            if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
            {
                options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba", "Elmész a templomba" };
                choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", "Lehetőságed van elmenni az éjféli misére", "Mit teszel?", player, timeStopped, index, options);       
            }
            else
            {
                choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", " ", "Mit teszel?", player, timeStopped, index, options);
            }
            switch (choice)
            {
                case 1:
                    SarkiBolt();
                    break;
                case 2:
                    Lotto();
                    break;
                case 3:
                    Falu();
                    break;
                case 4:
                    EjfeliMise();
                    break;
            }
        }

        static void Lotto()
        {
            Increase(0, 0, -500, player);
            Console.WriteLine("Vettél egy lottószelvényt 500Ft-ért.");
            int[] winNums = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int rand = r.Next(1, 11);
                if (winNums.Count(s => s == rand) == 0)
                {
                   winNums[i] = rand;
                }
                else
                {
                    Console.WriteLine("fsfddfsfds");
                    i -=1;
                }
            }

            int[] guesses = new int[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"\n{i + 1}. szám (1-10): ");
                string input = Console.ReadLine();
                int loteryNum;

                if (int.TryParse(input, out loteryNum))
                {
                    if (loteryNum <= 0 || loteryNum > 10)
                    {
                        Console.WriteLine($"Ez nem 1 és 10 között van te {RandomInsult()}");
                        i--;
                    }
                    else if (guesses.Count(s => s == loteryNum) == 0)
                    {
                        guesses[i] = loteryNum;
                    }
                    else
                    {
                        Console.WriteLine($"Ezt már tippelted te {RandomInsult()}");
                        i--;
                    }
                }
                else
                {
                    Console.WriteLine($"Ez nem szám te {RandomInsult()}");
                    i--;
                }
            }
            Console.WriteLine("\nA megadott számok:");
            int a = 0;
            foreach (var num in guesses)
            {
                a++;
                Console.WriteLine($"{a}. szám --> {num}");
            }

            Console.Write("\nSorsolás");
            string text = "...............";
            int delay = 300;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine("\nNyerőszámok:\n");
            Console.WriteLine(winNums[0]);
            Thread.Sleep(delay);
            Console.WriteLine(winNums[1]);
            Thread.Sleep(delay);
            Console.WriteLine($"{winNums[2]}\n");



            int count = 0;
            for (int i = 0; i < guesses.Length; i++)
            {
                if (winNums.Contains(guesses[i]))
                { 
                    count++;
                }
            }
            if (count >= 1) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{count} számot találtál el, nyertél {500 * count * 10}Ft-ot!");
                Console.ForegroundColor = ConsoleColor.White;
                Increase(0, 50, 500 * count * 10, player);
                Console.WriteLine("Vissza a boltba...");
                Console.ReadKey();
                SarkiBolt();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nem nyertél!");
                Console.ForegroundColor = ConsoleColor.White;
                Increase(0, - 30, 0, player);
                Console.WriteLine("Vissza a boltba...");
                Console.ReadKey();
                SarkiBolt();
            }
           
        }

        #endregion //sarkibolt

        static void EjfeliMise()
        {
            Time(player);
            Increase(0, 10, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Imádkozol", "Visszamész a faluközpontba" };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                options = new string[] { "Imádkozol", "Visszamész a faluközpontba", "Megbotránkoztatóan viselkedsz" };
                choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", "Morális korlátaidat felszámolta a magas véralkoholszinted.", "Mit teszel?", player, true, index, options);
            }
            else
            {
                choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", " ", "Mit teszel?", player, true, index, options);
            }
            switch (choice)
            {
                case 1:
                    DisplayEnd(true, "Templom", "Az éjféli mise után kijózanodtál, és megtérve hazaértél, túlélve az estét.");
                    break;
                case 2:
                    Falu();
                    break;
                case 3:
                    opponent = RandomPerson();
                    Console.WriteLine($"Erkölcsök hiányában {RandomScandal()}, és a papot {RandomInsult()}-nak/nek hívtad.\n");
                    int pickpocket = r.Next(0, 1501);
                    Thread.Sleep(5000);
                    Console.WriteLine($"Viselkedéseden {opponent} annyira megbotránkozott, hogy {RandomMoveOpponent()}.");
                    Thread.Sleep(500);
                    Console.WriteLine($"Válaszul {RandomMove()}");
                    Thread.Sleep(500);
                    Console.WriteLine($"\nAz örjöngő verekedés után mindketten földre kerültetek.");
                    Thread.Sleep(500);
                    Console.WriteLine($"Biológiai leleményességét, és a helyzetet kihasználva, egy goblin kivett a zsebedből {pickpocket} Ft-ot.");
                    Increase(0, -30, -pickpocket, player); //alkohol boldogság pénz
                    Thread.Sleep(1000);

                    Console.Write("\nMost kelsz fel");
                    string text = "...............";
                    int delay = 300;
                    foreach (char c in text)
                    {
                        Console.Write(c);
                        Thread.Sleep(delay);
                    }
                    Console.WriteLine("\nA rendőrség visszavisz a faluba....");
                    Console.ReadKey();
                    Falu();
                    break;
            }
        }

        #region haverok
        static void Haverok()
        {
            Time(player);
            if (allBeer < 3)
            {
                Increase(0, 3, 0, player); //alkohol boldogság pénz
            }
            else
            {
                allBeer -= 3;
                Increase(r.Next(30, 60) / 100.0, 15, 0, player); //alkohol boldogság pénz
            }
            string[] options = new string[] { "Isztok egy kört", "Viccesgombáztok", "Autókáztok egyet", "Visszamész a faluközpontba" };
            int choice;
            if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
            {
                options = new string[] { "Isztok egy kört", "Viccesgombáztok", "Autókáztok egyet", "Visszamész a faluközpontba", "Elmentek a templomba" };
                choice = Display("Haverod tanyája", $"Összeültél a 3 haveroddal inni.\n{beerCount} sört vittél, a többiekével együtt összesen {allBeer} sörötök van.", "Lehetőségetek van elmenni az éjféli misére", "Mit teszel?", player, true, index,options);
            }
            else
            {
                choice = Display("Haverod tanyája", $"Összeültél a 3 haveroddal inni.\n {beerCount} sört vittél, a többiekével együtt összesen {allBeer} sörötök van.", " ", "Mit tesztek?", player, true, index, options);
            }
            switch (choice)
            {
                case 1:
                    if (allBeer < 3)
                    {
                        Console.WriteLine("Nincs elég sör hármótoknak, ezért nem isztok.");
                        Console.ReadKey();
                        Haverok();
                    }
                    else
                    {
                        Haverok();
                    }
                    break;
                case 2:
                    VarazsGomba();
                    break;
                case 3:
                    //DrunkDriving();
                    break;
                case 4:
                    Falu();
                    break;
                case 5:
                    EjfeliMise();
                    break;
            }
        }
        #endregion //haverok

        #region falusikocsma
        static void FalusiKocsma()
        {

            Time(player);
            opponent = RandomPerson();
            int chance = r.Next(0, 100);
            Increase(r.Next(30, 60) / 100.0, 10, -700, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba" };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                alcPlusTime = true;
                options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", $"Duhajkodás" };
                choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat. ", "Mit teszel?", player, true, index, options);
                if(char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", "Duhajkodás", "Elmész az éjféli misére" };
                    choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat.\n\nLehetőséged van elmenni az éjféli misére.", "Mit teszel?", player, true, index, options);
                }
            }
            else
            {
                choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", " ", "Mit teszel?", player, true, index, options);
                if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", "Elmész az éjféli misére" };
                    choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "Lehetőséged van elmenni az éjféli misére.", "Mit teszel?", player, true, index, options);
                }
            }
            switch (choice)
            {
                case 1:
                    FalusiKocsma();
                    break;
                case 2:
                   // Darts();
                    break;
                case 3:
                    Falu();
                    break;

                case 4:
                    if(alcPlusTime)
                    {
                     Fight("faluba", "Dorozsmai határvégi borvirág kocsma");
                     Falu();
                    }
                    else
                    {
                        EjfeliMise();
                    }
                    break;

                case 5:
                    EjfeliMise();
                    break;
            }
        }

        static void Fight(string placeBack, string endPlace)
        {
            int chance = r.Next(0, 100);
            Console.WriteLine($"A kocsmában részegen {RandomScandal()}, és {opponent} -t {RandomInsult()}-nak/nek hívtad.\n");
            int pickpocket = r.Next(0, 1501);
            Thread.Sleep(5000);
            Console.WriteLine($"{opponent} a beszólásod hallatán {RandomMoveOpponent()}.");
            Console.WriteLine("Nyomj Entert a támadáshoz..");
            Console.ReadKey();
            Console.WriteLine($"Válaszul {RandomMove()}");
            Thread.Sleep(500);
            Console.WriteLine($"\nAz örjöngő verekedés után mindketten földre kerültetek.");
            Thread.Sleep(500);
            Console.WriteLine($"Biológiai leleményességét, és a helyzetet kihasználva, egy goblin kivett a zsebedből {pickpocket} Ft-ot.");
            Increase(0, -30, -pickpocket, player); //alkohol boldogság pénz
            Console.WriteLine("\nKelj fel");
            Console.ReadKey();
            if (chance <= 0)
            {
                DisplayEnd(false, $"{endPlace}", $"{opponent} annyira összevert, hogy belehaltál a sérüléseidbe.");
            }
            else
            {
                Console.Write("\nMost kelsz fel");
                string text = "...............";
                int delay = 300;
                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(delay);
                }

                pickpocket = r.Next(1, 1500);
                chance = r.Next(0, 100);
                string[] options = new string[] { "I", "N"};
                string userInput;
                Console.WriteLine("Kizsebeled? (I)/(N)");
                userInput = Console.ReadLine();

                while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                {
                    Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                    Console.WriteLine("Kizsebeled? (I)/(N)");
                    userInput = Console.ReadLine();
                }

                switch (userInput.ToLower())
                {
                    case "i":
                        Console.Write("\nÁtkutatod a zsebeit");
                        text = "...............";
                        delay = 300;
                        foreach (char c in text)
                        {
                            Console.Write(c);
                            Thread.Sleep(delay);
                        }
                        Console.WriteLine($"Találtál a zsebében {pickpocket} Ft-ot!");
                        Increase(0, 10, pickpocket, player);

                        Console.WriteLine("Elhagyod a helyszínt...");
                        Console.ReadKey();

                        if (chance <= 30)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("A rendőrség menekülés közben elkapott.");
                            Console.ReadKey();
                            DisplayEnd(false, placeBack, "Sajnos a részegséged miatt megcsúsztál egy banánhéjon a menekülés közben, ezért elfogott a rendőrség.");
                        }
                        else
                        {
                            Console.WriteLine($"Sikeresen visszamenekültél a {placeBack}");
                        }
                        break;

                    case "n":
                        Console.WriteLine("Úgy döntöttél nem zsebeled ki.");
                        Console.WriteLine($"\nA rendőrség megérkezett a helyszínre, és visszavisz a {placeBack}....");
                    break;

                    default:
                    Console.WriteLine("Ez nem");
                    break;
                }

            
                Console.ReadKey();
            }
        }

        //static void Darts()
        //{
        //    Increase(0, 0, 0, player); //alkohol boldogság pénz
        //    string[] options = new string[] { "Játék", "Vissza a pulthoz",};
        //    int choice = Display("Égő Fekete János asztal", "A baljós BlackJack asztalnál vagy", " ", "Mit teszel?", player, timeStopped, index, options);

        //    switch (choice)
        //    {
        //        case 1:
        //            //int bet;
        //            break;
        //        case 2:
        //            //BlackJack();
        //            break;
        //        case 3:
        //            Falu();
        //            break;
        //        case 4:
        //            Fight();
        //            break;
        //    }
        //}

        #endregion//falusi kocsma





        #endregion //falu

        #region kulfold
        public static void Kulfold()
        {
            string[] options = new string[] { "Csehország", "Szlovákia", "Szerbia" };
            int choice = Display("Legendás hármashatár", "Eljutottál a hármas határig.", " ", "Melyik országba folytatod utadat?", player, timeStopped, index, options);
            switch (choice)
            {
                case 1:
                    Csehorszag();
                    break;
                case 2:
                    //Szlovakia();
                    break;
                case 3:
                    //Szerbia();
                    break;
            }
        }

        public static void Csehorszag()
        {
            string[] options = new string[] { "Betérsz a \"hořící kostra\" sörözőbe", "FUVEZES????",};
            int choice = Display("Prága", "Végigmentél az E50-es autópályán egészen Prágáig, és leparkoltál párhuzamosan.", " ", "Mit teszel?", player, timeStopped, index, options);
            switch (choice)
            {
                case 1:
                    CsehSorozo();
                    break;
                case 2:
                    //Brownie();
                    break;
                case 3:
                    //Hajlektalan();
                    break;
            }
        }
        public static void CsehSorozo()
        {
            opponent = RandomPerson();
            Increase(r.Next(30, 60) / 100.0, 10, -1000, player); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Vissza a városba", };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                options = new string[] { "Ivás", "Vissza a városba", "Duhajkodás" };
                choice = Display("Hořící kostra söröző", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat.", "A magas véralkoholszinted felszámolta az összes morális és etikai korlátodat.", "Mit teszel?", player, timeStopped, index, options);
            }
            else
            {
                choice = Display("Hořící kostra söröző", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat. Nem láttad a forrását a sűrű füsttől.", " ", "Mit teszel?", player, timeStopped, index, options);
            }
            switch (choice)
            {
                case 1:
                    CsehSorozo();
                    break;
                case 2:
                    Csehorszag();
                    break;
                case 3:
                    Fight("városba", "Hořící kostra söröző");
                    CsehSorozo();
                    break;
            }
        }

        #endregion //kulfold


        //document pont áőáőáőőáőőáőáő

    }
}