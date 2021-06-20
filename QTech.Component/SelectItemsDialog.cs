using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QTech.Component
{
    public partial class SelectItemsDialog : ExDialog, IPage
    {

        public QTech.Base.BaseModels.ISearchModel SearchParameter { get; set; }
        Func<QTech.Base.BaseModels.ISearchModel, List<DropDownItemModel>> _action;
        DropDownItemModel _itemForAll;
        List<ItemAction> _itemActions;
        private List<DropDownItemModel> _preList = new List<DropDownItemModel>();
        public List<DropDownItemModel> SelectedItems { get; private set; }
        bool _loadAll;
        public SelectItemsDialog(Func<QTech.Base.BaseModels.ISearchModel, List<DropDownItemModel>> action,
            QTech.Base.BaseModels.ISearchModel searchParameter,
            List<DropDownItemModel> preList,
            List<ItemAction> itemActions,
            DropDownItemModel itemForAll,
            bool loadAll = true,
            bool showAll = false)
        {
            InitializeComponent();
            dgv.DataBindingComplete += dgv_DataBindingComplete;
            _loadAll = loadAll;
            _action = action;
            _itemActions = itemActions ?? new List<ItemAction>();
            _itemForAll = itemForAll;
            _itemActions?.Reverse();
            _preList = preList;
            SearchParameter = searchParameter;
            txtSearch.Text = searchParameter.Search;
            txtSearch.TextBox.SelectAll();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += TxtSearch_QuickSearch;

        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dr in dgv.Rows.OfType<DataGridViewRow>()
                .Where(x => ((DropDownItemModel)x.DataBoundItem).ItemObject is ItemAction))
            {
                dr.DefaultCellStyle.ForeColor = Color.Blue;
                dr.DefaultCellStyle.SelectionForeColor = Color.Blue;
            }

            //foreach (DataGridViewRow dr in dgv.Rows.OfType<DataGridViewRow>()
            //   .Where(x => ((DropDownItemModel)x.DataBoundItem).ItemObject ==null))
            //{
            //    dr.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            //}
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
            selectedItem();
        }
        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectedItem();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            selectedItem();
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
            var source = await dgv.RunAsync(() =>
            {
                var result = _action.Invoke(SearchParameter);

                return result;
            });

            if (source?.Any() == true)
            {
                if (_itemForAll != null)
                {
                    source.Insert(0, _itemForAll);
                }

                foreach (var item in _itemActions)
                {
                    source.Insert(0, new DropDownItemModel()
                    {
                        Id = 0,
                        DisplayText = item.ItemText,
                        Name = item.ItemText,
                        ItemObject = item
                    });
                }

                dgv.DataSource = source;
                dgv.RowSelected(colName.Name, txtSearch.Text);
            }
        }

        private async void SelectItemsDialog_Load(object sender, EventArgs e)
        {
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
