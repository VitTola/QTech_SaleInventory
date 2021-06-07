using Easy.Domain.Helpers;
using EasyServer.Domain.Helpers;
using Storm.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace QTech.Component.Helpers
{
    public static class FormatHelper
    {

        public static CultureInfo CurrentCulture => CultureInfo.CurrentCulture;

        private static CultureInfo kh = null;
        public static CultureInfo Khmer
        {
            get
            {
                if (kh == null)
                {
                    kh = new CultureInfo("km-KH");
                    kh.DateTimeFormat.AbbreviatedMonthNames = kh.DateTimeFormat.MonthNames;
                    kh.DateTimeFormat.LongDatePattern = DateTime[DateTimeType.LongDate];
                    kh.DateTimeFormat.ShortDatePattern = DateTime[DateTimeType.ShortDate];
                    kh.DateTimeFormat.ShortTimePattern = DateTime[DateTimeType.ShortTime];
                    kh.DateTimeFormat.LongTimePattern = DateTime[DateTimeType.LongTime];
                    kh.DateTimeFormat.FullDateTimePattern = DateTime[DateTimeType.FullLongDateTime];
                    kh.DateTimeFormat.AMDesignator = "AM";
                    kh.DateTimeFormat.PMDesignator = "PM";
                    kh.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Monday;
                    kh.NumberFormat.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                }
                return kh;
            }
        }

        private static CultureInfo en = null;
        public static CultureInfo English
        {
            get
            {
                if (en == null)
                {
                    en = new CultureInfo("en-US");
                    en.DateTimeFormat.LongDatePattern = DateTime[DateTimeType.LongDate];
                    en.DateTimeFormat.ShortDatePattern = DateTime[DateTimeType.ShortDate];
                    en.DateTimeFormat.ShortTimePattern = DateTime[DateTimeType.ShortTime];
                    en.DateTimeFormat.LongTimePattern = DateTime[DateTimeType.LongTime];
                    en.DateTimeFormat.FullDateTimePattern = DateTime[DateTimeType.FullLongDateTime];
                    en.NumberFormat.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
                }
                return en;
            }
        }



        public static Dictionary<DateTimeType, string> DateTime = new Dictionary<DateTimeType, string>()
        {
           // {DateTimeType.None,Storm.Domain.Resources.Unlimited},
            {DateTimeType.LongDate,"dddd, d MMMM, yyyy"},
            {DateTimeType.LongDateTime,"dd/MM/yyyy hh:mm:ss tt" },
            {DateTimeType.ShortDate,"dd/MM/yyyy" },
            {DateTimeType.ShortTime,"hh:mm tt"},
            {DateTimeType.LongTime,"hh:mm:ss tt"},
            {DateTimeType.FullLongDateTime,"dddd, d MMMM, yyyy hh:mm:ss tt" },
            {DateTimeType.FullShortDateTime,"dd/MM/yyyy hh:mm tt" },
            {DateTimeType.MonthYear,"MM/yyyy"},
            {DateTimeType.MonthShortYear, "MM/yy"},
            {DateTimeType.DayMonth, "dd/MM" },
        };

        public static Dictionary<DecimalType, string> Decimal = new Dictionary<DecimalType, string>()
        {
            {DecimalType.N, "#,##0" },
            {DecimalType.N2, "#,##0.##" },
            {DecimalType.N3, "#,##0.###" },
            {DecimalType.N4, "#,##0.####" },
            {DecimalType.N5, "#,##0.#####" },
            {DecimalType.N6, "#,##0.######" },
            {DecimalType.N7, "#,##0.#######" },
            {DecimalType.N7E, "#,###.#######" },
            {DecimalType.N3S, "0.######;-0.######;#" },
            {DecimalType.USD, "#,##0.00####" },
            {DecimalType.N3N, "0.######;-0.######;0" }
        };

        public enum DateTimeType
        {
            None,
            LongDate,
            LongDateTime,
            ShortDate,
            ShortTime,
            LongTime,
            FullLongDateTime,
            FullShortDateTime,
            //TimeWithoutSecond,
            //DateTimeWithSecond,
            //DateTimeWithoutSecond,
            MonthYear,
            MonthShortYear,
            DayMonth,
        }

        public enum DecimalType
        {
            N,
            N2,
            N3,
            N4,
            N5,
            N6,
            N7,
            N7E,
            N3S, // three sections format
            USD,  // for apply with unit price ex: 0.00000
            N3N, // three sections format with 0 all sections
        }

        public static string KhmerNumber(this decimal Number, string numberFormat = "#,###0.#######")
        {
            var stringNumber = Number.ToString(numberFormat);
            string resultString = string.Empty;
            foreach (char c in stringNumber)
            {
                var str = ResourceHelper.Translate($"kh_{c}");
                resultString = resultString + str;
            }

            return resultString;
        }

        public static string KhmerFullDate(this DateTime dateTime)
        {
            if (dateTime == Consts.MIN_DATE)
            {
                return string.Empty;
            }

            var khDayOfWeek = ResourceHelper.Translate(dateTime.DayOfWeek.ToString());
            var khDate = Parse.ToDecimal(dateTime.Day.ToString()).KhmerNumber("#");
            var khMonth = ResourceHelper.Translate(dateTime.ToString("MMMM"));
            var khYear = Parse.ToDecimal(dateTime.Year.ToString()).KhmerNumber("#");
            return $"ថ្ងៃ {khDayOfWeek} ទី {khDate} ខែ {khMonth} ឆ្នាំ {khYear}";
        }

        public static string ToShortNumber(decimal num)
        {
            if (num > 999999999 || num < -999999999)
            {
                return num.ToString("0,,,.###B");
            }
            else if (num > 999999 || num < -999999)
            {
                return num.ToString("0,,.##M");
            }
            else if (num > 999 || num < -999)
            {
                return num.ToString("0,.#K");
            }
            return num.ToString(Decimal[DecimalType.N4]);
        }

        public static string UnitPriceFormat(int currencyId)
        {
            return currencyId == 1 ? Decimal[DecimalType.N2] : Decimal[DecimalType.USD];
        }

        //public static string LocationFormat(this Installation installation, string code)
        //{
        //    if (installation == null)
        //    {
        //        return string.Empty;
        //    }
        //    var feeder = installation.Feeder?.ToString();
        //    if (!string.IsNullOrEmpty(feeder))
        //    {
        //        feeder = feeder == "-" ? "" : feeder;
        //    }
        //    var box = installation.BoxCode == "-" ? string.Empty : installation.BoxCode;
        //    return $"{installation.Transformer?.Code ?? string.Empty}-{feeder} {box} {code}";
        //}

        //public static string TypeFormat(this Consumer consumer)
        //{
        //    if (consumer == null)
        //    {
        //        return string.Empty;
        //    }
        //    return $"{consumer.InstallationType?.ToString()} {consumer.CustomerType?.ToString()}".Trim();
        //}

        //public static string CurrencyFormat(this Currency currency)
        //{
        //    return currency == null ? Decimal[DecimalType.N] : currency.Format ?? Decimal[DecimalType.N];
        //}
    }
}
