using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_File_Maneger.Commands.Bace
{
    internal sealed class ListCommands
    {
        private DataDirectores[] DataDirs;
        private IUserInterface UserInterface;

        public ListCommands(DataDirectores[] DataDir, IUserInterface UserInterface)
        {
            this.DataDirs = DataDir;
            this.UserInterface = UserInterface;
        }
        public Dictionary<string, FileManagerCommand> LoadCommand()
        {
            return new Dictionary<string, FileManagerCommand>
            {
                { "cd", new ChangeDir(DataDirs) },
                { "cp", new Copy(DataDirs, UserInterface) },
                { "rm", new Remove(DataDirs) },
                { "mkdir", new Make_Directory(DataDirs) },
                { "touch", new Make_File(DataDirs) },
                { "length", new Get_Infi_Dir_File(DataDirs, UserInterface) },
                { "getdrives", new Get_Drive(DataDirs, UserInterface) }
            };
        }
    }
}
