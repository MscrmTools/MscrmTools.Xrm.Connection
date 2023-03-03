using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.AppCode
{
    internal static class DrawingHelper
    {
        public static void DrawConnectionDetailItem(DrawListViewSubItemEventArgs e, bool drawAuthType = true)
        {
            var cd = (ConnectionDetail)e.Item.Tag;

            var hlColor = cd.IsEnvironmentHighlightSet ? (cd.EnvironmentHighlightingInfo.Color ?? Color.White) : Color.White;

            using (var pen = new Pen(new SolidBrush(hlColor)))
                e.Graphics.FillRectangle(new SolidBrush(hlColor), new Rectangle(e.Bounds.X, e.Bounds.Y, 5, e.Bounds.Height));

            Image img = Properties.Resources.Connection64;
            var base64 = ((ConnectionDetail)e.Item.Tag).ParentConnectionFile?.Base64Image;
            if (!string.IsNullOrEmpty(base64))
            {
                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(base64)))
                {
                    img = Image.FromStream(ms).ResizeImage(48, 48);
                }
            }

            e.Graphics.DrawImage(img, e.Bounds.X + 20, e.Bounds.Y + 10, 48, 48);

            using (var font = new Font(e.Item.ListView.Font.FontFamily, 14))
                e.Graphics.DrawString(cd.ConnectionName, font, new SolidBrush(e.Item.Selected ? Color.White : Color.Black), new Point(e.Bounds.X + 100, e.Bounds.Y));

            using (var font = new Font(e.Item.ListView.Font.FontFamily, 10))
            {
                var userName = cd.UserName;
                if (string.IsNullOrEmpty(userName) && !cd.IsCustomAuth) userName = "Integrated authentication";
                if (string.IsNullOrEmpty(userName)) userName = "Unknown";

                e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.globe_white : Properties.Resources.globe_blue, e.Bounds.X + 100, e.Bounds.Y + 25, 14, 14);
                e.Graphics.DrawString(cd.WebApplicationUrl, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 120, e.Bounds.Y + 25));
                e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.user_white : Properties.Resources.user_blue, e.Bounds.X + 100, e.Bounds.Y + 40, 14, 14);
                e.Graphics.DrawString(userName, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 120, e.Bounds.Y + 40));

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

                    e.Graphics.DrawImage(e.Item.Selected ? Properties.Resources.auth_white : Properties.Resources.auth_blue, e.Bounds.X + 100 + userNameSize.Width + 15, e.Bounds.Y + 40, 14, 14);
                    e.Graphics.DrawString(authType, font, new SolidBrush(e.Item.Selected ? Color.White : Color.FromArgb(84, 168, 232)), new Point(e.Bounds.X + 110 + userNameSize.Width + 20, e.Bounds.Y + 40));
                }
            }
        }
    }
}