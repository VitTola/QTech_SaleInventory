using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class ProductPage : ExPage, IPage
    {
        public Product Model { get; set; }
        public ProductPage()
        {
            InitializeComponent();
            dgv.SetColumnHeaderDefaultStyle();

            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Product_Product_Update);
        }

        public async void AddNew()
        {
            var product = new Product();
            var dig = new frmProduct(product, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                Model = dig.Model;
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }

        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => ProductLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmProduct(Model, GeneralProcess.Update);

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

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => ProductLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Products));
                return;
            }

            Model = await btnRemove.RunAsync(() => ProductLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmProduct(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new ProductSearch()
            {
                Search = txtSearch.Text,
            };
            dgv.Rows.Clear();
            List<Category> categories = null;
            var result = await dgv.RunAsync(() => {
                var products = ProductLogic.Instance.SearchAsync(search);
                categories = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                return products;
            });
            if (result == null)
            {
                return;
            }
            if (result?.Any() ?? false)
            {
                result.ForEach(x => {
                    var row = newRow();
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colName.Name].Value = x.Name;
                    row.Cells[colCategory_.Name].Value = categories?.FirstOrDefault(c=>c.Id == x.CategoryId)?.Name ??string.Empty;
                    row.Cells[colImportPrice.Name].Value = x.ImportPrice;
                    row.Cells[colUnitPrice.Name].Value = x.UnitPrice;
                    row.Cells[colNote.Name].Value = x.Note;
                });
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
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => ProductLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmProduct(Model, GeneralProcess.View);
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

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow.Name].Value = (e.RowIndex + 1).ToString();
        }
    }
}
