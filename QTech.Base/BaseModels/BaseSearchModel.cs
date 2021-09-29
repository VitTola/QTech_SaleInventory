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
    public class PagedResult<T> : Paging where T : class
    {
        public IQueryable<T> Results { get; set; }
        public IEnumerable<T> EnumerableResults { get; set; }
        public PagedResult()
        {
        }
    }

    public static class PageResultExt
    {
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                            int page, int pageSize, bool rowCount = true) where T : ActiveBaseModel
        {
            var result = new PagedResult<T>();
            pageSize = pageSize == 0 ? Paging.DEFAULT_PAGE_SIZE : pageSize;

            result.CurrentPage = Math.Max(1, page);
            result.PageSize = Math.Min(pageSize, Paging.MAX_RECORD);
            if (rowCount)
            {
                result.RowCount = query.Count();
                var pageCount = (double)result.RowCount / result.PageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
            }
            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.Results = query.OrderByDescending(x => x.RowDate).Skip(skip).Take(result.PageSize);
            return result;
        }
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query, Paging paging) where T : ActiveBaseModel
        {
            return query.GetPaged(paging.CurrentPage, paging.PageSize, paging.IncludeCount);
        }
        //
        public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query,int page, int pageSize, bool isClass , bool rowCount = true) where T : class
        {
            var result = new PagedResult<T>();
            pageSize = pageSize == 0 ? Paging.DEFAULT_PAGE_SIZE : pageSize;

            result.CurrentPage = Math.Max(1, page);
            result.PageSize = Math.Min(pageSize, Paging.MAX_RECORD);
            if (rowCount)
            {
                result.RowCount = query.Count();
                var pageCount = (double)result.RowCount / result.PageSize;
                result.PageCount = (int)Math.Ceiling(pageCount);
            }
            var skip = (result.CurrentPage - 1) * result.PageSize;
            result.EnumerableResults = query.Skip(skip).Take(result.PageSize);
            return result;
        }
        public static PagedResult<T> GetPaged<T>(this IEnumerable<T> query, Paging paging) where T : class
        {
            return query.GetPaged(paging.CurrentPage, paging.PageSize, true);
        }
    }
}
