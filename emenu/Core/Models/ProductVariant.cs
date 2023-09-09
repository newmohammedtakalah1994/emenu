using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models
{
    // this class to define variant for specfic product
    public class ProductVariant
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<ProductDetails> ProductDetails { get; set; }

        public ICollection<ProductVariantImage> ProductVariantImages { get; set; }
    }
}
