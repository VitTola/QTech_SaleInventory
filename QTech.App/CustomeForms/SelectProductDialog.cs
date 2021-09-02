using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Component
{
    public partial class SelectProductDialog : ExDialog, IPage, ISearchForm
    {

        public QTech.Base.BaseModels.ISearchModel SearchParameter { get; set; }
        Func<QTech.Base.BaseModels.ISearchModel, List<DropDownItemModel>> _action;
        DropDownItemModel _itemForAll;
        List<ItemAction> _itemActions = new List<ItemAction>();
        private List<DropDownItemModel> _preList = new List<DropDownItemModel>();
        public List<DropDownItemModel> SelectedItems { get; private set; }
        public dynamic SelectedObject { get; set; }
        List<Category> categories = new List<Category>();
        private bool AllProduct;

        bool _loadAll;
        public SelectProductDialog(QTech.Base.BaseModels.ISearchModel searchParameter, bool _allProduct = false)
        {
            InitializeComponent();
            dgv.DataBindingComplete += dgv_DataBindingComplete;
            SearchParameter = searchParameter;
            txtSearch.Text = searchParameter.Search;
            txtSearch.TextBox.SelectAll();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += TxtSearch_QuickSearch;
            AllProduct = _allProduct;

        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dr in dgv.Rows.OfType<DataGridViewRow>()
                .Where(x => ((DropDownItemModel)x.DataBoundItem).ItemObject is ItemAction))
            {
                dr.DefaultCellStyle.ForeColor = Color.Blue;
                dr.DefaultCellStyle.SelectionForeColor = Color.Blue;
            }
        }

        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            _loadAll = false;
            await Search();
        }

        void selectedItem()
        {
            if (dgv.SelectedRows.Count > 0)
            {
                SelectedItems = dgv.SelectedRows.OfType<DataGridViewRow>().Select(x => (DropDownItemModel)x.DataBoundItem).ToList();
                DialogResult = DialogResult.OK;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Selected();
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Selected();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Selected();

        }

        private void SelectItemsDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        public void AddNew()
        {

        }

        public void Remove()
        {

        }

        public void View()
        {

        }

        public void EditAsync()
        {
        }

        private async void TxtSearch_QuickSearch(object sender, EventArgs e)
        {
            _loadAll = false;
            await Search();
        }

        public async Task Search()
        {
            SearchParameter.Search = txtSearch.Text;
            var search = SearchParameter as ProductSearch;
            var products = await dgv.RunAsync(() =>
            {
                categories = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                var result = ProductLogic.Instance.SearchAsync(search);
                return result;
            });
            
            if (products != null)
            {
                dgv.Rows.Clear();
                if (AllProduct)
                {
                    products.Insert(0,new Product
                    {
                        Id = 0,
                        CategoryId = 0,
                        Name = $"{BaseResource.Products} {BaseResource.All_}"
                    }
                        );
                }
                products.ForEach(x=> {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    var category = categories.FirstOrDefault(c => c.Id == x.CategoryId)?.Name ?? string.Empty;
                    row.Cells[colName.Name].Value = $"{x.Name}";
                    row.Cells[colObject.Name].Value = x;
                    row.Cells[colCategory_.Name].Value = category;
                });
            }
            if (dgv.RowCount > 0)
            {
                if (!string.IsNullOrEmpty(txtSearch.Text))
                {
                    dgv.RowSelected(colName.Name, txtSearch.Text);
                }
                else
                {
                    dgv.Focus();
                    dgv.RowSelected(0);
                }
            }
        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        private async void SelectItemsDialog_Load(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            if (_preList?.Any() == true)
            {
                if (_itemForAll != null)
                {
                    _preList.Insert(0, _itemForAll);
                }

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
                await Search();
            }

        }
        private async void Selected()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }
            SelectedObject = dgv.SelectedRows[0].Cells[colObject.Name].Value;
         
            if (SelectedObject != null)
            {
                DialogResult = DialogResult.OK;
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
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
