using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formula_WOXO
{
    public class Util
    {
        public static string ReadInput(int maxLength)
        {
            StringBuilder inputBuilder = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key is ConsoleKey.Backspace && inputBuilder.Length > 0)
                {
                    Console.Write("\b \b");
                    inputBuilder.Remove(inputBuilder.Length - 1, 1);
                }
                else if (!char.IsControl(keyInfo.KeyChar) && inputBuilder.Length < maxLength)
                {
                    inputBuilder.Append(keyInfo.KeyChar);
                    Console.Write(keyInfo.KeyChar);
                }
                else if (keyInfo.Key is ConsoleKey.Escape)
                {
                    inputBuilder.Clear();
                    break;
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            return inputBuilder.ToString();
        }
        public static void WriteAt(int x, string text)
        {
            string[] lines = text.Split('\n');

            foreach (var line in lines)
            {
                Console.SetCursorPosition(x, Console.CursorTop + 1);
                Console.Write(line);
            }
        }
        public static void WriteAt(int x, int y, string text)
        {
            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(lines[i]);
            }
        }
        public static void ClearConsole(int startingPosition)
        {
            if (startingPosition >= 0)
            {
                string line = "".PadLeft(Console.WindowWidth - 1);
                Console.SetCursorPosition(0, startingPosition);
                for (int i = startingPosition; i <= Console.WindowHeight - startingPosition; i++)
                    Console.WriteLine(line);
                Console.SetCursorPosition(0, startingPosition);
            }
        }
        public static void ClearConsole(int startingPosition, int endingPosition)
        {
            if (startingPosition >= 0 && endingPosition >= 0)
            {
                string line = "".PadLeft(Console.WindowWidth - 1);
                Console.SetCursorPosition(0, startingPosition);
                for (int i = startingPosition; i <= endingPosition; i++)
                    Console.WriteLine(line);
                Console.SetCursorPosition(0, startingPosition);
            }
        }
        public static void ClearConsole()
        {
            string line = "".PadLeft(Console.WindowWidth - 1);
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i <= Console.WindowHeight; i++)
                Console.WriteLine(line);
            Console.SetCursorPosition(0, 0);
        }
        public static void KeyAdvance(ConsoleKey advanceKey)
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != advanceKey);
        }
        public static void KeyAdvance()
        {
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
            } while (key.Key != ConsoleKey.Enter);
        }
        public static void ClearKey()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }
        public static string WriteHeader(string text)
        {
            StringBuilder stringBuilder = new();

            List<Dictionary<char, string>> lettersRows = new List<Dictionary<char, string>>
            {
                new Dictionary<char, string>
                {
                    {' ', "  "}, {'A', "╭──╮"}, {'B', "┌──╮"}, {'C', "╭──╮"}, {'D', "┌──╮"},
                    {'E', "┌──╴"}, {'F', "┌──╴"}, {'G', "╭──╮"}, {'H', "╷  ╷"}, {'I', " ┬ "},
                    {'J', "  ╶┐"}, {'K', "╷ ╭╴"}, {'L', "╷  "}, {'M', "╭╮  ╭╮"}, {'N', "╭╮  ╷"},
                    {'O', "╭──╮"}, {'P', "┌──╮"}, {'Q', "╭──╮"}, {'R', "┌──╮"}, {'S', "╭──╴"},
                    {'T', "╶─┬─╴"}, {'U', "╷  ╷"}, {'V', "╷  ╷"}, {'W', "╷     ╷"}, {'X', "╭─╮╭─╮"},
                    {'Y', "╷   ╷"}, {'Z', "╶──╮"}, {'-', "    "}, 
                    {'1', " ╮ "}, {'2', "╶──╮"}, {'3', "╶──╮"}, {'4', "╷  ╷"}, {'5', "╭──╴"}, {'6', "╭──╴"}, {'7', "╶──╮"}, {'8', "╭──╮"}, {'9', "╭──╮"}, {'0', "╭──╮"}
                },
                new Dictionary<char, string>
                {
                    {' ', "  "}, {'A', "├──┤"}, {'B', "├──┤"}, {'C', "│   "}, {'D', "│  │"},
                    {'E', "├─╴ "}, {'F', "├─╴ "}, {'G', "│ ╶┐"}, {'H', "├──┤"}, {'I', " │ "},
                    {'J', "   │"}, {'K', "├─┴╮"}, {'L', "│  "}, {'M', "│╰──╯│"}, {'N', "│╰─╮│"},
                    {'O', "│  │"}, {'P', "├──╯"}, {'Q', "│  │"}, {'R', "├─┬╯"}, {'S', "╰──╮"},
                    {'T', "  │  "}, {'U', "│  │"}, {'V', "╰╮╭╯"}, {'W', "╰╮╭─╮╭╯"}, {'X', "  ├┤  "},
                    {'Y', "╰─┬─╯"}, {'Z', "╭──╯"}, {'-', "╶──╴"}, 
                    {'1', " │ "}, {'2', "╭──╯"}, {'3', " ──┤"}, {'4', "╰──┤"}, {'5', "╰──╮"}, {'6', "├──╮"}, {'7', "   │"}, {'8', "├──┤"}, {'9', "╰──┤"}, {'0', "│  │"}
                },
                new Dictionary<char, string>
                {
                    {' ', "  "}, {'A', "╵  ╵"}, {'B', "└──╯"}, {'C', "╰──╯"}, {'D', "└──╯"},
                    {'E', "└──╴"}, {'F', "╵   "}, {'G', "╰──╯"}, {'H', "╵  ╵"}, {'I', " ┴ "},
                    {'J', "╰──╯"}, {'K', "╵  ╵"}, {'L', "└──"}, {'M', "╵    ╵"}, {'N', "╵  ╰╯"},
                    {'O', "╰──╯"}, {'P', "╵   "}, {'Q', "╰──┤"}, {'R', "╵ ╰ "}, {'S', "╶──╯"},
                    {'T', "  ╵  "}, {'U', "╰──╯"}, {'V', " ╰╯ "}, {'W', " ╰╯ ╰╯ "}, {'X', "╰─╯╰─╯"},
                    {'Y', "  ╵  "}, {'Z', "╰──╴"}, {'-', "    "}, 
                    {'1', " ┴ "}, {'2', "╰──╴"}, {'3', "╶──╯"}, {'4', "   ╵"}, {'5', "╶──╯"}, {'6', "╰──╯"}, {'7', "   ╵"}, {'8', "╰──╯"}, {'9', "╶──╯"}, {'0', "╰──╯"}
                }
            };

            foreach (var lettersRow in lettersRows)
            {
                foreach (char c in text.ToUpper())
                {
                    stringBuilder.Append(lettersRow.ContainsKey(c) ? lettersRow[c] : "");
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
