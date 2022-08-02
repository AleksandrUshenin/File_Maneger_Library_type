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
            this.data_dirs = data_dirs;
            WF_Interface = new UserInterfaceFW(this);
            InitializeComponent();
        }
        //=======================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            file_maneger = new FileManagerLogic(data_dirs, WF_Interface);
            ControlCom = new ControlCommand(data_dirs, file_maneger, Command, this);
            IdLeft = 0;
            IdRight = 0;

            Command = new UserCommandInfo(Command_List.LineCommand, "getdrives");
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

        //========================== Left ======================================
        private void LeftListBox_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeWind(0);
            if (LeftListBox.SelectedIndex == 0)
            {
                Command = new UserCommandInfo(Command_List.ChangeDirUpp);
            }
            else
            {
                IdLeft = LeftListBox.SelectedIndex;
                Command = new UserCommandInfo(Command_List.GetLength, ControlCom.GetStringForInfo(IdLeft));
            }
            IdLeft = LeftListBox.SelectedIndex;
            file_maneger.Start();
        }
        private void LeftListBox_DoubleClick(object sender, EventArgs e)
        {
            Command = new UserCommandInfo(Command_List.ChangeDir, ControlCom.GetStringDir(IdLeft));
            file_maneger.Start();
        }

        private void LeftListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeWind(0);
            Command = new UserCommandInfo(Command_List.ChangeDir, Drive[comboBoxLeft.SelectedIndex]);
            file_maneger.Start();
        }

        //============================ Right ====================================
        private void RightlistBox_MouseDown(object sender, MouseEventArgs e)
        {
            ChangeWind(1);
            if (RightlistBox.SelectedIndex == 0)
            {
                Command = new UserCommandInfo(Command_List.ChangeDirUpp);
            }
            else
            {
                Command = new UserCommandInfo(Command_List.GetLength, ControlCom.GetStringDir(IdRight));
            }
            IdRight = RightlistBox.SelectedIndex;
            file_maneger.Start();
        }

        private void RightlistBox_DoubleClick(object sender, EventArgs e)
        {
            Command = new UserCommandInfo(Command_List.ChangeDir, ControlCom.GetStringDir(IdRight));
            file_maneger.Start();
        }

        private void RightlistBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeWind(1);
            Command = new UserCommandInfo(Command_List.ChangeDir, Drive[comboBoxRight.SelectedIndex]);
            file_maneger.Start();
        }

        //============================ Buttons ====================================

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            int otherWind = DataDirectores.Select_Window == 0 ? 1 : 0;
            int idFile;

            if (DataDirectores.Select_Window == 0)
            {
                idFile = LeftListBox.SelectedIndex;
            }
            else
            {
                idFile = RightlistBox.SelectedIndex;
            }

            string mess1 = data_dirs[DataDirectores.Select_Window].AllDirectoris[idFile];
            string mess2 = data_dirs[otherWind].DirHome;

            var result = MessageBox.Show("Копироавть: " + mess1 + " в " + mess2 + "?",
                                            "Копироавть?", MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Command = new UserCommandInfo
                    (
                        Command_List.Copy,
                        ControlCom.GetNameForCopy(idFile, otherWind)
                    );
            }
            file_maneger.Start();
        }

        private void buttonDelit_Click(object sender, EventArgs e)
        {
            int otherWind = DataDirectores.Select_Window == 0 ? 1 : 0;
            int idFile;

            if (DataDirectores.Select_Window == 0)
            {
                idFile = LeftListBox.SelectedIndex;
            }
            else
            {
                idFile = RightlistBox.SelectedIndex;
            }

            string mess = data_dirs[DataDirectores.Select_Window].AllDirectoris[idFile];
            var result = MessageBox.Show("Удалить: " + mess + "?",
                                            "Удалить?", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Command = new UserCommandInfo(Command_List.LineCommand, "rm -d " + ControlCom.GetNameForDelit(idFile));
            }
            file_maneger.Start();
        }

        private void buttonTouchFile_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(ControlCom, "Создание папки", "Имя папки:", 0);
            form2.Show();
        }

        private void buttonMkDir_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(ControlCom, "Создание файла", "Имя файла:", 0);
            form2.Show();
        }
    }
}
