using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTech.Base.BaseModels
{
    public interface ISearchModel
    {
        string Search { get; set; }
        Paging Paging { get; set; }
    }
    public class BasicSearchModel : ISearchModel
    {
        public string Search { get; set; } = "";
        public Paging Paging { get; set; } = new Paging
        {
            IsPaging = false,
            PageSize = 50,
        };
    }

    public class Paging
    {
        public const int MAX_RECORD = 1000;
        public const int DEFAULT_PAGE_SIZE = 25;
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public bool IsPaging { get; set; } = true;

        internal bool IncludeCount { get; set; } = false;
        internal int PageCount { get; set; }
        internal int RowCount { get; set; }

    }
}
