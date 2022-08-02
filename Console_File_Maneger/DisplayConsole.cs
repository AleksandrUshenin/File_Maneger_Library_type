using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger;

namespace Console_File_Maneger
{
    enum Color
    {
        Black,
        White,
        Yellow,
        Blue,
        DarkMagenta,
        Red
    }
    internal static class DisplayConsole
    {
        public static int X = 2;
        public static int Y = 1;
        public static readonly int Y_Min = 1;
        public static readonly int Y_Max;
        private static int[] PisitionCursorInCommandLine = new int[] { 2, 32 };
        public static void DefoltCordinate()
        {
            if (DataDirectores.Select_Window == 0)
            {
                X = 2;
                Y = 1;
            }
            else
            {
                X = DataDirectores.Select_Window == 0 ? 2 : WindowsWidth / 2 + 1;
                Y = 1;
            }
        }
        //============== Size Buffer =========================
        public static readonly int WindowHeight = 34;
        public static readonly int WindowsWidth = 100;
        //============== Line Cordinate =========================
        public static readonly int Line1_1 = 23;
        public static readonly int Line1_2 = 24;
        public static readonly int Line2_1 = 30;
        public static readonly int Line2_2 = 31;

        //============== Command Line =========================
        public static void PrintDirCommandLine(string Dir)
        {
            ChangrForegroundColor(Color.White);
            SetCursorPosition(PisitionCursorInCommandLine[0], PisitionCursorInCommandLine[1]);
            PrintWrite(Dir + " > ");
        }
        public static void PrintStringInCommandLine(int DirLength, string str)
        {
            ChangrForegroundColor(Color.White);
            SetCursorPosition(PisitionCursorInCommandLine[0] + 3 + DirLength, PisitionCursorInCommandLine[1]);
            PrintWrite(str);
        }
        public static void DeliteCharInCommandLine(string Dir, int Length)
        {
            SetCursorPosition(PisitionCursorInCommandLine[0] + 2 + Dir.Length + Length, PisitionCursorInCommandLine[1]);
            PrintWrite(" ");
            SetCursorPosition(PisitionCursorInCommandLine[0] + 2 + Dir.Length + Length, PisitionCursorInCommandLine[1]);
        }
        public static void DelitConsole()
        {
            Console.SetCursorPosition(1, Line2_2 + 1);
            for (int i = 0; i < WindowsWidth - 2; i++)
            {
                PrintWrite(" ");
            }
        }
        //============== Print ================================
        public static void PrintWrite(int x, int y, string messege)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(messege);
        }
        public static void PrintWrite(string messege)
        {
            Console.Write(messege);
        }
        public static void PrintStroks(string mess)
        {
            if (mess.Length > WindowsWidth - 2)
            {
                string mess1 = mess.Substring(0, WindowsWidth / 2);
                string mess2 = mess.Substring((WindowsWidth / 2) + 1, mess.Length - 1);
                Console.Write(mess1);
                Console.SetCursorPosition(2, Line1_2 + 2);
                Console.Write(mess2);
            }
            else
            {
                Console.Write(mess);
            }
        }
        /// <summary>
        /// отрисовка курсора
        /// </summary>
        /// <param name="direcroris"></param>
        /// <param name="color"></param>
        /// <param name="DataDirs"></param>
        public static void Print_Cursor(string[] direcroris, int color, DataDirectores[] DataDirs)
        {
            if (ControlKeys.Select <= DataDirs[DataDirectores.Select_Window].Dirs_Info.Length)
            {
                PrintAndSelectColor(DisplayConsole.X, DisplayConsole.Y, direcroris[ControlKeys.Select], color);
            }
            else
            {
                if (color == 1)
                {
                    PrintAndSelectColor(DisplayConsole.X, DisplayConsole.Y, direcroris[ControlKeys.Select], 2);
                }
                else
                {
                    PrintAndSelectColor(DisplayConsole.X, DisplayConsole.Y, direcroris[ControlKeys.Select], color);
                }
            }
        }
        private static void PrintAndSelectColor(int x, int y, string res, int color)
        {
            switch (color)
            {
                case 0:
                    ChangeBackgroundColor(Color.DarkMagenta);
                    ChangrForegroundColor(Color.Yellow);
                    break;
                case 1:
                    ChangeBackgroundColor(Color.Black);
                    ChangrForegroundColor(Color.White);
                    break;
                case 2:
                    ChangeBackgroundColor(Color.Black);
                    ChangrForegroundColor(Color.Yellow);
                    break;
            }

            SetCursorPosition(x, y);
            PrintWrite(res);
            ChangeBackgroundColor(Color.Black);
        }
        //============== Print frame ========================
        public static void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintZnak(0, 0, '╔');
            PrintZnak(WindowsWidth - 1, 0, '╗');
            for (int i = 0; i < WindowsWidth - 2; i++)
            {
                PrintZnak(i + 1, 0, '═');
                PrintZnak(i + 1, Line1_1, '═');
                PrintZnak(i + 1, Line1_2, '═');
                PrintZnak(i + 1, Line2_1, '═');
                PrintZnak(i + 1, Line2_2, '═');
                PrintZnak(i + 1, WindowHeight - 1, '═');
            }
            for (int i = 1; i < WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
                Console.SetCursorPosition(WindowsWidth - 1, i);
                Console.Write("║");
            }

            PrintZnak(0, WindowHeight - 1, '╚');
            PrintZnak(WindowsWidth - 1, WindowHeight - 1, '╝');
            PrintZnak(0, Line1_1, '╚');
            PrintZnak(0, Line2_1, '╚');
            PrintZnak(WindowsWidth - 1, Line1_1, '╝');
            PrintZnak(WindowsWidth - 1, Line2_1, '╝');
            PrintZnak(0, Line1_2, '╔');
            PrintZnak(0, Line2_2, '╔');
            PrintZnak(WindowsWidth - 1, Line1_2, '╗');
            PrintZnak(WindowsWidth - 1, Line2_2, '╗');

            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PrintDisplay2Line()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintZnak((WindowsWidth - 2) / 2, 0, '╦');
            for (int i = 1; i < Line1_1; i++)
            {
                PrintZnak((WindowsWidth - 2) / 2, i, '║');
            }
            PrintZnak((WindowsWidth - 2) / 2, Line1_1, '╩');
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void PrintZnak(int x, int y, char znak)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(znak);
        }
        //============== Change color =====================
        public static void ChangeBackgroundColor(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
                case Color.White:
                    Console.BackgroundColor = ConsoleColor.White;
                    break;
                case Color.Yellow:
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                case Color.Blue:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case Color.DarkMagenta:
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case Color.Red:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
            }
        }
        public static void ChangrForegroundColor(Color color)
        {
            switch (color)
            {
                case Color.Black:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case Color.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Color.DarkMagenta:
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
        }
        public static void SetCursorPosition(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
        //========================================
        /// <summary>
        /// Возвращает или задает значение, указывающее, видим ли курсор.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static bool CursorVisible(bool status = true)
        {
            return Console.CursorVisible = status;
        }
    }
}
