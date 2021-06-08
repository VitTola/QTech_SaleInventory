using Storm.Component;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using QTech.Component;
using QTech.Base.BaseModels;
using QTech.Base.Enums;
using QTech.Base;

namespace Storm.UI
{
    public partial class MainForm : ExDialog
    {
        /// <summary>
        /// All menus...
        /// </summary>
        private List<MenuBar> _menuBars = new List<MenuBar>();
        /// <summary>
        /// Save page controls.
        /// </summary>
        private Dictionary<string, Form> _pages = new Dictionary<string, Form>();
        AuthKey currentKeyTab;
        DebounceDispatcher debounce = new DebounceDispatcher();
        public static List<BaseModule> AllModuleRegistry = new List<BaseModule>();
        private ExTabItem _lastExtabitem = null;

        /// <summary>
        /// Save selected nav item.
        /// </summary>
        private Dictionary<AuthKey, NavItem> _navSelectedItem = new Dictionary<AuthKey, NavItem>();
        private bool _userTerminated = false;
        private bool _firstTabClick = true;

        public MainForm()
        {
            InitializeComponent();
            ShowIcon = true;

            // check Domain Version easy to debug.
            txtDomain.Text ="Domain: "+typeof(User).Assembly.GetName().Version.ToString();
            // Perform layout 
            container.SuspendLayout();
            topPanel.SuspendLayout();
            pBottom.SuspendLayout();
            pBranch.SuspendLayout();
            mainPanel.SuspendLayout();
            graPanel2.SuspendLayout();
            graPanel3.SuspendLayout();
            sidePanel.SuspendLayout();
            pContainBottom.SuspendLayout();
            SuspendLayout();
            // Start SocketIO
            // StartSocketIo();
            // Apply setting.
            ApplySetting();
           // Text = $"{ShareAPI.Instance.Company.Code} - {ShareAPI.Instance.Company.Name}"; 
            Text = "ឃ្យូតិច"; 
            container.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            pBottom.ResumeLayout(false);
            pBottom.PerformLayout();
            pBranch.ResumeLayout(false);
            pBranch.PerformLayout();
            mainPanel.ResumeLayout(false);
            graPanel2.ResumeLayout(false);
            graPanel3.ResumeLayout(false);
            sidePanel.ResumeLayout(false);
            pContainBottom.ResumeLayout(false);
            ResumeLayout(false);
            ResourceHelper.ApplyResource(this);
            this.InitForm();
            //initRequiredSocketEvent();
            this.OptimizeLoadUI();
            pLeftMenu.HorizontalScroll.Maximum = 1;
            pLeftMenu.VerticalScroll.Maximum = 1;
           // lblDemoVersion.Visible = !LocalVariable.ProductionMode;
        }

        private void ApplySetting()
        {
            try
            {
                txtLogin.Text = DateTime.Now.ToLongDateString();
               // var userName = ShareAPI.Instance.FormalUserName;
                var userName = "tola";
                txtUserName.Text = userName.Length >= 30 ? userName.Substring(0, 30) + "..." : userName;
                txtVersion.Text = "v1.0";
                _lblLinkServer.Text = "v1.0.0";


                #if DEBUG
                _lbSocket.Visible = true;
                _lbSocketStatus.Visible = true;
                //_lblLinkServer.Visible = true;
                #endif


                // check replace updater
                //if (File.Exists(Path.Combine(Application.StartupPath, "Updater_1.exe")))
                //{
                //    var filename = "Updater.exe";
                //    // remove old updater
                //    File.Delete(Path.Combine(Application.StartupPath, filename));
                //    // rename new updater
                //    File.Move("Updater_1.exe", filename);
                //}

                var moduleManager = ModuleManager.Instance;
                foreach (var module in AllModuleRegistry = moduleManager.Modules)
                {
                    var rsxMgr = module.GetResourceManger();
                    if (rsxMgr != null)
                    {
                        ResourceHelper.Register(rsxMgr);
                    } 
                }
                _menuBars = moduleManager.GetMenubars();
                InitMenu();
                //Get All Report after register all modules
                ResourceHelper.ApplyResource(mainPanel);
            }
            catch (Exception ex)
            {
                MsgBox.ShowError(ex);
            }
        }

