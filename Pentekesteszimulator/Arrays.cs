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
             "Kényszerzubbonyos ember", 
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
             "Duhajkodós István",
             "Tófalvi Milán",
             "Gonosz tudós",
             "Rostás Nintendo",
             "Gipsz Jakab",
             "Saddam Hussein",
             "Karcsú ember",
             "Kőbányai Szopófantom",
             "Munkás kéz",
             "Erős kéz",
             "Fortnite játékos",
             "John Wick a Fortniteból",
             "Kárpátia rajongó",
             "Jó LaciBetyár",
             "Holokauszt tagadó",
             "Fertőszentmiklósi",
             "Lapos Föld hívő",
             "Nyomorult",

            };
            return people[r.Next(0, people.Length)];
    }
        public static string RandomMove()
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
                "csiklandoztad",
                "flexelted",

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
                "az orrnyílását",
                "az idegvégződését",
                "a csigolyáját",
                "az ádámcsutkáját",
                "a gerincoszlopát",
                "a lelkét",
                "a fülcimpáját"
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
                "csiklandozta",
                "flexelte",

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
                "az orrnyílásodat",
                "az idegvégződésedet",
                "a csigolyádat",
                "az ádámcsutkádat",
                "a gerincoszlopodat",
                "a lelkedet",
                "a fülcimpádat",

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
                    "félkegyelmű",
                    "suttyó",
                    "amőba",
                    "egysejtű",
                    "komplex gondolkodásra képtelen",
                    "csalódás",
                    "tudatlan",
                    "agybaj",
                    "Linux felhasználó",
                    "isten csapása",
                    "isten ostora",
                    
            };
            return insults[r.Next(0, insults.Length)];
            }

        public static string RandomScandal()
        {
            string[] scandals =
        {
             "leverted az asztal sarkát egy üveg sörrel",
             "késsel a kezedben üvöltve hadonásztál",
             "levizelted a falat, miközben 360 fokban pörögtél",
             "széles mosollyal az arcodon önkényuralmi jelképeket mutogattál",
             "elkezdtél üvöltve mulatós slágereket énekelni",
             "különböző bandajeleket mutogattál",
             "örömmel összeraktál egy kalapácsot egy sarlóval, miközben üvöltve hirdetted a proletárdiktatúrát",
             "felgyújtottál egy melegzászlót, melynek a hamujából önkényuralmi jelképeket raktál ki",
             "hangosan és büszkén homofób kifejezéseket kiáltottál",
             "kimondtad az \"n betűs szót\"",
             "vérben forgó szemekkel elkezdted Jákob népét derogáló nyelvezettel illetni",
             "a melletted űlő államtársadat visszakézből orron vágtad, mert alsóbbrendű",
             "a földre köptél egyet, ami átmarta a padlót",
             "irdatlan nagyot fingottál, majd meggyújtottad",
             "elnyomtál a szomszédodon egy csikket, mert Heinekent ivott",
             "lereszelted a bőrt a sarkadról, majd levest főztél belőle",
             "megfogtál egy gyermeket, majd a lábánál fogva pörgetted a levegőben"

            };
            return scandals[r.Next(0, scandals.Length)];
        }

        public static string RandomAction()
        {
            string[] actions =
            {
                "mákos tésztát eszik",
                "vakolja a falat",
                "fugázza a csempét",
                "csömöszköli a betont",
                "ekével veri a földet",
                "mákos tésztát készít",
                "szemcseppet, higítót és mákvirágot kever össze",
                "fehér csíkokat szív fel az asztalról",
                "Fortikázik",
                "césárpot programozik",
                "ostort csattogtat a levegőben",
                "kalapáccsal veri a falat",
                "Obama vezetéknevét kutatja",
                "Viktória titkait tárja fel",
                "dinoszauruszokat szelidít",
                "keresi ki kérdezte",
                "keresi Régi-Zélandot",
                "tervezi, hogy az apja után megy tejért",
                "bizonyítja, hogy a Föld lapos",
                "lóháton ostorral a kezében hadonászik",

            };
            return actions[r.Next(0, actions.Length)];
        }

        public static string RandomRoom()
        {
            string[] rooms =
            {
                "A konyhában",
                "A nappaliban",
                "A skanzenben",
                "A hálószobában",
                "Az ebédlőben",
                "A sufniban",
                "A saját szobádban",
                "A budiban",
                "A kazánházban",
                "A kutyaházban"
            };
            return rooms[r.Next(0, rooms.Length)];
        }

        public static string[] BadWords()
        {
            string[] badWords = {
    "kurva", "kúrva",
    "fasz", "fasz",
    "nigger", "n*gger",
    "utallak", "utállak",
    "adj", "ádj",
    "adjal", "ádjal",
    "kuki", "kúki",
    "kell", "kéll",
    "akarok", "akárok",
    "neger", "néger",
    "mivan", "mi van",
    "idióta", "idióta",
    "eszetlen", "eszetlén",
    "nyomorult", "nyomorúlt",
    "szerencsétlen", "szerencsétlén",
    "agyhalott", "agyhallott",
    "sajátos nevelést igénylő", "sajátos nevelést igénylő",
    "nemnormális", "nem normális",
    "droid", "dróid",
    "debil", "debil",
    "agyilag nem ép", "agyilag nem ép",
    "majom", "májom",
    "elmeroggyant", "elmeroggyánt",
    "akusztikus", "akusztikus",
    "fityfiritty", "fityfiritty",
    "ördög fia", "ördög fia",
    "korlátolt elméjű", "korlátolt elméjű",
    "hibbant", "hibbánt",
    "szűk látókörű", "szűk látókörű",
    "csőlátású", "csőlátású",
    "kókler", "kókler",
    "elmebeteg", "elmebeteg",
    "mentálisan korlátolt", "mentálisan korlátolt",
    "mentálisan visszamaradott", "mentálisan visszamaradott",
    "visszafogott", "visszafogott",
    "normáltalan", "normáltalan",
    "zavarodott", "zavárodott",
    "intellektuálisatlan", "intellektuálisatlan",
    "szellemileg kihívott", "szellemileg kihívott",
    "agyirokkant", "agyírókkant",
    "halvány eszű", "halvány eszű",
    "agycsavarodott", "agycsavarodott",
    "konzervdoboz", "konzervdoboz",
    "akadályozott", "akadályozott",
    "csirkefogó", "csirkefogó",
    "csöves", "csöves",
    "intellektuális vakvágány", "intellektuális vakvágány",
    "agyi zsákutca", "agyi zsákutca",
    "bohóc", "bohóc",
    "agyalágyult", "agyalágyult",
    "fertőszentmiklósi", "fertőszentmiklósi",
    "félkegyelmű", "félkegyelmű",
    "suttyó", "suttyó",
    "amőba", "amőba",
    "egysejtű", "egysejtű",
    "komplex gondolkodásra képtelen", "komplex gondolkodásra képtelen",
    "csalódás", "csalódás",
    "tudatlan", "tudatlan",
    "agybaj", "agybaj",
    "Linux felhasználó", "Linux felhasználó",
    "isten csapása", "isten csapása",
    "isten ostora", "isten ostora"
};

            return badWords;
        }

        public static string[] GoodWords()
        {
            string[] goodWords = {
    "legyszi", "legyszíves",
    "kerlek", "kérlek",
    "legyszives", "legyszíves",
    "szeretlek", "szeretlek", "szeretlek",
    "imadlak", "imádlak",
    "szeretnek", "szeretnék",
    "kerek", "kérek",
    "szepen", "szépen",
    "puszi", "puszi",
    "kaphatnek", "kaphatnék"

            };
            return goodWords;
        }

    }
}
