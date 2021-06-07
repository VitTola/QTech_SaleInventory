using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Base.Helpers;

namespace QTech.Component.Helpers
{
    public class Conts
    {
        public enum BulkProcessStatus
        {
            All = 1,
            Success,
            Error
        }
        public enum BulkTemplateName
        {
            Transformer = 1,
            TransactionEntry,
            UploadCintri,
            AdjustmentCintri
        }

        public enum FileExtension
        {
            Excel = 1,
            Csv,
            Xml,
            Json
        }

        public enum AutomateReadingSearchKey
        {
            Recent = 1,
            MeterSerial,
            BillingCycle,
        }

        public enum ReadDeviceStatus
        {
            NotBlock = 1,
            Block
        }

        public static readonly Dictionary<FileExtension, string> FileExtensionFilter = new Dictionary<FileExtension, string>
        {
            {FileExtension.Excel,"Excel Worksheets|*.xls;*.xlsx;" },
            {FileExtension.Csv,"csv|*.csv" },
            {FileExtension.Xml,"xml|*.xml" },
            {FileExtension.Json,"json|*.json" }
        };

        public static readonly List<string> BulkPaymentOfflineHeader = new List<string>()
        {
            "RefNo",
            "User",
            "ConnectionType",
            "Currency",
            "PayAmount",
            "TranDate",
            "TranTime",
            "Amount",
            "ConsumerCode",
            "ConsumerName",
            "PayDate"
        };

        public static readonly List<string> BulkInputEDMIHeader = new List<string>()
        {
            "MeterSerial",
            "MeterRegister",
            "ReadDate",
            "NewReading",
        };

        public static readonly Dictionary<FileExtension, List<string>> FileTypeExtension = new Dictionary<FileExtension, List<string>>
        {
            {FileExtension.Excel, new List<string>{".xls", ".xlsx"}},
            {FileExtension.Csv, new List<string>{".csv"}},
            {FileExtension.Xml, new List<string>{".xml"}},
            {FileExtension.Json, new List<string>{".json"}}
        };

        //public static readonly Dictionary<CustomerSearchKey, Keys> KeyShourtcut = new Dictionary<CustomerSearchKey, Keys>
        //{
        //    {CustomerSearchKey.InstallationCode, Keys.F3 },
        //    {CustomerSearchKey.ConsumerCode, Keys.F4 },
        //    {CustomerSearchKey.CustomerCode, Keys.F9 },
        //    {CustomerSearchKey.CustomerName, Keys.F6 },
        //    {CustomerSearchKey.RecentCustomer, Keys.F5 },
        //    {CustomerSearchKey.CustomerAddress, Keys.F7 },
        //    {CustomerSearchKey.AdavanceSearch, Keys.Control | Keys.F},
        //    {CustomerSearchKey.MeterCode, Keys.F8 },
        //    {CustomerSearchKey.OldConsumerCode, Keys.F10 },
        //    {CustomerSearchKey.ConsumerChannelGroup, Keys.F11 }
        //};

        public static readonly Dictionary<GeneralProcess, Keys> PageKey = new Dictionary<GeneralProcess, Keys>
        {
            {GeneralProcess.Add, Keys.Control | Keys.N },
            {GeneralProcess.View, Keys.Control | Keys.E},
            {GeneralProcess.Update, Keys.Control | Keys.O},
            {GeneralProcess.Remove, Keys.Control | Keys.Delete}
        };
        
        public static readonly Dictionary<QTech.Base.Helpers.GeneralProcess, string> PageKeyText = new Dictionary<QTech.Base.Helpers.GeneralProcess, string>
        {
            {GeneralProcess.Add, "N" },
            {GeneralProcess.View, "E" },
            {GeneralProcess.Update, "O" },
            {GeneralProcess.Remove, "del" }
        };
        public static readonly Dictionary<PageReport, Keys> PageReportKey = new Dictionary<PageReport, Keys>
        {
            {PageReport.View, Keys.Control | Keys.O },
            {PageReport.Find,  Keys.F3},{ PageReport.DownloadCsv, Keys.Control | Keys.D}
        };
        public static readonly Dictionary<PageReport, string> PageReportKeyText = new Dictionary<PageReport, string>
        {
            {PageReport.View,  "O"},
            {PageReport.Find,"F3" },
            {PageReport.DownloadCsv,"D" },

        };

        public static readonly Dictionary<Pagination, Keys> PaginationKey = new Dictionary<Pagination, Keys>()
        {
            {Pagination.Next,(Keys.Control|Keys.Right)},
            {Pagination.Previous,(Keys.Control|Keys.Left)},
            {Pagination.ShowAll,(Keys.Control|Keys.Oemplus)}
        };

        public static readonly Dictionary<DialogProcess, Keys> DialogKey = new Dictionary<DialogProcess, Keys>
        {
            {DialogProcess.Save, Keys.Control| Keys.S },
            {DialogProcess.ViewChangeLog, Keys.Control| Keys.E },
            {DialogProcess.Close, Keys.Control |Keys.Q },
        };
        public static readonly Dictionary<DialogProcess, string> DialogKeyText = new Dictionary<DialogProcess, string>
        {
            {DialogProcess.Save,"S" },
            {DialogProcess.ViewChangeLog,"E" },
            {DialogProcess.Close,"Q" }
        };

