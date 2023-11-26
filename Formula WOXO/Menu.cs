using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Formula_WOXO.Color;
using static Formula_WOXO.Util;
using static Formula_WOXO.Graphics;
using static Formula_WOXO.Menu;
using System.Data.Common;

namespace Formula_WOXO
{
    public class Menu
    {
        public static void MainMenu(int x, int y)
        {
            int selected = 0;
            List<string> mainMenuItems = new() { "Quick Race", "Career", "Settings", "Quit Game" };
            ConsoleKeyInfo key;
            var menuDrawLines = DrawMainMenu(selected, mainMenuItems);

            while (true)
            {
                bool escape = false;
                Console.Write(FromHex("#e10600"));
                Graphics.DrawLogo(0, 5, 3, false);

                while (true)
                {
                    menuDrawLines = DrawMainMenu(selected, mainMenuItems);
                    for (int j = 0; j < menuDrawLines.Count; j++)
                    {
                        for (int i = 0; i < menuDrawLines[j].Count; i++)
                        {
                            Console.SetCursorPosition(x, y + i);
                            Console.WriteLine(menuDrawLines[j][i]);
                        }
                        Task.Delay(16).Wait();
                    }
                    if (escape is true)
                    {
                        escape = false;
                        break;
                    }
                    ClearKey();
                    key = Console.ReadKey(true);
                    if (key.Key is ConsoleKey.DownArrow)
                        selected = Math.Min(selected + 1, mainMenuItems.Count - 1);
                    else if (key.Key is ConsoleKey.UpArrow)
                        selected = Math.Max(selected - 1, 0);
                    else if (key.Key is ConsoleKey.Enter)
                        escape = true;
                }

                bool selectedSubOption = true;

                while (selected is 0 or 1)
                {
                    List<string> subMenuItems = new() { "Simulate Race", "Choose GP" };
                    if (selected is 1) {
                        subMenuItems[0] = "Become a Legend";
                        subMenuItems[1] = "F1 My Team";
                    }
                    var subMenuDrawLines = DrawSubMenuSquares(selectedSubOption, subMenuItems);
                    for (int i = 0; i < subMenuDrawLines.Count; i++)
                    {
                        Console.SetCursorPosition(x + 30, y + selected * 2 + i);
                        Console.WriteLine(subMenuDrawLines[i]);
                    }
                    if (escape is true)
                        break;
                    ClearKey();
                    key = Console.ReadKey(true);
                    if (key.Key is ConsoleKey.LeftArrow or ConsoleKey.RightArrow)
                        selectedSubOption = !selectedSubOption;
                    else if (key.Key is ConsoleKey.Enter)
                        escape = true;
                    else if (key.Key is ConsoleKey.Escape)
                    {
                        for (int i = 0; i < subMenuDrawLines.Count; i++)
                        {
                            Console.SetCursorPosition(x + 30, y + selected * 2 + i);
                            Console.WriteLine("".PadRight(40, ' '));
                        }
                        break;
                    }
                    Task.Delay(15).Wait();
                };

                while (selected is 0 && !selectedSubOption && escape)
                {
                    int userTeam = -1,
                        selectedDriver = -1,
                        selectedGP = -1;

                    userTeam = ChooseTeamMenu();
                    ClearConsole();
                    if (userTeam is -1)
                        break;

                    selectedDriver = ChooseDriverMenu(userTeam);
                    ClearConsole();
                    if (selectedDriver is -1)
                        continue;

                    selectedGP = ChooseGPMenu();
                    ClearConsole();
                    if (selectedGP is -1)
                        continue;
                };
                if (selected is 0 && selectedSubOption && escape)
                {
                }
                else if (selected is 1 && selectedSubOption && escape)
                {
                    CharacterCreationMenu();
                }
                else if (selected is 1 && !selectedSubOption && escape)
                {
                    TeamCreationMenu();
                }
            }
        }
        public static void TeamCreationMenu()
        {
            ConsoleKeyInfo key;
            TeamInfo teamInfo = new();
            bool escape = false;
            int selected = 0, selectedIcon = 0;
            List<string> lines = new();
            teamInfo.Icon = Symbols[selectedIcon].Key;
            teamInfo.TeamColor = "#96DC78";
            teamInfo.LogoColor = "#9BE17D";
            teamInfo.TeamBigLogo = new List<LogoLine>() { new LogoLine("", 0) };
            teamInfo.Name = "";
            #region Graphics
            string options = "" +
                    "Team Name\n\n" +
                    "Country\n\n" +
                    "Chief\n\n" +
                    "Team Color\n\n" +
                    "Logo Color\n\n" +
                    "Logo Icon\n\n" +
                    "Draw Big Logo\n\n" +
                    "              FINALIZE",
                   optionsInitial = "" +
                    "Team Name\n\n" +
                    "Country\n\n" +
                    "Chief\n\n" +
                    "Team Color         R150↕ G220↕ B120↕\n\n" +
                    "Logo Color         R155↕ G225↕ B125↕\n\n" +
                   $"Logo Icon          < ≡ ⸗ † {FromHex("#ffffff")}ʙ{FromHex("#aaaaaa")} ᴃ ᴄ ᴅ >\n\n" +
                    "Draw Big Logo\n\n" +
                    "              FINALIZE",
                   fields = "" +
                    $"{FromHexBackground("#aaaaaa")}                 {FromHexBackground("#000000")}\n\n" +
                    $"{FromHexBackground("#aaaaaa")}                 {FromHexBackground("#000000")}\n\n" +
                    $"{FromHexBackground("#aaaaaa")}                 {FromHexBackground("#000000")}";
            Console.Clear();
            Console.Write(FromHex("#e10600"));
            Graphics.DrawLogo(0, 5, 3, false);
            WriteAt(5, 9, "" +
            "┌─────────────────────┐\n" +
            "│ Create Your F1 Team │\n" +
            "╘═════════════════════╛");
            WriteAt(46, 13, FromHex("#aaaaaa") + "│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│");
            WriteAt(80, 13, "│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│");
            WriteAt(7, 14, optionsInitial);
            WriteAt(85, 13, FromHex("#555555") +
            "┏╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍┓\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┇                         ┇\n" +
            "┗╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍┛\n");
            #endregion
            while (true)
            {
                while (true)
                {
                    TeamColorTest(teamInfo.TeamColor, teamInfo.LogoColor, teamInfo.Icon, teamInfo.Name);
                    string optionSelected = ColorizeSelectedOption(selected, options);

                    WriteAt(7, 14, optionSelected + FromHex("#aaaaaa"));
                    WriteAt(26, 14, fields);

                    WriteAt(27, 14, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + teamInfo.Name);
                    WriteAt(27, 16, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + teamInfo.Country);
                    WriteAt(27, 18, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + teamInfo.Chief + FromHexBackground("#000000"));

                    ClearKey();
                    key = Console.ReadKey(true);
                    if (key.Key is ConsoleKey.DownArrow)
                        selected = Math.Min(selected + 2, 14);
                    else if (key.Key is ConsoleKey.UpArrow)
                        selected = Math.Max(selected - 2, 0);
                    else if (key.Key is ConsoleKey.Enter) {
                        escape = true;
                        break;
                    }
                    else if (key.Key is ConsoleKey.Escape)
                        break;
                }
                if (escape && (selected is 0 or 2 or 4))
                {
                    Console.SetCursorPosition(26, 14 + selected);
                    Console.Write(FromHexBackground("#ffffff") + "                 " + FromHex("#e10600"));
                    Console.SetCursorPosition(27, 14 + selected);
                    string? field = ReadInput(15);
                    WriteAt(27, 14 + selected, FromHexBackground("#ffffff") + FromHex("#e10600") + field + FromHexBackground("#000000"));
                    if (selected is 0 && field.Length != 0)
                        teamInfo.Name = field;
                    else if (selected is 2 && field.Length != 0)
                        teamInfo.Country = field;
                    else if (selected is 4 && field.Length != 0)
                        teamInfo.Chief = field;
                }
                else if (escape && selected is 6)
                    teamInfo.TeamColor = ColorSelector(26, 20, teamInfo.TeamColor, teamInfo, true);
                else if (escape && selected is 8)
                    teamInfo.LogoColor = ColorSelector(26, 22, teamInfo.LogoColor, teamInfo, false);
                else if (escape && selected is 10)
                {
                    var listOfChars = Symbols;
                    int initialIcon = selectedIcon;
                    bool doNotSave = false;
                    while (true)
                    {
                        TeamColorTest(teamInfo.TeamColor, teamInfo.LogoColor, listOfChars[selectedIcon].Key, teamInfo.Name);

                        char sy1 = listOfChars[(selectedIcon - 3 + listOfChars.Count) % listOfChars.Count].Key,
                             sy2 = listOfChars[(selectedIcon - 2 + listOfChars.Count) % listOfChars.Count].Key,
                             sy3 = listOfChars[(selectedIcon - 1 + listOfChars.Count) % listOfChars.Count].Key,
                             sy4 = listOfChars[selectedIcon].Key,
                             sy5 = listOfChars[(selectedIcon + 1) % listOfChars.Count].Key,
                             sy6 = listOfChars[(selectedIcon + 2) % listOfChars.Count].Key,
                             sy7 = listOfChars[(selectedIcon + 3) % listOfChars.Count].Key;
                        if (doNotSave)
                        {
                            WriteAt(26, 24, FromHex("#aaaaaa") + $"< {sy1} {sy2} {sy3} {FromHex("#ffffff") + sy4 + FromHex("#aaaaaa")} {sy5} {sy6} {sy7} >");
                            break;
                        }
                        else
                            WriteAt(26, 24, FromHex("#ffffff") + $"< {FromHex("#aaaaaa") + sy1} {FromHex("#bbbbbb") + sy2} {FromHex("#cccccc") + sy3} {FromHex("#e10600") + sy4} {FromHex("#cccccc") + sy5} {FromHex("#bbbbbb") + sy6} {FromHex("#aaaaaa") + sy7 + FromHex("#ffffff")} >");
                        ClearKey();
                        key = Console.ReadKey(true);
                        if (key.Key is ConsoleKey.LeftArrow)
                            selectedIcon = selectedIcon - 1 < 0 ? listOfChars.Count - selectedIcon - 1 : selectedIcon - 1;
                        else if (key.Key is ConsoleKey.RightArrow)
                            selectedIcon = selectedIcon + 1 >= listOfChars.Count ? listOfChars.Count - selectedIcon - 1 : selectedIcon + 1;
                        else if (key.Key is ConsoleKey.Escape)
                        {
                            doNotSave = true;
                            selectedIcon = initialIcon;
                        }
                        else if (key.Key is ConsoleKey.Enter)
                        {
                            WriteAt(26, 24, FromHex("#aaaaaa") + $"< {sy1} {sy2} {sy3} {FromHex("#ffffff") + sy4 + FromHex("#aaaaaa")} {sy5} {sy6} {sy7} >");
                            teamInfo.Icon = sy4;
                            break;
                        }
                    }
                }
                else if (escape && selected is 12)
                {
                    WriteAt(7, 26, FromHex("#ffffff") + "Draw Big Logo");
                    lines = TeamLogoDraw(teamInfo.LogoColor, lines);
                    teamInfo.TeamBigLogo = StringToLogoLine(lines);
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                escape = false;
            }
        }
        public static void CharacterCreationMenu()
        {
            ConsoleKeyInfo key;
            UserInfo userInfo = new();
            userInfo.Portrait = new()
            {
                SkinColor = "",
                HairColor = "",
                Hairstyle = 0,
                FacialHairColor = "",
                FacialHairStyle = 0
            };
            bool escape = false;
            int selected = 0, selectedAbbriviation = 0;
            var abbreviations = AbbreviationCreator("", "   ");
            string options = "" +
                "First Name\n\n" +
                "Last Name\n\n" +
                "Abbreviation\n\n" +
                "Nationality\n\n" +
                "Customize Avatar\n\n" +
                "              FINALIZE",
                fields = "" +
                        $"{FromHexBackground("#aaaaaa")}                {FromHexBackground("#000000")}\n\n" +
                        $"{FromHexBackground("#aaaaaa")}                {FromHexBackground("#000000")}\n\n" +
                                                      $"    <     >    \n\n" +
                        $"{FromHexBackground("#aaaaaa")}                {FromHexBackground("#000000")}",
                fieldsAnim = "" +
                        $"████████████████";
            Console.Clear();
            Console.Write(FromHex("#e10600"));
            Graphics.DrawLogo(0, 5, 3, false);

            WriteAt(5, 9, "" +
                "┌────────────────────┐\n" +
                "│ Create Your Driver │\n" +
                "╘════════════════════╛");
            UserPortraitCreator(false, userInfo.Portrait);
            WriteAt(47, 13, "│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│");

            while (true)
            {
                while (true)
                {
                    if (!string.IsNullOrEmpty(userInfo.FirstName) && !string.IsNullOrEmpty(userInfo.LastName))
                        abbreviations = AbbreviationCreator(userInfo.FirstName, userInfo.LastName);

                    string optionSelected = ColorizeSelectedOption(selected, options);

                    WriteAt(7, 14, optionSelected + FromHex("#aaaaaa"));
                    WriteAt(26, 14, fields);

                    WriteAt(27, 14, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + userInfo.FirstName);
                    WriteAt(27, 16, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + userInfo.LastName);
                    if (!string.IsNullOrEmpty(userInfo.Abbreviation) && abbreviations.Contains(userInfo.Abbreviation))
                        WriteAt(32, 18, FromHexBackground("#000000") + FromHex("#ffffff") + userInfo.Abbreviation);
                    else if (!string.IsNullOrEmpty(userInfo.FirstName) && !string.IsNullOrEmpty(userInfo.LastName))
                    {
                        WriteAt(32, 18, FromHexBackground("#000000") + FromHex("#ffffff") + abbreviations[0]);
                        userInfo.Abbreviation = abbreviations[0];
                    }
                    WriteAt(27, 20, FromHexBackground("#aaaaaa") + FromHex("#ffffff") + userInfo.Nationality + FromHexBackground("#000000"));

                    ClearKey();
                    key = Console.ReadKey(true);
                    if (key.Key is ConsoleKey.DownArrow)
                        selected = Math.Min(selected + 2, 10);
                    else if (key.Key is ConsoleKey.UpArrow)
                        selected = Math.Max(selected - 2, 0);
                    else if (key.Key is ConsoleKey.Enter) {
                        escape = true;
                        break;
                    }
                    else if (key.Key is ConsoleKey.Escape)
                        break;
                }
                if (escape && (selected is 0 or 2 or 6))
                {
                    Console.SetCursorPosition(26, 14 + selected);
                    Console.Write(FromHexBackground("#ffffff") + "                " + FromHex("#e10600"));
                    Console.SetCursorPosition(27, 14 + selected);
                    string? field = ReadInput(14);
                    WriteAt(27, 14 + selected, FromHexBackground("#ffffff") + FromHex("#e10600") + field + FromHexBackground("#000000"));
                    if (selected is 0 && field.Length != 0)
                        userInfo.FirstName = field;
                    else if (selected is 2 && field.Length != 0)
                        userInfo.LastName = field;
                    else if (selected is 6 && field.Length != 0)
                        userInfo.Nationality = field;
                }
                else if (escape && selected is 4 && (!string.IsNullOrEmpty(userInfo.FirstName) && !string.IsNullOrEmpty(userInfo.LastName)))
                {
                    abbreviations = AbbreviationCreator(userInfo.FirstName, userInfo.LastName);
                    if (!string.IsNullOrEmpty(userInfo.Abbreviation) && abbreviations.Contains(userInfo.Abbreviation))
                        selectedAbbriviation = abbreviations.IndexOf(userInfo.Abbreviation);
                    while (true)
                    {
                        WriteAt(30, 18, FromHex("#ffffff") + $"< {FromHex("#e10600") + abbreviations[selectedAbbriviation] + FromHex("#ffffff")} >");
                        ClearKey();
                        key = Console.ReadKey(true);
                        if (key.Key is ConsoleKey.LeftArrow)
                            selectedAbbriviation = Math.Max(selectedAbbriviation - 1, 0);
                        else if (key.Key is ConsoleKey.RightArrow)
                            selectedAbbriviation = Math.Min(selectedAbbriviation + 1, abbreviations.Count - 1);
                        else if (key.Key is ConsoleKey.Escape)
                            break;
                        else if (key.Key is ConsoleKey.Enter)
                        {
                            userInfo.Abbreviation = abbreviations[selectedAbbriviation];
                            break;
                        }
                    }
                }
                else if (escape && selected is 4)
                {
                    int speed = 20;
                    if (string.IsNullOrEmpty(userInfo.FirstName) && string.IsNullOrEmpty(userInfo.LastName))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Task.Delay(speed).Wait();
                            WriteAt(26, 14, FromHex("#000000") + "█");
                            WriteAt(27, 14, FromHex("#aaaaaa") + fieldsAnim);
                            WriteAt(26, 16, FromHex("#000000") + "█");
                            WriteAt(27, 16, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(27 + 16, 14, FromHex("#000000") + "█");
                            WriteAt(26, 14, FromHex("#aaaaaa") + fieldsAnim);
                            WriteAt(27 + 16, 16, FromHex("#000000") + "█");
                            WriteAt(26, 16, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(26 + 16, 14, FromHex("#000000") + "█");
                            WriteAt(25, 14, FromHex("#aaaaaa") + fieldsAnim);
                            WriteAt(26 + 16, 16, FromHex("#000000") + "█");
                            WriteAt(25, 16, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(25, 14, FromHex("#000000") + "█");
                            WriteAt(26, 14, FromHex("#aaaaaa") + fieldsAnim);
                            WriteAt(25, 16, FromHex("#000000") + "█");
                            WriteAt(26, 16, FromHex("#aaaaaa") + fieldsAnim);
                        }
                    }
                    else
                    {
                        int shakeFieldX = string.IsNullOrEmpty(userInfo.FirstName) ? 14 : 16;
                        for (int i = 0; i < 4; i++)
                        {
                            Task.Delay(speed).Wait();
                            WriteAt(26, shakeFieldX, FromHex("#000000") + "█");
                            WriteAt(27, shakeFieldX, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(27 + 16, shakeFieldX, FromHex("#000000") + "█");
                            WriteAt(26, shakeFieldX, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(26 + 16, shakeFieldX, FromHex("#000000") + "█");
                            WriteAt(25, shakeFieldX, FromHex("#aaaaaa") + fieldsAnim);
                            Task.Delay(speed).Wait();
                            WriteAt(25, shakeFieldX, FromHex("#000000") + "█");
                            WriteAt(26, shakeFieldX, FromHex("#aaaaaa") + fieldsAnim);
                        }
                    }
                }
                else if (escape && selected is 8)
                {
                    WriteAt(7, 22, FromHex("#ffffff") + "Customize Avatar");
                    userInfo.Portrait = UserPortraitCreator(true, userInfo.Portrait);
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
                escape = false;
            }
        }
        public static UserPortrait UserPortraitCreator(bool custom, UserPortrait userPortrait)
        {
            ConsoleKeyInfo key;
            int selected = 0, x = 52, y = 14;

            if (userPortrait.SkinColor.Length is 0)
            {
                userPortrait.SkinColor = "#8d5524";
                userPortrait.HairColor = "#310000";
                userPortrait.FacialHairColor = "#846f6f";
                userPortrait.FacialHairStyle = 0;
                userPortrait.Hairstyle = 0;
                userPortrait.Reverse = true;
            }
            bool reverse = userPortrait.Reverse;

            #region options
            string options = "" +
                        "Skin Color\n" +
                        "┗╸\n" +
                        "\n" +
                        "Hairstyle\n" +
                        "Hair Color\n" +
                        "┗╸\n" +
                        "\n" +
                        "Facial Hair\n" +
                        "Facial Hair Color\n" +
                        "┗╸",
                   optionsInitial = "" +
                        "Skin Color\n" +                            //0
                        "┗╸R 141↕   G  85↕   B  36↕\n" +
                        "\n" +
                        $"Hairstyle           < {FromHex("#ffffff")} 0{FromHex("#aaaaaa")} >\n" +            //3
                        "Hair Color\n" +                            //4
                        "┗╸R  49↕   G   0↕   B   0↕\n" +
                        "\n" +
                        $"Facial Hair         < {FromHex("#ffffff")} 0{FromHex("#aaaaaa")} >\n" +            //7
                        "Facial Hair Color\n" +                     //8
                        "┗╸R 132↕   G 111↕   B 111↕";
            #endregion

            if (!custom)
            {
                DrawPortrait(90, 14, userPortrait, reverse);
                WriteAt(x, y, FromHex("#aaaaaa") + optionsInitial);
            }
            while (custom)
            {
                string optionSelected = ColorizeSelectedOption(selected, options);

                DrawPortrait(90, 14, userPortrait, reverse);
                WriteAt(x, y, optionSelected);
                WriteAt(0, 14, "");

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.DownArrow && (selected is 0 or 4))
                    selected += 3;
                else if (key.Key is ConsoleKey.UpArrow && (selected is 3 || selected is 7))
                    selected -= 3;
                else if (key.Key is ConsoleKey.UpArrow && (selected is 4 || selected is 8))
                    selected--;
                else if (key.Key is ConsoleKey.DownArrow && (selected is 3 || selected is 7))
                    selected++;
                else if (key.Key is ConsoleKey.Enter && (selected is 0 || selected is 4 || selected is 8))
                {
                    WriteAt(x, y + selected + 1, FromHex("#ffffff") + "┗╸");
                    if (selected is 0)
                        userPortrait.SkinColor = ColorSelector(x + 2, y + selected + 1, userPortrait.SkinColor, userPortrait, selected, reverse);
                    else if (selected is 4)
                        userPortrait.HairColor = ColorSelector(x + 2, y + selected + 1, userPortrait.HairColor, userPortrait, selected, reverse);
                    else if (selected is 8)
                        userPortrait.FacialHairColor = ColorSelector(x + 2, y + selected + 1, userPortrait.FacialHairColor, userPortrait, selected, reverse);
                }
                else if (key.Key is ConsoleKey.Enter && (selected is 3 || selected is 7))
                {
                    int styleNumber = selected is 3
                        ? userPortrait.Hairstyle
                        : userPortrait.FacialHairStyle;
                    while (true)
                    {
                        if (selected is 3)
                            DrawPortrait(90, 14, new UserPortrait {
                                FacialHairColor = userPortrait.FacialHairColor,
                                HairColor = userPortrait.HairColor,
                                SkinColor = userPortrait.SkinColor,
                                FacialHairStyle = userPortrait.FacialHairStyle,
                                Hairstyle = styleNumber
                            }, reverse);
                        else
                            DrawPortrait(90, 14, new UserPortrait
                            {
                                FacialHairColor = userPortrait.FacialHairColor,
                                HairColor = userPortrait.HairColor,
                                SkinColor = userPortrait.SkinColor,
                                Hairstyle = userPortrait.Hairstyle,
                                FacialHairStyle = styleNumber
                            }, reverse);
                        string styleNumberString = "".PadRight(2 - styleNumber.ToString().Length) + styleNumber.ToString();

                        WriteAt(x + 20, y + selected, FromHex("#ffffff") + $"< {FromHex("#e10600") + styleNumberString + FromHex("#ffffff")} >");

                        ClearKey();
                        key = Console.ReadKey(intercept: true);
                        if (key.Key is ConsoleKey.RightArrow)
                        {
                            if (selected is 3)
                                styleNumber = Math.Min(styleNumber + 1, 27);
                            else
                                styleNumber = Math.Min(styleNumber + 1, 27);
                        }
                        else if (key.Key is ConsoleKey.LeftArrow)
                            styleNumber = Math.Max(styleNumber - 1, 0);
                        else if (key.Key is ConsoleKey.R)
                            reverse = !reverse;
                        else if (key.Key is ConsoleKey.Enter)
                        {
                            WriteAt(x + 20, y + selected, FromHex("#aaaaaa") + $"< {FromHex("#ffffff") + styleNumberString + FromHex("#aaaaaa")} >");
                            if (selected is 3)
                            {
                                userPortrait.Reverse = reverse;
                                userPortrait.Hairstyle = styleNumber;
                            }
                            else
                                userPortrait.FacialHairStyle = styleNumber;
                            break;
                        }
                        else if (key.Key is ConsoleKey.Escape)
                        {
                            WriteAt(x + 20, y + selected, FromHex("#aaaaaa") + $"< {FromHex("#ffffff") + styleNumberString + FromHex("#aaaaaa")} >");
                            break;
                        }
                    }
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    break;
                }
            }
            WriteAt(x, y, options);
            return userPortrait;
        }
        public class TeamInfo
        {
            public string Name { get; set; }
            public string Country { get; set; }
            public string Chief { get; set; }
            public string TeamColor { get; set; }
            public string LogoColor { get; set; }
            public char Icon { get; set; }
            public List<LogoLine> TeamBigLogo { get; set; }
        }
        public class UserInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Abbreviation { get; set; }
            public string Nationality { get; set; }
            public UserPortrait Portrait { get; set; }
        }
        public class UserPortrait
        {
            public string SkinColor { get; set; }
            public string HairColor { get; set; }
            public string FacialHairColor { get; set; }
            public int Hairstyle { get; set; }
            public int FacialHairStyle { get; set; }
            public bool Reverse { get; set; }
        }
        public static int ChooseTeamMenu()
        {
            ConsoleKeyInfo key;
            int selected = 0, previousSelected = 0;

            List<string> box = new();
            box.Add("                    ");
            box.Add("┌──────────────────┐");
            for (int i = 0; i < 6; i++)
                box.Add("│                  │");
            box.Add("╘══════════════════╛");
            box.Add("                    ");

            string pickATeamBox =
                "┌──────────────────┐\n" +
                "│ Pick a Team      │\n" +
                "╘══════════════════╛";

            Console.Clear();
            Console.Write(FromHex("#e10600"));
            Graphics.DrawLogo(0, 5, 3, false);
            Console.Write(FromHex("#eeeeee"));

            while (true)
            {
                for (int i = 0; i < 10; i++)
                {
                    string color = selected == i ? FromHex("#e10600") : FromHex("#aaaaaa");
                    int offsetX = i < 5 ? 0 : 5,
                        offsetY = i < 5 ? 12 : 22,
                        selectedTeamOffset = i == selected ? 1 : 0;
                    Console.Write(color);
                    for (int j = 0; j < box.Count; j++)
                    {
                        Console.SetCursorPosition(6 + (i - offsetX) * 23, offsetY + j - selectedTeamOffset);
                        Console.Write(box[j]);
                    }
                    Console.SetCursorPosition(8 + (i - offsetX) * 23, offsetY + 2 - selectedTeamOffset);
                    color = selected == i ? FromHex(Database.Constructors[i].Color) : FromHex("#aaaaaa");
                    Console.Write(color + Database.Constructors[i].Name);
                    Console.SetCursorPosition(23 + (i - offsetX) * 23, Console.CursorTop);
                    color = selected == i ? FromHex(Database.Constructors[i].Color2) : FromHex("#aaaaaa");
                    Console.Write(color + Database.Constructors[i].Icon);
                }

                WriteAt(6, 9, FromHex("#e10600") + pickATeamBox);

                var adjust = AdjustTeamLogoPostition(selected);
                Console.Write(FromHex(Database.Constructors[selected].Color2));
                DrawTeamLogo(selected, 84 + adjust[0], 0 + adjust[1]);
                previousSelected = selected;

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.RightArrow && selected != 4)
                    selected = Math.Min(selected + 1, 9);
                else if (key.Key is ConsoleKey.UpArrow && selected > 4)
                    selected = Math.Max(selected - 5, 0);
                else if (key.Key is ConsoleKey.LeftArrow && selected != 5)
                    selected = Math.Max(selected - 1, 0);
                else if (key.Key is ConsoleKey.DownArrow && selected < 5)
                    selected = Math.Min(selected + 5, 9);
                else if (key.Key is ConsoleKey.Escape)
                    break;
                else if (key.Key is ConsoleKey.Enter)
                    return selected;
                if (previousSelected != selected)
                {
                    for (int j = 0; j < 14; j++)
                    {
                        Console.SetCursorPosition(84, 0 + j);
                        Console.WriteLine("".PadRight(35, ' '));
                    }
                }
            }
            return -1;
        }
        public static int ChooseDriverMenu(int team)
        {
            ConsoleKeyInfo key;
            int selected = team * 2, xPos = 41;

            StringBuilder box = new();
            box.AppendLine("╭─────────────────────────────────╮");
            for (int i = 0; i < 13; i++)
                box.AppendLine("│");
            box.AppendLine("╰─────────────────────────────────╯");

            string chooseADriverBox =
                "┌──────────────────┐\n" +
                "│ Choose a Driver  │\n" +
                "╘══════════════════╛",
                boxLine = "│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│\n│";


            Console.Clear();
            Console.Write(FromHex("#e10600"));
            Graphics.DrawLogo(0, 5, 3, false);

            Console.Write(FromHex(Database.Constructors[team].Color2));
            DrawTeamLogo(team, 7, 15);

            WriteAt(6, 9, FromHex("#e10600") + chooseADriverBox);

            DrawPortrait(team * 2, xPos + 2, 14);
            DrawPortrait(team * 2 + 1, xPos + 44, 14);

            WriteAt(xPos + 2, 23, FromHex("#aaaaaa") + DriverBestInfoBuilder(team * 2));
            WriteAt(xPos + 44, 23, DriverBestInfoBuilder(team * 2 + 1));

            WriteAt(xPos + 20, 14, FromHex("#ffffff") + $"{Database.Drivers[team * 2].DisplayName}");

            WriteAt(xPos + 20, 17, FromHex("#ffffff") + $"{Database.SmallFlags.GetValueOrDefault(Database.Drivers[team * 2].Country.ToUpper())}");

            string numberColor = Database.Drivers[team * 2].Number is 44 ? "#fefe01" : Database.Constructors[team].Color;

            WriteAt(xPos + 20, 19, FromHex(numberColor) + WriteHeader(Database.Drivers[team * 2].Number.ToString()));

            WriteAt(xPos + 62, 14, FromHex("#ffffff") + $"{Database.Drivers[team * 2 + 1].DisplayName}");

            WriteAt(xPos + 62, 17, FromHex("#ffffff") + $"{Database.SmallFlags.GetValueOrDefault(Database.Drivers[team * 2 + 1].Country.ToUpper())}");

            numberColor = Database.Drivers[team * 2 + 1].Number is 63 ? "#1efe00" : Database.Constructors[team].Color;

            WriteAt(xPos + 62, 19, FromHex(numberColor) + WriteHeader(Database.Drivers[team * 2 + 1].Number.ToString()));

            while (true)
            {
                string color = selected % 2 is 0 ? FromHex("#e10600") : FromHex("#666666");
                WriteAt(xPos, 13, color + box);
                WriteAt(xPos + 34, 14, color + boxLine);
                color = selected % 2 is 1 ? FromHex("#e10600") : FromHex("#666666");
                WriteAt(xPos + 42, 13, color + box);
                WriteAt(xPos + 76, 14, color + boxLine);

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.RightArrow)
                    selected = Math.Min(selected + 1, team * 2 + 1);
                else if (key.Key is ConsoleKey.LeftArrow)
                    selected = Math.Max(selected - 1, team * 2);
                else if (key.Key is ConsoleKey.Escape)
                    break;
                else if (key.Key is ConsoleKey.Enter)
                    return selected;
            }
            return -1;
        }
        public static string DriverBestInfoBuilder(int driverId)
        {
            StringBuilder info = new();
            int infoCount = 0;
            var driverStats = Database.Drivers[driverId].Stats;
            if (driverStats.WorldChampionships > 0)
            {
                infoCount++;
                info.AppendLine(driverStats.WorldChampionships + " Time World Champion");
            }
            if (driverStats.HighestRaceFinish.Key is 1)
            {
                infoCount++;
                string plural = driverStats.HighestRaceFinish.Value > 1 ? "Wins" : "Win";
                info.AppendLine(driverStats.HighestRaceFinish.Value + " Race " + plural);
            }
            if (driverStats.Podiums > 0)
            {
                infoCount++;
                string plural = driverStats.Podiums > 1 ? "Podiums" : "Podium";
                info.AppendLine(driverStats.Podiums + " " + plural);
            }
            if (infoCount < 3 && driverStats.HighestRaceFinish.Key != 1)
            {
                infoCount++;
                info.AppendLine("Highest Race Finish " + driverStats.HighestRaceFinish.Key + " (x" + driverStats.HighestRaceFinish.Value + ")");
            }
            if (infoCount < 3)
            {
                infoCount++;
                info.AppendLine(driverStats.GrandsPrixEntered + " Grand Prix Entered");
            }
            info.AppendLine("Lifetime Points " + driverStats.Points);
            return info.ToString();
        }
        public static int ChooseGPMenu()
        {
            ConsoleKeyInfo key;
            int selected = 0, lastSelected = 1, onScreen = 16, scrollBase = 0;
            bool scrollSide = true;
            string pickATeamBox =
                "┌───────────────────┐\n" +
                "│ Choose Grand Prix │\n" +
                "╘═══════════════════╛";

            Console.Clear();
            Console.Write(FromHex("#e10600"));
            Graphics.DrawLogo(0, 5, 3, false);
            WriteAt(6, 9, FromHex("#e10600") + pickATeamBox);

            while (true)
            {
                if (selected != lastSelected)
                {
                    WriteAt(8, 14, "");
                    for (int i = scrollBase; i < Math.Min(Database.GrandsPrix.Count, scrollBase + onScreen); i++)
                    {
                        string grandPrixName = selected == i ? FromHex("#e10600") + Database.GrandsPrix[i].NameGP + " Grand Prix          \n"
                            : FromRgb(255 - Math.Max((selected - i) * 9, (selected - i) * -9),
                                      255 - Math.Max((selected - i) * 10, (selected - i) * -10),
                                      255 - Math.Max((selected - i) * 10, (selected - i) * -10)) + Database.GrandsPrix[i].NameGP + " Grand Prix          \n";
                        WriteAt(8, Console.CursorTop, grandPrixName);
                    }

                    //Scrollbar
                    DrawScrollBar(6, 14, Database.GrandsPrix.Count, onScreen, scrollBase, "#e10600");

                    //Circuit Map
                    DrawCircuitMap(40, 14, lastSelected, "#000000");
                    DrawCircuitMap(40, 14, selected, "#ffffff");

                    //Header Name
                    WriteHeaderGPName(lastSelected, "#000000");
                    WriteHeaderGPName(selected, "#e10600");

                    WriteGPData(80, 15, lastSelected, "#e10600", "#000000");
                    WriteGPData(80, 15, selected, "#e10600", "#ffffff");
                }

                lastSelected = selected;

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                    if (selected < scrollBase)
                        scrollBase = selected;
                }
                else if (key.Key is ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, Database.GrandsPrix.Count - 1);
                    if (selected >= scrollBase + onScreen)
                        scrollBase = selected - onScreen + 1;
                }
                else if (key.Key is ConsoleKey.Escape)
                    break;
                else if (key.Key is ConsoleKey.Enter)
                    return selected;
            }
            return -1;
        }
        private static void WriteGPData(int x, int y, int selected, string colorLables, string colorData)
        {
            WriteAt(x, y, FromHex(colorLables) + "Country:\nLocation:\nFirst GP:\nLap Record:\n\nLaps:\nTurns:\nDRS Zones:\nLap Length:\nRace Distance:");

            var lapRecordData = Database.GrandsPrix[selected].LapRecord.Split(' ');
            string lapRecordTime = lapRecordData[0];
            string lapRecordHolder = "";
            for (int i = 1; i < lapRecordData.Length; i++)
                lapRecordHolder += lapRecordData[i] + " ";

            List<string> data = new()
            {
                Database.GrandsPrix[selected].Country + " " + Database.SmallFlags.GetValueOrDefault(Database.GrandsPrix[selected].Country.ToUpper()) + FromHex(colorData),
                Database.GrandsPrix[selected].Location,
                Database.GrandsPrix[selected].FirstGP.ToString(),
                lapRecordTime,
                lapRecordHolder.TrimEnd(),
                Database.GrandsPrix[selected].Laps.ToString(),
                Database.GrandsPrix[selected].Turns.ToString(),
                Database.GrandsPrix[selected].DRSZones.ToString(),
                Database.GrandsPrix[selected].Lenght.ToString() + "km",
                Database.GrandsPrix[selected].RaceDistance.ToString() + "km"
            };

            Console.Write(FromHex(colorData));

            for(int i = 0; i < data.Count; i++)
            {
                if (i is 0)
                    WriteAt(Console.WindowWidth - Database.GrandsPrix[selected].Country.Length - 6, y + i, data[i]);
                else 
                    WriteAt(Console.WindowWidth - data[i].Length - 2, y + i, data[i]);
            }
        }
        public static List<List<string>> DrawMainMenu(int sel, List<string> menuItems)
        {
            sel = sel * 3 + 1;
            string notSelected = FromHex("#aaaaaa"), selected = FromHex("#e10600");
            List<List<string>> frames = new();
            List<string> processedMenuItems = new ();
            List<string> optionsList = new();
            foreach (var item in menuItems)
            {
                if (item.Length > 17)
                    processedMenuItems.Add(item.Substring(0, 17));
                else if (item.Length < 17)
                    processedMenuItems.Add(item.PadRight(17, ' '));
                else
                    processedMenuItems.Add(item);
            }
            foreach (var item in processedMenuItems)
            {
                optionsList.Add( "┌───────────────────┐");
                optionsList.Add($"│ {item           } │");
                optionsList.Add( "╘═══════════════════╛");
            }
            for (int step = 0; step <= 3; step++)
            {
                List<string> frame = new List<string>();
                for (int i = 0; i < optionsList.Count; i++)
                {
                    string optionText = optionsList[i];
                    optionText = sel == i || sel == i - 1 || sel == i + 1 
                        ? selected + new string(' ', step) + optionsList[i] + "   "
                        : optionText = notSelected + optionsList[i] + "   ";
                    frame.Add(optionText);
                }
                frames.Add(frame);
            }
            return frames;
        }
        public static List<string> DrawSubMenuSquares(bool sel, List<string> menuItems)
        {
            string oneColor = sel ? FromHex("#e10600") : FromHex("#aaaaaa"),
                   twoColor = sel ? FromHex("#aaaaaa") : FromHex("#e10600");
            List<string> processedMenuItems = new();
            List<string> optionsList = new();
            foreach (var item in menuItems)
            {
                if (item.Length > 15)
                    processedMenuItems.Add(item.Substring(0, 15));
                else if (item.Length < 15)
                    processedMenuItems.Add(item.PadRight(15, ' '));
                else
                    processedMenuItems.Add(item);
            }
            if (sel)
            {
                optionsList.Add(oneColor + $"┌─────────────────┐                               ");
                optionsList.Add(oneColor + $"│ {processedMenuItems[0]} │ {twoColor} ┌─────────────────┐");
                optionsList.Add(oneColor + $"│                 │ {twoColor} │ {processedMenuItems[1]} │");
            }
            else
            {
                optionsList.Add(oneColor + $"                    {twoColor} ┌─────────────────┐");
                optionsList.Add(oneColor + $"┌─────────────────┐ {twoColor} │ {processedMenuItems[1]} │");
                optionsList.Add(oneColor + $"│ {processedMenuItems[0]} │ {twoColor} │                 │");
            }
            for (int i = 0; i < 5; i++)
                optionsList.Add(oneColor + $"│                 │ {twoColor} │                 │");
            if (sel)
            {
                optionsList.Add(oneColor + $"╘═════════════════╛ {twoColor} │                 │");
                optionsList.Add(oneColor + $"                    {twoColor} ╘═════════════════╛");
            }
            else
            {
                optionsList.Add(oneColor + $"│                 │ {twoColor} ╘═════════════════╛");
                optionsList.Add(oneColor + $"╘═════════════════╛                               ");
            }
            return optionsList;
        }
        public static List<string> AbbreviationCreator(string? firstName, string? lastName)
        {
            List<string> abbreviations = new List<string>();

            if (lastName.Length >= 3)
                abbreviations.Add(lastName.Substring(0, 3));

            if (firstName.Length + lastName.Length is 2)
                abbreviations.Add(" " + firstName + lastName);

            if (firstName.Length + lastName.Length is 1)
                abbreviations.Add("  " + firstName + lastName);

            if (firstName.Length + lastName.Length is 3)
                abbreviations.Add(firstName + lastName);

            if (firstName.Length > 0 && lastName.Length > 1)
                abbreviations.Add(firstName.Substring(0, 1) + lastName.Substring(0, 2));

            if (firstName.Length > 1 && lastName.Length > 0)
                abbreviations.Add(firstName.Substring(0, 2) + lastName.Substring(0, 1));

            if (firstName.Length > 2)
                abbreviations.Add(firstName.Substring(0, 3));

            for (int i = 0; i < abbreviations.Count; i++)
                abbreviations[i] = abbreviations[i].ToUpper();

            return abbreviations.Distinct().ToList();
        }
        public static List<string> TeamLogoDraw(string color, List<string> lines)
        {
            WriteAt(85, 13, FromHex("#555555") +
                "┏╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍┓\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┇                         ┇\n" +
                "┗╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍╍┛\n");
            int x = 86, y = 28, xMax = 110, yMax = 49, xMin = 86, yMin = 28;
            ConsoleKeyInfo key;
            if (lines.Count is 0)
            {
                for (int i = 0; i < 11; i++)
                    lines.Add("                         ");
            }
            while (true)
            {
                string pointer = y % 2 is 1 ? "▄" : "▀";

                Console.Write(FromHex(color));
                for (int i = 0; i < lines.Count; i++)
                    WriteAt(xMin, yMin / 2 + i, FromHex(color) + lines[i]);

                if (((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▄" or "█") && pointer is "▀")
                 || ((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▀" or "█") && pointer is "▄"))
                    WriteAt(x, y / 2, FromHexBackground(color) + FromHex("#ffffff") + pointer + FromHexBackground("#000000"));
                else
                    WriteAt(x, y / 2, FromHex("#ffffff") + pointer + FromHexBackground("#000000"));

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.LeftArrow)
                    x = Math.Max(x - 1, xMin);
                else if (key.Key is ConsoleKey.RightArrow)
                    x = Math.Min(x + 1, xMax);
                else if (key.Key is ConsoleKey.UpArrow)
                    y = Math.Max(y - 1, yMin);
                else if (key.Key is ConsoleKey.DownArrow)
                    y = Math.Min(y + 1, yMax);
                else if (key.Key is ConsoleKey.Enter or ConsoleKey.Spacebar)
                {
                    if (((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▄" or "█") && pointer is "▀")
                     || ((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▀" or "█") && pointer is "▄"))
                        pointer = "█";
                    lines[(y - yMin) / 2] = lines[(y - yMin) / 2].Remove(x - xMin, 1);
                    lines[(y - yMin) / 2] = lines[(y - yMin) / 2].Insert(x - xMin, pointer.ToString());
                }
                else if (key.Key is ConsoleKey.Backspace)
                {
                    if ((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▄" or "█") && pointer is "▀")
                        pointer = "▄";
                    else if ((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▀" or "█") && pointer is "▄")
                        pointer = "▀";
                    else if (((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▀") && pointer is "▀")
                         || ((lines[(y - yMin) / 2].Substring(x - xMin, 1) is "▄") && pointer is "▄")
                         || (lines[(y - yMin) / 2].Substring(x - xMin, 1) is " "))
                        pointer = " ";

                    lines[(y - yMin) / 2] = lines[(y - yMin) / 2].Remove(x - xMin, 1);
                    lines[(y - yMin) / 2] = lines[(y - yMin) / 2].Insert(x - xMin, pointer.ToString());
                }
                else if (key.Key is ConsoleKey.C)
                {
                    lines.Clear();
                    for (int i = 0; i < 11; i++)
                        lines.Add("                         ");
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    WriteAt(x, y / 2, FromHex(color) + lines[(y - yMin) / 2].Substring(x - xMin, 1));
                    break;
                }
            }
            return lines;
        }
        public static List<LogoLine> StringToLogoLine(List<string> lines)
        {
            List<LogoLine> logoLines = new();
            foreach (string line in lines)
            {
                int indentation = 0;
                while (line[indentation] is ' ' && indentation != line.Length - 1)
                    indentation = Math.Min(indentation + 1, line.Length - 1);
                logoLines.Add(new LogoLine(line.TrimStart().TrimEnd(), indentation));
            }
            return logoLines;
        }
        public static int[] AdjustTeamLogoPostition(int team)
        {
            int x, y;
            switch (team)
            {
                case 0:
                    x = 6; y = 1;
                    break;
                case 1:
                    x = 8; y = 1;
                    break;
                case 2:
                    x = 7; y = 0;
                    break;
                case 3:
                    x = 6; y = 2;
                    break;
                case 4:
                    x = 0; y = 3;
                    break;
                case 5:
                    x = 6; y = 1;
                    break;
                case 6:
                    x = 6; y = 1;
                    break;
                case 7:
                    x = 2; y = 2;
                    break;
                case 8:
                    x = 8; y = 1;
                    break;
                case 9:
                    x = 6; y = 1;
                    break;
                default:
                    x = 0; y = 0;
                    break;
            }
            int[] coords = { x, y };
            return coords;
        }
        public static string ColorizeSelectedOption(int selectedIndex, string options)
        {
            string[] lines = options.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == selectedIndex)
                    lines[i] = FromHex("#e10600") + lines[i];
                else
                    lines[i] = FromHex("#aaaaaa") + lines[i];
            }
            return string.Join('\n', lines);
        }
        public static string ColorSelector(int x, int y, string color)
        {
            ConsoleKeyInfo key;
            bool escape = false;
            int selected = 0;
            var rgbValues = ColorConverter.HexToRgb(color);
            string rI = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                   gI = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                   bI = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();
            while (true)
            {
                string r = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                       g = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                       b = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();

                if (selected is 0)
                    WriteAt(x, y, $"{FromRgb(255, 0, 0)}R {FromRgb(255, 255, 255) + r + FromHex("#aaaaaa")}↕   G {g}↕   B {b}↕");
                else if (selected is 1)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   {FromRgb(0, 255, 0)}G {FromRgb(255, 255, 255) + g + FromHex("#aaaaaa")}↕   B {b}↕");
                else if (selected is 2)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   G {g}↕   {FromRgb(0, 0, 255)}B {FromRgb(255, 255, 255) + b + FromHex("#aaaaaa")}↕");

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.RightArrow)
                    selected = Math.Min(selected + 1, 2);
                else if (key.Key is ConsoleKey.LeftArrow)
                    selected = Math.Max(selected - 1, 0);
                else if (key.Key is ConsoleKey.UpArrow)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 1, 255);
                else if (key.Key is ConsoleKey.DownArrow)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 1, 0);
                else if (key.Key is ConsoleKey.W)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 10, 255);
                else if (key.Key is ConsoleKey.S)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 10, 0);
                else if (key.Key is ConsoleKey.Enter)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   G {g}↕   B {b}↕");
                    escape = true;
                    break;
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {rI}↕   G {gI}↕   B {bI}↕");
                    break;
                }
            }
            if (escape)
                color = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2]);
            return color;
        }
        public static string ColorSelector(int x, int y, string color, TeamInfo teamInfo, bool type)
        {
            ConsoleKeyInfo key;
            bool escape = false;
            int selected = 0;
            var rgbValues = ColorConverter.HexToRgb(color);
            string rI = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                   gI = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                   bI = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();
            while (true)
            {
                if (type)
                    TeamColorTest(ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2]), teamInfo.LogoColor, teamInfo.Icon, teamInfo.Name);
                else
                {
                    for (int i = 0; i < teamInfo.TeamBigLogo.Count; i++)
                        WriteAt(86 + teamInfo.TeamBigLogo[i].Indentation, 14 + i, FromRgb(rgbValues[0], rgbValues[1], rgbValues[2]) + teamInfo.TeamBigLogo[i].Line);
                    TeamColorTest(teamInfo.TeamColor, ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2]), teamInfo.Icon, teamInfo.Name);
                }
                string r = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                       g = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                       b = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();

                if (selected is 0)
                    WriteAt(x, y, $"{FromRgb(255, 0, 0)}R{FromRgb(255, 255, 255) + r + FromHex("#aaaaaa")}↕ G{g}↕ B{b}↕");
                else if (selected is 1)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R{r}↕ {FromRgb(0, 255, 0)}G{FromRgb(255, 255, 255) + g + FromHex("#aaaaaa")}↕ B{b}↕");
                else if (selected is 2)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R{r}↕ G{g}↕ {FromRgb(0, 0, 255)}B{FromRgb(255, 255, 255) + b + FromHex("#aaaaaa")}↕");

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.RightArrow)
                    selected = Math.Min(selected + 1, 2);
                else if (key.Key is ConsoleKey.LeftArrow)
                    selected = Math.Max(selected - 1, 0);
                else if (key.Key is ConsoleKey.UpArrow)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 1, 255);
                else if (key.Key is ConsoleKey.DownArrow)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 1, 0);
                else if (key.Key is ConsoleKey.W)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 10, 255);
                else if (key.Key is ConsoleKey.S)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 10, 0);
                else if (key.Key is ConsoleKey.Enter)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R{r}↕ G{g}↕ B{b}↕");
                    escape = true;
                    break;
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R{rI}↕ G{gI}↕ B{bI}↕");
                    break;
                }
            }
            if (escape)
                color = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2]);
            return color;
        }
        public static string ColorSelector(int x, int y, string color, UserPortrait userPortrait, int type, bool reverse)
        {
            ConsoleKeyInfo key;
            bool escape = false;
            int selected = 0;
            var rgbValues = ColorConverter.HexToRgb(color);
            string rI = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                   gI = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                   bI = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();
            while (true)
            {
                if (type is 0)
                    DrawPortrait(90, 14, new UserPortrait
                    {
                        FacialHairStyle = userPortrait.FacialHairStyle,
                        FacialHairColor = userPortrait.FacialHairColor,
                        Hairstyle = userPortrait.Hairstyle,
                        HairColor = userPortrait.HairColor,
                        SkinColor = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2])
                    }, reverse);
                else if (type is 4)
                    DrawPortrait(90, 14, new UserPortrait
                    {
                        FacialHairStyle = userPortrait.FacialHairStyle,
                        FacialHairColor = userPortrait.FacialHairColor,
                        Hairstyle = userPortrait.Hairstyle,
                        SkinColor = userPortrait.SkinColor,
                        HairColor = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2])
                    }, reverse);
                else if (type is 8)
                    DrawPortrait(90, 14, new UserPortrait
                    {
                        FacialHairStyle = userPortrait.FacialHairStyle,
                        HairColor = userPortrait.HairColor,
                        Hairstyle = userPortrait.Hairstyle,
                        SkinColor = userPortrait.SkinColor,
                        FacialHairColor = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2])
                    }, reverse);

                string r = "".PadRight(3 - rgbValues[0].ToString().Length) + rgbValues[0].ToString(),
                       g = "".PadRight(3 - rgbValues[1].ToString().Length) + rgbValues[1].ToString(),
                       b = "".PadRight(3 - rgbValues[2].ToString().Length) + rgbValues[2].ToString();

                if (selected is 0)
                    WriteAt(x, y, $"{FromRgb(255, 0, 0)}R {FromRgb(255, 255, 255) + r + FromHex("#aaaaaa")}↕   G {g}↕   B {b}↕");
                else if (selected is 1)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   {FromRgb(0, 255, 0)}G {FromRgb(255, 255, 255) + g + FromHex("#aaaaaa")}↕   B {b}↕");
                else if (selected is 2)
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   G {g}↕   {FromRgb(0, 0, 255)}B {FromRgb(255, 255, 255) + b + FromHex("#aaaaaa")}↕");

                ClearKey();
                key = Console.ReadKey(true);
                if (key.Key is ConsoleKey.RightArrow)
                    selected = Math.Min(selected + 1, 2);
                else if (key.Key is ConsoleKey.LeftArrow)
                    selected = Math.Max(selected - 1, 0);
                else if (key.Key is ConsoleKey.UpArrow)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 1, 255);
                else if (key.Key is ConsoleKey.DownArrow)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 1, 0);
                else if (key.Key is ConsoleKey.W)
                    rgbValues[selected] = Math.Min(rgbValues[selected] + 10, 255);
                else if (key.Key is ConsoleKey.S)
                    rgbValues[selected] = Math.Max(rgbValues[selected] - 10, 0);
                else if (key.Key is ConsoleKey.Enter)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {r}↕   G {g}↕   B {b}↕");
                    escape = true;
                    break;
                }
                else if (key.Key is ConsoleKey.Escape)
                {
                    WriteAt(x, y, $"{FromHex("#aaaaaa")}R {rI}↕   G {gI}↕   B {bI}↕");
                    break;
                }
            }
            if (escape)
                color = ColorConverter.RgbToHex(rgbValues[0], rgbValues[1], rgbValues[2]);
            return color;
        }
        public static void TeamColorTest(string colorOne, string colorTwo, char icon, string name)
        {
            WriteAt(50, 14, FromHex("#aaaaaa") + $"Make sure your colors don't\nclash with other teams\n\n{FromHex(colorOne)}████████████████████\n");
            foreach (var team in Database.Constructors)
            {
                WriteAt(Console.CursorLeft, Console.CursorTop, FromHex(team.Color) + "██");
            }
            string nameTest = name.ToUpper();
            WriteAt(50, 19, "               ");
            WriteAt(50, 19, FromHex(colorOne) + nameTest);
            WriteAt(50, 22, FromHex("#aaaaaa") + $"Make your logo recognisable\n\n{FromHex(colorTwo) + icon} ");
            foreach (var team in Database.Constructors)
            {
                WriteAt(Console.CursorLeft, Console.CursorTop, FromHex(team.Color2) + team.Icon + " ");
            }
        }
    }
}
