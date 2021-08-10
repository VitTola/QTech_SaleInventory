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
using QTech.Base.Models;
using QTech.Base.Enums;

namespace QTech.Forms
{
    public partial class IncomeExpensePage : ExPage, IPage
    {

        public IncomeExpensePage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }
        public IncomeExpense Model { get; set; }

        private void Bind()
        {
            cboMiscellaneousType.SetDataSource<Base.Enums.MiscellaneousType>();
        }
        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 28;
            dgv.BackgroundColor = System.Drawing.Color.White;
            
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;
            dgv.AllowRowNotFound = true;
            cboMiscellaneousType.SelectedIndexChanged += CboMiscellaneousType_SelectedIndexChanged;
        }
        private async void CboMiscellaneousType_SelectedIndexChanged(object sender, EventArgs e)
        {
            await Search();
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new IncomeExpense();
            var dig = new frmIncomeExpense(Model, GeneralProcess.Add);
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

            Model = await btnUpdate.RunAsync(() => IncomeExpenseLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmIncomeExpense(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                dgv.RowSelected(colId.Name, dig.Model.Id);
            }
        }
        public async void Reload()
        {
            dgv.AllowRowNotFound = true;
            dgv.AllowRowNumber = true;
            dgv.ColumnHeadersHeight = 28;

            await Search();
        }
        public async void Remove()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => IncomeExpenseLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.IncomeOutcome));
                return;
            }

            Model = await btnRemove.RunAsync(() => IncomeExpenseLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmIncomeExpense(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            var search = new IncomExpenseSearch()
            {
                Search = txtSearch.Text,
                MiscellaneousType = (MiscellaneousType)cboMiscellaneousType.SelectedValue,
                Paging = pagination.Paging
            };

            dgv.Rows.Clear();
            pagination.ListModel = await dgv.RunAsync(() => IncomeExpenseLogic.Instance.SearchAsync(search));
            if (pagination.ListModel != null)
            {
                var _incomeExpenses = pagination.ListModel as List<IncomeExpense>;
                _incomeExpenses.OrderByDescending(x=>x.DoDate).ToList().ForEach(x => {
                    var row = newRow();
                    row.Cells[colId.Name].Value = x.Id;
                    row.Cells[colMiscNo.Name].Value = x.MiscNo;
                    row.Cells[colDoDate.Name].Value = x.DoDate.ToString("dd-MMM-yyyy hh:mm");
                    row.Cells[colAmount.Name].Value = x.Amount;
                    row.Cells[colNote.Name].Value = x.Note;
                    row.Cells[colType.Name].Value = x.MiscellaneousType == MiscellaneousType.Expense ?
                    BaseResource.MiscellaneousType_Expense : BaseResource.MiscellaneousType_Income;
                });
            }
        }
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => IncomeExpenseLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmIncomeExpense(Model, GeneralProcess.View);
            dig.ShowDialog();
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
        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            View();
        }
    }
}
