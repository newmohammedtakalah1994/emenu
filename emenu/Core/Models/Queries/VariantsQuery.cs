using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models.Queries
{
    public class VariantsQuery 
        //: OrderedQuery
    {
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string OrderBy { get; set; }
        public bool IsDesc { get; set; }
    }
}
