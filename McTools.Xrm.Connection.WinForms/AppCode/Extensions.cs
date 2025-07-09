using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    public static class Extensions
    {
        public static Image ResizeImage(this Image image, int width, int height)
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

        public static void SetAutoWidth(this RadioButton rb)
        {
            rb.Width = TextRenderer.MeasureText(rb.Text, rb.Font).Width + 20;
        }

        public static void SetAutoWidth(this Label label)
        {
            label.Width = TextRenderer.MeasureText(label.Text, label.Font).Width;
        }
    }
}