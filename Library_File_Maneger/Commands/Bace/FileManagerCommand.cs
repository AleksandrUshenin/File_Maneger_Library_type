using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_File_Maneger.Commands.Bace
{
    internal abstract class FileManagerCommand
    {
        public abstract DataDirectores[] DataDirs { get; set; }

        public abstract void Execute(string[] args);
    }
}
