using QTech.Component.Helpers;
using Storm.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EDomain = EasyServer.Domain;

namespace QTech.Component
{
    public class ExReportDatePicker:ComboBox
    {
        public ExReportDatePicker()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;
        } 


        [Browsable(false)]
        public DateTime MinDate { get; private set; } = DateTimePicker.MinimumDateTime;
        [Browsable(false)]
        public DateTime MaxDate { get; private set; } = DateTimePicker.MaximumDateTime;

        public void SetMaxDate(DateTime date)
        {
            this.MaxDate = date < DateTimePicker.MinimumDateTime ? DateTimePicker.MaximumDateTime : date.Date.AddDays(1).AddSeconds(-1);
        }

        public void SetMinDate(DateTime date)
        {
            this.MaxDate = date < DateTimePicker.MinimumDateTime ? DateTimePicker.MinimumDateTime : date;
        }


        [Browsable(false)]
        public DateTimePeroid SelectedPeroid
        {
            get
            {
                if (this.InvokeRequired)
                {
                    DateTimePeroid peroid = null;
                    this.Invoke(new MethodInvoker(() =>
                    {
                        if (this.SelectedItem is DateTimePeroid value)
                        {
                            peroid = value;
                        } 
                    }));
                    return peroid;
                }
                else
                {
                    if (this.SelectedItem is DateTimePeroid peroid)
                    {
                        return peroid;
                    }
                }

                
                return null;
            } 
        }
        [DefaultValue(CustomDateRang.None)]
        public CustomDateRang CustomDateRang { get; set; } = CustomDateRang.None;
        public static List<DateTimePeroid> GetPeroids(DateTime? maxDate)
        {  
            var peroids = new List<DateTimePeroid>();
            foreach (var item in Enum.GetValues(typeof(DatePeroid))
                .OfType<DatePeroid>()
                .Where(x=>x != DatePeroid.Custom))
            {
                var peroid = GetPeriod(item, maxDate);
                if (maxDate != null &&
                    (peroid.Peroid != DatePeroid.Today))
                {
                    if ((peroid.ToDate.Date > maxDate.Value.Date && maxDate.Value > DateTimePicker.MinimumDateTime)
                        || (peroid.FromDate.Date > maxDate.Value.Date && maxDate.Value > DateTimePicker.MinimumDateTime))
                    {
                        continue;
                    } 
                }
                peroids.Add(peroid);
            }
            return peroids;
        }

        public void SetSelectePeroid(DatePeroid peroid)
        {
            var item = this.Items.OfType<DateTimePeroid>().FirstOrDefault(x => x.Peroid == peroid);
            if (item!=null)
            {
                this.SelectedItem = item;
            }
        }
       

        protected override void OnSelectionChangeCommitted(EventArgs e)
        {
            if (this.SelectedItem is DateTimePeroid peroid)
            {
                if (peroid.Peroid == DatePeroid.Custom)
                {
                    var dig = new ExReportPeroidDatePickerDialog(peroid, CustomDateRang, MinDate, MaxDate);
                    if (dig.ShowDialog() == DialogResult.OK)
                    {
                        peroid.FromDate = dig.Peroid.FromDate;
                        peroid.ToDate = dig.Peroid.ToDate;
                        peroid.Name = dig.Peroid.Name;
                        peroid.AsOfName = dig.Peroid.AsOfName;
                        peroid.PrettyDate = dig.Peroid.PrettyDate;
                        this.RefreshItem(this.SelectedIndex);
                    }
                } 
            }
            base.OnSelectionChangeCommitted(e);
        } 

