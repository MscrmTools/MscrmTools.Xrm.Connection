using McTools.Xrm.Connection.WinForms.AppCode;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.Forms
{
    public partial class CompactConnectionSelector : Form
    {
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
            var obj = cbbFiles.Items[e.Index];
            string text;
            Image img = Properties.Resources.Folder32;
            if (obj is ConnectionFile cf)
            {
                text = cf.Name;

                if (!string.IsNullOrEmpty(cf.Connections.Base64Image))
                {
                    using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cf.Connections.Base64Image)))
                    {
                        img = Image.FromStream(ms);
                    }
                }
            }
            else
            {
                if ((bool)btnMru.Tag)
                {
                    img = Properties.Resources.history;
                    text = obj.ToString();
                }
                else
                {
                    img = Properties.Resources.Connection32;
                    text = obj.ToString();
                }
            }

            e.DrawBackground();

            img = img.ResizeImage(32, 32);
            e.Graphics.DrawImage(img, e.Bounds.X + 4, e.Bounds.Y + (e.Bounds.Height - 32) / 2);
            var textSize = TextRenderer.MeasureText(text, cbbFiles.Font);

            SolidBrush brush;
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus
                && (e.State & DrawItemState.Selected) == DrawItemState.Selected
                && (e.State & DrawItemState.ComboBoxEdit) == DrawItemState.ComboBoxEdit
                )
            {
                brush = new SolidBrush(Color.White);
            }
            else
            if ((e.State & DrawItemState.Focus) == DrawItemState.Focus || (e.State & DrawItemState.HotLight) == DrawItemState.HotLight || (e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                brush = new SolidBrush(Color.White);
            }
            else
            {
                brush = new SolidBrush(Color.Black);
            }

            e.Graphics.DrawString(text, cbbFiles.Font, brush, e.Bounds.X + 40, e.Bounds.Y + (e.Bounds.Height - textSize.Height) / 2);
        }

        private void lvConnections_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvConnections_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((settings?.UseDetailsViewForConnectionSelector ?? false) || (bool)btnDetailsView.Tag)
            {
                e.DrawDefault = true;
                return;
            }

            e.DrawBackground();

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }
        }

        private void lvConnections_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if ((settings?.UseDetailsViewForConnectionSelector ?? false) || (bool)btnDetailsView.Tag)
            {
                e.DrawDefault = true;
                return;
            }

            DrawingHelper.DrawConnectionDetailItem(e, false, sizeFactor);
        }
    }
}