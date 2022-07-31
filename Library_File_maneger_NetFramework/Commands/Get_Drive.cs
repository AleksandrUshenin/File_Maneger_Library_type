using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.Commands.Bace;

namespace Library_File_Maneger.Commands
{
    internal sealed class Get_Drive : FileManagerCommand
    {
        public override DataDirectores[] DataDirs { get; set; }
        private IUserInterface UserInterface;

        public Get_Drive(DataDirectores[] DataDirs, IUserInterface UserInterface)
        {
            this.UserInterface = UserInterface;
        }

        public override void Execute(string[] args)
        {
            DriveInfo[] drive = DriveInfo.GetDrives();
            var res1 = new DriveType[drive.Length];
            var res2 = new List<string>();
            for (int i = 0; i < drive.Length; i++)
            {
                res1[i] = drive[i].DriveType;
                if (res1[i] == DriveType.Fixed || res1[i] == DriveType.Removable)
                {
                    res2.Add(drive[i].RootDirectory.ToString());
                }
            }
            UserInterface.PrintDrive(res2.ToArray());
        }
    }
}
