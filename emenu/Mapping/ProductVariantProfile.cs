using emenu.Core.Models;
using emenu.Controllers.Resources.ProductVariants;

namespace emenu.Mapping
{
    public class ProductVariantProfile : AutoMapper.Profile
    {
        public ProductVariantProfile()
        {
            CreateMap<CreateProductVariantRes, ProductVariant>();

            CreateMap<UpdateProductVariantRes, ProductVariant>();

            CreateMap<ProductVariant, ProductVariantRes>();


            CreateMap<ProductDetails, ProductDetailsRes>();

            CreateMap<CreateProductDetailsRes, ProductDetails>();


        }
    }
}
