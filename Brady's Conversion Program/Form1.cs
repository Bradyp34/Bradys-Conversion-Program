using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            if (ServerTextBox.Text == "") {
                MessageBox.Show("Please enter a server name.");
            }
            else if (FFPMCheckBox.Checked && ConvTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Conv Database on FFPM Conversion.");
            }
            else if (EyeMDCheckBox.Checked && EHRTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for EHR Database on EyeMD Conversion.");
                // I dont know what tables will be used in the end in ffpm vs eyemd, but this is good for now
            }
            else if (FFPMServerTextBox.Text == "" || FFPMDataBaseTextBox.Text == "") {
                MessageBox.Show("Please enter a server and database name for FFPM.");
                return;
            }
            else if (EyeMDServerNameTextBox.Text == "" || EyeMDDBTextBox.Text == "") {
                MessageBox.Show("Please enter a server and database name for EyeMD.");
                return;
            }
            FFPMNewDBCheckBox.Hide();
            EyeMDNewDBCheckBox.Hide();
            FFPMCheckBox.Hide();
            EyeMDCheckBox.Hide();
            progressBar1.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e) {
            progressBar1.Hide();
            EyeMDNewDBCheckBox.Hide();
            FFPMNewDBCheckBox.Hide();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            string convConnectionString = "Server=" + ServerTextBox.Text + ";Database=" + ConvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string ehrConnectionString = "Server=" + EHRTextBox.Text + ";Database=" + EHRTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string invConnectionString = "Server=" + InvTextBox.Text + ";Database=" + InvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string result = Functions.ConvertToDB(convConnectionString, ehrConnectionString, invConnectionString, FFPMConnectionString, EyeMDConnectionString,
                FFPMCheckBox.Checked, EyeMDCheckBox.Checked, FFPMNewDBCheckBox.Checked, EyeMDNewDBCheckBox.Checked, progressBar1);
            ResultsBox.Invoke((MethodInvoker)delegate {
                ResultsBox.Text = result;
            });
        }

        private void FFPMCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FFPMNewDBCheckBox.Checked) {
                FFPMNewDBCheckBox.Checked = false;
            }
            if (FFPMCheckBox.Checked) {
                FFPMNewDBCheckBox.Show();
            }
            else {
                FFPMNewDBCheckBox.Hide();
            }
        }

        private void EyeMDCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (EyeMDNewDBCheckBox.Checked) {
                EyeMDNewDBCheckBox.Checked = false;
            }
            if (EyeMDCheckBox.Checked) {
                EyeMDNewDBCheckBox.Show();
            }
            else {
                EyeMDNewDBCheckBox.Hide();
            }
        }

        private void ClearTextButton_Click(object sender, EventArgs e) {
            ResultsBox.Text = "";
        }

        private void ClearInputButton_Click(object sender, EventArgs e) {
            ServerTextBox.Text = "";
            ConvTextBox.Text = "";
            EHRTextBox.Text = "";
            InvTextBox.Text = "";
            FFPMServerTextBox.Text = "";
            FFPMDataBaseTextBox.Text = "";
            EyeMDServerNameTextBox.Text = "";
            EyeMDDBTextBox.Text = "";
            
        }
    }
}
