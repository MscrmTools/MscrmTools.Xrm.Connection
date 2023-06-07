using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionSucceededControl : UserControl, IConnectionWizardControl
    {
        private ConnectionFile folder;

        public ConnectionSucceededControl(ConnectionFile folder = null)
        {
            InitializeComponent();

            this.folder = folder;
        }

        public ConnectionDetail ConnectionDetail { private get; set; }

        public string ConnectionName
        {
            get => txtConnectionName.Text;
            set => txtConnectionName.Text = value;
        }

        public bool HasCreatedNewFolder { get; private set; }

        public ConnectionFile ParentFolder => (ConnectionFile)cbbFolderSelection.SelectedItem;

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

        private void BtnNewFolder_Click(object sender, System.EventArgs e)
        {
            var ncf = new ConnectionFile(new CrmConnections("Default"));
            using (var nfd = new EditConnectionFileDialog(ncf, true, false))
            {
                if (nfd.ShowDialog(this) == DialogResult.OK)
                {
                    ncf.Connections.Name = nfd.NewName;
                    ncf.Save();

                    ConnectionsList.Instance.Files.Add(ncf);

                    cbbFolderSelection.Items.Add(ncf);
                    cbbFolderSelection.SelectedItem = ncf;

                    HasCreatedNewFolder = true;
                }
            }
            ConnectionsList.Instance.Save();
        }

        private void btnSetBrowser_Click(object sender, System.EventArgs e)
        {
            var dialog = new BrowserSelectionDialog(ConnectionDetail.BrowserName, ConnectionDetail.BrowserProfile);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                ConnectionDetail.BrowserName = dialog.Browser;
                ConnectionDetail.BrowserProfile = dialog.Profile;
            }
        }

        private void btnSetEnvHighlight_Click(object sender, System.EventArgs e)
        {
            var dialog = new EnvHighlightDialog(ConnectionDetail);
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

            cbbFolderSelection.Items.AddRange(ConnectionManager.Instance.ConnectionsFilesList.Files.OrderBy(f => f.Name).ToArray());
            if (folder != null)
            {
                cbbFolderSelection.SelectedItem = folder;
                cbbFolderSelection.Visible = false;
                lblAddToFolder.Visible = false;
                btnNewFolder.Visible = false;
            }
            else
            {
                var defaultFile = ConnectionManager.Instance.ConnectionsFilesList.Files.FirstOrDefault(f => f.Name == "Default");
                if (defaultFile != null)
                {
                    cbbFolderSelection.SelectedItem = defaultFile;
                }
                else
                {
                    cbbFolderSelection.SelectedIndex = 0;
                }
            }
        }
    }
}