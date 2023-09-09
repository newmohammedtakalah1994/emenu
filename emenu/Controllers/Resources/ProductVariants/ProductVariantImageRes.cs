using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace emenu.Controllers.Resources.ProductVariants
{
    public class ProductVariantImageRes
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public ImageRes Image { get; set; }
        public int ProductId { get; set; }
    }
}
