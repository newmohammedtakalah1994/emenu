using emenu.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources.ProductVariants
{
    public class CreateProductVariantRes
    {
      
        public int ProductId { get; set; }

        public ICollection<CreateProductDetailsRes> ProductDetails { get; set; }

        public ICollection<CreateProductVariantImageRes> ProductVariantImages { get; set; }
    }
}
