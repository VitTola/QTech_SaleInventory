using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Drawing2D;
using CrystalDecisions.Windows.Forms;

namespace QTech.Component
{
    public partial class ExReportViewer : UserControl,IAsyncTask
    {

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F6)
            {
                switchView();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        public enum ViewerType
        {
            Crystal,
            PDF
        }
        public int TotalPages
        {
            get
            {
                if (crViewer.Controls[0] is PageView page)
                {
                    return page.GetLastPageNumber();
                }
                else
                {
                    return 0;
                }
            }
        }

        public ViewerType Viewer { get; set; } = ViewerType.Crystal;
        public bool Executing { get ; set ; }
        public ReportDocument ReportDoc { get; private set; }

        public bool IsNotDrillSubReport { get; set; } = true;

        public ExReportViewer()
        {
            InitializeComponent();
            this.SuspendLayout();
            panel.Visible = false;
            pdfViewer.Visible = false;
            crViewer.Visible = false;
            crViewer.ShowLogo = false;
            crViewer.ShowParameterPanelButton = false;
            crViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            crViewer.ShowRefreshButton = false;
            crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crViewer.EnableDrillDown = true;
            crViewer.Drill += crViewer_Drill;
            crViewer.DrillDownSubreport += crViewer_DrillDownSubreport;
            crViewer.AllowedExportFormats = (int)(CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat
                | CrystalDecisions.Shared.ViewerExportFormats.ExcelRecordFormat
                | CrystalDecisions.Shared.ViewerExportFormats.PdfFormat
                | CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat
                | CrystalDecisions.Shared.ViewerExportFormats.WordFormat
                | CrystalDecisions.Shared.ViewerExportFormats.XmlFormat);
            panel.Paint += Panel_Paint;
            this.ResumeLayout(); 
        }

         

        private void crViewer_DrillDownSubreport(object source, CrystalDecisions.Windows.Forms.DrillSubreportEventArgs e)
        {
            e.Handled = IsNotDrillSubReport;
        }

        private void crViewer_Drill(object source, CrystalDecisions.Windows.Forms.DrillEventArgs e)
        {
            e.Handled = true;
        }

        private void ExReportViewer_Load(object sender, EventArgs e)
        {
            if (UI.OS == UI.OSVersion.Windows7)
            {
                Viewer = ViewerType.PDF;
                pdfViewer.Visible = true;
            }
            else
            {
                Viewer = ViewerType.Crystal;
                pdfViewer.Visible = false; 
            } 
            crViewer.Visible = !pdfViewer.Visible;

        }

        public void View(ReportDocument report)
        { 
            if (Viewer == ViewerType.Crystal)
            {
                if (crViewer.ReportSource is ReportDocument rpt)
                {
                    rpt.Close();
                    rpt.Dispose();
                    crViewer.ReportSource = null;
                }
                crViewer.ReportSource = report; 
            }
            else
            {
                pdfViewer.LoadReport(report);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public async Task ViewAsync(ReportDocument report)
        {
            if (Viewer == ViewerType.Crystal)
            {
                if (crViewer.ReportSource is ReportDocument rpt)
                {
                    rpt.Close();
                    rpt.Dispose();
                    crViewer.ReportSource = null;
                }
                crViewer.ReportSource = report;
            }
            else
            {
                await pdfViewer.LoadReportAsync(report);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public void View(string pdf)
        {
            if (Viewer == ViewerType.Crystal)
            {
                if (crViewer.ReportSource is ReportDocument rpt)
                {
                    rpt.Close();
                    rpt.Dispose();
                    crViewer.ReportSource = null;
                } 
            }
            else
            { 
                pdfViewer.LoadPdf(pdf);
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        } 

        public void Close()
        {
            if (Viewer == ViewerType.Crystal)
            {
                if (!crViewer.IsDisposed)
                {
                    if (crViewer.ReportSource is ReportDocument rpt)
                    {
                        rpt.Close();
                        rpt.Dispose();
                        crViewer.ReportSource = null;
                    }
                    
                }
            }
            else
            {
                pdfViewer.Report?.Close(); 
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //DrawBackground(e.Graphics, picThin.ClientSize);

            // Make the smiley path.
            using (GraphicsPath path = graphicsPath(picLoading.DisplayRectangle, 5))
            {
                // Draw the shadow.
                e.Graphics.TranslateTransform(2, 2);
                //Color color = Color.FromArgb(64, 0, 0, 0);
                var color = Color.FromArgb(234, 234, 234);
                using (Pen thick_pen = new Pen(color, 4))
                {
                    e.Graphics.DrawPath(thick_pen, path);
                }
                e.Graphics.ResetTransform();
            }
        }
        private GraphicsPath graphicsPath(Rectangle bounds, int radius)
        {
            bounds.Location = new Point(bounds.Location.X + 4, bounds.Location.Y + 4);
            bounds.Size = new Size(bounds.Size.Width - 1, bounds.Size.Height - 1);

            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);

            GraphicsPath path = new GraphicsPath();
            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public void PreExecute(bool block = false)
        { 
            panel.Enabled = true;
            panel.Visible = true;
        }

        public void PostExecute(bool block = false)
        { 
            panel.Enabled = false;
            panel.Visible = false;
        }

        private void switchView()
        { 
            pdfViewer.Visible = !pdfViewer.Visible;
            crViewer.Visible = !pdfViewer.Visible;
            Viewer = pdfViewer.Visible ? ViewerType.PDF : ViewerType.Crystal; 
        }
    }
}
