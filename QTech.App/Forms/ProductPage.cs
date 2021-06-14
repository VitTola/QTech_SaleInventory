using QTech.Component;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QTech.Forms
{
    public partial class ProductPage : ExPage, IPage
    {
       
        public ProductPage()
        {
            InitializeComponent();

        }

        public void AddNew()
        {
            throw new NotImplementedException();
        }

        public void EditAsync()
        {
            throw new NotImplementedException();
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
            new frmCustomer().ShowDialog();
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
