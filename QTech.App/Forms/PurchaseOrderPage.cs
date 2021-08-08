using QTech.Base;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using System.Collections.Generic;
using System.Drawing;
using QTech.Base.Models;
using System.ComponentModel;

namespace QTech.Forms
{
    public partial class PurchaseOrderPage : ExPage, IPage
    {

        public PurchaseOrderPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }
        public PurchaseOrder Model { get; set; }

        private void Bind()
        {
        }
        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 28;
            dgv.BackgroundColor = System.Drawing.Color.White;

            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
        }


        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }


        public async void AddNew()
        {
            Model = new PurchaseOrder();
            var dig = new frmPurchaseOrder(Model, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => PurchaseOrderLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmPurchaseOrder(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }

        public async void Reload()
        {
            await Search();
        }

        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => PurchaseOrderLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.PurchaseOrderNo));
                return;
            }

            Model = await btnRemove.RunAsync(() => PurchaseOrderLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmPurchaseOrder(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            dgv.Rows.Clear();
            var search = new PurchaseOrderSearch()
            {
                Search = txtSearch.Text,
                Paging = pagination.Paging
            };
            var Customers = new List<Customer>();
            pagination.ListModel = await dgv.RunAsync(() =>
             {
                 var res = PurchaseOrderLogic.Instance.SearchAsync(search);
                 var CustomerIds = res.Select(x => x.CustomerId).ToList();
                 Customers = CustomerLogic.Instance.GetCustomersById(CustomerIds);
                 return res;
             });
            if (pagination.ListModel != null)
            {
                List<PurchaseOrder> lists = pagination.ListModel;
                lists.ForEach(x =>
                {
                    var row = _newRow(false);
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colName_.Name].Value = x.Name;
                    row.Cells[colCustomer.Name].Value = Customers?.FirstOrDefault(z => z.Id == x.CustomerId)?.Name;
                    row.Cells[colNote_.Name].Value = x.Note;
                    row.Cells[colRowDate.Name].Value = x.RowDate;
                });
            }
            dgv.Sort(dgv.Columns[colRowDate.Name], ListSortDirection.Descending);
        }
        private DataGridViewRow _newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            //row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => PurchaseOrderLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmPurchaseOrder(Model, GeneralProcess.View);
            dig.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EditAsync();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View();
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow.Name].Value = (e.RowIndex + 1).ToString();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
