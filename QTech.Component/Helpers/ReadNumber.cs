using System;

namespace QTech.Component.Helpers
{
    class ReadNumber
    {
        private static string[] _onesDigitKH = { "សូន្យ", "មួយ", "ពីរ", "បី", "បួន", "ប្រាំ", "ប្រាំមួយ", "ប្រាំពីរ", "ប្រាំបី", "ប្រាំបួន" };
        private static string[] _tensDigitKH = { "ដប់", "ម្ភៃ", "សាមសិប", "សែសិប", "ហាសិប", "ហុកសិប", "ចិតសិប", "ប៉ែតសិប", "កៅសិប" };
        private static string  dot = "ចុច";
        private static string nagative = "ដក";

        public static string ReadKhmer(decimal number)
        {
            if (number < 0)
            {
                return $"{nagative} {ReadKhmer(Math.Abs(number))}";
            }

            long _base = 0;
            var read = "";

            if (number < 1 && number>0)
            {
                read = $" {dot} ";

                var dec = ((decimal)number).ToString();
                dec = dec.Substring(dec.IndexOf(".")+1);
                while (dec.StartsWith("0"))
                {
                    read += _onesDigitKH[0]+" ";
                    dec = dec.Substring(1);
                }
                return read += ReadKhmer(decimal.Parse(dec));
            }

            /*
             * _base of number.
             */
            var len = number == 0 ? 0L : (long)Math.Floor(Math.Log10((double)number));
            var digit = (long)(number / (decimal)Math.Pow(10, len));
            if (len >= 36)
            {
                _base = (long)(number / (decimal)Math.Pow(10, 36));
                read += ReadKhmer(_base) + "អាន់ដេស៊ីលាន ";
                len = 36;
            }
            else if (len >= 33 && len <= 35)
            {
                _base = (long)(number / (decimal)(Math.Pow(10.0, 33.0)));
                read += ReadKhmer(_base) + "ដេស៊ីលាន ";
                len = 33;
            }
            else if (len >= 30 && len <= 32)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 30.0));
                read += ReadKhmer(_base) + "ណូនីលាន ";
                len = 30;
            }
            else if (len >= 27 && len <= 29)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 27.0));
                read += ReadKhmer(_base) + "អុកទីលាន ";
                len = 27;
            }
            else if (len >= 24 && len <= 26)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 24.0));
                read += ReadKhmer(_base) + "សិបទីលាន ";
                len = 24;
            }
            else if (len >= 21 && len <= 23)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 21.0));
                read += ReadKhmer(_base) + "សិចទីលាន ";
                len = 21;
            }
            else if (len >= 18 && len <= 20)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 18.0));
                read += ReadKhmer(_base) + "គ្វីនទីលាន ";
                len = 18;
            }
            else if (len >= 15 && len <= 17)
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 15.0));
                if (_base == 0)
                {
                    return $"{_onesDigitKH[1]} ក្វាទ្រីលាន ";
                }
                read += ReadKhmer(_base) + "ក្វាទ្រីលាន ";
                len = 15;
            }
            else if (len >= 12 && len <= 14)
            //ទ្រីលាន
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 12.0));
                read += ReadKhmer(_base) + "ទ្រីលាន ";
                len = 12;
            }
            else if (len >= 9 && len <= 11)
            // កោប៊ីលាន
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 9.0));
                read += ReadKhmer(_base) + "ប៊ីលាន ";
                len = 9;
            }
            else if (len >= 6 && len <= 8)
            // លាន
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 6.0));
                read += ReadKhmer(_base) + "លាន ";
                len = 6;
            }
            else if (len >= 3 && len <= 5)
            // ពាន់
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 3.0));
                read += ReadKhmer(_base) + "ពាន់ ";
                len = 3;
            }
            else if (len == 2)
            //រយ
            {
                _base = (long)(number / (decimal)Math.Pow(10.0, 2.0));
                read += ReadKhmer(_base) + "រយ ";
            }
            else if (len == 1)
            {
                read += _tensDigitKH[digit - 1];
            }
            else
            {
                read += _onesDigitKH[digit];
            }

            number %= (decimal)Math.Pow(10.0,len);
            if (number <= 0)
                return read;
            else
            {
                read += ReadKhmer(number);
                return read;
            }
        }
    }
}
