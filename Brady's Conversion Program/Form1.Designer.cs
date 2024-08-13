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
            ConvServerTextBox = new TextBox();
            ConvTextBox = new TextBox();
            DBBeginButton = new Button();
            FFPMServerTextBox = new TextBox();
            FFPMDataBaseTextBox = new TextBox();
            EyeMDDBTextBox = new TextBox();
            EyeMDServerNameTextBox = new TextBox();
            ResultsBox = new RichTextBox();
            progressBar1 = new ProgressBar();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            FFPMNewDBCheckBox = new CheckBox();
            EyeMDNewDBCheckBox = new CheckBox();
            EHRTextBox = new TextBox();
            InvTextBox = new TextBox();
            ConvCheckBox = new CheckBox();
            EHRCheckBox = new CheckBox();
            ClearTextButton = new Button();
            ClearInputButton = new Button();
            InvCheckBox = new CheckBox();
            EHRServerTextBox = new TextBox();
            InvServerTextBox = new TextBox();
            SuspendLayout();
            // 
            // ConvServerTextBox
            // 
            ConvServerTextBox.Location = new Point(12, 12);
            ConvServerTextBox.Name = "ConvServerTextBox";
            ConvServerTextBox.PlaceholderText = "Conv Server";
            ConvServerTextBox.Size = new Size(132, 23);
            ConvServerTextBox.TabIndex = 0;
            // 
            // ConvTextBox
            // 
            ConvTextBox.Location = new Point(12, 41);
            ConvTextBox.Name = "ConvTextBox";
            ConvTextBox.PlaceholderText = "Conv Database";
            ConvTextBox.Size = new Size(132, 23);
            ConvTextBox.TabIndex = 1;
            // 
            // DBBeginButton
            // 
            DBBeginButton.Location = new Point(288, 70);
            DBBeginButton.Name = "DBBeginButton";
            DBBeginButton.Size = new Size(132, 23);
            DBBeginButton.TabIndex = 2;
            DBBeginButton.Text = "Begin";
            DBBeginButton.UseVisualStyleBackColor = true;
            DBBeginButton.Click += DBBeginButton_Click;
            // 
            // FFPMServerTextBox
            // 
            FFPMServerTextBox.Location = new Point(12, 70);
            FFPMServerTextBox.Name = "FFPMServerTextBox";
            FFPMServerTextBox.PlaceholderText = "FFPM Server Name";
            FFPMServerTextBox.Size = new Size(132, 23);
            FFPMServerTextBox.TabIndex = 3;
            // 
            // FFPMDataBaseTextBox
            // 
            FFPMDataBaseTextBox.Location = new Point(12, 99);
            FFPMDataBaseTextBox.Name = "FFPMDataBaseTextBox";
            FFPMDataBaseTextBox.PlaceholderText = "FFPM Database";
            FFPMDataBaseTextBox.Size = new Size(132, 23);
            FFPMDataBaseTextBox.TabIndex = 4;
            // 
            // EyeMDDBTextBox
            // 
            EyeMDDBTextBox.Location = new Point(150, 99);
            EyeMDDBTextBox.Name = "EyeMDDBTextBox";
            EyeMDDBTextBox.PlaceholderText = "EyeMD Database";
            EyeMDDBTextBox.Size = new Size(132, 23);
            EyeMDDBTextBox.TabIndex = 6;
            // 
            // EyeMDServerNameTextBox
            // 
            EyeMDServerNameTextBox.Location = new Point(150, 70);
            EyeMDServerNameTextBox.Name = "EyeMDServerNameTextBox";
            EyeMDServerNameTextBox.PlaceholderText = "EyeMD Server Name";
            EyeMDServerNameTextBox.Size = new Size(132, 23);
            EyeMDServerNameTextBox.TabIndex = 5;
            // 
            // ResultsBox
            // 
            ResultsBox.Location = new Point(12, 163);
            ResultsBox.Name = "ResultsBox";
            ResultsBox.Size = new Size(408, 114);
            ResultsBox.TabIndex = 7;
            ResultsBox.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 134);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(408, 23);
            progressBar1.TabIndex = 8;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            // 
            // FFPMNewDBCheckBox
            // 
            FFPMNewDBCheckBox.AutoSize = true;
            FFPMNewDBCheckBox.Location = new Point(190, 134);
            FFPMNewDBCheckBox.Name = "FFPMNewDBCheckBox";
            FFPMNewDBCheckBox.Size = new Size(101, 19);
            FFPMNewDBCheckBox.TabIndex = 11;
            FFPMNewDBCheckBox.Text = "New FFPM DB";
            FFPMNewDBCheckBox.UseVisualStyleBackColor = true;
            // 
            // EyeMDNewDBCheckBox
            // 
            EyeMDNewDBCheckBox.AutoSize = true;
            EyeMDNewDBCheckBox.Location = new Point(312, 134);
            EyeMDNewDBCheckBox.Name = "EyeMDNewDBCheckBox";
            EyeMDNewDBCheckBox.Size = new Size(108, 19);
            EyeMDNewDBCheckBox.TabIndex = 12;
            EyeMDNewDBCheckBox.Text = "New EyeMD DB";
            EyeMDNewDBCheckBox.UseVisualStyleBackColor = true;
            // 
            // EHRTextBox
            // 
            EHRTextBox.Location = new Point(150, 41);
            EHRTextBox.Name = "EHRTextBox";
            EHRTextBox.PlaceholderText = "EHR Database";
            EHRTextBox.Size = new Size(132, 23);
            EHRTextBox.TabIndex = 13;
            // 
            // InvTextBox
            // 
            InvTextBox.Location = new Point(288, 41);
            InvTextBox.Name = "InvTextBox";
            InvTextBox.PlaceholderText = "Inv Database";
            InvTextBox.Size = new Size(132, 23);
            InvTextBox.TabIndex = 14;
            // 
            // ConvCheckBox
            // 
            ConvCheckBox.AutoSize = true;
            ConvCheckBox.Location = new Point(12, 134);
            ConvCheckBox.Name = "ConvCheckBox";
            ConvCheckBox.Size = new Size(54, 19);
            ConvCheckBox.TabIndex = 15;
            ConvCheckBox.Text = "Conv";
            ConvCheckBox.UseVisualStyleBackColor = true;
            ConvCheckBox.CheckedChanged += ConvCheckBox_CheckedChanged;
            // 
            // EHRCheckBox
            // 
            EHRCheckBox.AutoSize = true;
            EHRCheckBox.Location = new Point(72, 134);
            EHRCheckBox.Name = "EHRCheckBox";
            EHRCheckBox.Size = new Size(48, 19);
            EHRCheckBox.TabIndex = 16;
            EHRCheckBox.Text = "EHR";
            EHRCheckBox.UseVisualStyleBackColor = true;
            EHRCheckBox.CheckedChanged += EhrCheckBox_CheckedChanged;
            // 
            // ClearTextButton
            // 
            ClearTextButton.Location = new Point(12, 283);
            ClearTextButton.Name = "ClearTextButton";
            ClearTextButton.Size = new Size(68, 23);
            ClearTextButton.TabIndex = 17;
            ClearTextButton.Text = "Clear Text";
            ClearTextButton.UseVisualStyleBackColor = true;
            ClearTextButton.Click += ClearTextButton_Click;
            // 
            // ClearInputButton
            // 
            ClearInputButton.Location = new Point(343, 283);
            ClearInputButton.Name = "ClearInputButton";
            ClearInputButton.Size = new Size(77, 23);
            ClearInputButton.TabIndex = 18;
            ClearInputButton.Text = "Clear Input";
            ClearInputButton.UseVisualStyleBackColor = true;
            ClearInputButton.Click += ClearInputButton_Click;
            // 
            // InvCheckBox
            // 
            InvCheckBox.AutoSize = true;
            InvCheckBox.Location = new Point(126, 134);
            InvCheckBox.Name = "InvCheckBox";
            InvCheckBox.Size = new Size(42, 19);
            InvCheckBox.TabIndex = 19;
            InvCheckBox.Text = "Inv";
            InvCheckBox.UseVisualStyleBackColor = true;
            InvCheckBox.CheckedChanged += InvCheckBox_CheckedChanged;
            // 
            // EHRServerTextBox
            // 
            EHRServerTextBox.Location = new Point(150, 12);
            EHRServerTextBox.Name = "EHRServerTextBox";
            EHRServerTextBox.PlaceholderText = "EHR Server";
            EHRServerTextBox.Size = new Size(132, 23);
            EHRServerTextBox.TabIndex = 20;
            // 
            // InvServerTextBox
            // 
            InvServerTextBox.Location = new Point(288, 11);
            InvServerTextBox.Name = "InvServerTextBox";
            InvServerTextBox.PlaceholderText = "Inv Server";
            InvServerTextBox.Size = new Size(132, 23);
            InvServerTextBox.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(432, 312);
            Controls.Add(InvServerTextBox);
            Controls.Add(EHRServerTextBox);
            Controls.Add(InvCheckBox);
            Controls.Add(ClearInputButton);
            Controls.Add(ClearTextButton);
            Controls.Add(EHRCheckBox);
            Controls.Add(ConvCheckBox);
            Controls.Add(InvTextBox);
            Controls.Add(EHRTextBox);
            Controls.Add(EyeMDNewDBCheckBox);
            Controls.Add(FFPMNewDBCheckBox);
            Controls.Add(progressBar1);
            Controls.Add(ResultsBox);
            Controls.Add(EyeMDDBTextBox);
            Controls.Add(EyeMDServerNameTextBox);
            Controls.Add(FFPMDataBaseTextBox);
            Controls.Add(FFPMServerTextBox);
            Controls.Add(DBBeginButton);
            Controls.Add(ConvServerTextBox);
            Controls.Add(ConvTextBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button DBBeginButton;
        public TextBox ConvServerTextBox;
        public TextBox ConvTextBox;
        public TextBox FFPMServerTextBox;
        public TextBox FFPMDataBaseTextBox;
        public TextBox EyeMDDBTextBox;
        public TextBox EyeMDServerNameTextBox;
        public RichTextBox ResultsBox;
        public ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox FFPMNewDBCheckBox;
        private CheckBox EyeMDNewDBCheckBox;
        public TextBox EHRTextBox;
        public TextBox InvTextBox;
        private CheckBox ConvCheckBox;
        private CheckBox EHRCheckBox;
        private Button ClearTextButton;
        private Button ClearInputButton;
        private CheckBox InvCheckBox;
        public TextBox EHRServerTextBox;
        public TextBox InvServerTextBox;
    }
}
