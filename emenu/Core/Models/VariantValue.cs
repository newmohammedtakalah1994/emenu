using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models
{
    public class VariantValue
    {
        public int Id { get; set; }
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }

        public int VariantId { get; set; }
        public Variant Variant { get; set; }
    }
}
