using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class SelectListItemsDialog : ExDialog ,IPage
    {
        public ISearchModel SearchParameter { get; set; }
        Func<ISearchModel, List<DropDownItemModel>> _action;
        List<ItemAction> _itemActions;
        private List<DropDownItemModel> _preList = new List<DropDownItemModel>();
        bool _loadAll;
        
        public List<DropDownItemModel> SelectedItems { get; private set; }

        public bool MultiSelect { get; set; } = true;
        public bool AllowShowAll
        {
            get { return pagination.ShowAllOption; }
            set { pagination.ShowAllOption = value; }
        }

        public bool AllowNoSelected { get; set; } = false;

        public bool AllowTextAll
        {
            set { chkCheckAll_.Visible = value; }
        }

        public bool SelectAll
        {
            get { return chkCheckAll_.CheckState == CheckState.Checked; }
            set { chkCheckAll_.CheckState = value ? CheckState.Checked : CheckState.Unchecked; }
        }

        public bool ShowSelected { get; set; }

        // private List<object> _tempSelected = new List<object>();

        private ImageList _imgList;
        public SelectListItemsDialog(Func<ISearchModel,List<DropDownItemModel>> action, 
            ISearchModel searchParameter,
            List<DropDownItemModel> preList,
            List<ItemAction> itemActions,
            List<DropDownItemModel> seletedItems,
            bool loadAll =true, bool _showSelected = false)
        {
            InitializeComponent();
            dgv.DataBindingComplete += dgv_DataBindingComplete;
            _loadAll = loadAll;
            _action = action;
            _itemActions = itemActions??new List<ItemAction>();
            _itemActions?.Reverse();
            _preList = preList;
            SearchParameter = searchParameter;
            txtSearch.Text = searchParameter.Search;
            txtSearch.TextBox.SelectAll();
            txtSearch.RegisterKeyArrowDown(dgv);
            pnlRight.Visible = ShowSelected = _showSelected;
            SelectedItems = seletedItems?.Where(x=> !x.Id.Equals(0)).Select(x => new DropDownItemModel
            {
                Id = x.Id,
                Code = x.Code,
                DisplayText = x.DisplayText,
                ItemObject = x.ItemObject,
                Name = x.Name
            }).ToList();

            initEvent();
        }

        private void initEvent()
        {
            lblChoosed1.Text = Properties.Resources.Choosed;
            dgvSelected.ChangeCursor(Cursors.Hand, colRemove_);
            _imgList = new ImageList()
            {
                ImageSize = new Size(12, 12),
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = Color.Transparent,
            };
            _imgList.Images.Add(nameof(Properties.Resources.crossremove), Properties.Resources.crossremove);

            dgv.MultiSelect = dgvSelected.MultiSelect = MultiSelect;

            dgv.SelectionChanged += dgv_SelectionChanged;
            dgv.CellClick += dgv_CellClick;
            chkCheckAll_.Click += chkCheckAll__Click;
            chkCheckAll_.MouseDown += chkCheckAll__MouseDown;
            chkCheckAll_.CheckStateChanged += chkCheckAll__CheckStateChanged;
            lblChoosed_.Click += lblChoosed__Click;
            dgvSelected.CellClick += dgvSelected_CellClick;
            dgvSelected.KeyDown += dgvSelected_KeyDown;
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == colMark_.Index)
            {
                updateRowChecked(dgv.Rows[e.RowIndex]);
                updateSelectedList(dgv.Rows[e.RowIndex]);
                updateHeaderState();
                updateSelectCount();
            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    var check = (bool)(row.Cells[colMark_.Name].Value ?? false);
                    if (!check)
                    {
                        row.Cells[colMark_.Name].Value = true;
                        updateSelectedList(row);
                    }
                }
                updateHeaderState();
                updateSelectCount();
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            updateRowChecked(dgv.Rows[e.RowIndex]);
            updateSelectedList(dgv.Rows[e.RowIndex]);
            updateHeaderState();
            updateSelectCount();
        }
        
        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dr in dgv.Rows.OfType<DataGridViewRow>()
                .Where(x => ((DropDownItemModel)x.DataBoundItem).ItemObject is ItemAction))
            {
                dr.DefaultCellStyle.ForeColor = Color.Blue;
                dr.DefaultCellStyle.SelectionForeColor = Color.Blue;
            }

            var checkAll = chkCheckAll_.CheckState == CheckState.Checked;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var check = SelectedItems?.Any(x => x.Id.Equals(((DropDownItemModel)row.DataBoundItem).Id)) ?? false;
                row.Cells[colMark_.Name].Value = checkAll || check;
                if (check)
                {
                    SelectedItems.RemoveAll(x => x.Id.Equals(((DropDownItemModel)row.DataBoundItem).Id));
                }
                updateSelectedList(row);
            }
            updateSelectCount();

            //foreach (DataGridViewRow dr in dgv.Rows.OfType<DataGridViewRow>()
            //   .Where(x => ((DropDownItemModel)x.DataBoundItem).ItemObject ==null))
            //{
            //    dr.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            //}
        }

        private void chkCheckAll__MouseDown(object sender, MouseEventArgs e)
        {
            _lastState = chkCheckAll_.CheckState;
        }
        private CheckState _lastState = CheckState.Unchecked;
        private void chkCheckAll__Click(object sender, EventArgs e)
        {
            if (chkCheckAll_.CheckState == CheckState.Checked)
            {
                if (pagination.ShowAllOption)
                {
                    pagination.ShowAll();
                }
            }

            SelectedItems = new List<DropDownItemModel>();
            dgvSelected.Rows.Clear();
            dgv_DataBindingComplete(dgv, null);
        }

        private void chkCheckAll__CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void lblChoosed__Click(object sender, EventArgs e)
        {
            pnlRight.Visible = !pnlRight.Visible;
            ShowSelected = pnlRight.Visible;
        }

        private void dgvSelected_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == colRemove_.Index)
            {
                var row = dgvSelected.Rows[e.RowIndex];
                removedgvSelectedRows(row);
            }
        }

        private void dgvSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete &&  dgv.SelectedRows.Count >= 1)
            {
                var rows = dgvSelected.SelectedRows.OfType<DataGridViewRow>();
                foreach (var row in rows)
                {
                    removedgvSelectedRows(row);
                }
            }
        }

        private void updateRowChecked(DataGridViewRow row)
        {
            if (row == null)
            {
                return;
            }
            var check = (bool)(row.Cells[colMark_.Name].Value ?? false);
            row.Cells[colMark_.Name].Value = !check;
        }

        private void updateSelectedList(DataGridViewRow row, bool refreshSelectedGridView = true)
        {
            if (row == null)
            {
                return;
            }
            var check = (bool)(row.Cells[colMark_.Name].Value ?? false);
            var value = (DropDownItemModel)row.DataBoundItem;
            if (SelectedItems == null)
            {
                SelectedItems = new List<DropDownItemModel>();
            }
            if (check && !SelectedItems.Any(x=> x.Equals(value)))
            {
                SelectedItems.Add(value);
            }
            else if(!check && SelectedItems.Any(x=> x.Equals(value)))
            {
                SelectedItems.RemoveAll(x => x.Equals(value));
            }

            changeRowdgvSelected(row);
        }

        private void updateHeaderState()
        {
            if (SelectedItems?.Any() == true)
            {
                chkCheckAll_.CheckState = CheckState.Indeterminate;
            }
            else
            {
                chkCheckAll_.CheckState = CheckState.Unchecked;
            }
        }

        private void updateSelectCount()
        {
            if (chkCheckAll_.CheckState == CheckState.Checked)
            {
                lblChoosed_.Text = Properties.Resources.All;
            }
            else
            {
                lblChoosed_.Text = SelectedItems?.Where(x=> !x.Id.Equals(0))?.Count().ToString("N0") ?? "0";
            }
        }

        private void changeRowdgvSelected(DataGridViewRow row)
        {
            var check = (bool)(row.Cells[colMark_.Name].Value ?? false);
            var value = row.Cells[colId.Name].Value;

            var allSelectedRows = dgvSelected.Rows.OfType<DataGridViewRow>();
            if (check && !allSelectedRows.Any(x=> x.Cells[colSelectedId.Name].Value.Equals(value)))
            {
                adddgvSelectedRow((DropDownItemModel)row.DataBoundItem);
            }
            if (!check && allSelectedRows.Any(x => x.Cells[colSelectedId.Name].Value.Equals(value)))
            {
                dgvSelected.Rows.Remove(allSelectedRows.FirstOrDefault(x => x.Cells[colSelectedId.Name].Value.Equals(value)));
            }
        }

        private void adddgvSelectedRow(DropDownItemModel value)
        {
            var row = dgvSelected.Rows[dgvSelected.Rows.Add()];
            row.Cells[colSelectedId.Name].Value = value.Id;
            row.Cells[colSelectedName_.Name].Value = value.Name;
            row.Cells[colSelectedItemObject.Name].Value = value.ItemObject;
            row.Cells[colRemove_.Name].Value = _imgList.Images[nameof(Properties.Resources.crossremove)];
            if (dgvSelected.Visible)
            {
                dgvSelected.CurrentCell = row.Cells[colSelectedName_.Name];
            }
        }

        private void removedgvSelectedRows(DataGridViewRow row)
        {
            var value = row.Cells[colSelectedId.Name].Value;
            SelectedItems.RemoveAll(x => x.Id.Equals(value));

            updateHeaderState();
            updateSelectCount();
            var unchecks = dgv.Rows.OfType<DataGridViewRow>().Where(x => x.Cells[colId.Name].Value.Equals(value));
            foreach (var uncheck in unchecks)
            {
                uncheck.Cells[colMark_.Name].Value = false;
                if (uncheck.Selected)
                {
                    uncheck.Selected = false;
                }
            }
            dgvSelected.Rows.Remove(row);
        }

        private void save()
        {
            if (!AllowNoSelected && (this.SelectedItems == null || !this.SelectedItems.Any()))
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            _loadAll = false;
            pagination.Repaging();
            await Search();
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.End)
            {
                save();
            }
            else if (e.KeyCode == Keys.Space && (dgv.CurrentCell?.ColumnIndex ?? 0) != colMark_.Index)
            {
                var row = dgv.CurrentRow;
                if (row == null && row.Index == -1)
                {
                    return;
                }
                updateRowChecked(row);
                updateSelectedList(row);
                updateHeaderState();
                updateSelectCount();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            save();
        } 

        private void SelectItemsDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }
        
        public async Task Search()
        {
            SearchParameter.Search = txtSearch.Text.ToLower();
            if (_loadAll)
            {
                SearchParameter.Search = string.Empty; 
            }
            // Now not user

            // SearchParameter.Paging = pagination.Paging;

            pagination.ListModel = await dgv.RunAsync(() =>
            {
                var result = _action.Invoke(SearchParameter);
                if (pagination.Paging.CurrentPage == 1)
                {
                    //if (_itemForAll != null)
                    //{
                    //    result.Insert(0, _itemForAll);
                    //}
                    foreach (var item in _itemActions)
                    {
                        result.Insert(0, item.ToDropDownItemModel());
                    }
                }
                
                return result;
            });
            dgv.DataSource = pagination.ListModel;
        }

        private async void SelectItemsDialog_Load(object sender, EventArgs e)
        {
            if (_preList?.Any() == true)
            {
                //if (_itemForAll != null)
                //{
                //    _preList.Insert(0, _itemForAll);
                //}

                foreach (var item in _itemActions)
                {
                    _preList.Insert(0, new DropDownItemModel()
                    {
                        Id = 0,
                        DisplayText = item.ItemText,
                        Name = item.ItemText,
                        ItemObject = item
                    });
                }

                dgv.DataSource = _preList;
                dgv.RowSelected(colName.Name, txtSearch.Text);
            }
            else
            {
                if (chkCheckAll_.CheckState == CheckState.Checked && pagination.ShowAllOption)
                {
                    pagination.ForceShowAll();
                }
                else
                {
                    await Search();
                }
            }
            if (chkCheckAll_.CheckState != CheckState.Checked)
            {
                updateHeaderState();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Q))
            {
                BtnClose_Click(btnClose, EventArgs.Empty);
                return true;
            }
            else if (keyData == (Keys.Control | Keys.S))
            {
                save();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void AddNew() { }
        public void Remove() { }
        public void View() { }
        public void EditAsync() { }
    }
}
