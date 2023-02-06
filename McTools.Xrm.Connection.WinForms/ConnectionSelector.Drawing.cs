using McTools.Xrm.Connection.WinForms.AppCode;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms
{
    public partial class ConnectionSelector : Form
    {
        private void lvConnectionFiles_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvConnectionFiles_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawBackground();

            var file = (ConnectionFile)e.Item.Tag;

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
            }

            Image img = Properties.Resources.Folder64;

            if (!string.IsNullOrEmpty(file.Connections.Base64Image))
            {
                if (!_imageCache.ContainsKey(file.Connections.Name))
                {
                    byte[] bytes = Convert.FromBase64String(file.Connections.Base64Image);

                    using (MemoryStream ms = new MemoryStream(bytes))
                    {
                        img = Image.FromStream(ms);

                        img = ResizeImage(img, 48, 48);

                        _imageCache.Add(file.Connections.Name, img);
                    }
                }

                img = _imageCache[file.Connections.Name];
            }

            e.Graphics.DrawImage(img, e.Bounds.X + 10, e.Bounds.Y + 10, 48, 48);
            using (var font = new Font(e.Item.ListView.Font.FontFamily, 16))
            {
                using (var titleBrush = new SolidBrush(e.Item.Selected ? Color.White : Color.Black))
                {
                    e.Graphics.DrawString(file.Name, font, titleBrush, e.Bounds.X + 60, e.Bounds.Y + 10);
                }
            }

            using (var font = new Font(e.Item.ListView.Font.FontFamily, 12))
            {
                using (var countBrush = new SolidBrush(e.Item.Selected ? Color.LightGray : Color.Gray))
                {
                    e.Graphics.DrawString($"{file.Connections.Connections.Count} connection{(file.Connections.Connections.Count > 1 ? "s" : "")}", font, countBrush, e.Bounds.X + 62, e.Bounds.Y + 35);
                }
            }
        }

        private void lvConnections_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvConnections_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (showCompact)
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
            if (e.ColumnIndex != 0 || showCompact)
            {
                e.DrawDefault = true;
                return;
            }

            DrawingHelper.DrawConnectionDetailItem(e);
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height);
            using (Graphics gr = Graphics.FromImage(newImage))
            {
                gr.CompositingMode = CompositingMode.SourceCopy;
                gr.CompositingQuality = CompositingQuality.HighQuality;
                gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gr.SmoothingMode = SmoothingMode.HighQuality;
                gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gr.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return newImage;
        }
    }
}