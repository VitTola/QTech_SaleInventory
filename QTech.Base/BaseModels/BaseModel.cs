using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base
{
    public class BaseModel : TBaseModel<int>
    {
        public BaseModel()
        {

        }
    }

    public class TBaseModel<TKey> : ICloneable where TKey : struct
    {
        public TBaseModel() { }

        public TKey Id { get; set; }
        public DateTime RowDate { get; set; }
        public string CreatedBy { get; set; }

        public object Clone()
        {
            return null;
        }
        public override string ToString()
        {
            var result = new List<string>();
            foreach (PropertyInfo propertyInfo in this.GetType().GetProperties()
                .Where(x => x.Name == "Code" || x.Name == "Name")
                .OrderBy(x => x.Name)
            )
            {
                result.Add(propertyInfo.GetValue(this)?.ToString());
            }

            if (result.Any())
            {
                return string.Join(" ", result.ToArray());
            }
            else
            {
                return this.Id.ToString();
            }
        }
    }
    public class LongBaseModel : TBaseModel<long>
    {
    }
}
