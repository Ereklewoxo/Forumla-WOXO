using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Formula_WOXO.Color;
using static Formula_WOXO.Util;
using static Formula_WOXO.Database;
using static System.Formats.Asn1.AsnWriter;

namespace Formula_WOXO
{
    public class Race
    {
        public static void RaceHud(int grandPrixId)
        {
            ConsoleKeyInfo key;
            bool intervalSwitch = false; 
            var drivers = Drivers;
            var grid = new List<Grid>();

            foreach (var driver in drivers) { 
                 grid.Add(new Grid { DriverInfo = driver, Time = 0 }); }
            grid = StartingGridGenerator(grid);

            for (int lap = 0; lap < GrandsPrix[grandPrixId].Laps;)
            {
                if (lap != 0)
                    lap = lap + GrandsPrix[grandPrixId].Laps / 15 > GrandsPrix[grandPrixId].Laps ? GrandsPrix[grandPrixId].Laps : lap + GrandsPrix[grandPrixId].Laps / 15;

                string boxColor = lap == GrandsPrix[grandPrixId].Laps ? FromHex("#e10600") : FromRgb(80, 85, 100);
                WriteAt(1, 1, "" + boxColor +
                 "  ╭──────────────────────────┐\n" +
                $"  │ {FromHex("#e10600")} ▄███████▀ ▄██▀{boxColor}          │\n" +
                $"  │{FromHex("#e10600")}▄███▀▀▀▀▀ ▄██▀{boxColor}            │\n" +
                 "  ├──────────────────────────┤\n" +
                 "  │                          │\n" +
                 "  ├──────────────────────────┤\n" +
                 "  │                          │\n" +
                 "  ├──────────────────────────┤\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  │                          │\n" +
                 "  ╰──────────────────────────┘");
                WriteAt(5, 5, FromHex("#ffffff") + GrandsPrix[grandPrixId].NameShort + " GP");
                WriteAt(26, 5, SmallFlags[GrandsPrix[grandPrixId].Country.ToUpper()]);

                string lapCount = lap == GrandsPrix[grandPrixId].Laps ? "FINAL LAP" : FromHex("#aaaaaa") + "LAP " + FromHex("#ffffff") + lap + FromHex("#aaaaaa") + "/" + GrandsPrix[grandPrixId].Laps;
                string lineColor = "#eeeeee";

                WriteAt(12, 7, FromHex("#ffffff") + lapCount);

                do
                {
                    for (int i = 0; i < grid.Count; i++)
                    {
                        string position = i > 8 ? FromHex(lineColor) + (i + 1) : FromHex(lineColor) + $" {i + 1}";
                        string constructorLogo = FromHex(grid[i].DriverInfo.Team.Color2) + grid[i].DriverInfo.Team.Icon;
                        string Initials = FromHex(lineColor) + grid[i].DriverInfo.ShortName;
                        string time = intervalSwitch ? "Interval" : "  Leader";
                        if (i > 0)
                        {
                            TimeSpan timeSpan = intervalSwitch ? TimeSpan.FromSeconds((grid[i - 1].Time - grid[i].Time) / 5) : TimeSpan.FromSeconds((grid[0].Time - grid[i].Time) / 5);
                            
                            string seconds = timeSpan.Minutes > 0 && timeSpan.Seconds < 10 ? "0" + timeSpan.Seconds : timeSpan.Seconds.ToString();
                            
                            time = timeSpan.Minutes > 0 ? "+" + timeSpan.Minutes + ":" + seconds + "." + timeSpan.Milliseconds / 10 
                                                        : " +" + timeSpan.Seconds + "." + timeSpan.Milliseconds;
                            
                            if (timeSpan.Milliseconds.ToString().Length < 3 && timeSpan.Minutes is 0)
                                time = time.PadRight(time.Length + 3 - timeSpan.Milliseconds.ToString().Length, '0');
                            else if ((timeSpan.Milliseconds / 10).ToString().Length < 2)
                                time = time.PadRight(time.Length + 2 - (timeSpan.Milliseconds / 10).ToString().Length, '0');

                            if (timeSpan.Seconds < 10 && timeSpan.Minutes is 0)
                                time = " " + time;

                            if (GrandsPrix[grandPrixId].TimeLenght < timeSpan && GrandsPrix[grandPrixId].TimeLenght * 2 > timeSpan)
                                time = $"  +1 Lap";
                            else if (GrandsPrix[grandPrixId].TimeLenght * 2 < timeSpan)
                            {
                                int laped = Convert.ToInt32(timeSpan.TotalMilliseconds / GrandsPrix[grandPrixId].TimeLenght.TotalMilliseconds);
                                time = $" +{laped} Laps";
                            }
                        }
                        string tyre = FromHex("#ef1c24") + " s";

                        if (lap is 0)
                            time = "        ";

                        string hudLine = position + " " + constructorLogo + " " + Initials + "        " + time + tyre;
                        WriteAt(4, 9 + i * 2, hudLine);
                    }

                    ClearKey();
                    key = Console.ReadKey(true);
                    if (key.Key is ConsoleKey.Tab)
                        intervalSwitch = !intervalSwitch;

                } while(key.Key != ConsoleKey.Enter);
                grid = UpdateRace(grid);
                if (lap is 0)
                    lap++;
            }
        }
        public static List<Grid> StartingGridGenerator(List<Grid> grid)
        {
            foreach (var driver in grid)
            {
                Random rnd = new();
                double randomSeed = rnd.NextDouble();
                int randomScore = rnd.Next(driver.DriverInfo.Rating.Pace,
                    (driver.DriverInfo.Rating.Awareness + driver.DriverInfo.Rating.Experience + driver.DriverInfo.Rating.Racecraft + driver.DriverInfo.Rating.Pace * 2) / 4);
                driver.Time = randomScore + randomSeed;
            }
            grid.Sort((x, y) => y.Time.CompareTo(x.Time));
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i].Time = (grid.Count - i) * 10;
            }
            return grid;
        }
        public static List<Grid> UpdateRace(List<Grid> grid)
        {
            foreach (var driver in grid)
            {
                Random rnd = new();
                double randomSeed = rnd.NextDouble();
                int randomScore = rnd.Next(driver.DriverInfo.Rating.Racecraft + driver.DriverInfo.Rating.Pace / 2,
                    (driver.DriverInfo.Rating.Experience + driver.DriverInfo.Rating.Pace + driver.DriverInfo.Rating.Awareness) / 3 + driver.DriverInfo.Rating.Racecraft);
                driver.Time = driver.Time + randomScore + randomSeed;
            }
            grid.Sort((x, y) => y.Time.CompareTo(x.Time));
            return grid;
        }
        public class Grid
        {
            public Driver DriverInfo { get; set; }
            public double Time { get; set; }
        }
    }
}