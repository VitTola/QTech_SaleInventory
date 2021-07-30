using FastMember;
using QTech.Base;
using QTech.Base.BaseReport;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using QTech.ReportModels;
using QTech.Reports;
using Storm.CC.Report.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseReource = QTech.Base.Properties.Resources;

namespace QTech.Forms
{
    public partial class frmPurchaseOrder : ExDialog, IDialog
    {
        public PurchaseOrder Model { get; set; }
        private List<POProductPrice> POProductPrices;
        public GeneralProcess Flag { get; set; }
        public frmPurchaseOrder(PurchaseOrder model, GeneralProcess flag)
        {
            InitializeComponent();
            this.Model = model;
            this.Flag = flag;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            this.ApplyResource();
            Read();
            Bind();
            InitEvent();
        }
        public void Bind()
        {
            cboCustomer.DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList();
            cboCustomer.SearchParamFn = () => new CustomerSearch();
        }
        public void InitEvent()
        {
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.PurchaseOrderNo);
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtNote.RegisterPrimaryInputWith();
            txtPurchaseOrderNo.RegisterEnglishInputWith(txtPurchaseOrderNo);
            dgv.RegisterEnglishInputColumns(colQauntity, colUnitPrice_);
            dgv.RegisterPrimaryInputColumns(colNote);
            dgv.AllowRowNotFound = false;
            dgv.AllowUserToAddRows = dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnEnter;

