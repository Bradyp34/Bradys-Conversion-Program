using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            if (ServerTextBox.Text == "" || ConvTextBox.Text == "") {
                MessageBox.Show("Please enter a source server and database name.");
                return;
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
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
            string convConnectionString = "Server=" + ServerTextBox.Text + ";Database=" + ConvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string ehrConnectionString = "Server=" + EHRTextBox.Text + ";Database=" + EHRTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string invConnectionString = "Server=" + InvTextBox.Text + ";Database=" + InvTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string FFPMConnectionString = "Server=" + FFPMServerTextBox.Text + ";Database=" + FFPMDataBaseTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string EyeMDConnectionString = "Server=" + EyeMDServerNameTextBox.Text + ";Database=" + EyeMDDBTextBox.Text + ";Integrated Security=True;TrustServerCertificate=True;";
            string result = Functions.ConvertToDB(convConnectionString, ehrConnectionString, invConnectionString, FFPMConnectionString, EyeMDConnectionString, 
                FFPMCheckBox.Checked, EyeMDCheckBox.Checked, FFPMNewDBCheckBox.Checked, EyeMDNewDBCheckBox.Checked);
            ResultsBox.Invoke((MethodInvoker)delegate {
                ResultsBox.Text = result;
            });
        }
    }
}
