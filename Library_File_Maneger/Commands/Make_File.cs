using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class Make_File : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }

        public Make_File(DataDirectores[] DataDirs)
        {
            this.DataDirs = DataDirs;
        }

        public override void Execute(string[] args)
        {
            File.Create(Path.Combine(DataDirs[DataDirectores.Select_Window].DirHome, args[1]));

            DataDirs[DataDirectores.Select_Window] = new DataDirectores(DataDirs[DataDirectores.Select_Window].DirHome,
               DataDirs[DataDirectores.Select_Window].Count_Lins);
        }
    }
}
