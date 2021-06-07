using Easy.Domain.Helpers;
using QTech.Component.Helpers;
using System;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public partial class ExReportPeroidDatePickerDialog : ExDialog
    {
        CustomDateRang _rang = CustomDateRang.None; 
        public ExReportPeroidDatePickerDialog(DateTimePeroid peroid, CustomDateRang rang, DateTime minDate, DateTime maxDate)
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false; 
            _rang=rang;
            Peroid = peroid;
            dtpToDate.Value = peroid.ToDate;
            dtpToDate.MaxDate = maxDate;
            dtpToDate.MinDate = minDate;
            dtpFromDate.CustomFormatWith(FormatHelper.CurrentCulture.DateTimeFormat.ShortDatePattern, dtpToDate); 
            dtpFromDate.Value = peroid.FromDate;
            dtpToDate.Value = peroid.ToDate;
            dtpFromDate.Enabled = rang == CustomDateRang.MonthToDate 
                || rang == CustomDateRang.YearToDate 
                || rang == CustomDateRang.None;
            if (_rang == CustomDateRang.AsOfDate)
            {
                dtpFromDate.ClearValue(Consts.MIN_DATE);
            }

            this.Text = peroid.AsOfName;
        }
        public DateTimePeroid Peroid { get; set; }

        private bool Invalid()
        {
            if (dtpToDate.Value < dtpFromDate.Value)
            {
                dtpToDate.ShowValidation(string.Format(EDomain.Resources.MsgPleaseInputGreater_, EDomain.Resources.FromDate));
                return true;
            }

            return false;
        }

        private void btnAgree_Click_1(object sender, EventArgs e)
        {
            if (Invalid()) return;

            if (_rang == CustomDateRang.MonthToDate )
            {
                Peroid.FromDate = dtpFromDate.Value.Date;
                Peroid.ToDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                Peroid.Name = $"ក្នុងខែ៖{FormatHelper.CurrentCulture.DateTimeFormat.GetMonthName(Peroid.ToDate.Month)} ចាប់ពី៖{Peroid.FromDate.ToShortDateString()} ដល់៖{Peroid.ToDate.ToShortDateString()}";
                Peroid.AsOfName = Peroid.Name;
            }
            else if (_rang == CustomDateRang.YearToDate)
            {
                Peroid.FromDate = dtpFromDate.Value.Date;
                Peroid.ToDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                Peroid.Name = $"ក្នុងឆ្នាំ៖{Peroid.ToDate.Year} ចាប់ពី៖{Peroid.FromDate.ToShortDateString()} ដល់៖{Peroid.ToDate.ToShortDateString()}";
                Peroid.AsOfName = Peroid.Name;
            }
            else if (_rang == CustomDateRang.None)
            {
                Peroid.FromDate = dtpFromDate.Value.Date;
                Peroid.ToDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);
                Peroid.Name = $"ចាប់ពី៖{Peroid.FromDate.ToShortDateString()} ដល់៖{Peroid.ToDate.ToShortDateString()}";
                Peroid.AsOfName = Peroid.Name;
            }
            
            DialogResult = DialogResult.OK;
        }

        private void btnDisagree_Click_1(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            var date = dtpToDate.Value;
            if(_rang == CustomDateRang.AsOfDate)
            {
                Peroid = ExReportDatePicker.GetPeriod(_rang, date);
                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpFromDate.MaxDate = Peroid.ToDate;
                dtpFromDate.ClearValue(Consts.MIN_DATE);
            }
            else if (_rang == CustomDateRang.AsOfMonthToDate)
            {
                Peroid = ExReportDatePicker.GetPeriod(_rang,date );
                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime; 
                dtpFromDate.MaxDate = Peroid.ToDate;
                dtpFromDate.Value = Peroid.FromDate;
            }
            else if (_rang == CustomDateRang.AsOfYearToDate)
            {
                Peroid = ExReportDatePicker.GetPeriod(_rang, date);
                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime; 
                dtpFromDate.MaxDate = Peroid.ToDate;
                dtpFromDate.MinDate = Peroid.FromDate;
                dtpFromDate.Value = new DateTime(date.Year, 1, 1); 
            }
            else if (_rang== CustomDateRang.MonthToDate)
            {
                Peroid = ExReportDatePicker.GetPeriod(_rang, date);
                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime; 
                dtpFromDate.MaxDate = Peroid.ToDate;
                dtpFromDate.MinDate = Peroid.FromDate;  
            }
            else if (_rang== CustomDateRang.YearToDate)
            {
                Peroid = ExReportDatePicker.GetPeriod(_rang, date);
                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime; 
                dtpFromDate.MaxDate = Peroid.ToDate;
                dtpFromDate.MinDate = Peroid.FromDate;
            }

            this.Text = Peroid.AsOfName;
        } 
    }
}
