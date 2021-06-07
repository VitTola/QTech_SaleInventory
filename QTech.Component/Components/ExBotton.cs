
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component.Components
{
    public class ExBotton : Button
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(ShortcutText))
            {
                return;
            }

            // Create font and brush.
            var drawFont = new Font("Constantia", 5.75F); 
            var drawBrush = new SolidBrush(Color.White);
            // Set format of string.
            var drawFormat = new StringFormat
            {
                FormatFlags = StringFormatFlags.DisplayFormatControl,
                Alignment = StringAlignment.Far,
            };
            var textSize = e.Graphics.MeasureString(ShortcutText, drawFont);

            var locationF = new PointF(Width - 5, 5);
            int diameter = 2 * 2;
            var size = new SizeF(diameter, diameter);
            var bounds = new RectangleF(locationF, new SizeF(textSize.Width + 2, textSize.Height + 2));
            // Padding
            bounds.X -= bounds.Width - 1;
            bounds.Y -= 2;
            if (ShortcutAligment == Aligment.Vertical)
            {
                locationF = new PointF(locationF.X - textSize.Height, locationF.Y);
                bounds = new RectangleF(locationF, new SizeF(bounds.Height, bounds.Width));
                bounds.X -= 1;
                bounds.Y -= 2;
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                drawFormat.Alignment = StringAlignment.Near;
            } 

            var arc = new RectangleF(bounds.Location, size); 
            GraphicsPath path = new GraphicsPath(); 

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
            

            e.Graphics.FillPath(new SolidBrush(ColorTranslator.FromHtml(EDomain.Resources.ColorPrimary)), path);
            e.Graphics.DrawPath(new Pen(Color.White), path);
            e.Graphics.DrawString(ShortcutText, drawFont, drawBrush,locationF, drawFormat);
        }

        public string ShortcutText { get; set; }

        public Aligment ShortcutAligment { get; set; } = ExBotton.Aligment.Horizontal;


        public enum Aligment
        {
            Vertical,
            Horizontal
        }
    }
}
