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
        private static Random r = new Random();
        private static int index = 1;
        private static int allBeer = r.Next(6, 31);
        private static int beerCount = 0;
        private static int badCount = 0;
        private static int goodCount = 0;
        private static string opponent;
        private static bool timeStopped = false;
        private static bool boughtBeer = false;
        private static bool alcPlusTime = false;
        private static bool beatenByFather = false;
        private static bool beatenByMother = false;
        private static bool requested = false;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Otthon();
        }

        #region otthon
        public static void Otthon()
        {
            string[] options = new string[] { "Kérsz valakitől egy kis pénzt", "Iszol egyet", "Útnak indulsz" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "Fájó fejjel kelsz fel egy fura középkorban játszódó álom után, úgy érzed, mintha 2000 évet időutaztál volna, ezért úgy döntesz, hogy berúgsz.", " ", "Hogyan készülsz fel az éjszakára indulás előtt?", player, index, 0, options);
            switch (choice)
            {
                case 1:
                    PenzKeres();
                    break;
                case 2:
                    IvasOtthon();
                    break;
                case 3:
                    Start();
                    break;
            }

        }

        public static void PenzKeres()
        {
            BadWords();
            GoodWords();
            string[] options = new string[] { "Apádtól", "Anyádtól", "Mamádtól", "Kutyádtól", "Iszol inkább", "Mész az utadra" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "Kevésnek érzed a jelenlegi pénzed, ezért az egyik családtagodtól kérsz.", " ", "Kitől szeretnél kunyerálni?", player, index, 0, options);
            switch (choice)
            {
                case 1:
                    if (beatenByFather)
                    {
                        Console.WriteLine("Apád még mindig mérges az előbbi incidens után, ezért inkább kétszer meggondolod, és megfordulsz.");
                        Console.ReadKey();
                        PenzKeres();
                    }
                    if (requested)
                    {
                        Console.WriteLine("Már kértél az egyik családtagodtól pénzt, ezért nem kaspz többet.");
                        Console.ReadKey();
                        PenzKeres();
                    }
                    int request;
                    Console.WriteLine($"{RandomRoom()} apukád éppen {RandomAction()}. Mennyi pénzt szeretnél kérni tőle?");
                    string money = Console.ReadLine();

                    while(!(int.TryParse(money, out request))){
                        Console.WriteLine($"Ez nem egy összeg, te {RandomInsult()}\n");
                        Console.WriteLine("Mennyi pénzt szeretnél kérni tőle?");
                        money = Console.ReadLine();

                    }
                    if (int.TryParse(money, out request))
                    {
                        Console.WriteLine("Mit fogsz mondani neki?");
                        string[] badWords = BadWords();
                        string[] goodWords = GoodWords();
                        string input = Console.ReadLine().ToLower();


                        foreach (string badWord in badWords)
                        {
                            if (input.Contains(badWord))
                            {
                                badCount++;
                            }
                        }

                        foreach (string goodWord in goodWords)
                        {
                            if (input.Contains(goodWord))
                            {
                                goodCount++;
                            }
                        }

                        int finalMoney = request + (goodCount * 500) - (badCount * 2000);

                        if (request <= 20000)
                        {
                            if (badCount == 0)
                            {
                                Console.WriteLine($"Szépen beszéltél apukáddal, ezért minden kedves szavadért hozzárakott egy 500-ast a kért összeghez..");
                                Console.WriteLine($"{finalMoney} Ft-ot adott, és csajozási tanácsokat.");
                                Increase(0, 15, finalMoney, player);
                            }
                            else if(badCount > 0 || badCount <= 3)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél apáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 2000Ft-ot, a kedvesekért pedig hozzátett 500-at.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                Increase(0, 10, finalMoney, player);
                            }
                            else
                            {
                                Console.WriteLine("Apád egy hasított bőr övvel 23 alkalommal hátonvágott, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0, player);
                                beatenByFather = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél apádtól, ezért egy hasított bőr övvel 23 alkalommal hátonvágott.");
                            Increase(0, -30, 0, player);
                            beatenByFather = true;
                        }

                        requested = true;


                        Console.ReadKey();
                        PenzKeres();
                    }
                    break;
                case 2:
                    if (beatenByMother)
                    {
                        Console.WriteLine("Anyukád még mindig mérges az előbbi incidens után, ezért inkább kétszer meggondolod, és megfordulsz.");
                        Console.ReadKey();
                        PenzKeres();
                    }
                    if (requested)
                    {
                        Console.WriteLine("Már kértél az egyik családtagodtól pénzt, ezért nem kaspz többet.");
                        Console.ReadKey();
                        PenzKeres();
                    }

                    Console.WriteLine($"{RandomRoom()} anyukád éppen {RandomAction()}. Mennyi pénzt szeretnél kérni tőle?");
                    money = Console.ReadLine();

                    while (!(int.TryParse(money, out request)))
                    {
                        Console.WriteLine($"Ez nem egy összeg, te {RandomInsult()}\n");
                        Console.WriteLine("Mennyi pénzt szeretnél kérni tőle?");
                        money = Console.ReadLine();

                    }
                    if (int.TryParse(money, out request))
                    {
                        Console.WriteLine("Mit fogsz mondani neki?");
                        string[] badWords = BadWords();
                        string[] goodWords = GoodWords();
                        string input = Console.ReadLine().ToLower();


                        foreach (string badWord in badWords)
                        {
                            if (input.Contains(badWord))
                            {
                                badCount++;
                            }
                        }

                        foreach (string goodWord in goodWords)
                        {
                            if (input.Contains(goodWord))
                            {
                                goodCount++;
                            }
                        }

                        int finalMoney = request + (goodCount * 1500) - (badCount * 1000);

                        if (request <= 10000)
                        {
                            if (badCount == 0)
                            {
                                Console.WriteLine($"Szépen beszéltél apunyukáddal, ezért minden kedves szavadért hozzárakott 1500 Ft-ot a kért összeghez.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott, és kérte, hogy vigyázz magadra..");
                                Increase(0, 15, finalMoney, player);
                            }
                            else if (badCount > 0 || badCount <= 4)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél anyukáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 1000Ft-ot, a kedvesekért pedig hozzátett 1500-at.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                Increase(0, 10, finalMoney, player);
                            }
                            else
                            {
                                Console.WriteLine("Édesanyád egy serpenyőt elhajlított a hátadon, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0, player);
                                beatenByMother = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél anyukádtól, ezért egy serpenyőt elhajlított a hátadon.");
                            Increase(0, -30, 0, player);
                            beatenByMother = true;
                        }

                        requested = true;
                        Console.ReadKey();
                        PenzKeres();
                    }
                    break;
                case 3:
                    if (requested)
                    {
                        Console.WriteLine("Már kértél az egyik családtagodtól pénzt, ezért nem kaspz többet.");
                        Console.ReadKey();
                        PenzKeres();
                    }

                    Console.WriteLine($"{RandomRoom()} mamád éppen {RandomAction()}. Mennyi pénzt szeretnél kérni tőle?");
                    money = Console.ReadLine();

                    while (!(int.TryParse(money, out request)))
                    {
                        Console.WriteLine($"Ez nem egy összeg, te {RandomInsult()}\n");
                        Console.WriteLine("Mennyi pénzt szeretnél kérni tőle?");
                        money = Console.ReadLine();

                    }
                    if (int.TryParse(money, out request))
                    {
                        Console.WriteLine("Mit fogsz mondani neki?");
                        string[] badWords = BadWords();
                        string[] goodWords = GoodWords();
                        string input = Console.ReadLine().ToLower();


                        foreach (string badWord in badWords)
                        {
                            if (input.Contains(badWord))
                            {
                                badCount++;
                            }
                        }

                        foreach (string goodWord in goodWords)
                        {
                            if (input.Contains(goodWord))
                            {
                                goodCount++;
                            }
                        }

                        int finalMoney = request + (goodCount * 200) - (badCount * 1000);

                        if (request <= 100000)
                        {
                            if (badCount == 0)
                            {
                                Console.WriteLine($"Szépen beszéltél a mamáddal, ezért minden kedves szavadért hozzárakott 2000 Ft-ot a kért összeghez.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott, és egy kekszet.");
                                Increase(0, 15, finalMoney, player);
                            }
                            else if (badCount > 0 || badCount <= 4)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél a mamáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 1000Ft-ot, a kedvesekért pedig hozzátett 2000-et.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                Increase(0, 10, finalMoney, player);
                            }
                            else
                            {
                                Console.WriteLine("Mamád előhúzta a botjába rejtett titkos kardot, és átszúrta a mellkasodon, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0, player);
                                Console.ReadKey();
                                DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", "Elvéreztél miután leszúrt a mamád, ezután eltüntette a családod a bizonyítékokat, és elástak a kertbe.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél a mamádtól, ezért előhúzta a botjába rejtett titkos kardot, és átszúrta a mellkasodon.");
                            Increase(0, -30, 0, player);
                            Console.ReadKey();
                            DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", "Elvéreztél miután leszúrt a mamád, ezután eltüntette a családod a bizonyítékokat, és elástak a kertbe.");
                        }
                        requested = true;
                        Console.ReadKey();
                        PenzKeres();
                    }
                    break;

                case 4:
                    Console.WriteLine("Ezt te sem gondoltad komolyan, ugye?");
                    Console.ReadKey();
                    PenzKeres();
                    break;
                case 5:
                    IvasOtthon();
                    break;
                case 6:
                    Start();
                    break;
            }
        }

        public static void IvasOtthon()
        {
            int chance = r.Next(0, 100);
            string[] options = new string[] { "Sör", "Bor", "Vodka", "\"Vegyes házi 2006\" feliratú átlátszó folyadék műanyagpalackban", "Etil alkohol", "Fagyálló", "Útnak indulsz" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "A hűtőt kinyitva szinte már el sem tudod dönteni mit igyál.", " ", "Mit választasz?", player, index, 0, options);
            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 50) / 100.0, 5, 0, player);
                    IvasOtthon();
                    break;
                case 2:
                    Increase(r.Next(50, 70) / 100.0, 5, 0, player);
                    IvasOtthon();
                    break;
                case 3:
                    Increase(r.Next(80, 110) / 100.0, 5, 0, player);
                    IvasOtthon();
                    break;
                case 4:
                    Increase(r.Next(0, 200) / 100.0, 5, 0, player);
                    IvasOtthon();
                    break;
                case 5:
                    Increase(r.Next(110, 180) / 100.0, 5, 0, player);
                    IvasOtthon();
                    break;
                case 6:
                    DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", $"Megittad a fagyállót, te {RandomInsult()}");
                    break;
                case 7:
                    Start();
                    break;
            }

        }

        public static void Start()
        {
            string[] options = new string[] { "Busz", "Autó", "Bicikli" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "Úgy döntöttél elindulsz már, mert nem érünk rá egész nap.", " ", "Milyen járművel kezded meg utadat?", player, index, 1, options);
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

        #endregion //otthon

        static void Busz()
        {
            Increase(0, -10, -300, player);
            string[] options = new string[] { "Város", "Falu" };
            int choice = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", " ", "Hová mész tovább?", player, index, 1, options);

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
            int choice = Display("Garázs", "Úgy döntöttél autóval indulsz útnak.", " ", "Hová mész tovább?", player, index, 1, options);

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
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", " ", "Hová mész tovább?", player, index, 1, options);

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
            int choice = Display("Putri Pályaudvar", "A Putri Pályaudvaron vagy.", " ", "Hová mész tovább?", player, index, 1, options);

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
            string[] options = new string[] { "Ivás", "Az \"éj hölgye\" ", "Vissza a városba" };
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba", "Odamész ahhoz az aranyos lányhoz" };
                choice = Display($"Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Megláttál egy aranyos lányt.", "Mit teszel?", player, index, 1, options);
            }
            else
            {
                choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", " ", "Mit teszel?", player, index, 1, options);
            }
            switch (choice)
            {
                case 1:
                    if (chance <= 10)
                    {
                        VarazsGomba();
                    }
                    Increase(r.Next(30, 60) / 100.0, 10, -1190, player); //alkohol boldogság pénz
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
                choice = Display($"Cigiszagú panel", "Felvitt a fizetős \"hölgy\" a paneljébe.", "Nagyobb neki, mint neked.", "Mit teszel?", player, index, 1, options);
            }
            else
            {
                choice = Display("Cigiszagú panel", "Felvitt egy cigiszagú panelbe, ahol 3 férfi fehér csíkokat szív az asztalról.", " ", "Mit teszel?", player, index, 1, options);
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
           choice = Display("Happy Hours Nightclub", "Beszélgettél a lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", player, index, 1, options);
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
            string[] options = new string[] { "Ivás", "Fej vagy írás", "Vissza a városba" };
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy.", " ", "Mit teszel?", player, index, 1, options);

            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 60) / 100.0, 10, -800, player); //alkohol boldogság pénz
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
            int choice = Display("Vörös Farkas Pub", $"{opponent} vállalta a \"Fej Vagy Írás\" kihívásod.", " ", "Mi a következő lépésed?", player, index, 0, options);

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
            string[] options = new string[] { "Veszel egy sört", "Vissza a városba" };
            int choice;
            if (chance <= 70)
            {
                options = new string[] { "Veszel egy sört", "Vissza a városba", "Odamész az alter lányhoz" };
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", "Megpillantasz egy alter lányt, ahogy éppen a Jagermaisterért nyúl.", "Mit teszel?", player, index, 1, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", " ", "Mit teszel?", player, index, 1, options);
            }

            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 60) / 100.0, 10, -300, player); //alkohol boldogság pénz
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
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", $"A zsebében ott lapul {r.Next(3,11)} gramm varázsgomba", "Mit teszel?", player, index, 1, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", " ", "Mit teszel?", player, index, 1, options);
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
                choice = Display("Dorozsmai faluközpont", "A 20km-es főútat végigszenvedve a faluközpontba jutsz.", $"Egy {drinkMan} \"vegyes házit\" kínál.", "Hová mész tovább?", player, index, 0, options);
            }
            else
            {
                choice = Display("Dorozsmai faluközpont", "A 20km-es főútat végigszenvedve a faluközpontba jutsz.", " ", "Hová mész tovább?", player, index, 0, options);
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
            Time(1, player);
            string[] options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba" };
            int choice;
            if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
            {
                options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba", "Elmész a templomba" };
                choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", "Lehetőságed van elmenni az éjféli misére", "Mit teszel?", player, index, 1, options);       
            }
            else
            {
                choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", " ", "Mit teszel?", player, index, 1, options);
            }
            switch (choice)
            {
                case 1:
                    boughtBeer = true;
                    beerCount++;
                    allBeer++;
                    Increase(0, 1, -500, player); //alkohol boldogság pénz
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
                int lotteryNum;

                if (int.TryParse(input, out lotteryNum))
                {
                    if (lotteryNum <= 0 || lotteryNum > 10)
                    {
                        Console.WriteLine($"Ez nem 1 és 10 között van te {RandomInsult()}");
                        i--;
                    }
                    else if (guesses.Count(s => s == lotteryNum) == 0)
                    {
                        guesses[i] = lotteryNum;
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
                Console.WriteLine($"{count} számot találtál el, nyertél {5000 * count }Ft-ot!");
                Console.ForegroundColor = ConsoleColor.White;
                Increase(0, 50, 5000 * count, player);
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
            Time(1, player);
            Increase(0, 10, 0, player); //alkohol boldogság pénz
            string[] options = new string[] { "Imádkozol", "Visszamész a faluközpontba" };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                options = new string[] { "Imádkozol", "Visszamész a faluközpontba", "Megbotránkoztatóan viselkedsz" };
                choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", "Morális korlátaidat felszámolta a magas véralkoholszinted.", "Mit teszel?", player, index, 0, options);
            }
            else
            {
                choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", " ", "Mit teszel?", player, index, 0, options);
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
            Time(1, player);
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
                choice = Display("Haverod tanyája", $"Összeültél a 3 haveroddal inni.\n{beerCount} sört vittél, a többiekével együtt összesen {allBeer} sörötök van.", "Lehetőségetek van elmenni az éjféli misére", "Mit teszel?", player, index, 0, options);
            }
            else
            {
                choice = Display("Haverod tanyája", $"Összeültél a 3 haveroddal inni.\n {beerCount} sört vittél, a többiekével együtt összesen {allBeer} sörötök van.", " ", "Mit tesztek?", player, index, 0, options);
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

            Time(1, player);
            opponent = RandomPerson();
            int chance = r.Next(0, 100);

            string[] options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba" };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                alcPlusTime = true;
                options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", $"Duhajkodás" };
                choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat. ", "Mit teszel?", player, index, 0, options);
                if(char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", "Duhajkodás", "Elmész az éjféli misére" };
                    choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat.\n\nLehetőséged van elmenni az éjféli misére.", "Mit teszel?", player, index, 0, options);
                }
            }
            else
            {
                choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", " ", "Mit teszel?", player, index, 0, options);
                if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Ivás", "Darts", "Vissza a faluközpontba", "Elmész az éjféli misére" };
                    choice = Display("Dorozsmai határvégi borvirág kocsma", "Valahogyan eljutottál a határvégi kocsmához", "Lehetőséged van elmenni az éjféli misére.", "Mit teszel?", player, index, 0, options);
                }
            }
            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 60) / 100.0, 10, -700, player); //alkohol boldogság pénz
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
            if (chance <= 60)
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
        //    int choice = Display("Égő Fekete János asztal", "A baljós BlackJack asztalnál vagy", " ", "Mit teszel?", player, index, 1, options);

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
            int choice = Display("Legendás hármashatár", "Eljutottál a hármas határig.", " ", "Melyik országba folytatod utadat?", player, index, 1, options);
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
            int choice = Display("Prága", "Végigmentél az E50-es autópályán egészen Prágáig, és leparkoltál párhuzamosan.", " ", "Mit teszel?", player, index, 1, options);
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
                choice = Display("Hořící kostra söröző", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat.", "A magas véralkoholszinted felszámolta az összes morális és etikai korlátodat.", "Mit teszel?", player, index, 1, options);
            }
            else
            {
                choice = Display("Hořící kostra söröző", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat. Nem láttad a forrását a sűrű füsttől.", " ", "Mit teszel?", player, index, 1, options);
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