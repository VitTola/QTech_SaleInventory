
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;
namespace QTech.Component.Components
{
    public partial class ExLinkLabel : LinkLabel
    {
        public ExLinkLabel() { }
        public bool ShowShortcutText { get; set; }
        public string ShortcutText { get; set; } = "";
        public int RightSpace { get; set; } = 10;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (ShowShortcutText)
            {
                // Create string to draw.
                if (!string.IsNullOrEmpty(ShortcutText))
                {
                    var drawString = ShortcutText;

                    // Create font and brush.
                    var drawFont = new Font("Arial Black", 7F);
                    var drawBrush = new SolidBrush(ColorTranslator.FromHtml(EDomain.Resources.ColorPrimary));

                    float x = Width - RightSpace;
                    float y = -3;

                    // Set format of string.
                    var drawFormat = new StringFormat
                    {
                        FormatFlags = StringFormatFlags.DisplayFormatControl
                    };
                    e.Graphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
                }
            }
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size = base.GetPreferredSize(proposedSize);
            size.Width = size.Width + 3;
            return size;
        }
    }
}