        public static DateTimePeroid GetPeriod(DatePeroid range, DateTime? maxDate)
        {
            var now = DateTime.Now;
            var from = DateTime.Now;
            var to = DateTime.Now;
            var peroid = new DateTimePeroid();
            peroid.Peroid = range;

            switch (range)
            {
                case DatePeroid.Today:
                    from = DateTime.Now.Date;
                    to = DateTime.Now.Date;
                    peroid.Name = $"{EDomain.Resources.Today} ({DateTime.Now.ToShortDateString()})";
                    peroid.AsOfName = $"{EDomain.Resources.Today} ({DateTime.Now.ToShortDateString()})"; 
                    break;
                case DatePeroid.Yesterday:
                    from = DateTime.Now.Date.AddDays(-1);
                    to = from;
                    peroid.Name = $"{EDomain.Resources.Yesterday} ({to.ToShortDateString()})";
                    peroid.AsOfName = peroid.Name;
                    break;
                case DatePeroid.ThisWeek:
                    from    = FirstDayOfWeek(now);
                    to      = LastDayOfWeek(now);
                    peroid.Name = $"{EDomain.Resources.ThisWeek} ({EDomain.Resources.Week}ទី {GetWeekNumber(now)}-{now:yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.ThisWeek} ({to.ToShortDateString()})";
                    if (maxDate!=null)
                    {
                        if (to>maxDate.Value && maxDate.Value>DateTimePicker.MinimumDateTime)
                        {
                            from = FirstDayOfWeek(maxDate.Value);
                            to = LastDayOfWeek(maxDate.Value);
                            to = to > maxDate.Value ? maxDate.Value : to;
                            peroid.Name = $"{EDomain.Resources.ThisWeek} ({EDomain.Resources.Week}ទី {GetWeekNumber(now)}-{now:yyyy})";
                            peroid.AsOfName = $"{EDomain.Resources.ThisWeek} គិតត្រឹមថ្ងៃ៖{to.ToShortDateString()}";
                        }
                    }
                    
                    break;
                case DatePeroid.ThisMonth:
                    from    = FirstDayOfMonth(now);
                    to = LastDayOfMonth(now);
                    peroid.Name = $"{EDomain.Resources.ThisMonth} ({now:MMM-yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.ThisMonth} ({to.ToShortDateString()})";
                    if (maxDate != null)
                    {
                        if (to > maxDate.Value && maxDate.Value > DateTimePicker.MinimumDateTime)
                        {
                            from = FirstDayOfMonth(maxDate.Value);
                            to = LastDayOfMonth(maxDate.Value);
                            to = to > maxDate.Value ? maxDate.Value : to;
                            peroid.Name = $"{EDomain.Resources.ThisMonth} ({now:MMM-yyyy})";
                            peroid.AsOfName = $"{EDomain.Resources.ThisMonth} គិតត្រឹមថ្ងៃ៖{to.ToShortDateString()}";
                        }
                    }
                    
                    break;
                case DatePeroid.ThisQuarter:
                    from = FirstDayOfQuarter(now);
                    to = LastDayOfQuarter(now);
                    peroid.Name = $"{EDomain.Resources.ThisQuarter} ({GetQuarter(DateTime.Now.Month)} {DateTime.Now:yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.ThisQuarter} ({to.ToShortDateString()})";
                    if (maxDate != null)
                    {
                        if (to > maxDate.Value && maxDate.Value > DateTimePicker.MinimumDateTime)
                        {
                            from = FirstDayOfQuarter(maxDate.Value);
                            to = LastDayOfQuarter(maxDate.Value);
                            to = to > maxDate.Value ? maxDate.Value : to;
                            peroid.Name = $"{EDomain.Resources.ThisQuarter} ({GetQuarter(DateTime.Now.Month)} {DateTime.Now:yyyy})";
                            peroid.AsOfName = $"{EDomain.Resources.ThisQuarter} គិតត្រឹមថ្ងៃ{to.ToShortDateString()}";
                        }
                    }
                    
                    break;
                case DatePeroid.ThisFiscalYear:
                    from = FirstDayOfYear(now);
                    to = LastDayOfYears(now);
                    peroid.Name = $"{EDomain.Resources.ThisYear} ({DateTime.Now:yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.ThisYear} ({to.ToShortDateString()})";
                    if (maxDate != null)
                    {
                        if (to > maxDate.Value && maxDate.Value > DateTimePicker.MinimumDateTime)
                        {
                            from = FirstDayOfYear(maxDate.Value);
                            to = LastDayOfYears(maxDate.Value);
                            to = to > maxDate.Value ? maxDate.Value : to;
                            peroid.Name = $"{EDomain.Resources.ThisYear} ({DateTime.Now:yyyy})";
                            peroid.AsOfName = $"{EDomain.Resources.ThisYear} គិតត្រឹមថ្ងៃ{to.ToShortDateString()}";
                        }
                    }
                    
                    break;
                case DatePeroid.LastWeek:
                    from = FirstDayOfLastWeek(DateTime.Now);
                    to = LastDayOfLastWeek(DateTime.Now);
                    peroid.Name = $"{EDomain.Resources.LastWeek} ({EDomain.Resources.Week}ទី {GetWeekNumber(now) - 1}-{DateTime.Now:yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.LastWeek} ({to.ToShortDateString()})";
                    break;
                case DatePeroid.LastMonth:
                    from = FirstDayOfLastMonth(now);
                    to = LastDayOfLastMonth(now);
                    peroid.Name = $"{EDomain.Resources.LastMonth} ({DateTime.Now.AddMonths(-1):MMM-yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.LastMonth}​ ({to.ToShortDateString()})";
                    break;
                case DatePeroid.LastQuarter:
                    from = FirstDayOfLastQuarter(now);
                    to = LastDayOfLastQuarter(now);
                    peroid.Name = $"{EDomain.Resources.LastQuater} ({GetQuarter(FirstDayOfLastQuarter(now).Month)} {DateTime.Now.AddMonths(-3):yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.LastQuater} ({to.ToShortDateString()})";
                    break;
                case DatePeroid.LastFiscalYear:
                    from = FirstDayOfLastYear(now);
                    to = LastDayOfLastYears(now);
                    peroid.Name = $"{EDomain.Resources.LastYear} ({DateTime.Now.AddYears(-1):yyyy})";
                    peroid.AsOfName = $"{EDomain.Resources.LastYear} ({to.ToShortDateString()})";
                    break;
                case DatePeroid.Custom:
                    from = DateTime.Now.Date;
                    to = DateTime.Now.Date;
                    peroid.Name = EDomain.Resources.Choose;
                    peroid.AsOfName = EDomain.Resources.Choose;
                    break;

            }

            to = to.Date.AddDays(1).AddSeconds(-1);
            peroid.FromDate = from;
            peroid.ToDate = to;
            return peroid;
        }

