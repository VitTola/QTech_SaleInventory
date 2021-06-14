
//           +********************+
//           *  DISIGN BY MR TOLA *
//           **********************
using EasyServer.Domain.Enums;
using QTech.Base.BaseModels;
using QTech.Component;
using QTech.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SaleInventory
{
    public partial class frmMain : ExDialog
    {
        public readonly List<Assembly> Assemblies = new List<Assembly>();

        public readonly List<string> _registries = new List<string>()
        {
            Path.Combine(Directory.GetCurrentDirectory() ,"QTech.Base.dll"),
        };

        public frmMain()
        {
            InitializeComponent();
            timer1.Start();
            this.MinimizeBox = true;
            ResourceHelper.Register(QTech.Base.Properties.Resources.ResourceManager);
            InitEvent();
        }

        private void InitEvent()
        {
            btnAccSetting.Enabled = btnCate.Enabled = btnImp.Enabled = btnLogOut.Enabled =
                btnImpRe.Enabled = btnSup.Enabled  = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.FormClosed += (o, fe) => Application.Exit();
            this.WindowState = FormWindowState.Maximized;
            this.Athorization();
            timer1.Tick += (o, te) => { lblTime.Text = DateTime.Now.ToLongTimeString(); };
            lblDate.Text = DateTime.Now.ToLongDateString();
            //lblUser.Text = Operation.EmpName;
           // btnEmployee.Click += (o, ee) => { new frmEmployee().ShowDialog(); };
            //btnSup.Click += (o, se) => { new frmSupplier().ShowDialog(); };
            btnPro.Click += (o, pe) => { new frmProduct().ShowDialog(); };
            btnSale.Click += (o, se) => { new frmSale().ShowDialog(); };
            //btnSaleRe.Click += (o, se) => { new frmSaleReport().ShowDialog(); };
            //btnImp.Click += (o, se) => { new frmImport().ShowDialog(); };
            //btnImpRe.Click += (o, ie) => { new frmImportReport().ShowDialog(); };
            //btnAccSetting.Click += (o, se) => { new frmCreateAccount().ShowDialog(); };
            btnCus.Click += (o, ce) => { new frmCustomer().ShowDialog(); };
            //btnLogOut.Click += (o, le) => { this.Hide(); new frmLogin().Show(); };
            //btnCate.Click += (o, ce) => { new frmCategory().ShowDialog(); };
        }

        private void Athorization()
        {
        //    if (Operation.EmpPos == "admin" && Operation.EmpID != "0")
        //    {
        //        return;
        //    }
        //    else if (Operation.EmpPos == "seller")
        //    {
        //        btnImp.Enabled = btnImpRe.Enabled = btnEmployee.Enabled = btnSup.Enabled = btnPro.Enabled =
        //            btnCate.Enabled = false;
        //    }
        //    else if (Operation.EmpPos == "stockman")
        //    {
        //        btnEmployee.Enabled = btnCus.Enabled = btnSale.Enabled = btnSaleRe.Enabled = false;
        //    }
        //    else
        //    {
        //        btnImp.Enabled = btnImpRe.Enabled = btnSup.Enabled = btnPro.Enabled = btnCate.Enabled =
        //            btnCus.Enabled = btnSale.Enabled = btnSaleRe.Enabled = false;
        //    }
        }



        private readonly List<BaseModule> _modules = new List<BaseModule>();
        public List<BaseModule> Modules
        {
            get
            {
                // check if Module never load then load it 
                if (!_modules.Any())
                {
                    LoadModules();
                }
                return _modules;
            }
        }

        public void LoadModules()
        {
            foreach (var registry in _registries)
            {
                var assembly = Assembly.LoadFrom(registry);
                var type = assembly.GetType(assembly.DefinedTypes.FirstOrDefault(x => x.BaseType == typeof(BaseModule)).FullName);
                var module = (BaseModule)Activator.CreateInstance(type);

                module.Path = registry;
                if (!_modules.Contains(module))
                {
                    _modules.Add(module);
                }
            }
        }

        private void ApplyResource()
        {
            foreach (var module in _modules)
            {
                var rsxMgr = module.GetResourceManger();
                if (rsxMgr != null)
                {
                    ResourceHelper.Register(rsxMgr);
                }
            }
        }




    }




}
