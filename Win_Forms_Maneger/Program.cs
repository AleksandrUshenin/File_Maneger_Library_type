using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Library_File_Maneger;

namespace Win_Forms_Maneger
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataDirectores[] data_dirs = new DataDirectores[]
                {
                    new DataDirectores(Directory.GetCurrentDirectory(), 100),
                    new DataDirectores(Directory.GetCurrentDirectory(), 100)
                };
            //=================================================
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 FManeger = new Form1(data_dirs);

            Application.Run(FManeger);
        }
    }
}
