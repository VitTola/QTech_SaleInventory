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
using QTech.Reports;
using QTech.Base.BaseReport;

namespace QTech.Forms
{
    public partial class frmEmployeeBilling : ExDialog
    {
        public EmployeeBill Model { get; set; }
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
        private decimal Total = 0, prePaid = 0;
        private int AllSales = 0, CheckingAmount = 0;
        private List<SupplierGeneralPaid> SupplierGeneralPrepaids;

        private void Bind()
        {
            this.Text = Flag.GetTextDialog(Base.Properties.Resources.EmployeeBill);
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
            dgv.CellContentClick += Dgv_CellContentClick;
            txtPaidAmount.Leave += txtPaidAmount_Leave;
            txtPaidAmount.TextChanged += txtPaidAmount_TextChanged;
            cboCompany.SelectedIndexChanged += CboCompany_SelectedIndexChanged;

            colMark_.ReadOnly = txtPaidAmount.ReadOnly = false;
            txtPaidAmount.KeyPress += (s, e) => { txtPaidAmount.validCurrency(s, e); };
            btnLeft_.Click += BtnLeft_Click;
            btnRigt_.Click += BtnRigt_Click;
            btnPrint.Click += BtnPrint_Click;
        }
        private void BtnRigt_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) return;
            dgv.EndEdit();
            var Rows = dgv.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow && (bool)(x.Cells[colMark_.Name].Value))?.ToList();
            foreach (DataGridViewRow row in Rows)
            {
                var r = newRow(dgvResult);
                foreach (DataGridViewCell cell in row.Cells)
                {
                    r.Cells[cell.ColumnIndex].Value = cell.Value;
                }
            }
            Rows.ForEach(r => dgv.Rows.Remove(r));
            CalculateTotal();
        }
        private void BtnLeft_Click(object sender, EventArgs e)
        {
            if (dgvResult.SelectedRows.Count == 0) return;
            dgvResult.EndEdit();
            var row = dgvResult.CurrentRow;
            int index = dgv.Rows.Add(row.Clone() as DataGridViewRow);
            foreach (DataGridViewCell o in row.Cells)
            {
                dgv.Rows[index].Cells[o.ColumnIndex].Value = o.Value;
            }
            dgvResult.Rows.Remove(dgvResult.CurrentRow);
            CalculateTotal();
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
                
            }
        }
        private void CboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var company = cboCompany.SelectedObject.ItemObject as Customer;
            cboSite.SearchParamFn = () => new SiteSearch() { CustomerId = company == null ? 0 : company.Id };
            cboSite.SetValue(null);

        }
        public async void Reload()
        {
            await Search();
        }
        public async Task<List<EmployeeBillOutFace>> Search()
        {
            if (btnView.Executing)
            {
                return null;
            }

            var site = cboSite.SelectedObject?.ItemObject as Site;
            var company = cboCompany.SelectedObject?.ItemObject as Customer;
            var driver = cboDriver.SelectedObject?.ItemObject as Employee;

            //WHEN SEARCHING ADD NEW FLAG
            if (Flag == GeneralProcess.Add)
            {
                int driverId = driver.Id;
                SupplierGeneralPrepaids = SupplierGeneralPaidLogic.Instance.GetSupplierGeneralPaidByEmpId(driverId);
                SupplierGeneralPrepaids.ForEach(x => prePaid += x.Amount);
                txtPrePaid.Text = prePaid.ToString();
                lblDriver.Text = driver.Name;
            }
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
                var _result = SaleDetailLogic.Instance.GetEmployeeBillOutFaces(searchParam);
                return _result;
            });
            return employeeBills;
        }
        public async void View()
        {
            if (!dtpPeroid.IsSelected())
            {
                return;
            }
            if (!cboDriver.IsSelected() | !cboCompany.IsSelected() | !cboSite.IsSelected())
            {
                btnAdvanceSearch.ShowValidation(BaseResource.MsgPleaseSelectValue);
                return;
            }

            var employeeBills = await Search();
            FillGiridView(employeeBills, dgv);
        }
        private void FillResultGiridView(List<EmployeeBillOutFace> employeeBillOutFaces, DataGridView dataGridView)
        {
            if (employeeBillOutFaces == null)
            {
                return;
            }
            dgvResult.Rows.Clear();
            employeeBillOutFaces.ForEach(x =>
            {
                var row = newRow(dgvResult);
                row.Cells[colId2.Name].Value = x.saleDetail.Id;
                row.Cells[colTag2.Name].Value = x.saleDetail;
                row.Cells[colPurchaseOrderNo2.Name].Value = x.PurchaseOrderNo;
                row.Cells[colInvoiceNo2.Name].Value = x.InvoiceNo;
                row.Cells[colToCompany2.Name].Value = x.ToCompany;
                row.Cells[colToSite2.Name].Value = x.ToSite;
                row.Cells[colSaleDate2.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                row.Cells[colProduct2.Name].Value = x.Product;
                row.Cells[colCategory2.Name].Value = x.Category;
                row.Cells[colImportPrice2.Name].Value = x.ImportPrice;
                row.Cells[colQauntity2.Name].Value = x.Qauntity;
                row.Cells[colTotal2.Name].Value = x.ImportTotalAmount;

                if (Flag == GeneralProcess.Add)
                {
                    row.Cells[colMark_2.Name].Value = false;
                }
                else
                {
                    row.Cells[colMark_2.Name].Value = true;
                }
            });
      
        }
        private void FillGiridView(List<EmployeeBillOutFace> employeeBillOutFaces, DataGridView dataGridView)
        {
            if (employeeBillOutFaces == null)
            {
                return;
            }
            dgv.Rows.Clear();
            AllSales = 0;
            employeeBillOutFaces.ForEach(x =>
            {
                var row = newRow(dataGridView);
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
        private DataGridViewRow newRow(DataGridView dataGridView, bool isFocus = false)
        {
            var row = dataGridView.Rows[dataGridView.Rows.Add()];
            //row.Cells[colId.Name].Value = 0;
            if (isFocus)
            {
                dataGridView.Focus();
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
            if (!dtpPeroid.IsSelected())
            {
                return true;
            }

            if (!cboDriver.IsSelected() | !cboCompany.IsSelected() | !cboSite.IsSelected())
            {
                btnAdvanceSearch.ShowValidation(BaseResource.MsgPleaseSelectValue);
                return true;
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
        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }
        public async void Read()
        {
            if (Flag != GeneralProcess.Add)
            {
                var driver = new Employee();
                var employeeBillOutFaces = await dgv.RunAsync(() => {

                    var _employeeBillOutFaces = SaleDetailLogic.Instance.GetEmployeeBillOutFaces(new EmployeeBillSearch { EmployeeBillId = Model.Id});
                    driver = EmployeeLogic.Instance.FindAsync(Model.EmployeeId);
                    return _employeeBillOutFaces;
                });
                if (driver != null)
                {
                    cboDriver.SetValue(driver);
                    lblDriver.Text = driver.Name;
                    //Not allow to choose another drive when update
                    cboDriver.Enabled = false;
                }
                txtPrePaid.Text = Model.PaidAmount.ToString();
                txtLeftAmount.Text = Model.LeftAmount.ToString();
                txtPaidAmount.Text =  Model.PaidAmount.ToString();
                txtTotal.Text = Model.Total.ToString();
                FillResultGiridView(employeeBillOutFaces, dgvResult);
                Model.SaleDetails = employeeBillOutFaces?.Select(s => s.saleDetail)?.ToList();
            }
        }
        public void Write()
        {
            Model.SaleDetails?.ForEach(s =>
            {
                s.PayStatus = PayStatus.NotYetPaid;
                s.EmployeeBillId = 0;
            });
            Model.DoDate = DateTime.Now;
            Model.Total = decimal.Parse(!string.IsNullOrEmpty(txtTotal.Text) ? txtTotal.Text : "0");
            Model.PaidAmount = decimal.Parse(!string.IsNullOrEmpty(txtPaidAmount.Text) ? txtPaidAmount.Text : "0");
            Model.LeftAmount = decimal.Parse(!string.IsNullOrEmpty(txtLeftAmount.Text) ? txtLeftAmount.Text : "0");

            if (Flag == GeneralProcess.Add)
            {
                var employee = cboDriver.SelectedObject.ItemObject as Employee;
                Model.EmployeeId = employee.Id;
            }

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
            var Rows = dgvResult.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                var saleDetail = (row.Cells[colTag2.Name].Value) as SaleDetail;
                if (Model.PaidAmount == 0)
                {
                    saleDetail.PayStatus = PayStatus.WaitPayment;
                }
                else if (Model.LeftAmount == 0)
                {
                    saleDetail.PayStatus = PayStatus.Paid;
                }
                var oldRecord = Model.SaleDetails.FirstOrDefault(s => s.Id == saleDetail.Id);
                if (oldRecord != null)
                {
                    var index = Model.SaleDetails.IndexOf(oldRecord);
                    Model.SaleDetails[index].PayStatus = saleDetail.PayStatus;
                    Model.SaleDetails[index].EmployeeBillId = Model.Id;
                }
                else
                {
                    Model.SaleDetails.Add(saleDetail);
                }
            }
        }
        public bool InValid()
        {
            return dgvResult.Rows.Count == 0;
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
            //txtPaidAmount.Text = string.Empty;
            var Rows = dgvResult.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                if ((bool)row.Cells[colMark_2.Name].Value)
                {
                    Total = Total + decimal.Parse(row.Cells[colTotal2.Name].Value?.ToString() ?? "0");
                }
            }
            txtTotal.Text = Total.ToString();
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
        }
        private async void BtnPrint_Click(object sender, EventArgs e)
        {
            var driverDeliveryDetails = GetReportModel();
            if (driverDeliveryDetails == null)
            {
                return;
            }
            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                {"Driver",lblDriver.Text }
            };


            DataTable driverDeleryDetail = new DataTable("RportDriverDeliveryDetail");
            using (var reader = ObjectReader.Create(driverDeliveryDetails))
            {
                driverDeleryDetail.Load(reader);
            }
            var _driverDeliveryDetails = new List<DataTable>();
            _driverDeliveryDetails.Add(driverDeleryDetail);

            var report = await btnPrint.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportEmployeeBilling), _driverDeliveryDetails, reportHeader);
                r.SummaryInfo.ReportTitle = nameof(ReportEmployeeBilling);
                return r;
            });

            if (report != null)
            {
                var dig = new DialogReportViewer(report);
                dig.Text = QTech.Base.Properties.Resources.EmployeeBill;
                dig.ShowDialog();
            }
        }
        private List<ReportModels.DriverDeliveryDetail> GetReportModel()
        {
            var DriverDeliveryDetails = new List<ReportModels.DriverDeliveryDetail>();
         
            //if (Flag == GeneralProcess.Add)
            //{
            //    var employee = cboDriver.SelectedObject?.ItemObject as Employee;
            //    Model.EmployeeId = employee.Id;
            //}

            dgvResult.EndEdit();
            var Rows = dgvResult.Rows.OfType<DataGridViewRow>().Where(x => !x.IsNewRow);
            foreach (DataGridViewRow row in Rows)
            {
                DriverDeliveryDetails.Add(new ReportModels.DriverDeliveryDetail() {
                    PurchaseOrderNo = row.Cells[colPurchaseOrderNo2.Name].Value?.ToString() ?? string.Empty,
                    InvoiceNo = row.Cells[colInvoiceNo2.Name].Value?.ToString() ?? string.Empty,
                    Company = row.Cells[colToCompany2.Name].Value?.ToString() ?? string.Empty,
                    Site = row.Cells[colToSite2.Name].Value?.ToString() ?? string.Empty,
                    SaleDate = row.Cells[colSaleDate2.Name].Value?.ToString() ?? string.Empty,
                    ImportPrice = decimal.Parse(row.Cells[colImportPrice2.Name].Value?.ToString() ?? "0"),
                    Qauntity = int.Parse(row.Cells[colQauntity2.Name].Value?.ToString() ?? "0"),
                    SubTotal = row.Cells[colTotal2.Name].Value?.ToString() ?? string.Empty,
                    Product = $"{row.Cells[colProduct2.Name].Value?.ToString()} {row.Cells[colCategory2.Name].Value.ToString()}"
                });
            }

            return DriverDeliveryDetails;
        }
    }
}
