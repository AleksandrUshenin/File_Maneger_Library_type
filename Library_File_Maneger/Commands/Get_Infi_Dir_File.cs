using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class Get_Infi_Dir_File : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }
        private IUserInterface User_inteface;

        public Get_Infi_Dir_File(DataDirectores[] DataDirs, IUserInterface User_inteface)
        {
            this.DataDirs = DataDirs;
            this.User_inteface = User_inteface;
        }

        public override void Execute(string[] args)
        {
            long total_length = 0;
            string[] mess;
            if (Directory.Exists(args[1]))
            {
                DirectoryInfo directory = new DirectoryInfo(args[1]);
                foreach (var file in directory.EnumerateFiles())
                {
                    total_length += file.Length;
                }
                total_length /= 1024;
                mess = new string[]
                {
                    directory.Name,
                    directory.LastWriteTime.ToString(),
                    total_length + " Mb"
                };
            }
            else
            {
                FileInfo file = new FileInfo(args[1]);
                total_length = file.Length;
                mess = new string[]
                {
                    file.Name,
                    file.LastWriteTime.ToString(),
                    total_length + " Mb"
                };
            }
            User_inteface.PrintInfoWindow(mess);
        }
    }
}
