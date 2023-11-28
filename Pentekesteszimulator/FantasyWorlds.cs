using System;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public delegate void FantasyWorlds();

        public static FantasyWorlds[] worlds = new FantasyWorlds[]
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

            int randomIndex = random.Next(0, worlds.Length);

            worlds[randomIndex]();

            Console.ReadLine();
        }

        public static void FantasyWorld1()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[] {
                "Beleugrasz az üvöltve égő lelkek tüzébe",
                "Az éneklő démonok karaoke bulijába belépsz, és a pokoli refrénbe kezdesz bele, miközben a lángoló fityfirittyesek tapsolnak.", 
                "Megküzdöd a lángoló virágokkal, amelyeknek minden szirma éles tűzkarmokká változik, és csak egy szoknyás szellemként menekülhetsz el.", 
                "Részt veszel a hőlégballon versenyen, de a hőlégballonok helyett hatalmas lángcsóvákat kell irányítanod, miközben a fityfirittyesek kiabálnak neked.", 
                "Egy lángoló híd mellett pókháló kötögetsz, miközben a fityfirittyes pókok vidáman ugrándoznak körülötted." };
            int choice = Display("Fityfirittyes Tűzpokol", "Elsötétedett a világ, és hirtelen a Fityfirittyes Tűzpokolban találod magad.", " ", "Mit teszel?",  player, timeStopped, index, options);

            DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Fityfirittyes Tűzpokolba kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
        }

        public static void FantasyWorld2()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[]
             {
                "Megpróbálsz hűs kávét főzni a bágyogszováti síremlékek között, miközben az árnyak közt beszélgető koporsókra próbálsz figyelni.",
                "Késsel és villával kezdesz ásni a sírok körül, mert úgy hallottad, hogy a fakultatív hullák valószínűleg ételt rejtenek a sírjaikban.",
                "Elindulsz egy 'temetői szellemkarate' edzésre, ahol az elhunyt harcosok szellemei segítenek fejleszteni az ütéseidet és rúgásaidat.",
                "Az elhunytak sírjai helyett óriási könyvek sírjai körül sétálgatsz, és megpróbálod kibogozni a varázslatos kötéseket, amelyek a sírokat összekapcsolják.",
                "A bágyogszováti temetői tévéműsort készíted, ahol a síremlékeken táncoló zombik versenyeznek a legstílusosabb mozgásért.",
                "Két sír közt kanapét helyezel el, és elrendezel egy kis szellemfogadást a szellemekkel, akik az elhunytak közül érkeznek egy kis csevegésre és teázásra."
            };
            int choice = Display("Bágyogszováti Temető", "Elsötétedett a világ, és hirtelen a Bágyogszováti Temetőben találod magad. Pályaudvaron vagy.", " ", "Mit teszel?",  player, timeStopped, index, options);

            DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Bágyogszováti Temetőbe kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
        }

        public static void FantasyWorld3()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[]
            {
                "Lángoló delfinekkel támadsz mindenkit, aki nem használja a legújabb horgászfelszerelést.",
                "Az ásatás helyett szörnyeket hozol a sírok közé, hogy azok támadják az embereket, akik nem horgásznak elégedettséggel.",
                "Késsel vágod el a levegőt, hogy mindenkit ijesztően megijedj.",
                "Megfenyegeted a horgászok bordáit, hogy megvédhesd a delfinek becsületét.",
                "Kiválasztasz véletlenszerűen embereket, hogy ők legyenek a hajított csontok célpontjai.",
                "Vizes halakkal dobálod meg azokat a horgászokat, akik nem követik a \"delfin-kódexet\"."
            };
            int choice = Display("Down-Kóros Delfin Horgászbolt", "Elsötétedett a világ, és hirtelen a Down-Kóros Delfin Horgászboltban találod magad. Pályaudvaron vagy.", " ", "Mit teszel?",  player, timeStopped, index, options);

            DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Down-Kóros Delfin Horgászboltba kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
            
        }

        public static void FantasyWorld4()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[]
                {
                    "Beleugrasz az üvöltve égő lelkek tüzébe, majd karddal a kezedben eloltod a lángokat, miközben kacagva táncolsz.",
                    "Felveszed a kocsmai asztal alól a gigantikus csontozott halat, és elkezded vele verőfényesen veretni a többieket.",
                    "Egyetlen mozdulattal hatalmas légköri robbanást generálsz, amely mindenkire rázúdul a kocsmában, miközben te kihúzod magad a pusztítás közepéről.",
                    "Elkapod a közelben lévő bordákat, és fenyegetően lobogtatsz velük, miközben kiáltasz, hogy \"Halál a gyengébbeknek!\"",
                    "Egy pillanat alatt kiveszed az összes mozgó csontot a testből, és aztán táncolva menekülsz előlük, miközben az emberek ijedten figyelnek.",
                    "Téglákat dobálsz a kitalált hajléktalanokra, de azok a levegőben elkezdenek lebegni, és hangosan nevetnek a találatokon."
                };

            int choice = Display("Retek Taverna", "Elsötétedett a világ, és hirtelen a Retek Tavernában találod magad. Pályaudvaron vagy.", " ", "Mit teszel?",  player, timeStopped, index, options);

            DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Retek Tavernába kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
            
        }

        public static void FantasyWorld5()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[]
                 {
                    "Belevetedsz egy tűzgömböt az égő lelkek közé, közben nevetve a szenvedésükön.",
                    "Karmokkal téped szét a sírköveket, remélve, hogy a rejtett kincsek és nyomok megtalálhatók a sírokban.",
                    "Vassal és láncokkal kötözöd meg az embereket, majd hagyod, hogy a sötétség végezzen velük.",
                    "Fenyegetőzöl a bordákkal, hogy megtörjed az ellenfeleidet.",
                    "Vérző szemekkel nézed, ahogy a mozgó csontok vadul támadnak, miközben futásnak eredsz előlük.",
                    "Sziklákat dobálsz az árva lélekű hajléktalanokra, miközben őrjöngsz a kétségbeesésükön."
                 };
            int choice = Display("Purgatórium", "Elsötétedett a világ, és hirtelen a Purgatóriumban találod magad. Pályaudvaron vagy.", " ", "Mit teszel?",  player, timeStopped, index, options);

            DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Purgatóriumba kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
        }
    }
}
