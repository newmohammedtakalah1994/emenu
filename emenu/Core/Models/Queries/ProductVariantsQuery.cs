using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models.Queries
{
    public class ProductVariantQuery 
        //: OrderedQuery
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? ProductId { get; set; }
        public string OrderBy { get; set; }
        public bool IsDesc { get; set; }
    }
}
