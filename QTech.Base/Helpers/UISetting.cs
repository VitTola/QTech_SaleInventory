using System;
using System.Collections.Generic;
using System.Linq;

namespace QTech.Base.Helpers
{
    public class ElementSetting
    {
        public string Name { get; set; }
    }

    public class DatePickerSetting : ElementSetting
    {
        public int DateRange { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class FromToParam : ElementSetting
    {
        public decimal ToValue { get; set; }
        public decimal FromValue { get; set; }
    }

    public class DefaultPrinterSetting : ElementSetting
    {
        public string PrinterName { get; set; }
    }

    public class ServerLinkSetting : ElementSetting
    {
        public string ConnectionEncrypt { get; set; }
    }

    public class SettingCollection<T> where T : ElementSetting
    {
        public List<T> Items = new List<T>();
        public T this[string index]
        {
            get { return this.Items.FirstOrDefault(x => x.Name == index); }
            set
            {
                var cur = this.Items.FirstOrDefault(x => x.Name == index);
                var curIndex = this.Items.IndexOf(cur);
                if (cur == null)
                {
                    this.Items.Add(value);
                }
                else
                {
                    this.Items[curIndex] = value;
                }
            }
        }
    }

    public class UISetting
    {
        //public Dictionary<string, string> DefaultPrinterSetting { get; set; } = new Dictionary<string, string>();
        public SettingCollection<FromToParam> DefaultFromToParam { get; set; } = new SettingCollection<FromToParam>();
        public SettingCollection<DefaultPrinterSetting> DefaultPrinter { get; set; } = new SettingCollection<DefaultPrinterSetting>();
        public SettingCollection<DatePickerSetting> DatePickerSettings { get; set; } = new SettingCollection<DatePickerSetting>();
    }

    public class ServerLinkConfigurationSetting
    {
        public SettingCollection<ServerLinkSetting> ServerLinkSettings { get; set; } = new SettingCollection<ServerLinkSetting>();
    }
}
