using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger
{
    public sealed class FileManagerLogic
    {
        private static bool Can_Work = true;

        //=============== Data =========================
        private DataDirectores[] DataDirs;
        private IUserInterface UserInterface;
        private UserMenegement menegement;
        //==============================================

        public Dictionary<string, FileManagerCommand> Commands { get; private set; }

        public FileManagerLogic(DataDirectores[] DataDirs, IUserInterface UserInterface)
        {
            this.DataDirs = DataDirs;
            this.UserInterface = UserInterface;

            ListCommands listCommand = new ListCommands(DataDirs, UserInterface);
            Commands = listCommand.LoadCommand();
        }

        /// <summary>
        /// запуск
        /// </summary>
        public void Start()
        {
            menegement = new UserMenegement(DataDirs, UserInterface);

            UserInterface.PrintLeftWindow(DataDirs[0].GetDirsInPage());
            UserInterface.PrintRightWindow(DataDirs[1].GetDirsInPage());
            UserInterface.PrintPages
                (
                    DataDirs[DataDirectores.Select_Window].Page,
                    DataDirs[DataDirectores.Select_Window].PageMax
                );
            InterfaceUser(UserInterface, DataDirs);
            UserInterface.ClearCommandWindow();
            UserInterface.PrintCommandWindow(DataDirs[DataDirectores.Select_Window].DirHome);

            do
            {

                string input = menegement.Start();
                if (input != null)
                {
                    string[] args = input.Split(' ');
                    string command_name = args[0];

                    FileManagerCommand command;
                    if (Commands.TryGetValue(command_name.ToLower(), out command))
                    {
                        try
                        {
                            command.Execute(args);
                        }
                        catch (Exception ex)
                        {
                            UserInterface.PrintError("Oшибка! " + ex.Message);
                        }
                    }
                }

                InterfaceUser(UserInterface, DataDirs);
                UserInterface.ClearCommandWindow();
                UserInterface.PrintCommandWindow(DataDirs[DataDirectores.Select_Window].DirHome);
            }
            while (Can_Work);
        }
        /// <summary>
        /// От\становка программы
        /// </summary>
        public static void Stop()
        {
            Can_Work = false;
        }
        internal static void InterfaceUser(IUserInterface UserInterface, DataDirectores[] DataDirs)
        {
            if (DataDirectores.Select_Window == 0)
            {
                UserInterface.ClearLeftWindow();
                UserInterface.PrintLeftWindow(DataDirs[DataDirectores.Select_Window].GetDirsInPage());
            }
            else
            {
                UserInterface.ClearRightWindow();
                UserInterface.PrintRightWindow(DataDirs[DataDirectores.Select_Window].GetDirsInPage());
            }
        }
    }
}
