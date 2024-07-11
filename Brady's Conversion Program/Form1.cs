using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            progressBar1.Hide();
            EyeMDNewDBCheckBox.Hide();
            FFPMNewDBCheckBox.Hide();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            if (!(ConvCheckBox.Checked || EHRCheckBox.Checked || InvCheckBox.Checked)) {
                MessageBox.Show("Please select at least one database to convert.");
                return;
            }
            else if (ServerTextBox.Text == "") {
                MessageBox.Show("Please enter a server name.");
                return;
            }
            else if (ConvCheckBox.Checked && ConvTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Conv Database on FFPM Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && EHRTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for EHR Database on EyeMD Conversion.");
                return;
            }
            else if (InvCheckBox.Checked && InvTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Inv Database on Conversion.");
                return;
            }
            else if ((FFPMServerTextBox.Text == "" || FFPMDataBaseTextBox.Text == "") && ConvCheckBox.Checked) {
                MessageBox.Show("Please enter a server and database name for FFPM.");
                return;
            }
            else if ((EyeMDServerNameTextBox.Text == "" || EyeMDDBTextBox.Text == "") && EHRCheckBox.Checked) {
                MessageBox.Show("Please enter a server and database name for EyeMD.");
                return;
            }
            FFPMNewDBCheckBox.Hide();
            EyeMDNewDBCheckBox.Hide();
            ConvCheckBox.Hide();
            EHRCheckBox.Hide();
            InvCheckBox.Hide();
            progressBar1.Show();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            string convConnectionString = "Server=" + ServerTextBox.Text + ";Database=" + ConvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string ehrConnectionString = "Server=" + EHRTextBox.Text + ";Database=" + EHRTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string invConnectionString = "Server=" + InvTextBox.Text + ";Database=" + InvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            
            string result = Functions.ConvertToDB(convConnectionString, ehrConnectionString, invConnectionString, FFPMConnectionString, EyeMDConnectionString,
                ConvCheckBox.Checked, EHRCheckBox.Checked, InvCheckBox.Checked, FFPMNewDBCheckBox.Checked, EyeMDNewDBCheckBox.Checked, progressBar1);
            ResultsBox.Invoke((MethodInvoker)delegate {
                ResultsBox.Text = result;
            });
            progressBar1.Invoke((MethodInvoker)delegate {
                progressBar1.Hide();
                progressBar1.Value = 0;
            });
            ConvCheckBox.Invoke((MethodInvoker)delegate {
                ConvCheckBox.Show();
            });
            EHRCheckBox.Invoke((MethodInvoker)delegate {
                EHRCheckBox.Show();
            });
            InvCheckBox.Invoke((MethodInvoker)delegate {
                InvCheckBox.Show();
            });
            if (FFPMNewDBCheckBox.Checked) {
                FFPMNewDBCheckBox.Invoke((MethodInvoker)delegate {
                    FFPMNewDBCheckBox.Show();
                });
            }
            if (EyeMDNewDBCheckBox.Checked) {
                EyeMDNewDBCheckBox.Invoke((MethodInvoker)delegate {
                    EyeMDNewDBCheckBox.Show();
                });
            }
        }

        private void FFPMCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FFPMNewDBCheckBox.Checked) {
                FFPMNewDBCheckBox.Checked = false;
            }
            if (ConvCheckBox.Checked) {
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
            if (EHRCheckBox.Checked) {
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
            ConvCheckBox.Checked = false;
            EHRCheckBox.Checked = false;
            FFPMNewDBCheckBox.Checked = false;
            EyeMDNewDBCheckBox.Checked = false;
        }
    }
}
