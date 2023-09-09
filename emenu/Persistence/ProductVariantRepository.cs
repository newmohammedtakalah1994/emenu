using emenu.Core.Contracts;
using emenu.Core.Models;
using emenu.Core.Models.Helper;
using emenu.Core.Models.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Persistence
{
    public class ProductVariantRepository : Repository, IProductVariantRepository
    {
        private readonly ApplicationDbContext _context;


        public ProductVariantRepository(ApplicationDbContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters)
        {
            var query = _context.ProductVariants
                        .Include(pv => pv.ProductDetails)
                        .ThenInclude(pa => pa.VariantValue)
                //  .Include(c => c.Image)
                .AsQueryable();
            query = FilterAndOrder(query, filters);

            return await query.ToListAsync();
        }


        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            return await _context.ProductVariants
                                .Include(pv => pv.ProductDetails)
                                .ThenInclude(pa => pa.VariantValue)
                             .Where(o => o.Id == id)
                          //  .Include(c => c.Image)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters,PagingParams pagingParams)
        {

            var query = _context.ProductVariants
                .Include(pv => pv.ProductDetails)
                .ThenInclude(pa => pa.VariantValue)
                        //  .Include(c => c.Image)
                        .AsQueryable();

            PagedList<ProductVariant> PagedUsers = await GetPagedListAsync(query, pagingParams.PageNumber, pagingParams.PageSize);

            query = FilterAndOrder(query, filters);

            return PagedUsers;
        }

        public void Add(ProductVariant ProductVariant)
        {
            _context.AddAsync(ProductVariant);
        }


        public void Remove(ProductVariant ProductVariant)
        {
            _context.Remove(ProductVariant);
        }

        private IQueryable<ProductVariant> FilterAndOrder(IQueryable<ProductVariant> query, ProductVariantQuery filters)
        {
            if (filters.ProductId.HasValue)
                query = query.Where(c => c.ProductId == filters.ProductId);
           
            query = GetOrderdQuery(query, filters.OrderBy, filters.IsDesc);
            return query;
        }

    }
}
