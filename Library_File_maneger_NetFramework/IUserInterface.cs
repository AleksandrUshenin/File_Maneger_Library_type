using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger.User_Command;

namespace Library_File_Maneger
{
    public interface IUserInterface
    {
        //=================== Print =================================
        void PrintLeftWindow(string[] str);
        void PrintRightWindow(string[] str);
        void PrintInfoWindow(string[] str);
        void PrintCommandWindow(string str);
        void PrintPages(int now, int max);
        void PrintError(string str);
        void PrintDrive(string[] str);
        //=================== Print other ===========================
        void PrintChangeWind();
        //==================== Clear ================================
        void ClearAll();
        void ClearLeftWindow();
        void ClearRightWindow();
        void ClearInfoWindow();
        void ClearCommandWindow();
        void ClearPages();
        void ClearError();
        //==================== Print Write ==========================
        void PrintWrite(string str);
        void PrintWriteLine(string str);
        //===================== Read Line ===========================
        string ReadLine();
        //===================== Read Key ============================
        UserCommandInfo ReadKey(bool status);
        //===========================================================
    }
}
