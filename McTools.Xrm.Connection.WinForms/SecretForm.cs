using System;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    /// <summary>
    /// Formulaire Windows permettant de demander le mot de
    /// passe d'un utilisateur
    /// </summary>
    public partial class SecretForm : Form
    {
        #region Variables

        /// <summary>
        /// Login de l'utilisateur
        /// </summary>
        private string clientId;

        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        private string clientSecret;

        #endregion Variables

        #region Constructeur

        /// <summary>
        /// Créé une nouvelle instance de la classe PasswordForm
        /// </summary>
        public SecretForm(ConnectionDetail detail)
        {
            InitializeComponent();

            lblConnectionName.Text = detail.ConnectionName;
        }

        #endregion Constructeur

        #region Propriétés

        /// <summary>
        /// Obtient ou définit le login de l'utilisateur
        /// </summary>
        public string ClientId
        {
            get => clientId;
            set => clientId = value;
        }

        /// <summary>
        /// Obtient le secret
        /// </summary>
        public string ClientSecret => clientSecret;

        public bool SaveSecret { get; set; }

        #endregion Propriétés

        #region Méthodes

        protected override void OnLoad(EventArgs e)
        {
            tbClientId.Text = clientId;

            tbClientSecret.Focus();

            base.OnLoad(e);
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bValidate_Click(object sender, EventArgs e)
        {
            bool go = true;

            if (tbClientSecret.Text.Length == 0)
            {
                if (MessageBox.Show(this, @"Are you sure you want to leave the secret empty?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    go = false;
                }
            }

            if (go)
            {
                clientSecret = tbClientSecret.Text;
                SaveSecret = chkSavePassword.Checked;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void chkShowCharacters_CheckedChanged(object sender, EventArgs e)
        {
            tbClientSecret.PasswordChar = chkShowCharacters.Checked ? (char)0 : '•';
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                bValidate_Click(null, null);
            }
        }

        #endregion Méthodes
    }
}