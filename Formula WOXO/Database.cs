using static Formula_WOXO.Util;
using static Formula_WOXO.Color;

namespace Formula_WOXO
{
    public static class Database
    {
        public static List<Constructor> Constructors = new()
        {
            new Constructor {
                Name = "Red Bull",
                ConstructorName = "Red Bull Racing-Honda RBPT",
                Entrant = "Oracle Red Bull Racing",
                Chassis = " RB20",
                PowerUnit = "Honda RBPT",
                Country = "Austria",
                Chief = "Christian Horner",
                Color = "#3671c6",
                Color2 = "#ff0c49",
                Icon = 'ᴥ',
                WorldChampionships = 6
            },
            new Constructor {
                Name = "Mercedes",
                ConstructorName = "Mercedes",
                Entrant = "Mercedes-AMG Petronas F1 Team",
                Chassis = "F1 W15",
                PowerUnit = "Mercedes",
                Country = "Germany",
                Chief = "Toto Wolff",
                Color = "#6cd3bf",
                Color2 = "#7d8386",
                Icon = '☼',
                WorldChampionships = 8
            },
            new Constructor {
                Name = "Ferrari",
                ConstructorName = "Scuderia Ferrari",
                Entrant = "Ferrari",
                Chassis = "SF-24",
                PowerUnit = "Ferrari",
                Country = "Italy",
                Chief = "Frédéric Vasseur",
                Color = "#f91536",
                Color2 = "#fff200",
                Icon = '▼', WorldChampionships = 16
            },
            new Constructor {
                Name = "McLaren",
                ConstructorName = "McLaren-Mercedes",
                Entrant = "McLaren F1 Team",
                Chassis = "MCL38",
                PowerUnit = "Mercedes",
                Country = "United Kingdom",
                Chief = "Andrea Stella",
                Color = "#f58020",
                Color2 = "#ff800a",
                Icon = '~', WorldChampionships = 8
            },
            new Constructor {
                Name = "Aston Martin",
                ConstructorName = "Aston Martin Aramco-Mercedes",
                Entrant = "Aston Martin Aramco F1 Team",
                Chassis = "AMR24",
                PowerUnit = "Mercedes",
                Country = "United Kingdom",
                Chief = "Mike Krack",
                Color = "#358c75",
                Color2 = "#358c75",
                Icon = '▬', WorldChampionships = 0
            },
            new Constructor {
                Name = "Alpine",
                ConstructorName = "Alpine-Renault",
                Entrant = "BWT Alpine F1 Team",
                Chassis = "A524",
                PowerUnit = "Renault",
                Country = "France",
                Chief = "Bruno Famin",
                Color = "#2293d1",
                Color2 = "#2293d1",
                Icon = 'ᴀ', WorldChampionships = 2
            },
            new Constructor {
                Name = "Williams",
                ConstructorName = "Williams-Mercedes",
                Entrant = "Williams Racing",
                Chassis = "FW46",
                PowerUnit = "Mercedes",
                Country = "United Kingdom",
                Chief = "James Vowles",
                Color = "#37bedd",
                Color2 = "#37bedd",
                Icon = 'ᴡ', WorldChampionships = 9
            },
            new Constructor {
                Name = "RB",
                ConstructorName = "RB-Honda RBPT",
                Entrant = "Visa Cash App RB F1 Team",
                Chassis = "AT04",
                PowerUnit = "Honda RBPT",
                Country = "Italy",
                Chief = "Laurent Mekies",
                Color = "#5e8faa",
                Color2 = "#5e8faa",
                Icon = '∞', WorldChampionships = 0
            },
            new Constructor {
                Name = "Sauber",
                ConstructorName = "Kick Sauber-Ferrariv",
                Entrant = "Stake F1 Team Kick Sauber",
                Chassis = "C44",
                PowerUnit = "Ferrari",
                Country = "Switzerland",
                Chief = "Alessandro Alunni Bravi",
                Color = "#00E701",
                Color2 = "#00E701",
                Icon = '●', WorldChampionships = 0
            },
            new Constructor {
                Name = "Haas",
                ConstructorName = "Haas-Ferrari",
                Entrant = "MoneyGram Haas F1 Team",
                Chassis = "VF-24",
                PowerUnit = "Ferrari",
                Country = "United States",
                Chief = "Ayao Komatsu",
                Color = "#b6babd",
                Color2 = "#df0613",
                Icon = '○', WorldChampionships = 0
            }
        };

