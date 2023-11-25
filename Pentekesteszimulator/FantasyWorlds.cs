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
            string[] options = new string[] { "Beleugrasz az üvöltve égő lelkek tüzébe", "Az éneklő démonok karaoke bulijába belépsz, és a pokoli refrénbe kezdesz bele, miközben a lángoló fityfirittyesek tapsolnak.", "Megküzdöd a lángoló virágokkal, amelyeknek minden szirma éles tűzkarmokká változik, és csak egy szoknyás szellemként menekülhetsz el.", "Részt veszel a hőlégballon versenyen, de a hőlégballonok helyett hatalmas lángcsóvákat kell irányítanod, miközben a fityfirittyesek kiabálnak neked.", "Egy lángoló híd mellett pókháló kötögetsz, miközben a fityfirittyes pókok vidáman ugrándoznak körülötted." };
            int choice = Display("Fityfirittyes Tűzpokol", "Beleittál az italodba, és hirtelen a Fityfirittyes Tűzpokolban találod magad.", " ", "Mit teszel?", options, player);

            switch (choice)
            {
                case 1:
                    DisplayEnd(false, "Árok", "A vicces gombáktól kiütötted magad, és azt hitted, hogy a Fityfirittyes Tűzpokolba kerültél. Eközben csak a földön rángatózva összehugyoztad magad, és egy árokban keltél fel.");
                    break;

                case 2:
                    Kocsma();
                    break;

                case 3:
                    Supermarket();
                    break;
            }
        }

        public static void FantasyWorld2()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "Beleittál az italodba, és hirtelen egy találod magad. Pályaudvaron vagy.", " ", "Mit teszel?", options, player);

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

        public static void FantasyWorld3()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "Beleittál az italodba, és hirtelen egy találod magad. Pályaudvaron vagy.", " ", "Mit teszel?", options, player);

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

        public static void FantasyWorld4()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "Beleittál az italodba, és hirtelen egy találod magad. Pályaudvaron vagy.", " ", "Mit teszel?", options, player);

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

        public static void FantasyWorld5()
        {
            Increase(0, 100, 0, player);
            string[] options = new string[] { "Szórakozóhely", "Kocsma", "Supermarket" };
            int choice = Display("Putri Pályaudvar", "Beleittál az italodba, és hirtelen egy találod magad. Pályaudvaron vagy.", " ", "Mit teszel?", options, player);

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
    }
}
