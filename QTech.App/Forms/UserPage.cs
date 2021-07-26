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

namespace QTech.Forms
{
    public partial class UserPage : ExPage, IPage
    {
        public UserPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }
        public User Model { get; set; }
        private void Bind()
        {
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
        }
        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }
        public async void AddNew()
        {
            Model = new User();
            var dig = new frmUser(Model, GeneralProcess.Add);
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
            Model = await btnUpdate.RunAsync(() => UserLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmUser(Model, GeneralProcess.Update);
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

            var id = (int)dgv.CurrentRow.Cells[colId.Name].Value;
            var canRemove = await btnRemove.RunAsync(() => UserLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.User_Text));
                return;
            }

            Model = await btnRemove.RunAsync(() => UserLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmUser(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }
        public async Task Search()
        {
            var search = new UserSearch()
            {
                Search = txtSearch.Text,
            };

            dgv.DataSource = null;
            var result = await dgv.RunAsync(() => UserLogic.Instance.SearchAsync(search));
            if (result != null)
            {
                dgv.DataSource = result._ToDataTable();
            }
        }
        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;
            Model = await btnUpdate.RunAsync(() => UserLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmUser(Model, GeneralProcess.View);
            dig.ShowDialog();
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
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dgv.Rows[e.RowIndex].Cells[colRow_.Name].Value = (e.RowIndex + 1).ToString();
        }
    }
}
