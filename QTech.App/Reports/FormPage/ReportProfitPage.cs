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
using QTech.Base.Enums;

namespace QTech.Reports
{
    public partial class ReportProfitPage : ExPage
    {
        public ReportProfitPage()
        {
            InitializeComponent();
            Bind();
            InitAdvanceFilter();
            InitEvent();
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

            cboSource.SetDataSource<PaymentSource>();
        }

        private void InitEvent()
        {
            btnAdvanceSearch.Click += btnAdvanceSearch_Click;
            cboCompany.SelectedIndexChanged += CboCompany_SelectedIndexChanged;
            cboSource.SelectedIndexChanged += CboSource_SelectedIndexChanged;
        }

        private void CboSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var source = (PaymentSource)cboSource.SelectedValue;
            cboProduct.Enabled = cboCompany.Enabled = cboSite.Enabled = source != PaymentSource.Miscellaneous;
        }

        private void CboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            var company = cboCompany.SelectedObject.ItemObject as Customer;
            cboSite.SearchParamFn = () => new SiteSearch() { CustomerId = company == null ? 0 : company.Id };
        }

        public async void View()
        {
            if (inValid() || btnView.Executing)
            {
                return;
            }

            var company = cboCompany.SelectedObject.ItemObject as Customer;
            var site = cboSite.SelectedObject.ItemObject as Site;
            var product = cboProduct.SelectedObject.ItemObject as Product;
            var paymentSource = (PaymentSource)cboSource.SelectedValue;

            var searchParam = new ProfitSearch()
            {
                D1 = dtpPeroid.SelectedPeroid.FromDate.Date,
                D2 = dtpPeroid.SelectedPeroid.ToDate,
                CustomerId = company?.Id ?? 0,
                SiteId = site?.Id ?? 0,
                ProductId = product?.Id ?? 0,
                PaymentSource = paymentSource
            };

            var _Profits = await btnView.RunAsync(() =>
            {
                var result = ReportLogic.Instance.GetProfitData(searchParam);
                return result;
            });

            var reportHeader = new Dictionary<string, object>()
            {
                { "D1" , dtpPeroid.SelectedPeroid.FromDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                { "D2" , dtpPeroid.SelectedPeroid.ToDate.Date.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.ShortDate]) },
                {"PaymentSource",cboSource.Text },
                {"Customer", paymentSource == PaymentSource.Miscellaneous ? "គ្មាន" : cboCompany.Text },
                {"Site", paymentSource == PaymentSource.Miscellaneous ? "គ្មាន" : cboSite.Text},
                {"Product",paymentSource == PaymentSource.Miscellaneous ? "គ្មាន" : cboProduct.Text }
            };

            DataTable profitDt = new DataTable("Profit");
            using (var reader = ObjectReader.Create(_Profits))
            {
                profitDt.Load(reader);
            }
            var profitDts = new List<DataTable>();
            profitDts.Add(profitDt);

            var report = await btnView.RunAsync(() =>
            {
                var r = ReportHelper.Instance.Load(nameof(ReportProfit), profitDts, reportHeader);
                r.SummaryInfo.ReportTitle = BaseResource.ReportProfit;
                return r;
            });

            if (report != null)
            {
                viewer.View(report);
            }
        }

        private bool inValid()
        {
            _isAdvanceInvalid = false;
            if (!dtpPeroid.IsSelected())
            {
                return true;
            }

            if (!cboCompany.IsSelected() | !cboSite.IsSelected())
            {
                _isAdvanceInvalid = true;
                btnAdvanceSearch.ShowValidation(BaseResource.MsgPleaseSelectValue);
                return true;
            }
            return false;
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

        ComboBox cboSource = new ComboBox()
        {
            Name = nameof(cboSource),
            DropDownStyle = ComboBoxStyle.DropDownList
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
            CustomSearchForm = () => new SelectProductDialog(new ProductSearch(), true),
        };


        private void InitAdvanceFilter()
        {
            _advanceFilters = new Dictionary<string, Control>()
            {
                {cboSource.Name, cboSource },
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
        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            Find();
        }
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

        private void btnAdvanceSearch_Click_1(object sender, EventArgs e)
        {
            Find();
        }
    }
}
