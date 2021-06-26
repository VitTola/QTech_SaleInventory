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
            //new MenuBar()
            //{
            //    Index = 1,
            //    Level = 2,
            //    ParentKey = AuthKey.Employee,
            //    DisplayName = BaseResource.Employees+BaseResource.Employees+BaseResource.Employees,
            //    Icon = BaseResource.Driver_img,
            //    Children = new List<MenuBar>(),
            //    FormName = "QTech.Forms.Form1"
            //},
            //new MenuBar()
            //{
            //    Index = 2,
            //    Level = 2,
            //    ParentKey = AuthKey.Customer,
            //    DisplayName = BaseResource.Customer,
            //    Icon = BaseResource.Category_img,
            //    Children = new List<MenuBar>(),
            //    FormName = "QTech.Forms.frmCustomer"

            //},
            new MenuBar()
            {
                Index = 1,
                Level = 2,
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
                ParentKey = AuthKey.Product,
                DisplayName = BaseResource.Categorys,
                Icon = BaseResource.Type_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CategoryPage"

            },
            //new MenuBar()
            //{
            //    Index = 4,
            //    Level = 2,
            //    ParentKey = AuthKey.Sale,
            //    DisplayName = BaseResource.Sales,
            //    Icon = BaseResource.Type_img,
            //    Children = new List<MenuBar>(),
            //    FormName = "QTech.Forms.frmSale"

            //},
            //new MenuBar()
            //{
            //    Index = 5,
            //    Level = 2,
            //    ParentKey = AuthKey.CloseEntryData,
            //    DisplayName = BaseResource.CloseEntryData,
            //    Icon = BaseResource.Type_img,
            //    Children = new List<MenuBar>(),
            //    FormName = "QTech.Forms.frmEmployeePay"

            //},


        };

        public readonly List<MenuBar> _menuBars = new List<MenuBar>()
        {
            new MenuBar()
            {
                Index = 1,
                Level = 1,
                Key = AuthKey.Employee,
                DisplayName = BaseResource.Employees,
                Icon = BaseResource.Employee_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.EmployeePage"
            },
            new MenuBar()
            {
                Index = 2,
                Level = 1,
                Key = AuthKey.Customer,
                DisplayName = BaseResource.Customer,
                Icon = BaseResource.customer2,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CustomerPage"

            },
            new MenuBar()
            {
                Index = 3,
                Level = 1,
                Key = AuthKey.Product,
                DisplayName = BaseResource.Products,
                Icon = BaseResource.Product_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.ProductPage"

            },
            new MenuBar()
            {
                Index = 4,
                Level = 1,
                Key = AuthKey.Sale,
                DisplayName = BaseResource.Sales,
                Icon = BaseResource.Sale_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.SalePage"

            },
            new MenuBar()
            {
                Index = 5,
                Level = 1,
                Key = AuthKey.CloseEntryData,
                DisplayName = BaseResource.CloseEntryData,
                Icon = BaseResource.CloseDateEntery_img,
                Children = new List<MenuBar>(),
                FormName = "QTech.Forms.CloseDataEntryPage"
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
