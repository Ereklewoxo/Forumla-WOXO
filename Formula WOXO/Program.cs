using System.Data;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Formula_WOXO.Graphics;
using static Formula_WOXO.Database;
using static Formula_WOXO.Util;
using static Formula_WOXO.Color;
using static Formula_WOXO.Race;

namespace Formula_WOXO
{
    internal class Program
    {
        #region Pre
        public const int VK_F11 = 0x7A;

        public const uint WM_KEYDOWN = 0x100;

        public const int SW_MAXIMIZE = 3;
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        public static void SetConsoleFullscreen()
        {
            var hwnd = GetConsoleWindow();
            PostMessage(hwnd, WM_KEYDOWN, VK_F11, IntPtr.Zero);
        }
        public static void SetConsoleBufferSizeToWindowSize()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }
        #endregion
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            CustomColor.Color();
            SetConsoleFullscreen();
            SetConsoleBufferSizeToWindowSize();
            Console.CursorVisible = false;

            DrawInitialF1Logo();
            Console.Clear();
            Menu.MainMenu(5, 11);
        }
    }
}