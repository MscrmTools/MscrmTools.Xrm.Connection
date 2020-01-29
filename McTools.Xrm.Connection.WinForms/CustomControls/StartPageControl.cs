using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public enum ConnectionType
    {
        Wizard,
        Sdk,
        ConnectionString,
        Certificate,
        ClientSecret,
        Mfa
    }

    public partial class StartPageControl : UserControl, IConnectionWizardControl
    {
        public StartPageControl()
        {
            InitializeComponent();

            var tt = new ToolTip();
            tt.SetToolTip(btnStandard, @"Connect using the wizard included with XrmToolBox");
            tt.SetToolTip(btnSdkLoginControl, @"Connect using the wizard included in official Microsoft tools like Plugin Registration Tool or Configuration Manager.

Connections created with this wizard cannot be transported across multiple computers (Preview)");
            tt.SetToolTip(btnConnectionString, @"Connect by writing your own connection string");
        }

        public event EventHandler TypeSelected;

        public ConnectionType Type { get; private set; }

        private void btn_Click(object sender, EventArgs e)
        {
            if (sender == btnStandard)
            {
                Type = ConnectionType.Wizard;
            }
            else if (sender == btnSdkLoginControl)
            {
                Type = ConnectionType.Sdk;
            }
            else if (sender == btnCertificate)
            {
                Type = ConnectionType.Certificate;
            }
            else if (sender == btnClientSecret)
            {
                Type = ConnectionType.ClientSecret;
            }
            else if (sender == btnMfa)
            {
                Type = ConnectionType.Mfa;
            }
            else
            {
                Type = ConnectionType.ConnectionString;
            }

            TypeSelected?.Invoke(this, new EventArgs());
        }
    }
}