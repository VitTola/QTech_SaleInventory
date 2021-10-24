using QTech.Base.BaseModules;
using QTech.Base.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using BaseResource = QTech.Base.Properties.Resources;

namespace QTech.Base.BaseModels
{
    public abstract class BaseModule
    {
        public string Path { get; set; }
        public virtual ResourceManager GetResourceManger()
        {
            return null;
        }
        public abstract List<MenuBar> GetMenuBars();
        public abstract List<Report> GetReports();
        public abstract string GetDisplayName();
        public abstract string GetDescription();
    }

    public class MenuBar
    {
        public string DisplayName { get; set; }
        public string FormName { get; set; }
        public int Index { get; set; }
        public AuthKey Key { get; set; }
        public AuthKey ParentKey { get; set; }
        public int Level { get; set; }
        public MenuOption Option { get; set; }
        public List<MenuBar> Children { get; set; }
        public AuthKey ReportParentKey { get; set; }
        public Image Icon { get; set; }
        public string ModuleLocation { get; set; }
        public bool IsCollapse { get; set; } = true;
    }

    public class Report
    {
        public string DisplayName { get; set; }
        public string ReportFormName { get; set; }
        public int Index { get; set; }
        public int Level { get; set; }
        public AuthKey Key { get; set; }
        public AuthKey ParentKey { get; set; }
        public AuthKey BaseModuleKey { get; set; }
        public string ModuleLocation { get; set; }
        public List<Report> Children { get; set; } = new List<Report>();
    }
    public enum MenuOption
    {
        Dialog = 1,
        Page,
        ReportPage
    }

    public class ModuleManager
    {
        protected static Lazy<ModuleManager> _instance = new Lazy<ModuleManager>(() => new ModuleManager());
        public static ModuleManager Instance => _instance.Value;
        public readonly Dictionary<AuthKey, string> _registries = new Dictionary<AuthKey, string>();
        public readonly Dictionary<AuthKey, Assembly> Assemblies = new Dictionary<AuthKey, Assembly>();
        private readonly List<Report> _reports = new List<Report>();

        public readonly List<MenuBar> _secondLevelMenue = new List<MenuBar>()
        {
            new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Employee_Employee,
                ParentKey = AuthKey.Employee,
                DisplayName = BaseResource.Employees,
                Icon = BaseResource.GeneralEmployee,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.EmployeePage"
            },
            new MenuBar()
            {
                Index = 2,
                Level = 2,
                Key = AuthKey.Employee_EmployeeBill,
                ParentKey = AuthKey.Employee,
                DisplayName = BaseResource.RuningBill,
                Icon = BaseResource.RunningBill_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.EmployeeBillingPage"
            },
         
