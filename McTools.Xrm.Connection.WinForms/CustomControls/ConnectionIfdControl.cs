using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionIfdControl : UserControl, IConnectionWizardControl
    {
        public ConnectionIfdControl()
        {
            InitializeComponent();
        }

        public string HomeRealmUrl
        {
            get => txtHomeRealm.Text;
            set => txtHomeRealm.Text = value;
        }

        public bool IsIfd
        {
            get => rbIfdYes.Checked;
            set
            {
                rbIfdYes.Checked = value;
                rbIfdNo.Checked = !value;
            }
        }

        private void ConnectionIfdControl_Load(object sender, System.EventArgs e)
        {
            rbIfdNo_CheckedChanged(null, null);
        }

        private void rbIfdNo_CheckedChanged(object sender, System.EventArgs e)
        {
            txtHomeRealm.Enabled = rbIfdYes.Checked;
        }
    }
}