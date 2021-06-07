using Storm.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExLabel:Label
    {
        public bool Required { get; set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Required)
            {


                //float dim = 5;
                ////rgba(135, 90, 123, 1)
                //var drawBrush = new SolidBrush(Color.FromArgb(135,90,123));
                //var p = new PointF[]
                //{
                //    new PointF(Width-dim,0),
                //    new PointF(Width,0),
                //    new PointF(Width,dim)
                //};

                //e.Graphics.FillPolygon(drawBrush, p);


                // Create string to draw.
                var drawString = "*";

                // Create font and brush.
                var drawFont = new Font("Times New Roman", 9.75F);
                var drawBrush = new SolidBrush(ColorTranslator.FromHtml(EDomain.Resources.ColorRequiredLabel));

                float x = Width - 8;
                float y = -3;

                // Set format of string.
                var drawFormat = new StringFormat
                {
                    FormatFlags = StringFormatFlags.DisplayFormatControl
                };
               e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);

            } 
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size = base.GetPreferredSize(proposedSize);
            size.Width = size.Width +3; 
            return size;
        } 

    }
}
