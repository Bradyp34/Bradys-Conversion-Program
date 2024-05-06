using System.Configuration;

namespace Brady_s_Conversion_Program
{
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void DBBeginButton_Click(object sender, EventArgs e) {
            string connectionString = "Server=" + ServerTextBox.Text + ";Database=" + DatabaseTextBox.Text + ";Integrated Security=True";
            string outBoundConnectionString = "Server=" + OutBoundServerTextBox.Text + ";Database=" + OutBoundDataBaseTextBox.Text + ";Integrated Security=True";
            Functions.ConvertToDB(connectionString, outBoundConnectionString);
        }
    }
}