        public static List<Driver> Drivers = new()
        {
            new Driver {
                FirstName = "Max",
                LastName = "Verstappen",
                ShortName = "VER",
                Country = "Netherlands",
                Number = 1,
                Age = 26,
                DateOfBirth = new DateTime(1997, 9, 30),
                Team = Constructors[0],
                Rating = new DriverRatings(86, 92, 86, 94),
                Stats = new DriverStats(98, 2586.5, 185, 3, 1, new KeyValuePair<short, short> (1, 54))
            },
            new Driver {
                FirstName = "Sergio",
                LastName = "Perez",
                ShortName = "PER",
                Country = "Mexico",
                Number = 11,
                Age = 33,
                DateOfBirth = new DateTime(1990, 1, 26),
                Team = Constructors[0],
                Rating = new DriverRatings(91, 88, 84, 84),
                Stats = new DriverStats(35, 1486, 258, 0, 1, new KeyValuePair<short, short> (1, 6))
            },
            new Driver {
                FirstName = "Lewis",
                LastName = "Hamilton",
                ShortName = "HAM",
                Country = "United Kingdom",
                Number = 44,
                Age = 38,
                DateOfBirth = new DateTime(1985, 1, 7),
                Team = Constructors[1],
                Rating = new DriverRatings(97, 91, 88, 86),
                Stats = new DriverStats(197, 4639.5, 332, 7, 1, new KeyValuePair<short, short> (1, 103))
            },
            new Driver {
                FirstName = "George",
                LastName = "Russell",
                ShortName = "RUS",
                Country = "United Kingdom",
                Number = 63,
                Age = 25,
                DateOfBirth = new DateTime(1998, 2, 15),
                Team = Constructors[1],
                Rating = new DriverRatings(79, 88, 80, 89),
                Stats = new DriverStats(11, 469, 104, 0, 1, new KeyValuePair<short, short> (1, 1))
            },
            new Driver {
                FirstName = "Charles",
                LastName = "Leclerc",
                ShortName = "LEC",
                Country = "Monaco",
                Number = 16,
                Age = 26,
                DateOfBirth = new DateTime(1997, 10, 16),
                Team = Constructors[2],
                Rating = new DriverRatings(83, 92, 83, 93),
                Stats = new DriverStats(30, 1074, 125, 0, 1, new KeyValuePair<short, short> (1, 5))
            },
            new Driver {
                FirstName = "Carlos",
                LastName = "Sainz",
                ShortName = "SAI",
                Country = "Spain",
                Number = 55,
                Age = 29,
                DateOfBirth = new DateTime(1994, 9, 1),
                Team = Constructors[2],
                Rating = new DriverRatings(86, 91, 81, 90),
                Stats = new DriverStats(18, 982.5, 185, 0, 1, new KeyValuePair<short, short> (1, 2))
            },
            new Driver {
                FirstName = "Lando",
                LastName = "Norris",
                ShortName = "NOR",
                Country = "United Kingdom",
                Number = 4,
                Age = 23,
                DateOfBirth = new DateTime(1999, 11, 13),
                Team = Constructors[3],
                Rating = new DriverRatings(81, 93, 84, 94),
                Stats = new DriverStats(13, 633, 104, 0, 1, new KeyValuePair<short, short> (2, 7))
            },
            new Driver {
                FirstName = "Oscar",
                LastName = "Piastri",
                ShortName = "PIA",
                Country = "Australia",
                Number = 81,
                Age = 22,
                DateOfBirth = new DateTime(2001, 4, 6),
                Team = Constructors[3],
                Rating = new DriverRatings(74, 90, 85, 92),
                Stats = new DriverStats(2, 97, 22, 0, 2, new KeyValuePair<short, short> (2, 1))
            },
            new Driver {
                FirstName = "Fernando",
                LastName = "Alonso",
                ShortName = "ALO",
                Country = "Spain",
                Number = 14,
                Age = 42,
                DateOfBirth = new DateTime(1981, 7, 29),
                Team = Constructors[4],
                Rating = new DriverRatings(99, 84, 82, 82),
                Stats = new DriverStats(105, 2244, 337, 2, 1, new KeyValuePair<short, short> (1, 32))
            },
            new Driver {
                FirstName = "Lance",
                LastName = "Stroll",
                ShortName = "STR",
                Country = "Canada",
                Number = 18,
                Age = 25,
                DateOfBirth = new DateTime(1998, 10, 29),
                Team = Constructors[4],
                Rating = new DriverRatings(80, 83, 77, 82),
                Stats = new DriverStats(3, 247, 140, 0, 1, new KeyValuePair<short, short> (3, 3))
            },
            new Driver {
                FirstName = "Pierre",
                LastName = "Gasly",
                ShortName = "GAS",
                Country = "France",
                Number = 10,
                Age = 27,
                DateOfBirth = new DateTime(1996, 2, 7),
                Team = Constructors[5],
                Rating = new DriverRatings(79, 83, 75, 84),
                Stats = new DriverStats(4, 388, 127, 0, 2, new KeyValuePair<short, short> (1, 1))
            },
            new Driver {
                FirstName = "Esteban",
                LastName = "Ocon",
                ShortName = "OCO",
                Country = "France",
                Number = 31,
                Age = 27,
                DateOfBirth = new DateTime(1996, 1, 17),
                Team = Constructors[5],
                Rating = new DriverRatings(80, 84, 74, 83),
                Stats = new DriverStats(3, 409, 130, 0, 3, new KeyValuePair<short, short> (1, 1))
            },
            new Driver {
                FirstName = "Alexander",
                LastName = "Albon",
                ShortName = "ALB",
                Country = "Thailand",
                Number = 23,
                Age = 27,
                DateOfBirth = new DateTime(1996, 3, 23),
                Team = Constructors[6],
                Rating = new DriverRatings(81, 81, 80, 82),
                Stats = new DriverStats(2, 228, 78, 0, 4, new KeyValuePair<short, short> (3, 2))
            },
            new Driver {
                FirstName = "Logan",
                LastName = "Sargeant",
                ShortName = "SAR",
                Country = "United States",
                Number = 2,
                Age = 22,
                DateOfBirth = new DateTime(2000, 12, 31),
                Team = Constructors[6],
                Rating = new DriverRatings(61, 73, 76, 75),
                Stats = new DriverStats(0, 1, 19, 0, 10, new KeyValuePair<short, short> (10, 1))
            },
            new Driver {
                FirstName = "Yuki",
                LastName = "Tsunoda",
                ShortName = "TSU",
                Country = "Japan",
                Number = 22,
                Age = 23,
                DateOfBirth = new DateTime(2000, 5, 11),
                Team = Constructors[7],
                Rating = new DriverRatings(74, 85, 75, 86),
                Stats = new DriverStats(0, 52, 63, 0, 7, new KeyValuePair<short, short> (4, 1))
            },
            new Driver {
                FirstName = "Daniel",
                LastName = "Ricciardo",
                ShortName = "RIC",
                Country = "Australia",
                Number = 3,
                Age = 34,
                DateOfBirth = new DateTime(1989, 7, 1),
                Team = Constructors[7],
                Rating = new DriverRatings(89, 82, 80, 81),
                Stats = new DriverStats(32, 1317, 236, 0, 1, new KeyValuePair<short, short> (1, 8))
            },
            new Driver {
                FirstName = "Valtteri",
                LastName = "Bottas",
                ShortName = "BOT",
                Country = "Finland",
                Number = 77,
                Age = 34,
                DateOfBirth = new DateTime(1989, 8, 28),
                Team = Constructors[8],
                Rating = new DriverRatings(88, 80, 86, 77),
                Stats = new DriverStats(67, 1797, 219, 0, 1, new KeyValuePair<short, short> (1, 10))
            },
            new Driver {
                FirstName = "Zhou",
                LastName = "Guanyu",
                ShortName = "ZHO",
                Country = "China",
                Number = 24,
                Age = 24,
                DateOfBirth = new DateTime(1999, 5, 30),
                Team = Constructors[8],
                Rating = new DriverRatings(68, 76, 76, 73),
                Stats = new DriverStats(0, 12, 41, 0, 5, new KeyValuePair<short, short> (8, 1)),
                ReverseDisplayName = true
            },
            new Driver {
                FirstName = "Kevin",
                LastName = "Magnussen",
                ShortName = "MAG",
                Country = "Denmark",
                Number = 20,
                Age = 31,
                DateOfBirth = new DateTime(1992, 10, 5),
                Team = Constructors[9],
                Rating = new DriverRatings(82, 77, 78, 82),
                Stats = new DriverStats(1, 186, 161, 0, 4, new KeyValuePair<short, short> (2, 1))
            },
            new Driver {
                FirstName = "Nico",
                LastName = "Hulkenberg",
                ShortName = "HUL",
                Country = "Germany",
                Number = 27,
                Age = 36,
                DateOfBirth = new DateTime(1987, 8, 19),
                Team = Constructors[9],
                Rating = new DriverRatings(87, 81, 84, 86),
                Stats = new DriverStats(0, 530, 203, 0, 1, new KeyValuePair<short, short> (4, 3))
            },
        };
        
