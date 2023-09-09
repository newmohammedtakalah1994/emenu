using emenu.Controllers.Resources.ProductVariants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources.Products
{
    public class ProductRes
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescEn { get; set; }
        public string DescAr { get; set; }

        public int? ImageId { get; set; }
        public ImageRes Image { get; set; }

        public ICollection<ProductVariantRes> ProductVariants { get; set; }

        public ICollection<ProductImageRes> ProductImages { get; set; }

    }
}

