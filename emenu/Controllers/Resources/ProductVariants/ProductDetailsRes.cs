using emenu.Controllers.Resources.VariantValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace emenu.Controllers.Resources.ProductVariants
{
    public class ProductDetailsRes
    {
        public int Id { get; set; }
        public int ProductVariantId { get; set; }

        public int VariantValueId { get; set; }
        public VariantValueRes VariantValue { get; set; }
    }
}
