using System.Linq;
using System.Windows.Forms;

namespace QTech.Component.Helpers
{
    public static class ViewBinding
    {
        public static void ViewControls<T>(this Control container,T model)
        {
            if (model == null)
            {
                return;
            } 
            foreach (var txt in container.Controls.OfType<TextBox>())
            {
                var propertyName = txt.Name.Replace(nameof(txt), string.Empty);

                var property= model.GetType().GetProperty(propertyName);
                txt.DataBindings.Add(nameof(txt.Text), model, propertyName);
                //if (property.PropertyType== typeof(string))
                //{
                //    txt.DataBindings.Add(nameof(txt.Text), model, propertyName,false, DataSourceUpdateMode.OnPropertyChanged,"");
                    
                //}
                //else if (property.PropertyType==typeof(int))
                //{
                //    txt.DataBindings.Add(nameof(txt.Text), model, propertyName, true, DataSourceUpdateMode.OnPropertyChanged, "","N0");
                //}
                //else if (property.PropertyType==typeof(decimal))
                //{
                //    txt.DataBindings.Add(nameof(txt.Text), model, propertyName, true, DataSourceUpdateMode.OnPropertyChanged, "","N2"); 
                //} 
            }
            foreach (var cbo in container.Controls.OfType<ComboBox>())
            {
                cbo.DataBindings.Add(nameof(cbo.SelectedValue), model, cbo.Name.Replace(nameof(cbo), string.Empty));
            }
            foreach (var dtp in container.Controls.OfType<DateTimePicker>())
            {
                dtp.DataBindings.Add(nameof(dtp.Value), model, dtp.Name.Replace(nameof(dtp), string.Empty));
            }
        }
    }
}
