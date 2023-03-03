using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionSucceededControl : UserControl, IConnectionWizardControl
    {
        public ConnectionSucceededControl()
        {
            InitializeComponent();
        }

        public ConnectionDetail ConnectionDetail { private get; set; }

        public string ConnectionName
        {
            get => txtConnectionName.Text;
            set => txtConnectionName.Text = value;
        }

        private void btnClearBrowser_Click(object sender, System.EventArgs e)
        {
            ConnectionDetail.BrowserProfile = null;
            ConnectionDetail.BrowserName = BrowserEnum.None;

            btnClearBrowser.Visible = false;
        }

        private void btnClearEnvHighlight_Click(object sender, System.EventArgs e)
        {
            ConnectionDetail.EnvironmentHighlightingInfo = null;

            btnClearEnvHighlight.Visible = false;
        }

        private void btnSetBrowser_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new BrowserSelectionDialog(ConnectionDetail.BrowserName, ConnectionDetail.BrowserProfile))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ConnectionDetail.BrowserName = dialog.Browser;
                    ConnectionDetail.BrowserProfile = dialog.Profile;
                }
            }
        }

        private void btnSetEnvHighlight_Click(object sender, System.EventArgs e)
        {
            using (var dialog = new EnvHighlightDialog(ConnectionDetail))
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    ConnectionDetail.EnvironmentHighlightingInfo = new EnvironmentHighlighting
                    {
                        Color = dialog.BackColorSelected,
                        TextColor = dialog.TextColorSelected,
                        Text = dialog.TextSelected
                    };

                    btnClearEnvHighlight.Visible = true;
                }
            }
        }

        private void ConnectionSucceededControl_Load(object sender, System.EventArgs e)
        {
            if (!ConnectionManager.Instance.FromXrmToolBox)
            {
                lblHighlight.Visible = false;
                btnClearEnvHighlight.Visible = ConnectionDetail.IsEnvironmentHighlightSet;
                btnSetEnvHighlight.Visible = false;
                lblBrowser.Visible = false;
                btnSetBrowser.Visible = false;
            }
            else
            {
                btnClearEnvHighlight.Visible = ConnectionDetail.IsEnvironmentHighlightSet;
                lblHighlight.Visible = true;
                btnSetEnvHighlight.Visible = true;
                lblBrowser.Visible = true;
                btnSetBrowser.Visible = true;
                btnClearBrowser.Visible = ConnectionDetail.BrowserName != BrowserEnum.None;
            }
        }
    }
}