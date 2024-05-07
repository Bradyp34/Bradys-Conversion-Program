using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            if (ServerTextBox.Text == "" || DatabaseTextBox.Text == "" || FFPMServerTextBox.Text == "" || FFPMDataBaseTextBox.Text == "" || EyeMDServerNameTextBox.Text == "" || EyeMDDBTextBox.Text == "") {
                MessageBox.Show("Please fill out all fields.");
                return;
            }
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True";
            ResultsBox.Text = Functions.ConvertToDB(connectionString, FFPMConnectionString, EyeMDConnectionString);
        }
    }
}
