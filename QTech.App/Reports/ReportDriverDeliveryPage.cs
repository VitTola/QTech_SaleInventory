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

namespace QTech.Forms
{
    public partial class ReportDriverDeliveryPage : ExPage, IPage
    {

        public ReportDriverDeliveryPage()
        {
            InitializeComponent();
            Bind();
            InitEvent();

        }
        private bool isNodeCollapsed { get; set; } = false;
        private Customer selectedModel { get; set; } = null;
        public Customer Model { get; set; }

        private void Bind()
        {
            
        }
        private void InitEvent()
        {
           

        }


        private async void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            await Search();
        }

        private void Dgv_NodeCollapsed(object sender, CollapsedEventArgs e)
        {
            
        }

        private async void Dgv_NodeExpanded(object sender, ExpandedEventArgs e)
        {
            
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void RefreshAfterOperation(Customer model)
        {
            
        }

        public async void AddNew()
        { }

        public async void EditAsync()
        {
           
        }

        public async void Reload()
        {
            await Search();
        }

        public async void Remove()
        {
            
        }

        public async Task Search()
        {
            
        }
        
      

       

        public async void View()
        {
            
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
