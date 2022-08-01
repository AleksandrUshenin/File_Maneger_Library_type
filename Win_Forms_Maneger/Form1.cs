using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Library_File_Maneger;
using Library_File_Maneger.User_Command;

namespace Win_Forms_Maneger
{
    public partial class Form1 : Form
    {
        //=============================== Private Data ===========================
        private DataDirectores[] data_dirs;
        private UserInterfaceFW WF_Interface;
        private FileManagerLogic file_maneger;
        private ControlCommand ControlCom;
        private string[] Drive;
        //=======================================================================
        public Form1(DataDirectores[] data_dirs)
        {
            InitializeComponent();
        }
        //=======================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            file_maneger = new FileManagerLogic(data_dirs, WF_Interface);
            ControlCom = new ControlCommand(data_dirs, file_maneger, Command, this);
            IdLeft = 0;
            IdRight = 0;

            Command = new UserCommandInfo(DisplayKey.LineCommand, "getdrives");
            FileManagerLogic.Stop();
            file_maneger.Start();
        }
        private void ChangeWind(int id)
        {
            if (DataDirectores.Select_Window != id)
            {
                DataDirectores.Chenge_Windows();
            }
        }
        //=============================== Public Data ===========================
        public string[] LeftWindow
        {
            get { return null; }
            set
            {
                ClearLeft();
                LeftListBox.Items.AddRange(value);
                if (data_dirs[0].AllDirectoris.Length <= IdLeft)
                {
                    IdLeft = 0;
                }
                LeftListBox.SetSelected(IdLeft, true);

            }
        }
        public string[] RightWindow
        {
            get { return null; }
            set
            {
                ClearRight();
                RightlistBox.Items.AddRange(value);
                if (data_dirs[1].AllDirectoris.Length <= IdRight)
                {
                    IdRight = 0;
                }
                RightlistBox.SetSelected(IdRight, true);
            }
        }
        public string[] InfoWindow
        {
            get { return null; }
            set
            {
                ClearInfo();
                InfolistBox.Items.AddRange(value);
            }
        }
        public int IdLeft { get; private set; }
        public int IdRight { get; private set; }
        public UserCommandInfo Command { get; private set; }
        public void SetUserCommandInfo(UserCommandInfo newCommand)
        {
            //() => Command = newCommand;
            Command = newCommand;
        }
        public void ClearLeft()
        {
            LeftListBox.Items.Clear();
        }
        public void ClearRight()
        {
            RightlistBox.Items.Clear();
        }
        public void ClearInfo()
        {
            InfolistBox.Items.Clear();
        }
        public void PrintComboBox(string[] str)
        {
            Drive = str;
            comboBoxLeft.Items.AddRange(str);
            comboBoxLeft.Text = "Select drive";
            comboBoxRight.Items.AddRange(str);
            comboBoxRight.Text = "Select drive";
        }
        //=======================================================================
    }
}
