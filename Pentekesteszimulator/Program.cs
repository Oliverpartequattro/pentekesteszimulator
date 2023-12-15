using System.ComponentModel.DataAnnotations;
using System.Numerics;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Reflection;
using System;

namespace Pentekesteszimulator
{

    //nem kibelezett class
    internal partial class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(Console.LargestWindowWidth - 4, Console.LargestWindowHeight - 4);
#pragma warning restore CA1416 // Validate platform compatibility

#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowPosition(0, 0);
#pragma warning restore CA1416 // Validate platform compatibility

            credits(40);
            //Otthon("Egy 18 éves Jedlikes diák vagy. Rettentően másnaposan ébredsz fel, ezen a felhős péntek délutánon úgy érzed, mintha egy ősapád 2000 év távlatából szólna hozzád, hogy egy speciális képességgel áldottak meg:\nA CSALÁDFÁD ALKOHOLISTÁINAK EREJE FOLYIK A VÉREDBEN!\n\nÚgy érzed, egyetlen célod van: LEGYÉL GYŐRZÁMOLY LEGHÍRHEDTEBB ALKOHOLISTÁJA!");

        }

        #region otthon
        public static void Otthon(string desc)
        {
            string[] options = new string[] { "Kérsz valakitől egy kis pénzt", "Iszol egyet", "Útnak indulsz" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", $"{desc}", " ", "Hogyan készülsz fel az éjszakára indulás előtt?", player, index, 0, options);
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

        } //otthon fv kell parameter hogy a hutotol vissza lehessen menni   

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
                        if (finalMoney < 0)
                        {
                            finalMoney = 0;
                        }

                        if (request <= 20000)
                        {
                            if (badCount == 0)
                            {
                                Console.WriteLine($"Szépen beszéltél apukáddal, ezért minden kedves szavadért hozzárakott egy 500-ast a kért összeghez..");
                                Console.WriteLine($"{finalMoney} Ft-ot adott, és csajozási tanácsokat.");
                                Increase(0, 15, finalMoney);
                            }
                            else if(badCount > 0 || badCount <= 3)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél apáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 2000Ft-ot, a kedvesekért pedig hozzátett 500-at.");
                                
                                if (finalMoney == 0)
                                {
                                    Console.WriteLine($"Nem adott semmit mert azt modtad neki hogy \"{input}\".");
                                }
                                else
                                {
                                    Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                }

                                Increase(0, 10, finalMoney);
                            }
                            else
                            {
                                Console.WriteLine("Apád egy hasított bőr övvel 23 alkalommal hátonvágott, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0);
                                beatenByFather = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél apádtól, ezért egy hasított bőr övvel 23 alkalommal hátonvágott.");
                            Increase(0, -30, 0);
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
                                Console.WriteLine($"Szépen beszéltél anyukáddal, ezért minden kedves szavadért hozzárakott 1500 Ft-ot a kért összeghez.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott, és kérte, hogy vigyázz magadra..");
                                Increase(0, 15, finalMoney);
                            }
                            else if (badCount > 0 || badCount <= 4)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél anyukáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 1000Ft-ot, a kedvesekért pedig hozzátett 1500-at.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                Increase(0, 10, finalMoney);
                            }
                            else
                            {
                                Console.WriteLine("Édesanyád egy serpenyőt elhajlított a hátadon, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0);
                                beatenByMother = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél anyukádtól, ezért egy serpenyőt elhajlított a hátadon.");
                            Increase(0, -30, 0);
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
                                Increase(0, 15, finalMoney);
                            }
                            else if (badCount > 0 || badCount <= 4)
                            {
                                Console.WriteLine("Elfogadhatóan beszéltél a mamáddal, ezért még megadta a kért összeget, de minden csúnya szóért levont 1000Ft-ot, a kedvesekért pedig hozzátett 2000-et.");
                                Console.WriteLine($"{finalMoney} Ft-ot adott neked.");
                                Increase(0, 10, finalMoney);
                            }
                            else
                            {
                                Console.WriteLine("Mamád előhúzta a botjába rejtett titkos kardot, és átszúrta a mellkasodon, mert csúnyán beszéltél vele.");
                                Increase(0, -30, 0);
                                Console.ReadKey();
                                DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", "Elvéreztél miután leszúrt a mamád, ezután eltüntette a családod a bizonyítékokat, és elástak a kertbe.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Túl sok pénzt kértél a mamádtól, ezért előhúzta a botjába rejtett titkos kardot, és átszúrta a mellkasodon.");
                            Increase(0, -30, 0);
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
            int chance = r.Next(0, 101);
            string[] options = new string[] { "Sör", "Bor", "Vodka", "\"Vegyes házi 2006\" feliratú átlátszó folyadék műanyagpalackban", "Etil alkohol", "Fagyálló", "Visszamész a szobádba", "Útnak indulsz" };
            int choice = Display("Győrzámoly, Szerencse utca 22/B", "A hűtőt kinyitva szinte már el sem tudod dönteni mit igyál.", " ", "Mit választasz?", player, index, 0, options);
            

            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 50) / 100.0, 5, 0);
                    beersInRow++;

                    if (beersInRow > 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Most ittad meg az {beersInRow}-ödik sörödet egy huzamban. Ennek következtében összehugyoztad magad. Gyorsan gatyát cserélsz és úgy döntesz hogy útnak indulsz.\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        beersInRow = 0;

                        Console.ReadKey(true);
                        Start();
                        break;
                    }
                    IvasOtthon();
                    break;
                case 2:
                    Increase(r.Next(50, 70) / 100.0, 5, 0);
                    IvasOtthon();
                    break;
                case 3:
                    Increase(r.Next(80, 110) / 100.0, 5, 0);
                    IvasOtthon();
                    break;
                case 4:
                    if (metil)
                    {
                        DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", "A \"Vegyes házi 2006\" feliratú átlátszó folyadék műanyagpalack metil alkoholt tartalmazott ezért megvakultál.", ConsoleColor.DarkGray);
                        break;
                    }
                    else
                    {
                        Increase(r.Next(0, 200) / 100.0, 5, 0);
                        IvasOtthon();
                        break;
                    }
                case 5:
                    Increase(r.Next(110, 180) / 100.0, 5, 0);
                    IvasOtthon();
                    break;
                case 6:
                    DisplayEnd(false, "Győrzámoly, Szerencse utca 22/B", $"Megittad a fagyállót, ezért leálltak a veséid, te {RandomInsult()}");
                    break;
                case 7:
                    Otthon("Visszamentél a hűtőtöl a szobádba.");
                    break;
                case 8:
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
                    Auto("Úgy döntöttél, autóval indulsz útnak.");
                    break;
                case 3:
                    Bicikli();
                    break;
            }

        }

        #endregion //otthon

        static void Busz()
        {
            Increase(0, -10, -300);
            string[] options = new string[] { "Város", "Falu" }; //öɹɹéj
            int choice = Display("Buszmegálló", "Úgy döntöttél busszal indulsz útnak.", " ", "Hová mész tovább?", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    Varos("Egy szakadt Icarus elvitt egészen a Putri Pályaudvarig.");
                    break;
                case 2:
                    Falu("Felszálltál az egyetlen szakadt Icarusra, ami elvisz Dorozsmába.");
                    break;
            }
        }

        #region auto - rendorseg
        static void Auto(string desc)
        {
            bool szonda = false;
            int chance = r.Next(0, 101);
            Increase(0, 0, -300);
            string[] options = new string[] { "Város", "Falu", "Elhagyod az országot" };
            int choice;
            if(chance <= 30)
            {
                szonda = true;
                options = new string[] { "Lepadlózod", "Félrehúzódsz"};
                choice = Display("2002 Opel Astra G", "Beugrottál a kocsidba, és útnak indultál.", $"A mögötted levő fekete A6-os Audi felkapcsolta a kék villogóit.", $"{RandomQuestion()}", player, index, 0, options);
            }
            else
            {
                choice = Display("2002 Opel Astra G", $"{desc}", " ", "Hová mész tovább?", player, index, 1, options);
            }

            switch (choice)
            {
                case 1:
                    if(szonda == true)
                    {
                        int escapeChance = r.Next(0, 101);
                        int randomPlace = r.Next(0, 3);
                        if (escapeChance <= 60)
                        {
                            Console.WriteLine("Sikeresen elmenekültél a rendőr elől, de sajnos fogalmad sem volt merre mentél, ezért kénytelen vagy a péntek estédet a célállomáson tölteni.\nKiszállás...");
                            Console.ReadKey();
                            if (randomPlace == 0)
                            {
                                Varos("A városi pályaudvaron kötöttél ki.");
                            }
                            else if (randomPlace == 1)
                            {
                                Falu("Dorozsmába jutottál."); //erre a 3ra pl kell parameter fix
                            }
                            else
                            {
                                Kulfold("Valahogyan a Legendás Hármashatáron kötöttél ki.");
                            }
                        }
                        else
                        {
                            DisplayEnd(false, "Főút", "Túl gyenge sofőrnek bizonyultál, ezért a rendőr megfogott téged");
                        }
                    }
                    else
                    {
                        Varos("Elautókáztál a pályaudvarig, majd leparkoltál.");
                    }

                    break;
                case 2:
                    if(szonda  == true)
                    {
                        Igazoltatas();
                    }
                    Falu("Elautokáztál egészen Dorozsmáig, végigmentél a 20km-es főúton, majd megálltál elakadásjelzővel az út szélén, és elhagytad a járműved.");
                    break;
                case 3:
                    Kulfold("Elautókáztál a Legendás Hármas Határig.");
                    break;
            }
        }

        public static void Igazoltatas()
        {
            string[] options = new string[] { "Lehúzod az ablakot", "Padlógázzal továbbhajtasz"};
            int choice;
            if(player.Alcohol > 0.0)
            {
                bloodAlc = true;
                choice = Display("Főút", "Félreállítottak közúti igazoltatásra, csak remélni tudod, hogy nincs nála szonda.", "Tisztában vagy azzal, hogy ittál indulás előtt.\nMég van esélyed elmenekülni.", $"{RandomQuestion()}", player, index, 0, options);
            }
            else
            {
                choice = Display("Főút", "Félreállítottak közúti igazoltatásra. Szerencsére nem ittál még, ezért viszonylag biztonságban vagy..", " ", $"{RandomQuestion()}", player, index, 0, options);
            }
            switch (choice)
            {
                case 1:
                    Szondaztatas();
                    break;
                case 2:
                    QuickTime();
                    break;
            }
        }

        public static void Szondaztatas()
        {
            string[] options = new string[] { "Belefújsz", "Lefizeted" };
            int choice = Display("Út széle", "Kiszáll a rendőr az autójából, benyújt egy szondát az ablakodon, majd kéri, hogy fújd meg.", " ", $"{RandomQuestion()}", player, index, 0, options);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nFújod");
                    string text = "...............";
                    int delay = 300;
                    foreach (char c in text)
                    {
                        Console.Write(c);
                        Thread.Sleep(delay);
                    }
                    if (bloodAlc)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nA szonda {Math.Round(player.Alcohol, 2)}-t mutatott.");
                        Console.ReadKey();
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayEnd(false, "Szegedi csillagbörtön", $"Sajnos a rendőr nem nézte el a részeg vezetésedet.\nPontosabb vizsgálat után bizonyította tagságodat több terrorszervezetben,\nezért helyszíni halálbüntetést szabott ki.\nKivégzés ideje: {r.Next(2023, 2027)}.{r.Next(0, 13)}.{r.Next(1, 28)}");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nA szonda {player.Alcohol}-t mutatott.");
                    Console.WriteLine("A rendőr eltette a szondát, és jó utat kívánt.");
                    Console.ReadKey();
                    Console.ForegroundColor = ConsoleColor.White;
                    Auto("A rendőrrel lévő találkozás enyhén megrázott, de most megúsztad..."); //PARAMETER AAAAAAAA
                    break;
                case 2:
                    int bribe;
                    Console.WriteLine($"Mennyi az annyi?");
                    string money = Console.ReadLine();

                    while (!(int.TryParse(money, out bribe)))
                    {
                        Console.WriteLine($"Ez nem egy összeg, te {RandomInsult()}\n");
                        Console.WriteLine("Mennyi az annyi?");
                        money = Console.ReadLine();
                    }

                    if(bribe > r.Next(28000, 35000))
                    {
                        Increase(0, 0, -bribe);
                        Console.WriteLine("A rendőr elrakta a zsebébe a szondát, és jó utat kívánt.");
                        Console.ReadKey();
                        Auto("A rendőr elfogadta a kenőpénzt, becsukta a szemét és elengedett."); //IDE IS KELL PARAMETER
                    }
                    else
                    {
                        DisplayEnd(false, "Út széle", "A rendőr kinevette a gyenge kísérletedet a korrupcióra, kirángatott a kocsiból, rávágott a motorháztetődre, majd megbilincselt.");
                    }
                    

                    Console.ReadKey();
                    break;
            }
        }

        public static void QuickTime()
        {
            var countdownThread = new Thread(() => Countdown(5));

            countdownThread.Start();

            string[] options = new string[] { "Város", "Falu", "Elhagyod az országot" };
            int choice = Display("Út széle", $"GYORSAN!! 5 másodperced van eldönteni, hová menekülsz!", " ", "HOVA MÉSZ?!?!?!?!", player, index, 1, options);

            stopCountdown = true;

            switch (choice)
            {
                case 1:
                    Varos("Sikeresen elmenekültél egészen a Putri Pályaudvarig, majd leparkoltál.");
                    break;
                case 2:
                    Falu("Elmenekültél Dorozsma kicsiny falváig"); //ide is kell parameter
                    break;
                case 3:
                    Kulfold("Úgy döntöttél, külföldre menekülsz.\nA Legendás Hármas Határnál vagy.");
                    break;
            }
        }

        public static void Countdown(int seconds)
        {
            for (int i = seconds; i > -2; i--)
            {
                if (stopCountdown)
                {
                    break;
                }

                if(i > -1)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
                else
                {
                    
                    DisplayEnd(false, "Út széle", "Túl lassú volt a reakcióidőd, ezért odaért a rendőr a kocsidhoz.\nTelepátiával megfejtette, hogy el akartál menekülni, ezért kirángatott a kocsidból, és letartóztatott.");
                    Environment.Exit(0);
                }
            }
        }

        #endregion //auto - rendorseg
        static void Bicikli()
        {
            Increase(0, 2, 0);
            string[] options = new string[] { "Falu" };
            int choice = Display("Bicikli tároló", "Úgy döntöttél biciklivel indulsz útnak.", " ", "Hová mész tovább?", player, index, 1, options);

            switch (choice)
            {
                case 1:
                    Falu("Eltekertél a főút végéből egészen a faluközpontig.");
                    break;
            }
        }

        #region varos
        static void Varos(string desc)
        {
            Increase(0, 2, 0);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", $"{desc}", " ", "Hová mész tovább?", player, index, 1, options);

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
            int chance = r.Next(0, 101);
            string[] options = new string[] { "Ivás", "Az \"éj hölgye\" ", "Vissza a városba" };
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Ivás", "Az \"éj hölgye\"", "Vissza a városba", "Odamész ahhoz az aranyos lányhoz" };
                choice = Display($"Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", "Megláttál egy aranyos lányt.", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Happy Hours Nightclub", "Beléptél a szórakozóhelyre.", " ", $"{RandomQuestion()}", player, index, 1, options);
            }
            switch (choice)
            {
                case 1:
                    if (chance <= 10)
                    {
                        VarazsGomba();
                    }
                    Increase(r.Next(30, 60) / 100.0, 10, -1190); //alkohol boldogság pénz
                    Szorakozohely();
                    break;
                case 2:
                    EjHolgye();
                    break;
                case 3:
                    Varos("A szórakozóhelyből kisétálva a városba jutottál.");
                    break;
                case 4:
                    IngyenesNeni();
                    break;
            }
        }

        static void EjHolgye()
        {
            int chance = r.Next(0, 101);
            Increase(0, 30, -10000); //alkohol boldogság pénz
            string[] options = new string[]{ "Megmutatom neki a Fortnite Battle Passomat.",};
            int choice;
            if (chance <= 40)
            {
                options = new string[] { "Felül leszek", "Alul leszek", "Elmenekülök", };
                choice = Display($"Cigiszagú panel", "Felvitt a fizetős \"hölgy\" a paneljébe.", "Nagyobb neki, mint neked.", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Cigiszagú panel", $"Felvitt egy cigiszagú panelbe, ahol 3 férfi {RandomAction()}.", " ", $"{RandomQuestion()}", player, index, 1, options);
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
                    Varos("Sikeresen elmenekültél a thai férfi elől, és a városban vagy.");
                    break;
            }
        }

        static void IngyenesNeni()
        {
            int chance = r.Next(0, 101);
            Increase(0, 50, 0); //alkohol boldogság pénz
            string[] options = new string[] { "Hazaviszed", "Elutasítod és inkább iszol egyet"};
            int choice;
           choice = Display("Happy Hours Nightclub", "Beszélgettél a lánnyal, és fel akar menni a lakásodba.", " ", $"{RandomQuestion()}", player, index, 1, options);
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
            int choice = Display("Vörös Farkas Pub", "A kocsmában vagy.", " ", $"{RandomQuestion()}", player, index, 0, options);

            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 60) / 100.0, 10, -800); //alkohol boldogság pénz
                    Kocsma();
                    break;

                case 2:
                    FejVagyIras();
                    break;

                case 3:
                    Varos("Kisétáltál a kocsmából, és a városban vagy.");
                    break;
            }
        }

        static void FejVagyIras()
        {
            string opponent = RandomPerson();
            Increase(0, 0, 0); //alkohol boldogság pénz
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
                                Increase(0, 30, bet); //alkohol boldogság pénz
                                Thread.Sleep(1000);
                                Console.ReadKey(true);

                                FejVagyIras();
                            }
                            else
                            {
                                Console.ForegroundColor= ConsoleColor.Red;
                                Console.WriteLine($"Vesztettél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, -30, - bet); //alkohol boldogság pénz
                                Thread.Sleep(2000);
                                Console.ReadKey(true);

                                FejVagyIras();
                            }
                        }
                        else
                        {
                            int pickpocket = r.Next(0, 1501);
                            Console.WriteLine($"{opponent} {RandomMoveOpponent()}, mert a(z) \"{userChoice}\" nem Fej, és nem is Írás.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
                            Increase(0, -30, -pickpocket); //alkohol boldogság pénz
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
                        Increase(0, -30, 0);

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
                        Increase(0, -30, - pickpocket); //alkohol boldogság pénz
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
            int chance = r.Next(0, 101);
            string[] options = new string[] { "Veszel egy sört", "Vissza a városba" };
            int choice;
            if (chance <= 70)
            {
                options = new string[] { "Veszel egy sört", "Vissza a városba", "Odamész az alter lányhoz" };
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", "Megpillantasz egy alter lányt, ahogy éppen a Jagermaisterért nyúl.", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarkete", "A supermarketben vagy (ha budapesti, akkor a közértben).", " ", $"{RandomQuestion()}", player, index, 1, options);
            }

            switch (choice)
            {
                case 1:
                    Increase(r.Next(30, 60) / 100.0, 10, -300); //alkohol boldogság pénz
                    Supermarket();
                    break;

                case 2:
                    Varos("Kisétáltál a supermarketből, és a városban vagy.");
                    break;

                case 3:
                    AlterLany();
                    break;
            }
        }

        static void AlterLany()
        {
            int chance = r.Next(0, 101);
            Increase(0, 50, 0); //alkohol boldogság pénz
            string[] options = new string[] { $"Hazaviszed", "Elutasítod és inkább magányos maradsz" };
            int choice;
            if (chance <= 80)
            {
                options = new string[] { "Hazaviszed", "Elutasítod és inkább magányos maradsz", "Gombásztok" };
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", $"A zsebében ott lapul {r.Next(3,11)} gramm varázsgomba", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Zsuzsi néni supermarketje", "Beszélgettél az alter lánnyal, és fel akar menni a lakásodba.", " ", $"{RandomQuestion()}", player, index, 1, options);
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
            static void Falu(string desc)
            {
                string drinkMan = RandomPerson();
                int chance = r.Next(0, 101);
                Increase(0, 5, 0); //alkohol boldogság pénz
                string[] options = new string[] { "Sarki bolt", "Haverokhoz", "Falusi kocsma" };
                int choice;
                if (chance <= 10)
                {
                    options = new string[] { "Sarki bolt", "Haverokhoz", "Falusi kocsma", "Maradok vele inni" };
                    choice = Display("Dorozsmai faluközpont", $"{desc}", $"Egy {drinkMan} \"vegyes házit\" kínál.", "Hová mész tovább?", player, index, 0, options);
                }
                else
                {
                    choice = Display("Dorozsmai faluközpont", $"{desc}", " ", "Hová mész tovább?", player, index, 0, options);
                }
                switch (choice)
                {
                    case 1:
                        SarkiBolt();
                        break;
                    case 2:
                        if (boughtBeer == true)
                        {
                            Haverok($"Összeültél a 3 haveroddal inni.\n{beerCount} sört vittél, a többiekével együtt összesen {allBeer} sörötök van.");
                        }
                        else
                        {
                            Console.WriteLine("Nem vettél sört a sarki boltban, üres kézzel nem illik beállítani!");
                            Console.WriteLine("Visszamész a faluba...");
                            Console.ReadKey();
                            Falu("Visszamentél a faluba, mert nem vettél sört a haveroknak.");
                        }
                    
                        break;
                    case 3:
                        FalusiKocsma("Valahogyan eljutottál a határvégi kocsmához.");
                        break;
                    case 4:
                        if (chance % 10 == 0) 
                        {
                            DisplayEnd(false, "Dorozsmai faluközpont", $"{drinkMan} által kínált \"vegyes házi\" fagyálló volt. Továbbindultál utadra, de menetközben leálltak a veséid, és összeestél.");
                        }
                        else 
                        {
                            Increase(r.Next(70, 120) / 100.0, 20, 0);
                            Falu("Igazán jól esett a vegyes házi, sokkal boldogabb vagy.");
                        }
                        break;
                }
            }

            #region SarkiBolt
            static void SarkiBolt()
            {
                string[] options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba" };
                int choice;
                if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Veszel egy sört", "Kitöltesz egy lottószelvényt", "Visszamész a faluközpontba", "Elmész a templomba" };
                    choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", "Lehetőséged van elmenni az éjféli misére", $"{RandomQuestion()}", player, index, 0.1, options);       
                }
                else
                {
                    choice = Display("Putri kisbolt", "Eljutottál a 0-24-es Putri Kisbolthoz.", " ", $"{RandomQuestion()}", player, index, 0.1, options);
                }

                switch (choice)
                {
                    case 1:
                        boughtBeer = true;
                        beerCount++;
                        allBeer++;
                        Increase(0, 1, -500); //alkohol boldogság pénz
                        SarkiBolt();
                        break;
                    case 2:
                        Lotto();
                        break;
                    case 3:
                        Falu("A boltból visszasétáltál a faluközpontba");
                        break;
                    case 4:
                        EjfeliMise();
                        break;
                }
            }

            static void Lotto()
            {
                Increase(0, 0, -500);
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
                    Increase(0, 50, 5000 * count);
                    Console.WriteLine("Vissza a boltba...");
                    Console.ReadKey();
                    SarkiBolt();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nem nyertél!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Increase(0, - 30, 0);
                    Console.WriteLine("Vissza a boltba...");
                    Console.ReadKey();
                    SarkiBolt();
                }
           
            }

            #endregion //sarkibolt

            static void EjfeliMise()
            {
                Time(1);
                Increase(0, 10, 0); //alkohol boldogság pénz
                string[] options = new string[] { "Imádkozol", "Visszamész a faluközpontba" };
                int choice;
                if (player.Alcohol >= 2.0)
                {
                    options = new string[] { "Imádkozol", "Visszamész a faluközpontba", "Megbotránkoztatóan viselkedsz" };
                    choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", "Morális korlátaidat felszámolta a magas véralkoholszinted.", $"{RandomQuestion()}", player, index, 0, options);
                }
                else
                {
                    choice = Display($"Dorozsmai Szent Szűz \"{RandomPerson()}\" templom", "A templomban vagy megtérés (vagy akció) reményében.", " ", $"{RandomQuestion()}", player, index, 0, options);
                }
                switch (choice)
                {
                    case 1:
                        DisplayEnd(true, "Templom", "Az éjféli mise után kijózanodtál, és megtérve hazaértél, túlélve az estét.");
                        break;
                    case 2:
                        Falu("Nem hittél a pap hablatyolásának, ezért inkább kimentél a templomból.");
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
                        Increase(0, -30, -pickpocket); //alkohol boldogság pénz
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
                        Falu("Egy rendőrautó hátsóülésén visszajutottál a faluba");
                        break;
                }
            }

            #region haverok
            static void Haverok(string desc)
            {
                Time(1);
                if (allBeer < 3)
                {
                    Increase(0, 3, 0); //alkohol boldogság pénz
                }
                string[] options = new string[] { "Isztok egy kört", "Viccesgombáztok", "Autókáztok egyet", "Visszamész a faluközpontba" };
                int choice;
                if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                {
                    options = new string[] { "Isztok egy kört", "Viccesgombáztok", "Autókáztok egyet", "Visszamész a faluközpontba", "Elmentek a templomba" };
                    choice = Display("Haverod tanyája", $"{desc}", "Lehetőségetek van elmenni az éjféli misére", $"{RandomQuestion()}", player, index, 0, options);
                }
                else
                {
                    choice = Display("Haverod tanyája", $"{desc}", " ", "Mit tesztek?", player, index, 0, options);
                }
                switch (choice)
                {
                    case 1:
                        if (allBeer < 3)
                        {
                            Console.WriteLine("Nincs elég sör hármótoknak, ezért nem isztok.");
                            Console.ReadKey();
                            Haverok($"Sajnos kevés a sörötök, {allBeer} van, ezért nincs elég mindenkinek!\nVenned kéne...");
                        }
                        else
                        {
                            allBeer -= 3;
                            Increase(r.Next(30, 60) / 100.0, 15, 0); //alkohol boldogság pénz
                            Haverok($"Ittatok egy jót, már csak {allBeer} sörötök maradt.");
                        }
                        break;
                    case 2:
                        VarazsGomba();
                        break;
                    case 3:
                        DrunkDriving();
                        break;
                    case 4:
                        Falu("Otthagytad a haverokat, és visszamentél a faluba.");
                        break;
                    case 5:
                        EjfeliMise();
                        break;
                }
            }

        static void DrunkDriving()
        {
            Increase(0, 2, 0);
            string friend = RandomPerson();
            Vehicle vehicle1 = RandomVehicle();
            Vehicle vehicle2 = RandomVehicle();
            Vehicle vehicle3 = RandomVehicle();

            string[] options = new string[] {$"Feri járgánya: {vehicle1} (milyen Feri?)", $"A karcsú ember járgánya: {vehicle2}", $"{friend} járgánya: {vehicle3}"};
            int choice = Display("Haverod tanyája", "Úgy döntöttetek, elmentek egyet kocsikázni", "", $"Kinek a járgányát választod?", player, index, 1, options);

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Beugrottál Feri {vehicle1.Model}-ébe/ába\nNyomj Entert a vezetéshez...");
                    Console.ReadKey();
                    Console.WriteLine($"Érzed, ahogy mind a {vehicle1.Performance} ló dübörög alattad.");
                    deathChance = carDeath(player.Alcohol, vehicle1.Performance);
                    Console.WriteLine($"\nTovábbmész? ({100- deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                    string userInput = Console.ReadLine();
                    while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                    {
                        Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                        Console.WriteLine("\nTovábbmész? (I)/(N)");
                        userInput = Console.ReadLine();
                    }
                    while(userInput.ToLower() == "i")
                    {
                        if (ifDie(deathChance))
                        {
                            int dead = r.Next(1, 5);
                            int survived = 4 - dead;
                            DisplayEnd(false, $"Feri {vehicle1.Model}-a/e", $"Az egyik kanyart sajnos elszámoltad, kisodródtál az útról, és körbecsavartad a járgányt egy fán. {dead} halott, {survived} sebesült.");
                        }
                        else
                        {
                            Console.WriteLine(RandomCarPlace());
                        }
                        Console.WriteLine($"\nTovábbmész? ({100 - deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                        userInput = Console.ReadLine();
                        while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                        {
                            Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                            Console.WriteLine("\nTovábbmész? (I)/(N)");
                            userInput = Console.ReadLine();
                        }
                    }    
                 Haverok($"Úgy döntöttetek, elég volt a kocsikázásból. {allBeer} sörötök van.");              
                    break;

                case 2:
                    Console.WriteLine($"Beugrottál a karcsú ember {vehicle2.Model}-ébe/ába\nNyomj Entert a vezetéshez...");
                    Console.ReadKey();
                    Console.WriteLine($"Érzed, ahogy mind a {vehicle2.Performance} ló dübörög alattad.");
                    deathChance = carDeath(player.Alcohol, vehicle2.Performance);
                    Console.WriteLine($"\nTovábbmész? ({100 - deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                    userInput = Console.ReadLine();
                    while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                    {
                        Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                        Console.WriteLine("\nTovábbmész? (I)/(N)");
                        userInput = Console.ReadLine();
                    }
                    while (userInput.ToLower() == "i")
                    {
                        if (ifDie(deathChance))
                        {
                            int dead = r.Next(1, 5);
                            int survived = 4 - dead;
                            DisplayEnd(false, $"A karcsú ember {vehicle2.Model}-a/e", $"Az egyik kanyart sajnos elszámoltad, kisodródtál az útról, és körbecsavartad a járgányt egy fán. {dead} halott, {survived} sebesült.");
                        }
                        else
                        {
                            Console.WriteLine(RandomCarPlace());
                        }
                        Console.WriteLine($"\nTovábbmész? ({100 - deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                        userInput = Console.ReadLine();
                        while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                        {
                            Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                            Console.WriteLine("\nTovábbmész? (I)/(N)");
                            userInput = Console.ReadLine();
                        }
                    }
                    Haverok($"Úgy döntöttetek, elég volt a kocsikázásból. {allBeer} sörötök van.");
                    break;

                case 3:
                    Console.WriteLine($"Beugrottál a {friend} {vehicle3.Model}-ébe/ába\nNyomj Entert a vezetéshez...");
                    Console.ReadKey();
                    Console.WriteLine($"Érzed, ahogy mind a {vehicle3.Performance} ló dübörög alattad.");
                    deathChance = carDeath(player.Alcohol, vehicle3.Performance);
                    Console.WriteLine($"\nTovábbmész? ({100 - deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                    userInput = Console.ReadLine();
                    while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                    {
                        Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                        Console.WriteLine("\nTovábbmész? (I)/(N)");
                        userInput = Console.ReadLine();
                    }
                    while (userInput.ToLower() == "i")
                    {
                        if (ifDie(deathChance))
                        {
                            int dead = r.Next(1, 5);
                            int survived = 4 - dead;
                            DisplayEnd(false, $"{friend} {vehicle3.Model}-a/e", $"Az egyik kanyart sajnos elszámoltad, kisodródtál az útról, és körbecsavartad a járgányt egy fán. {dead} halott, {survived} sebesült.");
                        }
                        else
                        {
                            Console.WriteLine(RandomCarPlace());
                        }
                        Console.WriteLine($"\nTovábbmész? ({100 - deathChance}% esélyed van túlélni a jelenlegi állapotodban, és járművel.) (I)/(N)");
                        userInput = Console.ReadLine();
                        while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                        {
                            Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                            Console.WriteLine("\nTovábbmész? (I)/(N)");
                            userInput = Console.ReadLine();
                        }
                    }
                    Haverok($"Úgy döntöttetek, elég volt a kocsikázásból. {allBeer} sörötök van.");
                    break;
            }
        }

        static bool ifDie(int deathChance)
        {
            if(deathChance > r.Next(0, 100))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion //haverok

        #region falusikocsma
        static void FalusiKocsma(string desc)
            {

                Time(1);
                opponent = RandomPerson();
                int chance = r.Next(0, 101);

                string[] options = new string[] { "Ivás", "Roulette", "Vissza a faluközpontba" };
                int choice;
                if (player.Alcohol >= 2.0)
                {
                    alcPlusTime = true;
                    options = new string[] { "Ivás", "Roulette", "Vissza a faluközpontba", $"Duhajkodás" };
                    choice = Display("Csévi Szilva Kocsma", $"{desc}", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat. ", $"{RandomQuestion()}", player, index, 0, options);
                    if(char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                    {
                        options = new string[] { "Ivás", "Roulette", "Vissza a faluközpontba", "Duhajkodás", "Elmész az éjféli misére" };
                        choice = Display("Csévi Szilva Kocsma", "Valahogyan eljutottál a határvégi kocsmához", "A magas véralkoholszinted felszámolta az összes erkölcsi és morális korlátodat.\n\nLehetőséged van elmenni az éjféli misére.", $"{RandomQuestion()}", player, index, 0, options);
                    }
                }
                else
                {
                    choice = Display("Csévi Szilva Kocsma", "Valahogyan eljutottál a határvégi kocsmához", " ", $"{RandomQuestion()}", player, index, 0, options);
                    if (char.ToLower(player.Time[0]) == '2' && char.ToLower(player.Time[1]) == '3')
                    {
                        options = new string[] { "Ivás", "Roulette", "Vissza a faluközpontba", "Elmész az éjféli misére" };
                        choice = Display("Csévi Szilva kocsma", "Valahogyan eljutottál a határvégi kocsmához", "Lehetőséged van elmenni az éjféli misére.", $"{RandomQuestion()}", player, index, 0, options);
                    }
                }
                switch (choice)
                {
                    case 1:
                        Increase(r.Next(30, 60) / 100.0, 10, -700); //alkohol boldogság pénz
                        FalusiKocsma("Ittál egy jót, ez kifejezetten boldoggá tett.");
                        break;
                    case 2:
                       Roulette("Úgy gondolod, jó ötlet feltenni az összes pénzedet a rouletten, amiről már lekoptak a színek.");
                        break;
                    case 3:
                        Falu("A kocsmából visszasétáltál a faluba.");
                        break;

                    case 4:
                        if(alcPlusTime)
                        {
                             Fight("faluba", "Dorozsmai határvégi borvirág kocsma");
                             Falu("A rendőrség visszavitt a faluközpontba.");
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

            static void Roulette(string desc)
            {
            string opponent = RandomPerson();
            Increase(0, 0, 0); //alkohol boldogság pénz
            string[] options = new string[] { "Játék", "Vissza a pulthoz" };
            int choice = Display("Csévi Szilva Pub roulette asztala", $"{desc}", " ", $"{RandomQuestion()}", player, index, 0, options);

            static string SpinRoulette(string[] wheel)
            {
                return wheel[r.Next(0, wheel.Length)];
            }

            switch (choice)
            {
                case 1:
                    bool isValid = false;
                    int bet;
                    ulong bigNum;
                    Console.WriteLine("Mennyi pénzt raksz fel?");
                    string input = Console.ReadLine();

                    while (int.TryParse(input, out bet) && bet > player.Money)
                    {
                        Console.WriteLine($"Nincs is ennyi pénzed, te {RandomInsult()}");
                        Console.WriteLine("Mennyi pénzt raksz fel?");
                        input = Console.ReadLine();

                    }

                    while (int.TryParse(input, out bet))
                    {
                        notNumTwice = false;
                        bigNumTwice = false;
                        Console.WriteLine($"{bet} Ft-ot tettél fel.\n");

                        Console.WriteLine("Válassz egy számot! (0-36)");
                        string userNum = Console.ReadLine();

                        if (Array.IndexOf(wheel, userNum) != -1)
                        {
                            isValid = true;
                        }

                        while (!isValid)
                        {
                            Console.WriteLine($"Ez nincs rajta a keréken, te {RandomInsult()}");
                            Console.WriteLine("Válassz egy számot! (0-36)");
                            userNum = Console.ReadLine();

                            if (Array.IndexOf(wheel, userNum) != -1)
                            {
                                isValid = true;
                            }
                        }

                        if (isValid)
                        {
                            string result = SpinRoulette(wheel);
                            Console.WriteLine("\nAz eredmény:");
                            string text = $"............... {result} --> ";
                            int delay = 300;
                            foreach (char c in text)
                            {
                                Console.Write(c);
                                Thread.Sleep(delay);
                            }

                            if (userNum == result)  
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Nyertél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, 30, bet); //alkohol boldogság pénz
                                Thread.Sleep(1000);
                                Console.ReadKey(true);

                                Roulette("Nyertél egyet a rouletten, ez boldogsággal tölt el.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Vesztettél {bet} Ft-ot!");
                                Console.ResetColor();
                                Increase(0, -30, -bet); //alkohol boldogság pénz
                                Thread.Sleep(2000);
                                Console.ReadKey(true);

                                Roulette("Sajnos vesztettél a rouletten, ez szomorúvá tett."); //PARAMETER
                            }
                        }

                    }
                    if (ulong.TryParse(input, out bigNum))
                    {
                        
                        {
                            if (bigNumTwice)
                            {
                                int pickpocket = r.Next(0, 1501);
                                Console.WriteLine($"{opponent}, aki a biztonságiőr {RandomMoveOpponent()} , mert megint feldolgozhatatlanul nagy számot adtál meg.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
                                Increase(0, -30, -pickpocket); //alkohol boldogság pénz
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
                            }
                            else
                            {
                                 bigNumTwice = true;
                                 Console.ForegroundColor = ConsoleColor.Red;
                                 Console.WriteLine($"Mégegyszer feldolgozhatatlanul nagy számot raksz fel tétnek, rád fogják hívni a biztonságiőrt.");
                                 Console.ForegroundColor = ConsoleColor.White;
                                 Console.ReadKey();
                                 Roulette("Feldolgozuhatatlanul nagy számot tettél fel tétnek.\nÉn a helyedben több ilyent nem mernék csinálni."); //PARAMETER
                            }
                        }

                    }
                    else
                    {
                        if (notNumTwice)
                        {
                            int pickpocket = r.Next(0, 1501);
                            Console.WriteLine($"{opponent}, aki a biztonságiőr {RandomMoveOpponent()}, mert másodszorra sem vagy hajlandó számot feltenni tétnek.\nMíg feltápászkodtál, kivett a zsebedből {pickpocket} Ft-ot");
                            Increase(0, -30, -pickpocket); //alkohol boldogság pénz
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
                        }
                        else { 
                            notNumTwice = true;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Mégegyszer számon kívül mást raksz fel tétnek, rád fogják hívni a biztonságiőrt.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            Roulette("Nem számot tettél fel tétnek.\nÉn a helyedben több ilyent nem mernék csinálni.");
                        }

                    }
                    break;

                case 2:
                    FalusiKocsma("A roulette asztaltól visszamentél a pulthoz."); //PARAMETER
                    break;

            }

        }

            



        static void Fight(string placeBack, string endPlace, string pickPMan = "goblin")
            {
                int chance = r.Next(0, 101);
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
                Console.WriteLine($"Biológiai leleményességét, és a helyzetet kihasználva, egy {pickPMan} kivett a zsebedből {pickpocket} Ft-ot.");
                Increase(0, -30, -pickpocket); //alkohol boldogság pénz
                updateAttributeDisplay();
                Console.WriteLine("\nKelj fel");
                Console.ReadKey();
                if (chance <= 50)
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
                    chance = r.Next(0, 101);
                    string[] options = new string[] { "I", "N"};
                    string userInput;
                    Console.WriteLine("Kizsebeled? (I)/(N)");
                    userInput = Console.ReadLine();

                    while (userInput.ToLower() != "i" && userInput.ToLower() != "n")
                    {
                        Console.WriteLine($"Ez nem \"I\", és nem is \"N\", te {RandomInsult()}");
                        Console.WriteLine("\nKizsebeled? (I)/(N)");
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
                            Increase(0, 10, pickpocket);
                            updateAttributeDisplay();

                            Console.WriteLine("Elhagyod a helyszínt...");
                            Console.ReadKey();

                            if (chance <= 30)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("A rendőrség menekülés közben elkapott.");
                                Console.ReadKey();
                                DisplayEnd(false, endPlace, "Sajnos a részegséged miatt megcsúsztál egy banánhéjon a menekülés közben, ezért elfogott a rendőrség.");
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

            #endregion//falusi kocsma

            #endregion //falu

        #region kulfold
        public static void Kulfold(string desc)
        {
            string[] options = new string[] { "Csehország", "Slovákia", "Szerbia" };
            int choice = Display("Legendás hármashatár", $"{desc}", " ", "Melyik országba folytatod utadat?", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    Csehorszag();
                    break;
                case 2:
                    Szlovakia();
                    break;
                case 3:
                    Szerbia();
                    break;
            }
        }

        public static void Csehorszag()
        {
            string[] options = new string[] { "Betérsz a \"hořící kostra\" sörözőbe", "Meglátogatod a cseh plugot"};
            int choice = Display("Prága", "Végigmentél az E50-es autópályán egészen Prágáig, és leparkoltál párhuzamosan.", " ", $"{RandomQuestion()}", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    CsehSorozo();
                    break;
                case 2:
                    Plug();
                    break;
            }
        }

        public static void Plug()
        {
            string[] options = new string[] { "Brownie", "Pár g" };
            int choice = Display("Találka hely", "Megbeszélted hol találkozok és most rá vársz.", " ", $"Mit veszel?", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Elfogyasztottad a browniekat, és most jól érzed magad.");
                    Increase(0, 100, -3000);
                    Console.ReadKey(true);
                    plugCount += 1;

                    Csehorszag();
                    break;
                case 2:
                    Console.WriteLine("Elfogyasztottad a szajrét, és most jól érzed magad.");
                    Increase(0, 100, -3000);
                    Console.ReadKey(true);
                    plugCount += 1;

                    Csehorszag();
                    break;
            }
        }

        public static void CsehSorozo()
        {
            if (!voltCsoves)
            {
                Hajlektalan();
            }

            opponent = RandomCzechPerson();
            Increase(r.Next(30, 60) / 100.0, 10, -1000); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Elhagyod a kocsmát", };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                options = new string[] { "Ivás", "Vissza a városba", "Duhajkodás" };
                choice = Display("Hořící kostra pub", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat.", "A magas véralkoholszinted felszámolta az összes morális és etikai korlátodat.", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Hořící kostra pub", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat. Nem láttad a forrását a sűrű füsttől.", " ", $"{RandomQuestion()}", player, index, 1, options);
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
                    Fight("városba", "Hořící kostra pub", "šotek");
                    CsehSorozo();
                    break;
            }
        }

        public static void Hajlektalan()
        {
            voltCsoves = true;
            string[] options = new string[] { "Igen", "Nem"};
            int choice = Display("Prága", "Prága utcáin sétálgattál úton egy kocsmába, amikor megközelített egy hajléktalan. A csöves kemény drogokat ajánl fel neked.", " ", $"Elfogadod őket?", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Egy rozsdás tűt szúrsz a kezedbe.");
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.ReadKey(true);
                    VarazsGomba();
                    break;
                case 2:
                    Console.WriteLine("A hajlétalan szomorúan tovább áll.");
                    Console.ReadKey(true);
                    Console.WriteLine("A szemed sarkábol látod hogy a csöves beszáll egy rendőr autóba és elhajt.");
                    Console.ReadKey(true);
                    Console.WriteLine("Tovább mész a kocsmába.");
                    Console.ReadKey(true);

                    CsehSorozo();
                    break;
            }
        }

        public static void Szlovakia()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Ezt most te se gondoltad komolyan ugye?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
            Increase(0, 20, 0);
            Kulfold("Te most komolyan szlovákiába akartál volna menni??? Válassz újra.");
        }

        public static void Szerbia()
        {
            string[] options = new string[] { "Betérsz a \"iznuđena klasa\" feliratú Szerb sörözőbe", "Meglátogatod a világszrete híres Szerb fekete piacot", };
            int choice = Display("Belgrád", "Egy összehugyozott benzinkúti wc és 5 óra autózás után. Végre Szerbia fővárosába jutsz.", " ", $"{RandomQuestion()}", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    SzerbSorozo();
                    break;
                case 2:
                    FeketePiac();
                    break;
                
            }
        }

        public static void SzerbSorozo()
        {
            opponent = RandomSerbianPerson();
            Increase(r.Next(30, 60) / 100.0, 10, -1000); //alkohol boldogság pénz
            string[] options = new string[] { "Ivás", "Vissza a városba", };
            int choice;
            if (player.Alcohol >= 2.0)
            {
                options = new string[] { "Ivás", "Vissza a városba", "Duhajkodás" };
                choice = Display("Iznuđena klasa pub", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat.", "A magas véralkoholszinted felszámolta az összes morális és etikai korlátodat.", $"{RandomQuestion()}", player, index, 1, options);
            }
            else
            {
                choice = Display("Iznuđena klasa pub", "Lementél a föld alatti kocsmába, és megcsapta egy vicces illat az orrodat. Nem láttad a forrását a sűrű füsttől.", " ", $"{RandomQuestion()}", player, index, 1, options);
            }
            switch (choice)
            {
                case 1:
                    SzerbSorozo();
                    break;
                case 2:
                    Szerbia();
                    break;
                case 3:
                    Fight("városba", "Iznuđena klasa pub", "гоблин");
                    SzerbSorozo();
                    break;
            }
        }

        public static void FeketePiac()
        {
            string opp = RandomPerson();
            string[] options = new string[] { "Zastava CZ99", "Steyr SSG 69", "AK-47", "M79 Osa(rakétavető)", "TMA-5-ös taposó akna", $"Nem fogadod el {opp} ajánlatát."};
            int choice = Display("Egy sötét sikátor", $"{opp} félrehúz és megmutatja neked.\nAzt mondja nem kell fizetned ha megteszel neki valamit.", " ", $"Elviszed valamelyiket?", player, index, 1, options);
            switch (choice)
            {
                default:
                    weapon = options[choice - 1];
                    Increase(0, 30, 0);
                    Bankrablas();
                    break;
                case 6:
                    Szerbia();
                    break;

            }
        }

        public static void Bankrablas()
        {
            string[] options = new string[] { "Halgattsz az ösztöneidre", "Túl felkészületlen vagy ehhez a manőverhez", };
            int choice = Display("Belgrádi Nemzeti Bank előtti tér", "Hirtelen egy gondolatod támad ahogy rápillantassz a Belgrádi Nemzeti Bankra.\nAz újjonnan beszerzett fegyverrel ki tudnád rabolni a bankot.", " ", $"{RandomQuestion()}", player, index, 1, options);
            switch (choice)
            {
                case 1:
                    if(r.Next(1, 101) >= 80)
                    {
                        DisplayEnd(true, " ", $"Csodával határos módon sikerült a három és fél perc alatt kigondolt terved. Rámutattad a {weapon}-edet/adat a szerb pénztárosra és ő odatta a pénzt. Visszafutottál az autódig és meg se álltál hazáig még ha be is kellett hugyoznod.");
                    }
                    else
                    {
                        DisplayEnd(false, "Belgrádi Nemzeti Bank", $"Nem meglepően, nem jött be a terved. Percek alatt elkaptak a szerb rendőrök és még a bankban rátérdeltek a nyakadra és elkobozták a {weapon}-edet/adat.");
                    }
                    break;
                case 2:
                    Szerbia();
                    break;

            }
        }

        #endregion //kulfold

        //document pont áőáőáőőáőőáőáő
        //hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás, hibás

    }
}
