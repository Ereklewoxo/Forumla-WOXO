using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Formula_WOXO.Color;
using static Formula_WOXO.Util;

namespace Formula_WOXO
{
    public class Race
    {
        public static void RaceHud(int grandPrixId)
        {
            while (true)
            {
                var drivers = Database.Drivers;
                var grid = new List<Grid>();
                foreach (var driver in drivers)
                {
                    grid.Add(new Grid { DriverInfo = driver, Time = 0 });
                }
                grid = StartingGridGenerator(grid);
                string box = FromRgb(80, 80, 115);
                WriteAt(1, 1, "" + box +
                 " ╭───────────────────┐\n" +
                $" │ {FromHex("#e10600")}/‾‾‾‾‾‾//‾/{box}       │\n" +
                $" │{FromHex("#e10600")}/__/‾‾‾‾/_/ {box}       │\n" +
                 " ├───────────────────┤\n" +
                 " │                   │\n" +
                 " ├───────────────────┤\n" +
                 " │                   │\n" +
                 " ├───────────────────┤\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " │                   │\n" +
                 " ╰───────────────────┘");
                WriteAt(4, 5, Database.GrandsPrix[grandPrixId].NameShort + " GP");
                WriteAt(18, 5, Database.SmallFlags[Database.GrandsPrix[grandPrixId].Country.ToUpper()]);
                grandPrixId++;
                for (int i = 0; i < grid.Count; i++)
                {
                    string position = i > 8 ? FromHex("#ffffff") + (i + 1) : FromHex("#ffffff") + $" {i + 1}";
                    string constructorLogo = FromHex(grid[i].DriverInfo.Team.Color2) + grid[i].DriverInfo.Team.Icon;
                    string Initials = FromHex("#ffffff") + grid[i].DriverInfo.ShortName;
                    string hudLine = position + " " + constructorLogo + " " + Initials + "  " + grid[i].Time;
                    WriteAt(3, 9 + i, hudLine);
                }
                KeyAdvance();
            }
        }
        public static List<Grid> StartingGridGenerator(List<Grid> grid)
        {
            foreach (var driver in grid)
            {
                Random rnd = new();
                double randomSeed = rnd.NextDouble();
                int randomScore = rnd.Next(driver.DriverInfo.Rating.Awareness / 3 + driver.DriverInfo.Rating.Pace * 5, driver.DriverInfo.Rating.Awareness + ((driver.DriverInfo.Rating.Experience + driver.DriverInfo.Rating.Racecraft) / 3) + driver.DriverInfo.Rating.Pace * 5);
                driver.Time = randomScore + randomSeed;
            }
            grid.Sort((x, y) => y.Time.CompareTo(x.Time));
            for (int i = 0; i < grid.Count; i++)
            {
                grid[i].Time = i;
                grid[i].Time /= 2;
            }
            return grid;
        }
        /*public static List<Grid> UpdateRace(List<Grid> grid)
        {
            foreach(var driver in grid)
            {

            }
        }*/
        public class Grid
        {
            public Driver DriverInfo { get; set; }
            public double Time { get; set; }
        }
    }
}
