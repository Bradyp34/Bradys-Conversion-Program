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
            tabControl1 = new TabControl();
            FromDBPage = new TabPage();
            FromFilePage = new TabPage();
            UploadFileButton = new Button();
            DBBeginButton = new Button();
            tabControl1.SuspendLayout();
            FromDBPage.SuspendLayout();
            FromFilePage.SuspendLayout();
            SuspendLayout();
            // 
            // ServerTextBox
            // 
            ServerTextBox.Location = new Point(6, 6);
            ServerTextBox.Name = "ServerTextBox";
            ServerTextBox.PlaceholderText = "Server Name";
            ServerTextBox.Size = new Size(132, 23);
            ServerTextBox.TabIndex = 0;
            // 
            // DatabaseTextBox
            // 
            DatabaseTextBox.Location = new Point(6, 35);
            DatabaseTextBox.Name = "DatabaseTextBox";
            DatabaseTextBox.PlaceholderText = "Database";
            DatabaseTextBox.Size = new Size(132, 23);
            DatabaseTextBox.TabIndex = 1;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(FromDBPage);
            tabControl1.Controls.Add(FromFilePage);
            tabControl1.Location = new Point(2, 1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(797, 447);
            tabControl1.TabIndex = 2;
            // 
            // FromDBPage
            // 
            FromDBPage.Controls.Add(DBBeginButton);
            FromDBPage.Controls.Add(ServerTextBox);
            FromDBPage.Controls.Add(DatabaseTextBox);
            FromDBPage.Location = new Point(4, 24);
            FromDBPage.Name = "FromDBPage";
            FromDBPage.Padding = new Padding(3);
            FromDBPage.Size = new Size(789, 419);
            FromDBPage.TabIndex = 0;
            FromDBPage.Text = "FromDBPage";
            FromDBPage.UseVisualStyleBackColor = true;
            // 
            // FromFilePage
            // 
            FromFilePage.Controls.Add(UploadFileButton);
            FromFilePage.Location = new Point(4, 24);
            FromFilePage.Name = "FromFilePage";
            FromFilePage.Padding = new Padding(3);
            FromFilePage.Size = new Size(789, 419);
            FromFilePage.TabIndex = 1;
            FromFilePage.Text = "FromFilePage";
            FromFilePage.UseVisualStyleBackColor = true;
            // 
            // UploadFileButton
            // 
            UploadFileButton.Location = new Point(6, 6);
            UploadFileButton.Name = "UploadFileButton";
            UploadFileButton.Size = new Size(75, 23);
            UploadFileButton.TabIndex = 0;
            UploadFileButton.Text = "UploadFile";
            UploadFileButton.UseVisualStyleBackColor = true;
            UploadFileButton.Click += UploadFileButton_Click;
            // 
            // DBBeginButton
            // 
            DBBeginButton.Location = new Point(6, 64);
            DBBeginButton.Name = "DBBeginButton";
            DBBeginButton.Size = new Size(132, 23);
            DBBeginButton.TabIndex = 2;
            DBBeginButton.Text = "Begin";
            DBBeginButton.UseVisualStyleBackColor = true;
            DBBeginButton.Click += DBBeginButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            FromDBPage.ResumeLayout(false);
            FromDBPage.PerformLayout();
            FromFilePage.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox ServerTextBox;
        private TextBox DatabaseTextBox;
        private TabControl tabControl1;
        private TabPage FromDBPage;
        private TabPage FromFilePage;
        private Button UploadFileButton;
        private Button DBBeginButton;
    }
}
