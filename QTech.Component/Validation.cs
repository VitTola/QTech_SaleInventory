using QTech.Component.Helpers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class Validation : Form
    {
        private Control _clParent;
        private TabAlignment _aligment = TabAlignment.Right;
        
        public Validation(Control parent, string message, TabAlignment alignment = TabAlignment.Right)
        {
            InitializeComponent();               
            _clParent = parent;
            // this.lblDisplay.Font = parent.Font;
            lblDisplay.Text = message;
             
            DataBindings.Add("Width", lblDisplay, "Width");
            DataBindings.Add("Height", parent.GetBounds(), "Height");
            //DataBindings.Add("Height", parent as Control, "Height");
            //Hide when form move.
            parent.FindForm().LocationChanged += new EventHandler(frmParent_LocationChanged);
            parent.FindForm().FormClosed += new FormClosedEventHandler(Validation_FormClosed);
            _aligment = alignment;
            GetLocation(parent as Control,_aligment);
        }

        void Validation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Reset();
        }

        protected override void DefWndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE = 0x21;
            const int MA_NOACTIVATE = 0x0003;

            switch (m.Msg)
            {
                case WM_MOUSEACTIVATE:
                    m.Result = (IntPtr)MA_NOACTIVATE;
                    return;
            }
            base.DefWndProc(ref m);
        }

        protected override bool ShowWithoutActivation => false;

        /// <summary>
        /// Clear event of parent form.
        /// </summary>
        public void Reset()
        {
            var frm = _clParent?.FindForm();
            if (frm!=null)
            {
                _clParent.FindForm().LocationChanged -= frmParent_LocationChanged;
                _clParent.FindForm().FormClosed -= Validation_FormClosed;
            }
            if (!IsDisposed)
            {
                Dispose();
            }
        }

        void frmParent_LocationChanged(object sender, EventArgs e)
        {
            Hide();
        }
        
        bool _show = false;
        /// <summary>
        /// Display validate operator.
        /// </summary>
        public new bool Show 
        {
            get
            {
                return _show;
            }
            set
            {
                
                if (value==true &&lblDisplay.Text.Trim()!="")
                {
                    GetLocation(_clParent as Control, _aligment);
                    if (!IsDisposed)
                    {
                        Show();
                        _clParent.Focus();
                    }
                }
                else
                {
                    Hide();
                }                
                _show = value;
            }
        }

        /// <summary>
        /// Set new location to validate operator.
        /// </summary>
        /// <param name="_cl"></param>
        private void GetLocation(Control parent, TabAlignment alignment)
        {
            if (alignment == TabAlignment.Right)
            {
                if (parent is TextBox)
                {
                    Location = Point.Add(parent.PointToScreen(new Point(-1, 0)), new Size(parent.Width + 2, -3));
                }
                else
                {
                    Location = Point.Add(parent.PointToScreen(new Point(0, 1)), new Size(parent.Width + 2, -2));
                }
            }
            else if (alignment == TabAlignment.Left)
            {
                Location = Point.Add(parent.PointToScreen(new Point(0, 0)), new Size(-lblDisplay.Width - 2, -3));
            }
            else if (alignment == TabAlignment.Bottom)
            {
                Location = Point.Add(parent.PointToScreen(new Point(-1, -1)), new Size(0, parent.Height + 2));
            }
            else // Top
            {
                Location = Point.Add(parent.PointToScreen(new Point(0, 0)), new Size(0, -parent.Height - 2));
            }
            this.Anchor = parent.Anchor;
        }

        /// <summary>
        /// Cancel close form when user closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Validation_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void lblDisplay_Click(object sender, EventArgs e)
        {
            Hide();
        }  
    }
}
