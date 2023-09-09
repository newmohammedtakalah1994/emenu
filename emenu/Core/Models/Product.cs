using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescEn { get; set; }
        public string DescAr { get; set; }

        public int? ImageId { get; set; }
        public Image Image { get; set; }

        public ICollection<ProductVariant> ProductVariants { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

    }
}
