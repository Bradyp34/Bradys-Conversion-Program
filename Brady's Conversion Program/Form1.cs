using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            if (!FFPMCheckBox.Checked && !EyeMDCheckBox.Checked) {
                MessageBox.Show("Please select at least 1 place to upload.");
                return;
            } else if (ServerTextBox.Text == "" || DatabaseTextBox.Text == "") {
                MessageBox.Show("Please enter a server and database name.");
                return;
            }
            else if (FFPMCheckBox.Checked && (FFPMServerTextBox.Text == "" || FFPMDataBaseTextBox.Text == "")) {
                MessageBox.Show("Please enter a server and database name for FFPM.");
                return;
            }
            else if (EyeMDCheckBox.Checked && (EyeMDServerNameTextBox.Text == "" || EyeMDDBTextBox.Text == "")) {
                MessageBox.Show("Please enter a server and database name for EyeMD.");
                return;
            }
            FFPMCheckBox.Hide();
            EyeMDCheckBox.Hide();
            progressBar1.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e) {
            progressBar1.Hide();
            FFPMServerTextBox.Hide();
            FFPMDataBaseTextBox.Hide();
            EyeMDServerNameTextBox.Hide();
            EyeMDDBTextBox.Hide();
            FFPMCheckBox.Show();
            EyeMDCheckBox.Show();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True";
            ResultsBox.Text = Functions.ConvertToDB(connectionString, FFPMConnectionString, EyeMDConnectionString, FFPMCheckBox.Checked, EyeMDCheckBox.Checked, FFPMNewDBCheckBox.Checked, EyeMDNewDBCheckBox.Checked);
        }

        private void FFPMCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FFPMCheckBox.Checked) {
                FFPMServerTextBox.Show();
                FFPMDataBaseTextBox.Show();
                FFPMNewDBCheckBox.Show();
            }
            else {
                FFPMServerTextBox.Hide();
                FFPMDataBaseTextBox.Hide();
                FFPMNewDBCheckBox.Hide();
            }
        }

        private void EyeMDCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (EyeMDCheckBox.Checked) {
                EyeMDServerNameTextBox.Show();
                EyeMDDBTextBox.Show();
                EyeMDNewDBCheckBox.Show();
            }
            else {
                EyeMDServerNameTextBox.Hide();
                EyeMDDBTextBox.Hide();
                EyeMDNewDBCheckBox.Hide();
            }
        }
    }
}
