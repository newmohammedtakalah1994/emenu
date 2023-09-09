using emenu.Core.Models.Queries;
using emenu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu.Core.Models.Helper;

namespace emenu.Core.Contracts
{
    public interface IVariantValueRepository
    {
        Task<VariantValue> GetVariantValueByIdAsync(int id);
        Task<IEnumerable<VariantValue>> GetVariantValuesAsync(VariantValuesQuery filters);
        Task<PagedList<VariantValue>> GetPagedVariantValuesAsync(VariantValuesQuery filters, PagingParams pagingParams);

        void Add(VariantValue variantValue);
        void Remove(VariantValue variantValue);
    }
}
