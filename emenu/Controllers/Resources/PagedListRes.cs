using emenu.Core.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources
{
    public class PagedListRes<R>
    {

        public PagingInfo PagingInfo { get; set; }

        public List<R> Items { get; set; }

        public PagedListRes(PagingInfo pagingInfo, List<R> _Items)
        {
            this.PagingInfo = pagingInfo;
            this.Items = _Items;
        }
    }
}
