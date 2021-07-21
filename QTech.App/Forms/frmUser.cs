
using QTech.Base.Helpers;
using QTech.Base.Models;
using QTech.Base.SearchModels;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Db.Logics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BaseResource = QTech.Base.Properties.Resources;
namespace QTech.Forms
{
    public partial class frmUser : ExDialog, IDialog
    {
        public frmUser(User model, GeneralProcess flag)
        {
            InitializeComponent();
            Model = model;
            Flag = flag;
            this.SetEnabled(flag != GeneralProcess.Remove && flag != GeneralProcess.View);
            this.Text = Flag.GetTextDialog(BaseResource.User_Text);
            Bind();
            Read();
            InitEvent();
        }

        public GeneralProcess Flag { get; set; }
        public User Model { get; set; }
        List<Permission> _permission;
        bool _isBinding = true;
        int _userId;

        public async void Bind()
        {
            _permission = await this.RunAsync(() =>
            {
                return PermissionLogic.Instance.SearchAsync(new PermissionSearch());
            });
            TreeNode treeNode = AddNodes(new Permission()
            {
                Id = 0,
                Name = string.Format(BaseResource.All_, BaseResource.Permission),
            });

            treeNode.Expand();
            trvPermission.Nodes.Add(treeNode);
            if (trvPermission.TopNode != null)
            {
                CheckNodeAfterAddedNode(trvPermission.TopNode);
            }

            _isBinding = false;
        }

        public void InitEvent()
        {
            txtAccount.RegisterKeyEnterNextControlWith(txtPassword, trvPermission);
            txtAccount.RegisterPrimaryInputWith(txtPassword);
        }

        public bool InValid()
        {
            if (!txtAccount.IsValidRequired(_lblAccount.Text))
            {
                return true;
            }
            return false;
        }

        public void Read()
        {
            txtAccount.Text = Model.Name ?? string.Empty;
        }

        public async void Save()
        {
            if (Flag == GeneralProcess.View)
            {
                this.Close();
            }
            if (this.Executing || btnSave.Executing)
            {
                return;
            }

            if (InValid())
            {
                return;
            }

            Write();

            var isExists = await btnSave.RunAsync(() => UserLogic.Instance.IsExistsAsync(Model));
            if (isExists == null)
            {
                return;

            }
            if (isExists == true)
            {
                txtAccount.IsExists(txtAccount.Text);
                return;
            }


            await btnSave.RunAsync(() =>
            {
                if (Flag == GeneralProcess.Add)
                {
                    Model = UserLogic.Instance.AddAsync(Model);
                }
                else if (Flag == GeneralProcess.Update)
                {
                    Model = UserLogic.Instance.UpdateAsync(Model);
                }
                else if (Flag == GeneralProcess.Remove)
                {
                    Model = UserLogic.Instance.RemoveAsync(Model);
                }
                return Model;
            });
            if (Model != null)
            {
                DialogResult = DialogResult.OK;
            }
        }

        public void ViewChangeLog()
        {
            //AuditTrailDialog.ShowChangeLog(Model);
        }

        public void Write()
        {
            Model.FullName = txtAccount.Text;
            Model.PasswordHash = txtPassword.Text;
            Model.Name = txtUserName.Text;
            Model.Note = txtNote.Text;
            
            trvPermission.CollapseAll();
            var permission = GetNodeChecked(trvPermission.TopNode);
           // Model.UserPermissions = permission;
        }

        private TreeNode AddNodes(Permission permission)
        {
            TreeNode node = new TreeNode(permission.Name);
            node.Tag = permission.Id;
            if (!_permission.Select(x => x.ParentId).Contains(permission.Id))
            {
                node.Checked = Model.UserPermissions?.Select(x => x.PermissionId).Contains(permission.Id) ?? false;
            }
            foreach (var p in _permission.Where(x => x.ParentId == permission.Id))
            {
                node.Nodes.Add(AddNodes(p));
            }

            return node;
        }

        private List<Permission> GetNodeChecked(TreeNode node)
        {
            var rolePermissions = new List<Permission>();
            var _rolePermission = Model.UserPermissions?.FirstOrDefault(x => x.PermissionId == (int)node.Tag);
            //if (_rolePermission != null)
            //{
            //    if(_rolePermission.Active != node.Checked)
            //    {
            //        _rolePermission.Active = node.Checked;
            //        rolePermissions.Add(_rolePermission);
            //    }
            //}
            //else if ((node.Checked) && (int)node.Tag != 0)
            //{
            //    _rolePermission = new Permission()
            //    {
            //        PermissionId = (int)node.Tag,
            //        RoleId = Model.Id,
            //    };
            //    rolePermissions.Add(_rolePermission);
            //}
            //foreach (TreeNode nodes in node.Nodes)
            //{
            //    rolePermissions.AddRange(GetNodeChecked(nodes));
            //}
            return rolePermissions;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Save();
        }

        private int CountNode(TreeNode treeNode)
        {
            int i = 0;
            foreach (TreeNode node in treeNode.Nodes)
            {
                i += CountNode(node);
            }
            return i + 1;
        }

        private void trvPermission_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!_isBinding)
            {
                if (Flag == GeneralProcess.View || Flag == GeneralProcess.Remove)
                {
                    e.Cancel = true;
                }
                else if ((int)e.Node.Tag != 0)
                {
                    //e.Cancel = !_currentUserPermissionId.Contains((int)e.Node.Tag);
                    e.Cancel = false;
                }
            }
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ViewChangeLog();
        }

        private void CheckNodeAfterAddedNode(TreeNode node)
        {
            if (node.Nodes.Count == 0)
            {
                node.Checked = !node.Checked;
                trvPermission.CheckAll(new TreeNodeMouseClickEventArgs(node, MouseButtons.Left, 1, 0, 0));
            }
            foreach (TreeNode treeNode in node.Nodes)
            {
                CheckNodeAfterAddedNode(treeNode);
            }
        }
    }
}
