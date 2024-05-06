using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True";
            Functions.ConvertToDB(connectionString, FFPMConnectionString, EyeMDConnectionString);
        }
    }
}
