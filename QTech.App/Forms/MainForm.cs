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
using QTech.Forms;
using BaseResource = QTech.Base.Properties.Resources;

namespace Storm.UI
{
    public partial class MainForm : ExDialog
    {
        private Dictionary<AuthKey, Button> _secondLevelMenue= new Dictionary<AuthKey, Button>();
        private Dictionary<string, Form> _pages = new Dictionary<string, Form>();
        private ExTabItem _lastExtabitem = null;
        private List<MenuBar> _menuBars = new List<MenuBar>();
        private bool _firstTabClick = true;
        AuthKey currentKeyTab;


        public MainForm()
        {
            InitializeComponent();
            InitEvent();
        }

        private void InitEvent()
        {
            this.Text = QTech.Base.Properties.Resources.Company;

            container.SuspendLayout();
            topPanel.SuspendLayout();
            pBottom.SuspendLayout();
            pBranch.SuspendLayout();
            mainPanel.SuspendLayout();
            graPanel2.SuspendLayout();
            graPanel3.SuspendLayout();
            pContainBottom.SuspendLayout();
            SuspendLayout();
            pSecondMenue1.SuspendLayout();
            pSecondMenue2.SuspendLayout();

            ApplySetting();
            pSecondMenue1.ResumeLayout(false);
            pSecondMenue2.ResumeLayout(false);
            container.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            pBottom.ResumeLayout(false);
            pBottom.PerformLayout();
            pBranch.ResumeLayout(false);
            pBranch.PerformLayout();
            mainPanel.ResumeLayout(false);
            graPanel2.ResumeLayout(false);
            graPanel3.ResumeLayout(false);
            pContainBottom.ResumeLayout(false);
            ResumeLayout(false);
            
            ResourceHelper.ApplyResource(this);
            this.InitForm();
            this.OptimizeLoadUI();
            pSecondMenue2.Hide();
            pSecondMenue1.Hide();
        }

        private void ApplySetting()
        {
            var moduleManager = ModuleManager.Instance;
            _menuBars = moduleManager.GetMenubars();
            InitMenu();
        }
        public void InitMenu()
        {
            //CAN CHECK THE WITH AUTHORIZE KEY IN HERE BEFORE READTOPMENUE

            AddTopMenue(_menuBars);
        }

        private void AddTopMenue(List<MenuBar> topMenuBars)
        {
            topMenuBars.OrderByDescending(x => x.Index).ToList()
                .ForEach(x =>
                {
                    var topMenue = new ExTabItem
                    {
                        Name = x.FormName,
                        Tag = x.Key,
                        Text = x.DisplayName,
                        Image = x.Icon,
                        TextAlignment = ContentAlignment.MiddleLeft,
                        BorderStyle = BorderStyle.None,
                        Padding = new Padding() { All = 0 }
                    };
                    pTopMenu.AddTabItem(topMenue);
                    topMenue.Click += TopMenue_Click;
                    _lastExtabitem = topMenue;
                });
            if (_lastExtabitem != null)
            {
                TopMenue_Click(_lastExtabitem, EventArgs.Empty);
                _lastExtabitem.Selected = true;
            }
            _firstTabClick = false;
        }

        private void TopMenue_Click(object sender, EventArgs e)
        {
            var key = ((ExTabItem)sender).Tag ?? string.Empty;
            var navMenu = _menuBars.FirstOrDefault(y => y.Key.ToString() == key.ToString());
            currentKeyTab = navMenu.Key;
            pTopMenu.Text = navMenu.DisplayName;
            ShowPage(navMenu.FormName, navMenu.ModuleLocation);
            ReadSecondLevelMenue(navMenu);

            if (sender is ExTabItem exTab)
            {
                if (exTab.Tag is Form form)
                {
                    pSecondMenue2.Show();
                    pSecondMenue1.Show();

                    FormCollection fc = Application.OpenForms;
                    foreach (Form frm in fc)
                    {
                        if (frm.Name == form.Name)
                        {
                            return;
                        }
                    }

                    form.TopLevel = false;
                    form.Enabled = true;
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.Dock = DockStyle.Fill;
                    pContainForm.Controls.Add(form);
                    _pages.Add(form.Name, form);
                    ResourceHelper.ApplyResource(form);
                    form.Show();
                }

                exTab.MouseClick += (ee, o) => { exTab.BackColor = Color.FromArgb(245, 245, 237); };
                exTab.MouseHover += (ee, o) => { exTab.BackColor = Color.FromArgb(245, 245, 237); };

            }
        }
        public void ShowPage(string formname, string moduleLocation)
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
                _pages.Add(formname, form);
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
        private Form _lastPage;
        public void ShowDialog(string formname, string moduleLocation)
        {
            if (_pages.ContainsKey(formname) == false)
            {
                Assembly assembly = Assembly.LoadFrom(moduleLocation);
                Type type = assembly.GetType(formname);
                var form = Activator.CreateInstance(type) as Form;
                form.ShowDialog();
                if (_lastPage != null && _lastPage is IPage page)
                {
                    page.Reload();
                }
            }
        }

        private void ReadSecondLevelMenue(MenuBar menuBar)
        {
            if (menuBar == null)
            {
                return;
            }








        }

       
        private void copyControl(Control sourceControl, Control targetControl)
        {
            // make sure these are the same
            if (sourceControl.GetType() != targetControl.GetType())
            {
                throw new Exception("Incorrect control types");
            }

            foreach (PropertyInfo sourceProperty in sourceControl.GetType().GetProperties())
            {
                object newValue = sourceProperty.GetValue(sourceControl, null);

                MethodInfo mi = sourceProperty.GetSetMethod(true);
                if (mi != null)
                {
                    sourceProperty.SetValue(targetControl, newValue, null);
                }
            }
        }

        private Button MyTemplateButton(string text, string name, Image image)
        {
            var btn = new Button();
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ImageAlign = ContentAlignment.TopCenter;
            btn.TextAlign = ContentAlignment.BottomCenter;
            btn.Height = 70;
            btn.BackColor = Color.Transparent;
            btn.Text = text;
            btn.Name = name;
            btn.Image = image;


            return btn;
        }

        private void _btnUpDown_Click(object sender, EventArgs e)
        {
            if (pSecondMenue2.Visible == false)
            {
                pSecondMenue2.Show();
                pSecondMenue1.Show();
            }
            else
            {
                pSecondMenue2.Hide();
                pSecondMenue1.Hide();

            }
        }


    }
}
