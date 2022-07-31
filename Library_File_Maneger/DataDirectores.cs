using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_File_Maneger
{
    internal sealed class DataDirectores
    {
        //================= static ===============================
        /// <summary>
        /// Рабочие окно
        /// </summary>
        public static int Select_Window { get; private set; }
        /// <summary>
        /// Смена рабочего окна 
        /// </summary>
        public static void Chenge_Windows()
        {
            Select_Window = Select_Window == 0 ? 1 : 0;
        }
        //========================================================


        /// <summary>
        /// имя текущей директории
        /// </summary>
        public string DirHome { get; private set; }
        /// <summary>
        /// DirectoryInfo текущей директории
        /// </summary>
        public DirectoryInfo Dir_Info { get; private set; }
        /// <summary>
        /// DirectoryInfo[] текущей директории
        /// </summary>
        public DirectoryInfo[] Dirs_Info { get; private set; }
        /// <summary>
        /// FileInfo[] текущей директории
        /// </summary>
        public FileInfo[] File_Info { get; private set; }
        /// <summary>
        /// текущая страница
        /// </summary>
        public int Page;
        /// <summary>
        /// максимум страниц
        /// </summary>
        public int PageMax { get; private set; }
        /// <summary>
        /// список директорий и файлов
        /// </summary>
        public string[] AllDirectoris { get; private set; }
        /// <summary>
        /// число строк 
        /// </summary>
        public int Count_Lins { get; private set; }

        public DataDirectores(string homeDir, int countLins)
        {
            DirHome = homeDir;
            SetDInfo();
            GetInfo();
            Count_Lins = countLins;
            PageMax = AllDirectoris.Length / Count_Lins + (AllDirectoris.Length % Count_Lins == 0 ? 0 : 1);
        }

        public string[] GetDirsInPage()
        {
            string[] str = null;
            if (AllDirectoris.Length > Count_Lins)
            {
                str = new string[Count_Lins];
                int u = 0;
                for (int i = Count_Lins * Page; i < AllDirectoris.Length && u < Count_Lins; i++)
                {
                    str[u++] = AllDirectoris[i];
                }
            }
            return AllDirectoris;
        }

        private void SetDInfo()
        {
            Dir_Info = new DirectoryInfo(DirHome);
        }
        private void GetInfo()
        {
            Dirs_Info = Dir_Info.GetDirectories();
            File_Info = Dir_Info.GetFiles();

            AllDirectoris = new string[Dirs_Info.Length + File_Info.Length + 1];
            AllDirectoris[0] = @"\..";

            for (int i = 0; i < Dirs_Info.Length; i++)
            {
                AllDirectoris[i + 1] = Dirs_Info[i].Name;
            }
            int i2 = 0;
            for (int i = Dirs_Info.Length + 1; i2 < File_Info.Length; i++, i2++)
            {
                AllDirectoris[i] = File_Info[i2].Name;
            }
        }
    }
}
