using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    internal static class DrawingHelper
    {
        public static void DrawConnectionDetailItem(DrawListViewSubItemEventArgs e, bool drawAuthType = true, int sizeFactor = 4)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            var imageSize = Convert.ToInt32(40 + 2 * sizeFactor);
            var fontSize = 10 + sizeFactor;
            var smallFontSize = 6 + sizeFactor;

            var cd = (ConnectionDetail)e.Item.Tag;

            var hlColor = cd.IsEnvironmentHighlightSet ? (cd.EnvironmentHighlightingInfo.Color ?? Color.White) : Color.White;

            using (var pen = new Pen(new SolidBrush(hlColor)))
                e.Graphics.FillRectangle(new SolidBrush(hlColor), new Rectangle(e.Bounds.X, e.Bounds.Y, 5, e.Bounds.Height));

            Image img = (cd.UseOnline ? Properties.Resources.Dataverse_64x64 : Properties.Resources.Dynamics365_64).ResizeImage(imageSize, imageSize); // Properties.Resources.Connection64;
            var base64 = ((ConnectionDetail)e.Item.Tag).ParentConnectionFile?.Base64Image;
            if (!string.IsNullOrEmpty(base64))
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64)))
                {
                    img = Image.FromStream(ms).ResizeImage(imageSize, imageSize);
                }
            }

            e.Graphics.DrawImage(img, e.Bounds.X + 10, e.Bounds.Y + 3 * sizeFactor, imageSize, imageSize);
            var yOffset = 0;

            using (var font = new Font(e.Item.ListView.Font.FontFamily, fontSize))
            {
                e.Graphics.DrawString(cd.ConnectionName, font, new SolidBrush(e.Item.Selected ? Color.White : Color.Black), new Point(e.Bounds.X + 70, e.Bounds.Y));
                yOffset += TextRenderer.MeasureText(cd.ConnectionName, font).Height;
            }

            using (var font = new Font(e.Item.ListView.Font.FontFamily, smallFontSize))
            {
                var userName = cd.UserName;
                if (string.IsNullOrEmpty(userName) && !cd.IsCustomAuth) userName = "Integrated authentication";
                if (string.IsNullOrEmpty(userName)) userName = "Unknown";

                var textHeight = TextRenderer.MeasureText(userName, font).Height;

                e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.globe_white.ResizeImage(fontSize, fontSize) : Properties.Resources.globe_blue.ResizeImage(fontSize, fontSize), e.Bounds.X + 75, e.Bounds.Y + yOffset, fontSize, fontSize);
                e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.user_white.ResizeImage(fontSize, fontSize) : Properties.Resources.user_blue.ResizeImage(fontSize, fontSize), e.Bounds.X + 75, e.Bounds.Y + yOffset + textHeight, fontSize, fontSize);

                e.Graphics.DrawString(cd.WebApplicationUrl, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 90, e.Bounds.Y + yOffset));
                e.Graphics.DrawString(userName, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 90, e.Bounds.Y + yOffset + textHeight));

                if (drawAuthType)
                {
                    var userNameSize = TextRenderer.MeasureText(userName, font);
                    string authType;
                    if (cd.IsFromSdkLoginCtrl)
                    {
                        authType = "MS Login Control";
                    }
                    else if (cd.NewAuthType.ToString() == "AD")
                    {
                        authType = "Wizard";
                    }
                    else
                    {
                        authType = cd.NewAuthType.ToString();
                    }

                    e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.auth_white.ResizeImage(fontSize, fontSize) : Properties.Resources.auth_blue.ResizeImage(fontSize, fontSize), e.Bounds.X + 100 + userNameSize.Width + 15, e.Bounds.Y + yOffset + textHeight, fontSize, fontSize);
                    e.Graphics.DrawString(authType, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 110 + userNameSize.Width + 20, e.Bounds.Y + yOffset + textHeight));
                }
            }
        }
    }
}