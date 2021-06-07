
using EasyServer.Domain.Models;
using EasyServer.Domain.SearchModels;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using res = EasyServer.Domain;

namespace QTech.Component
{
    public static class EasyServer
    {

        //public static void SetDataSource<T>(this ComboBox cbo, IEnumerable<T> source) where T:BaseListModel
        //{
        //    if (source != null)
        //    {
        //        cbo.ValueMember = "Id";
        //        //cbo.DisplayMember = 

        //        //PropertyInfo[] pis = typeof(T).GetProperties();
        //        //if (pis.Count() > 0)
        //        //{
        //        //    cbo.ValueMember = pis[0].Name;
        //        //    cbo.DisplayMember = pis.Count() > 1 ? pis[1].Name : pis[0].Name;
        //        //}
        //        cbo.DataSource = source.ToList();
        //    }
        //}

        public static void SetDataSource2<T>(this ComboBox cbo, IEnumerable<T> source)
        {
            if (source != null)
            { 
                PropertyInfo[] pis = typeof(T).GetProperties();
                if (pis.Count() > 0)
                {
                    if (typeof(T)== typeof(DropDownItemModel))
                    {
                        cbo.ValueMember = nameof(DropDownItemModel.Id);
                        cbo.DisplayMember = nameof(DropDownItemModel.Code);
                    }
                    else
                    {
                        cbo.ValueMember = pis[0].Name;
                        cbo.DisplayMember = pis.Count() > 1 ? pis[1].Name : pis[0].Name;
                    }
                }
                cbo.DataSource = source.ToList();
               
            }
        }

        /// <summary>
        /// Set Enum to ComboBox Source 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cbo"></param>
        /// <param name="all"></param>
        /// <param name="ignores"></param>
        public static void SetDataSource<T>(this ComboBox cbo, string all = "", params Enum[] ignores) where T : struct
        { 
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T is not an Enum type");
            if (ignores == null)
            {
                ignores = new Enum[] { };
            }

            var source = Enum.GetValues(typeof(T))
                .Cast<object>()
                .Where(x => !ignores.Contains(x))
                .Select(k => new KeyValuePair<T?, string>((T)k,ResourceHelper.Translate((Enum)k))).ToList(); 

            if (!string.IsNullOrEmpty(all))
            {
                source.Insert(0, new KeyValuePair<T?, string>(null, string.Format(res.Resources.All_, all)));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = source;
        }
        
        public static List<DropDownItemModel> GetDropDownItemModelByEnum<T>(ISearchModel search, params Enum[] ignores) where T : struct
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T is not an Enum type");
            if (ignores == null)
            {
                ignores = new Enum[] { };
            }
            var source = Enum.GetValues(typeof(T))
                .Cast<object>()
                .Where(x => !ignores.Contains(x))
                .Select(k => new KeyValuePair<int, string>((int)k, ResourceHelper.Translate((Enum)k)))
                .Select(x => new DropDownItemModel
                {
                    Id = x.Key,
                    Code = x.Value,
                    Name = x.Value,
                    ItemObject = x,
                });
            if (!string.IsNullOrEmpty(search.Search))
            {
                source = source.Where(x => x.Name.ToLower().Contains(search.Search.ToLower()));
            }
            if (search?.Paging?.IsPaging == true)
            {
                var iquery = source.AsQueryable();
                source = iquery.GetPaged(search.Paging.CurrentPage, search.Paging.PageSize).Results;
            }
            return source.ToList();
        }
        