        public static DateTimePeroid GetPeriod(CustomDateRang range,DateTime? date)
        {
            if (date == null)
            {
                date = DateTime.Now;
            }
            else
            {
                date = date < DateTimePicker.MinimumDateTime ? DateTime.Now : date;
            }


            var from = DateTime.Now;
            var to = DateTime.Now;
            var peroid = new DateTimePeroid();
            peroid.Peroid =  DatePeroid.Custom;

            switch (range)
            {
                case CustomDateRang.AsOfDate:
                    from = date.Value.Date;
                    to = date.Value.Date;
                    peroid.Name = $"គិតត្រឹមថ្ងៃ៖{to.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break; 
                case CustomDateRang.AsOfMonthToDate:
                    from = new DateTime(date.Value.Year,date.Value.Month,1);
                    to = date.Value.Date;
                    peroid.Name = $"ក្នុងខែ៖{FormatHelper.CurrentCulture.DateTimeFormat.GetMonthName(to.Month)} គិតត្រឹមថ្ងៃ៖{to.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break;
                case CustomDateRang.AsOfYearToDate:
                    from = new DateTime(date.Value.Year, 1, 1);
                    to = date.Value.Date;
                    peroid.Name = $"ក្នុងឆ្នាំ៖{to.Year} គិតត្រឹមថ្ងៃ៖{to.Date.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break;
                case CustomDateRang.MonthToDate:
                    from = new DateTime(date.Value.Year, date.Value.Month, 1);
                    to = date.Value.Date;
                    peroid.Name = $"ក្នុងខែ៖{FormatHelper.CurrentCulture.DateTimeFormat.GetMonthName(to.Month)} ចាប់ពី៖{from.ToShortDateString()} ដល់៖{to.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break;
                case CustomDateRang.YearToDate:
                    from = new DateTime(date.Value.Year, 1, 1);
                    to = date.Value.Date;
                    peroid.Name = $"ក្នុងឆ្នាំ៖{to.Year} ចាប់ពី៖{from.ToShortDateString()} ដល់៖{to.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break;
                default:
                    from = date.Value.Date;
                    to = date.Value.Date;
                    peroid.Name = $"ចាប់ពី៖{from.ToShortDateString()} ដល់៖{to.ToShortDateString()}";
                    peroid.AsOfName = peroid.Name;
                    break;

            }

            to = to.Date.AddDays(1).AddSeconds(-1);
            peroid.FromDate = from;
            peroid.ToDate = to;
            return peroid;
        }

