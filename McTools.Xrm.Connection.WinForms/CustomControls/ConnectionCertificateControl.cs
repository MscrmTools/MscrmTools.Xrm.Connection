using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionCertificateControl : UserControl, IConnectionWizardControl
    {
        private readonly ConnectionDetail _detail;
        private readonly X509Store _store;

        public ConnectionCertificateControl(ConnectionDetail detail = null)
        {
            _store = new X509Store("MY", StoreLocation.CurrentUser);
            InitializeComponent();

            _detail = detail;
        }

        public X509Certificate2 Certificate { get; private set; }

        private void btnBrowseCert_Click(object sender, System.EventArgs e)
        {
            _store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = _store.Certificates;
            X509Certificate2Collection fcollection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(fcollection,
                "Certificate selection",
                "Select a certificate from the following list to use as connection credentials",
                X509SelectionFlag.SingleSelection);

            if (scollection.Count == 0) return;

            Certificate = scollection[0];

            DisplayCertInfo();

            _store.Close();
        }

        private void ConnectionStringControl_Load(object sender, System.EventArgs e)
        {
            if (_detail != null)
            {
                _store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
                X509Certificate2Collection collection = _store.Certificates;

                foreach (var c in collection)
                {
                    if (c.GetNameInfo(X509NameType.SimpleName, false) == _detail.Certificate?.Name
                       && c.Issuer == _detail.Certificate?.Issuer
                       && c.Thumbprint == _detail.Certificate?.Thumbprint)
                    {
                        Certificate = c;
                        DisplayCertInfo();
                    }
                }

                _store.Close();
            }
        }

        private void DisplayCertInfo()
        {
            lblName.Text = string.Format(lblName.Tag.ToString(), Certificate.GetNameInfo(X509NameType.SimpleName, false));
            lblIssuer.Text = string.Format(lblIssuer.Tag.ToString(), Certificate.Issuer);
            lblThumbprint.Text = string.Format(lblThumbprint.Tag.ToString(), Certificate.Thumbprint);
        }
    }
}