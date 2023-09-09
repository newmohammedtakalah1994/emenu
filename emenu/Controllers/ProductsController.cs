using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu.Controllers.Resources.Products;
using emenu.Core.Contracts;
using emenu.Core.Models;
using emenu.Core.Models.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using emenu.Core.Services;

namespace emenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;
        private readonly HelperService _helperService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(
            HelperService helperService,
            ProductService ProductService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _helperService = helperService;
            _productService = ProductService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductRes>>> GetProducts([FromQuery]ProductsQuery filters)
        {
            var products = await _productService.GetProductsAsync(filters);

            var results = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductRes>>(products);
            return Ok(results);
        }


        
        [HttpGet("paged")]
        //return Products for dashboard
        public async Task<ActionResult> GetPagedProductsAsync([FromQuery]ProductsQuery filters, [FromQuery]PagingParams pagingParams)
        {
            var Products = await _productService.GetPagedProductsAsync(filters, pagingParams);
            var result = _helperService.ToPageListResource<Product, ProductRes>(Products);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var Product = await _productService.GetProductByIdAsync(id);
            if (Product == null)
                return NotFound("Product is not found");

            var result = _mapper.Map<Product, ProductRes>(Product);

            return Ok(result);
        }

     
        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Product Product = _mapper.Map<CreateProductRes, Product>(resource);

            await _productService.Add(Product);

            return Ok();
        }

      
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRes resource)
        {
            var Product = await _productService.GetProductByIdAsync(id);
            if (Product == null)
                return NotFound("Product is not found");

            if(resource.NameEn == null)
            {
                resource.NameEn = Product.NameEn;
            }
            if (resource.NameAr == null)
            {
                resource.NameAr = Product.NameAr;
            }
            if (resource.DescEn == null)
            {
                resource.DescEn = Product.DescEn;
            }
            if (resource.DescAr == null)
            {
                resource.DescAr = Product.DescAr;
            }
            if (resource.ImageId == null)
            {
                resource.ImageId = Product.ImageId;
            }
           

            _mapper.Map(resource, Product);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var Product = await _productService.GetProductByIdAsync(id);
            if (Product == null)
                return NotFound("Product is not found");

            await _productService.RemoveProduct(Product);

            return Ok();
        }


    }
}