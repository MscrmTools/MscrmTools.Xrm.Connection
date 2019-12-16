using System.Windows.Forms;

namespace McTools.Xrm.Connection.Forms
{
    public partial class PasswordRequestDialog : Form
    {
        private readonly ConnectionDetail _detail;

        public PasswordRequestDialog(string passwordUsageDescription, ConnectionDetail detail, string item)
        {
            _detail = detail;

            InitializeComponent();

            lblReason.Text = passwordUsageDescription;

            Text = Text.Replace("password", item);
            lblHeaderTitle.Text = lblHeaderTitle.Text.Replace("password", item);
            rdbDoNotAllow.Text = rdbDoNotAllow.Text.Replace("password", item);
            rdbThisSession.Text = rdbThisSession.Text.Replace("password", item);
            rdbThisTimeOnly.Text = rdbThisTimeOnly.Text.Replace("password", item);
        }

        public bool Accepted { get; private set; }

        private void bValidate_Click(object sender, System.EventArgs e)
        {
            Accepted = !rdbDoNotAllow.Checked;
            _detail.AllowPasswordSharing = rdbThisSession.Checked;
        }
    }
}