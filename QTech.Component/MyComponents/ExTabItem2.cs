using System;                        
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("Click")]
    public partial class ExTabItem2 : UserControl
    {
        public ExTabItem2()
        {
            InitializeComponent();
        }

        bool selected = false;

        bool isTitle = false;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment TextAlignment
        {
            get
            {
                return lblCaption.TextAlign;
            }
            set
            {
                lblCaption.TextAlign = value;
            }
        }


        [Browsable(true)]
        public Image Image
        {
            get
            {
                return picBox.Image;
            }
            set
            {
                picBox.Image = value;
            }
        }

        [Browsable(true)]
        public bool Selected
        {
            set
            {
                selected = value;

                if (selected)
                {

                    if (Parent!=null)
                    {
                        foreach (Control c in Parent.Controls)
                        {
                            if (c is ExTabItem)
                            {
                                if (c != this)
                                {
                                    ((ExTabItem)c).Selected = false;
                                }
                            }
                        }
                    } 
                }
                else
                {
                    lblCaption.ForeColor = Color.Black;
                } 
            }
            get
            {
                return selected;
            }
        }

        [Browsable(true)]
        public bool IsTitle
        {
            get
            {
                return isTitle;
            }
            set
            {
                isTitle = value;
                Selected = false;
            }
        }

        private void lblCaption_MouseEnter(object sender, EventArgs e)
        {
            if (!selected && !isTitle)
            {
                lblCaption.ForeColor = Color.Firebrick;
            }
        }

      

        private void lblCaption_MouseLeave(object sender, EventArgs e)
        {
            if (!selected && !isTitle)
            {
                lblCaption.ForeColor = Color.Black;
            }
        } 
        
        private void lblCaption_Click(object sender, EventArgs e)
        {
            if (!isTitle)
            {
                Selected = true;
            }
            base.OnClick(e);
        }

        private void picBox_Click(object sender, EventArgs e)
        {
            if (!isTitle)
            {
                Selected = true;
            }
            base.OnClick(e);
        }

        private void lblCaption_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        private void lblCaption_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }
    }
}
