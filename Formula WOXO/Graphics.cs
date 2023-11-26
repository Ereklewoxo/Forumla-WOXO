using System;
using System.Linq;
using System.Numerics;
using static Formula_WOXO.Util;
using static Formula_WOXO.Color;
using static Formula_WOXO.Database;
using System.Text;

namespace Formula_WOXO
{
    public static class Graphics
    {
        public static void DrawScrollBar(int x, int y, int numberOfElements, int onScreen, int scrollBase, string color)
        {
            StringBuilder stringBuilder = new();
            for (int i = 0; i < scrollBase; i++)
            {
                stringBuilder.Append("  \n");
            }
            stringBuilder.Append("╭╮\n");
            for (int i = 0; i < onScreen - (numberOfElements - onScreen) - 2; i++)
            {
                stringBuilder.Append("││\n");
            }
            stringBuilder.Append("╰╯\n");
            for (int i = 0; i < (numberOfElements - onScreen) - scrollBase; i++)
            {
                stringBuilder.Append("  \n");
            }
            WriteAt(x, y, FromHex(color) + stringBuilder.ToString());
        }
        public static void WriteHeaderGPName(int selected, string color)
        {
            string headerName = Util.WriteHeader(Database.GrandsPrix[selected].Name);
            var splitHeaderName = headerName.Split('\n');
            WriteAt(Console.WindowWidth - splitHeaderName[0].Length - 1, 9, FromHex(color) + headerName);
        }
        public static void DrawCircuitMap(int x, int y, int selected, string color)
        {
            string circuit = CircuitMaps()[selected];
            var splitCircuit = circuit.Split('\n');
            int adjustX = 0;
            foreach (var line in splitCircuit)
                adjustX = Math.Max(adjustX, line.Length);
            adjustX = Math.Max(0, (40 - adjustX) / 2);
            int adjustY = splitCircuit.Length - 1;
            WriteAt(x + adjustX, y + (10 - adjustY), FromHex(color) + circuit);
        }
        public static void DrawTeamLogo(int teamIndex, int x, int y)
        {
            if (teamIndex <= TeamLogos.Count)
            {
                foreach(var line in TeamLogos[teamIndex]) 
                {
                    Console.SetCursorPosition(x + line.Indentation, y);
                    Console.Write(line.Line);
                    y++;
                }
            }
        }
        public static void DrawInitialF1Logo()
        {
            bool pulse = false;
            int i = 225, windowSize = Console.WindowWidth + Console.WindowHeight,
                x = Console.WindowWidth / 2 - 19,
                y = Console.WindowHeight / 2 - 6;
            Task.Delay(1000).Wait();
            DrawLogo(2, 42, 0, true);
            ClearKey();
            while (true)
            {
                Console.Write(FromRgb(i, 0, 0));
                DrawLogo(0, x, y, false);
                i = pulse ? Math.Min(225, i + 2) : Math.Max(0, i - 2);
                pulse = i is 225 || i is 0 ? !pulse : pulse;
                if (Console.KeyAvailable)
                    break;
                if (Console.WindowWidth + Console.WindowHeight != windowSize)
                {
                    Util.ClearConsole();
                    x = Console.WindowWidth / 2 - 19; y = Console.WindowHeight / 2 - 6;
                    windowSize = Console.WindowWidth + Console.WindowHeight;
                }
                Task.Delay(1).Wait();
            }
            for (int j = 0; j < 4;)
            {
                Console.Write(FromRgb(i, 0, 0));
                DrawLogo(0, x, y, false);
                i = pulse ? Math.Min(225, i + 20) : Math.Max(0, i - 20);
                pulse = i is 225 || i is 0 ? !pulse : pulse;
                if (i > 224 || i < 1)
                    j++;
                if (Console.WindowWidth + Console.WindowHeight != windowSize)
                {
                    Util.ClearConsole();
                    x = Console.WindowWidth / 2 - 19; y = Console.WindowHeight / 2 - 6;
                    windowSize = Console.WindowWidth + Console.WindowHeight;
                }
                Task.Delay(1).Wait();
            }
            DrawLogo(2, 42, 0, false);
            ClearKey();
        }
        public static void DrawLogo(int logoIndex, int x, int y, bool animation)
        {
            if (logoIndex is 0)
            {
                if (animation)
                {
                    string[] gradientColors = ColorTools.ColorGradient("#e10600", "#ffffff", 42);
                    string[] gradientColorsReversed = gradientColors.Reverse().ToArray();
                    int originalY = y, nyan = 0, numColors = gradientColors.Length;
                    bool loop = true;
                    while (true)
                    {
                        foreach (var line in F1Logo)
                        {
                            Console.SetCursorPosition(x + line.Indentation, y);
                            for (int i = 0; i < line.Line.Length; i++)
                            {
                                int colorIndex = (line.Indentation + i + nyan) % (2 * numColors - 2);

                                if (colorIndex >= numColors)
                                    colorIndex = numColors - 2 - (colorIndex - numColors);

                                char character = line.Line[i];

                                if (loop)
                                    Console.Write(Color.FromHex(gradientColors[colorIndex]) + $"{character}");
                                else
                                    Console.Write(Color.FromHex(gradientColorsReversed[colorIndex]) + $"{character}");
                            }
                            y++;
                        }
                        Task.Delay(4).Wait();
                        y = originalY;
                        if (nyan < numColors - 1)
                            nyan++;
                        else
                        {
                            nyan = 0;
                            loop = !loop;
                        }
                    }
                }
                else
                {
                    foreach (var line in F1Logo2)
                    {
                        Console.SetCursorPosition(x + line.Indentation, y);
                        Console.Write(line.Line);
                        y++;
                    }
                }
            }
            else if (logoIndex is 1)
            {
                string[] gradientColors = ColorTools.ColorGradient("#07ECF4", "#A91C83", 42);
                if (animation)
                {
                    string[] gradientColorsReversed = gradientColors.Reverse().ToArray();
                    int originalY = y, nyan = 0, numColors = gradientColors.Length;
                    bool loop = true;
                    while (true)
                    {
                        foreach (var line in F1AcademyLogo)
                        {
                            Console.SetCursorPosition(x + line.Indentation, y);
                            for (int i = 0; i < line.Line.Length; i++)
                            {
                                int colorIndex = (line.Indentation + i + nyan) % (2 * numColors - 2);

                                if (colorIndex >= numColors)
                                    colorIndex = numColors - 2 - (colorIndex - numColors);

                                char character = line.Line[i];

                                if (loop)
                                    Console.Write(Color.FromHex(gradientColors[colorIndex]) + $"{character}");
                                else
                                    Console.Write(Color.FromHex(gradientColorsReversed[colorIndex]) + $"{character}");
                            }
                            y++;
                        }
                        Task.Delay(4).Wait();
                        y = originalY;
                        if (nyan < numColors - 1)
                            nyan++;
                        else
                        {
                            nyan = 0;
                            loop = !loop;
                        }
                    }
                }
                else
                {
                    foreach (var line in F1AcademyLogo)
                    {
                        Console.SetCursorPosition(x + line.Indentation, y);
                        for (int j = 0; j < line.Line.Length; j++)
                        {
                            char character = line.Line[j];
                            Console.Write(Color.FromHex(gradientColors[line.Indentation + j]) + $"{character}");
                        }
                        y++;
                    }
                }
            }
            else if (logoIndex is 2)
            {
                var anim = F1LogoAnimation;
                if (animation)
                {
                    anim.Reverse();
                    int originalY = y;
                    for (int i = 0; i < anim.Count; i++)
                    {
                        Console.Write(FromRgb(15 + i * 10, 0, 0));
                        foreach (var line in anim[i])
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(line);
                            y++;
                        }
                        if (i % 2 is 1)
                            y = Console.CursorTop - anim[i].Count + 1;
                        else
                            y = Console.CursorTop - anim[i].Count;
                        Task.Delay(15).Wait();
                        Util.ClearConsole(0, 15);
                    }
                }
                else
                {
                    y += 10;
                    int originalY = y;
                    for (int i = anim.Count - 1; i >= 0; i--)
                    {
                        Console.Write(FromRgb(15 + i * 10, 0, 0));
                        foreach (var line in anim[i])
                        {
                            Console.SetCursorPosition(x, y);
                            Console.WriteLine(line);
                            y++;
                        }
                        if (i % 2 is 1)
                            y = Console.CursorTop - anim[i].Count;
                        else
                            y = Console.CursorTop - anim[i].Count - 1;
                        Task.Delay(15).Wait();
                        Util.ClearConsole(0, 15);
                    }
                }
            }
        }

