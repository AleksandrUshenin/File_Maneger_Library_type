using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class Copy : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }
        private IUserInterface UserInterface;

        public Copy(DataDirectores[] DataDirs, IUserInterface UserInterface)
        {
            this.DataDirs = DataDirs;
            this.UserInterface = UserInterface;
        }

        public override void Execute(string[] args)
        {
            if (Directory.Exists(args[1]))
            {
                args[2] = Path.Combine(args[2], args[1].Split('\\').Last());
                Directory.CreateDirectory(args[2]);
                foreach (string str in Directory.GetFiles(args[1]))
                {
                    File.Copy(str, Path.Combine(args[2], Path.GetFileName(str)));
                }
                foreach (string str in Directory.GetDirectories(args[1]))
                {
                    Execute(args);
                }
            }
            else if (File.Exists(args[1]))
            {
                File.Copy(args[1], Path.Combine(args[2], args[1].Split('\\').Last()));
            }
            DataDirectores.Chenge_Windows();
            DataDirs[DataDirectores.Select_Window] =
                new DataDirectores(DataDirs[DataDirectores.Select_Window].DirHome,
               DataDirs[DataDirectores.Select_Window].Count_Lins);
            FileManagerLogic.InterfaceUser(UserInterface, DataDirs);
            DataDirectores.Chenge_Windows();
        }
    }
}
