using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component.Components
{
    public class ExToolTip : ToolTip
    {
        public ExToolTip()
        {
         
            OwnerDraw = true;
            this.Draw += exToolTip_Draw;
            
            this.Popup += ExToolTip_Popup;
        }
        public ExToolTip(System.ComponentModel.IContainer Cont)
        {
            OwnerDraw = true;
            this.Draw += exToolTip_Draw;
            this.Popup += ExToolTip_Popup;
        }

        private void ExToolTip_Popup(object sender, PopupEventArgs e)
        {   
            var size =  TextRenderer.MeasureText(this.GetToolTip(e.AssociatedControl), new Font("Khmer OS System", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))));
            e.ToolTipSize = new Size(size.Width + 8, size.Height);      
        }

        private void exToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            DrawToolTipEventArgs newArgs = new DrawToolTipEventArgs(e.Graphics,
               e.AssociatedWindow, e.AssociatedControl, new Rectangle( e.Bounds.Location,new Size(e.Bounds.Width+8,e.Bounds.Height+8)), e.ToolTipText,
               this.BackColor, this.ForeColor, new Font("Khmer OS System", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))));

            //newArgs.DrawBorder();
            newArgs.DrawText();
            //newArgs.DrawBackground();
            //newArgs.DrawBorder();
            //newArgs.Graphics.DrawString(newArgs.ToolTipText, newArgs.Font, Brushes.Black, e.Bounds);
        }
    }
}
