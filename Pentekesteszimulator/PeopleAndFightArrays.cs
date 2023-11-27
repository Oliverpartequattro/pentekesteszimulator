using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Pentekesteszimulator
{
    internal partial class Program
    {
        public static string RandomPerson()
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
             "Kibelezett class",
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
             "Rúgásos kick-boxos",
             "Pinterius Valentino",
             "László Sándor",
             "Dr. House",
            };
            return people[r.Next(0, people.Length)];
    }
        public static string RandomMove()
        {
            string[] prefixes =
            {
                "Meg",
                "Szét",
                "Fel",
                "Le",
                "Össze",
                "Be",
                "El",
                "Ki"
            };

              string[] moves =
                {
                "préselted",
                "ütötted",
                "fejelted",
                "törted",
                "bökted",
                "könyökölted",
                "csípted",
                "nyársaltad",
                "ragadtad",
                "haraptad",
                "jobbhorogoztad",
                "nyaltad",
                "pofoztad",
                "ütötted",
                "csavargattad",
                "tapostad",
                "csaptad",
                "mélyesztetted",
                "vágtad",
                "fogtad",
                "rántottad",
                "hajítottad",
                "köszörülted",
                "rúgtad",
                "tépted",
                "csiklandoztad"
            };

            string[] bodyParts =
            {
                "az állát",
                "a torkát",
                "az állkapcsát",
                "a lábát",
                "az orrát",
                "a hátát",
                "az arcát",
                "a vállát",
                "a kezét",
                "a gyomrát",
                "a koponyáját",
                "a fogát",
                "a gigáját",
                "a nyelvét",
                "az agylebenyét",
                "a nyaki vénáját",
                "a combközét",
                "az izületét",
                "a nyakcsigolyáját",
                "az agyát",
                "a köldökét",
                "az ujjperceit",
                "a tarkóját",
                "a bőrét",
                "a hónalját",
                "az ujjbegyeit",
                "az ujjainak hegyét",
                "az orrcimpáját",
                "az orrnyílását"
            };
            return prefixes[r.Next(0, prefixes.Length)] + moves[r.Next(0, moves.Length)] + " " + bodyParts[r.Next(0, bodyParts.Length)];
        }

        public static string RandomMoveOpponent()
        {
            string[] prefixes =
             {
                "meg",
                "szét",
                "fel",
                "le",
                "össze",
                "be",
                "el",
                "ki"
            };

            string[] moves =
              {
                "préselte",
                "ütötte",
                "fejelte",
                "törte",
                "bökte",
                "könyökölte",
                "csípte",
                "nyársalta",
                "ragadta",
                "harapta",
                "jobbhorogozta",
                "nyalta",
                "pofozta",
                "ütötte",
                "csavargatta",
                "taposta",
                "csapta",
                "mélyesztette",
                "vágta",
                "fogta",
                "rántotta",
                "hajította",
                "köszörülte",
                "rúgta",
                "tépte",
                "csiklandozta"
            };

            string[] bodyParts =
           {
                "az álladat",
                "a torkodat",
                "az állkapcsodat",
                "a lábadat",
                "az orrodat",
                "a hátadat",
                "az arcodat",
                "a válladat",
                "a kezedet",
                "a gyomrodat",
                "a koponyádat",
                "a fogadat",
                "a gigádat",
                "a nyelvedet",
                "az agylebenyedet",
                "a nyaki véna​dat",
                "a combközödet",
                "az ízületedet",
                "a nyakcsigolyádat",
                "az agyadat",
                "a köldöködet",
                "az ujjperceidet",
                "a tarkódat",
                "a bőrödet",
                "a hónaljadat",
                "az ujjbegyeidet",
                "az ujjaidnak hegyét",
                "az orrcimpádat",
                "az orrnyílásodat"
         };
            return prefixes[r.Next(0, prefixes.Length)] + moves[r.Next(0, moves.Length)] + " " + bodyParts[r.Next(0, bodyParts.Length)];
        }

        public static string RandomInsult()
            {
            string[] insults =
        {
                    "idióta",
                    "eszetlen",
                    "nyomorult",
                    "szerencsétlen",
                    "agyhalott",
                    "sajátos nevelést igénylő",
                    "nemnormális",
                    "droid",
                    "debil",
                    "agyilag nem ép",
                    "majom",
                    "elmeroggyant",
                    "akusztikus",
                    "fityfiritty",
                    "ördög fia",
                    "korlátolt elméjű",
                    "hibbant",
                    "szűk látókörű",
                    "csőlátású",
                    "kókler",
                    "elmebeteg",
                    "mentálisan korlátolt",
                    "mentálisan visszamaradott",
                    "visszafogott",
                    "normáltalan",
                    "zavarodott",
                    "intellektuálisatlan",
                    "szellemileg kihívott",
                    "agyirokkant",
                    "halvány eszű",
                    "agycsavarodott",
                    "konzervdoboz",
                    "akadályozott",
                    "csirkefogó",
                    "csöves",
                    "intellektuális vakvágány",
                    "agyi zsákutca",
                    "bohóc",
                    "agyalágyult",
                    "fertőszentmiklósi",
                    "fertőszentmiklósi",
            };
            return insults[r.Next(0, insults.Length)];
            }

    }
}
