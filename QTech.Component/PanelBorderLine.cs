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
    public partial class PanelBorderLine : Panel
    {
        public PanelBorderLine()
        {
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen redPen = new Pen(SystemColors.ActiveBorder, 5);
            redPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Rectangle rectangle = new Rectangle(0,0, Width, Height);
            e.Graphics.DrawRectangle(redPen, rectangle);
        }
    }
}
