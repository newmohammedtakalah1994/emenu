using emenu.Core.Models;
using emenu.Controllers.Resources.Products;
using emenu.Controllers.Resources;

namespace emenu.Mapping
{
    public class ProductProfile : AutoMapper.Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductRes, Product>();

            CreateMap<UpdateProductRes, Product>();

            CreateMap<Product, ProductRes>();

            CreateMap<ImageRes, Image>();
            CreateMap<Image, ImageRes>();


            CreateMap<CreateProductImageRes, ProductImage>();
            CreateMap<ProductImage, ProductImageRes>();



        }
    }
}
