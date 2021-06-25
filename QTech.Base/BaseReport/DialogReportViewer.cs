using CrystalDecisions.CrystalReports.Engine;
using QTech.Component;
using Storm.CC.Report.Helpers;
using Storm.Component;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QTech.Component;

namespace QTech.Base.BaseReport
{
    public partial class DialogReportViewer : ExDialog
    {
        enum ReportDirection
        {
            ReportFile,
            ReportData,
            ReportDataList,
            ReportFunction,
            ReportDictionaryFunction,
            ReportListFunction,
            ReportDataTable
        }

        private ReportDirection _direction;

        private ReportDocument _report;

        private string _name;
        private Dictionary<string, IEnumerable> _data;
        private Dictionary<string, Dictionary<string, IEnumerable>> _subData;

        private List<IEnumerable> _dataList;
        private Dictionary<string,  List<IEnumerable>> _subDataList;
        
        private Func<Dictionary<string, IEnumerable>> _dataDicFn;
        private Func<Dictionary<string, Dictionary<string, IEnumerable>>> _subDataDicFn;

        private Func<List<IEnumerable>> _dataListFn;
        private Func<Dictionary<string, List<IEnumerable>>> _subDataListFn;

        private Func<IEnumerable> _dataFn;
        private Func<Dictionary<string, IEnumerable>> _subDataFn;

        private List<DataTable> _dataTable;
        private Dictionary<string, List<DataTable>> _subDataTable;

        Dictionary<string,object> _parameters;
        public DialogReportViewer( )
        {
            InitializeComponent(); 
            this.InitForm();
            this.OptimizeLoadUI();
        }
        public DialogReportViewer(ReportDocument report):this()
        {
            _direction = ReportDirection.ReportFile;
            _report = report;
        }


        public DialogReportViewer(string name, Dictionary<string, IEnumerable> data, Dictionary<string, Dictionary<string, IEnumerable>> subData = null, Dictionary<string, object> parameters = null) : this()
        {
            _direction = ReportDirection.ReportData;
            _name = name;
            _data = data;
            _subData = subData;
            _parameters = parameters;
        }

        public DialogReportViewer(string name,  List<IEnumerable> data, Dictionary<string, List<IEnumerable>> subData = null, Dictionary<string, object> parameters = null) : this()
        {
            _direction = ReportDirection.ReportData;
            _name = name;
            _dataList = data;
            _subDataList = subData;
            _parameters = parameters;
        }

        public DialogReportViewer(string name,
            Func<Dictionary<string, IEnumerable>> dataFn,
            Func<Dictionary<string, Dictionary<string, IEnumerable>>> subDataFn = null,
            Dictionary<string, object> parameters = null) : this()
        {
             
            _direction = ReportDirection.ReportDictionaryFunction;
            _name = name;
            _dataDicFn = dataFn;
            _subDataDicFn = subDataFn;
            _parameters = parameters;
        }
        public DialogReportViewer(string name,
            Func<List<IEnumerable>> dataFn,
            Func<Dictionary<string, List<IEnumerable>>> subDataFn = null,
            Dictionary<string, object> parameters = null) : this()
        {

            _direction = ReportDirection.ReportListFunction;
            _name = name;
            _dataListFn = dataFn;
            _subDataListFn = subDataFn;
            _parameters = parameters;
        }

        public DialogReportViewer(string name,
           Func<IEnumerable> dataFn,
           Func<Dictionary<string, IEnumerable>> subDataFn = null,
           Dictionary<string, object> parameters = null) : this()
        {
            _direction = ReportDirection.ReportListFunction;
            _name = name;
            _dataFn = dataFn;
            _subDataFn = subDataFn;
            _parameters = parameters;
        }

        public DialogReportViewer(string name,
           List<DataTable> dataTable,
           Dictionary<string, List<DataTable>> subDataTable = null,
           Dictionary<string, object> parameters = null) : this()
        {
            _direction = ReportDirection.ReportDataTable;
            _name = name;
            _dataTable = dataTable;
            _subDataTable = subDataTable;
            _parameters = parameters;
        }

        private async void DialogReportViewer_Load(object sender, EventArgs e)
        {
            if (_direction == ReportDirection.ReportData)
            {
                _report = await this.RunAsync(() =>
                {
                    return ReportHelper.Instance.Load(_name, _data, _subData, _parameters);
                });
            }
            else if (_direction == ReportDirection.ReportDataList)
            {
                _report = await this.RunAsync(() =>
                {
                    return ReportHelper.Instance.Load(_name, _dataList, _subDataList, _parameters);
                });
            }
            else if (_direction == ReportDirection.ReportDictionaryFunction)
            {
                if (_dataDicFn == null)
                {
                    throw new Exception("No Action to request report's data!");
                }

                _report = await this.RunAsync(() =>
                {
                    _data = _dataDicFn?.Invoke();
                    _subData = _subDataDicFn?.Invoke();
                    return ReportHelper.Instance.Load(_name, _data, _subData, _parameters);
                });
            }
            else if (_direction == ReportDirection.ReportListFunction)
            {
                if (_dataListFn == null)
                {
                    throw new Exception("No Action to request report's data!");
                }

                _report = await this.RunAsync(() =>
                {
                    var data = _dataListFn?.Invoke();
                    var subData = _subDataListFn?.Invoke();
                    return ReportHelper.Instance.Load(_name, data, subData, _parameters);
                });
            }
            else if (_direction== ReportDirection.ReportFunction)
            {
                if (_dataFn == null)
                {
                    throw new Exception("No Action to request report's data!");
                }

                _report = await this.RunAsync(() =>
                {
                    var data = _dataFn?.Invoke();
                    var subData = _subDataFn?.Invoke();
                    return ReportHelper.Instance.Load(_name, data, subData, _parameters);
                });
            }
            else if (_direction == ReportDirection.ReportDataTable)
            {
                _report = await this.RunAsync(() =>
                {
                    return ReportHelper.Instance.Load(_name, _dataTable);
                });
            } 
            viewer.View(_report);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Q))
            {
                this.Close();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
