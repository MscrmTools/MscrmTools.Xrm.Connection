using System.Drawing;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    public partial class ConnectionCredentialsControl : UserControl, IConnectionWizardControl
    {
        private const string DomainTip = "Provide domain name, possibly not mandatory for IFD connection";
        private const string PasswordTemp = "@@PASSWORD@@";
        private const string PasswordTip = "Please specify the password";
        private const string UserTip = "Provide user name. For IFD connections, try domain\\username";

        public ConnectionCredentialsControl()
        {
            InitializeComponent();

            txtUsername.Text = UserTip;
            txtDomain.Text = DomainTip;
            txtPassword.TextChanged -= txt_TextChanged;
            txtPassword.Text = PasswordTip;
            txtPassword.TextChanged += txt_TextChanged;
        }

        public string Domain
        {
            get => txtDomain.Text == DomainTip ? "" : txtDomain.Text;
            set
            {
                if (value?.Length > 0)
                    txtDomain.Text = value;
            }
        }

        public bool IsOnline { private get; set; }

        public string Password => txtPassword.Text == PasswordTip ? null : txtPassword.Text;

        public bool PasswordChanged { get; private set; }

        public bool PasswordIsSet
        {
            set
            {
                if (value)
                {
                    txtPassword.TextChanged -= txt_TextChanged;
                    txtPassword.Text = PasswordTemp;
                    txtPassword.ForeColor = DefaultForeColor;
                    txtPassword.UseSystemPasswordChar = true;
                    txtPassword.TextChanged += txt_TextChanged;
                }
                else
                {
                    txtPassword.TextChanged -= txt_TextChanged;
                    txtPassword.Text = PasswordTip;
                    txtPassword.ForeColor = Color.DarkGray;
                    txtPassword.UseSystemPasswordChar = false;
                    txtPassword.TextChanged += txt_TextChanged;
                }
            }
        }

        public bool SavePassword
        {
            get => chkSavePassword.Checked;
            set => chkSavePassword.Checked = value;
        }

        public string Username
        {
            get => txtUsername.Text == UserTip ? null : txtUsername.Text;
            set
            {
                if (value?.Length > 0)
                    txtUsername.Text = value;
            }
        }

        private void ConnectionCredentialsControl_Load(object sender, System.EventArgs e)
        {
            txtDomain.Enabled = !IsOnline;

            txtDomain.ForeColor = txtDomain.Text == DomainTip ? Color.DarkGray : DefaultForeColor;
            txtUsername.ForeColor = txtUsername.Text == UserTip ? Color.DarkGray : DefaultForeColor;
            txtPassword.ForeColor = txtPassword.Text == PasswordTip ? Color.DarkGray : DefaultForeColor;

            if (txtPassword.Text == PasswordTip)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txt_Enter(object sender, System.EventArgs e)
        {
            var textbox = (TextBox)sender;

            if (textbox == txtDomain && textbox.Text == DomainTip
                || textbox == txtUsername && textbox.Text == UserTip)
            {
                textbox.Text = string.Empty;
                textbox.ForeColor = DefaultForeColor;
            }
            else if (textbox.Text == PasswordTip)
            {
                textbox.TextChanged -= txt_TextChanged;

                textbox.UseSystemPasswordChar = true;
                textbox.Text = string.Empty;
                textbox.ForeColor = DefaultForeColor;

                textbox.TextChanged += txt_TextChanged;
            }
            else if (textbox.Text == PasswordTemp)
            {
                textbox.TextChanged -= txt_TextChanged;

                textbox.Text = string.Empty;

                textbox.TextChanged += txt_TextChanged;
            }
        }

        private void txt_Leave(object sender, System.EventArgs e)
        {
            var textbox = (TextBox)sender;

            if (textbox == txtDomain && textbox.Text.Length == 0)
            {
                textbox.Text = DomainTip;
                textbox.ForeColor = Color.DarkGray;
            }

            if (textbox == txtUsername && textbox.Text.Length == 0)
            {
                textbox.Text = UserTip;
                textbox.ForeColor = Color.DarkGray;
            }

            if (textbox == txtPassword && textbox.Text.Length == 0)
            {
                textbox.TextChanged -= txt_TextChanged;

                textbox.Text = PasswordTip;
                textbox.ForeColor = Color.DarkGray;
                textbox.UseSystemPasswordChar = false;

                textbox.TextChanged += txt_TextChanged;
            }
        }

        private void txt_TextChanged(object sender, System.EventArgs e)
        {
            var textbox = (TextBox)sender;
            if (textbox == txtPassword)
            {
                PasswordChanged = true;
            }
        }
    }
}