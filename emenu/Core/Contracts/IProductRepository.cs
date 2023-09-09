using emenu.Core.Models.Queries;
using emenu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using emenu.Core.Models.Helper;

namespace emenu.Core.Contracts
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync(ProductsQuery filters);
        Task<PagedList<Product>> GetPagedProductsAsync(ProductsQuery filters,PagingParams pagingParams);
        void Add(Product product);
        void Remove(Product product);
    }
}