        private readonly static List<List<string>> F1LogoAnimation = new()
        {
            new(){
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "   ▄████▀ ▄█████████████▀ ▄██████▀",
                " ▄████▀ ▄████▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "▀▀▀▀▀  ▀▀▀▀▀           ▀▀▀▀▀▀▀"
            },
            new(){
                "                                ▄▄▄▄▄▄▄",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "   ▄████▀ ▄█████████████▀ ▄██████▀",
                " ▄████▀ ▄████▀▀▀▀▀▀▀▀▀▀ ▄██████▀"
            },
            new(){
                "                                ▄██████▀",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "   ▄████▀ ▄█████████████▀ ▄██████▀",
                "  ▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀"
            },
            new(){
                "                                  ▄▄▄▄▄▄▄",
                "                                ▄██████▀",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "   ▄████▀ ▄█████████████▀ ▄██████▀",
                "  ▀▀▀▀▀  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "   ▄████▀ ▄███████████████ ▀▀▀▀▀▀▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                    ▄▄▄▄▄▄▄",
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀",
                "    ▀▀▀▀▀ ▄████████████████▄",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
                },
            new(){
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "       ▄▄███████████████████▀ ▄██████▀",
                "     ▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀  ▀▀▀▀▀▀▀",
                "          ▄████████████████████▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                      ▄▄▄▄▄▄▄",
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "       ▄▄████████████████████ ▄██████▀",
                "      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "          ▄█████████████████████▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "       ▄▄█████████████████████ ▀▀▀▀▀▀▀",
                "      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "          ▄██████████████████████▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                        ▄▄▄▄▄▄▄",
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "                                ▄██████▀",
                "         ▄█████████████████████▄▄▄▄▄▄▄",
                "        ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "          ▄███████████████████████▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "                                 ▀▀▀▀▀▀▀",
                "          ▄████████████████████████████▀",
                "         ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "           ▄███████████████████████▀",
                "          ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                          ▄▄▄▄▄▄▄",
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "                                  ▄██████▀",
                "",
                "           ▄████████████████████████████▀",
                "          ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "            ▄███████████████████████▀",
                "           ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "                                   ▀▀▀▀▀▀▀",
                "",
                "            ▄████████████████████████████▀",
                "           ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "             ▄███████████████████████▀",
                "            ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                            ▄▄▄▄▄▄▄",
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "                                    ▄██████▀",
                "",
                "",
                "             ▄████████████████████████████▀",
                "            ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "              ▄███████████████████████▀",
                "             ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "                                     ▀▀▀▀▀▀▀",
                "",
                "",
                "              ▄████████████████████████████▀",
                "             ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "               ▄███████████████████████▀",
                "              ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                              ▄▄▄▄▄▄▄",
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "                                      ▄██████▀",
                "",
                "",
                "",
                "               ▄████████████████████████████▀",
                "              ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                ▄███████████████████████▀",
                "               ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                              ▄██████▀",
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "                                       ▀▀▀▀▀▀▀",
                "",
                "",
                "",
                "                ▄████████████████████████████▀",
                "               ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                 ▄███████████████████████▀",
                "                ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                                ▄▄▄▄▄▄▄",
                "                                              ▄██████▀",
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "                                        ▄██████▀",
                "",
                "",
                "",
                "",
                "                 ▄████████████████████████████▀",
                "                ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                  ▄███████████████████████▀",
                "                 ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                                ▄██████▀",
                "                                              ▄██████▀",
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "                                         ▀▀▀▀▀▀▀",
                "",
                "",
                "",
                "",
                "                  ▄████████████████████████████▀",
                "                 ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                   ▄███████████████████████▀",
                "                  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                                  ▄▄▄▄▄▄▄",
                "                                                ▄██████▀",
                "                                              ▄██████▀",
                "                                            ▄██████▀",
                "                                          ▄██████▀",
                "",
                "",
                "",
                "",
                "",
                "                   ▄████████████████████████████▀",
                "                  ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                    ▄███████████████████████▀",
                "                   ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
            new(){
                "                                                  ▄██████▀",
                "                                                ▄██████▀",
                "                                              ▄██████▀",
                "                                            ▄██████▀",
                "                                           ▀▀▀▀▀▀▀",
                "",
                "",
                "",
                "",
                "",
                "                    ▄████████████████████████████▀",
                "                   ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀",
                "                     ▄███████████████████████▀",
                "                    ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀"
            },
        };

        private readonly static List<LogoLine> F1Logo = new()
        {
                new LogoLine(       "▄▄███████████████████▀ ▄██████▀", 7),
                new LogoLine(     "▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 5),
                new LogoLine(   "▄████▀ ▄█████████████▀ ▄██████▀", 3),
                new LogoLine( "▄████▀ ▄████▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 1),
                new LogoLine("▀▀▀▀▀  ▀▀▀▀▀           ▀▀▀▀▀▀▀", 0),
                new LogoLine("PRESS ANY KEY", 12)
        };

        private readonly static List<LogoLine> F1Logo2 = new()
        {
                new LogoLine(       "▄▄███████████████████▀ ▄██████▀", 7),
                new LogoLine(     "▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 5),
                new LogoLine(   "▄████▀ ▄█████████████▀ ▄██████▀", 3),
                new LogoLine( "▄████▀ ▄████▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 1),
                new LogoLine("▀▀▀▀▀  ▀▀▀▀▀           ▀▀▀▀▀▀▀", 0)
        };
        
        private readonly static List<LogoLine> F1AcademyLogo = new()
        {
                new LogoLine(         "▄▄███████████████████▀ ▄██████▀", 9),
                new LogoLine(       "▄████▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 7),
                new LogoLine(     "▄████▀ ▄█████████████▀ ▄██████▀", 5),
                new LogoLine(   "▄████▀ ▄████▀▀▀▀▀▀▀▀▀▀ ▄██████▀", 3),
                new LogoLine(  "▀▀▀▀▀  ▀▀▀▀▀           ▀▀▀▀▀▀▀", 2),
                new LogoLine("╭───╮╭──── ╭───╮┌────╮╭────┬─╮   ╭─┬╮   ╭", 0),
                new LogoLine("│   ││     │   ││    │├───╴│ ╰─┰─╯ │╰─┬─╯", 0),
                new LogoLine("╵   ╰╰─────╯   ╰┴────╯╰────┘       ╵  ╵", 0)
        };

        private readonly static List<List<LogoLine>> TeamLogos = new()
        {
            new()
            {
                new LogoLine(                     "▄▄", 21),
                new LogoLine(     "▄▄▄▄           █▀", 5),
                new LogoLine(   "████████▄▄▄       ▀█", 3),
                new LogoLine(  "████████████████▄▄█▀", 2),
                new LogoLine("▄▄█▀█ ▀████▐████▌███", 0),
                new LogoLine(   "▀▀   ▄██      ▀███▄", 3),
                new LogoLine(        "▀█▄▄       ▀▀▀██", 8)
            },
            new()
            {
                new LogoLine(      "▄▄██████▄▄", 6),
                new LogoLine(   "▄█▀▀   ▐▌   ▀▀█▄", 3),
                new LogoLine(  "█▀      ▐▌      ▀█", 2),
                new LogoLine( "█▀       ██       ▀█", 1),
                new LogoLine("█▀       ▐██▌       ▀█", 0),
                new LogoLine("█       ▄████▄       █", 0),
                new LogoLine("█▄   ▄▄██▀▀▀▀██▄▄   ▄█", 0),
                new LogoLine( "█▄▄█▀▀        ▀▀█▄▄█", 1),
                new LogoLine(  "█▄              ▄█", 2),
                new LogoLine(   "▀█▄▄        ▄▄█▀", 3),
                new LogoLine(      "▀▀██████▀▀", 6),
            },
            new()
            {
                new LogoLine(       "▄▄█▄▄", 7),
                new LogoLine(     "███▄████▀▄", 5),
                new LogoLine(         "████▀▄", 9),
                new LogoLine(       "▄█████▀▄     ▄ ▄", 7),
                new LogoLine(  "▄██▄██████▄▀▄    █ █", 2),
                new LogoLine("▄█▀ ▀███████▄      ██", 0),
                new LogoLine("▀  ▄█████████▄     ▌█", 0),
                new LogoLine(   "█▄ ▀████████▄  ▄█▀", 3),
                new LogoLine(    "▀   ▀███████▄█▀", 4),
                new LogoLine(         "▀█▌████▀█▄", 9),
                new LogoLine(          "▀█▐██  ▀ ▀", 10),
                new LogoLine(      "▄█▀▀▀▀ █", 6),
                new LogoLine(           "▄█▀", 11),
                new LogoLine(          "▀▀", 10)
            },
            new()
            {
                new LogoLine(            "▄▄▄▄██████▄", 12),
                new LogoLine(      "▄▄▄██████████████", 6),
                new LogoLine(  "▄▄█████████████████▀", 2),
                new LogoLine("▀▀▀         ▀▀█████▀", 0),
                new LogoLine(               "██▀", 15),
                new LogoLine(             "▄█▀", 13)
            },
            new()
            {
                new LogoLine("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄    ▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄", 0),
                new LogoLine("▀▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄▄█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▀", 0),
                new LogoLine( "▀▄▄▄▄▄▄██ ASTON MARTIN ██▄▄▄▄▄▄▀", 1),
                new LogoLine(    "▀▄▄█▄▀█▀█▀▀█▀▀█▀▀█▀█▀▄█▄▄▀", 4),
                new LogoLine(        "▀█▄█▄▄█▄▀▀▄█▄▄█▄█▀", 8)
            },
            new()
            {
                new LogoLine(                "▄▄▄▄", 16),
                new LogoLine(              "▄█████", 14),
                new LogoLine(            "▄███▀███", 12),
                new LogoLine(          "▄███▀  ███", 10),
                new LogoLine(  "▄█    ▄███▀   ███▀", 2),
                new LogoLine("▄█████████████████████▀", 0),
                new LogoLine(    "▄███▀       ███", 4),
                new LogoLine(   "▀▀▀▀         ▀▀▀", 3)
            },
            new()
            {
                new LogoLine("▄▄▄        ▄▄        ▄▄▄", 0),
                new LogoLine("▀███      ▄██▄      ███▀", 0),
                new LogoLine( "▀███    ▄████▄    ███▀", 1),
                new LogoLine(  "▀███   ██████   ███▀", 2),
                new LogoLine(   "▀███ ███  ███ ███▀", 3),
                new LogoLine(    "▀█ ███    ███ █▀", 4),
                new LogoLine(      "███      ███", 6),
                new LogoLine(      "▀█        █▀", 6)
            },
            new()
            {
                new LogoLine(  "▄▄██████▄  ▄▄███▌██████████", 2),
                new LogoLine( "████████▀ ▄██████▌█████████▀", 1),
                new LogoLine("█████▀▀▀▀ ████▀▀    ▀████▀▀▀", 0),
                new LogoLine("█████    █████        ███", 0),
                new LogoLine("█████▄▄▄▄█████   ▄█ ▀▄▄▄█", 0),
                new LogoLine( "████████████▀ ▄▄▄ █████", 1),
                new LogoLine(  "▀▀██████▀▀  ▀█▄▄▌██▀▀", 2)
            },
            new()
            {
                new LogoLine(      "▄▄██████▄▄", 6),
                new LogoLine(   "▄█▀▀█████▄▄▄███▄", 3),
                new LogoLine(  "███  ███▀█▄▄   ▀██", 2),
                new LogoLine( "████  █████▄▄▄▄   ██", 1),
                new LogoLine("█████  █████▀     ▄███", 0),
                new LogoLine("█          ▌  ▀▀▀█████", 0),
                new LogoLine("█████  █████▄     ▀███", 0),
                new LogoLine( "████  ██████▀▀▀▀  ██", 1),
                new LogoLine(  "███  █████   ▄▄▄██", 2),
                new LogoLine(   "▀█▄▄██████▄▄▄▄█▀", 3),
                new LogoLine(      "▀▀██████▀▀", 6),
            },
            new()
            {
                new LogoLine(         "▄▄████▄▄", 9),
                new LogoLine(      "▄██▀▀    ▀▀██▄", 6),
                new LogoLine(     "██▀    ▄██   ███", 5),
                new LogoLine(    "██     ▄██   ▄████", 4),
                new LogoLine(   "██     ▄██   ▄██  ██", 3),
                new LogoLine(   "██    ▄██   ▄██   ██", 3),
                new LogoLine("▄██████████ █████   ██", 0),
                new LogoLine(    "▀██▄██    ██  ▄██", 4),
                new LogoLine(      "▀██▄▄    ▄▄██▀", 6),
                new LogoLine(         "▀▀████▀▀", 9)
            }
        };
        public static void DrawPortrait(int driver, int x, int y)
        {
            foreach (var line in Portrait(driver))
            {
                Console.SetCursorPosition(x, y);
                Console.WriteLine(line);
                y++;
            }
            Console.Write(FromHex("#ffffff"));
        }
        public static void DrawPortrait(int x, int y, Menu.UserPortrait userPortrait, bool reverse)
        {
            foreach (var line in UserPortrait(userPortrait))
            {
                if (reverse)
                {
                    int test = 16;
                    foreach (char c in line)
                    {
                        if (c is '█' or ' ' or '▀' or '▄')
                        {
                            Console.SetCursorPosition(x + test, y);
                            Console.Write(c);
                            test = Math.Max(test - 1, 0);
                        }
                        else
                            Console.Write(c);
                    }
                    y++;
                }
                else
                {
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(line);
                    y++;
                }
            }
            Console.Write(FromHex("#ffffff"));
        }
        private static List<string> UserPortrait(Menu.UserPortrait userPortrait)
        {
            string hair = FromHex(userPortrait.HairColor),
                   skin = FromHex(userPortrait.SkinColor), 
                   skinBG = FromHexBackground(userPortrait.SkinColor), 
                   fHair = FromHex(userPortrait.FacialHairColor), 
                   fHairBG = FromHexBackground(userPortrait.FacialHairColor),
                   neck = FromHexBackground(ColorTools.DarkenColor(userPortrait.SkinColor, 0.2)),
                   bG = FromHexBackground("#212121"), fG = FromHex("#212121");
            List<string> hairSelection;
            List<string> facialHairSelection;
            switch (userPortrait.Hairstyle)
            {
                case 0:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 1:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair + skinBG}▀       ▀{bG + fG}█   "
                    };
                    break;
                case 3:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 2:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair + fHairBG}▀{skinBG}       {fHairBG}▀{bG + fG}█   "
                    };
                    break;
                case 4:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {fHair}█{skin}███████{fHair}█    "
                    };
                    break;
                case 7:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}██{skinBG}▀▀█▀{hair + bG}███    ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 8:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀████{bG + fG}█   ",
                        $"    {hair + fHairBG}▀{skinBG}     ▀▀{fHairBG}▀{bG + fG}█   "
                    };
                    break;
                case 13:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀{hair + bG}█    ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 14:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀█{bG + fG}█   ",
                        $"    {hair + skinBG}▀       ▀{bG + fG}    "
                    };
                    break;
                case 15:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀{hair + bG}█    ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 5:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}███{skinBG}▀▀▀▀{hair + bG}██    ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 12:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"    {skinBG}█▀     ▀█{bG + fG}█   "
                    };
                    break;
                case 11:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    █████████    ",
                        $"    {fHair}█{skin}███████{fHair}█    "
                    };
                    break;
                case 19:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"   {hair}▄█████████▄   ",
                        $"   ▀{skinBG}█▀     ▀█{bG}▀{fG}█  "
                    };
                    break;
                case 20:
                    hairSelection = new() {
                        $"{hair + bG}    ▄▄▄▄▄▄▄▄▄    ",
                        $"  {hair}▄███████████▄  ",
                        $"  ▀{skinBG}██▀     ▀██{bG}▀{fG}█ "
                    };
                    break;
                case 10:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 9:
                    hairSelection = new() {
                        $"{hair + bG}    ▄▄▄▄▄▄▄▄▄    ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 6:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {skinBG}███▀▀▀▀██{bG + fG}█   ",
                        $"    {skinBG + hair}██▀    ▀█{bG + fG}█   "
                    };
                    break;
                case 16:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"   {hair}███████████   "
                    };
                    break;
                case 17:
                    hairSelection = new() {
                        $"{skin + bG}     ▄{hair}▄▄{skin}▄{hair}▄▄{skin}▄     ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin}█████████    " 
                    };
                    break;
                case 18:
                    hairSelection = new() {
                        $"{skin + bG}     ▄{hair}▄{skin}▄{hair}▄{skin}▄{hair}▄{skin}▄     ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 23:
                    hairSelection = new() {
                        $"{hair + bG}     ▄{skin}▄▄▄▄▄{hair}▄     ",
                        $"    {hair}█{skinBG}▀{skin}▀▀▀▀▀{hair}▀{bG}█    ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 24:
                    hairSelection = new() {
                        $"{hair + bG}  ▄▄▄▄▄▄▄▄▄▄▄▄▄  ",
                        $"   {hair + skinBG}███▀▀▀▀▀███{bG + fG}█  ",
                        $"    {hair}█{skin}███████{hair}█    "
                    };
                    break;
                case 25:
                    hairSelection = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {skin + skinBG}█{hair}▀▀▀▀▀▀▀{skin + bG}█    ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 26:
                    hairSelection = new() {
                        $"{skin + bG}     ▄{hair}▄▄▄▄▄{skin}▄     ",
                        $"    {skin + skinBG}██{hair}▀███▀{skin + bG}██    ",
                        $"    {skin}█████████    "
                    };
                    break;
                case 21:
                    hairSelection = new() {
                        $"{hair + bG}  ▄▄▄▄▄▄▄▄▄▄▄▄▄  ",
                        $" {hair + skinBG}█████▀▀▀▀▀█████{bG} ",
                        $"  {hair}▀▀{skinBG}▀       ▀{bG}▀▀{fG}█ "
                    };
                    break;
                case 22:
                    hairSelection = new() {
                        $"{hair + bG}  ▄▄▄▄{skin}▄▄▄▄▄{hair}▄▄▄▄  ",
                        $" {hair + skinBG}█████     █████{bG} ",
                        $"  {hair}▀▀{skinBG}▀       ▀{bG}▀▀{fG}█ "
                    };
                    break;
                default:
                    hairSelection = new() {
                        $"{skin + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {skin}█████████    ",
                        $"    {skin}█████████    "
                    };
                    break;
            }
            switch (userPortrait.FacialHairStyle)
            {
                case 0:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 1:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}▀█▀▄▄▄▀█▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀▀▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 2:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}▀█▀▄▄▄▀█▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀ ▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 3:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}▀▀▀ ▀▀▀{bG + fHair}▀    "
                    };
                    break;
                case 4:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}▀▀▀▀▀▀▀{bG + fHair}▀    "
                    };
                    break;
                case 5:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {skin}▀{fHairBG}▀▀▀ ▀▀▀{bG}▀    "
                    };
                    break;
                case 6:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {skin}▀{fHairBG}▀▀▀▀▀▀▀{bG}▀    "
                    };
                    break;
                case 7:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {skin}▀{fHairBG}███ ███{bG}▀    "
                    };
                    break;
                case 8:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {skin}▀{fHairBG}███ ███{bG}▀    "
                    };
                    break;
                case 9:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}▄███████▄{bG + fG}█   ",
                        $"    {skin}▀{fHairBG}▀▀▀▀▀▀▀{bG}▀    "
                    };
                    break;
                case 10:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG} ███████ {bG + fG}█   ",
                        $"    {skin}▀{fHairBG}▀▀▀▀▀▀▀{bG}▀    "
                    };
                    break;
                case 11:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG} █▀▄▄▄▀█ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 12:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG} █▀▄▄▄▀█ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀▀▀  {bG + fHair}▀    "
                    };
                    break;
                case 13:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}▀█ ▄▄▄ █▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 14:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}▀█ ▄▄▄ █▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀▀▀  {bG + fHair}▀    "
                    };
                    break;
                case 15:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀▀▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 16:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀ ▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 17:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {skin}▀{fHairBG}▀▀▀▀▀▀▀{bG}▀    "
                    };
                    break;
                case 18:
                    facialHairSelection = new() {
                        $"    {fHair}█{skin + fHairBG}▀█▀▀▀█▀{fHair}█{bG + fG}█   ",
                        $"    {fHair}▀{skinBG}██▄▄▄██{bG}▀    "
                    };
                    break;
                case 19:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                                  $"    {skin}▀███████▀    "
                    };
                    break;
                case 20:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██ ▄▄▄ ██{bG + fG}█   ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 21:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                         $"    {skin}▀{fHairBG}█ ▀▀▀ █{bG}▀    "
                    };
                    break;
                case 22:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██ ▄▄▄ ██{bG + fG}█   ",
                         $"    {skin}▀{fHairBG}█ ▀▀▀ █{bG}▀    "
                    };
                    break;
                case 23:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                         $"    {skin}▀{fHairBG}█ ▀ ▀ █{bG}▀    "
                    };
                    break;
                case 24:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG}██ ▄▄▄ ██{bG + fG}█   ",
                         $"    {skin}▀{fHairBG}█ ▀ ▀ █{bG}▀    "
                    };
                    break;
                case 25:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG} ▀ ▄▄▄ ▀ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 26:
                    facialHairSelection = new() {
                        $"    {skin + fHairBG} ▀ ▄▄▄ ▀ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀▀▀  {bG + fHair}▀    "
                    };
                    break;
                case 27:
                    facialHairSelection = new() {
                        $"    {fHair}█{skin + fHairBG}█▀▀▀▀▀█{fHair}█{bG + fG}█   ",
                        $"    {fHair}▀{skinBG}██▄▄▄██{bG}▀    "
                    };
                    break;
                default:
                    facialHairSelection = new() {
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
            }
            facialHairSelection.AddRange(PortraitUniform(10, neck));
            hairSelection.AddRange(facialHairSelection);
            hairSelection[hairSelection.Count - 1] += FromHexBackground("#000000");
            return hairSelection;
        }
        private static List<string> Portrait(int driver)
        {
            string hair, skin, skinBG, fHair, fHairBG, neck = FromHexBackground("#65676b"),
                   bG = FromHexBackground("#212121"), fG = FromHex("#212121");
            if (driver < 20)
            {
                bG = FromHexBackground(ColorTools.DarkenColor(Constructors[driver / 2].Color, 0.4));
                fG = FromHex(ColorTools.DarkenColor(Constructors[driver / 2].Color, 0.4));
            }
            List<string> portrait = new() { };
            switch (driver)
            {
                case 0:
                    hair = FromHex("#5c4237"); skin = FromHex("#d29a8a"); skinBG = FromHexBackground("#d29a8a");
                    fHair = FromHex("#985e54"); fHairBG = FromHexBackground("#985e54"); neck = FromHexBackground("#d1a294");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}███{skinBG}▀▀▀▀{hair + bG}██    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG}▀█▀▄▄▄▀█▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀▀▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 1:
                    hair = FromHex("#0b0907"); skin = FromHex("#d19c81"); skinBG = FromHexBackground("#d19c81");
                    fHair = FromHex("#8d5844"); fHairBG = FromHexBackground("#8d5844"); neck = FromHexBackground("#59392c");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀{hair + bG}█    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG}▀█▀▄▄▄▀█▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG} ▀▀ ▀▀ {bG + fHair}▀    "
                    };
                    break;
                case 2:
                    hair = FromHex("#1f0f09"); skin = FromHex("#9c5f49"); fHairBG = FromHexBackground("#1f0f09"); neck = FromHexBackground("#6b3627");
                    portrait = new() {
                        $"{skin + bG}     ▄{hair}▄▄{skin}▄{hair}▄▄{skin}▄     ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin}█████████    ",
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {hair}▀{skin + fHairBG}▀▀▀ ▀▀▀{bG + hair}▀    "};
                    break;
                case 3:
                    hair = FromHex("#241c17"); skin = FromHex("#d7a68e"); skinBG = FromHexBackground("#d7a68e"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                        $"{hair + bG}    ▄▄▄▄▄▄▄▄▄    ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 4:
                    hair = FromHex("#2f1e1e"); skin = FromHex("#c7958b"); skinBG = FromHexBackground("#c7958b");
                    fHair = FromHex("#ab7367"); fHairBG = FromHexBackground("#ab7367"); neck = FromHexBackground("#c7958b");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}██{skinBG}▀▀█▀{hair + bG}███    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG}▀█▀▄▄▄▀█▀{bG + fG}█   ",
                        $"    {fHair}▀{skinBG}█▄▄█▄▄█{bG}▀    "
                    };
                    break;
                case 5:
                    hair = FromHex("#1c0d0d"); skin = FromHex("#c99478"); skinBG = FromHexBackground("#c99478"); neck = FromHexBackground("#bb886d");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 6:
                    hair = FromHex("#1c0d0d"); skin = FromHex("#d09c85"); skinBG = FromHexBackground("#d09c85");
                    fHairBG = FromHexBackground("#815d48"); neck = FromHexBackground("#ca9074");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"   {hair}▄█████████▄   ",
                        $"   ▀{skinBG}█▀     ▀█{bG}▀{fG}█  ",
                        $"    {skin + fHairBG}▄███████▄{bG + fG}█   ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 7:
                    hair = FromHex("#36271e"); skin = FromHex("#d7a68e"); skinBG = FromHexBackground("#d7a68e");
                    fHairBG = FromHexBackground("#815d48"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                            $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀████{bG + fG}█   ",
                        $"    {hair + fHairBG}▀{skinBG}     ▀▀{fHairBG}▀{bG + fG}█   ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 8:
                    hair = FromHex("#36271e"); skin = FromHex("#c7958b"); skinBG = FromHexBackground("#c7958b");
                    fHair = FromHex("#805b53"); fHairBG = FromHexBackground("#805b53"); neck = FromHexBackground("#b97b6f");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG} █▀▄▄▄▀█ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 9:
                    hair = FromHex("#1c0d0d"); skin = FromHex("#d09c85"); skinBG = FromHexBackground("#d09c85");
                    fHairBG = FromHexBackground("#815d48"); neck = FromHexBackground("#ca9074");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"    {skinBG}█▀     ▀█{bG + fG}█   ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 10:
                    hair = FromHex("#36271e"); skin = FromHex("#d7a68e");
                    fHair = FromHex("#967b6c"); fHairBG = FromHexBackground("#967b6c"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    █████████    ",
                        $"    {fHair}█{skin}███████{fHair}█    ",
                        $"    {skin + fHairBG}▀█ ▄▄▄ █▀{bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 11:
                    hair = FromHex("#1c0d0d"); skin = FromHex("#d7a68e"); skinBG = FromHexBackground("#d7a68e");
                    fHairBG = FromHexBackground("#967b6c"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                            $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {hair + fHairBG}▀{skinBG}       {fHairBG}▀{bG + fG}█   ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 12:
                    hair = FromHex("#b99c8a"); skin = FromHex("#c99478"); skinBG = FromHexBackground("#c99478");
                    fHair = FromHex("#826a5b"); neck = FromHexBackground("#aa7458");
                    portrait = new() {
                            $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {fHair}█{skin}███████{fHair}█    ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 13:
                    hair = FromHex("#36271e"); skin = FromHex("#d7a68e"); skinBG = FromHexBackground("#d7a68e");
                    fHair = FromHex("#826a5b"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                            $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair + skinBG}██▀▀▀▀▀██{bG + fG}█   ",
                        $"    {fHair}█{skin}███████{fHair}█    ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 14:
                    hair = FromHex("#100c08"); skin = FromHex("#d7a68e"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"   {hair}▐█████████▌   ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀{bG}    "
                    };
                    break;
                case 15:
                    hair = FromHex("#241c17"); skin = FromHex("#c4967e"); skinBG = FromHexBackground("#c4967e");
                    fHair = FromHex("#805b53"); fHairBG = FromHexBackground("#805b53"); neck = FromHexBackground("#9f7763");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀{hair + bG}█    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {fHair}█{skin + fHairBG}▀█▀▀▀█▀{fHair}█{bG + fG}█   ",
                        $"    {fHair}▀{skinBG}██▄▄▄██{bG}▀    "
                    };
                    break;
                case 16:
                    hair = FromHex("#846748"); skin = FromHex("#d09790"); skinBG = FromHexBackground("#d09790");
                    fHair = FromHex("#846748"); fHairBG = FromHexBackground("#846748"); neck = FromHexBackground("#ca9086");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}██{skinBG}▀▀▀▀▀{hair + bG}██    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG}██▀▄▄▄▀██{bG + fG}█   ",
                        $"    {fHairBG + skin}▀███████▀{bG}    "
                    };
                    break;
                case 17:
                    hair = FromHex("#000000"); skin = FromHex("#d19f8c"); skinBG = FromHexBackground("#d19f8c"); neck = FromHexBackground("#c99380");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {skinBG}███▀▀▀▀██{bG + fG}█   ",
                        $"    {skinBG + hair}██▀    ▀█{bG + fG}█   ",
                        $"    {skinBG + hair}▀{skin}████████{bG + fG}█   ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
                case 18:
                    hair = FromHex("#a78c66"); skin = FromHex("#d7a68e"); skinBG = FromHexBackground("#d7a68e");
                    fHair = FromHex("#a78c66"); fHairBG = FromHexBackground("#a78c66"); neck = FromHexBackground("#d09c85");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█{skinBG}▀▀▀▀▀▀▀{hair + bG}█    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {skin + fHairBG} ▀ ▄▄▄ ▀ {bG + fG}█   ",
                        $"    {fHair}▀{skin + fHairBG}  ▀ ▀  {bG + fHair}▀    "
                    };
                    break;
                case 19:
                    hair = FromHex("#705a49"); skin = FromHex("#c79285"); skinBG = FromHexBackground("#c79285");
                    fHair = FromHex("#a7786a"); fHairBG = FromHexBackground("#a7786a"); neck = FromHexBackground("#c58e80");
                    portrait = new() {
                        $"{hair + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {hair}█████████    ",
                        $"    {hair}█{skin}███████{hair}█    ",
                        $"    {fHair}█{skin + fHairBG}█▀▀▀▀▀█{fHair}█{bG + fG}█   ",
                        $"    {fHair}▀{skinBG}██▄▄▄██{bG}▀    "
                    };
                    break;
                default:
                    skin = FromHex("#c8cbd0");
                    portrait = new() {
                        $"{skin + bG}     ▄▄▄▄▄▄▄     ",
                        $"    {skin}█████████    ",
                        $"    {skin}█████████    ",
                        $"    {skin}█████████    ",
                        $"    {skin}▀███████▀    "
                    };
                    break;
            }
            portrait.AddRange(PortraitUniform(driver / 2, neck));
            portrait[portrait.Count - 1] += FromHexBackground("#000000");
            return portrait;
        }
        private static List<string> PortraitUniform(int team, string neck)
        {
            string collar, uni, uniBG, uni2,
                   bG = FromHexBackground("#212121"), fG = FromHex("#212121"), emblem = FromHex("#212121");
            if (team < 10)
            {
                bG = FromHexBackground(Constructors[team].Color); fG = FromHex(Constructors[team].Color); emblem = FromHex(Constructors[team].Color2);
            }
            List<string> uniform = new();
            switch (team)
            {
                case 0:
                    collar = FromHex("#fc2a2a"); uni = FromHex("#1d304a"); uniBG = FromHexBackground("#1d304a");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" ███{uniBG + emblem}{Constructors[team].Icon}{bG + uni}███████████ " };
                    break;
                case 1:
                    collar = FromHex("#b3e529"); uni = FromHex("#020304"); uniBG = FromHexBackground("#020304");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" ███{uniBG + emblem}{Constructors[team].Icon}           {bG + uni} " };
                    break;
                case 2:
                    uni = FromHex("#d33231"); uni2 = FromHex("#2b2b2b"); uniBG = FromHexBackground("#2b2b2b");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄▄▄▄{bG + fG}      ",
                        $" {uni2}▄█████{uni}███{uni2}██{emblem + uniBG}{Constructors[team].Icon}  {bG + uni2}▄{fG}█",
                        $" {uniBG + uni}▄▄▄▄▄█████▄▄▄▄▄{bG + fG} " };
                    break;
                case 3:
                    collar = FromHex("#000000"); uni = FromHex("#e77221"); uni2 = FromHex("#4c4c4c"); uniBG = FromHexBackground("#e77221");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni2}▄{uni}██████████{uniBG + collar}{Constructors[team].Icon}{bG + uni}██{uni2}▄{bG + fG}█",
                        $" {uni2 + uniBG}█ ▄▄▄▄▄▄▄▄▄▄▄ █{bG + fG} " };
                    break;
                case 4:
                    collar = FromHex("#ffffff"); uni = FromHex("#1a7d74"); uniBG = FromHexBackground("#1a7d74"); emblem = FromHex("#ffffff");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" ███████████{uniBG + emblem}{Constructors[team].Icon}{bG + uni}███ " };
                    break;
                case 5:
                    collar = FromHex("#ff80bf"); uni = FromHex("#15141f"); uni2 = FromHex("#09a2e6"); uniBG = FromHexBackground("#ff80bf");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄▄▄▄{bG + fG}      ",
                        $" {uni}▄{uni2}██{uni}█████████{uni2}██{uni}▄ ",
                        $" {uni}███{collar}███████{uniBG + emblem}{Constructors[team].Icon} {bG}{uni}███ " };
                    break;
                case 6:
                    collar = FromHex("#0aabd4"); uni = FromHex("#282d2e"); uniBG = FromHexBackground("#282d2e");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" ███████████{uniBG + emblem}{Constructors[team].Icon} {bG + uni}██ " };
                    break;
                case 7:
                    collar = FromHex("#242834"); uni = FromHex("#dbdad5"); uniBG = FromHexBackground("#dbdad5");
                    uniform = new() {
                        $"{bG}      {neck + collar}▄▄▄▄▄{bG}      ",
                        $" {collar}▄█████████████▄ ",
                        $" {uni}███{uniBG + emblem}{Constructors[team].Icon}           {bG + fG}█" };
                    break;
                case 8:
                    collar = FromHex("#ffffff"); uni = FromHex("#1a1b1a"); uniBG = FromHexBackground("#1a1b1a");
                    uniform = new() {
                        $"{bG}      {neck + uni}▄▄{collar}▄{uni}▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" ███{uniBG + emblem}{Constructors[team].Icon}           {bG + fG}█" };
                    break;
                case 9:
                    collar = FromHex("#1d1d20"); uni = FromHex("#cfd0d1"); uniBG = FromHexBackground("#cfd0d1"); uni2 = FromHex("#bc192c");
                    uniform = new() {
                        $"{bG}      {neck + collar}▄▄▄▄▄{bG + fG}      ",
                        $" {uni2}▄████{uni}█████{uni2}████▄ ",
                        $" {uni}███{uniBG + emblem}{Constructors[team].Icon}{bG + uni}███████████ " };
                    break;
                default:
                    uni = FromHex("#c8cbd0");
                    uniform = new() {
                        $"{bG}      {uni + neck}▄▄▄▄▄{bG + fG}      ",
                        $" {uni}▄█████████████▄ ",
                        $" {uni}███████████████ " };
                    break;
            }
            return uniform;
        }
        private static List<string> CircuitMaps()
        {
            List<string> circuitMaps = new()
            {
                "   ╭─╮          ╭─╮\n" +
                "   │ ╰─╮       ╭╯ ╰╮\n" +
                "  ╭╯   ╰─╮    ╭╯   ╰╮\n" +
                "  │      │    │     ╰╮\n" +
                " ╭╯      ╰──╮ ╰────╮ ╰╮\n" +
                " ╰╮ ╭───────╯      │  ╰╮\n" +
                "╭─╯ ╰──────────────╯   ╰╮\n" +
                "╰───────────────────────╯",

                "                              ╭────╮\n" +
                "╭───────╮                ╭────╯  ╭─╯\n" +
                "╰──────╮╰───────────╮╭───╯     ╭─╯\n" +
                "       ╰───────────╮╰╯╭───╮  ╭─╯\n" +
                "                   ╰──╯   ╰──╯",

                "  ╭─────╮\n" +
                "╭─╯     ╰─╮\n" +
                "│         ╰╮       ╭─────╮\n" +
                "╰╮         ╰───────╯     ╰──╮\n" +
                " ╰╮                       ╭─╯\n" +
                "  ╰───────╮            ╭──╯\n" +
                "          ╰────────────╯",

                "╭──╮     ╭╮\n" +
                "╰╮ ╰╮    ││\n" +
                " ╰─╮╰────╯╰╮    ╭──╮\n" +
                "   ╰───╮   │  ╭─╯  ╰─╮\n" +
                "       ╰───┼──╯╭───╮ ╰─╮\n" +
                "           ╰───╯   ╰─╮ ╰─╮\n" +
                "                     ╰─╮ ╰╮\n" +
                "                       ╰──╯",

                "              ╭──╮\n" +
                "             ╭╯╭╮│\n" +
                "            ╭╯ │╰╯\n" +
                "           ╭╯  ╰───────╮\n" +
                "          ╭╯    ╭──────╯\n" +
                "         ╭╯     ╰╮\n" +
                "        ╭╯       ╰╮\n" +
                "       ╭╯     ╭───╯   ╭─╮\n" +
                "╭──────╯      ╰───────╯ ╰╮\n" +
                "╰────────────────────────╯",

                "         ╭─────────╮\n" +
                "     ╭───╯ ╭─────╮ ╰────────╮\n" +
                " ╭───╯    ╭╯     ╰──╮  ╭─╮  │\n" +
                " ╰─╮      ╰──╮      ╰──╯ ╰──╯\n" +
                "╭──╯         ╰──╮   ╭───╮\n" +
                "│               ╰───╯   ╰╮\n" +
                "╰────────────────────────╯",

                "                 ╭─────────╮\n" +
                "                 │      ╭──╯\n" +
                "                 ╰╮     │\n" +
                "     ╭────────────╯    ╭╯\n" +
                "╭────╯                ╭╯\n" +
                "╰╮                  ╭─╯\n" +
                " ╰──────────────────╯",

                "             ╭─╮\n" +
                "           ╭─╯ │╭─╮\n" +
                "           ╰╮  ╰╯ │\n" +
                " ╭──────────╯  ╭──╯\n" +
                "╭╯╭────────────╯\n" +
                "│ │  \n" +
                "│ ╰╮ \n" +
                "│ ╭╯\n" +
                "╰╮╰─╮\n" +
                " ╰──╯",

                "╭─────────────────────────╮\n" +
                "╰────╮                   ╭╯\n" +
                "     ╰───╮              ╭╯\n" +
                "         ╰──╮    ╭─╮  ╭─╯\n" +
                "            ╰────╯ ╰──╯",

                " ╭──────╮  ╭───╮     ╭───╮\n" +
                "╭╯ ╭────╯ ╭╯   ╰──╮  ╰─╮ │\n" +
                "╰╮ ╰──╮  ╭╯       ╰──╮ │ │\n" +
                " ╰──╮ ╰──╯           ╰─╯ │\n" +
                "    ╰────────────────────╯",

                "╭──────────────╮\n" +
                "╰─╮           ╭╯\n" +
                "  ╰─╮  ╭──────╯\n" +
                "    ╰╮ ╰╮\n" +
                "     ╰╮ ╰╮  ╭─────────╮\n" +
                "      ╰╮ ╰──╯         │\n" +
                "       ╰╮       ╭─────╯\n" +
                "        ╰───────╯",

                "        ╭──╮\n" +
                "        │  ╰─╮          ╭──╮\n" +
                "      ╭─╯    ╰─╮        ╰─╮╰╮\n" +
                "   ╭──╯        ╰─╮       ╭╯ │\n" +
                "╭──╯             │     ╭─╯  │\n" +
                "╰───╮            ╰╮  ╭─╯    │\n" +
                "    ╰───╮       ╭─╯╭─╯      │\n" +
                "        ╰───╮   ╰──╯    ╭───╯\n" +
                "            ╰───────────╯",

                "╭╮           ╭─╮\n" +
                "│╰╮ ╭────────╯ │\n" +
                "│ │╭╯         ╭╯\n" +
                "│ ╰╯          ╰╮\n" +
                "│             ╭╯\n" +
                "│ ╭╮         ╭╯\n" +
                "│ ││        ╭╯\n" +
                "╰─╯╰────────╯",

                "     ╭─────────────╮\n" +
                "╭────╯             ╰─╮\n" +
                "╰───────╮    ╭─────╮ │\n" +
                "        ╰──╮ ╰╮    ╰─╯\n" +
                "           │  ╰╮\n" +
                "           │   ╰╮\n" +
                "           ╰╮ ╭─╯\n" +
                "            ╰─╯",

                "    ╭───────╮\n" +
                "    │  ╭──╮ │\n" +
                "    │  │  │ │\n" +
                "    ╰─╮╰╮ ╰─╯\n" +
                "      │ ╰╮\n" +
                "      ╰╮ ╰╮\n" +
                "       │  ╰╮    ╭─╮\n" +
                "       ╰╮ ╭╯ ╭──╯ ╰╮\n" +
                "╭───────╯ ╰──╯    ╭╯\n" +
                "╰─────────────────╯",

                "╭───╮\n" +
                "│   ╰╮\n" +
                "│    ╰─╮\n" +
                "╰╮     ╰──╮\n" +
                " │        ╰────────────╮\n" +
                " ╰╮                  ╭─╯\n" +
                "  ╰──────────────────╯",

                "                 ╭────────────╮\n" +
                "  ╭─────╮        │            │\n" +
                " ╭╯     ╰╮    ╭──╯            │\n" +
                "╭╯       ╰╒═══╛───────────────╯\n" +
                "╰─╮   ╭───╯\n" +
                "  ╰───╯ ",

                "                   ╭─╮\n" +
                "                   │ ╰─╮\n" +
                "     ╭───╮         │   │\n" +
                "╭──╮╭╯   ╰─╮       │   │\n" +
                "│  ╰╯      ╰───────╯   │\n" +
                "│    ╭──╮              │\n" +
                "│    │  ╰────────╮     │\n" +
                "╰─╮  │           ╰─────╯\n" +
                "  ╰─╮│\n" +
                "    ╰╯",

                "╭───╮  ╭╮╭─────────────────╮\n" +
                "╰╮  │  │╰╯               ╭─╯\n" +
                " ╰╮ ╰──╯     ╭──╮ ╭─╮  ╭─╯\n" +
                "  ╰╮       ╭─╯  ╰─╯ ╰──╯\n" +
                "   ╰╮  ╭───╯\n" +
                "    ╰╮ │\n" +
                "     ╰─╯",

                " ╭────────────────────╮\n" +
                "╭╯                    ╰─╮\n" +
                "╰──╮                   ╭╯\n" +
                "   ╰───────╮          ╭╯\n" +
                "           ╰───╮     ╭╯\n" +
                "               ╰──╮ ╭╯\n" +
                "                  │╭╯\n" +
                "                  ╰╯",

                "           ╭──────╮\n" +
                "       ╭───╯╭╮╭╮  ╰╮\n" +
                "   ╭───╯  ╭─╯╰╯╰╮  │\n" +
                "╭──╯      ╰─╮   ╰──╯\n" +
                "╰╮          ╰───╮\n" +
                " │              │\n" +
                " ╰──────────────╯",

                "   ╭───╮         ╭─╮\n" +
                "   │   │         ╰╮╰─╮\n" +
                "   │   ╰──────────╯  │\n" +
                " ╭─╯                 │\n" +
                "╭╯                   │\n" +
                "╰──╮                 │\n" +
                "   ╰─────────────────╯",

                "      ╭─╮       ╭───╮\n" +
                "╭───╮ │ ╰╮     ╭╯   ╰╮\n" +
                "│   │╭╯  ╰╮   ╭╯    ╭╯\n" +
                "│   ╰╯    │ ╭─╯    ╭╯\n" +
                "╰─╮       ╰─╯     ╭╯\n" +
                "  ╰─╮             ╰╮\n" +
                "  ╭─╯              ╰╮\n" +
                "╭─╯                 ╰╮\n" +
                "╰────────────────────╯",

                "            ╭──╮\n" +
                "         ╭──╯  ╰───╮\n" +
                "      ╭──╯╭──╮     ╰───╮\n" +
                "    ╭─╯   │  │         ╰───╮\n" +
                "  ╭─╯╭──╮ │  │    ╭──╮     ╰──╮\n" +
                " ╭╯╭─╯  ╰─╯  │    │  ╰────────╯\n" +
                " │ │         ╰────╯\n" +
                " ╰─╯"
            };
            return circuitMaps;
        }
        public class LogoLine
        {
            public string Line { get; }
            public int Indentation { get; }
            public LogoLine(string line, int indentation)
            {
                Line = line;
                Indentation = indentation;
            }
        }

        public readonly static List<KeyValuePair<char, string>> Symbols = new()
        {
            new KeyValuePair<char, string>('ʙ', "LATIN LETTER SMALL CAPITAL B"),
            new KeyValuePair<char, string>('ᴃ', "LATIN LETTER SMALL CAPITAL BARRED B"),
            new KeyValuePair<char, string>('ᴄ', "LATIN LETTER SMALL CAPITAL C"),
            new KeyValuePair<char, string>('ᴅ', "LATIN LETTER SMALL CAPITAL D"),
            new KeyValuePair<char, string>('ᴆ', "LATIN LETTER SMALL CAPITAL ETH"),
            new KeyValuePair<char, string>('ᴇ', "LATIN LETTER SMALL CAPITAL E"),
            new KeyValuePair<char, string>('ⱻ', "LATIN LETTER SMALL CAPITAL TURNED E"),
            new KeyValuePair<char, string>('ⅎ', "LATIN LETTER SMALL CAPITAL TURNED F"),
            new KeyValuePair<char, string>('ɢ', "LATIN LETTER SMALL CAPITAL G"),
            new KeyValuePair<char, string>('ʜ', "LATIN LETTER SMALL CAPITAL H"),
            new KeyValuePair<char, string>('ɪ', "LATIN LETTER SMALL CAPITAL I"),
            new KeyValuePair<char, string>('ᴊ', "LATIN LETTER SMALL CAPITAL J"),
            new KeyValuePair<char, string>('ᴋ', "LATIN LETTER SMALL CAPITAL K"),
            new KeyValuePair<char, string>('ʟ', "LATIN LETTER SMALL CAPITAL L"),
            new KeyValuePair<char, string>('ᴌ', "LATIN LETTER SMALL CAPITAL L WITH STROKE"),
            new KeyValuePair<char, string>('ᴍ', "LATIN LETTER SMALL CAPITAL M"),
            new KeyValuePair<char, string>('ɴ', "LATIN LETTER SMALL CAPITAL N"),
            new KeyValuePair<char, string>('ᴘ', "LATIN LETTER SMALL CAPITAL P"),
            new KeyValuePair<char, string>('ʀ', "LATIN LETTER SMALL CAPITAL R"),
            new KeyValuePair<char, string>('ȿ', "LATIN SMALL LETTER S WITH SWASH TAIL"),
            new KeyValuePair<char, string>('ᴛ', "LATIN LETTER SMALL CAPITAL T"),
            new KeyValuePair<char, string>('ᴜ', "LATIN LETTER SMALL CAPITAL U"),
            new KeyValuePair<char, string>('ᵾ', "LATIN LETTER SMALL CAPITAL U WITH STROKE"),
            new KeyValuePair<char, string>('ᴠ', "LATIN LETTER SMALL CAPITAL V"),
            new KeyValuePair<char, string>('ⱱ', "LATIN SMALL LETTER V WITH RIGHT HOOK"),
            new KeyValuePair<char, string>('ⱴ', "LATIN LETTER SMALL LETTER V WITH CURL"),
            new KeyValuePair<char, string>('ʬ', "LATIN LETTER BILABIAL PERCUSSIVE"),
            new KeyValuePair<char, string>('x', "LATIN LETTER SMALL CAPITAL X"),
            new KeyValuePair<char, string>('ʏ', "LATIN LETTER SMALL CAPITAL Y"),
            new KeyValuePair<char, string>('ᴢ', "LATIN LETTER SMALL CAPITAL Z"),
            new KeyValuePair<char, string>('ƶ', "LATIN LETTER SMALL CAPITAL Z WITH STROKE"),
            new KeyValuePair<char, string>('ɀ', "LATIN LETTER SMALL CAPITAL Z WITH SWASH TAIL"),
            new KeyValuePair<char, string>('ƽ', "LATIN SMALL LETTER TONE FIFE"),
            new KeyValuePair<char, string>('ʊ', "LATIN SMALL LETTER UPSILON"),
            new KeyValuePair<char, string>('ɤ', "LATIN SMALL LETTER RAMS HORN"),
            new KeyValuePair<char, string>('ȣ', "LATIN SMALL LETTER OU"),
            new KeyValuePair<char, string>('ᴧ', "GREEK LETTER SMALL CAPITAL LAMDA"),
            new KeyValuePair<char, string>('λ', "GREEK SMALL LETTER LAMDA"),
            new KeyValuePair<char, string>('α', "GREEK SMALL LETTER ALPHA"),
            new KeyValuePair<char, string>('ͼ', "GREEK CAPITAL DOTTED LUNATE SIGMA SYMBOL"),
            new KeyValuePair<char, string>('ϵ', "GREEK LUNATE EPSILON SYMBOL"),
            new KeyValuePair<char, string>('϶', "GREEK REVERSED LUNATE EPSILON SYMBOL"),
            new KeyValuePair<char, string>('σ', "GREEK SMALL LETTER SIGMA"),
            new KeyValuePair<char, string>('ϙ', "GREEK SMALL LETTER ARCHAIC KOPPA"),
            new KeyValuePair<char, string>('ͳ', "GREEK SMALL LETTER ARCHAIC SAMPI"),
            new KeyValuePair<char, string>('ϰ', "GREEK KAPPA SYMBOL"),
            new KeyValuePair<char, string>('π', "GREEK SMALL LETTER PI"),
            new KeyValuePair<char, string>('Ω', "GREEK LETTER SMALL CAPITAL OMEGA"),
            new KeyValuePair<char, string>('ω', "GREEK SMALL LETTER OMEGA"),
            new KeyValuePair<char, string>('ᴪ', "GREEK LETTER SMALL CAPITAL PSI"),
            new KeyValuePair<char, string>('Ϟ', "GREEK LETTER KOPPA"),
            new KeyValuePair<char, string>('ѧ', "CYRILLIC SMALL LETTER LITTLE YUS"),
            new KeyValuePair<char, string>('ѫ', "CYRILLIC SMALL LETTER BIG YUS"),
            new KeyValuePair<char, string>('в', "CYRILLIC SMALL LETTER VE"),
            new KeyValuePair<char, string>('ғ', "CYRILLIC SMALL LETTER GHE WITH STROKE"),
            new KeyValuePair<char, string>('ԍ', "CYRILLIC SMALL LETTER KOMI SJE"),
            new KeyValuePair<char, string>('н', "CYRILLIC SMALL LETTER EN"),
            new KeyValuePair<char, string>('ԋ', "CYRILLIC SMALL LETTER KOMI NJE"),
            new KeyValuePair<char, string>('м', "CYRILLIC SMALL LETTER EM"),
            new KeyValuePair<char, string>('ѻ', "CYRILLIC SMALL LETTER ROUND OMEGA"),
            new KeyValuePair<char, string>('ѳ', "CYRILLIC SMALL LETTER FITA"),
            new KeyValuePair<char, string>('ԅ', "CYRILLIC SMALL LETTER KOMI ZJE"),
            new KeyValuePair<char, string>('ѕ', "CYRILLIC SMALL LETTER DZE"),
            new KeyValuePair<char, string>('т', "CYRILLIC SMALL LETTER TE"),
            new KeyValuePair<char, string>('ԏ', "CYRILLIC SMALL LETTER KOMI TJE"),
            new KeyValuePair<char, string>('ӿ', "CYRILLIC SMALL LETTER HA WITH STROKE"),
            new KeyValuePair<char, string>('ϩ', "COPTIC SMALL LETTER HORI"),
            new KeyValuePair<char, string>('ϧ', "COPTIC SMALL LETTER KHEI"),
            new KeyValuePair<char, string>('ϫ', "COPTIC SMALL LETTER GANGIA"),
            new KeyValuePair<char, string>('₸', "TENGE SIGN"),
            new KeyValuePair<char, string>('₪', "NEW SHEQEL SIGN"),
            new KeyValuePair<char, string>('∆', "INCREMENT"),
            new KeyValuePair<char, string>('×', "MULTIPLICATION SIGN"),
            new KeyValuePair<char, string>('⌂', "HOUSE"),
            new KeyValuePair<char, string>('◊', "LOZENGE"),
            new KeyValuePair<char, string>('♦', "DIAMOND SUIT"),
            new KeyValuePair<char, string>('▲', "UP-POINTING TRIANGLE"),
            new KeyValuePair<char, string>('✶', "SIX POINTED STAR"),
            new KeyValuePair<char, string>('»', "RIGHT-POINTING DOUBLE ANGLE QUOTATION MARK"),
            new KeyValuePair<char, string>('¤', "CURRENCY SIGN"),
            new KeyValuePair<char, string>('☻', "SMILING FACE"),
            new KeyValuePair<char, string>('♥', "HEART"),
            new KeyValuePair<char, string>('≡', "IDENTICAL TO"),
            new KeyValuePair<char, string>('⸗', "DOUBLE OBLIQUE HYPHEN"),
            new KeyValuePair<char, string>('†', "DAGGER")
        };
    }
}