            if (Flag == GeneralProcess.Add || Flag == GeneralProcess.Update)
            {
                dgv.EditingControlShowing += dgv_EditingControlShowing;
            }
            this.SetEnabled(Flag != GeneralProcess.Remove && Flag != GeneralProcess.View);
            colProductId.ReadOnly = colLeftQauntity_.ReadOnly = colCategory_.ReadOnly = true;
            dgv.EditColumnIcon(colQauntity,colUnitPrice_,colNote);

        }
        private void dgv_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox txt)
            {
                if (dgv.CurrentCell.ColumnIndex == colQauntity.Index)
                {
                    txt.KeyUp += Txt_KeyUp;
                }
                if (dgv.CurrentCell.ColumnIndex == colQauntity.Index || dgv.CurrentCell.ColumnIndex == colUnitPrice_.Index)
                {
                    txt.KeyPress += Txt_KeyPress;
                }
            }
        }
        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var _sender = sender as TextBox;
            _sender.validCurrency(_sender, e);
            _sender.KeyPress -= Txt_KeyPress;
        }
        private void Txt_KeyUp(object sender, EventArgs e)
        {
            if (Flag == GeneralProcess.Update)
            {
                var rowId = int.Parse(dgv.CurrentRow.Cells[colId.Name].Value?.ToString() ?? "0");
                var firstQty = POProductPrices.FirstOrDefault(x => x.Id == rowId)?.StartQauntity;

                var currentValue = int.Parse(dgv.CurrentRow.Cells[colQauntity.Name].Value?.ToString() ?? "0");
                var firstLeftQty = POProductPrices.FirstOrDefault(x => x.Id == rowId)?.LeftQauntity;
                dgv.CurrentRow.Cells[colLeftQauntity_.Name].Value = firstLeftQty;
                dgv.CurrentRow.Cells[colLeftQauntity_.Name].Value = firstLeftQty + (currentValue - firstQty);
            }
            else if (Flag == GeneralProcess.Add)
            {
                dgv.CurrentRow.Cells[colLeftQauntity_.Name].Value = dgv.CurrentRow.Cells[colQauntity.Name].Value;
            }
            if (sender is TextBox txt)
            {
                txt.Leave -= Txt_KeyUp;
            }
        }
        public bool InValid()
        {
            if (
                !txtPurchaseOrderNo.IsValidRequired(lblPurchaseOrderNo.Text)
                |!cboCustomer.IsSelected() 
                | !validPurchaseOrderDetail())
            {
                return true;
            }

            return false;
        }
        private bool validPurchaseOrderDetail()
        {
            var invalidCell = false;
            var rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => x.Index != dgv.RowCount - 1);
            if (rows?.Any() != true)
            {
                MsgBox.ShowInformation(string.Format(BaseReource.MsgPleaseInputDataInTable_, BaseReource.SaleDetail));
                return false;
            }

            foreach (DataGridViewRow row in rows)
            {
                var cells = row.Cells.OfType<DataGridViewCell>().Where(x =>
                x.ColumnIndex == row.Cells[colQauntity.Name].ColumnIndex && x.ColumnIndex == row.Cells[colUnitPrice_.Name].ColumnIndex).ToList();
                cells.ForEach(x =>
                {
                    if (x.Value == null)
                    {
                        x.ErrorText = BaseReource.MsgPleaseInputValue;
                        invalidCell = true;
                    }
                    else
                    {
                        x.ErrorText = string.Empty;
                    }
                });
            }
            if (invalidCell)
            {
                return false;
            }

            return true;
        }
        public async void Read()
        {
            var categorys = new List<Category>();
            var customer = new Customer();
            dgv.Rows.Clear();
            var Products = await dgv.RunAsync(() =>
            {
                var search = new ProductSearch();
                var prods = ProductLogic.Instance.SearchAsync(search);
                POProductPrices = POProductPriceLogic.Instance.GetPOProductPriceByPO(Model.Id);
                categorys = CategoryLogic.Instance.SearchAsync(new CategorySearch());
                customer = CustomerLogic.Instance.FindAsync(Model.CustomerId);
                return prods;
            });

            txtPurchaseOrderNo.Text = Model.Name;
            txtNote.Text = Model.Note;
            cboCustomer.SetValue(customer);

            foreach (var product in Products)
            {
                var row = _newRow(false);
                row.Cells[colId.Name].Value = POProductPrices?.FirstOrDefault(x => x.ProductId == product.Id && x.PurchaseOrderId == Model.Id)?.Id;
                row.Cells[colProductId.Name].Value = product?.Name;
                row.Cells[colProductId_.Name].Value = product?.Id;
                row.Cells[colCategory_.Name].Value = categorys?.FirstOrDefault(x => x.Id == product.CategoryId)?.Name;
                row.Cells[colQauntity.Name].Value = POProductPrices?.FirstOrDefault(x => x.ProductId == product.Id)?.StartQauntity;
                row.Cells[colLeftQauntity_.Name].Value = POProductPrices?.FirstOrDefault(x => x.ProductId == product.Id && x.PurchaseOrderId == Model.Id)?.LeftQauntity;
                row.Cells[colUnitPrice_.Name].Value = POProductPrices?.FirstOrDefault(x => x.ProductId == product.Id && x.PurchaseOrderId == Model.Id)?.SalePrice;
                row.Cells[colNote.Name].Value = POProductPrices?.FirstOrDefault(x => x.ProductId == product.Id && x.PurchaseOrderId == Model.Id)?.Note;
            }
            //dgv.CurrentCell = dgv.Rows[0].Cells[colQauntity.Name];
            dgv.BeginEdit(true);
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
        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => PurchaseOrderLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return PurchaseOrderLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return PurchaseOrderLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return PurchaseOrderLogic.Instance.RemoveAsync(Model);
                }

                return null;
            });
            if (result != null)
            {
                Model = result;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        public void ViewChangeLog()
        {

        }
        public void Write()
        {
            Model.Name = txtPurchaseOrderNo.Text;
            Model.Note = txtNote.Text;
            var customer = cboCustomer.SelectedObject.ItemObject as Customer;
            Model.CustomerId = customer.Id;

            if (Model.POProductPrices == null)
            {
                Model.POProductPrices = new List<POProductPrice>();
            }

            dgv.EndEdit();
            foreach (DataGridViewRow row in dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow))
            {
                var _pOProductPrice = new POProductPrice();
                _pOProductPrice.Active = true;
                _pOProductPrice.Id = int.Parse(row.Cells[colId.Name].Value?.ToString() ?? "0");
                _pOProductPrice.PurchaseOrderId = Model.Id;
                _pOProductPrice.StartQauntity = int.Parse(row.Cells[colQauntity.Name].Value?.ToString() ?? "0");
                _pOProductPrice.LeftQauntity = int.Parse(row.Cells[colLeftQauntity_.Name].Value?.ToString() ?? "0");
                _pOProductPrice.SalePrice = decimal.Parse(row.Cells[colUnitPrice_.Name].Value?.ToString() ?? "0");
                _pOProductPrice.Note = row.Cells[colNote.Name].Value?.ToString();
                _pOProductPrice.ProductId = int.Parse(row.Cells[colProductId_.Name].Value?.ToString());
                Model.POProductPrices.Add(_pOProductPrice);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
