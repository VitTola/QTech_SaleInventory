using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Forms;

namespace QTech.Component
{
    public class ExCrystalReportViewer : CrystalReportViewer, IAsyncTask
    {
        public bool Executing { get; set; }

        public void PostExecute(bool block = false)
        {
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            panel.Enabled = false;
            panel.Visible = false;
        }

        public void PreExecute(bool block = false)
        {
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            panel.Enabled = true;
            panel.Visible = true;
        }

        public ExCrystalReportViewer()
        {
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Controls.Add(picLoading);
            Controls.Add(panel);
            panel.Paint += Panel_Paint;
            this.Controls.SetChildIndex(panel, 0); 
        }

        protected override void OnLoad(EventArgs e)
        {
            var x = Width / 2 - panel.Width / 2;
            var y = Height / 2 - panel.Height / 2;
            panel.Location = new Point(x, y);
            base.OnLoad(e);
        }

        Panel panel = new Panel()
        {
            BackColor = Color.Transparent,
            Size = new Size(110, 110),
            Padding = new Padding(5),
            Visible = false,
        };

        PictureBox picLoading = new PictureBox()
        {
            Enabled = true,
            Image = Properties.Resources.dgvloading,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Visible = true,
            Dock = DockStyle.Fill
        };
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //DrawBackground(e.Graphics, picThin.ClientSize);

            // Make the smiley path.
            using (GraphicsPath path = graphicsPath(picLoading.DisplayRectangle, 5))
            {
                // Draw the shadow.
                e.Graphics.TranslateTransform(2, 2);
                //Color color = Color.FromArgb(64, 0, 0, 0);
                var color = Color.FromArgb(234, 234, 234);
                using (Pen thick_pen = new Pen(color, 4))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
                e.Graphics.ResetTransform();
            }
        }
        private GraphicsPath graphicsPath(Rectangle bounds, int radius)
        {
            bounds.Location = new Point(bounds.Location.X + 4, bounds.Location.Y + 4);
            bounds.Size = new Size(bounds.Size.Width - 1, bounds.Size.Height - 1);

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            GraphicsPath path = new GraphicsPath();
            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

    }
}
