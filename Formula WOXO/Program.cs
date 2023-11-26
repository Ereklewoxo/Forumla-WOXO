using System.Data;
using System.Text;
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
        static void Main()
        {
            Thread disableCursorThread = new(new ThreadStart(DisableCursor))
            { IsBackground = true };
            disableCursorThread.Start();

            Console.OutputEncoding = Encoding.UTF8;

            var hwnd = GetConsoleWindow();
            PostMessage(hwnd, WM_KEYDOWN, (IntPtr)VK_F11, IntPtr.Zero);

            Console.Write("\x1b[48;2;0;0;0m");
            Console.Clear();

            for (int i = 0; i < 30; i++)
                Console.WriteLine("█████████                                                                                                         █████████");
            Console.Write("█████████ Zoom-in [CTRL + MOUSEWHEEL UP] so                                                                       █████████\n" +
            FromRgb(255, 255, 0) + "█████████ This row is visible" + 
            FromRgb(255, 255, 255) + "                                                                   And press [ENTER] " + FromRgb(255, 255, 0) + "█████████\n" + 
            FromRgb(255, 0, 0) + "█████████ And this one is not                                                                                     █████████");
            
            KeyAdvance();
            Console.Clear();
            foreach(var flag in SmallFlags)
            {
                WriteAt(5, Console.CursorTop + 2, flag.Value);
            }
            KeyAdvance();
            Console.Clear();


            hwnd = GetConsoleWindow();
            PostMessage(hwnd, WM_KEYDOWN, (IntPtr)VK_F11, IntPtr.Zero);
            PostMessage(hwnd, WM_KEYDOWN, (IntPtr)VK_F11, IntPtr.Zero);
            Console.Clear();
            Console.SetBufferSize(Console.LargestWindowWidth - 2, Console.LargestWindowHeight);

            //RaceHud(0);

            DrawInitialF1Logo();
            Console.Clear();
            Menu.MainMenu(5, 11);
        }
        static void DisableCursor()
        {
            while (true)
            {
                if (Console.CursorVisible == true)
                    Console.CursorVisible = false;
            }
        }

        public const int VK_F11 = 0x7A;

        public const uint WM_KEYDOWN = 0x100;

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}