
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExButtonLoading:Button,IAsyncTask
    {
        public ExButtonLoading()
        {
            BackColor = Color.Ivory;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = Color.FromArgb(238, 127, 0);
        }
        public enum Aligment
        {
            Vertical,
            Horizontal
        }
        [Browsable(false)]
        public Image DefaultImage { get; set; } = null;
        public Aligment ShortcutAligment { get; set; } = Aligment.Horizontal;
        public string ShortcutText { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (string.IsNullOrEmpty(ShortcutText))
            {
                return;
            }

            // Create font and brush.
            //var drawFont = new Font("Constantia", 6.75F);
            var drawFont = new Font("Arial Black", 7F);
            //var drawFont = new Font("DDD Round Square", 8F);
            var drawBrush = new SolidBrush(ColorTranslator.FromHtml(EDomain.Resources.ColorPrimary));
            // Set format of string.
            var drawFormat = new StringFormat
            {
                FormatFlags = StringFormatFlags.DisplayFormatControl,
                Alignment = StringAlignment.Far,
            };
            var locationF = new PointF(Width - 2, 1);
            var textSize = e.Graphics.MeasureString(ShortcutText, drawFont);
            ////int diameter = 1 * 2;
            ////var size = new SizeF(diameter, diameter);
            ////var bounds = new RectangleF(locationF, new SizeF(textSize.Width + 2, textSize.Height + 2));
            //// Padding
            //bounds.X -= bounds.Width - 1;
            //bounds.Y -= 2;
            if (ShortcutAligment == Aligment.Vertical)
            {
                locationF = new PointF(locationF.X - textSize.Height, locationF.Y);
                //bounds = new RectangleF(locationF, new SizeF(bounds.Height, bounds.Width));
                //bounds.X -= 1;
                //bounds.Y -= 2;
                drawFormat.FormatFlags = StringFormatFlags.DirectionVertical;
                drawFormat.Alignment = StringAlignment.Near;
            }

            //var arc = new RectangleF(bounds.Location, size);
            //GraphicsPath path = new GraphicsPath();

            //// top left arc  
            //path.AddArc(arc, 180, 90);

            //// top right arc  
            //arc.X = bounds.Right - diameter;
            //path.AddArc(arc, 270, 90);

            //// bottom right arc  
            //arc.Y = bounds.Bottom - diameter;
            //path.AddArc(arc, 0, 90);

            //// bottom left arc 
            //arc.X = bounds.Left;
            //path.AddArc(arc, 90, 90);
            //path.CloseFigure();


            //e.Graphics.FillPath(new SolidBrush(ColorTranslator.FromHtml(Properties.Resources.ColorPrimary)), path);

            //e.Graphics.DrawPath(new Pen(Color.White), path);
            //e.Graphics.DrawPath(new Pen(ColorTranslator.FromHtml(Properties.Resources.ColorPrimary)), path);
            this.Font = new Font("Khmer OS Siemreap", 8);

            e.Graphics.DrawString(ShortcutText, drawFont, drawBrush, locationF, drawFormat);
        }


        public bool Executing { get; set ;}

        public void PostExecute(bool block =false)
        {
            if (block)
            { 
                Enabled = true;
            }
            Image = DefaultImage; 
        }

        public void PreExecute(bool block = false)
        {
            if (block)
            {
                Enabled = false;
            }
            if (Image != null)
            {
                DefaultImage = (Image)Image.Clone();
            }
            Image = Properties.Resources.spin;
            ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        }

        protected override void OnClick(EventArgs e)
        {
            if (Executing)
            {
                return;
            }
            base.OnClick(e);
        }
    }
}
