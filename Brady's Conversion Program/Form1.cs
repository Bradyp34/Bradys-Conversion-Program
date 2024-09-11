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
            else if (ConvCheckBox.Checked && ConvServerTextBox.Text == "") {
                MessageBox.Show("Please enter a server name.");
                return;
            }
            else if (ConvCheckBox.Checked && ConvTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Conv Database on FFPM Conversion.");
                return;
            }
            else if (ConvCheckBox.Checked && CustomerInfoServerTextBox.Text == "") {
                MessageBox.Show("Please enter the server name for Customer Info database on FFPM Conversion.");
                return;
            }
            else if (ConvCheckBox.Checked && CustomerInfoDatabaseTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Customer Info database on FFPM Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && EHRServerTextBox.Text == "") {
                MessageBox.Show("Please enter the server name for EHR database on EyeMD Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && EHRTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for EHR Database on EyeMD Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && FFPMServerTextBox.Text == "") {
                MessageBox.Show("Please enter the server name for FFPM database on EyeMD Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && FFPMDataBaseTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for FFPM Database on EyeMD Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && ConvServerTextBox.Text == "") {
                MessageBox.Show("Please enter the server name for Conv database on EyeMD Conversion.");
                return;
            }
            else if (EHRCheckBox.Checked && ConvTextBox.Text == "") {
                MessageBox.Show("Please enter the database name for Conv Database on EyeMD Conversion.");
                return;
            }
            else if (InvCheckBox.Checked && InvServerTextBox.Text == "") {
                MessageBox.Show("Please enter the server name for Inv database on Conversion.");
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
            DBBeginButton.Enabled = false;
            ResultsBox.Text = string.Empty;
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) { // this is the actual work starting
            string convConnectionString = "Server=" + ConvServerTextBox.Text + ";Database=" + ConvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";
            string ehrConnectionString = "Server=" + EHRServerTextBox.Text + ";Database=" + EHRTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";
            string invConnectionString = "Server=" + InvServerTextBox.Text + ";Database=" + InvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";
            string customerInfoConnectionString = "Server=" + CustomerInfoServerTextBox.Text + ";Database=" + CustomerInfoDatabaseTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;ConnectRetryCount=3;ConnectRetryInterval=10;";

            string result = Functions.ConvertToDB(convConnectionString, ehrConnectionString, invConnectionString, FFPMConnectionString, EyeMDConnectionString,
                ConvCheckBox.Checked, EHRCheckBox.Checked, InvCheckBox.Checked, FFPMNewDBCheckBox.Checked, EyeMDNewDBCheckBox.Checked, progressBar1, ResultsBox,
                    customerInfoConnectionString); // this is the actual work
            ResultsBox.Invoke((MethodInvoker)delegate {
                ResultsBox.Text += "\n" + result + "\n" + DateTime.Now;
            });
            progressBar1.Invoke((MethodInvoker)delegate { 
                progressBar1.Hide();
                progressBar1.Value = 0;
            });
            ConvCheckBox.Invoke((MethodInvoker)delegate {
                ConvCheckBox.Show();
                if (ConvCheckBox.Checked) {
                    FFPMNewDBCheckBox.Invoke((MethodInvoker)delegate {
                        FFPMNewDBCheckBox.Show();
                    });
                }
            });
            EHRCheckBox.Invoke((MethodInvoker)delegate {
                EHRCheckBox.Show();
                if (EHRCheckBox.Checked) {
                    EyeMDNewDBCheckBox.Invoke((MethodInvoker)delegate {
                        EyeMDNewDBCheckBox.Show();
                    });
                }
            });
            InvCheckBox.Invoke((MethodInvoker)delegate {
                InvCheckBox.Show();
                if (InvCheckBox.Checked) {
                    FFPMNewDBCheckBox.Invoke((MethodInvoker)delegate {
                        FFPMNewDBCheckBox.Show();
                    });
                }
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
            DBBeginButton.Invoke((MethodInvoker)delegate {
                DBBeginButton.Enabled = true;
            });
        }

        private void ConvCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (FFPMNewDBCheckBox.Checked) {
                FFPMNewDBCheckBox.Checked = false;
            }
            if (ConvCheckBox.Checked) {
                FFPMNewDBCheckBox.Show();
            }
            else if (!InvCheckBox.Checked) {
                FFPMNewDBCheckBox.Hide();
            }
        }

        private void EhrCheckBox_CheckedChanged(object sender, EventArgs e) {
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

        private void InvCheckBox_CheckedChanged(object sender, EventArgs e) {
            if (InvCheckBox.Checked) {
                FFPMNewDBCheckBox.Show();
            }
            else if (!ConvCheckBox.Checked) {
                    FFPMNewDBCheckBox.Hide();
            }
        }

        private void ClearTextButton_Click(object sender, EventArgs e) {
            ResultsBox.Text = "";
        }

        private void ClearInputButton_Click(object sender, EventArgs e) {
            ConvServerTextBox.Text = "";
            EHRServerTextBox.Text = "";
            InvServerTextBox.Text = "";
            ConvTextBox.Text = "";
            EHRTextBox.Text = "";
            InvTextBox.Text = "";
            FFPMServerTextBox.Text = "";
            FFPMDataBaseTextBox.Text = "";
            EyeMDServerNameTextBox.Text = "";
            EyeMDDBTextBox.Text = "";
            ConvCheckBox.Checked = false;
            EHRCheckBox.Checked = false;
            InvCheckBox.Checked = false;
            FFPMNewDBCheckBox.Checked = false;
            EyeMDNewDBCheckBox.Checked = false;
        }
    }
}
