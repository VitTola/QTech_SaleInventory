
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
        string _defaultPassword = @"*cuMQ*?EmL9tKqWp";


        public async void Bind()
        {
            _permission = await this.RunAsync(() =>
            {
                if (Model.UserPermissions == null)
                {
                    Model.UserPermissions = new List<UserPermission>();
                }
                Model.UserPermissions = UserPermissionLogic.Instance.GetUserPermissionsByUserId(Model.Id);
                return PermissionLogic.Instance.SearchAsync(new UserPermissionSearch() { UserId = Model.Id});
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
            txtAccount.RegisterKeyEnterNextControlWith(txtPassword, txtConfirmPassword,txtUserName,txtNote);
            txtAccount.RegisterEnglishInputWith(txtPassword,txtConfirmPassword);
            txtNote.RegisterPrimaryInput();
            this.MaximizeBox = false;
        }
        public bool InValid()
        {
            if (!txtAccount.IsValidRequired(_lblAccount.Text)
                | !txtPassword.IsValidRequired(_lblPassword.Text)
                | !txtUserName.IsValidRequired(_lblUserName.Text))
            {
                return true;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                txtConfirmPassword.IsValidRequired(BaseResource.MsgConfirmPasswordNotMatch);
                return true;
            }
            
            return false;
        }
        public void Read()
        {
            txtAccount.Text = Model.FullName ?? string.Empty;
            txtUserName.Text = Model.Name ?? string.Empty;
            txtNote.Text = Model.Note ?? string.Empty;
            if (Flag != GeneralProcess.Add)
            {
                txtPassword.Text = txtConfirmPassword.Text = _defaultPassword;
            }
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
            Model.PasswordHash = txtPassword.Text == _defaultPassword ? string.Empty : txtPassword.Text;
            Model.Name = txtUserName.Text;
            Model.Note = txtNote.Text;
            
            trvPermission.CollapseAll();
            var _userPermission = GetNodeChecked(trvPermission.TopNode);
            Model.UserPermissions = _userPermission;
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
        private List<UserPermission> GetNodeChecked(TreeNode node)
        {
            var userPermissions = new List<UserPermission>();
            var _userPermission = Model.UserPermissions?.FirstOrDefault(x => x.PermissionId == (int)node.Tag);
            if (_userPermission != null)
            {
                if (_userPermission.Active != node.Checked)
                {
                    _userPermission.Active = node.Checked;
                    userPermissions.Add(_userPermission);
                }
            }
            else if ((node.Checked) && (int)node.Tag != 0)
            {
                _userPermission = new UserPermission()
                {
                    PermissionId = (int)node.Tag,
                    UserId = Model.Id,
                };
                userPermissions.Add(_userPermission);
            }
            foreach (TreeNode nodes in node.Nodes)
            {
                userPermissions.AddRange(GetNodeChecked(nodes));
            }
            return userPermissions;
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
