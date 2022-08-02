using System.IO;

using Library_File_Maneger;

namespace Console_File_Maneger
{
    class Program
    {
        static void Main(string[] args)
        {
            SetWindowsSise();
            int siseWin = 20;
            DataDirectores[] DataDirs = new DataDirectores[]
            {
                new DataDirectores(Directory.GetCurrentDirectory(), siseWin),
                new DataDirectores(Directory.GetCurrentDirectory(), siseWin)
            };

            ConsoleUserInerface userInterface = new ConsoleUserInerface(DataDirs);

            FileManagerLogic MenegeLogik = new FileManagerLogic
                (
                    DataDirs,
                    userInterface
                );
            MenegeLogik.Start();
        }
        static void SetWindowsSise()
        {
            Console.WindowHeight = 34;
            Console.WindowWidth = 100;
            Console.BufferHeight = 34;
            Console.BufferWidth = 101;
            Console.Title = "File Maneger v2";
        }
    }
}
