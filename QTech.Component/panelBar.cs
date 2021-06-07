using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaleInventory
{
    public partial class panelBar : UserControl
    {
        bool mv;
        int mx, my;


        public panelBar()
        {
            InitializeComponent();
            initEvent();
        }

        [Browsable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                lblTitle.Text = value;
            }
        }

        private bool isLoaded = false;

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        private void initEvent()
        {
           

            if (!isLoaded)
            {
                picMini.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
                picExit.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                lblTitle.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;

                picExit.Click += PicExit_Click;
                lblTitle.MouseMove += lbl_MouseMove;
                lblTitle.MouseUp += lbl_MouseUp;
                lblTitle.MouseDown += lbl_MouseDown;
                picMini.Click += Picmin_Minimize;

                isLoaded = true;
            }
        }

        private void Picmin_Minimize(object sender, EventArgs e)
        {
            var parent = this.ParentForm;
            if (parent != null && !parent.IsDisposed)
            {
                parent.WindowState = FormWindowState.Minimized;
            }
        }

        private void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            var parent = this.ParentForm;
            if (parent != null && !parent.IsDisposed)
            {
                mv = true; mx = e.X; my = e.Y;
            }
        }

        private void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            var parent = this.ParentForm;
            if (parent != null && !parent.IsDisposed)
            {
                mv = false;
            }
        }

        private void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            var parent = this.ParentForm;
            if (parent != null && !parent.IsDisposed)
            {
                if (mv)
                {
                    parent.Left = parent.Left + (e.X - mx);
                    parent.Top = parent.Top + (e.Y - my);
                }
            }
        }

        private void picExit_Click_1(object sender, EventArgs e)
        {




        }

        private void picMini_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void PicExit_Click(object sender, EventArgs e)
        {
            var parent = this.ParentForm;
            if (parent != null && !parent.IsDisposed)
            {
                parent.Close();
            }
        }
        
    }
}
