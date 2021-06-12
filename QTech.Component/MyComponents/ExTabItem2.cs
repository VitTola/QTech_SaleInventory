using System;                        
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExTabItem2 : Button
    {
        public int ParentId { get; set; }
        public ExTabItem2()
        {
            InitializeComponent();

            this.MouseEnter += ExTabItem2_MouseEnter;
            this.MouseLeave += ExTabItem2_MouseLeave;
        }

        private void ExTabItem2_MouseLeave(object sender, EventArgs e)
        {
            this.ForeColor = Color.Black;
        }

        private void ExTabItem2_MouseEnter(object sender, EventArgs e)
        { 
            this.ForeColor = Color.Firebrick;
        }

    protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            this.Font = new Font("Khmer OS Siemreap",8,FontStyle.Bold);

            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(this.Text, this.Font);
                this.Width = (int)size.Width+30;
                //ForeColor = Color.Blue;
            }

        }

    }
}
