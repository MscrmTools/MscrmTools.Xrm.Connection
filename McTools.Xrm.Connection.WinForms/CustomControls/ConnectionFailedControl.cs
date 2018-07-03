using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionFailedControl : UserControl, IConnectionWizardControl
    {
        public ConnectionFailedControl()
        {
            InitializeComponent();
        }

        public string ErrorMEssage
        {
            set => lblError.Text = value;
        }

        private void llOpenConnectionLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Log folder is defined by configuration file and follows Microsoft
            // SDK tools configuration. It stores connection log file in path
            // path\Company\Product\Version
            var assembly = Assembly.GetEntryAssembly();
            var companyName = ((AssemblyCompanyAttribute)assembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute))).Company;
            var productName = ((AssemblyProductAttribute)assembly.GetCustomAttribute(typeof(AssemblyProductAttribute))).Product;
            var version = assembly.GetName().Version.ToString();

            var logFolder =
                $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\{companyName}\\{productName}\\{version}";

            if (string.IsNullOrEmpty(logFolder))
            {
                MessageBox.Show(this, @"There is no connection log folder available currently!");
            }
            else
            {
                Process.Start(logFolder);
            }
        }
    }
}