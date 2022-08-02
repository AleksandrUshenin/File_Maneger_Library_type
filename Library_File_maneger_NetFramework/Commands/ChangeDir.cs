using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class ChangeDir : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }

        public ChangeDir(DataDirectores[] dataDir)
        {
            DataDirs = dataDir;
        }

        public override void Execute(string[] args)
        {
            if (Directory.Exists(args.Last()))
            {
                DataDirs[DataDirectores.Select_Window] = new DataDirectores(args.Last(), DataDirs[DataDirectores.Select_Window].Count_Lins);
            }
        }
    }
}