        //public static List<DropDownItemModel> DistinctFeederDropDownItemModel(ISearchModel param)
        //{
        //    var lst = new List<DropDownItemModel>();
        //    //var str = new string[] { "-", "0", "F1", "F10", "F11", "F2", "F3", "F4", "F5", "F6",
        //    //            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "22", "30", "31", "32",};
        //    var search = param as FeederSearch;
        //    var str = FeederAPI.Instance.GetDistinctFeeders(search);
        //    var i = 1;
        //    foreach (var value in str)
        //    {
        //        lst.Add(new DropDownItemModel()
        //        {
        //            Id = i++,
        //            Name = value,
        //            Code = value,
        //            ItemObject = value,
        //        });
        //    }
        //    if (!string.IsNullOrEmpty(param.Search))
        //    {
        //        lst = lst.Where(x => x.Name.ToLower().Contains(param.Search.ToLower())).ToList();
        //    }
        //    if (param?.Paging?.IsPaging == true)
        //    {
        //        var iquery = lst.AsQueryable();
        //        lst = iquery.GetPaged(param.Paging.CurrentPage, param.Paging.PageSize).Results.ToList();
        //    }
        //    return lst;
        //}

        /// <summary>
        /// Set BaseModel to ComboBox Source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cbo"></param>
        /// <param name="source"></param>
        /// <param name="all"></param>
        public static void SetDataSource<T>(this ComboBox cbo, IEnumerable<T> source, string all = "")
            where T : BaseModel, new()
        {
            var temp = source.Select(x => new KeyValuePair<int, object>(x.Id, x)).ToList();
            if (!string.IsNullOrEmpty(all))
            {
                temp.Insert(0, new KeyValuePair<int, object>(0, string.Format(res.Resources.All_, all)));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }

        public static void SetDataSource(this ComboBox cbo, IEnumerable<string> source, string all = "")
        {
            var temp = source.Select(x => new KeyValuePair<string, string>(x, x)).ToList();
            if (!string.IsNullOrEmpty(all))
            {
                temp.Insert(0, new KeyValuePair<string, string>(string.Empty, string.Format(res.Resources.All_, all)));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }

        public static void SetIntDatasource(this ComboBox cbo, IEnumerable<int> source)
        {
            var temp = source.Select(x => new KeyValuePair<int, int>(x, x)).ToList();
            //if (!string.IsNullOrEmpty(all))
            //{
            //    temp.Insert(0, new KeyValuePair<int, int>(string.Empty, string.Format(Storm.Domain.Resources.All_, all)));
            //}
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }

        //public static void SetCurrencyDataSource(this ComboBox cbo,List<Currency> source,string all = "") 
        //{
        //    var temp = source.Select(x => new KeyValuePair<int, object>(x.Id, x.Code)).ToList();
        //    if (!string.IsNullOrEmpty(all))
        //    {
        //        temp.Insert(0, new KeyValuePair<int, object>(0, string.Format(EasyServer.Domain.Resources.All_, all)));
        //    }
        //    cbo.ValueMember = "Key";
        //    cbo.DisplayMember = "Value";
        //    cbo.DataSource = temp;
        //}

        /// <summary>
        /// Find all file by name
        /// </summary>
        /// <param name="reportName">eg. InvoiceReport_Misc_ to get all file name starts with InvoiceReport_Misc_</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetInvoiceTemplatePathsByType(string reportPrefix="InvoiceReport")
        {
            var result = new Dictionary<string, string>();
            var extention = ".rpt";
            var rootReportFolder = "";//LocalVariable.ReportLocation;
            //var name = $"Invoice_{(int)invoiceType}_";//
            var moduleReportPath = Path.Combine(rootReportFolder, "Billing"); 
            string[] files = Directory.GetFiles(moduleReportPath, $"*{extention}");
            foreach (string fileDir in files.OrderBy(x => x))
            {
                string fileName = Path.GetFileName(fileDir); 
                if (fileName.StartsWith(reportPrefix))
                {
                    var title = fileName.Replace(reportPrefix, "").Replace(extention, "");  
                    result.Add(fileName.Replace(extention, ""), ResourceHelper.Translate(title));
                }
            }

            return result;
        } 
        //public static void SetInvoiceTemplatePathDataSource(this ComboBox cbo, InvoiceType invoiceType)
        //{ 
        //    // Use Ondemand Like invoice cycled
        //    if (invoiceType == InvoiceType.Ondemand)
        //    {
        //        invoiceType = InvoiceType.Cycled;
        //    }
        //    // Refund | Reverse | Adjustment like Mic
        //    else if(invoiceType == InvoiceType.Refund)
        //    {
        //        invoiceType = InvoiceType.Bond;
        //    }
        //    if(invoiceType == InvoiceType.Adjustment || invoiceType == InvoiceType.Reverse)
        //    {
        //        invoiceType = InvoiceType.Transaction;
        //    }
        //    var templatePaths = GetInvoiceTemplatePathsByType($"InvoiceReport_{invoiceType.ToString()}_");
        //    var temp = templatePaths.Select(x => new KeyValuePair<object, object>(x.Key, x.Value)).ToList();
        //    cbo.ValueMember = "Key";
        //    cbo.DisplayMember = "Value";
        //    cbo.DataSource = temp;
        //}
        public static void SetReadingReportTemplateDataSource(this ComboBox cbo)
        {
            var templatePaths = GetInvoiceTemplatePathsByType("ReadingListReport_");
            var temp = templatePaths.Select(x => new KeyValuePair<object, object>(x.Key, x.Value)).ToList();
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }
        public static void SetEditListReportTemplateDataSource(this ComboBox cbo)
        {
            var templatePaths = GetInvoiceTemplatePathsByType("EditListReport_");
            var temp = templatePaths.Select(x => new KeyValuePair<object, object>(x.Key, x.Value)).ToList();
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }
        public static void SetInstalledPrinterDataSource(this ComboBox cbo)
        {
            var allPrinterName = PrinterSettings.InstalledPrinters.OfType<string>().ToList();
            var temp = allPrinterName.Select(x => new KeyValuePair<object, object>(x, x)).ToList();
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
            cbo.SelectedValue = new PrinterSettings().PrinterName;
        }

        public static void SetLookUpDataSource(this ComboBox cbo, List<Lookup> source, string all = "", bool isValueInt = true)
        {
            
            var temp = (isValueInt) ? 
                source.Select(x => new KeyValuePair<object, object>(x.ValueInt, x.Name)).ToList() :
                source.Select(x => new KeyValuePair<object, object>(x.ValueText, x.Name)).ToList();
            
            if (!string.IsNullOrEmpty(all))
            {
                temp.Insert(0, new KeyValuePair<object, object>((isValueInt) ? "0" : "", string.Format(res.Resources.All_, all)));
            }
            cbo.ValueMember = "Key";
            cbo.DisplayMember = "Value";
            cbo.DataSource = temp;
        }

        public class Domain
        {
        }



        ///// <summary>
        ///// Set BaseModel to ComboBox Source
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="cbo"></param>
        ///// <param name="source"></param>
        ///// <param name="all"></param>
        //public static void SetDataSource<TList>(this ComboBox cbo, IEnumerable<TList> source, string all = "")
        //    where TList: BaseListModel, new()
        //{
        //    var temp = source.Select(x => new KeyValuePair<int, object>(x.Id, x)).ToList();
        //    if (!string.IsNullOrEmpty(all))
        //    {
        //        temp.Insert(0, new KeyValuePair<int, object>(0, string.Format(Storm.Domain.Resources.All_, all)));
        //    }
        //    cbo.ValueMember = "Key";
        //    cbo.DisplayMember = "Value";
        //    cbo.DataSource = temp;
        //}

        //public static void SetDataSource(this ComboBox cbo, IEnumerable<Location> source, string all = "", string choose="")
        //{
        //    var temp = source.Select(x => new KeyValuePair<string, object>(x.Code, x.ToString())).ToList();
        //    if (!string.IsNullOrEmpty(all))
        //    {
        //        temp.Insert(0, new KeyValuePair<string, object>(null, string.Format(Storm.Domain.Resources.All_, all)));
        //    }
        //    if (!string.IsNullOrEmpty(choose))
        //    {
        //        temp.Insert(0, new KeyValuePair<string, object>(null, choose ));
        //    }
        //    cbo.ValueMember = "Key";
        //    cbo.DisplayMember = "Value";
        //    cbo.DataSource = temp;
        //}
    }

   
}
