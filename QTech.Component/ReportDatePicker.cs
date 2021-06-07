using QTech.Base.Helpers;
using QTech.Component.Helpers;
using EasyServer.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;


namespace QTech.Component
{
    [DefaultEvent("ValueChanged")]
    public partial class ReportDatePicker : UserControl
    {
        //private bool _isNeedRefresh = true;
        private bool _isCustomBinding = false;
        private DateTime oldCustomFromDate​ = DateTime.Now;
        private DateTime oldCustomToDate = DateTime.Now;

        public ReportDatePicker()
        {
            InitializeComponent();
            InitializeObj();
        }

        private void ReportDatePicker_Load(object sender, EventArgs e)
        {
            // Reload setting
            var targetName = this.GetFullName();
            Properties.Settings.Default.USER_DATA = Properties.Settings.Default.USER_DATA ?? new UISetting();

            if (Properties.Settings.Default.USER_DATA.DatePickerSettings[targetName] is DatePickerSetting dateRange)
            {
                if ((DateRanges)dateRange.DateRange == DateRanges.Custom)
                {
                    _isCustomBinding = true;
                    oldCustomFromDate = dateRange.FromDate;
                    oldCustomToDate = dateRange.ToDate;
                    InitializeObj($"{dateRange.FromDate.ToShortDateString()} {EDomain.Resources.To} {dateRange.ToDate.ToShortDateString()}");
                }
                else
                {
                    if ((DateRanges)dateRange.DateRange != Value)
                    {
                        Value = (DateRanges)dateRange.DateRange;
                    }
                    // if save date range equal custom no need to update value
                    updateValue();
                }
            }
            else
            {
                // register update value 
                updateValue();
            }
            cbo.SelectedIndexChanged += cbo_SelectedIndexChanged;
        }

        public event EventHandler ValueChanged;

        private DateTime fromDate { get; set; } = DateTime.Now;
        private DateTime toDate { get; set; } = DateTime.Now;
        public bool AutoSave { get; set; } = true;

        [Browsable(false)]
        public DateTime FromDate
        {
            get { return fromDate; }
            set { fromDate = value; }
        }

        [Browsable(false)]
        public DateTime ToDate
        {
            get { return toDate; }
            set { toDate = value; }
        }

        private DateFilterType _dateFilterType = DateFilterType.Period;

        public DateFilterType DateFilterTypes
        {
            get { return _dateFilterType; }
            set
            {
                cbo.DisplayMember = value == DateFilterType.AsOfDate ? "AsOfName" : "Name";
                _dateFilterType = value;
            }
        }

