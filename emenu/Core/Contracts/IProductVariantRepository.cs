using emenu.Core.Models.Queries;
using emenu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu.Core.Models.Helper;

namespace emenu.Core.Contracts
{
    public interface IProductVariantRepository
    {
        Task<ProductVariant> GetProductVariantByIdAsync(int id);
        Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters);
        Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters, PagingParams pagingParams);

        void Add(ProductVariant productVariant);
        void Remove(ProductVariant productVariant);
    }
}
