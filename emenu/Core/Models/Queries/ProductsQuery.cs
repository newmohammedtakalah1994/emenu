using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models.Queries
{
    public class ProductsQuery 
        //: OrderedQuery
    {
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string OrderBy { get; set; }
        public bool IsDesc { get; set; }
    }
}
