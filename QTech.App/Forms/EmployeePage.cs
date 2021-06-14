using QTech.Base;
using QTech.Component;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Base.Helpers;
using QTech.Db.Logics;
using QTech.Db;

namespace QTech.Forms
{
    public partial class EmployeePage : ExPage, IPage
    {
        public Employee Model { get; set; }
        //private static QTechDbContext db = new QTechDbContext();
        //private  readonly EmployeeLogic _logic = new EmployeeLogic(db);


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

            ////if (Model == null)
            //{
            //    return;
            //}

            //var dig = new MainStatusDialog(Model, GeneralProcess.Update);

            //if (dig.ShowDialog() == DialogResult.OK)
            //{
            //    await Search();
            //    dgv.RowSelected(colId.Name, dig.Model.Id);
            //}
        }

        public void Reload()
        {
            
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        public Task Search()
        {
            throw new NotImplementedException();
        }

        public void View()
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            new frmCustomer().ShowDialog();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            new frmCustomer().ShowDialog();

        }
    }
}
