using emenu.Core.Contracts;
using emenu.Core.Models;
using emenu.Core.Models.Helper;
using emenu.Core.Models.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace emenu.Core.Services
{
    public class ProductVariantService 
    {
        private readonly IProductVariantRepository _ProductVariantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductVariantService(
            IProductVariantRepository ProductVariantRepository,
            IUnitOfWork unitOfWork
            )
        {
            _ProductVariantRepository = ProductVariantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductVariant>> GetProductVariantsAsync(ProductVariantQuery filters)
        {
            var list = await _ProductVariantRepository.GetProductVariantsAsync(filters);
            return list;
        }

        public async Task<PagedList<ProductVariant>> GetPagedProductVariantsAsync(ProductVariantQuery filters, PagingParams pagingParams)
        {
            var list = await _ProductVariantRepository.GetPagedProductVariantsAsync(filters, pagingParams);
            return list;
        }

        public async Task<IActionResult> Add(ProductVariant ProductVariant)
        {
            _ProductVariantRepository.Add(ProductVariant);
            await _unitOfWork.CompleteAsync();
            return new OkObjectResult("ProductVariant AddedSuccessfully");
        }

        public async Task<ProductVariant> GetProductVariantByIdAsync(int id)
        {
            return await _ProductVariantRepository.GetProductVariantByIdAsync(id);
        }

        public async Task RemoveProductVariant(ProductVariant ProductVariant)
        {
            _ProductVariantRepository.Remove(ProductVariant);
            await _unitOfWork.CompleteAsync();
        }


    }
}
