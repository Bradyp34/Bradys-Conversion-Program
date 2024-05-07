using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            FFPMCheckBox.Hide();
            EyeMDCheckBox.Hide();
            progressBar1.Show();
            if ((!FFPMCheckBox.Checked && !EyeMDCheckBox.Checked) || ServerTextBox.Text == "" || DatabaseTextBox.Text == "" || FFPMServerTextBox.Text == "" || FFPMDataBaseTextBox.Text == "" || EyeMDServerNameTextBox.Text == "" || EyeMDDBTextBox.Text == "") {
                MessageBox.Show("Please fill out all fields.");
                return;
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e) {
            progressBar1.Hide();
            FFPMServerTextBox.Hide();
            FFPMDataBaseTextBox.Hide();
            EyeMDServerNameTextBox.Hide();
            EyeMDDBTextBox.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True";
            ResultsBox.Text = Functions.ConvertToDB(connectionString, FFPMConnectionString, EyeMDConnectionString);
        }

        private void FFPMCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FFPMCheckBox.Checked) {
                FFPMServerTextBox.Show();
                FFPMDataBaseTextBox.Show();
            }
            else {
                FFPMServerTextBox.Hide();
                FFPMDataBaseTextBox.Hide();
            }
        }

        private void EyeMDCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (EyeMDCheckBox.Checked) {
                EyeMDServerNameTextBox.Show();
                EyeMDDBTextBox.Show();
            }
            else {
                EyeMDServerNameTextBox.Hide();
                EyeMDDBTextBox.Hide();
            }
        }
    }
}
