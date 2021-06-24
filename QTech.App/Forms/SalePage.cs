using QTech.Base;
using QTech.Base.Enums;
using QTech.Base.Helpers;
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
    public partial class SalePage : ExPage, IPage
    {
        public Sale Model { get; set; }
        public SalePage()
        {
            InitializeComponent();
            BindData();
            InitEvent();
        }

        private void BindData()
        {
            var maxDate = DateTime.Now;
            rdtpPicker.CustomDateRang = CustomDateRang.None;
            //rdtpPicker.CustomDateRang = 
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(rdtpPicker.CustomDateRang, maxDate);
            rdtpPicker.SetMaxDate(maxDate);
            rdtpPicker.Items.AddRange(peroids.ToArray());
            rdtpPicker.Items.Add(customPeroid);
            rdtpPicker.SetSelectePeroid(DatePeroid.Today);

            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            txtSearch.PatternChanged += txtSearch_PatternChanged;
            //rdtpPicker.ValueChanged += txtSearch_QuickSearch;
            registerSearchMenu();

        }
        private void InitEvent()
        {
            this.Text = BaseResource.Sales;
            dgv.CellContentClick += Dgv_CellContentClick;
        }

        private void Dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.CurrentCell.ColumnIndex != colViewDetail.Index)
            {
                return;
            }
            View();
        }

        private void txtSearch_PatternChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            
        }

        
        public async void AddNew()
        {
            Model = new Sale();
            Model.SaleDetails = new List<SaleDetail>();
            var dig = new frmSale(Model, GeneralProcess.Add);
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
            if (Model == null)
            {
                return;
            }
            //Model.SaleDetails=new List<SaleDetail>();
            var dig = new frmSale(Model, GeneralProcess.Update);

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
            var search = new SaleSearch()
            {
                Search = txtSearch.Text,
            };
            List<Customer> _Customers = null;
            List<Site> _Sites = null;
            var _sales =await dgv.RunAsync(() =>
            {
               var _result = SaleLogic.Instance.SearchAsync(search);
                var CusIds = _result.Select(x => x.CompanyId).ToList();
                var SitesIds = _result.Select(x => x.SiteId).ToList();
                 _Customers = CustomerLogic.Instance.GetCustomersById(CusIds);
                _Sites = SiteLogic.Instance.GetSiteByIds(SitesIds);

                return _result;
            });
            if (_sales == null)
            {
                return;
            }
            _sales.ForEach(x =>
            {
                var row = newRow(false);
                row.Cells[colId.Name].Value = x.Id;
                row.Cells[colPurchaseOrderNo.Name].Value = x.PurchaseOrderNo;
                row.Cells[colInvoiceNo.Name].Value = x.InvoiceNo;
                row.Cells[colToCompany.Name].Value = _Customers?.FirstOrDefault(cus => cus.Id == x.CompanyId)?.Name;
                row.Cells[colToSite.Name].Value = _Sites?.FirstOrDefault(s => s.Id == x.SiteId)?.Name;
                row.Cells[colTotal.Name].Value = x.Total;
                row.Cells[colSaleDate.Name].Value = x.SaleDate.ToShortDateString();
                row.Cells[colViewDetail.Name].Value = BaseResource.ViewDetail;
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
            else if(keyData == Constants.KeyShortcut[SaleSearchKey.InvoiceNo])
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
