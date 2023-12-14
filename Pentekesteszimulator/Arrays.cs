﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;//goto

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
                "körfűrészelted",
                "reszelted",
                "daráltad"

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
                "körfűrászelte",
                "resztelte",
                "darálta"

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
                    "goto",
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
                    "mentálisan megerőltetett",
                    "zokni"
                    
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
             "felvetted az albán zászlós arcmaszkodat, és különböző bandajeleket mutogattál",
             "örömmel összeraktál egy kalapácsot egy sarlóval, miközben üvöltve hirdetted a proletárdiktatúrát",
             "felgyújtottál egy melegzászlót, melynek a hamujából önkényuralmi jelképeket raktál ki",
             "hangosan és büszkén homofób kifejezéseket kiáltottál",
             "széles mosollyal az arcodon kimondtad az \"n betűs szót\"",
             "vérben forgó szemekkel elkezdted Jákob népét derogáló nyelvezettel illetni",
             "a melletted űlő államtársadat visszakézből orron vágtad, mert alsóbbrendű",
             "a földre köptél egyet, ami átmarta a padlót",
             "irdatlan nagyot fingottál, majd meggyújtottad",
             "elnyomtál a szomszédodon egy csikket, mert Heinekent ivott",
             "lereszelted a bőrt a sarkadról, majd sajtlevest főztél belőle",
             "megfogtál egy gyermeket, majd a lábánál fogva pörgetted a levegőben",
             "egy nem létező istenhez fohászkodtál a negyedik utolsó italod után",
             "a hangszóródon hangosan náci indulót játszottál",
             "rácsatlakoztál egy államtársad mobileszközére \"mögötted vagyok\" BlueTooth névvel",
             "felkeltél, és a hozzád legközelebb eső honfitársadat elkezdted aggresszívan szaglászni"

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
                "töcsköli a vájlingot",
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
                "olajozza a félmeztelen felsőtestét",
                "üvöltve nehézgépeket operál",
                "oroszlánként küzd UNO-ban",
                "rakétahajtóműveket szerel fel egy Lidl-s bevásárlókocsira"

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
                "A kutyaházban",
                "A vájlingban"
            };
            return rooms[r.Next(0, rooms.Length)]; 
        }

        public static string[] BadWords()
        {
            string[] badWords = {
                "kurva", "kúrva",
                "fasz", "fasz",
                "nigger", "nigger",
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
                "isten ostora", "isten ostora",
                "bazdmeg"
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

        public static string RandomQuestion()
        {
            string[] questions = 
            {
                "Mit teszel?",
                "Mit fogsz tenni?",
                "Mi a terved?",
                "Mi a következő lépésed?",
                "Mi lesz a következő cselekedeted?",
                "Milyen lépést tervezel?",
                "Mi a következő lépés a tervben?",
                "Mik a terveid?",
                "Hogyan fogod folytatni?",
                "Milyen intézkedéseket fogsz hozni?",
                "Mivel folytatod?",
                "Mit szándékozol tenni?"
            };
            return questions[r.Next(0, questions.Length)];
        }

            public static string[] vehicles =
            {
            "1993 Ford Mustang 5.0 V8 ;305",
            "2005 Chevrolet Malibu 2.2 I4 ;145",
            "2010 Toyota Camry 2.5 I4 ;178",
            "1989 Honda Accord 2.0 I ;98",
            "2018 Tesla Model 3 Elektromos ;258",
            "2008 Nissan Altima 2.5 I4 ;175",
            "2002 Ford Focus 2.0 I4 ;110",
            "1995 Toyota Corolla 1.8 I4 ;105",
            "1985 Chevrolet Impala 5.0 V8 ;140",
            "2015 Honda Civic 1.8 I4 ;143",
            "1998 Ford Taurus 3.0 V6 ;145",
            "2019 Hyundai Elantra 2.0 I4 ;147",
            "2007 Volkswagen Jetta 2.5 I5 ;150",
            "1990 Buick Century 3.3 V6 ;160",
            "2012 Kia Optima 2.4 I4 ;200",
            "1988 Dodge Caravan 2.5 I4 ;100",
            "2017 Chevrolet Cruze 1.4 Turbo I4 ;153",
            "2000 Honda Odyssey 3.5 V6 ;210",
            "2014 Ford Fusion 1.5 Turbo I4 ;181",
            "1996 Nissan Maxima 3.0 V6 ;190",
            "2004 Toyota Camry Solara 3.3 V6 ;225",
            "2016 Subaru Legacy 2.5 Flat-4 ;175",
            "1991 Honda Prelude 2.1 I4 ;160",
            "2009 Hyundai Sonata 2.4 I4 ;175",
            "1986 Chevrolet Cavalier 2.0 I4 ;88",
            "2013 Mazda6 2.5 I4 ;184",
            "1999 Ford Escort 2.0 I4 ;110",
            "2011 Nissan Sentra 2.0 I4 ;140",
            "1987 Toyota Camry 2.0 I4 ;95",
            "2003 Honda CR-V 2.4 I4 ;160",
            "2014 Subaru Impreza 2.0 Flat-4 ;148",
            "1997 Ford Explorer 4.0 V6 ;160",
            "2019 Kia Forte 2.0 I4 ;147",
            "2006 Chevrolet Cobalt 2.2 I4 ;145",
            "1992 Honda Civic 1.5 I4 ;102",
            "2010 Subaru Outback 2.5 Flat-4 ;170",
            "2015 Toyota Prius 1.8 Hybrid ;121",
            "1994 Nissan Pathfinder 3.0 V6 ;153",
            "2018 Honda Fit 1.5 I4 ;130",
            "1996 Toyota RAV4 2.0 I4 ;120",
            "2005 Subaru Forester 2.5 Flat-4 ;165",
            "2017 Hyundai Accent 1.6 I4 ;130",
            "1993 Chevrolet S-10 4.3 V6 ;160",
            "2008 Honda Pilot 3.5 V6 ;244",
            "2016 Ford Fiesta 1.6 I4 ;120",
            "1996 Jeep Cherokee 4.0 I6 ;190",
            "2012 Chevrolet Sonic 1.8 I4 ;138",
            "1989 Ford Ranger 2.9 V6 ;140",
            "2014 Kia Soul 1.6 I4 ;130",
            "2007 Toyota Highlander 3.3 V6 ;270",
            "2015 Chevrolet Corvette Z06 6.2 V8 ;650",
            "2018 Dodge Challenger SRT Hellcat 6.2 V8 ;707",
            "2019 Ford Mustang Shelby GT500 5.2 V8 ;760",
            "2017 Tesla Model S P100D Elektromos ;762",
            "2016 Chevrolet Camaro ZL1 6.2 V8 ;650",
            "2020 Porsche 911 Turbo S 3.8 Flat-6 ;640",
            "2021 Ford GT 3.5 V6 Twin-Turbo ;660",
            "2014 Nissan GT-R Nismo 3.8 V6 Twin-Turbo ;600",
            "2013 Mercedes-Benz SLS AMG Black Series 6.2 V8 ;622",
            "2019 Ferrari 488 Pista 3.9 V8 Twin-Turbo ;710",
            "2016 BMW M5 Competition 4.4 V8 Twin-Turbo ;625",
            "2017 Lamborghini Huracan Performante 5.2 V10 ;640",
            "2022 Audi RS6 Avant 4.0 V8 Twin-Turbo ;591",
            "2015 Jaguar F-Type R 5.0 V8 Supercharged ;550",
            "2018 McLaren 720S 4.0 V8 Twin-Turbo ;710",
            "2020 Chevrolet Corvette Stingray 6.2 V8 ;495",
            "2019 Porsche Panamera Turbo S E-Hybrid 4.0 V8 Twin-Turbo ;680",
            "2017 Dodge Charger SRT Hellcat 6.2 V8 ;707",
            "2015 BMW i8 Elektromos Hybrid ;369",
            "2023 Tesla Model X Plaid Elektromos ;1020",
            "2018 Mercedes-AMG GT R 4.0 V8 Twin-Turbo ;577",
            "2019 Aston Martin DBS Superleggera 5.2 V12 Twin-Turbo ;715",
            "2016 Ford Shelby GT350 5.2 V8 ;526",
            "2021 Lexus LC 500 5.0 V8 ;471",
            "2014 Chevrolet SS 6.2 V8 ;415",
            "2017 Alfa Romeo Giulia Quadrifoglio 2.9 V6 Twin-Turbo ;505",
            "2019 Bentley Continental GT 6.0 W12 Twin-Turbo ;626",
            "2020 Jeep Grand Cherokee Trackhawk 6.2 V8 Supercharged ;707",
            "2015 Cadillac CTS-V 6.2 V8 Supercharged ;640",
            "2022 Toyota Supra A91 3.0 Turbo I6 ;382",
            "2012 Ford Fusion 2.5 I4 ;175",
            "2014 Honda Accord 2.4 I4 ;185",
            "2010 Chevrolet Equinox 2.4 I4 ;182",
            "2016 Nissan Rogue 2.5 I4 ;170",
            "2018 Hyundai Tucson 2.0 I4 ;164",
            "2015 Kia Sportage 2.4 I4 ;182",
            "2017 Subaru Forester 2.5 Flat-4 ;170",
            "2013 Toyota RAV4 2.5 I4 ;176",
            "2019 Honda HR-V 1.8 I4 ;141",
            "2011 Chevrolet Traverse 3.6 V6 ;281",
            "2014 Ford Escape 2.0 Turbo I4 ;240",
            "2018 Toyota Highlander 3.5 V6 ;295",
            "2016 Honda Pilot 3.5 V6 ;280",
            "2012 Nissan Murano 3.5 V6 ;260",
            "2015 Hyundai Santa Fe 3.3 V6 ;290",
            "2017 Kia Sorento 3.3 V6 ;290",
            "2013 Subaru Outback 2.5 Flat-4 ;173",
            "2019 Toyota Camry 3.5 V6 ;301",
            "2014 Honda Odyssey 3.5 V6 ;248",
            "2010 Ford Edge 3.5 V6 ;265",
            "2009 Fiat 500 1.2 I4 ;69",
            "2013 Smart Fortwo 1.0 I3 ;70",
            "2016 Chevrolet Spark 1.4 I ;98",
            "2012 Toyota Prius C 1.5 I3 ;99",
            "2015 Ford Fiesta 1.0 I3 ;123",
            "2011 Honda Fit 1.5 I4 ;117",
            "2014 Nissan Versa 1.6 I4 ;109",
            "2010 Hyundai Accent 1.6 I4 ;110",
            "2017 Kia Rio 1.6 I4 ;130",
            "2013 Mazda2 1.5 I4 ;100",
            "2018 Volkswagen Polo 1.0 I3 ;65",
            "2016 Ford Fiesta 1.6 I4 ;120",
            "2014 Chevrolet Sonic 1.8 I4 ;138",
            "2010 Toyota Yaris 1.5 I4 ;106",
            "2015 Honda Fit 1.5 I4 ;130",
            "2017 Hyundai Accent 1.6 I4 ;130",
            "2013 Kia Rio 1.6 I4 ;138",
            "2011 Mazda2 1.5 I4 ;100",
            "2018 Volkswagen Polo 1.2 I3 ;90",
            "2012 Ford Fiesta 1.6 I4 ;120",
            "2014 Chevrolet Spark 1.2 I3 ;84",
            "2010 Nissan Sentra 2.0 I4 ;140",
            "2015 Toyota Corolla 1.8 I4 ;132",
            "2005 Ford Fiesta 1.4 I4 ;78",
            "2010 Chevrolet Spark 1.0 I4 ;68",
            "2013 Nissan Micra 1.2 I3 ;80",
            "2008 Toyota Aygo 1.0 I3 ;67",
            "2012 Honda Jazz 1.2 I3 ;90",
            "2016 Hyundai i10 1.0 I3 ;66",
            "2014 Kia Picanto 1.0 I3 ;69",
            "2011 Mazda2 1.3 I4 ;75",
            "2009 Volkswagen Polo 1.2 I3 ;70",
            "2015 Subaru Justy 1.0 I3 ;68",
            "2018 Ford Ka 1.2 I3 ;70",
            "2010 Chevrolet Aveo 1.2 I ;84",
            "2013 Nissan Versa 1.6 I4 ;109",
            "2016 Toyota Yaris 1.5 I4 ;106",
            "2012 Honda Fit 1.5 I4 ;130",
            "2007 Hyundai Accent 1.4 I4 ;95",
            "2014 Kia Rio 1.2 I3 ;84",
            "2019 Mazda2 1.5 I4 ;90",
            "2011 Volkswagen Polo 1.2 I4 ;70",
            "2015 Subaru Impreza 1.6 Flat-4 ;114",
            "2018 Ford Fiesta 1.0 I3 ;100",
            "2012 Chevrolet Sonic 1.8 I4 ;138",
            "2010 Nissan Sentra 2.0 I4 ;140",
            "2013 Toyota Corolla 1.8 I4 ;132",
            "2016 Honda Civic 1.5 I4 ;130",
            "2017 Hyundai Elantra 1.6 I4 ;128",
            "2014 Kia Forte 1.8 I4 ;145",
            "2011 Mazda3 2.0 I4 ;155",
            "2015 Volkswagen Golf 1.8 I4 ;170",
            "2016 Subaru Legacy 2.5 Flat-4 ;175",
            "1997 Mazda MX-5 1.8 I4 ;138",
            };

        public class Vehicle
        {
            public string Model { get; set; }
            public double Performance { get; set; }

            public Vehicle(string model, double performance)
            {
                Model = model;
                Performance = performance;
            }

            public override string ToString()
            {
                return $"{Model}- {Performance} Lóerő";
            }
        }

            public static Vehicle RandomVehicle()
            {
                int i = r.Next(vehicles.Length);

                string[] vehicleData = vehicles[i].Split(';');
                string model = vehicleData[0];
                double performance = double.Parse(vehicleData[1]);

                return new Vehicle(model, performance);
            }

    }
}
