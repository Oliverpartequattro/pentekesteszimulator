using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public delegate void Arrays();

        public static Arrays[] PeopleAndFightArrays = new Arrays[]
        {
            RandomPerson1,
            RandomMove,
        };

        public static void RandomPerson1()
        {
             string[] people =
            {
             "Szakállas alkoholista",
             "Kalapos ember",
             "Lángoló katéteres ember",
             "Kardos árny",
             "Mérgező tekintet",
             "Vérszomjas démon",
             "Szikrázó karom",
             "Lángoló halál",
             "Vérszívó árny",
             "Vasmarok",
             "Pokolból üvöltve rohanó",
             "Sötét árny",
             "Véres mészáros mester",
             "Éjfekete árnyék",
             "Gyilkos pillantású hajléktalan",
             "Vérző kard",
             "Halálos csapda",
             "Lidércfény",
             "Lángoló ököl",
             "Sötét vadász",
             "Kínzó kéz",
             "Gyilkos gőz",
             "Véráztatta árny",
             "Karmos démon",
             "Dühöngő ragadozó",
             "Vérfarkas",
             "Ködös rém",
             "Lélekevő szörny",
             "Hullaarc",
             "Kínzó tűz",
             "Csonttörő",
             "Halálos szem",
             "Rúgós birkózó",
             "Üvöltő zsarnok",
             "Haragos kamionsofőr",
             "Verekedő punk",
             "Csattanós bárdos",
             "Harapós pitbull",
             "Ordító szurkoló",
             "Ütős dzsesszzenész",
             "Üvöltő hajléktalan",
             "Harcos tűzoltó",
             "Rémítő kardforgató",
             "Emberi vágóhídi munkás",
             "Haragos tetovált",
             "Rángatózó epilepsziás",
             "Habzószájú irodalomtanár",
             "Ütős bokszoló",
             "Ordító rockzenész",
             "Verekedő motorkerékpáros",
             "Harcias testépítő",
             "Rúgkapáló karateka",
             "Üvöltő szomszéd",
             "Rémítő horrorfilmfigura",
             "Haragos cimbora",
             "Vágódeszkás vadállat",
             "Ütős harcművész",
             "Ordító szélhámos",
             "Verekedős betyár",
             "Harcias viking",
             "Rúgásos kick-boxos"
            };
            Console.Write(people[r.Next(0, people.Length)]);
    }
        public static void RandomMove()
        {
            Console.WriteLine("asd");
        }

    }
}
