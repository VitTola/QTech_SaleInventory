using Storm.Base.BaseModules;
using Storm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Storm.Component
{
    public partial class ReportPage : Form, IPage
    {
        public Base.BaseModules.Report Report { get; set; } = new Base.BaseModules.Report();
        public AuthKey ReportButtonKey { get; set; }
        public AuthKey ModuleKey { get; set; }
        
        private Dictionary<AuthKey, List<ExReportGroup>> _reportGroups = new Dictionary<AuthKey, List<ExReportGroup>>();
        private Dictionary<string, Form> _openedReport = new Dictionary<string, Form>();

        public ReportPage()
        {
            InitializeComponent();
        }

        public void AddNew() { }

        public void Edit() { }

        public void Reload()
        {
            if (Report == null) return;

            reportGroupsContainer.Controls.Clear();
            reportGroupsContainer.BringToFront();
            if (_reportGroups.ContainsKey(ReportButtonKey))
            {
                var oldReports = _reportGroups[ReportButtonKey];

                if (oldReports.Any())
                {
                    reportGroupsContainer.Controls.AddRange(oldReports.ToArray());
                    return;
                }
            }

            List<ExReportGroup> newReportGroups = new List<ExReportGroup>();
            
            Report.Children.ForEach(x =>
            {
                ExReportGroup reportGroup = new ExReportGroup();
                reportGroup.ReportGroup = x;
                reportGroup.Tag = x;
                reportGroup.Size = reportGroup.CurrentSize;
                reportGroup.ReportItemClick += reportItem_Click;
                reportGroupsContainer.Controls.Add(reportGroup);
                newReportGroups.Add(reportGroup);
            });

            _reportGroups[ReportButtonKey] = newReportGroups;
            
        }
        
        private void reportItem_Click(object sender, EventArgs e)
        {
            LinkLabel linkLabel = (LinkLabel)sender;
            Base.BaseModules.Report report = (Base.BaseModules.Report)linkLabel.Tag;
            //
            if (!_openedReport.ContainsKey(linkLabel.Name))
            {
                Assembly assembly = Assembly.LoadFrom(report.ModuleLocation);
                if (string.IsNullOrEmpty(report.ReportFormName)) return;
                Type type = assembly.GetType(report.ReportFormName);
                if (!(Activator.CreateInstance(type) is Form form)) return;
                form.TopLevel = false;
                form.Enabled = true;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                //
                reportFormContainer.Controls.Add(form);
                _openedReport.Add(linkLabel.Name, form);
                ResourceHelper.ApplyResource(form);
                form.Show();
            }
            //
            if (reportFormContainer.Tag is Form oldForm)
            {
                oldForm.Hide();
            }
            //
            reportFormContainer.Controls.SetChildIndex(_openedReport[linkLabel.Name], 0);
            reportFormContainer.Tag = _openedReport[linkLabel.Name];
            _openedReport[linkLabel.Name].Show();
            reportFormContainer.SelectNextControl(reportFormContainer, true, true, true, true);
            if (_openedReport[linkLabel.Name] is IPage page)
            {
                page.Reload();
            }

            reportFormContainer.BringToFront();
        }

        public void Remove() { }

        public Task Search() { throw new NotImplementedException(); }

        public void View() { }
        
    }
}
