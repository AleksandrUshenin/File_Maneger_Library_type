using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class Remove : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }

        public Remove(DataDirectores[] DataDirs)
        {
            this.DataDirs = DataDirs;
        }

        public override void Execute(string[] args)
        {
            if ((args[1] == "-d" || args[1] == "-D") && Directory.Exists(args[2]))
            {
                Rm_D(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, args[2]));
            }
            Rm(args.Last());
            DataDirs[DataDirectores.Select_Window] = new DataDirectores(DataDirs[DataDirectores.Select_Window].DirHome,
                DataDirs[DataDirectores.Select_Window].Count_Lins);
        }
        private void Rm(string com)
        {
            if (File.Exists(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, com)))
            {
                File.Delete(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, com));
            }
            else if (Directory.Exists(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, com)))
            {
                Directory.Delete(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, com));
                if (DataDirs[DataDirectores.Select_Window].Dirs_Info.Length == 1 && DataDirs[DataDirectores.Select_Window].File_Info.Length == 0)
                {
                    DataDirs[DataDirectores.Select_Window] = new DataDirectores
                        (
                            DataDirs[DataDirectores.Select_Window].Dir_Info.Parent.FullName,
                            DataDirs[DataDirectores.Select_Window].Count_Lins
                        );
                }
            }
        }
        private void Rm_D(string com)
        {
            string[] fileinfo = Directory.GetFiles(com);
            foreach (string Dfile in fileinfo)
            {
                File.Delete(Dfile);
            }
            string[] dirinfo = Directory.GetDirectories(com);
            foreach (string Ddir in dirinfo)
            {
                Rm_D(Ddir);
            }
            Directory.Delete(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, com));
        }
    }
}
