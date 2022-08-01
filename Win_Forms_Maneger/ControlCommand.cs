using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Library_File_Maneger;
using Library_File_Maneger.User_Command;

namespace Win_Forms_Maneger
{
    internal class ControlCommand
    {
        private DataDirectores[] data_dirs;
        private FileManagerLogic file_maneger;
        private UserCommandInfo Command;
        private Form1 FManeger;
        internal ControlCommand(DataDirectores[] data_dirs, FileManagerLogic file_maneger, UserCommandInfo Command,
            Form1 FManeger)
        {
            this.data_dirs = data_dirs;
            this.file_maneger = file_maneger;
            this.Command = Command;
            this.FManeger = FManeger;
        }

        internal string GetStringDir(int id)
        {
            try
            {
                if (id == 0)
                {
                    return Directory.GetParent(data_dirs[DataDirectores.Select_Window].DirHome).FullName;
                }
                string directory = Path.Combine(data_dirs[DataDirectores.Select_Window].DirHome,
                    data_dirs[DataDirectores.Select_Window].AllDirectoris[id]);
                if (Directory.Exists(directory))
                {
                    return directory;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        internal string GetStringDir(string DirPath)
        {
            try
            {
                if (Directory.Exists(DirPath))
                {
                    return DirPath;
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        internal string GetStringForInfo(int id)
        {
            try
            {
                return Path.Combine(data_dirs[DataDirectores.Select_Window].DirHome,
                    data_dirs[DataDirectores.Select_Window].AllDirectoris[id]);
            }
            catch
            {
                return "";
            }
        }
        internal string GetNameForCopy(int idFrom, int idTo)
        {
            return Path.Combine(
                                    data_dirs[DataDirectores.Select_Window].DirHome,
                                    data_dirs[DataDirectores.Select_Window].AllDirectoris[idFrom]
                                ) + " " + data_dirs[idTo].DirHome;
        }
        internal string GetNameForDelit(int idFile)
        {
            return Path.Combine(data_dirs[DataDirectores.Select_Window].DirHome,
                data_dirs[DataDirectores.Select_Window].AllDirectoris[idFile]);
        }
        internal void button_Click_File(string name)
        {
            FManeger.SetUserCommandInfo(new UserCommandInfo(DisplayKey.LineCommand, "touch " + name));
            file_maneger.Start();
        }
        internal void button_Click_Directory(string name)
        {
            FManeger.SetUserCommandInfo(new UserCommandInfo(DisplayKey.LineCommand, "mkdir " + name));
            file_maneger.Start();
        }
    }
}
