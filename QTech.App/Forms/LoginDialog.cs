using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QTech.Component;
using QTech.Component.Helpers;

namespace QTech.Forms
{
    public partial class LoginDialog : ExDialog
    {
       
        private string[] _userLoggedIn = Properties.Settings.Default.USER_LOGGED_IN?
                                                 .Cast<string>().ToArray() ?? new string[0];
        //public static Action<LoginDialog> ShowSettingFn;
        //string socketId = string.Empty;
        //public delegate void SafeCallDelegate(string text);
        //private bool _isProcessing = false;


        public LoginDialog()
        {
            InitializeComponent();
            txtUserName.RegisterEnglishInputWith(txtPassword);
            txtUserName.RegisterKeyEnterNextControlWith(txtPassword);

            lblDemoVersion.Visible = true;

            //Auto Complete with user logged in
            AutoCompleteStringCollection customAutoComplete = new AutoCompleteStringCollection();
            if (_userLoggedIn.Any())
            {
                foreach (var userLoggedIn in _userLoggedIn)
                {
                    if (!string.IsNullOrEmpty(userLoggedIn))
                    {
                        customAutoComplete.Add(userLoggedIn);
                    }
                }
                txtUserName.AutoCompleteCustomSource = customAutoComplete;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            new MainForm().Show();
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
            btnLogin.Enabled = false;
        }
        private void EnableAuthorize()
        {
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            btnLogin.Enabled = true;
        }

       
        private async void LoginDialog_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
