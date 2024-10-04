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
		private void InitializeComponent () {
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
			CustomerInfoServerTextBox = new TextBox();
			CustomerInfoDatabaseTextBox = new TextBox();
			DocumentsGiveText = new TextBox();
			ImageFolderSelectButton = new Button();
			ImageFolderTextBox = new TextBox();
			ImageDestinationFolderTextBox = new TextBox();
			ImageDestinationFolderSelectButton = new Button();
			SelectDestinationBox = new TextBox();
			RenumAccsCheckBox = new CheckBox();
			SuspendLayout();
			// 
			// ConvServerTextBox
			// 
			ConvServerTextBox.Location = new Point(17, 20);
			ConvServerTextBox.Margin = new Padding(4, 5, 4, 5);
			ConvServerTextBox.Name = "ConvServerTextBox";
			ConvServerTextBox.PlaceholderText = "Conv Server";
			ConvServerTextBox.Size = new Size(187, 31);
			ConvServerTextBox.TabIndex = 0;
			// 
			// ConvTextBox
			// 
			ConvTextBox.Location = new Point(17, 68);
			ConvTextBox.Margin = new Padding(4, 5, 4, 5);
			ConvTextBox.Name = "ConvTextBox";
			ConvTextBox.PlaceholderText = "Conv Database";
			ConvTextBox.Size = new Size(187, 31);
			ConvTextBox.TabIndex = 1;
			// 
			// DBBeginButton
			// 
			DBBeginButton.Location = new Point(214, 472);
			DBBeginButton.Margin = new Padding(4, 5, 4, 5);
			DBBeginButton.Name = "DBBeginButton";
			DBBeginButton.Size = new Size(189, 38);
			DBBeginButton.TabIndex = 16;
			DBBeginButton.Text = "Begin";
			DBBeginButton.UseVisualStyleBackColor = true;
			DBBeginButton.Click += DBBeginButton_Click;
			// 
			// FFPMServerTextBox
			// 
			FFPMServerTextBox.Location = new Point(17, 117);
			FFPMServerTextBox.Margin = new Padding(4, 5, 4, 5);
			FFPMServerTextBox.Name = "FFPMServerTextBox";
			FFPMServerTextBox.PlaceholderText = "FFPM Server Name";
			FFPMServerTextBox.Size = new Size(187, 31);
			FFPMServerTextBox.TabIndex = 7;
			// 
			// FFPMDataBaseTextBox
			// 
			FFPMDataBaseTextBox.Location = new Point(17, 165);
			FFPMDataBaseTextBox.Margin = new Padding(4, 5, 4, 5);
			FFPMDataBaseTextBox.Name = "FFPMDataBaseTextBox";
			FFPMDataBaseTextBox.PlaceholderText = "FFPM Database";
			FFPMDataBaseTextBox.Size = new Size(187, 31);
			FFPMDataBaseTextBox.TabIndex = 8;
			// 
			// EyeMDDBTextBox
			// 
			EyeMDDBTextBox.Location = new Point(214, 165);
			EyeMDDBTextBox.Margin = new Padding(4, 5, 4, 5);
			EyeMDDBTextBox.Name = "EyeMDDBTextBox";
			EyeMDDBTextBox.PlaceholderText = "EyeMD Database";
			EyeMDDBTextBox.Size = new Size(187, 31);
			EyeMDDBTextBox.TabIndex = 10;
			// 
			// EyeMDServerNameTextBox
			// 
			EyeMDServerNameTextBox.Location = new Point(214, 117);
			EyeMDServerNameTextBox.Margin = new Padding(4, 5, 4, 5);
			EyeMDServerNameTextBox.Name = "EyeMDServerNameTextBox";
			EyeMDServerNameTextBox.PlaceholderText = "EyeMD Server Name";
			EyeMDServerNameTextBox.Size = new Size(187, 31);
			EyeMDServerNameTextBox.TabIndex = 9;
			// 
			// ResultsBox
			// 
			ResultsBox.Location = new Point(17, 272);
			ResultsBox.Margin = new Padding(4, 5, 4, 5);
			ResultsBox.Name = "ResultsBox";
			ResultsBox.Size = new Size(581, 187);
			ResultsBox.TabIndex = 19;
			ResultsBox.Text = "";
			// 
			// progressBar1
			// 
			progressBar1.Location = new Point(17, 223);
			progressBar1.Margin = new Padding(4, 5, 4, 5);
			progressBar1.Name = "progressBar1";
			progressBar1.Size = new Size(583, 38);
			progressBar1.Style = ProgressBarStyle.Continuous;
			progressBar1.TabIndex = 20;
			// 
			// backgroundWorker1
			// 
			backgroundWorker1.DoWork += backgroundWorker1_DoWork;
			// 
			// FFPMNewDBCheckBox
			// 
			FFPMNewDBCheckBox.AutoSize = true;
			FFPMNewDBCheckBox.Location = new Point(17, 232);
			FFPMNewDBCheckBox.Margin = new Padding(4, 5, 4, 5);
			FFPMNewDBCheckBox.Name = "FFPMNewDBCheckBox";
			FFPMNewDBCheckBox.Size = new Size(150, 29);
			FFPMNewDBCheckBox.TabIndex = 14;
			FFPMNewDBCheckBox.Text = "New FFPM DB";
			FFPMNewDBCheckBox.UseVisualStyleBackColor = true;
			// 
			// EyeMDNewDBCheckBox
			// 
			EyeMDNewDBCheckBox.AutoSize = true;
			EyeMDNewDBCheckBox.Location = new Point(214, 233);
			EyeMDNewDBCheckBox.Margin = new Padding(4, 5, 4, 5);
			EyeMDNewDBCheckBox.Name = "EyeMDNewDBCheckBox";
			EyeMDNewDBCheckBox.Size = new Size(162, 29);
			EyeMDNewDBCheckBox.TabIndex = 15;
			EyeMDNewDBCheckBox.Text = "New EyeMD DB";
			EyeMDNewDBCheckBox.UseVisualStyleBackColor = true;
			// 
			// EHRTextBox
			// 
			EHRTextBox.Location = new Point(214, 68);
			EHRTextBox.Margin = new Padding(4, 5, 4, 5);
			EHRTextBox.Name = "EHRTextBox";
			EHRTextBox.PlaceholderText = "EHR Database";
			EHRTextBox.Size = new Size(187, 31);
			EHRTextBox.TabIndex = 4;
			// 
			// InvTextBox
			// 
			InvTextBox.Location = new Point(411, 68);
			InvTextBox.Margin = new Padding(4, 5, 4, 5);
			InvTextBox.Name = "InvTextBox";
			InvTextBox.PlaceholderText = "Inv Database";
			InvTextBox.Size = new Size(187, 31);
			InvTextBox.TabIndex = 6;
			// 
			// ConvCheckBox
			// 
			ConvCheckBox.AutoSize = true;
			ConvCheckBox.Location = new Point(17, 206);
			ConvCheckBox.Margin = new Padding(4, 5, 4, 5);
			ConvCheckBox.Name = "ConvCheckBox";
			ConvCheckBox.Size = new Size(79, 29);
			ConvCheckBox.TabIndex = 11;
			ConvCheckBox.Text = "Conv";
			ConvCheckBox.UseVisualStyleBackColor = true;
			ConvCheckBox.CheckedChanged += ConvCheckBox_CheckedChanged;
			// 
			// EHRCheckBox
			// 
			EHRCheckBox.AutoSize = true;
			EHRCheckBox.Location = new Point(214, 206);
			EHRCheckBox.Margin = new Padding(4, 5, 4, 5);
			EHRCheckBox.Name = "EHRCheckBox";
			EHRCheckBox.Size = new Size(71, 29);
			EHRCheckBox.TabIndex = 12;
			EHRCheckBox.Text = "EHR";
			EHRCheckBox.UseVisualStyleBackColor = true;
			EHRCheckBox.CheckedChanged += EhrCheckBox_CheckedChanged;
			// 
			// ClearTextButton
			// 
			ClearTextButton.Location = new Point(17, 472);
			ClearTextButton.Margin = new Padding(4, 5, 4, 5);
			ClearTextButton.Name = "ClearTextButton";
			ClearTextButton.Size = new Size(97, 38);
			ClearTextButton.TabIndex = 17;
			ClearTextButton.Text = "Clear Text";
			ClearTextButton.UseVisualStyleBackColor = true;
			ClearTextButton.Click += ClearTextButton_Click;
			// 
			// ClearInputButton
			// 
			ClearInputButton.Location = new Point(490, 472);
			ClearInputButton.Margin = new Padding(4, 5, 4, 5);
			ClearInputButton.Name = "ClearInputButton";
			ClearInputButton.Size = new Size(110, 38);
			ClearInputButton.TabIndex = 18;
			ClearInputButton.Text = "Clear Input";
			ClearInputButton.UseVisualStyleBackColor = true;
			ClearInputButton.Click += ClearInputButton_Click;
			// 
			// InvCheckBox
			// 
			InvCheckBox.AutoSize = true;
			InvCheckBox.Location = new Point(411, 206);
			InvCheckBox.Margin = new Padding(4, 5, 4, 5);
			InvCheckBox.Name = "InvCheckBox";
			InvCheckBox.Size = new Size(62, 29);
			InvCheckBox.TabIndex = 13;
			InvCheckBox.Text = "Inv";
			InvCheckBox.UseVisualStyleBackColor = true;
			InvCheckBox.CheckedChanged += InvCheckBox_CheckedChanged;
			// 
			// EHRServerTextBox
			// 
			EHRServerTextBox.Location = new Point(214, 20);
			EHRServerTextBox.Margin = new Padding(4, 5, 4, 5);
			EHRServerTextBox.Name = "EHRServerTextBox";
			EHRServerTextBox.PlaceholderText = "EHR Server";
			EHRServerTextBox.Size = new Size(187, 31);
			EHRServerTextBox.TabIndex = 3;
			// 
			// InvServerTextBox
			// 
			InvServerTextBox.Location = new Point(411, 18);
			InvServerTextBox.Margin = new Padding(4, 5, 4, 5);
			InvServerTextBox.Name = "InvServerTextBox";
			InvServerTextBox.PlaceholderText = "Inv Server";
			InvServerTextBox.Size = new Size(187, 31);
			InvServerTextBox.TabIndex = 5;
			// 
			// CustomerInfoServerTextBox
			// 
			CustomerInfoServerTextBox.Location = new Point(411, 117);
			CustomerInfoServerTextBox.Margin = new Padding(4, 5, 4, 5);
			CustomerInfoServerTextBox.Name = "CustomerInfoServerTextBox";
			CustomerInfoServerTextBox.PlaceholderText = "CustomerInfo Server";
			CustomerInfoServerTextBox.Size = new Size(187, 31);
			CustomerInfoServerTextBox.TabIndex = 21;
			// 
			// CustomerInfoDatabaseTextBox
			// 
			CustomerInfoDatabaseTextBox.Location = new Point(411, 165);
			CustomerInfoDatabaseTextBox.Margin = new Padding(4, 5, 4, 5);
			CustomerInfoDatabaseTextBox.Name = "CustomerInfoDatabaseTextBox";
			CustomerInfoDatabaseTextBox.PlaceholderText = "CustomerInfo Database";
			CustomerInfoDatabaseTextBox.Size = new Size(187, 31);
			CustomerInfoDatabaseTextBox.TabIndex = 22;
			// 
			// DocumentsGiveText
			// 
			DocumentsGiveText.BackColor = Color.Ivory;
			DocumentsGiveText.BorderStyle = BorderStyle.None;
			DocumentsGiveText.Location = new Point(17, 520);
			DocumentsGiveText.Margin = new Padding(4, 5, 4, 5);
			DocumentsGiveText.Name = "DocumentsGiveText";
			DocumentsGiveText.ReadOnly = true;
			DocumentsGiveText.Size = new Size(189, 24);
			DocumentsGiveText.TabIndex = 23;
			DocumentsGiveText.Text = "Select the image folder: ";
			// 
			// ImageFolderSelectButton
			// 
			ImageFolderSelectButton.Location = new Point(17, 552);
			ImageFolderSelectButton.Margin = new Padding(4, 5, 4, 5);
			ImageFolderSelectButton.Name = "ImageFolderSelectButton";
			ImageFolderSelectButton.Size = new Size(583, 38);
			ImageFolderSelectButton.TabIndex = 24;
			ImageFolderSelectButton.Text = "Select Image Folder";
			ImageFolderSelectButton.UseVisualStyleBackColor = true;
			ImageFolderSelectButton.Click += ImageFolderSelectButton_Click;
			// 
			// ImageFolderTextBox
			// 
			ImageFolderTextBox.BackColor = Color.Ivory;
			ImageFolderTextBox.BorderStyle = BorderStyle.None;
			ImageFolderTextBox.Location = new Point(214, 520);
			ImageFolderTextBox.Margin = new Padding(4, 5, 4, 5);
			ImageFolderTextBox.Name = "ImageFolderTextBox";
			ImageFolderTextBox.ReadOnly = true;
			ImageFolderTextBox.Size = new Size(386, 24);
			ImageFolderTextBox.TabIndex = 25;
			// 
			// ImageDestinationFolderTextBox
			// 
			ImageDestinationFolderTextBox.BackColor = Color.Ivory;
			ImageDestinationFolderTextBox.BorderStyle = BorderStyle.None;
			ImageDestinationFolderTextBox.Location = new Point(249, 608);
			ImageDestinationFolderTextBox.Margin = new Padding(4, 5, 4, 5);
			ImageDestinationFolderTextBox.Name = "ImageDestinationFolderTextBox";
			ImageDestinationFolderTextBox.ReadOnly = true;
			ImageDestinationFolderTextBox.Size = new Size(351, 24);
			ImageDestinationFolderTextBox.TabIndex = 28;
			// 
			// ImageDestinationFolderSelectButton
			// 
			ImageDestinationFolderSelectButton.Location = new Point(17, 640);
			ImageDestinationFolderSelectButton.Margin = new Padding(4, 5, 4, 5);
			ImageDestinationFolderSelectButton.Name = "ImageDestinationFolderSelectButton";
			ImageDestinationFolderSelectButton.Size = new Size(583, 38);
			ImageDestinationFolderSelectButton.TabIndex = 27;
			ImageDestinationFolderSelectButton.Text = "Select Image Destination Folder";
			ImageDestinationFolderSelectButton.UseVisualStyleBackColor = true;
			ImageDestinationFolderSelectButton.Click += ImageDestinationFolderSelectButton_Click;
			// 
			// SelectDestinationBox
			// 
			SelectDestinationBox.BackColor = Color.Ivory;
			SelectDestinationBox.BorderStyle = BorderStyle.None;
			SelectDestinationBox.Location = new Point(17, 608);
			SelectDestinationBox.Margin = new Padding(4, 5, 4, 5);
			SelectDestinationBox.Name = "SelectDestinationBox";
			SelectDestinationBox.ReadOnly = true;
			SelectDestinationBox.Size = new Size(223, 24);
			SelectDestinationBox.TabIndex = 26;
			SelectDestinationBox.Text = "Select the destination folder: ";
			// 
			// RenumAccsCheckBox
			// 
			RenumAccsCheckBox.AutoSize = true;
			RenumAccsCheckBox.Location = new Point(411, 233);
			RenumAccsCheckBox.Margin = new Padding(4, 5, 4, 5);
			RenumAccsCheckBox.Name = "RenumAccsCheckBox";
			RenumAccsCheckBox.Size = new Size(197, 29);
			RenumAccsCheckBox.TabIndex = 29;
			RenumAccsCheckBox.Text = "Renumber Accounts";
			RenumAccsCheckBox.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.Ivory;
			ClientSize = new Size(617, 698);
			Controls.Add(RenumAccsCheckBox);
			Controls.Add(ImageDestinationFolderTextBox);
			Controls.Add(ImageDestinationFolderSelectButton);
			Controls.Add(SelectDestinationBox);
			Controls.Add(ImageFolderTextBox);
			Controls.Add(ImageFolderSelectButton);
			Controls.Add(DocumentsGiveText);
			Controls.Add(CustomerInfoDatabaseTextBox);
			Controls.Add(CustomerInfoServerTextBox);
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
			Margin = new Padding(4, 5, 4, 5);
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
        private TextBox CustomerInfoServerTextBox;
        private TextBox CustomerInfoDatabaseTextBox;
        private TextBox DocumentsGiveText;
        private Button ImageFolderSelectButton;
        private TextBox ImageFolderTextBox;
        private TextBox ImageDestinationFolderTextBox;
        private Button ImageDestinationFolderSelectButton;
        private TextBox SelectDestinationBox;
		private CheckBox RenumAccsCheckBox;
	}
}
