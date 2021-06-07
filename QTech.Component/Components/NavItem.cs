using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QTech.Component
{
    public class NavItem : Button
    {
        private Color _colorNonSelected = Color.Black;
        private Color _colorSelected = Color.Black;
        private Color _colorBgSelected = Color.FromArgb(30, 33, 39);
        private Font _defaultFont = new Font(new FontFamily("Khmer OS System"), 8);

        [Browsable(true)]
        public Color NonSelected { get { return _colorNonSelected; } set { _colorNonSelected = value; } }

        [Browsable(true)]
        public Color Selected { get { return _colorSelected; } set { _colorSelected = value; } }

        public NavItem()
        {
            SetStyle(ControlStyles.Selectable, false);
            Cursor = Cursors.Hand;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            AutoSize = false;
            AutoEllipsis = true;
            
            ForeColor = _colorNonSelected;
            Text = "  " + Text;
            ImageAlign = ContentAlignment.MiddleLeft;
            TextImageRelation = TextImageRelation.ImageBeforeText;
            TextAlign = ContentAlignment.MiddleCenter;
            Font = _defaultFont;
        }

        protected override bool ShowFocusCues => false;

        private bool _selected = false;
        [DefaultValue(false)]
        [Browsable(true)]
        public bool _Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (_isCheck == false)
                {
                    _selected = _isCheck;
                }
                if (value)
                {
                    ForeColor = _colorSelected;
                    BackColor = ColorBgSelected;
                    if (Parent != null)
                    {
                        if (Parent.Controls.Count == 1)
                        {
                            Control ctrlParent = Parent;
                            loopDisableInParent(ctrlParent);
                        }
                        else if (Parent.Controls.Count > 1)
                        {
                            foreach (Control item in Parent.Controls.OfType<Control>().Where(x => x != this))
                            {
                                disableItem(item);
                                Control ctrlParent = Parent;
                                loopDisableInParent(ctrlParent);
                            }
                        }
                            
                    }
                }
            }
        }

        private void loopDisableInParent(Control ctrlParent)
        {
            while ((ctrlParent = ctrlParent.Parent) != null)
            {
                if (ctrlParent is NavGroup)
                {
                    foreach (var k in ctrlParent.Parent.Controls.OfType<Control>().Where(x => x != this))
                    {
                        disableItem(k);
                    }
                    break;
                }
            }
        }

        void disableItem(Control c)
        {
            if (c is NavItem)
            {
                c.ForeColor = ((NavItem)c)._colorNonSelected;
                c.BackColor = Parent.BackColor;
                ((NavItem)c)._Selected = false;
            }

            else if (c is NavGroup)
            {
                var g = ((NavGroup)c)._title;
                //disableItem(g);
                //g.BackColor = Color.Silver;
                /*
                 * Control the same lv.
                 */
                foreach (var item in g.Parent.Controls.OfType<NavGroup>().Where(x => x._title != this && x._title._Selected))
                {
                    disableItem(g);
                }
                foreach (var item in ((NavGroup)c).Body.Controls.OfType<NavItem>().Where(x => x != this && x._Selected))
                {
                    disableItem(item);

                }
            }
        }
        private bool _isCheck = true;
        [DefaultValue(true)]
        [Browsable(true)]
        public bool _IsCheck { get { return _isCheck; } set { _isCheck = value; } }

        protected override void OnClick(EventArgs e)
        {
            _Selected = true;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //ForeColor = _colorSelected;
            ForeColor = HoverColor;
            BackColor = Color.White;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (!_Selected)
            {
                //ForeColor = _colorNonSelected;
                ForeColor = LeaveColor;
                BackColor = Parent.BackColor;
            }
            else
            {
                ForeColor = _colorBgSelected;
                BackColor = ColorBgSelected;
            }
            base.OnMouseLeave(e);
        }

        public Color HoverColor { get; set; } = Color.Red;
        public Color LeaveColor { get; set; } = Color.Black;
        public Color ColorBgSelected { get; set; } = Color.FromArgb(179, 179, 179);
    }
}