        public static Dictionary<string, string> SmallFlags = new()
        {
            { "BAHRAIN", FromHexBackground("#FFFFFF") + FromHex("#CE1126") + "▒██" + FromHexBackground("#000000")},
            { "SAUDI ARABIA", FromHexBackground("#165D31") + FromHex("#FFFFFF") + " ﬗ " + FromHexBackground("#000000")},
            { "AUSTRALIA", FromHexBackground("#012169") + FromHex("#E4005B") + "⁺" + FromHex("#FFFFFF") + " ✶" + FromHexBackground("#000000")},
            { "JAPAN", FromHexBackground("#FFFFFF") + FromHex("#BC002D") + " ● " + FromHexBackground("#000000")},
            { "CHINA", FromHexBackground("#EE1C25") + FromHex("#FFFF00") + "*: " + FromHexBackground("#000000")},
            { "UNITED STATES", FromHexBackground("#0A3161") + FromHex("#FFFFFF") + "░" + FromHexBackground("#B31942") + FromHex("#FFFFFF") + "■■" + FromHexBackground("#000000")},
            { "ITALY", FromHex("#008C45") + "█" + FromHex("#F4F9FF") + "█" + FromHex("#CD212A") + "█" },
            { "FRANCE", FromHex("#002654") + "█" + FromHex("#FFFFFF") + "█" + FromHex("#ED2939") + "█" },
            { "MONACO", FromHexBackground("#FFFFFF") + FromHex("#CE1126") + "▀▀▀" + FromHexBackground("#000000")},
            { "CANADA", FromHexBackground("#FFFFFF") + FromHex("#D80621") + "▌♣▐" + FromHexBackground("#000000")},
            { "SPAIN", FromHexBackground("#AA151B") + FromHex("#F1BF00") + "◙■■" + FromHexBackground("#000000")},
            { "AUSTRIA", FromHexBackground("#EF3340") + FromHex("#FFFFFF") + "■■■" + FromHexBackground("#000000")},
            { "UNITED KINGDOM", FromHexBackground("#012169") + FromHex("#FFFFFF") + "╪" + FromHexBackground("#FFFFFF") + FromHex("#C8102E") + "╋" + FromHexBackground("#012169") + FromHex("#FFFFFF") + "╪" + FromHexBackground("#000000")},
            { "HUNGARY", FromHexBackground("#477050") + FromHex("#CE2939") + "▄" + FromHexBackground("#FFFFFF") + " " + FromHex("#477050") + FromHexBackground("#CE2939")  +  "▀" + FromHexBackground("#000000")},
            { "BELGIUM", FromHex("#2D2926") + "█" + FromHex("#FFCD00") + "█" + FromHex("#C8102E") + "█" },
            { "NETHERLANDS", FromHexBackground("#C8102E") + FromHex("#003DA5") + "▄" + FromHexBackground("#FFFFFF") + " " + FromHexBackground("#C8102E") + FromHex("#003DA5") + "▄" + FromHexBackground("#000000")},
            { "GERMANY", FromHexBackground("#000000") + FromHex("#FFCC00") + "▄" + FromHexBackground("#DD0000") + " " + FromHexBackground("#000000") + FromHex("#FFCC00") + "▄"},
            { "AZERBAIJAN", FromHexBackground("#0092BC") + FromHex("#00AF66") + "▄" + FromHexBackground("#E4002B") + FromHex("#FFFFFF")  + "с" + FromHexBackground("#0092BC") + FromHex("#00AF66") + "▄" + FromHexBackground("#000000")},
            { "SINGAPORE", FromHexBackground("#C73B3C") + FromHex("#FFFFFF") + "⁽" + FromHexBackground("#FFFFFF") + FromHex("#C73B3C") + "▀▀" + FromHexBackground("#000000")},
            { "MEXICO", FromHex("#006341") + "█" + FromHex("#F4F9FF") + FromHexBackground("#FFFFFF") + FromHex("#784421") + "◌" + FromHexBackground("#000000") + FromHex("#C8102E") + "█" },
            { "BRAZIL", FromHexBackground("#009739") + FromHex("#FEDD00") + "◄" + FromHexBackground("#FEDD00") + FromHex("#021269") + "●" + FromHexBackground("#009739") + FromHex("#FEDD00") + "►" + FromHexBackground("#000000")},
            { "QATAR", FromHexBackground("#FFFFFF") + FromHex("#8A1538") + "▒██" + FromHexBackground("#000000")},
            { "UNITED ARAB EMIRATES", FromHex("#EF3340") + "█" + FromHexBackground("#097339") + FromHex("#FFFFFF") + "▄▄" + FromHexBackground("#000000")},
            { "DENMARK", FromHexBackground("#C8102E") + FromHex("#FFFFFF") + "╋━━" + FromHexBackground("#000000")},
            { "ICELAND", FromHexBackground("#02529C") + FromHex("#DC1E35") + "╬══" + FromHexBackground("#000000")},
            { "NORWAY", FromHexBackground("#BA0C2F") + FromHex("#00205B") + "╬══" + FromHexBackground("#000000")},
            { "SWEDEN", FromHexBackground("#006AA7") + FromHex("#FECC02") + "╋━━" + FromHexBackground("#000000")},
            { "FINLAND", FromHexBackground("#FFFFFF") + FromHex("#002F6C") + "╋━━" + FromHexBackground("#000000")},
            { "FAROE ISLANDS", FromHexBackground("#FFFFFF") + FromHex("#ED2939") + "╬══" + FromHexBackground("#000000")},
            { "SWITZERLAND", FromHexBackground("#000000") + FromHex("#DA291C") + "▐" + FromHexBackground("#DA291C") + FromHex("#FFFFFF") + "+" + FromHex("#000000") + "▐" + FromHexBackground("#000000")},
            { "GEORGIA", FromHexBackground("#FFFFFF") + FromHex("#DA291C") + "÷╋÷" + FromHexBackground("#000000")},
            { "THAILAND", FromHexBackground("#EF3340") + FromHex("#FFFFFF") + "■" + FromHex("#00247D") + "█" + FromHex("#FFFFFF") + "■" + FromHexBackground("#000000")},
            { "PORTUGAL", FromHexBackground("#046A38") +  FromHex("#FFE900") + "⁽" + FromHexBackground("#DA291C") + FromHex("#FFE900") + "⁾ " + FromHexBackground("#000000")},
        };

