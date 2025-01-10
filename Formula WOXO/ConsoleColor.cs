using System.Runtime.InteropServices;

namespace Formula_WOXO
{
    public static class CustomColor
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetConsoleMode(IntPtr handle, out int mode);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(int handle);
        public static void Color()
        {
            var handle = GetStdHandle(-11);
            GetConsoleMode(handle, out int mode);
            SetConsoleMode(handle, mode | 0x4);
        }
    }
    public static class Color
    {
        public static string FromHex(string hex)
        {
            int[] rgb = ColorConverter.HexToRgb(hex);
            return $"\x1b[38;2;{rgb[0]};{rgb[1]};{rgb[2]}m";
        }
        public static string FromRgb(int red, int green, int blue)
        {
            return $"\x1b[38;2;{red};{green};{blue}m";
        }
        public static string FromHexBackground(string hex)
        {
            int[] rgb = ColorConverter.HexToRgb(hex);
            return $"\x1b[48;2;{rgb[0]};{rgb[1]};{rgb[2]}m";
        }
        public static string FromRgbBackground(int red, int green, int blue)
        {
            return $"\x1b[48;2;{red};{green};{blue}m";
        }
    }
    public class ColorTools
    {
        public static string[] ColorGradient(string color1, string color2, int steps)
        {
            int[] color1Rgb = ColorConverter.HexToRgb(color1);
            int[] color2Rgb = ColorConverter.HexToRgb(color2);
            string[] gradientColors = new string[steps];
            for (int i = 1; i <= steps; i++)
            {
                float ratio = (float)i / steps;
                int red = (int)(color1Rgb[0] * (1 - ratio) + color2Rgb[0] * ratio);
                int green = (int)(color1Rgb[1] * (1 - ratio) + color2Rgb[1] * ratio);
                int blue = (int)(color1Rgb[2] * (1 - ratio) + color2Rgb[2] * ratio);

                string hexValue = ColorConverter.RgbToHex(red, green, blue);

                gradientColors[i - 1] = hexValue;
            }
            return gradientColors;
        }
        public static string DarkenColor(string hexColor, double factor)
        {
            if (string.IsNullOrEmpty(hexColor) || hexColor.Length != 7 || hexColor[0] != '#')
            {
                throw new ArgumentException("Invalid hex color code format. It should be in the format '#RRGGBB'.");
            }

            int red = Convert.ToInt32(hexColor.Substring(1, 2), 16);
            int green = Convert.ToInt32(hexColor.Substring(3, 2), 16);
            int blue = Convert.ToInt32(hexColor.Substring(5, 2), 16);

            red = (int)(red * (1 - factor));
            green = (int)(green * (1 - factor));
            blue = (int)(blue * (1 - factor));

            red = Math.Max(0, Math.Min(255, red));
            green = Math.Max(0, Math.Min(255, green));
            blue = Math.Max(0, Math.Min(255, blue));

            return $"#{red:X2}{green:X2}{blue:X2}";
        }
    }
    public class ColorConverter
    {
        public static int[] HexToRgb(string hex)
        {
            hex = hex.TrimStart('#');
            if (hex.Length != 6)
                throw new ArgumentException("Hex color must be in the format RRGGBB.", nameof(hex));
            int red = Convert.ToInt32(hex[..2], 16),
                green = Convert.ToInt32(hex.Substring(2, 2), 16),
                blue = Convert.ToInt32(hex.Substring(4, 2), 16);
            int[] rgb = new int[3] { red, green, blue };
            return rgb;
        }
        public static string RgbToHex(int red, int green, int blue)
        {
            return "#" + red.ToString("X2") + green.ToString("X2") + blue.ToString("X2");
        }
    }
}
