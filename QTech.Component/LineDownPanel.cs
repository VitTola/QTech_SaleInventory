using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleInventory.Components
{
    public partial class LineDownPanel : Panel
    {
        public LineDownPanel()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen redPen = new Pen(Color.Gray, 20);
            redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            PointF point1 = new PointF(0f, Height);
            PointF point2 = new PointF(Width, Height);
            e.Graphics.DrawLine(redPen, point1, point2);
        }
    }
}