        public void InitMenu()
        {
           // _menuBars = _menuBars.Where(x => ShareAPI.Instance.IsAuthorized(x.Key)).ToList();
            // bad practice will check later
            var firstMenu = _menuBars.OrderBy(x => x.Index).FirstOrDefault(x => x.Level == 1);
            if (firstMenu != null)
            {
                firstMenu.Children.ForEach(x => x.IsCollapse = false);
            }

            ReadTopMenu(_menuBars); 
        }

        public void ReadLeftMenu(MenuBar menuBar)
        {
            if (menuBar == null)
            {
                return;
            }
            NavItem selectedNavitem = null;
            NavGroup navCollapseSelected = null;
            if (_navSelectedItem.ContainsKey(currentKeyTab))
            {
                selectedNavitem = _navSelectedItem[menuBar.Key];
            }
            var level2Menubar = menuBar.Children.Where(x => x.Level == 2).ToList();
            /*
             * Invisible other NavGroup.
             */
            inVisible(level2Menubar);

            /*
             * Find exists NavGroup.
             */
            IEnumerable<NavGroup> groups = pLeftMenu.Controls.OfType<NavGroup>()
                .Where(x => level2Menubar.Select(z => z.Key.ToString())
                .Contains(x.Name)); 
            if (groups.Any())
            {
                foreach (var group in groups)
                {
                    group.Visible = true;
                    var navItems = group.Body.Controls.OfType<NavItem>();
                    foreach (var item in navItems)
                    {
                        item.Visible = true;
                    }
                } 
            }
            else
            {
                //level2Menubar = level2Menubar.Where(x => ShareAPI.Instance.IsAuthorized(x.Key)).ToList();
                level2Menubar.OrderByDescending(x => x.Index).ToList()
                    .ForEach(x =>
                    {
                        NavGroup navGroup = newNavGroup(x);
                        if (x.Children == null) x.Children = new List<MenuBar>();
                        var level3Menubar = x.Children?.Where(y => y.ParentKey == x.Key).ToList();
                        //level3Menubar = level3Menubar.Where(lv3m => ShareAPI.Instance.IsAuthorized(lv3m.Key)).ToList();
                        // Update Module location to each children who don't have module location!!!!
                        // level3Menubar.ForEach(l => l.ModuleLocation = moduleLocation);
                        var level3MenubarOrdered = level3Menubar.OrderByDescending(ord => ord.Index).ToList();
                        level3MenubarOrdered.ForEach(l =>
                        {
                            var item = newNavItem(l);
                            //item.Image = Properties.Resources.bullet;
                            navGroup.AddChild(item);
                        });
                        pLeftMenu.Controls.Add(navGroup);
                        navGroup.Collapse = x.IsCollapse;
                    }
                );

                //Init Selected navitem
                if (selectedNavitem == null)
                {
                    selectedNavitem = pLeftMenu.Controls.OfType<NavGroup>()
                        .SelectMany(x => x.Body.Controls.OfType<NavItem>())
                        .LastOrDefault();
                }
                if (navCollapseSelected == null)
                {
                    navCollapseSelected = pLeftMenu.Controls.OfType<NavGroup>().LastOrDefault();
                }
            }
            if (!_firstTabClick)
            {
                if (navCollapseSelected != null)
                {
                    navCollapseSelected.Collapse = true;
                }
            }
            if (selectedNavitem != null)
            {
               // debounce.Debounce(10, p => NavItem_Click(selectedNavitem, EventArgs.Empty));
            }
        }

        private NavItem newNavItem(MenuBar l)
        {
            var navItem =  new NavItem()
            {
                Name = l.FormName,
                Text = l.DisplayName,
                Image = l.Icon,
                ImageAlign = ContentAlignment.TopLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Tag = l,
                Font = new Font("Khmer Os System", 8.25F),
            };
            navItem.Click += NavItem_Click;
            return navItem;
        }

        private static NavGroup newNavGroup(MenuBar menu)
        {
            return new NavGroup()
            {
                Name = menu.Key.ToString(),
                Text = "  " + menu.DisplayName,
                Collapse = false,
                Dock = DockStyle.Top,
                Font = new Font("Khmer Os System", 8.25F),
                Tag =  menu
            };
        }

        private void inVisible(List<MenuBar> level2Menubar)
        {
            IEnumerable<NavGroup> others = pLeftMenu.Controls.OfType<NavGroup>()
                        .Where(x => level2Menubar.Select(z => z.Key.ToString())
                        .Contains(x.Name) == false);
            foreach (var other in others)
            {
                other.Visible = false;
                var otherItems = other.Body.Controls.OfType<NavItem>();
                foreach (var item in otherItems)
                {
                    item.Visible = false;
                }
            }
        }

