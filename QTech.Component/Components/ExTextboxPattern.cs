using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;

namespace QTech.Component
{
    [DefaultEvent("QuickSearch")]
    public partial class ExTextboxPattern : UserControl
    {

        public event EventHandler QuickSearch;
        public event EventHandler CanceledSearch;
        private bool searched = false;
 
        public enum SearchModes
        {
            OnKeyUp,
            OnKeyReturn
        }

        public ExTextboxPattern()
        {
            InitializeComponent();
            button.BackgroundImage = getIconSearch();
            menuPattern.ItemClicked += menuPattern_ItemClicked;
            txtSearch.TextChanged += (sender, e) => { Text = txtSearch.Text; };
        }
        
        public void AddPattern(string pattern,Image image,string description="")
        {
            var item = menuPattern.Items.Add(image);
            item.ToolTipText = description;
            item.Tag = pattern;
            item.Text = $"{pattern} {description}"; 
        }
        public void ClearPatter()
        {
            menuPattern.Items.Clear();
        }


        private void changeFormat()
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                var location = this.ClientRectangle.Location;
                location.Y = this.Height;
                menuPattern.Show(this, location, ToolStripDropDownDirection.BelowRight);
            }
            int originalIndex = txtSearch.SelectionStart;
            int originalLength = txtSearch.SelectionLength;
            var originalColor = Color.Black;
            var items = menuPattern.Items.OfType<ToolStripMenuItem>().Select(x => x.Tag.ToString());
            if (items.Any())
            {
                string keywords = $@"\b({string.Join("|", items.ToArray())})\b";
                MatchCollection keywordMatches = Regex.Matches(txtSearch.Text, keywords);

                // removes any previous highlighting (so modified words won't remain highlighted)
                txtSearch.SelectionStart = 0;
                txtSearch.SelectionLength = txtSearch.Text.Length;
                txtSearch.SelectionColor = originalColor;
                txtSearch.SelectionFont = new Font(txtSearch.Font, FontStyle.Regular);
                foreach (Match m in keywordMatches)
                {
                    txtSearch.SelectionStart = m.Index;
                    txtSearch.SelectionLength = m.Length;
                    txtSearch.SelectionColor = SystemColors.Highlight;
                    txtSearch.SelectionFont = new Font(txtSearch.Font, FontStyle.Bold);
                }

                //txtSearch.Select(originalIndex, originalLength);
            }
            // getting strings
            string strings = "\".+?\"";
            MatchCollection stringMatches = Regex.Matches(txtSearch.Text, strings);

            txtSearch.SelectionStart = originalIndex;
            txtSearch.SelectionLength = originalLength;
            txtSearch.SelectionColor = originalColor;
            txtSearch.SelectionFont = new Font(txtSearch.Font, FontStyle.Regular);
            txtSearch.Focus();
        }
        private void menuPattern_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Text = e.ClickedItem.Tag.ToString();
            txtSearch.SelectionStart = txtSearch.TextLength;
            txtSearch.Focus();
        }

        private SearchModes searchMode = SearchModes.OnKeyUp;
        public SearchModes SearchMode
        {
            get { 
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
            button.BackgroundImage = global::QTech.Component.Properties.Resources.icon_close;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                button.BackgroundImage = getIconSearch();
                searched = false;
            }

            debounceTimer.Debounce(200, p =>
            {

                QuickSearch?.Invoke(this, EventArgs.Empty);
            });

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
 
        public ExRichTextBox TextBox
        {
            get
            {
                return txtSearch;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        public ContextMenuStrip MenuPattern { get { return menuPattern; }}

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //[Browsable(true)]
        //public override string Text
        //{
        //    get
        //    {
        //        return txtSearch.Text;
        //    }
        //    set
        //    {
        //        txtSearch.Text = value;
        //    }
        //} 

        [Bindable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Browsable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get { return base.Text; }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    if (txtSearch.Text!=value)
                    {
                        txtSearch.Text = value;
                    }
                    changeFormat();
                    this.Invalidate();
                }
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
                txtSearch.BackColor = value;
            }
        }

        public void AcceptSearch(bool raiseEvent)
        { 
            searched = true;
            button.BackgroundImage = global::QTech.Component.Properties.Resources.icon_close;
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
            button.BackgroundImage = global::QTech.Component.Properties.Resources.icon_search;
            if (QuickSearch != null  && SearchMode == SearchModes.OnKeyUp)
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
            return SearchMode == SearchModes.OnKeyUp ? QTech.Component.Properties.Resources.icon_search : QTech.Component.Properties.Resources.icon_search;
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
            //txtSearch_TextChanged(txtSearch, EventArgs.Empty);
             
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
    }

    public class ExRichTextBox : RichTextBox
    {
        public ExRichTextBox()
        {
            Selectable = true;
        }
        const int WM_SETFOCUS = 0x0007;
        const int WM_KILLFOCUS = 0x0008;

        ///<summary>
        /// Enables or disables selection highlight. 
        /// If you set `Selectable` to `false` then the selection highlight
        /// will be disabled. 
        /// It's enabled by default.
        ///</summary>
        [DefaultValue(true)]
        public bool Selectable { get; set; }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SETFOCUS && !Selectable)
                m.Msg = WM_KILLFOCUS;

            base.WndProc(ref m);
        }
    }
}