        // Week
        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = FormatHelper.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset).Date;
            return fdowDate;
        }
        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }
        public static DateTime FirstDayOfLastWeek(DateTime date)
        {
            DateTime mondayOfLastWeek = date.AddDays(-(int)date.DayOfWeek - 6).Date;
            return mondayOfLastWeek;
        } 
        public static DateTime LastDayOfLastWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfLastWeek(date).AddDays(6);
            return ldowDate;
        }
        public static int GetWeekNumber(DateTime date)
        {
            CultureInfo ciCurr = FormatHelper.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek,date.DayOfWeek);
            return weekNum;
        }

        // GetQuarter
        public static string GetQuarter(int month)
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

        //Month
        public static DateTime FirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
        public static DateTime LastDayOfMonth(DateTime date)
        {
            DateTime firstDayOfTheMonth = new DateTime(date.Year, date.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }
        public static DateTime FirstDayOfLastMonth(DateTime date)
        {
            return date.AddDays(1 - date.Day).AddMonths(-1).Date;
        }
        public static DateTime LastDayOfLastMonth(DateTime date)
        {
            DateTime firstDayLastMonth = date.AddDays(1 - date.Day).AddMonths(-1);
            return new DateTime(firstDayLastMonth.Year, firstDayLastMonth.Month, DateTime.DaysInMonth(firstDayLastMonth.Year, firstDayLastMonth.Month));
        }

        //Quarter
        public static DateTime FirstDayOfQuarter(DateTime date)
        { 
            var quarterNumber = (date.Month - 1) / 3 + 1;
            return new DateTime(date.Year, (quarterNumber - 1) * 3 + 1, 1);
        }
        public static DateTime LastDayOfQuarter(DateTime date)
        {
            return FirstDayOfQuarter(date).AddMonths(3).AddDays(-1);
        }
        public static DateTime FirstDayOfLastQuarter(DateTime date)
        {
            return FirstDayOfQuarter(date).AddMonths(-3).Date;
        }
        public static DateTime LastDayOfLastQuarter(DateTime date)
        {
            return FirstDayOfLastQuarter(date).AddMonths(3).AddDays(-1);
        }

        // Financial Years
        public static DateTime FirstDayOfYear(DateTime date)
        {
            return new DateTime(date.Year, 1, 1);
        }
        public static DateTime LastDayOfYears(DateTime date)
        {
            return new DateTime(date.Year, 12, 31);
        }
        public static DateTime FirstDayOfLastYear(DateTime date)
        {
            return new DateTime(date.Year - 1, 1, 1);
        }
        public static DateTime LastDayOfLastYears(DateTime date)
        {
            return new DateTime(date.Year - 1, 12, 31);
        } 
    }

    public enum CustomDateRang
    { 
        MonthToDate,
        YearToDate,
        AsOfDate,
        AsOfMonthToDate,
        AsOfYearToDate, 
        None
    }

    public enum DatePeroid
    {
        Today,
        Yesterday,
        ThisWeek,
        ThisMonth,
        ThisQuarter,
        ThisFiscalYear,
        LastWeek,
        LastMonth,
        LastQuarter,
        LastFiscalYear,
        Custom,
    }

    public class DateTimePeroid
    {
        public DatePeroid Peroid { get; set; }
        public string Name { get; set; }
        public string AsOfName { get; set; }
        public string PrettyDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public override string ToString()
        {
            return AsOfName;
        }
    } 
}
