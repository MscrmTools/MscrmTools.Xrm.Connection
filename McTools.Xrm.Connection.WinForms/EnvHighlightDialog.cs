using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class EnvHighlightDialog : Form
    {
        private readonly Image template;
        private Color backColor = Color.FromArgb(255, 255, 0, 255);
        private string text;
        private Color textColor = Color.White;

        public EnvHighlightDialog(ConnectionDetail detail)
        {
            InitializeComponent();

            template = pbCustom.Image;

            if (detail.IsEnvironmentHighlightSet)
            {
                rdbProd.Checked = detail.EnvironmentColor == Color.Red && detail.EnvironmentTextColor == Color.White &&
                                  detail.EnvironmentText == "PRODUCTION";
                rdbUAT.Checked = detail.EnvironmentColor == Color.Yellow && detail.EnvironmentTextColor == Color.Black &&
                                  detail.EnvironmentText == "UAT";
                rdbCustom.Checked = !rdbProd.Checked && !rdbUAT.Checked;
                if (rdbCustom.Checked)
                {
                    Dialog_OnTemplateSettingsChanged(null, new TemplateChangeEventArgs
                    {
                        BackColor = detail.EnvironmentColor.Value,
                        TextColor = detail.EnvironmentTextColor.Value,
                        Text = detail.EnvironmentText
                    });
                }
            }
        }

        public Color BackColorSelected
        {
            get
            {
                if (rdbProd.Checked)
                {
                    return Color.Red;
                }

                if (rdbUAT.Checked)
                {
                    return Color.Yellow;
                }

                return backColor;
            }
        }

        public Color TextColorSelected
        {
            get
            {
                if (rdbProd.Checked)
                {
                    return Color.White;
                }

                if (rdbUAT.Checked)
                {
                    return Color.Black;
                }

                return textColor;
            }
        }

        public string TextSelected
        {
            get
            {
                if (rdbProd.Checked)
                {
                    return "PRODUCTION";
                }

                if (rdbUAT.Checked)
                {
                    return "UAT";
                }

                return text;
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            if (!rdbUAT.Checked && !rdbProd.Checked && !rdbCustom.Checked)
            {
                MessageBox.Show(this, @"Please select a template", @"Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            Close();
        }

        private void Dialog_OnTemplateSettingsChanged(object sender, TemplateChangeEventArgs e)
        {
            textColor = e.TextColor;
            backColor = e.BackColor;
            text = e.Text;

            var font = new Font(new FontFamily("Calibri"), 30, FontStyle.Bold);

            var image = (Image)template.Clone();
            var g = Graphics.FromImage(image);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Center };
            g.DrawString(text, font, new SolidBrush(textColor), new Rectangle(0, 50, image.Width, 50), sf);

            ImageAttributes imageAttributes = new ImageAttributes();

            ColorMap[] remapTable =
            {
                new ColorMap
                {
                    OldColor = Color.FromArgb(255, 255, 0, 255),
                    NewColor = Color.FromArgb(255, e.BackColor.R, e.BackColor.G, e.BackColor.B)
                }
            };

            imageAttributes.SetRemapTable(remapTable, ColorAdjustType.Bitmap);

            g.DrawImage(image, 0, 0, image.Width, image.Height);
            g.DrawImage(
                image,
                new Rectangle(0, 0, image.Width, image.Height),  // destination rectangle
                0, 0,        // upper-left corner of source rectangle
                image.Width,       // width of source rectangle
                image.Height,      // height of source rectangle
                GraphicsUnit.Pixel,
                imageAttributes);

            pbCustom.Image = image;
            pbCustom.Invalidate();
        }

        private void rdbCustom_MouseClick(object sender, MouseEventArgs e)
        {
            var dialog = new EnvHighlightSettingsDialog(null, null, "");
            dialog.OnTemplateSettingsChanged += Dialog_OnTemplateSettingsChanged;
            dialog.ShowDialog(this);
        }
    }
}