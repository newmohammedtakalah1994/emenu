using emenu.Core.Models;
using emenu.Controllers.Resources.VariantValues;

namespace emenu.Mapping
{
    public class VariantValueProfile : AutoMapper.Profile
    {
        public VariantValueProfile()
        {
            CreateMap<CreateVariantValueRes, VariantValue>();

            CreateMap<UpdateVariantValueRes, VariantValue>();

            CreateMap<VariantValue, VariantValueRes>();

        }
    }
}
