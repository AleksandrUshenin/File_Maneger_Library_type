using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library_File_Maneger;

namespace Win_Forms_Maneger
{
    internal class UserInterfaceFW : IUserInterface
    {
        private Form1 Fmaneger;

        internal UserInterfaceFW(Form1 Fmaneger)
        {
            this.Fmaneger = Fmaneger;
        }
        //============== Print =============================
        public void PrintLeftWindow(string[] str)
        {
            Fmaneger.LeftWindow = str;
        }
        public void PrintRightWindow(string[] str)
        {
            Fmaneger.RightWindow = str;
        }
        public void PrintInfoWindow(string[] str)
        {
            Fmaneger.InfoWindow = str;
        }
        public void PrintCommandWindow(string str)
        {
        }
        public void PrintPages(int now, int max)
        { }
        public void PrintError(string str)
        {
        }
        public void PrintChangeWind()
        { }
        public void PrintDrive(string[] str)
        {
            Fmaneger.PrintComboBox(str);
        }
        //=============== Clear ========================
        public void ClearAll()
        {
            ClearLeftWindow();
            ClearRightWindow();
        }
        public void ClearLeftWindow()
        {
            Fmaneger.ClearLeft();
        }
        public void ClearRightWindow()
        {
            Fmaneger.ClearRight();
        }
        public void ClearInfoWindow()
        {
            Fmaneger.ClearInfo();
        }
        public void ClearCommandWindow()
        {
        }
        public void ClearPages()
        {
        }
        public void ClearError()
        {
        }

        public void PrintWrite(string str)
        {
        }

        public void PrintWriteLine(string str)
        {
        }

        public string ReadLine()
        {
            throw new NotImplementedException();
        }

        public UserCommandInfo ReadKey(bool status)
        {
            return Fmaneger.Command;
        }
    }
}
