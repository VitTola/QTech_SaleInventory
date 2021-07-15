using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmCustomer : ExDialog, IDialog
    {
        public Customer Model = new Customer();
        List<Site> sites = new List<Site>();
        List<Site> _removeSites = new List<Site>();
        List<CustomerPrice> _customerPrices;

        public frmCustomer(Customer model, GeneralProcess flage)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flage;

            Bind();
            InitEvent();
        }
        public GeneralProcess Flag { get; set; }
        public void Bind()
        {
            Read();
        }
        public void InitEvent()
        {
            this.MaximizeBox = false;
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.Customer);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtPhone.RegisterEnglishInput();

            dgv.ReadOnly = false;
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;
            dgv.RegisterEnglishInputColumns(colPhone);
            dgv.RegisterEnglishInputColumns(colPhone);
            dgv.RegisterPrimaryInputColumns(colName);
            
            tabMain.SelectedIndexChanged += TabMain_SelectedIndexChanged;
            dgvGoods.EditingControlShowing += DgvGoods_EditingControlShowing;
            dgvGoods.RegisterEnglishInputColumns(colSalePrice);
            dgvGoods.ReadOnly = false;
            dgvGoods.AllowRowNotFound = false;
            colGoodName.ReadOnly = true;
            colCategory_.ReadOnly = true;
            dgvGoods.EditMode = DataGridViewEditMode.EditOnEnter;
            if (Flag == GeneralProcess.Add)
            {
                tabMain.Controls.Remove(tabSetPrice);
            }
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            dgv.EditColumnIcon(colName,colPhone);
            dgvGoods.EditColumnIcon(colGoodName,colSalePrice);

        }
        private void DgvGoods_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvGoods.CurrentCell.ColumnIndex == colSalePrice.Index)
            {
                if (e.Control is TextBox txt)
                {
                    txt.KeyPress += (o, ee) => { txt.validCurrency(sender, ee); };
                }
            }
        }
        private async void TabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.SelectedTab.Equals(tabSetPrice))
            {
                var categorys = new List<Category>();
                dgvGoods.Rows.Clear();
                var Products = await dgvGoods.RunAsync(() =>
                {
                    var search = new ProductSearch();
                    var prods = ProductLogic.Instance.SearchAsync(search);
                    _customerPrices = CustomerPriceLogic.Instance.GetCustomerPriceByCustomerId(Model.Id);
                    categorys = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                    return prods;
                });
                foreach (var product in Products)
                {
                    var row = _newRow(false);
                    row.Cells[colProductId.Name].Value = product.Id;
                    row.Cells[colIdd.Name].Value = _customerPrices?.FirstOrDefault(x => x.ProductId == product.Id)?.Id;
                    row.Cells[colGoodName.Name].Value = product.Name;
                    row.Cells[colSalePrice.Name].Value = _customerPrices.FirstOrDefault(x => x.ProductId == product.Id)?.SalePrice;
                    row.Cells[colCategory_.Name].Value = categorys.FirstOrDefault(x=>x.Id == product.CategoryId);

                }
                dgvGoods.CurrentCell = dgvGoods.Rows[0].Cells[colSalePrice.Name];
                dgvGoods.BeginEdit(true);
            }
        }
        private DataGridViewRow _newRow(bool isFocus = false)
        {
            var row = dgvGoods.Rows[dgvGoods.Rows.Add()];
            row.Cells[colProductId.Name].Value = 0;
            if (isFocus)
            {
                dgvGoods.Focus();
            }
            return row;
        }
        public bool InValid()
        {
            if (!txtName.IsValidRequired(lblName.Text) | !txtPhone.IsValidRequired(lblPhone.Text)
                | !txtPhone.IsValidPhone() | !inValidGridView())
            {
                return false;
            }
            return true;
        }
        private bool inValidGridView()
        {
            var invalidRow = false;
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var cellname = row?.Cells[colName.Name];
                var cellphone = row?.Cells[colPhone.Name];
                if (string.IsNullOrEmpty(cellname?.Value?.ToString()) && !string.IsNullOrEmpty(cellphone.Value?.ToString()))
                {
                    cellname.ErrorText = BaseResource.MsgNotInputSite;
                    invalidRow = true;
                }
                if (string.IsNullOrEmpty(cellname?.Value?.ToString()) && string.IsNullOrEmpty(cellphone.Value?.ToString()))
                {
                    invalidRow = true;
                }
            }
            if (invalidRow)
            {
                return false;
            }

            return true;
        }
        public async void Read()
        {
            txtName.Text = Model.Name;
            txtPhone.Text = Model.Phone;
            txtNote.Text = Model.Note;
            
            var sites = await dgv.RunAsync(() => SiteLogic.Instance.GetSiteByCustomerIds(Model.Id));
            if (sites.Any())
            {
                Model.Sites = sites;
                foreach (var site in sites)
                {
                    var row = newRow(false);
                    row.Cells[colId.Name].Value = site.Id;
                    row.Cells[colName.Name].Value = site.Name;
                    row.Cells[colPhone.Name].Value = site.Phone;
                }
            }
        }
        public void ViewChangeLog()
        {
            throw new NotImplementedException();
        }
        public void Write()
        {
            if (!InValid())
            {
                return;
            }
            
            Model.Active = true;
            Model.Name = txtName.Text;
            Model.Phone = txtPhone.Text;
            Model.Note = txtNote.Text;

            if (Model.Sites == null)
            {
                Model.Sites = new List<Site>();
            }

            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var Id = int.Parse(row?.Cells[colId.Name]?.Value?.ToString() ?? "0");
                var site = Model.Sites?.FirstOrDefault(x => x.Id == Id);
                var _phone = row.Cells[colPhone.Name].Value?.ToString();
                var _name = row.Cells[colName.Name].Value?.ToString();
                if (site != null)
                {
                    var id = (int)(row?.Cells[colId.Name]?.Value ?? 0);
                    var s = new Site()
                    {
                        Id = id,
                        Active = true,
                        Name = _name,
                        Phone = _phone,
                        CustomerId = Model.Id
                    };
                    Model.Sites[Model.Sites.IndexOf(site)] = s;
                }
                else
                {
                    var s = new Site()
                    {
                        Active = true,
                        Name = _name,
                        Phone = _phone
                    };
                    Model.Sites.Add(s);
                }
            }

            if (Flag != GeneralProcess.Update)
            {
                return;
            }
            if (Model.CustomerPrices == null)
            {
                Model.CustomerPrices = new List<Base.Models.CustomerPrice>();
            }
            foreach (DataGridViewRow row in dgvGoods.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var c = new CustomerPrice()
                {
                    Id = int.Parse(row.Cells[colIdd.Name].Value?.ToString() ?? "0"),
                    Active = true,
                    CustomerId = Model.Id,
                    ProductId = int.Parse(row.Cells[colProductId.Name].Value?.ToString()),
                    SalePrice = decimal.Parse(row.Cells[colSalePrice.Name]?.Value?.ToString() ?? "0")
                };
                Model.CustomerPrices.Add(c);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!dgv.CurrentCell?.IsInEditMode ?? true)
            {
                if (dgv.Rows.OfType<DataGridViewRow>().Where(x => x.IsNewRow).Count() == 1 && dgv.CurrentCell == null)
                {
                    dgv.Rows.Clear();
                }
                var index = dgv.Rows[dgv.NewRowIndex].Cells[colName.Name];
                dgv.CurrentCell = index;
                dgv.BeginEdit(true);
            }

        }
        private DataGridViewRow newRow(bool isFocus = false)
        {
            var row = dgv.Rows[dgv.Rows.Add()];
            row.Cells[colId.Name].Value = 0;
            row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dgv.Focus();
            }
            return row;
        }
        private async void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var row = dgv.SelectedRows[0];
            var idValue = row.Cells[colId.Name].Value;
            int siteId = int.Parse(idValue.ToString());
            if (siteId != 0)
            {
                var canRemove = await dgv.RunAsync(() => SiteLogic.Instance.CanRemoveAsync(siteId));
                if (!canRemove)
                {
                    MsgBox.ShowWarning(BaseResource.Site + BaseResource.MsgDataCurrentlyInUsed,
                   GeneralProcess.Remove.GetTextDialog(BaseResource.Site));
                    return;
                }
            }

            if (dgv?.SelectedRows?.Count > 0)
            {
                if (row.Cells[colName.Name].Value == null ||
                 row.Cells[colPhone.Name].Value == null)
                {
                    return;
                }

                if (idValue == null)
                {
                    dgv.Rows.Remove(dgv.CurrentRow);
                    return;
                }

                Model.Sites.ForEach(x =>
                {
                    if (x.Id == int.Parse(idValue.ToString()))
                    {
                        x.Active = false;
                    }
                }
                );
                if (!row.IsNewRow)
                {
                    dgv.Rows.Remove(row);
                    dgv.EndEdit();
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (!InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => CustomerLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                txtName.IsExists(lblName.Text);
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return CustomerLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return CustomerLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return CustomerLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
    }
}