            new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Product_Product,
                ParentKey = AuthKey.Product,
                DisplayName = BaseResource.Products,
                Icon = BaseResource.Product32x32,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.ProductPage"
            },
              new MenuBar()
            {
                Index = 2,
                Level = 2,
                Key = AuthKey.Product_Category,
                ParentKey = AuthKey.Product,
                DisplayName = BaseResource.Categorys,
                Icon = BaseResource.categorie_ing,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CategoryPage"

            },
            new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Sale_Sale,
                ParentKey = AuthKey.Sale,
                DisplayName = BaseResource.Sales,
                Icon = BaseResource.sale_img32,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.SalePage"

            },
            new MenuBar()
            {
                Index = 2,
                Level = 2,
                Key = AuthKey.Sale_CreateInvoice,
                ParentKey = AuthKey.Sale,
                DisplayName = BaseResource.CreateInvoice,
                Icon = BaseResource.Report_img32,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CreateInvoicePage"

            },
            new MenuBar()
            {
                Index = 3,
                Level = 2,
                Key = AuthKey.Sale_PurchaseOrder,
                ParentKey = AuthKey.Sale,
                DisplayName = BaseResource.PurchaseOrderNo,
                Icon = BaseResource.PurchaseOrder_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.PurchaseOrderPage"

            },
              new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Setting_User,
                ParentKey = AuthKey.Setting,
                DisplayName = BaseResource.User_Text,
                Icon = BaseResource.user_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.UserPage"

            },
             new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Customer_Customer,
                ParentKey = AuthKey.Customer,
                DisplayName = BaseResource.Customer,
                Icon = BaseResource.Customer_img32,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CustomerPage"

            },
             new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.General_IncomeOutcome,
                ParentKey = AuthKey.General,
                DisplayName = BaseResource.IncomeOutcome,
                Icon = BaseResource.IncomeOutcome_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.IncomeExpensePage"

            },
              new MenuBar()
            {
                Index = 1,
                Level = 2,
                Key = AuthKey.Report_DriverDeliveryDetail,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportDriverDeliveryDetail,
                Icon = BaseResource.delivery,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportDriverDeliveryPage"

            },
              new MenuBar()
            {
                Index = 3,
                Level = 2,
                Key = AuthKey.Report_IncomeExpense,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportIncomeExpense,
                Icon = BaseResource.InOut,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportIncomeExpensePage"

            },
              new MenuBar()
            {
                Index = 4,
                Level = 2,
                Key = AuthKey.Report_Income,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportIncome,
                Icon = BaseResource.Income_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportImcomePage"

            },
             new MenuBar()
            {
                Index = 5,
                Level = 2,
                Key = AuthKey.Report_Expense,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportExpense,
                Icon = BaseResource.expenses_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportExpensePage"

            },
            new MenuBar()
            {
                Index = 6,
                Level = 2,
                Key = AuthKey.Report_Profit,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportProfit,
                Icon = BaseResource.ProfitImg,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportProfitPage"

            },
            new MenuBar()
            {
                Index = 2,
                Level = 2,
                Key = AuthKey.Report_InvoiceStatus,
                ParentKey = AuthKey.Report,
                DisplayName = BaseResource.ReportInvoiceStatus,
                Icon = BaseResource.invoice_status_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Reports.ReportInvoiceStatus"

            },

        };

        public readonly List<MenuBar> _menuBars = new List<MenuBar>()
        {
            new MenuBar()
            {
                Index = 2,
                Level = 1,
                Key = AuthKey.Employee,
                DisplayName = BaseResource.Employees,
                Icon = BaseResource.Employee_img,
                Children = new List<MenuBar>(),
                FormName = ""
            },
            new MenuBar()
            {
                Index = 5,
                Level = 1,
                Key = AuthKey.Customer,
                DisplayName = BaseResource.Customer,
                Icon = BaseResource.customer2,
                Children = new List<MenuBar>(),
                FormName = ""

            },
            new MenuBar()
            {
                Index = 3,
                Level = 1,
                Key = AuthKey.Product,
                DisplayName = BaseResource.Products,
                Icon = BaseResource.Product_img,
                Children = new List<MenuBar>(),
                FormName = ""

            },
            new MenuBar()
            {
                Index = 1,
                Level = 1,
                Key = AuthKey.Sale,
                DisplayName = BaseResource.Sales,
                Icon = BaseResource.Sale_img,
                Children = new List<MenuBar>(),
                FormName = ""

            },
            new MenuBar()
            {
                Index = 6,
                Level = 1,
                Key = AuthKey.Report,
                //DisplayName = BaseResource.Report_,
                DisplayName = "របាយការណ៍   ",
                Icon = BaseResource.CloseDateEntery_img,
                Children = new List<MenuBar>(),
                FormName = ""
            },
             new MenuBar()
            {
                Index = 4,
                Level = 1,
                Key = AuthKey.Setting,
                DisplayName = BaseResource.Setting_Text,
                Icon = BaseResource.Setting_img,
                Children = new List<MenuBar>(),
                FormName = ""
            },
          new MenuBar()
            {
                Index = 7,
                Level = 1,
                Key = AuthKey.General,
                DisplayName = BaseResource.General_,
                Icon = BaseResource.General_img,
                Children = new List<MenuBar>(),
                FormName = ""
            },
        };


        //init registered dll
        public ModuleManager()
        {
            //_registries[AuthKey.Employee] = Path.Combine("Storm.Billing.dll");

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
                var assembly = Assembly.LoadFrom(registry.Value);
                Assemblies[registry.Key] = assembly;
                var type = assembly.GetType(assembly.DefinedTypes.FirstOrDefault(x => x.BaseType == typeof(BaseModule)).FullName);
                var module = (BaseModule)Activator.CreateInstance(type);

                module.Path = registry.Value;
                if (!_modules.Contains(module))
                {
                    _modules.Add(module);
                }
            }
        }

        public List<MenuBar> GetMenubars()
        {
            foreach (var module in Modules)
            {
                //Add not if not exists
                var menus = module.GetMenuBars().Where(x => !_menuBars.Any(m => m.Key == x.Key)).ToList();
                menus.ForEach(x =>
                {
                    if (string.IsNullOrEmpty(x.ModuleLocation)) x.ModuleLocation = module.Path;
                });
                RearrangeMenuHierachy(menus);
            }
            return _menuBars;
        }

        public List<Report> GetAllReports()
        {
            foreach (var module in Modules)
            {
                var reports = module.GetReports().OrderBy(x => x.Index).ToList();
                reports.ForEach(x => x.ModuleLocation = (!string.IsNullOrEmpty(x.ModuleLocation)) ? x.ModuleLocation : module.Path);
                _reports.AddRange(reports);
            }
            var arrangedReports = RearrangeReportHiarachy();
            return arrangedReports;
        }

        public List<Report> RearrangeReportHiarachy()
        {
            var topLevelReport = _reports.Where(x => x.Level == 1).ToList();
            topLevelReport.ForEach(tl =>
            {
                tl.Children.AddRange(_reports.Where(x => x.ParentKey == tl.Key && x.Level == 2).OrderByDescending(x => x.Index).ToList());

                var lv3Children = _reports.Where(ch => ch.Level == 3).ToList();
                foreach (var item in lv3Children.Select(x => x.ParentKey).Distinct())
                {
                    var lv2 = tl.Children.FirstOrDefault(x => x.Key == item);
                    if (lv2 != null)
                    {
                        if (lv2.Children == null)
                        {
                            lv2.Children = new List<Report>();
                        }

                        var currentlv3Children = lv3Children.Where(x => x.ParentKey == item).OrderByDescending(x => x.Index).ToList();
                        var lv3ChildrenCrossModule = currentlv3Children.Where(x => string.IsNullOrEmpty(x.ReportFormName) || string.IsNullOrEmpty(x.ModuleLocation)).ToList();

                        if (lv3ChildrenCrossModule.Any())
                        {
                            lv3ChildrenCrossModule.ForEach(x =>
                            {
                                var sourceReport = lv3Children.FirstOrDefault(lv3 => lv3.Key == x.Key && !string.IsNullOrEmpty(lv3.ReportFormName));
                                currentlv3Children.FirstOrDefault(clv3 => clv3.Key == x.Key).ModuleLocation = sourceReport.ModuleLocation;
                                currentlv3Children.FirstOrDefault(clv3 => clv3.Key == x.Key).ReportFormName = sourceReport.ReportFormName;
                            });
                        }

                        lv2.Children.AddRange(currentlv3Children);
                    }
                }
            });

            return topLevelReport;
        }

        public void RearrangeMenuHierachy(List<MenuBar> menuBars)
        {
            List<MenuBar> toplevelMenu = null;
            toplevelMenu = _menuBars.Where(x => x.Level == 1).ToList();
            toplevelMenu.ForEach(l1 =>
            {
                l1.Children.AddRange(menuBars.Where(y => y.ParentKey == l1.Key && y.Level == 2));

                var lv3 = menuBars.Where(y => y.Level == 3);
                foreach (var item in lv3.Select(x => x.ParentKey).Distinct())
                {
                    var lv2 = l1.Children.FirstOrDefault(x => x.Key == item);
                    if (lv2 != null)
                    {
                        if (lv2.Children == null)
                        {
                            lv2.Children = new List<MenuBar>();
                        }
                        lv2.Children.AddRange(lv3.Where(x => x.ParentKey == lv2.Key));
                    }
                }
            });
        }

        public object GetInstanceObject(AuthKey moduleKey, string className, params object[] args)
        {
            var type = Assemblies[moduleKey].ExportedTypes.FirstOrDefault(x => x.Name == className);
            var obj = Activator.CreateInstance(type, args);
            return obj;
        }

    }
}
