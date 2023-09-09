using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models.Queries
{
    public class VariantValuesQuery 
        //: OrderedQuery
    {
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }
        public int? VariantId { get; set; }
        public string OrderBy { get; set; }
        public bool IsDesc { get; set; }
    }
}
