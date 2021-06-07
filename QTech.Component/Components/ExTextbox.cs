using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("QuickSearch")]
    public partial class ExTextbox : UserControl
    {

        public event EventHandler QuickSearch;
        public event EventHandler CanceledSearch;
        private bool searched = false;
 
        public enum SearchModes
        {
            OnKeyUp,
            OnKeyReturn
        }

        public ExTextbox()
        {
            InitializeComponent();
            button.BackgroundImage = getIconSearch();
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

        [Browsable(true)]
        public string PlaceHolderText
        {
            get
            {
                return txtSearch.PlaceHolder;
            }
            set
            {
                if (value == null) return;
                txtSearch.PlaceHolder = value;
            }
        }

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
}
