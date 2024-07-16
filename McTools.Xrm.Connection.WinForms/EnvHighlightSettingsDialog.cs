using McTools.Xrm.Connection.WinForms.AppCode;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class EnvHighlightSettingsDialog : Form
    {
        private readonly ConnectionDetail detail;
        private Color backColor;
        private Color textColor;

        public EnvHighlightSettingsDialog(Color? backColor, Color? textColor, string text, ConnectionDetail detail)
        {
            InitializeComponent();

            this.detail = detail;

            this.backColor = backColor.HasValue ? backColor.Value : Color.FromArgb(255, 0, 255);
            this.textColor = textColor.HasValue ? textColor.Value : Color.White;
            txtText.Text = text;
            btnBackColor.BackColor = this.backColor;
            btnTextColor.BackColor = this.textColor;

            btnUseOrgTheme.Visible = detail.OrganizationMajorVersion > 7 ||
                                      detail.OrganizationMajorVersion == 7 && detail.OrganizationMinorVersion >= 1;

            CustomTheme.Instance.ApplyTheme(this);
        }

        public event EventHandler<TemplateChangeEventArgs> OnTemplateSettingsChanged;

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog { Color = backColor })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    backColor = dialog.Color;
                    ((Button)sender).BackColor = dialog.Color;

                    OnTemplateSettingsChanged?.Invoke(this, new TemplateChangeEventArgs
                    {
                        BackColor = backColor,
                        Text = txtText.Text,
                        TextColor = textColor
                    });
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            using (var dialog = new ColorDialog { Color = textColor })
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    textColor = dialog.Color;
                    ((Button)sender).BackColor = dialog.Color;

                    OnTemplateSettingsChanged?.Invoke(this, new TemplateChangeEventArgs
                    {
                        BackColor = backColor,
                        Text = txtText.Text,
                        TextColor = textColor
                    });
                }
            }
        }

        private void btnUseOrgTheme_Click(object sender, EventArgs e)
        {
            btnUseOrgTheme.Text = @"Connecting...";
            btnUseOrgTheme.Enabled = false;
            Cursor = Cursors.WaitCursor;

            var bw = new BackgroundWorker { WorkerReportsProgress = true };
            bw.DoWork += (s, evt) =>
            {
                var svc = detail.ServiceClient;

                ((BackgroundWorker)s).ReportProgress(50);

                evt.Result = svc.RetrieveMultiple(new QueryExpression
                {
                    EntityName = "theme",
                    ColumnSet = new ColumnSet("navbarbackgroundcolor"),
                    Criteria = new FilterExpression
                    {
                        Conditions =
                            {
                                new ConditionExpression("isdefaulttheme", ConditionOperator.Equal, true)
                            }
                    }
                }).Entities.FirstOrDefault();
            };
            bw.RunWorkerCompleted += (s, evt) =>
            {
                btnUseOrgTheme.Text = @"Use environment theme";
                btnUseOrgTheme.Enabled = true;
                Cursor = Cursors.Default;

                if (evt.Error != null)
                {
                    MessageBox.Show(this,
                        $@"An error occured when retrieving theme: {evt.Error.Message}",
                        @"Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else if (evt.Result is Entity theme)
                {
                    backColor = ColorTranslator.FromHtml(theme.GetAttributeValue<string>("navbarbackgroundcolor"));
                    btnBackColor.BackColor = backColor;
                    textColor = Color.White;
                    btnTextColor.BackColor = textColor;
                    txtText.Text = txtText.Text.Length == 0 ? detail.ConnectionName : txtText.Text;

                    OnTemplateSettingsChanged?.Invoke(this, new TemplateChangeEventArgs
                    {
                        BackColor = backColor,
                        Text = txtText.Text,
                        TextColor = textColor
                    });
                }
            };
            bw.ProgressChanged += (s, evt) =>
            {
                if (evt.ProgressPercentage == 50)
                {
                    btnUseOrgTheme.Text = @"Retrieving theme...";
                }
            };
            bw.RunWorkerAsync();
        }

        private void txtText_TextChanged(object sender, EventArgs e)
        {
            OnTemplateSettingsChanged?.Invoke(this, new TemplateChangeEventArgs
            {
                BackColor = backColor,
                Text = txtText.Text,
                TextColor = textColor
            });
        }
    }

    public class TemplateChangeEventArgs : EventArgs
    {
        public Color BackColor { get; set; }
        public string Text { get; set; }
        public Color TextColor { get; set; }
    }
}