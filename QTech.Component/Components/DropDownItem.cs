using EasyServer.Domain.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QTech.Component
{
	public partial class DropDownItem : UserControl, IDropDownPanel
    {
        List<DropDownItemModel> _listObject;

        public object ItemObject
        {
            get
            {
                if (dropDownParent.Value == null)
                {
                    return null;
                }
                else
                {
                    return _listObject.FirstOrDefault(x=>x.Id == dropDownParent.Value).ItemObject;
                }
            }
        }
		public DropDownItemModel ItemModel
		{
			get
			{
				if (dropDownParent.Value == null)
				{
					return null;
				}
				else
				{

					return _listObject.FirstOrDefault(x => x.Id == dropDownParent.Value);
				}
			}
		}

		public int DisplayRow { get; set; } = 10;

        ExComboBox IDropDownPanel.Parent
        {
            get { return dropDownParent; }

            set { dropDownParent = value; }
        }

        public Popup Popup = null;
        private ExComboBox dropDownParent = null;
        private string text = "";

        public DropDownItem(IEnumerable<DropDownItemModel> list):this(list.ToList())
        {

        }


        public DropDownItem(List<DropDownItemModel> list)
        {
            InitializeComponent();
            dgv.ApplyDefaultStyle();
            dgv.ColumnHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Popup = new Popup(this);
            Popup.AutoClose = false;

            _listObject = list;
        }
        public DropDownItem(List<DropDownItemModel> list, string all):this(list)
        {
            _listObject.Insert(0, new DropDownItemModel() { Id = 0, DisplayText = all, Name = all, ItemObject = null });
        }

        public void ShowDropDown()
        {
            var h = (dgv.Rows.Count > DisplayRow ? DisplayRow : dgv.Rows.Count)
                    * dgv.RowTemplate.Height;
            if (h > 0) h = h + 2;
            Popup.Height = h;
            Popup.Show(dropDownParent);
            Popup.Visible = true;
        }

        public void HideDropDown()
        {
            Popup.Visible = false;
            Popup.Close();
        }

        public void Search(string search)
        {
            search = search ?? "";
            text = search.ToLower();
            //if (string.IsNullOrEmpty(search) || _listObject == null)
            //{
            //    this.HideDropDown();
            //    return;
            //}
            if (_listObject==null)
            {
                HideDropDown();
                return;
            }
            dgv.DataSource = (from o in _listObject
                                  where (o.Name + " ").ToLower().Contains(search.ToLower())
                                  select new
                                  {
                                      o.Id,
                                      o.Name,
                                  }).ToList();
            ShowDropDown();
        }


        public string GetDisplayText(object value)
        {
            if (value == null)
            {
                return "";
            }
            //var obj = _listObject.FirstOrDefault(x => x.Id == value);
            var obj = _listObject.FirstOrDefault(x => x.Id.Equals(value));
            return obj == null ? "" : obj.DisplayText;
        }

        public object GetSelectedValue()
        {
            return dgv.SelectedRows.Count > 0 ? dgv.SelectedRows[0].Cells[Id.Name].Value : null;
        }

        public void SetDropDownParent(ExComboBox parent)
        {
            var width = parent.Width;
            // in case it's datagridview cell, then get the size from editingcontrol's parent.
            if (parent is IDataGridViewEditingControl)
            {
                width = parent.Width < 260 ? 260 : parent.Width;
            }
            dropDownParent = parent;
            Popup.Size = new Size(width,150);
        }

        public new void Focus()
        {
            dgv.Focus();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                dropDownParent.Value = dgv.SelectedRows[0].Cells[Id.Name].Value;
                dropDownParent.Focus();
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                e.Handled = true;
                if (dgv.SelectedRows.Count > 0)
                {
                    HideDropDown();
                    dropDownParent.Value = GetSelectedValue();
                    dropDownParent.Focus();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (dgv.SelectedRows.Count>0&& dgv.SelectedRows[0].Index == 0)
                {
                    dropDownParent.Focus();
                    HideDropDown();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                HideDropDown();
            }
        }

        bool IDropDownPanel.Visible()
        {
            return Popup.Visible;
        }

        //public class DropDownItemModel
        //{
        //    public object Id { get; set; }
        //    public string DisplayText { get; set; }
        //    public string Name { get; set; }
        //    public object ItemObject { get; set; }
        //}

    }
}
