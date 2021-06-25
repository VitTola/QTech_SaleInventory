using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTech.Base.BaseReport;
using QTech.Base.Helpers;
using QTech.Component;
using QTech.Component.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Storm.CC.Report.Helpers
{
    public class PictureDataColumn
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string Value { get; set; }
    }

    public class ReportHelper
    {
        protected static Lazy<ReportHelper> _instance = new Lazy<ReportHelper>(() => new ReportHelper());
        public ReportHelper()
        {
            RegisterPath(@"Reports");
        }
        public static ReportHelper Instance => _instance.Value;
        public enum Priority
        {
            Hight,
            Low
        }

        private Dictionary<string, object> _defualtParameters = new Dictionary<string, object>
        {
            //{"Company", CCShareValue.Instance.Company.Name},
            //{"CompanyLatian", "ELECTRICITÉ DU CAMBODGE" },
            //{"CompanyPhone", CCShareValue.Instance.Company.Phone },
            //{"CompanyEmail", CCShareValue.Instance.Company.Email },
            //{"CompanyAddress", CCShareValue.Instance.Company.AddressText },
            //{"Branch", CCShareValue.Instance.Branch.Name },
            //{"BranchAddress", CCShareValue.Instance.Branch.AddressText },
            //{"BranchPhone", CCShareValue.Instance.Branch.Phone },
            //{"BranchEmail", CCShareValue.Instance.Branch.Email },
            //{"ViewBy", CCShareValue.Instance.UserFormalName },
            //{"SuppressHeader", false },
            //{"SuppressWatermark", true }
        };

        public List<int> ReportNewConsumerServiceIds = new List<int>() { 32, 36 };
        public List<int> ReportConnectNewMeterServiceIds = new List<int>() { 33, 35 };
        public static int TechnicalDeputyId = 5;

        public List<string> ReportPath { get; private set; } = new List<string>();
        public object CCMediaAPI { get; private set; }

        public void RegisterPath(string path, Priority priority = Priority.Low)
        {
            if (ReportPath.Any(x => x == path))
            {
                return;
            }

            if (priority == Priority.Hight)
            {
                ReportPath.Insert(0, path);
            }
            else
            {
                ReportPath.Add(path);
            }
        }

        public ReportDocument Load(string name, IEnumerable data, Dictionary<string, IEnumerable> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = new List<IEnumerable>() { data };
            Dictionary<string, List<IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key, y => new List<IEnumerable>() { y.Value });
            }

            return Load(name, _data, _subData, parameters);
        }

        public ReportDocument Load(string name, List<IEnumerable> data, Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = data.ToDictionary(x => x.GetType().GetGenericArguments()[0].Name, y => y);
            Dictionary<string, Dictionary<string, IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key
                , y => y.Value.ToDictionary(key => key.GetType().GetGenericArguments()[0].Name, value => value));
            }
            return Load(name, _data, _subData, parameters);
        }

        public ReportDocument Load(string name, Dictionary<string, IEnumerable> data, Dictionary<string, Dictionary<string, IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            ReportDocument report = new ReportDocument();

            name = name.EndsWith(".rpt") ? name : name + ".rpt";
            var fileReport = string.Empty;
            foreach (var path in ReportPath)
            {
                var file = Path.Combine(path, name);
                if (File.Exists(file))
                {
                    fileReport = file;
                    break;
                }
            }
            if (string.IsNullOrEmpty(fileReport))
            {
                report = Load(nameof(ReportNotFound), new List<IEnumerable>());
                return report;
            }
            report.Load(fileReport);
            if (data != null)
            {
                foreach (var table in data)
                {
                    report.Database.Tables[table.Key].SetDataSource(table.Value);
                }
            }
            if (subData != null)
            {
                foreach (var sub in subData)
                {
                    foreach (var table in sub.Value)
                    {
                        report.Subreports[sub.Key].Database.Tables[table.Key].SetDataSource(table.Value);
                    }
                }
            }

            /*
             * Default Parameters.
             */
            //report.SetParameterValue("Company", CCShareValue.Instance.Company.Name);
            //report.SetParameterValue("CompanyLatian", "ELECTRICITÉ DU CAMBODGE");
            //report.SetParameterValue("CompanyPhone", CCShareValue.Instance.Company.Phone);
            //report.SetParameterValue("CompanyEmail", CCShareValue.Instance.Company.Email);
            //report.SetParameterValue("CompanyAddress", CCShareValue.Instance.Company.AddressText);
            //report.SetParameterValue("Branch", CCShareValue.Instance.Branch.Name);
            //report.SetParameterValue("BranchAddress", CCShareValue.Instance.Branch.AddressText);
            //report.SetParameterValue("BranchPhone", CCShareValue.Instance.Branch.Phone);
            //report.SetParameterValue("BranchEmail", CCShareValue.Instance.Branch.Email);
            //report.SetParameterValue("ViewBy", CCShareValue.Instance.UserFormalName);
            //report.SetParameterValue("SuppressHeader", false);
            //report.SetParameterValue("SuppressWatermark", true);

            /*
             * Verify report's parameters before set value.
             */
            var rParameters = report.ParameterFields.OfType<ParameterField>().ToList();

            foreach (var item in _defualtParameters)
            {
                if (rParameters.Any(x => x.Name == item.Key))
                {
                    report.SetParameterValue(item.Key, item.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (rParameters.Any(x => x.Name == item.Key))
                    {
                        report.SetParameterValue(item.Key, item.Value);
                    }
                }
            }

            //report.ReportOptions.ConvertNullFieldToDefault = true;
            //report.ReportOptions.ConvertOtherNullsToDefault = true;

            return report;
        }

        public ReportDocument Load(string name, List<DataTable> data, Dictionary<string, object> parameters = null)
        {
            ReportDocument report = new ReportDocument();
            name = name.EndsWith(".rpt") ? name : name + ".rpt";
            var fileReport = string.Empty;
            foreach (var path in ReportPath)
            {
                var file = Path.Combine(path, name);
                if (File.Exists(file))
                {
                    fileReport = file;
                    break;
                }
            }
            if (string.IsNullOrEmpty(fileReport))
            {
                report = Load(nameof(ReportNotFound), new List<IEnumerable>());
                return report;
            }
            report.Load(fileReport);

            // Report header
            if (parameters == null)
            {
                parameters = new Dictionary<string, object>();
                var dtParam = data.FirstOrDefault(x => x.TableName == "Paramters");
                if (dtParam?.Rows?.Count > 0)
                {
                    parameters = dtParam.Columns.OfType<DataColumn>().ToDictionary(x => x.ColumnName, x => dtParam.Rows[0][x.ColumnName]);
                }
            }

            var dataTable = data.Where(x => x.TableName != "Paramters").ToList();
            var rDt = report.Database.Tables.OfType<Table>().ToList();

            //if (rDt.Any(x => x.Name == "QRCodeReportList"))
            //{
            //    var qrDataTable = generateQRCode(dataTable);
            //    if (qrDataTable != null)
            //    {
            //        dataTable.Add(qrDataTable);
            //    }
            //}

            foreach (var dt in rDt)
            {
                if (dataTable.Any(x => x.TableName == dt.Name))
                {
                    var rdt = report.Database.Tables[dt.Name];
                    var dtVal = dataTable.FirstOrDefault(x => x.TableName == dt.Name);
                    report.Database.Tables[dt.Name].SetDataSource(ExtraColumns(rdt, dtVal));
                }
                else
                {
                    var ndt = this.toDataTable(dt);
                    report.Database.Tables[dt.Name].SetDataSource(ndt);
                }
            }

            var sub = report.Subreports.OfType<ReportDocument>().ToList();
            foreach (var item in sub)
            {
                var sDt = item.Database.Tables.OfType<Table>().ToList();
                foreach (var sdt in sDt)
                {
                    if (dataTable.Any(x => x.TableName == sdt.Name))
                    {
                        var rdt = report.Subreports[item.Name].Database.Tables[sdt.Name];
                        var dtVal = dataTable.FirstOrDefault(x => x.TableName == sdt.Name);
                        report.Subreports[item.Name].Database.Tables[sdt.Name].SetDataSource(ExtraColumns(rdt, dtVal));
                    }
                    else
                    {
                        var ndt = this.toDataTable(sdt);
                        report.Subreports[item.Name].Database.Tables[sdt.Name].SetDataSource(ndt);
                    }
                }
            }

            /*
             * Verify report's parameters before set value.
             */
            var rParameters = report.ParameterFields.OfType<ParameterField>().ToList();

            /*
             * Default Parameters.
             */
            foreach (var item in _defualtParameters)
            {
                if (rParameters.Any(x => x.Name == item.Key))
                {
                    report.SetParameterValue(item.Key, item.Value);
                }
            }

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (rParameters.Any(x => x.Name == item.Key))
                    {
                        report.SetParameterValue(item.Key, item.Value);
                    }
                }
            }

            //report.ReportOptions.ConvertNullFieldToDefault = true;
            //report.ReportOptions.ConvertOtherNullsToDefault = true;

            return report;
        }

       

        //private DataTable generateQRCode(List<DataTable> data)
        //{
        //    if (data?.Any() != true)
        //    {
        //        return null;
        //    }
        //    var requestIds = data.Where(x => x.Columns.OfType<DataColumn>().Any(col => col.ColumnName == "RequestId"))
        //                  .SelectMany(x => x.Rows.OfType<DataRow>().Select(s => s["RequestId"]?.ToString() ?? "")).Distinct().ToList();
        //    if (requestIds?.Any() == true)
        //    {
        //        DataTable qrDataTable = new DataTable();
        //        qrDataTable.TableName = "QRCodeReportList";
        //        qrDataTable.Columns.Add("RequestId");
        //        qrDataTable.Columns.Add("QRCodeImagePath");
        //        foreach (var id in requestIds)
        //        {
        //            var dr = qrDataTable.Rows.Add();
        //            dr["RequestId"] = id;
        //            dr["QRCodeImagePath"] = CC.Domain.Helpers.Crypto.EncryptNoneSpacial(id, Domain.Helpers.Consts.REQUEST_ID_ENCRYPT_KEY).GenerateQRCodeFile();
        //        }
        //        return qrDataTable;
        //    }
        //    return null;
        //}



        private DataTable ExtraColumns(Table table, DataTable dt)
        {
            if (table == null || dt == null)
            {
                return dt;
            }

            foreach (var col in table.Fields.OfType<DatabaseFieldDefinition>())
            {
                if (!dt.Columns.Contains(col.Name))
                {
                    dt.Columns.Add(col.Name);
                }
            }
            return dt;
        }

        private DataTable toDataTable(Table table)
        {
            if (table == null)
            {
                return null;
            }

            var dt = new DataTable(table.Name);
            foreach (var col in table.Fields.OfType<DatabaseFieldDefinition>())
            {
                Type t = typeof(object);
                switch (col.ValueType)
                {
                    case FieldValueType.Int8sField:
                    case FieldValueType.Int8uField:
                        t = typeof(short);
                        break;
                    case FieldValueType.Int16sField:
                    case FieldValueType.Int16uField:
                        t = typeof(int);
                        break;
                    case FieldValueType.Int32sField:
                    case FieldValueType.Int32uField:
                        t = typeof(long);
                        break;
                    case FieldValueType.NumberField:
                    case FieldValueType.CurrencyField:
                        t = typeof(float);
                        break;
                    case FieldValueType.BooleanField:
                        t = typeof(bool);
                        break;
                    case FieldValueType.DateTimeField:
                    case FieldValueType.DateField:
                    case FieldValueType.TimeField:
                        t = typeof(DateTime);
                        break;
                    case FieldValueType.ChartField:
                        t = typeof(char);
                        break;
                    case FieldValueType.StringField:
                        t = typeof(string);
                        break;
                    case FieldValueType.TransientMemoField:
                    case FieldValueType.PersistentMemoField:
                    case FieldValueType.BlobField:
                    case FieldValueType.BitmapField:
                    case FieldValueType.IconField:
                    case FieldValueType.PictureField:
                    case FieldValueType.OleField:
                    case FieldValueType.SameAsInputField:
                    case FieldValueType.UnknownField:
                        t = typeof(object);
                        break;
                    default:
                        t = typeof(object);
                        break;
                }
                dt.Columns.Add(col.Name, t);
            }
            return dt;
        }

        public void View(ReportDocument report)
        {
            var dig = new DialogReportViewer(report); //new DialogReportViewer(report);
            if (dig.InvokeRequired)
            {
                dig.Invoke(new MethodInvoker(() =>
                {
                    var title = report?.SummaryInfo?.ReportTitle;
                    if (!string.IsNullOrEmpty(title))
                    {
                        dig.Text = title;
                    }
                    dig.ShowDialog();
                }));
            }
            else
            {
                var title = report?.SummaryInfo?.ReportTitle;
                if (!string.IsNullOrEmpty(title))
                {
                    dig.Text = title;
                }
                dig.ShowDialog();
            }

        }
        public void View(string name, IEnumerable data, Dictionary<string, IEnumerable> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = new List<IEnumerable>() { data };
            Dictionary<string, List<IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key, y => new List<IEnumerable>() { y.Value });
            }
            View(name, _data, _subData, parameters);
        }
        public void View(string name, List<IEnumerable> data, Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = data.ToDictionary(x => x.GetType().GetGenericArguments()[0].Name, y => y);
            Dictionary<string, Dictionary<string, IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key
                , y => y.Value.ToDictionary(key => key.GetType().GetGenericArguments()[0].Name, value => value));
            }
            View(name, _data, _subData, parameters);
        }
        public void View(string name, Dictionary<string, IEnumerable> data, Dictionary<string, Dictionary<string, IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            //var report = Load(name, data, subReports, parameters);
            var dig = new DialogReportViewer(name, data, subData, parameters);
            dig.ShowDialog();
        }
        public void View(string name, Func<List<IEnumerable>> dataFn, Func<Dictionary<string, List<IEnumerable>>> subDataFn = null, Dictionary<string, object> parameters = null)
        {
            var dig = new DialogReportViewer(name, dataFn, subDataFn, parameters);
            dig.ShowDialog();
        }
        public void View(string name, Func<Dictionary<string, IEnumerable>> dataFn, Func<Dictionary<string, Dictionary<string, IEnumerable>>> subDataFn = null, Dictionary<string, object> parameters = null)
        {
            var dig = new DialogReportViewer(name, dataFn, subDataFn, parameters);
            dig.ShowDialog();
        }
        public void Print(string name, IEnumerable data, string printerName, Dictionary<string, IEnumerable> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = new List<IEnumerable>() { data };
            Dictionary<string, List<IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key, y => new List<IEnumerable>() { y.Value });
            }
            Print(name, _data, printerName, _subData, parameters);
        }
        public void Print(string name, List<IEnumerable> data, string printerName, Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = data.ToDictionary(x => x.GetType().GetGenericArguments()[0].Name, y => y);
            Dictionary<string, Dictionary<string, IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key
                , y => y.Value.ToDictionary(key => key.GetType().GetGenericArguments()[0].Name, value => value));
            }
            Print(name, _data, printerName, string.Empty, _subData, parameters);
        }
        public void Print(string name, List<IEnumerable> data, string printerName, string printerJobTitle,
            Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = data.ToDictionary(x => x.GetType().GetGenericArguments()[0].Name, y => y);
            Dictionary<string, Dictionary<string, IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key
                , y => y.Value.ToDictionary(key => key.GetType().GetGenericArguments()[0].Name, value => value));
            }
            Print(name, _data, printerName, printerJobTitle, _subData, parameters);
        }
        public void Print(ReportDocument report, string printerName, string printerJobTitle)
        {
            var printer = new PrinterSettings
            {
                PrinterName = printerName
            };

            if (!string.IsNullOrEmpty(printerJobTitle))
            {
                report.SummaryInfo.ReportTitle = printerJobTitle;
            }

            if (UI.OS == UI.OSVersion.Windows7)
            {
                var t = new Thread(() =>
                {
                    this.View(report);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
            else
            {
                var setting = new PageSettings();
                report.PrintOptions.CopyTo(printer, setting);
                printer.PrinterName = printerName;
                report.PrintToPrinter(printer, setting, false);
            }

            report.Close();
        }
        public void Print(string name, Dictionary<string, IEnumerable> data, string printerName, string printerJobTitle
            , Dictionary<string, Dictionary<string, IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var printer = new PrinterSettings();
            printer.PrinterName = printerName;

            if (!printer.IsValid)
            {
                throw new Exception("ម៉ាស៊ីនបោះពុម្ពមិនត្រឹមត្រូវ!!");
            }
            var report = Load(name, data, subData, parameters);
            if (!string.IsNullOrEmpty(printerJobTitle))
            {
                report.SummaryInfo.ReportTitle = printerJobTitle;
            }

            if (UI.OS == UI.OSVersion.Windows7)
            {
                var t = new Thread(() =>
                {
                    this.View(report);
                });
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
            else
            {
                var setting = new PageSettings();
                report.PrintOptions.CopyTo(printer, setting);
                printer.PrinterName = printerName;
                report.PrintToPrinter(printer, setting, false);
            }
            report.Close();
        }
        public void Export(string name, IEnumerable data, CrystalDecisions.Shared.ExportFormatType formatType, string file, Dictionary<string, IEnumerable> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = new List<IEnumerable>() { data };
            Dictionary<string, List<IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key, y => new List<IEnumerable>() { y.Value });
            }
            Export(name, _data, formatType, file, _subData, parameters);
        }

        public void Export(string name, List<IEnumerable> data, CrystalDecisions.Shared.ExportFormatType formatType, string file, Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null)
        {
            var _data = data.ToDictionary(x => x.GetType().GetGenericArguments()[0].Name, y => y);
            Dictionary<string, Dictionary<string, IEnumerable>> _subData = null;
            if (subData != null)
            {
                _subData = subData.ToDictionary(x => x.Key
                , y => y.Value.ToDictionary(key => key.GetType().GetGenericArguments()[0].Name, value => value));
            }
            Export(name, _data, formatType, file, _subData, parameters);
        }
        public void Export(string name, Dictionary<string, IEnumerable> data, CrystalDecisions.Shared.ExportFormatType formatType, string file, Dictionary<string, Dictionary<string, IEnumerable>> subReports = null, Dictionary<string, object> parameters = null)
        {
            var report = Load(name, data, subReports, parameters);
            var option = new CrystalDecisions.Shared.ExportOptions();
            option.ExportFormatType = formatType;
            report.ExportToDisk(formatType, file);
            report.Close();
        }

        public SaveFileDialog CsvSaveFileDialog()
        {
            var dig = new SaveFileDialog
            {
                Filter = "CSV(*.csv)|*.csv",
                AddExtension = true,
                DefaultExt = "csv",
                SupportMultiDottedExtensions = false
            };
            return dig;
        }
        public void SelectFile(string path)
        {
            System.Diagnostics.Process.Start("explorer.exe", $"/select, \"{path}\"");
        }

        public ReportDocument ReportFile(string path)
        {
            var info = new FileInfo(path);

            var size = info.Length / 1024f;
            var fileSize = $"{size.ToString("0.##")}KB";
            if (size > 1024)
            {
                size = size / 1024f;
                fileSize = $"{size.ToString("0.##")}MB";
            }
            if (size > 1024)
            {
                size = size / 1024f;
                fileSize = $"{size.ToString("0.##")}GB";
            }

            var report = Load(nameof(ReportFileDownload), default(Dictionary<string, IEnumerable>), null,
                     new Dictionary<string, object>()
                     {
                        { "FileName",info.Name},
                        { "FileSize",fileSize },
                        { "CreateDate", info.CreationTime.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.FullLongDateTime])},
                        { "FileLink",info.FullName},
                     });
            return report;
        }
        public ReportDocument ReportNameFile(string path)
        {
            //var info = new FileInfo(path);

            //var size = info.Length / 1024f;
            //var fileSize = $"{size.ToString("0.##")}KB";
            //if (size > 1024)
            //{
            //    size = size / 1024f;
            //    fileSize = $"{size.ToString("0.##")}MB";
            //}
            //if (size > 1024)
            //{
            //    size = size / 1024f;
            //    fileSize = $"{size.ToString("0.##")}GB";
            //}

            var report = Load(nameof(ReportFileDownload), default(Dictionary<string, IEnumerable>), null,
                     new Dictionary<string, object>()
                     {
                        { "FileName",path},
                        { "FileSize","" },
                        { "CreateDate", DateTime.Now.ToString(FormatHelper.DateTime[FormatHelper.DateTimeType.FullLongDateTime])},
                        { "FileLink",""},
                     });
            return report;
        }

        public T TryCast<T>(object source)
        {
            try
            {
                return (T)source;
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static DataTable ToJDataTable(string json)
        {
            var jsonNetSerializer = new JsonNetSerializer();
            var val = jsonNetSerializer.Serialize(json);
            var dt = jsonNetSerializer.DeserializeObject<DataTable>(json);
            return dt;
        }

        //public static List<DataTable> IncludeReportHeader(List<DataTable> dataTables, Dictionary<string, object> reportHeader)
        //{
        //    // Check datatable parameter
        //    var paramTableName = "Paramters";
        //    var dtParam = dataTables.FirstOrDefault(x => x.TableName == paramTableName);
        //    if (dtParam != null)
        //    {
        //        foreach (var k in reportHeader)
        //        {
        //            dtParam.Columns.Add(k.Key);
        //            dtParam.Rows[0][k.Key] = k.Value.ToString();
        //        }
        //    }
        //    else
        //    {
        //        var dt = new DataTable();
        //        var dr = dt.NewRow();
        //        dt.TableName = paramTableName;
        //        foreach (var k in reportHeader)
        //        {
        //            dt.Columns.Add(k.Key);
        //            dr[k.Key] = k.Value.ToString();
        //        }
        //        dt.Rows.Add(dr);
        //        dataTables.Add(dt);
        //    }
        //    return dataTables;
        //}
    }
}
