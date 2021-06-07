using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("QuickSearch")]
    public partial class ExTextboxIconPattern : UserControl
    {
        private ImageList _imageList = new ImageList();
        public event EventHandler QuickSearch;
        public event EventHandler CanceledSearch;
        public event EventHandler PatternChanged;
        private bool searched = false;

        private ToolStripItem _selectedMenuPattern;
        public ToolStripItem SelectedMenuPattern
        {
            get
            {
                return _selectedMenuPattern;
            }
            set
            {
                if (value != null)
                {
                    if (value is ToolStripSeparator) return;
                    _selectedMenuPattern = value;
                    imgPattern.Image = new Bitmap(_selectedMenuPattern.Image, new Size(13, 13));
                    imgPattern.Visible = true;
                    txtSearch.PlaceHolder = _selectedMenuPattern.Text;
                    txtSearch.Focus();
                    if (PatternChanged != null)
                    {
                        debounceTimer.Debounce(300, p => PatternChanged(this, new EventArgs()));
                    }
                }
                else
                {
                    imgPattern.Visible = false;
                    imgPattern.Image = null;
                }
            }
        }

        public object SelectedPattern
        {
            get => SelectedMenuPattern?.Tag;
        }


        private Size _sizeIcon = new Size(16, 16);
        public Size SizeIcon
        {
            get
            {
                return _sizeIcon;
            }
            set
            {
                _sizeIcon = value;
                _imageList = new ImageList();
                _imageList.ColorDepth = ColorDepth.Depth32Bit;
                _imageList.ImageSize = value;
                _imageList.Images.Add(nameof(Properties.Resources.icon_search), Properties.Resources.icon_search);
                _imageList.Images.Add(nameof(Properties.Resources.icon_close), Properties.Resources.icon_close);
                button.BackgroundImage = getIconSearch();
            }
        }


        public bool ReadOnly
        {
            get => txtSearch.ReadOnly; set
            {
                txtSearch.ReadOnly = value;
                panel1.BackColor = txtSearch.BackColor;
                button.BackColor = txtSearch.BackColor;
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                txtSearch.Font = value;
                menuPattern.Font = value;
            }
        }

        public enum SearchModes
        {
            OnKeyUp,
            OnKeyReturn
        }

        public ExTextboxIconPattern()
        {
            InitializeComponent();
            button.BackgroundImage = getIconSearch();
            imgPattern.ErrorImage = null;
            imgPattern.InitialImage = null;
            imgPattern.Visible = false;
            imgPattern.Click += imgPattern_Click;
            menuPattern.ItemClicked += menuPattern_ItemClicked;
        }

        private void imgPattern_Click(object sender, EventArgs e)
        {
            showMenuPattern();
        }

        private void menuPattern_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SelectedMenuPattern = e.ClickedItem;
        }

        public void AddSeperator()
        {
            menuPattern.Items.Add(new ToolStripSeparator());
        }


        public void AddMenuPattern(string key, object pattern, Image image, string description = "", Keys shortcutkeys = Keys.None, EventHandler onClick = null)
        {
            var item = new ToolStripMenuItem(description, image, onClick);
            menuPattern.Items.Add(item);

            item.Name = key;
            item.Tag = pattern;
            if (shortcutkeys != Keys.None)
            {
                item.ShowShortcutKeys = true;
                item.ShortcutKeys = shortcutkeys;
            }
        }

        public void ClearMenuPatter()
        {
            menuPattern.Items.Clear();
        }
        public void ShowMenuPattern(object pattern)
        {
            var menuItem = menuPattern.Items.OfType<ToolStripMenuItem>().FirstOrDefault(x => x.Tag.Equals(pattern));
            if (menuItem != null)
            {
                SelectedMenuPattern = menuItem;
            }
        }


        private SearchModes searchMode = SearchModes.OnKeyUp;
        public SearchModes SearchMode
        {
            get
            {
                return searchMode;
            }
            set
            {
                searchMode = value;
                button.BackgroundImage = getIconSearch();
            }
        }

        private DebounceDispatcher debounceTimer = new DebounceDispatcher();
        protected void OnSearch()
        {
            searched = true;
            button.BackgroundImage = _imageList.Images[nameof(Properties.Resources.icon_close)];
            if (txtSearch.Text == "")
            {
                button.BackgroundImage = getIconSearch();
                searched = false;
            }
            if (QuickSearch != null)
            {
                debounceTimer.Debounce(300, p => QuickSearch(this, new EventArgs()));
            }
        }


        private void button_Click(object sender, EventArgs e)
        {
            if (SearchMode == SearchModes.OnKeyUp)
            {
                if (searched)
                {
                    CancelSearch(true);
                }
                else
                {
                    txtSearch.Text = "";
                    AcceptSearch(true);
                }
            }
            else
            {
                if (searched)
                {
                    CancelSearch(true);
                }
                else
                {
                    AcceptSearch(true);
                }
            }
        }

        public PlaceholderTextBox TextBox
        {
            get
            {
                return txtSearch;
            }
        }

        public ContextMenuStrip MenuPattern => menuPattern;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public override string Text
        {
            get
            {
                return txtSearch.Text;
            }
            set
            {
                txtSearch.Text = value;
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }

        public void AcceptSearch(bool raiseEvent)
        {
            searched = true;
            button.BackgroundImage = _imageList.Images[nameof(Properties.Resources.icon_close)];
            if (raiseEvent)
            {
                OnSearch();
            }
        }

        public void CancelSearch(bool raiseEvent)
        {
            searched = false;
            txtSearch.Text = "";
            button.BackgroundImage = getIconSearch();
            txtSearch.Focus();
            button.BackgroundImage = _imageList.Images[nameof(Properties.Resources.icon_search)];
            if (QuickSearch != null && SearchMode == SearchModes.OnKeyUp)
            {
                QuickSearch(this, EventArgs.Empty);
            }
            if (CanceledSearch != null)
            {
                CanceledSearch(this, EventArgs.Empty);
            }
        }

        private Image getIconSearch()
        {
            return SearchMode == SearchModes.OnKeyUp ? _imageList.Images[nameof(Properties.Resources.icon_search)]
                : _imageList.Images[nameof(Properties.Resources.icon_search)];
        }

        public new void Focus()
        {
            if (txtSearch.Enabled)
            {
                txtSearch.Focus();
            }
        }

        public new bool Enabled
        {
            set
            {
                base.Enabled = value;
                BackColor = value ? Color.White : Color.WhiteSmoke;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
            if (e.KeyCode == Keys.Enter)
            {
                if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
                {
                    SearchMode = searchMode == SearchModes.OnKeyUp
                        ? SearchModes.OnKeyReturn
                        : SearchModes.OnKeyUp;
                }
                if (SearchMode == SearchModes.OnKeyReturn)
                {
                    if (e.KeyCode == Keys.Return)
                    {
                        AcceptSearch(true);
                    }

                }
            }
            //else if (e.KeyCode == Keys.Back && string.IsNullOrEmpty(txtSearch.Text.Trim()))
            //{
            //    hideIconPattern();
            //}
            else if (e.KeyCode == Keys.Escape)
            {
                CancelSearch(true);
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //if (SearchMode == SearchModes.OnKeyUp)
            //{
            //    if (e.KeyCode == Keys.Escape)
            //    {
            //        this.CancelSearch(true);
            //    }
            //    else
            //    {
            //        this.searched = true;
            //        this.OnSearch();
            //    }
            //} 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            //{
            //    txtSearch.Text = txtSearch.Text.Trim();
            //    //hideIconPattern();
            //    showMenuPattern();
            //}
        }

        private void hideIconPattern()
        {
            imgPattern.Visible = false;
            imgPattern.Image = null;
        }

        private void showMenuPattern()
        {
            var location = this.ClientRectangle.Location;
            location.Y = this.Height;
            location.X -= 1;
            menuPattern.Show(this, location, ToolStripDropDownDirection.BelowRight);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            panel1.BackColor = txtSearch.BackColor;
            button.BackColor = txtSearch.BackColor;
        }

        public void SetDropDownFont(Font font)
        {
            menuPattern.Font = font;
        }
    }
}
