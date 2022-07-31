using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_File_Maneger.User_Command
{
    public sealed class UserCommandInfo
    {
        public Command_List Key { get; private set; }
        public char KeyChar { get; private set; }
        public string LineCommand { get; private set; }


        public UserCommandInfo(Command_List Key)
        {
            this.Key = Key;
        }
        public UserCommandInfo(Command_List Key, string LineCommand)
            : this(Key)
        {
            this.LineCommand = LineCommand;
        }

        public static bool operator !=(UserCommandInfo a, UserCommandInfo b)
        {
            return a.Key != b.Key;
        }
        public static bool operator ==(UserCommandInfo a, UserCommandInfo b)
        {
            return a.Key == b.Key;
        }
    }
}
