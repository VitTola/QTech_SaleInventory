using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EasyServer.Domain.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EDomain = EasyServer.Domain;
    

namespace QTech.Component.Helpers
{
    public static class Validator
    {
        public static bool IsValidDigit(this string value, int digit, int decimalDigit)
        {
            // ^\d{0,6}(\.\d{0,2})?$
            var pattern = $@"^\d{{0,{digit}}}(\.\d{{0,{decimalDigit}}})?$";
            var regx = new Regex(pattern).IsMatch(value);       
            return regx;
        }

        //public static bool IsEmail(string value)
        //{
        //    //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        //    //     @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //    //     @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        //    //System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
        //    //if (re.IsMatch(value))
        //    //    return (true);
        //    //else
        //    //    return (false);

        //    return true;
        //}
        //public static bool IsUrl(string value)
        //{
        //    //string strRegex = @"^[a-zA-Z0-9\-\.]+\.(com|org|net|mil|edu|COM|ORG|NET|MIL|EDU)$";
        //    //System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
        //    //if (re.IsMatch(value))
        //    //    return (true);
        //    //else
        //    //    return (false);
        //    return true;
        //}
        //public static bool IsPhone(string value)
        //{
        //    //string strRegex = @"^[0-9 ]{9,15}$";
        //    //System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(strRegex);
        //    //if (re.IsMatch(value))
        //    //    return (true);
        //    //else
        //    //    return (false);
        //    return true;
        //}
        //public static bool IsNumeric(string value)
        //{
        //    try
        //    {
        //        double.Parse(value);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        //public static bool IsInteger(string value)
        //{
        //    try
        //    {
        //        int.Parse(value);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        //public static bool IsUInteger(string value)
        //{
        //    return IsInteger(value) && Parse.ToInt(value) >= 0;
        //}
        //public static bool IsUNumeric(string value)
        //{
        //    return IsNumeric(value) &&  Parse.ToDouble(value) >= 0;
        //}
        //public static bool IsNotBlank(string value)
        //{
        //    return string.IsNullOrEmpty(value) == false;
        //}
        //public static bool IsValidLatitute(decimal lat)
        //{
        //    return lat >= -90 & lat <= 90;
        //}
        //public static bool IsValidLongtitue(decimal lng)
        //{
        //    return lng >= -180 & lng <= 180;
        //}

