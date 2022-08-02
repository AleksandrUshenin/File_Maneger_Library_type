using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win_Forms_Maneger
{
    public partial class Form2 : Form
    {
        private string Name;
        private int id;
        private ControlCommand ControlCom;

        public Form2(ControlCommand ControlCom, string text, string labelText, int id)
        {
            InitializeComponent();

            this.Text = text;
            this.label1.Text = labelText;
            this.id = id;
            this.ControlCom = ControlCom;
        }

        private void buttonDo_Click(object sender, EventArgs e)
        {
            Name = textBox.Text;
            if (id == 0)
            {
                ControlCom.button_Click_Directory(Name);
            }
            else
            {
                ControlCom.button_Click_File(Name);
            }
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
