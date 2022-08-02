namespace Win_Forms_Maneger
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeftListBox = new System.Windows.Forms.ListBox();
            this.RightlistBox = new System.Windows.Forms.ListBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonDelit = new System.Windows.Forms.Button();
            this.buttonTouchFile = new System.Windows.Forms.Button();
            this.buttonMkDir = new System.Windows.Forms.Button();
            this.comboBoxLeft = new System.Windows.Forms.ComboBox();
            this.comboBoxRight = new System.Windows.Forms.ComboBox();
            this.InfolistBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LeftListBox
            // 
            this.LeftListBox.FormattingEnabled = true;
            this.LeftListBox.ItemHeight = 16;
            this.LeftListBox.Location = new System.Drawing.Point(12, 114);
            this.LeftListBox.Name = "LeftListBox";
            this.LeftListBox.Size = new System.Drawing.Size(392, 388);
            this.LeftListBox.TabIndex = 0;
            this.LeftListBox.DoubleClick += new System.EventHandler(this.LeftListBox_DoubleClick);
            this.LeftListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftListBox_MouseDown);
            // 
            // RightlistBox
            // 
            this.RightlistBox.FormattingEnabled = true;
            this.RightlistBox.ItemHeight = 16;
            this.RightlistBox.Location = new System.Drawing.Point(422, 114);
            this.RightlistBox.Name = "RightlistBox";
            this.RightlistBox.Size = new System.Drawing.Size(392, 388);
            this.RightlistBox.TabIndex = 1;
            this.RightlistBox.DoubleClick += new System.EventHandler(this.RightlistBox_DoubleClick);
            this.RightlistBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightlistBox_MouseDown);
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(35, 651);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(123, 45);
            this.buttonCopy.TabIndex = 2;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonDelit
            // 
            this.buttonDelit.Location = new System.Drawing.Point(207, 651);
            this.buttonDelit.Name = "buttonDelit";
            this.buttonDelit.Size = new System.Drawing.Size(123, 45);
            this.buttonDelit.TabIndex = 3;
            this.buttonDelit.Text = "Delit";
            this.buttonDelit.UseVisualStyleBackColor = true;
            this.buttonDelit.Click += new System.EventHandler(this.buttonDelit_Click);
            // 
            // buttonTouchFile
            // 
            this.buttonTouchFile.Location = new System.Drawing.Point(451, 651);
            this.buttonTouchFile.Name = "buttonTouchFile";
            this.buttonTouchFile.Size = new System.Drawing.Size(123, 45);
            this.buttonTouchFile.TabIndex = 4;
            this.buttonTouchFile.Text = "Touch File";
            this.buttonTouchFile.UseVisualStyleBackColor = true;
            this.buttonTouchFile.Click += new System.EventHandler(this.buttonTouchFile_Click);
            // 
            // buttonMkDir
            // 
            this.buttonMkDir.Location = new System.Drawing.Point(630, 651);
            this.buttonMkDir.Name = "buttonMkDir";
            this.buttonMkDir.Size = new System.Drawing.Size(123, 45);
            this.buttonMkDir.TabIndex = 5;
            this.buttonMkDir.Text = "Make Dir";
            this.buttonMkDir.UseVisualStyleBackColor = true;
            this.buttonMkDir.Click += new System.EventHandler(this.buttonMkDir_Click);
            // 
            // comboBoxLeft
            // 
            this.comboBoxLeft.FormattingEnabled = true;
            this.comboBoxLeft.Location = new System.Drawing.Point(12, 69);
            this.comboBoxLeft.Name = "comboBoxLeft";
            this.comboBoxLeft.Size = new System.Drawing.Size(392, 24);
            this.comboBoxLeft.TabIndex = 6;
            this.comboBoxLeft.SelectedIndexChanged += new System.EventHandler(this.comboBoxLeft_SelectedIndexChanged);
            // 
            // comboBoxRight
            // 
            this.comboBoxRight.FormattingEnabled = true;
            this.comboBoxRight.Location = new System.Drawing.Point(422, 69);
            this.comboBoxRight.Name = "comboBoxRight";
            this.comboBoxRight.Size = new System.Drawing.Size(392, 24);
            this.comboBoxRight.TabIndex = 7;
            this.comboBoxRight.SelectedIndexChanged += new System.EventHandler(this.comboBoxRight_SelectedIndexChanged);
            // 
            // InfolistBox
            // 
            this.InfolistBox.FormattingEnabled = true;
            this.InfolistBox.ItemHeight = 16;
            this.InfolistBox.Location = new System.Drawing.Point(12, 517);
            this.InfolistBox.Name = "InfolistBox";
            this.InfolistBox.Size = new System.Drawing.Size(802, 116);
            this.InfolistBox.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 747);
            this.Controls.Add(this.InfolistBox);
            this.Controls.Add(this.comboBoxRight);
            this.Controls.Add(this.comboBoxLeft);
            this.Controls.Add(this.buttonMkDir);
            this.Controls.Add(this.buttonTouchFile);
            this.Controls.Add(this.buttonDelit);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.RightlistBox);
            this.Controls.Add(this.LeftListBox);
            this.Name = "Form1";
            this.Text = "File Mageger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LeftListBox;
        private System.Windows.Forms.ListBox RightlistBox;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonDelit;
        private System.Windows.Forms.Button buttonTouchFile;
        private System.Windows.Forms.Button buttonMkDir;
        private System.Windows.Forms.ComboBox comboBoxLeft;
        private System.Windows.Forms.ComboBox comboBoxRight;
        private System.Windows.Forms.ListBox InfolistBox;
    }
}

