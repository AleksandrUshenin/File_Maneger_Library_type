using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger;
using Library_File_Maneger.User_Command;

namespace Console_File_Maneger
{
    internal sealed class ControlKeys
    {
        public static int Select;
        private DataDirectores[] DataDirs;

        public ControlKeys(DataDirectores[] DataDirs)
        {
            this.DataDirs = DataDirs;
        }

        public UserCommandInfo Start()
        {
            bool status = true;
            StringBuilder command = new StringBuilder(255);

            //--------------------------------------------

            do
            {
                DisplayConsole.CursorVisible(true);
                ConsoleKeyInfo infoKey = Console.ReadKey(true);
                switch (infoKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (PressUpp())
                        {
                            return new UserCommandInfo(Command_List.GetLength,
                                Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome,
                                DataDirs[DataDirectores.Select_Window].AllDirectoris[Select]));
                        }
                        break;
                    //==============================================================================
                    case ConsoleKey.DownArrow:
                        if (PressDown())
                        {
                            return new UserCommandInfo(Command_List.GetLength,
                                Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome,
                                DataDirs[DataDirectores.Select_Window].AllDirectoris[Select]));
                        }
                        break;
                    //==============================================================================
                    case ConsoleKey.F1:
                        PressChangePage();
                        break;
                    //==============================================================================
                    case ConsoleKey.F5:
                        return new UserCommandInfo(Command_List.Copy,
                           Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome,
                                        DataDirs[DataDirectores.Select_Window].AllDirectoris[Select])
                           + " " + DataDirs[DataDirectores.Select_Window == 0 ? 1 : 0].DirHome);
                    //==============================================================================
                    case ConsoleKey.Tab:
                        PressTAB();
                        return new UserCommandInfo(Command_List.Chenge_Windows);
                    //==============================================================================
                    case ConsoleKey.Escape:
                        return new UserCommandInfo(Command_List.Exit);
                    //==============================================================================
                    case ConsoleKey.Enter:
                        DisplayConsole.DefoltCordinate();
                        if (command.Length > 0)
                        {
                            ChangeSelect(0);
                            DisplayConsole.DelitConsole();
                            return new UserCommandInfo(Command_List.LineCommand, command.ToString());
                        }
                        else
                        {
                            if (Select == 0)
                            {
                                return new UserCommandInfo(Command_List.ChangeDirUpp);
                            }
                            if (DataDirs[DataDirectores.Select_Window].Dirs_Info.Length > 0)
                            {
                                int select2 = Select;
                                ChangeSelect(0);
                                return new UserCommandInfo(Command_List.ChangeDir,
                                DataDirs[DataDirectores.Select_Window].Dirs_Info[select2 - 1].FullName);
                            }
                        }
                        break;
                    //==============================================================================
                    case ConsoleKey.Backspace:
                        if (command.Length > 0)
                        {
                            DisplayConsole.DeliteCharInCommandLine(DataDirs[DataDirectores.Select_Window].DirHome, command.Length);
                            command.Remove(command.Length - 1, 1);
                        }
                        break;
                    //==============================================================================
                    default:
                        if (infoKey.Key != ConsoleKey.LeftArrow && infoKey.Key != ConsoleKey.RightArrow
                            && Console.CursorLeft < DisplayConsole.WindowsWidth - 2)
                        {
                            command.Append(infoKey.KeyChar);
                            DisplayConsole.PrintStringInCommandLine(DataDirs[DataDirectores.Select_Window].DirHome.Length,
                                command.ToString());
                        }
                        break;
                        //==============================================================================
                }
            }
            while (status);
            return new UserCommandInfo(Command_List.Null);
        }

        //============== Button meyhods =========================
        private void ChangeSelect(int changeInt)
        {
            int SelectNew = Select;
            SelectNew = changeInt;

            if (SelectNew < DataDirs[DataDirectores.Select_Window].AllDirectoris.Length)
            {
                Select = SelectNew;
            }
        }
        private bool GetZone()
        {
            return DisplayConsole.Y < DataDirs[DataDirectores.Select_Window].AllDirectoris.Length
                && DisplayConsole.Y < DisplayConsole.Line1_1 - 1;
        }
        /// <summary>
        /// отработка нажатие клавиши верх
        /// паралельная работа метода подсчета размера файла/папки 
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="select"></param>
        /// <param name="X"></param>
        private bool PressUpp()
        {
            if (DataDirs[DataDirectores.Select_Window].AllDirectoris.Length == 1)
            {
                DisplayConsole.DefoltCordinate();
                ChangeSelect(0);
                return false;
            }
            if (DisplayConsole.Y != DisplayConsole.Y_Min)
            {
                DisplayConsole.Print_Cursor
                    (
                        DataDirs[DataDirectores.Select_Window].AllDirectoris,
                        1,
                        DataDirs
                    );
                DisplayConsole.Y--;
                ChangeSelect(Select > 0 ? --Select : 0);
                DisplayConsole.Print_Cursor
                    (
                        DataDirs[DataDirectores.Select_Window].AllDirectoris,
                        0,
                        DataDirs
                     );
                return true;
            }
            return false;
        }
        /// <summary>
        /// отработка нажатие клавиши вниз
        /// паралельная работа метода подсчета размера файла/папки 
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="select"></param>
        /// <param name="X"></param>
        private bool PressDown()
        {
            if (DataDirs[DataDirectores.Select_Window].AllDirectoris.Length == 1)
            {
                DisplayConsole.DefoltCordinate();
                ChangeSelect(0);
                return false;
            }
            if (DisplayConsole.Y != 0 && GetZone())
            {
                DisplayConsole.Print_Cursor
                    (
                        DataDirs[DataDirectores.Select_Window].AllDirectoris,
                        1, DataDirs
                    );
                DisplayConsole.Y++;
                ChangeSelect(++Select);
                DisplayConsole.Print_Cursor
                    (
                        DataDirs[DataDirectores.Select_Window].AllDirectoris,
                        0, DataDirs
                    );
                return true;
            }
            return false;
        }
        /// <summary>
        /// метод сметы страниццы
        /// </summary>
        /// <param name="Y"></param>
        /// <param name="Select"></param>
        private void PressChangePage()
        {
            DisplayConsole.DefoltCordinate();
            //DisplayConsole.Y = 1;
            if (DataDirs[DataDirectores.Select_Window].Page != DataDirs[DataDirectores.Select_Window].PageMax - 1
                && DataDirs[DataDirectores.Select_Window].PageMax != 0)
            {
                DataDirs[DataDirectores.Select_Window].Page++;
                ChangeSelect(DisplayConsole.Line1_1 - 2);
            }
            else
            {
                DataDirs[DataDirectores.Select_Window].Page = 0;
                ChangeSelect(0);
            }
        }
        /// <summary>
        /// метод смены окна
        /// </summary>
        private void PressTAB()
        {
            DisplayConsole.Print_Cursor(DataDirs[DataDirectores.Select_Window].AllDirectoris, 1, DataDirs);
            DisplayConsole.Y = 1;
            ChangeSelect(0);
            DisplayConsole.X = DataDirectores.Select_Window == 1 ? 2 : DisplayConsole.WindowsWidth / 2 + 1;
            DisplayConsole.Print_Cursor(DataDirs[DataDirectores.Select_Window].AllDirectoris, 0, DataDirs);

            DisplayConsole.ChangrForegroundColor(Color.White);
            DisplayConsole.DelitConsole();
            DisplayConsole.PrintWrite(2, DisplayConsole.Line2_2 + 1, DataDirs[DataDirectores.Select_Window].DirHome + " > ");
        }
    }
}
