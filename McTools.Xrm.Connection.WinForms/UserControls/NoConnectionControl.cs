using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace McTools.Xrm.Connection.WinForms.UserControls
{
    public partial class NoConnectionControl : UserControl
    {
        public NoConnectionControl()
        {
            InitializeComponent();
        }

        public LinkLabel ActionLabel { get; set; }

        private void NoConnectionControl_Load(object sender, EventArgs e)
        {
            NoConnectionControl_Resize(this, new EventArgs());

            if (ActionLabel != null)
            {
                ActionLabel.Width = lblNoConnectionFound.Width;
                ActionLabel.Font = new Font(lblNoConnectionFound.Font.FontFamily, lblNoConnectionFound.Font.Size - 4);
                ActionLabel.Height = lblNoConnectionFound.Height;
                ActionLabel.Location = new System.Drawing.Point(lblNoConnectionFound.Location.X, lblNoConnectionFound.Location.Y + lblNoConnectionFound.Height);
                ActionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

                Controls.Add(ActionLabel);
            }
        }

        private void NoConnectionControl_Resize(object sender, EventArgs e)
        {
            pbNoConnection.Location = new Point(Width / 2 - pbNoConnection.Width / 2, Height / 2 - pbNoConnection.Height / 2 - lblNoConnectionFound.Height) ;
            lblNoConnectionFound.Location = new Point(0, pbNoConnection.Location.Y + pbNoConnection.Height);
            lblNoConnectionFound.Width = Width;

            var ll = Controls.OfType<LinkLabel>().FirstOrDefault();
            if (ll != null)
            {
                ActionLabel.Location = new Point(lblNoConnectionFound.Location.X, lblNoConnectionFound.Location.Y + lblNoConnectionFound.Height);
                ActionLabel.Width = lblNoConnectionFound.Width;
            }
        }
    }
}