        //public static bool IsValidLatitute(string latStr)
        //{
        //    if (string.IsNullOrEmpty(latStr)) return false;
        //    var lat = Parse.ToDecimal(latStr);
        //    return IsValidLatitute(lat);
        //}
        //public static bool IsValidLongtitue(string lngStr)
        //{
        //    if (string.IsNullOrEmpty(lngStr)) return false;
        //    var lng = Parse.ToDecimal(lngStr);
        //    return IsValidLongtitue(lng);
        //}
        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) ||
                (strInput.StartsWith("[") && strInput.EndsWith("]")) || (strInput.StartsWith("") && strInput.EndsWith("")))
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException)
                {
                    return false;
                }
                catch (Exception) //some other exception
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidRequired(this TextBox textBox,string requiredMessage,TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = (EDomain.Helpers.Validator.IsNotBlank(textBox.Text.Trim()) || !string.IsNullOrWhiteSpace(textBox.Text.Trim()));
            if (!valid)
            { 
                textBox.ShowValidation(string.Format(EDomain.Resources.MsgFieldRequire,requiredMessage),alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        

        public static bool IsValidRequired(this Control control, string requiredMessage, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsNotBlank(control.Text);
            if (!valid)
            {
                control.ShowValidation(string.Format(EDomain.Resources.MsgFieldRequire, requiredMessage),alignment);
            }
            else
            {
                control.HideValidation();
            }
            return valid;
        }

        public static void IsExists(this Control textbox, string value, TabAlignment alignment = TabAlignment.Right)
        {
            textbox.ShowValidation(string.Format(EDomain.Resources.MsgFieldExists, value),alignment);
        }

        public static bool IsValidEmail(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsEmail(textBox.Text);
            if(!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputEmail,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidUrl(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsUrl(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputUrl,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidPhone(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsPhone(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputPhone,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsNotBlank(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsNotBlank(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputData,alignment );
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidNumberic(this TextBox textBox, bool isShowValidation = true, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsNumeric(textBox.Text);
            if (!valid)
            {
                if (isShowValidation)
                    textBox.ShowValidation(EDomain.Resources.MsgPleaseInputNumber,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        //public static bool IsValidNumberic(this DataGridViewCell textBox, bool isShowValidation = true, TabAlignment alignment = TabAlignment.Right)
        //{
        //    bool valid = EDomain.Helpers.Validator.IsNumeric(textBox.Value.ToString());
        //    if (!valid)
        //    {
        //        if (isShowValidation)
        //            textBox.ShowValidation(EDomain.Resources.MsgPleaseInputNumber, alignment);
        //    }
        //    else
        //    {
        //        textBox.HideValidation();
        //    }
        //    return valid;
        //}

        public static bool IsValidInteger(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsInteger(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputInteger,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidUNumeric(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsUNumeric(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputUnsignedNumber,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidUInteger(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = false;
            if (textBox.IsNotBlank())
            {
                valid = EDomain.Helpers.Validator.IsUInteger(textBox.Text);
            }
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputUnsignedInteger,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }

        public static bool IsValidLatitute(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsValidLatitute(textBox.Text); 
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPlsInputLatitute,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
        public static bool IsValidLongtitute(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = EDomain.Helpers.Validator.IsValidLongtitue(textBox.Text);
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPlsInputLongtitute,alignment);
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }


        public static bool IsGreaterThenZero(this TextBox textBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = false;
            if (EDomain.Helpers.Validator.IsNumeric(textBox.Text))
            {
                valid = Parse.ToDecimal(textBox.Text) > 0;
            }
            if (!valid)
            {
                textBox.ShowValidation(EDomain.Resources.MsgPleaseInputGreaterZero,alignment );
            }
            else
            {
                textBox.HideValidation();
            }
            return valid;
        }
         

        public static bool IsSelected(this ComboBox comboBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = comboBox.SelectedIndex != -1;
            if (!valid)
            {
                comboBox.ShowValidation(EDomain.Resources.MsgPleaseSelectValue,alignment);
            }
            else
            {
                comboBox.HideValidation();
            }
            return valid;
        }

        public static bool IsSelected(this ExComboBox comboBox, TabAlignment alignment = TabAlignment.Right)
        {
            bool valid = comboBox.Value  != null;
            if (!valid)
            {
                comboBox.ShowValidation(EDomain.Resources.MsgPleaseSelectValue,alignment);
            }
            else
            {
                comboBox.HideValidation();
            }
            return valid;
        }

         
         
        public static Rectangle GetBounds(this Control control)
        { 
            return new Rectangle(control.Location.X - 1, control.Location.Y - 1, control.Width + 2, control.Height + 2);
        }

        public static void ShowValidation(this Control parent, string info, TabAlignment alignment = TabAlignment.Right)
        {
            
            var p = parent?.Parent;
            if (p!=null)
            {
                /*
                 * Clear Validations
                 */
                listInvalidConrols.RemoveAll(x => x.FindForm() != parent.FindForm());
                parent.HideValidation();

                parent.Click += new EventHandler(parent_ClickShowValidation);
                parent.Leave += new EventHandler(parent_LeaveToHideValidation);
                parent.Enter += new EventHandler(parent_ClickShowValidation);
                p.Paint += (s, e) =>
                {

                    if (listInvalidConrols.Contains(parent))
                    {
                        var bound = parent.GetBounds();
                        ControlPaint.DrawBorder(e.Graphics, bound,
                          Color.Red, 2, ButtonBorderStyle.Solid,
                          Color.Red, 2, ButtonBorderStyle.Solid,
                          Color.Red, 2, ButtonBorderStyle.Solid,
                          Color.Red, 2, ButtonBorderStyle.Solid);
                    }
                };
                p.Invalidate(parent.GetBounds());
                Validation frmV = new Validation(parent, info, alignment);
                parent.Tag = frmV;
                // add conrol to invalid input list!
                // focus on first invalid conrol in list.
                listInvalidConrols.Add(parent);
                if (listInvalidConrols[0].Focused)
                {
                    parent_ClickShowValidation(listInvalidConrols[0], EventArgs.Empty);
                }
                else
                {
                    listInvalidConrols[0].Focus();
                }
            } 

            
        }

        

        static void parent_LeaveToHideValidation(object sender, EventArgs e)
        {
            if (((Control)sender).Tag is Validation frmV)
            {
                if (!frmV.Show)
                {
                    return;
                }
                frmV.Show = false;
            }
        }

        static void parent_ClickShowValidation(object sender, EventArgs e)
        {
            if (((Control)sender).Tag is Validation frmV)
            {
                if (frmV.Show)
                {
                    return;
                }
                frmV.Show = true;
            }            
        }


        public static void HideValidations(this Control Parent)
        {
            foreach (Control item in Parent.Controls)
            {
                foreach (Control inner in item.Controls)
                {
                    inner.HideValidations();
                }
                item.HideValidation();
            }
            listInvalidConrols.Clear();
        }
        public static void HideValidation(this Control control)
        {
            if (control.Tag is Validation frmV)
            { 
                control.Leave -= hideValidionOnLeave;
                control.Click -= showValidionOnClick;
                control.Enter -= showValidionOnClick; 
                if (frmV != null)
                {
                    frmV.Reset();
                }
                control.Parent.Invalidate(control.GetBounds());
                listInvalidConrols.Remove(control);
            }
        }

        static void hideValidionOnLeave(object sender, EventArgs e)
        {
            HideValidationOnLeave(sender as Control);
        }

        public static void HideValidationOnLeave(this Control sender)
        {
            if (sender.Tag is Validation frmV)
            {
                if (!frmV.Show)
                {
                    return;
                }
                frmV.Show = false;
            } 
        }

        static void showValidionOnClick(object sender, EventArgs e)
        {
            if (((Control)sender).Tag is Validation frmV)
            {
                if (frmV.Show)
                {
                    return;
                }
                frmV.Show = true;
            }             
        }
        public static List<Control> listInvalidConrols = new List<Control>(); 
    }
}
