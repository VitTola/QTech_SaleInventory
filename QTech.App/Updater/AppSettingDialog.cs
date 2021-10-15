using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QTech.Component;
using QTech.Component.Helpers;
using QTech.Base.Helpers;
using QTech.Db.Logics;
using BaseResource = QTech.Base.Properties.Resources;
using QTech.Db;

namespace QTech.Forms
{
    public partial class AppSettingDialog : ExDialog
    {
       
        private string[] _userLoggedIn = Properties.Settings.Default.USER_LOGGED_IN?
                                                 .Cast<string>().ToArray() ?? new string[0];

        public AppSettingDialog()
        {
            InitializeComponent();
           
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var _user = await btnSave.RunAsync(() => {
                var user = UserLogic.Instance.GetUserByNameAndPassword(txtUserName.Text, txtPassword.Text);
                if (user == null)
                {
                    MsgBox.ShowWarning( BaseResource.MsgNotCorrectNameOrPassword, BaseResource.Login);
                    return user;
                }

                //ShareValue.CurrentAppVersion = ApplicationVersionLogic.Instance.GetCurrentAppVersion();
                //ShareValue.ServerVersion = ApplicationVersionLogic.Instance.GetCurrentServerVersion();
                
                ShareValue.User = user;
                var userPermissions = UserPermissionLogic.Instance.GetUserPermissionsByUserId(user.Id);
                if (userPermissions != null)
                {
                    var permissionIds = userPermissions.Select(x => x.PermissionId).ToList();
                    ShareValue.permissions = PermissionLogic.Instance.GetPermissionByIds(permissionIds);

                    // Start to get Setting and store in memory
                    if (Properties.Settings.Default.USER_LOGGED_IN == null)
                    {
                        Properties.Settings.Default.USER_LOGGED_IN = new System.Collections.Specialized.StringCollection();
                    }
                    if (!_userLoggedIn.Any(x => x == user.FullName))
                    {
                        Properties.Settings.Default.USER_LOGGED_IN.Add(user.FullName);
                    }
                    Properties.Settings.Default.LAST_USER_LOGGED = user.Id;
                    Properties.Settings.Default.Save();
                }
                return user;
            });
            if (_user == null)
            {
                return;
            }
            this.Hide();
            var dig = new MainForm();
            dig.Show();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //Environment.Exit(0);
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, new EventArgs());
            }
        }
        private void txtUserName_Enter(object sender, EventArgs e)
        {
            txtUserName.SelectAll();
        }
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.SelectAll();
        }
        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            txtUserName.HideValidation();
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.HideValidation();
        }
        private void DisableAuthorize()
        {
            this.txtPassword.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            btnSave.Enabled = false;
        }
        private void EnableAuthorize()
        {
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            btnSave.Enabled = true;
        }
        private async void LoginDialog_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void container_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