        private void NavItem_Click(object sender, EventArgs e)
        {
            var navItem = (NavItem)sender;
            var selectedMenu = (MenuBar)navItem.Tag;
            if (selectedMenu.Option == MenuOption.Page)
            {
                navItem._Selected = true;
                pMenuHeader.Text = navItem.Text;

                ShowPage(navItem.Name, selectedMenu.ModuleLocation);
                _navSelectedItem[currentKeyTab]= navItem;
            }
            if (selectedMenu.Option == MenuOption.Dialog)
            {
                navItem._Selected = false;
                ShowDialog(navItem.Name, selectedMenu.ModuleLocation);
            }
            if (selectedMenu.Option == MenuOption.ReportPage)
            {
                navItem._Selected = true;
                pMenuHeader.Text = navItem.Text;

                //ShowReportPage(selectedMenu);
                ShowPage(navItem.Name, selectedMenu.ModuleLocation);
                _navSelectedItem[currentKeyTab] = navItem;
            }
        }

        public void ReadTopMenu(List<MenuBar> topMenuBars)
        {
            if (topMenuBars == null)
            {
                return;
            }
            topMenuBars.OrderByDescending(x => x.Index).ToList()
                .ForEach(x =>
                {
                    var exTab = new ExTabItem
                    {
                        Name = x.FormName,
                        Tag = x.Key,
                        Text = x.DisplayName,
                        Image = x.Icon,
                        TextAlignment = ContentAlignment.MiddleLeft,
                        BorderStyle = BorderStyle.None,
                        Padding = new Padding() { All = 0 }
                    };
                    pTopMenu.AddTabItem(exTab);
                    exTab.Click += ExTabOnClick;
                    _lastExtabitem = exTab;
                });
            if (_lastExtabitem != null)
            {
                ExTabOnClick(_lastExtabitem, EventArgs.Empty);
                _lastExtabitem.Selected = true;
            }
            _firstTabClick = false;
        }

        private void ExTabOnClick(object sender, EventArgs eventArgs)
        {
            var key = ((ExTabItem) sender).Tag ?? string.Empty;
            var navMenu = _menuBars.FirstOrDefault(y => y.Key.ToString() == key.ToString());
            currentKeyTab = navMenu.Key;
            pTopMenu.Text = navMenu.DisplayName;
            pMenuHeader.Image = navMenu.Icon;
            // clear menu bar
            pHeaderLefrMenu.Text = navMenu.DisplayName;
            pHeaderLefrMenu.Image = navMenu.Icon;
            ReadLeftMenu(navMenu);
        }

        public void ShowPage(string formname,string moduleLocation)
        {
            if (string.IsNullOrEmpty(formname))
            {
                return;
            }
            if (_pages.ContainsKey(formname) == false)
            {
                Assembly assembly = Assembly.LoadFrom(moduleLocation);
                Type type = assembly.GetType(formname);
                if (!(Activator.CreateInstance(type) is Form form)) return;
                form.TopLevel = false;
                form.Enabled = true;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pContainForm.Controls.Add(form);
                _pages.Add(formname,form);
                ResourceHelper.ApplyResource(form);
                form.Show(); 
            }
            if (pContainForm.Tag is Form oldForm)
            {
                oldForm.Hide();
            }

            pContainForm.Controls.SetChildIndex(_pages[formname], 0);
            pContainForm.Tag = _pages[formname];
            _pages[formname].Show();
            pContainForm.SelectNextControl(pContainForm, true, true, true, true);
            if (_pages[formname] is IPage page)
            {
                page.Reload();
                _lastPage = _pages[formname];
            }
            if (_pages[formname] is IPageReport pageReport)
            {
                pageReport.Reload();
                _lastPage = _pages[formname]; 
            }
        }

