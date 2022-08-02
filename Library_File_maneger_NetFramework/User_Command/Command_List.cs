using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_File_Maneger.User_Command
{
    public enum Command_List
    {
        Null = 0,
        /// <summary>
        /// строка для хранение команды 
        /// </summary>
        LineCommand = 1,
        /// <summary>
        /// смена директории 
        /// </summary>
        ChangeDir = 2,
        /// <summary>
        /// смена директории на родительскую
        /// </summary>
        ChangeDirUpp = 3,
        /// <summary>
        /// получение размера папки/файла
        /// </summary>
        GetLength = 4,
        /// <summary>
        /// копированике
        /// </summary>
        Copy = 5,
        /// <summary>
        /// смена рабочего окна 
        /// </summary>
        Chenge_Windows = 9,
        /// <summary>
        /// выход 
        /// </summary>
        Exit = 255,
        /// <summary>
        /// получение информации
        /// </summary>
        Get_Information = 10,
        AutDatas = 11
    }
}