        public static readonly Dictionary<AutomateReadingSearchKey, Keys> AutomateReadingSearchShorcutKey = new Dictionary<AutomateReadingSearchKey, Keys>
        {
            {AutomateReadingSearchKey.Recent, Keys.F3 },
            {AutomateReadingSearchKey.MeterSerial, Keys.F4 },
            {AutomateReadingSearchKey.BillingCycle, Keys.F5 }
        };
        
        public static ImageList HealthImageList => new Lazy<ImageList>(() =>
        {
            var img = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
            img.Images.Add("Healthy", Properties.Resources.img_active);
            img.Images.Add("Unhealthy", Properties.Resources.img_diconnected);
            return img;
        }).Value;   
        
        public static ImageList PrintReadingImageList => new Lazy<ImageList>(() =>
        {
            var img = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
            img.Images.Add(PrintReadingProcess.Waiting.ToString(), Properties.Resources.waiting);
            img.Images.Add(PrintReadingProcess.GenerateReport.ToString(), Properties.Resources.report_processing);
            img.Images.Add(PrintReadingProcess.Printing.ToString(), Properties.Resources.report_printing);
            img.Images.Add(PrintReadingProcess.Ready.ToString(), Properties.Resources.printed_check);
            img.Images.Add(PrintReadingProcess.GettingDatas.ToString(), Properties.Resources.downloading_datas);
            img.Images.Add(PrintReadingProcess.NoDatasToPrint.ToString(), Properties.Resources.documents_empty);
            img.Images.Add(PrintReadingProcess.Error.ToString(), Properties.Resources.img_block);
            return img;
        }).Value;
        public static Dictionary<CounterSessionReport, string> CounterSessionReportList => new Lazy<Dictionary<CounterSessionReport, string>>(() =>
        {
            var dic = new Dictionary<CounterSessionReport, string>();
            dic.Add(CounterSessionReport.CounterSessionSumaryReport, $"Payment\\CounterSessionSumaryReport.rdlc");
            dic.Add(CounterSessionReport.CounterSessionDetailReport, $"Payment\\CounterSessionDetailReport.rdlc");
            //dic.Add(PaymentReport.CounterSessionTotallyReport, $"Payment\\CounterSessionTotalyReport.rdlc");
            //dic.Add(PaymentReport.CashNoteCountReport, $"Payment\\CashNoteCountReport.rdlc");
            //dic.Add(CounterSessionReport.CounterSessionReverseReport, $"Payment\\CounterSessionReverseReport.rdlc");
            return dic;
        }).Value;

        public static Dictionary<ReadingListTemplates, string> ReadingReportPaths = new Dictionary<ReadingListTemplates, string>()
        {
            {ReadingListTemplates.ReadingListTemplate1, "Billing\\ReadingList.rdlc"},
            { ReadingListTemplates.ReadingListTemplate2, "Billing\\ReadingList_1.rdlc" }
        };

        public static Dictionary<EditListTemplates, string> EditListReportPaths = new Dictionary<EditListTemplates, string>()
        {
            {EditListTemplates.EditListDetail, "Billing\\EditList.rdlc"},
            { EditListTemplates.EditListSummary, "Billing\\EditSummaryList.rdlc" }
        };

        public static ImageList PrintInvoiceProcessImageList => new Lazy<ImageList>(() =>
        {
            var img = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
            img.Images.Add(PrintInvoiceProcess.Waiting.ToString(), Properties.Resources.img_pending);
            img.Images.Add(PrintInvoiceProcess.DownloadingInvoice.ToString(), Properties.Resources.downloading_datas);
            img.Images.Add(PrintInvoiceProcess.PreparingInvoice.ToString(), Properties.Resources.waiting);
            img.Images.Add(PrintInvoiceProcess.SendingToPrinter.ToString(), Properties.Resources.report_printing);
            img.Images.Add(PrintInvoiceProcess.Ready.ToString(), Properties.Resources.img_active);
            img.Images.Add(PrintInvoiceProcess.Error.ToString(), Properties.Resources.img_block);
            return img;
        }).Value;
        
        public static Color ReportViewerBackColor
        {
            get
            {
                if(UI.OS == UI.OSVersion.Windows7)
                {
                    return Color.FromArgb(88, 88, 88);
                }
                return Color.Transparent;
            }
        }
        
        public static ImageList ChannelImageList => new Lazy<ImageList>(() =>
        {
            var img = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
            img.Images.Add(nameof(ChannelStatus.Work), Properties.Resources.img_active);
            img.Images.Add(nameof(ChannelStatus.NotWork), Properties.Resources.img_diconnected);
            return img;
        }).Value;
        public static ImageList ReadDeviceStatusImageList => new Lazy<ImageList>(() =>
        {
            var img = new ImageList() { ColorDepth = ColorDepth.Depth32Bit };
            img.Images.Add(ReadDeviceStatus.NotBlock.ToString(), Properties.Resources.img_active);
            img.Images.Add(ReadDeviceStatus.Block.ToString(), Properties.Resources.img_suspend);
            return img;
        }).Value;

        public static object CustomerSearchKey { get; private set; }
    }
}
