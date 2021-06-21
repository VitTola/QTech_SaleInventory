using QTech.Base;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Db.Logics;
using System;
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
            rdtpPicker.CustomDateRang = CustomDateRang.AsOfDate;
            var peroids = ExReportDatePicker.GetPeroids(maxDate);
            var customPeroid = ExReportDatePicker.GetPeriod(rdtpPicker.CustomDateRang, maxDate);
            rdtpPicker.SetMaxDate(maxDate);
            rdtpPicker.Items.AddRange(peroids.ToArray());
            rdtpPicker.Items.Add(customPeroid);
            rdtpPicker.SetSelectePeroid(DatePeroid.Today);
        }

        private void InitEvent()
        {
            registerSearchMenu();
            this.Text = BaseResource.Sales;
        }

        public async void AddNew()
        {
            var sale = new Sale();
            var dig = new frmSale(sale, GeneralProcess.Add);
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

            Model = await btnUpdate.RunAsync(() => SaleLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

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

            var result = await dgv.RunAsync(() => SaleLogic.Instance.SearchAsync(search));
            if (result == null)
            {
                return;
            }
            dgv.DataSource = result._ToDataTable();


            //dgv.Rows[0].Cells[colViewDetail.Name].Value = "មើលលម្អិត";
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
            //txtSearch.AddMenuPattern(
            //    RequestSearchKey.RequestNo.ToString(),
            //    RequestSearchKey.RequestNo,
            //    Properties.Resources.imgRequestNo,
            //    Properties.Resources.RequestNo,
            //    Constants.KeyShortcut[RequestSearchKey.RequestNo],
            //    (s, e) =>
            //    {
            //        InputLanguage.CurrentInputLanguage = UI.English;
            //        txtSearch.ReadOnly = false;
            //    });

            //txtSearch.AddMenuPattern(
            //    RequestSearchKey.GeneralInformation.ToString(),
            //    RequestSearchKey.GeneralInformation,
            //    Properties.Resources.customer,
            //    Properties.Resources.GeneralInformation,
            //    Constants.KeyShortcut[RequestSearchKey.GeneralInformation],
            //    (s, e) =>
            //    {
            //        InputLanguage.CurrentInputLanguage = UI.Primary;
            //        txtSearch.ReadOnly = false;
            //    });

            //txtSearch.AddMenuPattern(
            //    RequestSearchKey.RequestGroupNo.ToString(),
            //    RequestSearchKey.RequestGroupNo,
            //    Properties.Resources.imgRequestGroupNo,
            //    Properties.Resources.RequestGroupNo,
            //    Constants.KeyShortcut[RequestSearchKey.RequestGroupNo],
            //    (s, e) =>
            //    {
            //        InputLanguage.CurrentInputLanguage = UI.English;
            //        txtSearch.ReadOnly = false;
            //    });
            //txtSearch.AddSeperator();
            //txtSearch.AddMenuPattern(
            //    RequestSearchKey.AdvanceSearch.ToString(),
            //    RequestSearchKey.AdvanceSearch,
            //    Properties.Resources.filter,
            //    Storm.Domain.Resources.AdvanceSearch,
            //    Constants.KeyShortcut[RequestSearchKey.AdvanceSearch],
            //    (s, e) =>
            //    {
            //        InputLanguage.CurrentInputLanguage = UI.English;
            //        txtSearch.ReadOnly = true;
            //        btnAdvanceSearch_Click(btnAdvanceSearch, EventArgs.Empty);
            //    });
  
            //InputLanguage.CurrentInputLanguage = UI.English;
            //txtSearch.ShowMenuPattern(RequestSearchKey.RequestNo);
            //changeDataVisible();
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
    }
}
