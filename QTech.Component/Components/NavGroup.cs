using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace QTech.Component
{
    [Designer(typeof(NavGroupDesigner))]
    public partial class NavGroup : UserControl
    {
        public NavGroup()
        {
            InitializeComponent();
            BackgroundImageLayout = ImageLayout.Zoom;
        }

        public void AddChild(NavItem navItem)
        {
            navItem.Padding = new Padding() { Left = 10 };
            navItem.Margin = new Padding() { Left = 0 };

            navItem.Dock = DockStyle.Top;
            navItem.Height = 29;
            navItem.Text = " " + navItem.Text;
            navItem.TextAlign = ContentAlignment.MiddleCenter;
            Body.Controls.Add(navItem);
            Body.Height = navItem.Height * Body.Controls.Count;
        }

        protected override void OnLoad(EventArgs e)
        {
            _body.Visible = true;
            base.OnLoad(e);
            //ResourceHelper.ApplyResource(this);
        }
        [
        Category("Appearance"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content)
        ]
        public Panel Body
        {
            get { return _body; }
        }

        [Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
        ]
        public override string Text
        {
            get
            {
                return "   "+_title.Text;
            }
            set
            {
                _title.Text = value;
            }
        }
        [Browsable(true),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Collapse
        {
            get
            {
                return _body.Visible;
            }
            set
            {
                _body.Visible = value;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        private void body_VisibleChanged(object sender, EventArgs e)
        {
            if (Body.Height == 0 && Body.Controls.Count > 0)
            {
                _body.Height = 29 * Body.Controls.Count;
            }
            if (_body.Visible == true)
            {
                //_title.Image = Properties.Resources.down_arrow_in_small_circle_light;
                _title.Image = Properties.Resources.arrow_up_small;
            }
            else
            {
                //_title.Image = Properties.Resources.right_arrow_in_circular_button_light;
                _title.Image = Properties.Resources.arrow_down_small;
            }
            Height = _body.Visible ? _title.Height + _body.Height : _title.Height;
            _title.BackColor = Collapse ? Color.Silver : Color.LightGray;
        }

        private void _title_Click(object sender, EventArgs e)
        {
            Collapse = !_body.Visible;
        }

        private void _title_MouseLeave(object sender, EventArgs e)
        {
            _title.BackColor = this.Collapse ? Color.Silver : Color.LightGray;
        }

        private void _title_MouseEnter(object sender, EventArgs e)
        {
            _title.ForeColor = Color.Black;
            _title.BackColor = Color.Silver;
        }
    }

    public class NavGroupDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            if (Control is NavGroup)
            {
                EnableDesignMode(((NavGroup)Control).Body, "Body");
            }
        }
    }
   
}
