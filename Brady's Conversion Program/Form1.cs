using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void UploadFileButton_Click(object sender, EventArgs e) {
            string filePath = Functions.OpenDialogBox();
            UploadedFilesBox.Items.Add(filePath);
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            Functions.ConvertToDB(connectionString);
        }

        private void ClearFilesButton_Click(object sender, EventArgs e) {
            Functions.ClearFiles();
            UploadedFilesBox.Items.Clear();
        }
    }
}
