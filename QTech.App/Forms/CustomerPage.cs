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

namespace QTech.Forms
{
    public partial class CustomerPage : ExPage, IPage
    {
       
        public CustomerPage()
        {
            InitializeComponent();

        }
        private bool isNodeCollapsed { get; set; } = false;
        private Customer selectedModel { get; set; } = null;
        public Customer Model { get; set; }

        private void InitEvent()
        {
            dgv.RowsDefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(173, 205, 239);
            dgv.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            dgv.RowTemplate.Height = 28;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 28;
            dgv.BackgroundColor = System.Drawing.Color.White;
            dgv.ShowLines = false;
            dgv.ShowLines = true;
            

            dgv.KeyDown += dgv_KeyDown;
            dgv.NodeExpanded += Dgv_NodeExpanded;
            dgv.NodeCollapsed += Dgv_NodeCollapsed;
            txtSearch.RegisterEnglishInput();
            txtSearch.RegisterKeyArrowDown(dgv);
            txtSearch.QuickSearch += txtSearch_QuickSearch;

        }

      

        private void txtSearch_QuickSearch(object sender, EventArgs e)
        {
            Search();
        }

        private void Dgv_NodeCollapsed(object sender, CollapsedEventArgs e)
        {
            isNodeCollapsed = true;
        }

        private async void Dgv_NodeExpanded(object sender, ExpandedEventArgs e)
        {
            if (e.Node.Tag is Customer parent)
            {
                //In case top level node is expanded manually
                if (parent.Id == int.Parse(BaseResource.TopLevelNodeId))
                {
                    return;
                }
                                    
                e.Node.Nodes.Clear();
                var search = new CustomerSearch()
                {
                    Id = parent.Id
                };
                var customers = await dgv.RunAsync(() => CustomerLogic.Instance.SearchAsync(search).FirstOrDefault());

                if (customers.Sites.Any())
                {
                    var dummy = e.Node.Nodes.Add();
                    dummy.Visible = false;
                    AddChildNode(e.Node, customers.Sites, parent);
                    return;
                }
            }

            if (selectedModel != null)
            {
                var childRow = dgv.Rows.Cast<TreeGridNode>().FirstOrDefault(x => x.Tag is Customer station && station.Name == selectedModel.Name);
                if (childRow != null)
                {
                    childRow.Selected = true;
                }

                selectedModel = null;
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                dgv.CurrentNode?.Expand();
            }
            else if (e.KeyCode == Keys.Left)
            {
                dgv.CurrentNode?.Collapse();
            }
        }

        private void RefreshAfterOperation(Customer model)
        {
            //var parentNode = dgv.Rows.Cast<TreeGridNode>().FirstOrDefault(x => x.Tag is Site site && site.Id == model);
            //if (parentNode != null)
            //{
            //    parentNode.Selected = true;
            //    if (parentNode.IsExpanded)
            //    {
            //        parentNode.Collapse();
            //    }
            //    parentNode.Expand();
            //}
        }

        public async void AddNew()
        {
            var customer = new Customer() ;
            var dig = new frmCustomer(customer,GeneralProcess.Add);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
                selectedModel = dig.Model;
                RefreshAfterOperation(selectedModel);
            }
        }

        public async void EditAsync()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => CustomerLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.Update);

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
            var canRemove = await btnRemove.RunAsync(() => CustomerLogic.Instance.CanRemoveAsync(id));
            if (canRemove == false)
            {
                MsgBox.ShowWarning(EasyServer.Domain.Resources.RowCannotBeRemoved,
                    GeneralProcess.Remove.GetTextDialog(BaseResource.Employees));
                return;
            }

            Model = await btnRemove.RunAsync(() => CustomerLogic.Instance.FindAsync(id));
            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.Remove);
            if (dig.ShowDialog() == DialogResult.OK)
            {
                await Search();
            }
        }

        public async Task Search()
        {
            var search = new CustomerSearch()
            {
                Search = txtSearch.Text,
            };

            var result = await dgv.RunAsync(() => CustomerLogic.Instance.SearchAsync(search));
            if (result != null)
            {
                 TreeGridFillData(result);
            }
        }
        private void TreeGridFillData(List<Customer> customers)
        {
            if (customers == null)
            {
                return;
            }

            dgv.Nodes.Clear();
            var topLevelNode = new Customer { Id = 0, Name = BaseResource.AllCustomer };
            TreeGridNode _topLevelTreeGridNode = AddParentNode(dgv, topLevelNode);
            dgv.NodeExpanded -= Dgv_NodeExpanded;
            _topLevelTreeGridNode.Expand();
            dgv.NodeExpanded += Dgv_NodeExpanded;

            foreach (var parent in customers)
            {
                var _treeGridNode = AddParentNode(_topLevelTreeGridNode, parent);
            
                if (parent.Sites.Any())
                {
                    AddChildNode(_treeGridNode, parent.Sites, parent);
                    dgv.NodeExpanded -= Dgv_NodeExpanded;
                    _treeGridNode.Expand();
                    dgv.NodeExpanded += Dgv_NodeExpanded;
                }

                var dummy = _treeGridNode.Nodes.Add();
                dummy.Visible = false;
            }
        }
        private void AddChildNode(TreeGridNode TreeGridNode, IEnumerable<Site> children, Customer parent)
        {
            foreach (var child in children)
            {
                var node = TreeGridNode.Nodes.Add();
                var font = dgv.DefaultCellStyle.Font;
                node.Height = dgv.RowTemplate.Height;
                node.Tag = child;
                node.Height = dgv.RowTemplate.Height;
                node.Image = imageList1.Images[nameof(BaseResource.Site_img)];
                node.Cells[dgv.Columns[colName.Name].Index].Value = child.Name;
                node.Cells[dgv.Columns[colPhone.Name].Index].Value = child.Phone;
                node.Cells[dgv.Columns[colNote.Name].Index].Value = child.Note;
                node.Cells[dgv.Columns[colId.Name].Index].Value = child.Id;
               
            }
        }

        private TreeGridNode AddParentNode(dynamic parentNode, Customer customer)
        {
            var node = parentNode.Nodes.Add();
            node.Height = dgv.RowTemplate.Height;
            node.Tag = customer;

            node.Image = imageList1.Images[nameof(BaseResource.Customer_img)];
            node.Cells[dgv.Columns[colName.Name].Index].Value = customer?.Name;
            node.Cells[dgv.Columns[colPhone.Name].Index].Value = customer?.Phone;
            node.Cells[dgv.Columns[colNote.Name].Index].Value = customer.Note;
            node.Cells[dgv.Columns[colId.Name].Index].Value = customer.Id;
            var dummy = node.Nodes.Add();
            dummy.Visible = false;
            return node;
        }

        public async void View()
        {
            if (dgv.SelectedRows.Count == 0)
            {
                return;
            }

            var id = (int)dgv.SelectedRows[0].Cells[colId.Name].Value;

            Model = await btnUpdate.RunAsync(() => CustomerLogic.Instance.FindAsync(id));

            if (Model == null)
            {
                return;
            }

            var dig = new frmCustomer(Model, GeneralProcess.View);
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

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            View();
        }
    }
}
