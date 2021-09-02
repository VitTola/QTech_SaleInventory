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

namespace QTech.Reports
{
    public partial class ReportDriverDeliveryPage : ExPage, IPage
    {

        public ReportDriverDeliveryPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
            InitAdvanceFilter();
        }
        Dictionary<string, Control> _advanceFilters;
        CustomAdvanceFilter dig;


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

            cboCompany.TextAll = BaseResource.Customer;
            var customers = CustomerLogic.Instance.SearchAsync(new CustomerSearch())?.ToList() ?? new List<Customer>();
            var customer = new Customer() { Id = -1, Name = BaseResource.GeneralCustomer };
            customers.Add(customer);
            cboCompany.DataSourceFn = p => customers.ToDropDownItemModelList();
            cboCompany.SearchParamFn = () => new CustomerSearch();
            cboCompany.Choose = BaseResource.Customer;
            cboCompany.Name = BaseResource.Customer;
        }

        private void InitEvent()
        {
            btnAdvanceSearch.Click += btnAdvanceSearch_Click;
            cboCompany.SelectedIndexChanged += CboCompany_SelectedIndexChanged;
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
            await Task.Delay(0);
        }

        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }


            var driver = cboDriver.SelectedObject.ItemObject as Employee;
            var company = cboCompany.SelectedObject.ItemObject as Customer;
            var site = cboSite.SelectedObject.ItemObject as Site;
            var product = cboProduct.SelectedObject.ItemObject as Product;

            var searchParam = new ReportDriverDeliverySearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
                DriverId = driver?.Id ?? 0,
                CustomerId = company?.Id ?? 0,
                SiteId = site?.Id ?? 0,
                ProductId = product?.Id ?? 0
            };


            var driverDeliveryDetails = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetDriverDeliveryDetails(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                {"Driver",cboDriver.Text }
            };


            DataTable driverDeleryDetail = new DataTable("RportDriverDeliveryDetail");
            using (var reader = ObjectReader.Create(driverDeliveryDetails))
            {
                driverDeleryDetail.Load(reader);
            }
            var _driverDeliveryDetails = new List<DataTable>();
            _driverDeliveryDetails.Add(driverDeleryDetail);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(RportDriverDeliveryDetail), _driverDeliveryDetails, reportHeader);
                r.SummaryInfo.ReportTitle = nameof(RportDriverDeliveryDetail);
                return r;
            });

            if (report != null)
            {
                viewer.View(report);
            }
        }

        ExSearchCombo cboDriver = new ExSearchCombo
        {
            Name = BaseResource.Driver,
            TextAll = BaseResource.Driver,
            DataSourceFn = p => EmployeeLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new EmployeeSearch(),
            Choose = BaseResource.Driver,
        };

        ExSearchCombo cboCompany = new ExSearchCombo();

        ExSearchCombo cboSite = new ExSearchCombo
        {
            Name = BaseResource.Site,
            TextAll = BaseResource.Site,
            Choose = BaseResource.Site,
            DataSourceFn = p => SiteLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new SiteSearch() { }
        };

        ExSearchCombo cboProduct = new ExSearchCombo
        {
            Name = BaseResource.Products,
            TextAll = BaseResource.Products,
            Choose = BaseResource.Products,
            DataSourceFn = p => ProductLogic.Instance.SearchAsync(p).ToDropDownItemModelList(),
            SearchParamFn = () => new ProductSearch(),
            CustomSearchForm = () => new SelectProductDialog(new ProductSearch(),true),
        };

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
                {cboProduct.Name, cboProduct },
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
    }
}