        public static List<GrandPrix> GrandsPrix = new()
        {
            new() {
                Name = "Bahrain",
                NameGP = "Bahrain",
                NameShort = "Bahrain",
                Circuit = "Bahrain International Circuit",
                Country = "Bahrain",
                Location = "Sakhir",
                Coordinates = "26.0325, 50.5106",
                FirstGP = 2004,
                LapRecord = "1:31.447 Pedro de la Rosa (2005)",
                Laps = 57,
                Turns = 15,
                DRSZones = 3,
                Lenght = 5.412,
                RaceDistance = 308.238,
                TimeLenght = new TimeSpan(0, 1, 32)
            },
            new() {
                Name = "Jeddah",
                NameGP = "Saudi Arabian",
                NameShort = "SA",
                Circuit = "Jeddah Corniche Circuit",
                Country = "Saudi Arabia",
                Location = "Jeddah",
                Coordinates = "21.6319, 39.1044",
                FirstGP = 2021,
                LapRecord = "1:30.734 Lewis Hamilton (2021)",
                Laps = 50,
                Turns = 27,
                DRSZones = 2,
                Lenght = 6.175,
                RaceDistance = 308.750,
                TimeLenght = new TimeSpan(0, 1, 31)
            },
            new() {
                Name = "Albert Park",
                NameGP = "Australian",
                NameShort = "Australian",
                Circuit = "Albert Park Circuit",
                Country = "Australia",
                Location = "Melbourne",
                Coordinates = "-37.8497, 144.9686",
                FirstGP = 1996,
                LapRecord = "1:24.125 Michael Schumacher (2004)",
                Laps = 58,
                Turns = 16,
                DRSZones = 2,
                Lenght = 5.303,
                RaceDistance = 307.574,
                TimeLenght = new TimeSpan(0, 1, 25)
            },
            new() {
                Name = "Suzuka",
                NameGP = "Japanese",
                NameShort = "Japanese",
                Circuit = "Suzuka International Racing Course",
                Country = "Japan",
                Location = "Suzuka",
                Coordinates = "34.8431, 136.5404",
                FirstGP = 1987,
                LapRecord = "1:30.983 Lewis Hamilton (2019)",
                Laps = 53,
                Turns = 18,
                DRSZones = 2,
                Lenght = 5.807,
                RaceDistance = 307.471,
                TimeLenght = new TimeSpan(0, 1, 32)
            },
            new() {
                Name = "Shanghai",
                NameGP = "Chinese",
                NameShort = "Chinese",
                Circuit = "Shanghai International Circuit",
                Country = "China",
                Location = "Shanghai",
                Coordinates = "31.3389, 121.2208",
                FirstGP = 2004,
                LapRecord = "1:32.238 Michael Schumacher (2004)",
                Laps = 56,
                Turns = 16,
                DRSZones = 2,
                Lenght = 5.451,
                RaceDistance = 305.066,
                TimeLenght = new TimeSpan(0, 1, 33)
            },
            new() {
                Name = "Miami",
                NameGP = "Miami",
                NameShort = "Miami",
                Circuit = "Miami International Autodrome",
                Country = "United States",
                Location = "Miami",
                Coordinates = "25.9581, -80.2389",
                FirstGP = 2022,
                LapRecord = "1:29.708 Max Verstappen (2023)",
                Laps = 57,
                Turns = 19,
                DRSZones = 3,
                Lenght = 5.412,
                RaceDistance = 308.326,
                TimeLenght = new TimeSpan(0, 1, 30)
            },
            new() {
                Name = "Imola",
                NameGP = "Emilia Romagna",
                NameShort = "E. Romagna",
                Circuit = "Imola Circuit",
                Country = "Italy",
                Location = "Imola",
                Coordinates = "44.3439, 11.7167",
                FirstGP = 1980,
                LapRecord = "1:15.484 Lewis Hamilton (2020)",
                Laps = 63,
                Turns = 19,
                DRSZones = 2,
                Lenght = 4.909,
                RaceDistance = 309.049,
                TimeLenght = new TimeSpan(0, 1, 16)
            },
            new() {
                Name = "Monaco",
                NameGP = "Monaco",
                NameShort = "Monaco",
                Circuit = "Circuit de Monaco",
                Country = "Monaco",
                Location = "Monte Carlo",
                Coordinates = "43.7347, 7.4206",
                FirstGP = 1950,
                LapRecord = "1:12.909 Lewis Hamilton (2021)",
                Laps = 78,
                Turns = 19,
                DRSZones = 1,
                Lenght = 3.337,
                RaceDistance = 260.286,
                TimeLenght = new TimeSpan(0, 1, 14)
            },
            new() {
                Name = "Gilles Villeneuve",
                NameGP = "Canadian",
                NameShort = "Canadian",
                Circuit = "Circuit Gilles Villeneuve",
                Country = "Canada",
                Location = "Montreal",
                Coordinates = "45.5040, -73.5225",
                FirstGP = 1967,
                LapRecord = "1:13.078 Valtteri Bottas (2019)",
                Laps = 70,
                Turns = 14,
                DRSZones = 2,
                Lenght = 4.361,
                RaceDistance = 305.27,
                TimeLenght = new TimeSpan(0, 1, 14)
            },
            new() {
                Name = "Barcelona",
                NameGP = "Spanish",
                NameShort = "Spanish",
                Circuit = "Circuit de Barcelona-Catalunya",
                Country = "Spain",
                Location = "Montmeló",
                Coordinates = "41.5697, 2.2590",
                FirstGP = 1991,
                LapRecord = "1:16.330 Max Verstappen (2023)",
                Laps = 66,
                Turns = 14,
                DRSZones = 2,
                Lenght = 4.657,
                RaceDistance = 307.236,
                TimeLenght = new TimeSpan(0, 1, 17)
            },
            new() {
                Name = "Red Bull Ring",
                NameGP = "Austrian",
                NameShort = "Austrian",
                Circuit = "Red Bull Ring",
                Country = "Austria",
                Location = "Spielberg",
                Coordinates = "47.2197, 14.7642",
                FirstGP = 1970,
                LapRecord = "1:05.619 Carlos Sainz (2020)",
                Laps = 71,
                Turns = 10,
                DRSZones = 3,
                Lenght = 4.318,
                RaceDistance = 306.452,
                TimeLenght = new TimeSpan(0, 1, 7)
            },
            new() {
                Name = "Silverstone",
                NameGP = "British",
                NameShort = "British",
                Circuit = "Silverstone Circuit",
                Country = "United Kingdom",
                Location = "Silverstone",
                Coordinates = "52.0786, -1.0169",
                FirstGP = 1950,
                LapRecord = "1:27.097 Max Verstappen (2020)",
                Laps = 52,
                Turns = 18,
                DRSZones = 2,
                Lenght = 5.891,
                RaceDistance = 306.198,
                TimeLenght = new TimeSpan(0, 1, 28)
            },
            new() {
                Name = "Hungaroring",
                NameGP = "Hungarian",
                NameShort = "Hungarian",
                Circuit = "Hungaroring",
                Country = "Hungary",
                Location = "Mogyoród",
                Coordinates = "47.5789, 19.2488",
                FirstGP = 1986,
                LapRecord = "1:16.627 Lewis Hamilton (2020)",
                Laps = 70,
                Turns = 14,
                DRSZones = 2,
                Lenght = 4.381,
                RaceDistance = 306.630,
                TimeLenght = new TimeSpan(0, 1, 18)
            },
            new() {
                Name = "Spa-Francorchamps",
                NameGP = "Belgian",
                NameShort = "Belgian",
                Circuit = "Circuit de Spa-Francorchamps",
                Country = "Belgium",
                Location = "Stavelot",
                Coordinates = "50.4372, 5.9714",
                FirstGP = 1950,
                LapRecord = "1:46.286 Valtteri Bottas (2018)",
                Laps = 44,
                Turns = 19,
                DRSZones = 1,
                Lenght = 7.004,
                RaceDistance = 308.052,
                TimeLenght = new TimeSpan(0, 1, 47)
            },
            new() {
                Name = "Zandvoort",
                NameGP = "Dutch",
                NameShort = "Dutch",
                Circuit = "Circuit Zandvoort",
                Country = "Netherlands",
                Location = "Zandvoort",
                Coordinates = "52.3888, 4.5400",
                FirstGP = 1952,
                LapRecord = "1:11.097 Lewis Hamilton (2021)",
                Laps = 72,
                Turns = 14,
                DRSZones = 2,
                Lenght = 4.259,
                RaceDistance = 306.587,
                TimeLenght = new TimeSpan(0, 1, 12)
            },
            new() {
                Name = "Monza",
                NameGP = "Italian",
                NameShort = "Italian",
                Circuit = "Monza Circuit",
                Country = "Italy",
                Location = "Monza",
                Coordinates = "45.6156, 9.2811",
                FirstGP = 1950,
                LapRecord = "1:21.046 Rubens Barrichello (2004)",
                Laps = 53,
                Turns = 11,
                DRSZones = 2,
                Lenght = 5.793,
                RaceDistance = 306.720,
                TimeLenght = new TimeSpan(0, 1, 22)
            },
            new() {
                Name = "Baku City",
                NameGP = "Azerbaijan",
                NameShort = "Azerbaijan",
                Circuit = "Baku City Circuit",
                Country = "Azerbaijan",
                Location = "Baku",
                Coordinates = "40.3725, 49.8533",
                FirstGP = 2016,
                LapRecord = "1:43.009 Charles Leclerc (2019)",
                Laps = 51,
                Turns = 20,
                DRSZones = 2,
                Lenght = 6.003,
                RaceDistance = 306.049,
                TimeLenght = new TimeSpan(0, 1, 44)
            },
            new() {
                Name = "Marina Bay",
                NameGP = "Singapore",
                NameShort = "Singapore",
                Circuit = "Marina Bay Street Circuit",
                Country = "Singapore",
                Location = "Marina Bay",
                Coordinates = "1.2914, 103.8640",
                FirstGP = 2008,
                LapRecord = "1:35.867 Lewis Hamilton (2023)",
                Laps = 62,
                Turns = 19,
                DRSZones = 3,
                Lenght = 4.94,
                RaceDistance = 306.143,
                TimeLenght = new TimeSpan(0, 1, 37)
            },
            new() {
                Name = "Circuit of the Americas",
                NameGP = "United States",
                NameShort = "US",
                Circuit = "Circuit of the Americas",
                Country = "United States",
                Location = "Texas",
                Coordinates = "30.1328, -97.6411",
                FirstGP = 2012,
                LapRecord = "1:36.169 Charles Leclerc (2019)",
                Laps = 56,
                Turns = 20,
                DRSZones = 2,
                Lenght = 5.513,
                RaceDistance = 308.405,
                TimeLenght = new TimeSpan(0, 1, 37)
            },
            new() {
                Name = "Hermanos Rodriguez",
                NameGP = "Mexico City",
                NameShort = "Mexico C.",
                Circuit = "Autódromo Hermanos Rodríguez",
                Country = "Mexico",
                Location = "Mexico City",
                Coordinates = "19.4042, -99.0907",
                FirstGP = 1963,
                LapRecord = "1:17.774 Valtteri Bottas (2021)",
                Laps = 71,
                Turns = 17,
                DRSZones = 1,
                Lenght = 4.304,
                RaceDistance = 305.354,
                TimeLenght = new TimeSpan(0, 1, 19)
            },
            new() {
                Name = "Interlagos",
                NameGP = "São Paulo",
                NameShort = "São Paulo",
                Circuit = "Interlagos Circuit",
                Country = "Brazil",
                Location = "São Paulo",
                Coordinates = "-23.7036, -46.6997",
                FirstGP = 1973,
                LapRecord = "1:10.540 Valtteri Bottas (2018)",
                Laps = 71,
                Turns = 15,
                DRSZones = 2,
                Lenght = 4.309,
                RaceDistance = 305.879,
                TimeLenght = new TimeSpan(0, 1, 11)
            },
            new() {
                Name = "Las Vegas Strip",
                NameGP = "Las Vegas",
                NameShort = "Las Vegas",
                Circuit = "Las Vegas Strip Circuit",
                Country = "United States",
                Location = "Las Vegas",
                Coordinates = "36.1699, -115.1398",
                FirstGP = 2023,
                LapRecord = "1:35.950 Oscar Piastri (2023)",
                Laps = 50,
                Turns = 17,
                DRSZones = 2,
                Lenght = 6.201,
                RaceDistance = 310.05,
                TimeLenght = new TimeSpan(0, 1, 37)
            },
            new() {
                Name = "Lusail",
                NameGP = "Qatar",
                NameShort = "Qatar",
                Circuit = "Lusail International Circuit",
                Country = "Qatar",
                Location = "Lusail",
                Coordinates = "25.4714, 51.4150",
                FirstGP = 2021,
                LapRecord = "1:24.319 Max Verstappen (2023)",
                Laps = 57,
                Turns = 16,
                DRSZones = 2,
                Lenght = 5.419,
                RaceDistance = 308.611,
                TimeLenght = new TimeSpan(0, 1, 25)
            },
            new() {
                Name = "Yas Marina",
                NameGP = "Abu Dhabi",
                NameShort = "Abu Dhabi",
                Circuit = "Yas Marina Circuit",
                Country = "United Arab Emirates",
                Location = "Abu Dhabi",
                Coordinates = "24.4672, 54.6031",
                FirstGP = 2009,
                LapRecord = "1:26.103 Max Verstappen (2021)",
                Laps = 58,
                Turns = 16,
                DRSZones = 2,
                Lenght = 5.281,
                RaceDistance = 306.183,
                TimeLenght = new TimeSpan(0, 1, 27)
            }
        }; 
    }
    public class Constructor
    {
        public string? Name { get; set; }
        public string? ConstructorName { get; set; }
        public string? Entrant { get; set; }
        public string? Chassis { get; set; }
        public string? PowerUnit { get; set; }
        public string? Country { get; set; }
        public string? Chief { get; set; }
        public string? Color { get; set; }
        public string? Color2 { get; set; }
        public char Icon { get; set; }
        public byte WorldChampionships { get; set; }
    };
    public class Driver
    {
        public int id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public bool ReverseDisplayName { get; set; }
        public string DisplayName
        {
            get
            {
                if (ReverseDisplayName)
                    return $"{FromHex(Team.Color) + FirstName.ToUpper()}\n{FromHex("#ffffff") + LastName}";
                else
                    return $"{FirstName}\n{FromHex(Team.Color) + LastName.ToUpper()}";
            }
        }
        public string? ShortName { get; set; }
        public string? Country { get; set; }
        public byte Number { get; set; }
        public byte Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Constructor? Team { get; set; }
        public DriverRatings Rating { get; set; }
        public DriverStats Stats { get; set; }
    };
    public class GrandPrix
    {
        public string? Name { get; set; }
        public string? NameGP { get; set; }
        public string? NameShort { get; set; }
        public string? Circuit { get; set; }
        public string? Country { get; set; }
        public string? Location { get; set; }
        public string? Coordinates { get; set; }
        public int DRSZones { get; set; }
        public int Laps { get; set; }
        public int Turns { get; set; }
        public int FirstGP { get; set; }
        public double Lenght { get; set; }
        public TimeSpan TimeLenght { get; set; }
        public double RaceDistance { get; set; }
        public string? LapRecord { get; set; }
    }
    public readonly struct DriverRatings
    {
        public byte Experience { get; }
        public byte Racecraft { get; }
        public byte Awareness { get; }
        public byte Pace { get; }
        public DriverRatings(byte experience, byte racecraft, byte awareness, byte pace)
        {
            Experience = experience;
            Racecraft = racecraft;
            Awareness = awareness;
            Pace = pace;
        }
    }
    public readonly struct DriverStats
    {
        public short Podiums { get; }
        public double Points { get; }
        public short GrandsPrixEntered { get; }
        public byte WorldChampionships { get; }
        public byte HighestGridPosition { get; }
        public KeyValuePair<short, short> HighestRaceFinish { get; }
        public DriverStats(short podiums, double points, short grandsPrixEntered, byte worldChampionships, byte highestGridPosition, KeyValuePair<short, short> highestRaceFinish)
        {
            Podiums = podiums;
            Points = points;
            GrandsPrixEntered = grandsPrixEntered;
            WorldChampionships = worldChampionships;
            HighestGridPosition = highestGridPosition;
            HighestRaceFinish = highestRaceFinish;
        }
    }
}
