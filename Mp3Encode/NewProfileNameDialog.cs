using System.Windows.Forms;
using System.ComponentModel;

namespace Mp3Encode
{
    public partial class NewProfileNameDialog : Form
    {
        public NewProfileNameDialog()
        {
            InitializeComponent();
        }

        private void NameTextBox_TextChanged(object sender, System.EventArgs e)
        {
            okButton.Enabled = NameTextBox.Text.Length > 0;
        }

        public string ProfileName { get { return NameTextBox.Text; } }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
                e.Cancel = NameTextBox.Text.Length == 0;
        }
    }
}
