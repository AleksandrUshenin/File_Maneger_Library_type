using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger;
using Library_File_Maneger.User_Command;

namespace Console_File_Maneger
{
    internal sealed class ConsoleUserInerface : IUserInterface
    {
        DataDirectores[] DataDirs;

        public ConsoleUserInerface(DataDirectores[] DataDirs)
        {
            DisplayConsole.Print();
            DisplayConsole.PrintDisplay2Line();
            this.DataDirs = DataDirs;
        }

        //============ Print ========================
        public void PrintLeftWindow(string[] str)
        {
            Print(str, DataDirs[0].Page, 0);
        }
        public void PrintRightWindow(string[] str)
        {
            Print(str, DataDirs[1].Page, 1);
        }
        public void PrintInfoWindow(string[] str)
        {
            int lint_y = 1;
            foreach (var line in str)
            {
                DisplayConsole.SetCursorPosition(2, DisplayConsole.Line1_2 + lint_y++);
                DisplayConsole.PrintWrite(line);
            }
        }
        public void PrintCommandWindow(string str)
        {
            DisplayConsole.PrintDirCommandLine(str);
        }
        public void PrintPages(int now, int max)
        {
            DisplayConsole.ChangrForegroundColor(Color.Blue);
            string pages = "╣ Page " + (now + 1) + "/" + max + " ╠";
            DisplayConsole.PrintWrite(DisplayConsole.WindowsWidth / 2 - pages.Length / 2, DisplayConsole.Line1_1, pages);
            DisplayConsole.ChangrForegroundColor(Color.White);
        }
        public void PrintError(string str)
        {
            DisplayConsole.CursorVisible(false);
            DisplayConsole.SetCursorPosition(2, DisplayConsole.Line1_2 + 3);
            DisplayConsole.ChangrForegroundColor(Color.Red);
            DisplayConsole.PrintStroks(str);
            DisplayConsole.ChangrForegroundColor(Color.White);
        }
        public void PrintDrive(string[] str)
        { }
        //==========================================
        public void Print(string[] str, int page, int NumDisplay)
        {
            int poz = 1;
            int Wind;
            if (NumDisplay == 0)
            {
                Wind = 2;
            }
            else
            {
                Wind = DisplayConsole.WindowsWidth / 2 + 1;
            }
            for (int i = (DisplayConsole.Line1_1 - 2) * page; i < DataDirs[NumDisplay].AllDirectoris.Length; i++, poz++)
            {
                if (poz <= DisplayConsole.Line1_1 - 1)
                {
                    if (i <= DataDirs[NumDisplay].Dirs_Info.Length)
                    {
                        DisplayConsole.ChangrForegroundColor(Color.White);
                    }
                    else
                    {
                        DisplayConsole.ChangrForegroundColor(Color.Yellow);
                    }
                    DisplayConsole.PrintWrite(Wind, poz, DataDirs[NumDisplay].AllDirectoris[i]);
                }
                else
                {
                    break;
                }
            }
            DisplayConsole.Print_Cursor(DataDirs[DataDirectores.Select_Window].AllDirectoris, 0, DataDirs);
        }
        public void PrintChangeWind()
        { }
        //=========== Clear ==================
        public void ClearAll()
        {
            ClearLeftWindow();
            ClearRightWindow();
            ClearInfoWindow();
            ClearCommandWindow();
            ClearPages();
            ClearError();
        }
        public void ClearLeftWindow()
        {
            ClearWindows(0);
        }
        public void ClearRightWindow()
        {
            ClearWindows(1);
        }
        public void ClearInfoWindow()
        {
            DisplayConsole.CursorVisible(false);
            for (int i = 1; i < DisplayConsole.WindowsWidth - 2; i++)
            {
                for (int j = DisplayConsole.Line1_2 + 1; j < DisplayConsole.Line2_1; j++)
                {
                    DisplayConsole.SetCursorPosition(i, j);
                    DisplayConsole.PrintWrite(" ");
                }
            }
        }
        public void ClearCommandWindow()
        {
            DisplayConsole.DelitConsole();
        }
        public void ClearPages()
        {
        }
        public void ClearError()
        {
            ClearInfoWindow();
        }
        public void ClearWindows(int NumDisp)
        {
            DisplayConsole.CursorVisible(false);
            DisplayConsole.ChangeBackgroundColor(Color.Black);
            int start, end;
            if (NumDisp == 0)
            {
                start = 1;
                end = (DisplayConsole.WindowsWidth - 1) / 2;
            }
            else
            {
                end = DisplayConsole.WindowsWidth - 1;
                start = DisplayConsole.WindowsWidth / 2;
            }
            for (int i = start; i < end; i++)
            {
                for (int j = 1; j < DisplayConsole.Line1_1; j++)
                {
                    DisplayConsole.PrintWrite(i, j, " ");
                }
            }
            DisplayConsole.CursorVisible(true);
        }
        //======================================

        public void PrintWrite(string str)
        {
            throw new NotImplementedException();
        }

        public void PrintWriteLine(string str)
        {
            throw new NotImplementedException();
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        public UserCommandInfo ReadKey(bool status)
        {
            ControlKeys consKeys = new ControlKeys(DataDirs);
            return consKeys.Start();
        }
    }
}
