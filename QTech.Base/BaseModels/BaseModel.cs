using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
