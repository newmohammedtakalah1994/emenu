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
    public class ProductRepository : Repository, IProductRepository
    {
        private readonly ApplicationDbContext _context;


        public ProductRepository(ApplicationDbContext context )
        {
            _context = context;
        }


        public async Task<IEnumerable<Product>> GetProductsAsync(ProductsQuery filters)
        {
            var query = _context.Products
                .Include(p => p.Image)
                .AsQueryable();

            query = FilterAndOrder(query, filters);

            return await query.ToListAsync();
        }

     
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                              .Include(p => p.ProductVariants)
                                    .ThenInclude(pv => pv.ProductDetails)
                                    .ThenInclude(pa => pa.VariantValue)
                             .Where(o => o.Id == id)
                             .Include(p => p.ProductVariants)
                                    .ThenInclude(pv => pv.ProductVariantImages)
                                    .ThenInclude(pvi => pvi.Image)
                            .Include(c => c.Image)
                             .Include(p => p.ProductImages)
                                    .ThenInclude(pi => pi.Image)
                            .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Product>> GetPagedProductsAsync(ProductsQuery filters, PagingParams pagingParams)
        {

            var query = _context.Products
                        .Include(c => c.Image)
                        .AsQueryable();

            query = FilterAndOrder(query, filters);

            PagedList<Product> PagedUsers = await GetPagedListAsync(query, pagingParams.PageNumber, pagingParams.PageSize);

            return PagedUsers;
        }

        public void Add(Product Product)
        {
            _context.AddAsync(Product);
        }


        public void Remove(Product Product)
        {
            _context.Remove(Product);
        }

        private IQueryable<Product> FilterAndOrder(IQueryable<Product> query, ProductsQuery filters)
        {
            //if filter.name like arabic name or english name
            if (!string.IsNullOrWhiteSpace(filters.Name))
                query = query.Where(m =>
                    EF.Functions.Like(m.NameEn, $"%{filters.Name}%")
                    );

            if (!string.IsNullOrWhiteSpace(filters.NameAr))
                query = query.Where(m =>
                    EF.Functions.Like(m.NameAr, $"%{filters.NameAr}%")
                    );

            query = GetOrderdQuery(query, filters.OrderBy, filters.IsDesc);
            return query;
        }

    }
}
