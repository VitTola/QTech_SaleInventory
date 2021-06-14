﻿using QTech.Base;
using QTech.Component;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Base.Helpers;
using QTech.Base.SearchModels;
using QTech.Db.Logics;
using QTech.Db;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Base.BaseModels;

namespace QTech.Forms
{
    public partial class EmployeePage : ExPage, IPage
    {
        public Employee Model { get; set; }
        public EmployeePage()
        {
            InitializeComponent();
        }

        public async void AddNew()
        {
            var employee = new Employee();
            var dig = new frmEmployee(Model, GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                Model = dig.model;
            }
        }

        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.Update);

            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
               // dgv.RowSelected(colId.Name, dig.Model.Id);
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
            var canRemove = await btnRemove.RunAsync(() => EmployeeLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Employees));
                return;
            }

            Model = await btnRemove.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new EmployeeSearch()
            {
                Search = txtSearch.Text,
                
                Paging = new Paging()
                {
                    PageSize = pagination.Paging.PageSize,
                    CurrentPage = pagination.CurrentPage,
                    IsPaging = pagination.IsPaging
                }
            };

            var result = await dgv.RunAsync(() => EmployeeLogic.Instance.Search(search));
            pagination.ListModel = result._ToDataTable();
            var temp = pagination.ListModel;
            dgv.DataSource = temp;
        }

        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => EmployeeLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmEmployee(Model, GeneralProcess.View);
            dig.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Remove();

        }

    }
}
