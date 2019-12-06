using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionAppIdControl : UserControl, IConnectionWizardControl
    {
        public ConnectionAppIdControl()
        {
            InitializeComponent();
        }

        public string AppId
        {
            get => txtAppId.Text;
            set => txtAppId.Text = value;
        }

        private void ConnectionIfdControl_Load(object sender, System.EventArgs e)
        {
        }
    }
}