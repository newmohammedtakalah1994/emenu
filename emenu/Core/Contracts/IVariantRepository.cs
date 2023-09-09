using emenu.Core.Models.Queries;
using emenu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu.Core.Models.Helper;

namespace emenu.Core.Contracts
{
    public interface IVariantRepository
    {
        Task<Variant> GetVariantByIdAsync(int id);
        Task<IEnumerable<Variant>> GetVariantsAsync(VariantsQuery filters);
        Task<PagedList<Variant>> GetPagedVariantsAsync(VariantsQuery filters, PagingParams pagingParams);

        void Add(Variant variant);
        void Remove(Variant variant);
    }
}