        // Last Page on Open Dialog and after close will refresh
        private Form _lastPage;
        public void ShowDialog(string formname, string moduleLocation)
        {
            if (_pages.ContainsKey(formname) == false)
            {
                Assembly assembly = Assembly.LoadFrom(moduleLocation);
                Type type = assembly.GetType(formname);
                var form = Activator.CreateInstance(type) as Form;
                form.ShowDialog();
                if(_lastPage != null && _lastPage is IPage page)
                {
                    page.Reload();
                }
                
                //if (form == null) return;
                //_pages.Add(formname, form);
            }
            //var currentForm = _pages[formname];
            //currentForm.ShowDialog();

            //if (_previouseSelectedItem?.Tag is MenuBar menu)
            //{
            //    if (menu.Option != MenuOption.Dialog)
            //    {
            //        NavItem_Click(_previouseSelectedItem, EventArgs.Empty);
            //    }
            //}
        }

        private void lblVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //var dialog = new AboutUsDialog();
            //dialog.ShowDialog();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            //var dialog = new AboutUsDialog();
            //dialog.ShowDialog();
        }

        private void txtUserName_Click(object sender, EventArgs e)
        {
            var p = Point.Add(lblUserProfile_.PointToScreen(new Point(0, -79)), new Size(0, lblUserProfile_.Height));

            //Point p = new Point(lblUserProfile_.Left, pContainBottom.Top - cnmStrip.Height + 22);
            cnmStrip.Show(p);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {        
            Application.Restart();
            Environment.Exit(0);
        }
        private void txtDomain_Click(object sender, EventArgs e)
        {
            menuSwitchLinkServer.Show((Cursor.Position.X - 60), (Cursor.Position.Y - 60));
        }

        private void SessionTerminated(int delay)
        {
            //var delayTimer = (int)TimeSpan.FromSeconds(delay).TotalMilliseconds;
            //new DebounceDispatcher().Debounce(delayTimer, p =>
            //{
            //    Application.Exit();
            //});

            //var diag = new UserSessionTerminatedDialog(delay);
            //delayTimer = diag.delay;
            //if (diag.ShowDialog()== DialogResult.Cancel)
            //{
            //    this.Invoke((MethodInvoker)delegate
            //    {
            //        Application.Exit();
            //    });
            //}
        }


        //private async Task<bool> signOutUser(Guid sessionId, string logOutBy)
        //{
        //    //var signedOut = UserSessionAPI.Instance.SignOut(ShareAPI.Instance.SessionId, logOutBy);
        //    //if (!signedOut)
        //    //{
        //    //    UserSessionAPI.Instance.WriteFailSessionSignOut(_userSession);
        //    //}
        //    //await Task.Delay(0);
        //    //return signedOut;
        //}

        //private void initRequiredSocketEvent()
        //{

        //    // Listen event <<disconnect>>
        //    // to update socket status on UI
        //    ShareAPI.Instance.Socket.On("disconnect", data =>
        //    {
        //        // Log event to text file
        //        // ShareAPI.Instance.Log("disconnect", data.ToString());

        //        if (!this.IsDisposed)
        //        {
        //            _lbSocket.Invoke((MethodInvoker)delegate
        //            {
        //                _lbSocketStatus.Image = Properties.Resources.img_diconnected;
        //            });
        //        }
        //    });


        //    // Listen event << Socket.EVENT_CONNECT >>
        //    // to update socket status on UI
        //    // and re-join room when connection is back
        //    ShareAPI.Instance.Socket.On(Socket.EVENT_CONNECT, data =>
        //    {
        //        // Log event to text file
        //        // ShareAPI.Instance.Log(Socket.EVENT_CONNECT, data == null ? string.Empty : data.ToString());
        //        foreach (var room in SocketRoomExtension._rooms)
        //        {
        //            ShareAPI.Instance.Socket.ReJoinRoom(room);
        //        }

        //        if (ShareAPI.Instance.Socket.Io().ReadyState == Manager.ReadyStateEnum.OPEN)
        //        {
        //            if (_lbSocket.InvokeRequired)
        //            {
        //                _lbSocket.Invoke((MethodInvoker)delegate
        //                {
        //                    _lbSocketStatus.Image = Properties.Resources.img_active;
        //                });
        //            }
        //        }
        //    });


        //    // Listen event << Terminate-{SessionId} >>
        //    // to inform user and exit application then initial callback data to local var _userSession
        //    // callback data has data like: TerminatedBy ...
        //    // _userSession: use to update UserSession when sign out
        //    ShareAPI.Instance.Socket.ListenRoom<UserSession>("Terminate-" + ShareAPI.Instance.SessionId, (data) =>
        //      {
        //          _userSession = data;
        //          SessionTerminated(30);
        //      });

        //    // Listen event << BranchSettingChanged-{BranchId} >>
        //    // to real-time reload Branch data when data was updated by other user
        //    ShareAPI.Instance.Socket.ListenRoom($"BranchSettingChanged-{ShareAPI.Instance.Branch.Id}", (data) =>
        //    {
        //        ShareAPI.Instance.Branch = ShareAPI.Instance.Branch.Reload();
        //        if (txtBranch.InvokeRequired)
        //        {
        //            txtBranch.Invoke(new MethodInvoker(() =>
        //            {
        //                txtBranch.Text = ShareAPI.Instance.Branch?.Name ?? string.Empty;
        //            }));
        //        }
        //    });

        //    // Listen event << CompanySettingChanged-{BranchId} >>
        //    // to real-time reload Company data when data was updated by other user
        //    ShareAPI.Instance.Socket.ListenRoom($"CompanySettingChanged-{ShareAPI.Instance.Company.Id}", (data) =>
        //    {
        //        ShareAPI.Instance.Company = ShareAPI.Instance.Company.Reload();
        //        if (this.InvokeRequired)
        //        {
        //            this.Invoke(new MethodInvoker(() =>
        //            {
        //                this.Text = $"{ShareAPI.Instance.Company?.Code ?? string.Empty} - {ShareAPI.Instance.Company?.Name ?? string.Empty}";
        //            }));
        //        }
        //    });


        //    /*
        //     * User Session Block 
        //     */
        //    ShareAPI.Instance.Socket.JoinRoom($"Session-{ShareAPI.Instance.SessionId}");

        //    ShareAPI.Instance.Socket.On($"alive:Session-{ShareAPI.Instance.SessionId}", data =>
        //    {
        //        // Log event to text file
        //        // ShareAPI.Instance.Log($"Session-{ShareAPI.Instance.SessionId}", data.ToString());

        //        ShareAPI.Instance.Socket.Emit($"alive", $"Session-{ShareAPI.Instance.SessionId}");
        //    });

        //    ShareAPI.Instance.Socket.ListenRoom($"Session-{ShareAPI.Instance.SessionId}", (data) =>
        //    {
        //        // Log event to text file
        //        // ShareAPI.Instance.Log($"Session-{ShareAPI.Instance.SessionId}", data.ToString());

        //        if (data.ToString() == Consts.CMDSocketTerminate)
        //        {
        //            this.Invoke((MethodInvoker)delegate
        //            {
        //                this.Enabled = false;
        //            });
                    
        //            MsgBox.ShowWarning(Resources.MsgUserWasLoggedIn, this.Text);
        //            Application.Exit();
        //        }
        //    });
        //}

        private async void MainForm_Load(object sender, EventArgs e)
        {
            /*
             * Init required socket.io event
             * then save user-session
             * In process save user-session, worker start to check active session or broken session
             * Then broadcast msg back to client (allow or not...)
             * So need to make sure Socket state is ready to send & recieve notify
             */
            //if (ShareAPI.Instance.Socket != null)
            //{
            //    if (ShareAPI.Instance.Socket.Io().ReadyState != Manager.ReadyStateEnum.OPEN)
            //    {
            //        // prevent if socket.io not ready
            //        // delay for 3 sec to wait for it
            //        await Task.Delay(3000);
            //    }
            //}
            //await Task.Run(() =>
            //{
            //    //SocketClient.Instance.InitOperationEvent();
            //    initRequiredSocketEvent();

            //    ShareAPI.Instance.GrantedBranches = UserGrantAPI.Instance.UserGrantBranchesCompanies(new UserGrantBranchCompanySearch() { UserId = ShareAPI.Instance.User.Id });

            //    UserSessionAPI.Instance.Add(new UserSession()
            //    {
            //        Id = ShareAPI.Instance.SessionId,
            //        UserId = ShareAPI.Instance.User.Id,
            //        LastActivity = "SignedIn" /*Helpers.Consts.SignedIn*/,
            //        Status = Domain.Enums.UserSessionStatus.Active
            //    });

                
            //});
        }
         

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!this.IsDisposed)
            //{
            //    string loggedOutBy = _userSession?.LogOutBy ?? string.Empty;
            //    this.Invoke((MethodInvoker)async delegate
            //    {
            //        await signOutUser(_userSession.Id, loggedOutBy);
            //    });
            //}
        }
    }
}
