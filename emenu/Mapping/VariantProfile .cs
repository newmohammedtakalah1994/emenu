using emenu.Core.Models;
using emenu.Controllers.Resources.Variants;

namespace emenu.Mapping
{
    public class VariantProfile : AutoMapper.Profile
    {
        public VariantProfile()
        {
            CreateMap<CreateVariantRes, Variant>();

            CreateMap<UpdateVariantRes, Variant>();

            CreateMap<Variant, VariantRes>();


        }
    }
}
