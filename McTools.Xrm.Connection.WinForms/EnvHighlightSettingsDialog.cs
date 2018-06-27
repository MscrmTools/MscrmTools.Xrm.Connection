using System;
using System.Drawing;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class EnvHighlightSettingsDialog : Form
    {
        private Color backColor;
        private Color textColor;

        public EnvHighlightSettingsDialog(Color? backColor, Color? textColor, string text)
        {
            InitializeComponent();

            this.backColor = backColor.HasValue ? this.backColor : Color.FromArgb(255, 0, 255);
            this.textColor = textColor.HasValue ? this.textColor : Color.White;
            txtText.Text = text;
            btnBackColor.BackColor = this.backColor;
            btnTextColor.BackColor = this.textColor;
        }

        public event EventHandler<TemplateChangeEventArgs> OnTemplateSettingsChanged;

        private void btnBackColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog { Color = backColor };
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog { Color = textColor };
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