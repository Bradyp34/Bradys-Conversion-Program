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
            OutBoundServerTextBox = new TextBox();
            OutBoundDataBaseTextBox = new TextBox();
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
            DBBeginButton.Size = new Size(270, 23);
            DBBeginButton.TabIndex = 2;
            DBBeginButton.Text = "Begin";
            DBBeginButton.UseVisualStyleBackColor = true;
            DBBeginButton.Click += DBBeginButton_Click;
            // 
            // OutBoundServerTextBox
            // 
            OutBoundServerTextBox.Location = new Point(150, 12);
            OutBoundServerTextBox.Name = "OutBoundServerTextBox";
            OutBoundServerTextBox.PlaceholderText = "Outbound Server Name";
            OutBoundServerTextBox.Size = new Size(132, 23);
            OutBoundServerTextBox.TabIndex = 3;
            // 
            // OutBoundDataBaseTextBox
            // 
            OutBoundDataBaseTextBox.Location = new Point(150, 41);
            OutBoundDataBaseTextBox.Name = "OutBoundDataBaseTextBox";
            OutBoundDataBaseTextBox.PlaceholderText = "Outbound Database";
            OutBoundDataBaseTextBox.Size = new Size(132, 23);
            OutBoundDataBaseTextBox.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(295, 100);
            Controls.Add(OutBoundDataBaseTextBox);
            Controls.Add(OutBoundServerTextBox);
            Controls.Add(DBBeginButton);
            Controls.Add(ServerTextBox);
            Controls.Add(DatabaseTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button DBBeginButton;
        public TextBox ServerTextBox;
        public TextBox DatabaseTextBox;
        public TextBox OutBoundServerTextBox;
        public TextBox OutBoundDataBaseTextBox;
    }
}
