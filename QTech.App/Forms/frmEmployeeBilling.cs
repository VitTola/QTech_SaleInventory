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
using QTech.Component.Interfaces;
using System.Data;
using FastMember;
using QTech.ReportModels;
using Storm.CC.Report.Helpers;
using QTech.Component.Helpers;
using QTech.Base.Models;
using QTech.Base.OutFaceModels;
using QTech.Base.Enums;

namespace QTech.Forms
{
    public partial class frmEmployeeBilling : ExDialog, QTech.Component.Helpers.IDialog
    {
        public EmployeeBill Model{ get; set; }
        public GeneralProcess Flag { get; set; }
        public frmEmployeeBilling(EmployeeBill model, GeneralProcess flag)
        {
            InitializeComponent();
            Model = model;
            Flag = flag;
            Bind();
            Read();
            InitEvent();
            InitAdvanceFilter();
        }
        Dictionary<string, Control> _advanceFilters;
        CustomAdvanceFilter dig;
        private decimal Total=0, prePaid = 0;
        private int AllSales = 0, CheckingAmount = 0;
        private List<SupplierGeneralPaid> SupplierGeneralPrepaids;

        private void Bind()
        {
            var maxDate = DateTime.Now;
            dtpPeroid.CustomDateRang = CustomDateRang.None;
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(dtpPeroid.CustomDateRang, maxDate);
            dtpPeroid.SetMaxDate(maxDate);
            dtpPeroid.Items.AddRange(peroids.ToArray());
            dtpPeroid.Items.Add(customPeroid);
            dtpPeroid.SetSelectePeroid(DatePeroid.Today);
        }

        private void InitEvent()
        {
            btnAdvanceSearch.Click += btnAdvanceSearch_Click;
            cboCompany.SelectedIndexChanged += CboCompany_SelectedIndexChanged;
            dgv.CellContentClick += Dgv_CellContentClick;
            txtPaidAmount.Leave += txtPaidAmount_Leave;
            txtPaidAmount.TextChanged += txtPaidAmount_TextChanged;
            cboCompany.SelectedIndexChanged += CboCompany_SelectedIndexChanged1;

            colMark_.ReadOnly = false;
            txtPaidAmount.ReadOnly = false;
            txtPaidAmount.KeyPress += (s, e) => { txtPaidAmount.validCurrency(s, e); };

        }

