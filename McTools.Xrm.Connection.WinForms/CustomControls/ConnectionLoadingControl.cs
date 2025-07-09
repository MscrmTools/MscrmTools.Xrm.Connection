using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionLoadingControl : UserControl, IConnectionWizardControl
    {
        public ConnectionLoadingControl(ConnectionDetail detail)
        {
            InitializeComponent();

            if (detail.UseOnline)
            {
                label3.Text = string.Format(label3.Text, "Dataverse environment");
            }
            else
            {
                label3.Text = string.Format(label3.Text, "Microsoft Dynamics CRM/365 organization");
            }
        }
    }
}