using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; 
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QTech.Component
{
    public partial class ExPdfReportViewer : UserControl
    { 
        public ReportDocument Report { get; set; }
        public ExPdfReportViewer()
        {
            InitializeComponent();
            this.DoubleBuffered = true; 
            viewer.setShowToolbar(false);
            //viewer.setLayoutMode("SinglePage");
            //viewer.setPageMode("thumbs");
            //viewer.setView("Fit"); 
            //viewer.setZoom(1.0f);
        }

        public async void LoadReport(ReportDocument report)
        {
            //if (Report!=null)
            //{
            //    Report.Close();
            //} 
            //Report = report; 
            //var file = string.Empty;
            //if (this?.Parent is IAsyncTask parent)
            //{
            //    await parent.RunAsync(() =>
            //    {
            //        file = Path.GetTempFileName(); 
            //        report.ExportToDisk(ExportFormatType.PortableDocFormat, file);  
            //        return file;
            //    });
            //}
            //else
            //{
            //    file = Path.GetTempFileName();
            //    var option = new ExportOptions
            //    {
            //        ExportFormatType = ExportFormatType.PortableDocFormat
            //    };
            //    report.ExportToDisk(option.ExportFormatType, file);
            //} 
            //LoadPdf(file);

            await LoadReportAsync(report);
        }

        public async Task LoadReportAsync(ReportDocument report)
        {
            if (Report != null)
            {
                Report.Close();
            }
            Report = report;
            var file = string.Empty;
            if (this?.Parent is IAsyncTask parent)
            {
                await parent.RunAsync(() =>
                {
                    file = Path.GetTempFileName();
                    report.ExportToDisk(ExportFormatType.PortableDocFormat, file);
                    return file;
                });
            }
            else
            {
                file = Path.GetTempFileName();
                var option = new ExportOptions
                {
                    ExportFormatType = ExportFormatType.PortableDocFormat
                };
                report.ExportToDisk(option.ExportFormatType, file);
            }
            LoadPdf(file);
        }

        public void LoadPdf(string fileName)
        {
            if (File.Exists(fileName))
            { 
                if (UI.IS_INIT_PDF)
                {
                    var h = this.Height;
                    var w = this.Width;
                    this.Size = new Size(w, h);
                    this.Dock = DockStyle.None;
                    viewer.src = fileName;
                    this.Dock = DockStyle.Fill;
                    UI.IS_INIT_PDF = false; 
                }
                else
                {
                    viewer.src = fileName;
                }
                viewer.setLayoutMode("SinglePage");
                //viewer.setView("Fit"); 
                viewer.setZoom(100.0f);
            }
        }

        private async void btnExport_Click(object sender, EventArgs e)
        {
            if (Report != null)
            {
                var option = new ExportOptions();
                option.ExportDestinationType = ExportDestinationType.DiskFile;


                var saveDialog = new SaveFileDialog(); 
                saveDialog.Filter = "Excel(*.xls)|*.xls|PDF(*.pdf)|*.pdf";
                saveDialog.FileName = Report.SummaryInfo.ReportTitle;
                saveDialog.AddExtension = true;
                saveDialog.DefaultExt = "xls";
                saveDialog.SupportMultiDottedExtensions = false; 
                 
                if (saveDialog.ShowDialog()== DialogResult.OK)
                {  
                    if (saveDialog.ValidateNames)
                    {
                        var filename = saveDialog.FileName;
                        if (saveDialog.FilterIndex == 1)
                        {
                            option.ExportFormatType = ExportFormatType.Excel;
                            if (!filename.EndsWith(".xls"))
                            {
                                filename += ".xls";
                            }
                        }
                        else if (saveDialog.FilterIndex == 2)
                        {
                            option.ExportFormatType = ExportFormatType.PortableDocFormat;
                            if (!filename.EndsWith(".pdf"))
                            {
                                filename += ".pdf";
                            }
                        }

                        if (this?.Parent is IAsyncTask parent)
                        {

                            await parent.RunAsync(() =>
                            {
                                Report.ExportToDisk(option.ExportFormatType, filename); 
                                return true;
                            });
                        }
                        else
                        {
                            Report.ExportToDisk(option.ExportFormatType, filename);
                        }
                    } 
                }                
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        { 
            viewer.Print(); 
        } 
    }
}
