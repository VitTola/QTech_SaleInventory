using QTech.Base;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;


namespace QTech.Forms
{
    public partial class SalePage : ExPage, IPage
    {
        public Sale Model { get; set; }
        private GeneralProcess flag = GeneralProcess.None;
        SaleSearchKey saleSearchKey = SaleSearchKey.None;

        public SalePage()
        {
            InitializeComponent();
            BindData();
            InitEvent();
        }
        private void BindData()
        {
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            txtSearch.PatternChanged += txtSearch_PatternChanged;
            registerSearchMenu();
            cboPayStatus.SetDataSource<PayStatus>();
            cboImport.SetDataSource<ImportPrice>();
        }
        private void InitEvent()
        {
            this.Text = BaseResource.Sales;
            cboPayStatus.SelectedIndexChanged += CboPayStatus_SelectedIndexChanged;
            cboImport.SelectedIndexChanged += CboPayStatus_SelectedIndexChanged;
            btnAdd.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Add);
            btnRemove.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Remove);
            btnUpdate.Visible = ShareValue.IsAuthorized(AuthKey.Sale_Sale_Update);
            dgv.SetColumnHeaderDefaultStyle();
            cboImport.SelectedIndex = cboImport.FindStringExact(BaseResource.ImportPrice_All);

        }
        private async void CboPayStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private void txtSearch_PatternChanged(object sender, EventArgs e)
        {
            saleSearchKey = (SaleSearchKey)txtSearch.SelectedPattern;
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new Sale();
            Model.SaleDetails = new List<SaleDetail>();
            flag = GeneralProcess.Add;
            var dig = new frmSale(Model, flag);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
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
            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model.PayStatus != PayStatus.NotYetPaid)
            {
                MsgBox.ShowWarning(BaseResource.MsgSaleCanEdit,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Sales));
                return;
            }

            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            flag = GeneralProcess.Update;
            var dig = new frmSale(Model, flag);

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
            var canRemove = await btnRemove.RunAsync(() => SaleLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Sales));
                return;
            }

            Model = await btnRemove.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmSale(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }        
        public async Task Search()
        {
            dgv.Rows.Clear();
            List<Customer> _Customers = null;
            List<Site> _Sites = null;
            List<PurchaseOrder> purchaseOrders = null;
            var _payStatus = (PayStatus)cboPayStatus.SelectedValue;
            var _importPrice = (ImportPrice)cboImport.SelectedValue;
            var search = new SaleSearch()
            {
                saleSearchKey = this.saleSearchKey,
                Search = txtSearch.Text,
                payStatus = _payStatus,
                ImportPrice = _importPrice,
                Paging = pagination.Paging
            };
            pagination.ListModel = await dgv.RunAsync(() =>
             {
                 var _result = SaleLogic.Instance.SearchAsync(search);
                 var CusIds = _result.Select(x => x.CompanyId).ToList();
                 var SitesIds = _result.Select(x => x.SiteId).ToList();
                 _Customers = CustomerLogic.Instance.GetCustomersById(CusIds);
                 _Sites = SiteLogic.Instance.GetSiteByIds(SitesIds);
                 purchaseOrders = PurchaseOrderLogic.Instance.SearchAsync(new PurchaseOrderSearch());

                 return _result;
             });
            if (pagination.ListModel == null)
            {
                return;
            }
            List<Sale> sales = pagination.ListModel;
            dgv.Rows.Clear();
            sales.ForEach(x =>
            {
                var row = newRow(false);
                row.Cells[colId.Name].Value = x.Id;
                row.Cells[colPurchaseOrderNo.Name].Value = purchaseOrders.FirstOrDefault(p => p.Id == x.PurchaseOrderId)?.Name ?? "";
                row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                row.Cells[colToCompany.Name].Value = _Customers?.FirstOrDefault(cus => cus.Id == x.CompanyId)?.Name ?? x.CustomerName;
                row.Cells[colToSite.Name].Value = _Sites?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                row.Cells[colTotal.Name].Value = x.Total;
                row.Cells[colSaleDate.Name].Value = x.SaleDate.ToString("dd-MMM-yyyy hh:mm");
                row.Cells[colIsPaid.Name].Value = x.PayStatus;
                row.Cells[colRowDate.Name].Value = x.RowDate;

                var cell = row.Cells[colStatus.Name];
                if (x.PayStatus == PayStatus.Paid)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.IsPaid;
                    cell.Style.ForeColor = Color.Red;
                }
                else if (x.PayStatus == PayStatus.WaitPayment)
                {
                    row.Cells[colStatus.Name].Value = BaseResource.PayStatus_WaitPayment;
                    cell.Style.ForeColor = Color.Orange;
                }
                else
                {
                    row.Cells[colStatus.Name].Value = BaseResource.NotYetPaid;
                    cell.Style.ForeColor = Color.Green;
                }
            });
            dgv.Sort(dgv.Columns[colRowDate.Name], ListSortDirection.Descending);
            if (dgv.RowCount > 0) dgv.Rows[0].Selected = true;

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

            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmSale(Model, GeneralProcess.View);
            dig.ShowDialog();
        }
        private void registerSearchMenu()
        {
            txtSearch.AddMenuPattern(
                SaleSearchKey.PurchaseOrderNo.ToString(),
                SaleSearchKey.PurchaseOrderNo,
                BaseResource.PurchaseOrderNo_img,
                BaseResource.PurchaseOrderNo,
                Constants.KeyShortcut[SaleSearchKey.PurchaseOrderNo],
                (s, e) =>
                {
                    InputLanguage.CurrentInputLanguage = UI.English;
                    txtSearch.ReadOnly = false;
                });
            txtSearch.AddMenuPattern(
             SaleSearchKey.InvoiceNo.ToString(),
             SaleSearchKey.InvoiceNo,
             BaseResource.InvoiceNo_img,
             BaseResource.InvoiceNo,
             Constants.KeyShortcut[SaleSearchKey.InvoiceNo],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });
            txtSearch.AddMenuPattern(
             SaleSearchKey.CompanyName.ToString(),
             SaleSearchKey.CompanyName,
             BaseResource.customer2,
             BaseResource.Customer,
             Constants.KeyShortcut[SaleSearchKey.CompanyName],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });
            txtSearch.AddMenuPattern(
             SaleSearchKey.SiteName.ToString(),
             SaleSearchKey.SiteName,
             BaseResource.home,
             BaseResource.Site,
             Constants.KeyShortcut[SaleSearchKey.SiteName],
             (s, e) =>
             {
                 InputLanguage.CurrentInputLanguage = UI.English;
                 txtSearch.ReadOnly = false;
             });

            InputLanguage.CurrentInputLanguage = UI.English;
            txtSearch.ShowMenuPattern(SaleSearchKey.PurchaseOrderNo);
            // changeDataVisible();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Constants.KeyShortcut[SaleSearchKey.PurchaseOrderNo])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.PurchaseOrderNo);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.InvoiceNo])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.InvoiceNo);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.CompanyName])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.CompanyName);
                return true;
            }
            else if (keyData == Constants.KeyShortcut[SaleSearchKey.SiteName])
            {
                InputLanguage.CurrentInputLanguage = UI.English;
                txtSearch.ReadOnly = false;
                txtSearch.ShowMenuPattern(SaleSearchKey.SiteName);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
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