        public DateRanges Value
        {
            set
            {
                cbo.SelectedIndex = (int)value;
            }
            get
            {
                return (DateRanges)cbo.SelectedIndex;
            }
        }
        protected virtual void OnValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null)
            {
                if (AutoSave && DesignMode == false)
                {
                    // Save
                    var targetName = this.GetFullName();
                    Properties.Settings.Default.USER_DATA = Properties.Settings.Default.USER_DATA ?? new UISetting();
                    var setting = Properties.Settings.Default.USER_DATA.DatePickerSettings[targetName];
                    if (setting == null)
                    {
                        Properties.Settings.Default.USER_DATA.DatePickerSettings[targetName] = new DatePickerSetting()
                        {
                            Name = targetName,
                            DateRange = (int)Value,
                            FromDate = FromDate,
                            ToDate = ToDate
                        };
                    }
                    else
                    {
                        setting.DateRange = (int)Value;
                        setting.FromDate = FromDate;
                        setting.ToDate = ToDate;
                    }
                    Properties.Settings.Default.Save();
                }
                ValueChanged(sender, e);
            }
        }
        private void InitializeObj(string chooseText = "")
        {
            var objs = new List<obj>()
            {
                new obj()
                {
                    Id = (int) DateRanges.Today,
                    Name =$"{EDomain.Resources.Today} ({DateTime.Now.ToShortDateString()})",
                    AsOfName = $"{EDomain.Resources.Today} ({DateTime.Now.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.ThisWeek,
                    Name = $"{EDomain.Resources.ThisWeek} ({EDomain.Resources.Week}ទី {GetWeekNumber()}-{DateTime.Now:yyyy})",
                    AsOfName = $"{EDomain.Resources.ThisWeek} ({GetPeriod(DateRanges.ThisWeek).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.ThisMonth,
                    Name = $"{EDomain.Resources.ThisMonth} ({DateTime.Now:MMM-yyyy})",
                    AsOfName = $"{EDomain.Resources.ThisMonth} ({GetPeriod(DateRanges.ThisMonth).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.ThisQuarter,
                    Name = $"{EDomain.Resources.ThisQuarter} ({GetQuarter(DateTime.Now.Month)} {DateTime.Now:yyyy})",
                    AsOfName = $"{EDomain.Resources.ThisQuarter} ({GetPeriod(DateRanges.ThisQuarter).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int)DateRanges.HaftOfYear,
                    Name = $"{Properties.Resources.HaftOfYear} ({DateTime.Now.AddMonths(-6):MMM-yyyy})",
                    AsOfName = $"{Properties.Resources.HaftOfYear} ({GetPeriod(DateRanges.HaftOfYear).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.ThisFiscalYear,
                    Name = $"{EDomain.Resources.ThisYear} ({DateTime.Now:yyyy})",
                    AsOfName = $"{EDomain.Resources.ThisYear} ({GetPeriod(DateRanges.ThisFiscalYear).Item2.ToShortDateString()})"
                },
                new obj() // Last week
                {
                    Id = (int) DateRanges.LastWeek,
                    Name = $"{EDomain.Resources.LastWeek} ({EDomain.Resources.Week}ទី {GetWeekNumber()-1}-{DateTime.Now:yyyy})",
                    AsOfName = $"{EDomain.Resources.LastWeek} ({GetPeriod(DateRanges.LastWeek).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.LastMonth,
                    Name = $"{EDomain.Resources.LastMonth} ({DateTime.Now.AddMonths(-1):MMM-yyyy})",
                    AsOfName = $"{EDomain.Resources.LastMonth}​ ({GetPeriod(DateRanges.LastMonth).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.LastQuarter,
                    Name = $"{EDomain.Resources.LastQuater} ({GetQuarter(FirstDayOfLastQuarter().Month)} {DateTime.Now.AddMonths(-3):yyyy})",
                    AsOfName = $"{EDomain.Resources.LastQuater} ({GetPeriod(DateRanges.LastQuarter).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.LastFiscalYear,
                    Name = $"{EDomain.Resources.LastYear} ({DateTime.Now.AddYears(-1):yyyy})",
                    AsOfName = $"{EDomain.Resources.LastYear} ({GetPeriod(DateRanges.LastFiscalYear).Item2.ToShortDateString()})"
                },
                new obj()
                {
                    Id = (int) DateRanges.Custom,
                    Name = string.IsNullOrEmpty(chooseText) ? EDomain.Resources.Choose : chooseText,
                    AsOfName = string.IsNullOrEmpty(chooseText) ? EDomain.Resources.Choose : chooseText,
                }
            };

            cbo.DisplayMember = "Name";
            if (DateFilterTypes == DateFilterType.AsOfDate)
            {
                cbo.DisplayMember = "AsOfName";
            }
            cbo.ValueMember = "Id";
            cbo.DataSource = objs;
            if (_isCustomBinding)
            {
                cbo.SelectedValue = (int)DateRanges.Custom;
                fromDate = oldCustomFromDate;
                toDate = oldCustomToDate;
                _isCustomBinding = false;
            }
            else
            {
                cbo.SelectedValue = (int)DateRanges.Today;
            }
        }

        public enum DateRanges
        {
            Today = 0,
            ThisWeek,
            ThisMonth,
            ThisQuarter,
            HaftOfYear,
            ThisFiscalYear,
            LastWeek,
            LastMonth,
            LastQuarter,
            LastFiscalYear,
            Custom
        }
        public enum DateFilterType
        {
            Period,
            AsOfDate
        }
        public class obj
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string AsOfName { get; set; }
        }

        public Tuple<DateTime, DateTime> GetPeriod(DateRanges range)
        {
            var d1 = DateTime.Now;
            var d2 = DateTime.Now;
            switch (range)
            {
                case DateRanges.Today:
                    d1 = DateTime.Now.Date;
                    d2 = DateTime.Now.Date/*.AddDays(1).AddSeconds(-1)*/;
                    break;
                case DateRanges.ThisWeek:
                    d1 = FirstDayOfWeek(DateTime.Now);
                    d2 = LastDayOfWeek(DateTime.Now);
                    break;
                case DateRanges.ThisMonth:
                    d1 = FirstDayOfMonth(DateTime.Now);
                    d2 = LastDayOfMonth(DateTime.Now);
                    break;
                case DateRanges.ThisQuarter:
                    d1 = FirstDayOfQuarter();
                    d2 = LastDayOfQuarter();
                    break;
                case DateRanges.ThisFiscalYear:
                    d1 = FirstDayOfYear();
                    d2 = LastDayOfYears();
                    break;
                case DateRanges.LastWeek:
                    d1 = FirstDayOfLastWeek(DateTime.Now);
                    d2 = LastDayOfLastWeek(DateTime.Now);
                    break;
                case DateRanges.LastMonth:
                    d1 = FirstDayOfLastMonth();
                    d2 = LastDayOfLastMonth();
                    break;
                case DateRanges.LastQuarter:
                    d1 = FirstDayOfLastQuarter();
                    d2 = LastDayOfLastQuarter();
                    break;
                case DateRanges.LastFiscalYear:
                    d1 = FirstDayOfLastYear();
                    d2 = LastDayOfLastYears();
                    break;
                case DateRanges.HaftOfYear:
                    d1 = DateTime.Now.Date.AddMonths(-6);
                    d2 = LastDayOfMonth(DateTime.Now);
                    break;
            }
            return new Tuple<DateTime, DateTime>(d1.Date, d2.Date.AddDays(1).AddSeconds(-1));
        }
        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_isCustomBinding)
            {
                updateValue();
                OnValueChanged(sender, e);
            }
        }

        private void updateValue()
        {
            var range = (DateRanges)Parse.ToInt(cbo.SelectedValue.ToString());
            if (range == DateRanges.Custom)
            {
                if (DateFilterTypes == DateFilterType.AsOfDate)
                {
                    //var dig = new ReportAsOfDatePickerDialog(ToDate);
                    //if (dig.ShowDialog() != DialogResult.OK) return;
                    //fromDate = dig.FromDate;
                    //toDate = dig.ToDate;
                }
                else
                {
                    var dig = new ReportPeroidDatePickerDialog(oldCustomFromDate, oldCustomToDate);
                    if (dig.ShowDialog() != DialogResult.OK) return;
                    fromDate = oldCustomFromDate = dig.FromDate;
                    toDate = oldCustomToDate = dig.ToDate;
                    //_isNeedRefresh = false;
                    _isCustomBinding = true;
                    InitializeObj($"{fromDate.ToShortDateString()} {EDomain.Resources.To} {toDate.ToShortDateString()}");
                    //cbo.SelectedValue = (int)DateRanges.Custom;
                }
            }
            else
            {
                var period = GetPeriod(range);
                fromDate = period.Item1;
                toDate = period.Item2;
                //_isNeedRefresh = false;
                //InitializeObj();
                //cbo.SelectedIndex = (int)range;
            }
        }

        public int GetWeekNumber()
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

        // GetQuarter
        public string GetQuarter(int month)
        {
            var quarter = string.Empty;
            if (month >= 1 && month <= 3)
                quarter = "Q1";
            if (month >= 4 && month <= 6)
                quarter = "Q2";
            if (month >= 7 && month <= 9)
                quarter = "Q3";
            if (month >= 10 && month <= 12)
                quarter = "Q4";
            return quarter;
        }

        // Week
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = FormatHelper.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = GetDayOfWeekNumber(fdow, fdow) - GetDayOfWeekNumber(date.DayOfWeek, fdow);
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        private static int GetDayOfWeekNumber(DayOfWeek dayOfWeek, DayOfWeek firstDayOfWeek)
        {
            var val = DayOfWeek.Sunday - firstDayOfWeek;
            var day = (int)(dayOfWeek) + val;
            if (day < 0)
            {
                return 7 + day;
            }
            else
            {
                return day;
            }
        }

        public static DateTime FirstDayOfLastWeek(DateTime date)
        {
            DateTime mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6);
            return mondayOfLastWeek;
        }
        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        public static DateTime LastDayOfLastWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfLastWeek(date).AddDays(6);
            return ldowDate;
        }

        //Month
        public DateTime FirstDayOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }
        public DateTime LastDayOfMonth(DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        public DateTime FirstDayOfLastMonth()
        {
            return DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1);
        }
        public DateTime LastDayOfLastMonth()
        {
            DateTime firstDayLastMonth = DateTime.Now.AddDays(1 - DateTime.Now.Day).AddMonths(-1);
            return new DateTime(firstDayLastMonth.Year, firstDayLastMonth.Month, DateTime.DaysInMonth(firstDayLastMonth.Year, firstDayLastMonth.Month));
        }

        //Quarter
        public DateTime FirstDayOfQuarter()
        {
            var date = DateTime.Now;
            var quarterNumber = (date.Month - 1) / 3 + 1;
            return new DateTime(date.Year, (quarterNumber - 1) * 3 + 1, 1);
        }
        public DateTime LastDayOfQuarter()
        {
            return FirstDayOfQuarter().AddMonths(3).AddDays(-1);
        }
        public DateTime FirstDayOfLastQuarter()
        {
            return FirstDayOfQuarter().AddMonths(-3);
        }
        public DateTime LastDayOfLastQuarter()
        {
            return FirstDayOfLastQuarter().AddMonths(3).AddDays(-1);
        }

        // Financial Years
        public DateTime FirstDayOfYear()
        {
            return new DateTime(DateTime.Now.Year, 1, 1);
        }
        public DateTime LastDayOfYears()
        {
            return new DateTime(DateTime.Now.Year, 12, 31);
        }
        public DateTime FirstDayOfLastYear()
        {
            return new DateTime(DateTime.Now.Year - 1, 1, 1);
        }
        public DateTime LastDayOfLastYears()
        {
            return new DateTime(DateTime.Now.Year - 1, 12, 31);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            cbo.Font = this.Font;
            base.OnFontChanged(e);
        }
    }
}
