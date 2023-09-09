using emenu.Core.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models.Helper
{
    public class PagedList<T>
    {
        public int TotalItems { get; set; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public List<T> List { get; set; }
        private IQueryable<T> Source { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling(this.TotalItems / (double)this.PageSize);
            }
        }

        public  PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Source = source;
        }

        public PagedList(List<T> source, int pageNumber, int pageSize)
        {
            this.TotalItems = source.Count();
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.List = source;
        }


        public PagingInfo GetInfo()
        {
            return new PagingInfo(
                 this.TotalItems, this.PageNumber,
                 this.PageSize, this.TotalPages);
        }
    }
}