
using QTech.Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Component;


namespace QTech.App.Reports

{
    public partial class ReportDriverDiliveryPage : ExPage, IPage
    {
        public ReportDriverDiliveryPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();
        }


      //  CustomAdvanceFilter dig;
       

        private void Bind()
        {
           

        }

        private void InitEvent()
        {

        }

        public void AddNew() { }

        public void Edit() { }

        public async void Reload()
        {
            await Search();
        }

        public void Remove() { }

        public async Task Search()
        {
            await Task.Delay(0);
        }

        public async void View()
        {
           

           
        }

        public void Find()
        {
           
        }

        private bool inValid()
        {
            if (true)
            {
                return true;
            }
            return false;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            View();
        }

        private void btnAdvanceSearch_Click(object sender, EventArgs e)
        {
            Find();
        }

        public void EditAsync()
        {
            throw new NotImplementedException();
        }
    }
}
