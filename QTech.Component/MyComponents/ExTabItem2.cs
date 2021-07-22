using System;                        
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class ExTabItem2 : Button
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public int ParentId { get; set; }
        public ExTabItem2()
        {
            InitializeComponent();

            this.MouseEnter += ExTabItem2_MouseEnter;
            this.MouseLeave += ExTabItem2_MouseLeave;
        }
        public string ExItem2Text { get; set; }
        public override string Text { get => ExItem2Text; set => base.Text = ExItem2Text; }
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
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 15, 15));

            base.OnPaint(pevent);

            this.Font = new Font("Khmer OS Siemreap", 9);

            using (Graphics cg = this.CreateGraphics())
            {
                SizeF size = cg.MeasureString(this.Text, this.Font);
                this.Width = (int)size.Width+30;
                //ForeColor = Color.Blue;
            }

        }

    }

}