        private void CboCompany_SelectedIndexChanged1(object sender, EventArgs e)
        {
            cboSite.SetValue(null);
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colMark_.Index)
            {
                var _isCheck = (bool)(dgv.CurrentRow.Cells[colMark_.Name]?.Value);
                dgv.CurrentRow.Cells[colMark_.Name].Value = !_isCheck;

                if (!_isCheck && CheckingAmount < AllSales)
                {
                    CheckingAmount++;
                }
                else
                {
                    CheckingAmount--;
                }
                chkMarkAll_.Checked = CheckingAmount == AllSales ? true : false;

                CalculateTotal();
            }
        }
        private void CboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var company = cboCompany.SelectedObject.ItemObject as Customer;
            cboSite.SearchParamFn = () => new SiteSearch() { CustomerId = company == null ? 0 : company.Id };
        }

        public void AddNew() { }

        public void Edit() { }

        public async void Reload()
        {
            await Search();
        }

        public void Remove()
        {

        }

        public async Task Search()
        {
            dgv.Rows.Clear();
            txtPrePaid.Text = txtTotal.Text = txtPaidAmount.Text = txtLeftAmount.Text = "0";
            Total = 0; prePaid = 0;
            if (btnView.Executing)
            {
                return;
            }
            if (inValid() && Flag == GeneralProcess.Add)
            {
                return;
            }
            var driver = cboDriver?.SelectedObject?.ItemObject as Employee;
            var company = cboCompany?.SelectedObject?.ItemObject as Customer;
            var site = cboSite?.SelectedObject?.ItemObject as Site;
            SupplierGeneralPrepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaidByEmpId(driver?.Id ?? -1);
            SupplierGeneralPrepaids.ForEach(x => prePaid += x.Amount);
            txtPrePaid.Text = prePaid.ToString();
            lblDriver.Text = cboDriver.Text;

            var searchParam = new EmployeeBillSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate.Date,
                DriverId = driver?.Id ?? 0,
                CustomerId = company?.Id ?? 0,
                SiteId = site?.Id ?? 0,
                EmployeeBillId = Model.Id
            };

            var employeeBills = await btnView.RunAsync(() =>
            {
                var result = SaleDetailLogic.Instance.GetEmployeeBillOutFaces(searchParam);
                return result;
            });
            FillGiridView(employeeBills);
        }

        public async void View()
        {
            await Search();
        }
        private void FillGiridView(List<EmployeeBillOutFace> employeeBillOutFaces)
        {
            if (employeeBillOutFaces == null)
            {
                return;
            }
            AllSales = 0;
            employeeBillOutFaces.ForEach(x=> {
                var row = newRow(false);
                row.Cells[colId.Name].Value = x.saleDetail.Id;
                row.Cells[colTag.Name].Value = x.saleDetail;
                row.Cells[colPurchaseOrderNo.Name].Value = x.PurchaseOrderNo;
                row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                row.Cells[colToCompany.Name].Value = x.ToCompany;
                row.Cells[colToSite.Name].Value = x.ToSite;
                row.Cells[colSaleDate.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm"); 
                row.Cells[colProducts.Name].Value = x.Product;
                row.Cells[colCategory_.Name].Value = x.Category;
                row.Cells[colImportPrice.Name].Value = x.ImportPrice;
                row.Cells[colQauntity_3.Name].Value = x.Qauntity;
                row.Cells[colTotal.Name].Value = x.ImportTotalAmount;

                if (Flag == GeneralProcess.Add)
                {
                    row.Cells[colMark_.Name].Value = false;
                }
                else
                {
                    chkMarkAll_.Checked = true;
                    row.Cells[colMark_.Name].Value = true;
                }
                AllSales++;
            });
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

        #region INIT ADVANT SEARCH
        ExSearchCombo cboDriver = new ExSearchCombo
        {
            Name = BaseResource.Driver,
            DataSourceFn = p => EmployeeLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new EmployeeSearch(),
        };

        ExSearchCombo cboCompany = new ExSearchCombo
        {
            Name = BaseResource.Customer,
            TextAll = BaseResource.Customer,
            DataSourceFn = p => CustomerLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new CustomerSearch(),
            Choose = BaseResource.Customer,
        };

        ExSearchCombo cboSite = new ExSearchCombo
        {
            Name = BaseResource.Site,
            TextAll = BaseResource.Site,
            Choose = BaseResource.Site,
            DataSourceFn = p => SiteLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new SiteSearch() { }
        };
        #endregion
        private bool _isAdvanceInvalid = false;
        public void Find()
        {
            if (btnView.Executing)
            {
                return;
            }
            btnAdvanceSearch.HideValidation();
            if (dig.ShowDialog() == DialogResult.OK)
            {
                if (btnView.Enabled && btnView.Visible)
                {
                    View();
                }
            }
            if (_isAdvanceInvalid)
            {
                btnAdvanceSearch.ShowValidation(BaseResource.MsgPleaseSelectValue);
            }
        }

        private void InitAdvanceFilter()
        {
            _advanceFilters = new Dictionary<string, Control>()
            {
                {cboDriver.Name, cboDriver },
                {cboCompany.Name, cboCompany },
                {cboSite.Name, cboSite },
            };


            _advanceFilters.IniAdvanceFilter();
            dig = new CustomAdvanceFilter(_advanceFilters, inValid);

            foreach (var item in _advanceFilters.Values)
            {
                if (item is ExSearchListCombo cbo)
                {
                    if (!item.IsHandleCreated)
                    {
                        item.CreateControl();
                    }
                    if (cbo.SelectedItems.Any())
                    {
                        cbo.SelectedValue = cbo.SelectedItems[0].Id;
                    }
                }
                else if (item is ComboBox comboBox)
                {
                    if (!item.IsHandleCreated)
                    {
                        comboBox.CreateControl();
                    }
                }
            }
        }

        private bool inValid()
        {
            _isAdvanceInvalid = false;
            if (!dtpPeroid.IsSelected())
            {
                return true;
            }

            if (!cboDriver.IsSelected() | !cboCompany.IsSelected() | !cboSite.IsSelected())
            {
                _isAdvanceInvalid = true;
                btnAdvanceSearch.ShowValidation(BaseResource.MsgPleaseSelectValue);
                return true;
            }

            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_.Name]?.Value)
                {
                    return false;
                }
            }
            return false;
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            Find();
        }

        private void dig_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnAdvanceSearch.HideValidation();
            _isAdvanceInvalid = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.O))
            {
                View();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                Find();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void EditAsync()
        {
            throw new NotImplementedException();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        public async void Read()
        {
           await Search();
        }

        void IDialog.InitEvent()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            Model.DoDate = DateTime.Now;
            Model.Total = decimal.Parse(!string.IsNullOrEmpty(txtTotal.Text) ? txtTotal.Text : "0");
            Model.PaidAmount = decimal.Parse(!string.IsNullOrEmpty(txtPaidAmount.Text) ? txtPaidAmount.Text : "0");
            Model.LeftAmount = decimal.Parse(!string.IsNullOrEmpty(txtLeftAmount.Text) ? txtLeftAmount.Text : "0");
            var employee = cboDriver.SelectedObject.ItemObject as Employee;
            Model.EmployeeId = employee.Id;

            if (Model.PaidAmount == 0)
            {
                Model.InvoiceStatus = InvoiceStatus.WaitPayment;
            }
            else if (Model.LeftAmount == 0)
            {
                Model.InvoiceStatus = InvoiceStatus.Paid;
            }
            else
            {
                Model.InvoiceStatus = InvoiceStatus.PaySome;
            }

            if (Model.SaleDetails == null)
            {
                Model.SaleDetails = new List<SaleDetail>();
            }
            dgv.EndEdit();
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                var _isChecked = (bool)(row.Cells[colMark_.Name].Value ?? false);
                if (_isChecked)
                {
                    var saleDetail = (row.Cells[colTag.Name].Value) as SaleDetail;
                    if (Model.PaidAmount == 0)
                    {
                        saleDetail.PayStatus = PayStatus.WaitPayment;
                    }
                    else if (Model.LeftAmount == 0)
                    {
                        saleDetail.PayStatus = PayStatus.Paid;
                    }
                    Model.SaleDetails.Add(saleDetail);
                }
            }
        }

        void IDialog.Bind()
        {
            throw new NotImplementedException();
        }

        public bool InValid()
        {
            bool _isValid = true;
            var employee = cboDriver.SelectedObject.ItemObject as Employee;
            if (employee == null || employee.Id == 0 )
            {
                _isValid = false;
            }

            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_.Name]?.Value)
                {
                    _isValid = false;
                    break;
                }
            }
            return _isValid;
        }

        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                Close();
            }

            if (InValid()) { return; }
            Write();

            var isExist = await btnSave.RunAsync(() => EmployeeBillLogic.Instance.IsExistsAsync(Model));
            if (isExist == true)
            {
                return;
            }

            var result = await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    return EmployeeBillLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    return EmployeeBillLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    return EmployeeBillLogic.Instance.RemoveAsync(Model);
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
            throw new NotImplementedException();
        }
        private void CalculateTotal()
        {
            Total = 0;
            txtPaidAmount.Text = string.Empty;
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_.Name].Value)
                {
                    Total = Total + decimal.Parse(row.Cells[colTotal.Name].Value?.ToString() ?? "0");
                }
            }
            txtTotal.Text =  Total.ToString();
            txtLeftAmount.Text = (Total - prePaid).ToString();
        }
        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text))
            {
                return;
            }
            var pay = decimal.Parse(txtPaidAmount.Text);
            var total = decimal.Parse(txtTotal.Text ?? "0");
            txtLeftAmount.Text = (total - (pay + prePaid)).ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblPrePaid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtPaidAmount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPaidAmount.Text))
            {
                txtPaidAmount.Text = "0";
            }
        }
        private void chkMarkAll__CheckedChanged(object sender, EventArgs e)
        {
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                row.Cells[colMark_.Name].Value = chkMarkAll_.Checked;
            }
            CheckingAmount = chkMarkAll_.Checked ? AllSales : 0;

            CalculateTotal();
        }
    }
}
