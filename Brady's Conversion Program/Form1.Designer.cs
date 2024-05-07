namespace Brady_s_Conversion_Program
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ServerTextBox = new TextBox();
            DatabaseTextBox = new TextBox();
            DBBeginButton = new Button();
            FFPMServerTextBox = new TextBox();
            FFPMDataBaseTextBox = new TextBox();
            EyeMDDBTextBox = new TextBox();
            EyeMDServerNameTextBox = new TextBox();
            ResultsBox = new RichTextBox();
            progressBar1 = new ProgressBar();
            FFPMCheckBox = new CheckBox();
            EyeMDCheckBox = new CheckBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // ServerTextBox
            // 
            ServerTextBox.Location = new Point(12, 12);
            ServerTextBox.Name = "ServerTextBox";
            ServerTextBox.PlaceholderText = "Inbound Server Name";
            ServerTextBox.Size = new Size(132, 23);
            ServerTextBox.TabIndex = 0;
            // 
            // DatabaseTextBox
            // 
            DatabaseTextBox.Location = new Point(12, 41);
            DatabaseTextBox.Name = "DatabaseTextBox";
            DatabaseTextBox.PlaceholderText = "Inbound Database";
            DatabaseTextBox.Size = new Size(132, 23);
            DatabaseTextBox.TabIndex = 1;
            // 
            // DBBeginButton
            // 
            DBBeginButton.Location = new Point(12, 70);
            DBBeginButton.Name = "DBBeginButton";
            DBBeginButton.Size = new Size(408, 23);
            DBBeginButton.TabIndex = 2;
            DBBeginButton.Text = "Begin";
            DBBeginButton.UseVisualStyleBackColor = true;
            DBBeginButton.Click += DBBeginButton_Click;
            // 
            // FFPMServerTextBox
            // 
            FFPMServerTextBox.Location = new Point(150, 12);
            FFPMServerTextBox.Name = "FFPMServerTextBox";
            FFPMServerTextBox.PlaceholderText = "FFPM Server Name";
            FFPMServerTextBox.Size = new Size(132, 23);
            FFPMServerTextBox.TabIndex = 3;
            // 
            // FFPMDataBaseTextBox
            // 
            FFPMDataBaseTextBox.Location = new Point(150, 41);
            FFPMDataBaseTextBox.Name = "FFPMDataBaseTextBox";
            FFPMDataBaseTextBox.PlaceholderText = "FFPM Database";
            FFPMDataBaseTextBox.Size = new Size(132, 23);
            FFPMDataBaseTextBox.TabIndex = 4;
            // 
            // EyeMDDBTextBox
            // 
            EyeMDDBTextBox.Location = new Point(288, 41);
            EyeMDDBTextBox.Name = "EyeMDDBTextBox";
            EyeMDDBTextBox.PlaceholderText = "EyeMD Database";
            EyeMDDBTextBox.Size = new Size(132, 23);
            EyeMDDBTextBox.TabIndex = 6;
            // 
            // EyeMDServerNameTextBox
            // 
            EyeMDServerNameTextBox.Location = new Point(288, 12);
            EyeMDServerNameTextBox.Name = "EyeMDServerNameTextBox";
            EyeMDServerNameTextBox.PlaceholderText = "EyeMD Server Name";
            EyeMDServerNameTextBox.Size = new Size(132, 23);
            EyeMDServerNameTextBox.TabIndex = 5;
            EyeMDServerNameTextBox.Text = "EyeMD";
            // 
            // ResultsBox
            // 
            ResultsBox.Location = new Point(12, 128);
            ResultsBox.Name = "ResultsBox";
            ResultsBox.Size = new Size(408, 114);
            ResultsBox.TabIndex = 7;
            ResultsBox.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 99);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(408, 23);
            progressBar1.TabIndex = 8;
            // 
            // FFPMCheckBox
            // 
            FFPMCheckBox.AutoSize = true;
            FFPMCheckBox.Location = new Point(105, 99);
            FFPMCheckBox.Name = "FFPMCheckBox";
            FFPMCheckBox.Size = new Size(56, 19);
            FFPMCheckBox.TabIndex = 9;
            FFPMCheckBox.Text = "FFPM";
            FFPMCheckBox.UseVisualStyleBackColor = true;
            FFPMCheckBox.CheckedChanged += FFPMCheckBox_CheckedChanged;
            // 
            // EyeMDCheckBox
            // 
            EyeMDCheckBox.AutoSize = true;
            EyeMDCheckBox.Location = new Point(252, 99);
            EyeMDCheckBox.Name = "EyeMDCheckBox";
            EyeMDCheckBox.Size = new Size(63, 19);
            EyeMDCheckBox.TabIndex = 10;
            EyeMDCheckBox.Text = "EyeMD";
            EyeMDCheckBox.UseVisualStyleBackColor = true;
            EyeMDCheckBox.CheckedChanged += EyeMDCheckBox_CheckedChanged;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(432, 254);
            Controls.Add(EyeMDCheckBox);
            Controls.Add(FFPMCheckBox);
            Controls.Add(progressBar1);
            Controls.Add(ResultsBox);
            Controls.Add(EyeMDDBTextBox);
            Controls.Add(EyeMDServerNameTextBox);
            Controls.Add(FFPMDataBaseTextBox);
            Controls.Add(FFPMServerTextBox);
            Controls.Add(DBBeginButton);
            Controls.Add(ServerTextBox);
            Controls.Add(DatabaseTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button DBBeginButton;
        public TextBox ServerTextBox;
        public TextBox DatabaseTextBox;
        public TextBox FFPMServerTextBox;
        public TextBox FFPMDataBaseTextBox;
        public TextBox EyeMDDBTextBox;
        public TextBox EyeMDServerNameTextBox;
        public RichTextBox ResultsBox;
        private RichTextBox richTextBox1;
        public ProgressBar progressBar1;
        private CheckBox FFPMCheckBox;
        private CheckBox EyeMDCheckBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
