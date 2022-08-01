using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.User_Command;

namespace Library_File_Maneger
{
    internal sealed class UserMenegement
    {
        private readonly DataDirectores[] DataDirs;
        private IUserInterface UserInterface;


        public UserMenegement(DataDirectores[] DataDirs, IUserInterface UserInterface)
        {
            this.DataDirs = DataDirs;
            this.UserInterface = UserInterface;
        }
        /// <summary>
        /// запуск
        /// </summary>
        /// <returns></returns>
        public string Start()
        {
            UserCommandInfo infoKey = UserInterface.ReadKey(true);
            if (infoKey.Key == null)
            {
                return " ";
            }
            switch (infoKey.Key)
            {
                case Command_List.ChangeDirUpp:
                    return "cd " + Directory.GetParent
                        (
                           DataDirs[DataDirectores.Select_Window].DirHome
                        );
                //=======================================================
                case Command_List.ChangeDir:
                    return "cd " + infoKey.LineCommand;
                //=======================================================
                case Command_List.Chenge_Windows:
                    DataDirectores.Chenge_Windows();
                    break;
                //=======================================================
                case Command_List.LineCommand:
                    return infoKey.LineCommand;
                //=======================================================
                case Command_List.GetLength:
                    return "length " + infoKey.LineCommand;
                //=======================================================
                case Command_List.Copy:
                    return "cp " + infoKey.LineCommand;
                //=======================================================
                case Command_List.Exit:
                    FileManagerLogic.Stop();
                    break;
                //=======================================================
                case Command_List.Get_Information:
                    break;
                //=======================================================
                default:    //исправить
                    return infoKey.LineCommand;
            }
            return " ";
        }
    }
}
