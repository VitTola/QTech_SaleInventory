using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.Components
{
    public partial class ExPanel : Panel
    {
        public ExPanel()
        {
            InitializeComponent();
            BorderStyle = BorderStyle.None;
            Padding = new Padding(2, 2, 2, 2);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen redPen = new Pen(SystemColors.ActiveBorder, 1);
            redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            PointF point1 = new PointF(0F, 0F);
            PointF point2 = new PointF(Width, 0F);
            e.Graphics.DrawLine(redPen, point1, point2);
        }
    }
}
