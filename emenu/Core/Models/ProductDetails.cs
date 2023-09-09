using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }
        public ProductVariant ProductVariant { get; set; }

        public int VariantValueId { get; set; }
        public VariantValue VariantValue { get; set; }
    }
}
