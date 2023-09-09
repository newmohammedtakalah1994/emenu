using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources.Products
{
    public class ProductImageRes
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public ImageRes Image { get; set; }
        public int ProductId { get; set; }
    }
}
