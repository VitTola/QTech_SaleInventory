using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QTech.Component
{
    [DefaultEvent("ValueChanged")]
    public partial class ExComboBox : UserControl
    {
        public Color SELECTED_COLOR = Color.White;
        public Color FORCE_COLOR = Color.Black;
        private IDropDownPanel dropDownPanel = null;
        private object value = null;
        private SearchModes searchMode = SearchModes.OnKeyUp;

        public ExComboBox()
        {
            InitializeComponent();
            lblDropDown.Image = GetSearchImage();
            txtSearch.Font = Font;
            AutoSize = false;
        }
        public event EventHandler ValueChanged;
        public event CancelEventHandler ValueChanging;

        public object Value
        {
            get
            {
                return value;
            }
            set
            {
                if (DropDownPanel != null)
                {
                    DropDownPanel.HideDropDown();
                }

                CancelEventArgs cea = new CancelEventArgs();

                OnValueChaning(cea);

                if (cea.Cancel)
                {
                    return;
                }
                this.value = value;


                if (DropDownPanel != null)
                {

                    Text = value == null ? "" : DropDownPanel.GetDisplayText(value);

                    // if cannot find text for selected value
                    // then mark it as not yet assinged to it.
                    if (Text == "")
                    {
                        this.value = null;
                    }
                }
                if (this.value == null)
                {
                    txtSearch.Enabled = true;
                    BackColor = Color.White;
                    txtSearch.BackColor = Color.White;
                    lblDropDown.Image = GetSearchImage();
                }
                else
                {
                    txtSearch.Enabled = false;
                    BackColor = SELECTED_COLOR;
                    txtSearch.BackColor = SELECTED_COLOR;
                    txtSearch.ForeColor = FORCE_COLOR;
                    lblDropDown.Image = Properties.Resources.icon_close;
                }

                OnValueChanged(new EventArgs());
            }
        }

        public IDropDownPanel DropDownPanel
        {
            get
            {
                return dropDownPanel;
            }
            set
            {
                dropDownPanel = value;
                if (dropDownPanel != null)
                {
                    dropDownPanel.SetDropDownParent(this);
                }
            }
        }

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

        private string lastSearchText = "";
        public string LastSearchText
        {
            get
            {
                return lastSearchText;
            }
        }

        public new bool Enabled
        {
            get
            {
                return txtSearch.Enabled;
            }
            set
            {
                txtSearch.Enabled = value;
                lblDropDown.Visible = value;
                txtSearch.BackColor = BackColor = value ? Color.White : Color.WhiteSmoke;
            }
        }

        public SearchModes SearchMode
        {
            get
            {
                return searchMode;
            }
            set
            {
                searchMode = value;
                lblDropDown.Image = GetSearchImage();
            }
        }

        private Image GetSearchImage()
        {
            return searchMode == SearchModes.OnKeyUp ? Properties.Resources.arrow_dropdown : Properties.Resources.icon_barcode;
        }

        public new void Focus()
        {
            txtSearch.SelectionStart = txtSearch.Text.Length;
            txtSearch.Focus();
        }

        protected virtual void OnValueChanged(EventArgs e)
        {
            if (ValueChanged != null)
            {
                ValueChanged(this, e);
            }
        }

        protected virtual void OnValueChaning(CancelEventArgs e)
        {
            if (ValueChanging != null)
            {
                ValueChanging(this, e);
            }
        }

        private void lblDropDown_Click(object sender, EventArgs e)
        {
            OnClick(e);
            if (value != null)
            {
                lblDropDown.Image = GetSearchImage();
                Value = null;
                Text = "";
                BackColor = Color.White;
                txtSearch.BackColor = Color.White;
                txtSearch.Enabled = true;
                txtSearch.Focus();
                txtSearch.SelectionStart = txtSearch.Text.Length;
            }
            else
            {
                if (DropDownPanel == null) {
                    return;
                }
                if (DropDownPanel.Visible())
                {
                    DropDownPanel.HideDropDown();
                }
                else
                {
                    DropDownPanel.Search(txtSearch.Text);
                    DropDownPanel.ShowDropDown();
                    txtSearch.Focus();
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (searchMode == SearchModes.OnKeyUp && e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                object selectedValue = DropDownPanel.GetSelectedValue();
                if (selectedValue == null)
                {
                    return;
                }
                // hide dropdown and select a value as expected!
                DropDownPanel.HideDropDown();
                Value = selectedValue;
            }
            if (e.KeyCode == Keys.B && e.Modifiers == Keys.Control)
            {
                SearchMode = searchMode == SearchModes.OnKeyUp ? SearchModes.OnKeyReturn : SearchModes.OnKeyUp;
                dropDownPanel.HideDropDown();
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }


        public enum SearchModes
        {
            OnKeyUp,
            OnKeyReturn
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            // do nothing if no dropdown panel.
            if (DropDownPanel == null)
            {
                return;
            }

            if (SearchMode == SearchModes.OnKeyReturn)
            {
                if (e.KeyCode == Keys.Return)
                {
                    lastSearchText = txtSearch.Text;
                    if (Text == "") return;
                    DropDownPanel.Search(txtSearch.Text);
                    object selectedValue = DropDownPanel.GetSelectedValue();
                    if (selectedValue != null)
                    {
                        Value = selectedValue;
                    }
                }
            }
            else
            {
                e.Handled = true;
                if (e.KeyCode == Keys.Escape)
                {
                    DropDownPanel.HideDropDown();
                }
                else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    DropDownPanel.Focus();
                }
                else if (e.KeyCode == Keys.Return)
                {
                    // implement on keydown
                    object selectedValue = DropDownPanel.GetSelectedValue();
                    if (selectedValue == null)
                    {
                        return;
                    }
                    DropDownPanel.HideDropDown();
                    Value = selectedValue;
                }
                else
                {
                    DropDownPanel.Search(txtSearch.Text);
                    txtSearch.Focus();
                }
            }
        }
    }


    public interface IDropDownPanel
    {
        void ShowDropDown();
        void HideDropDown();
        void Search(string value);
        string GetDisplayText(object value);
        object GetSelectedValue();
        void SetDropDownParent(ExComboBox parent);
        ExComboBox Parent { get; set; }
        void Focus();
        bool Visible();
    }

}
