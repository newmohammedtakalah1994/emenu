using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using emenu.Controllers.Resources.VariantValues;
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
    public class VariantValuesController : ControllerBase
    {
        private readonly VariantValueService _VariantValueService;
        private readonly HelperService _helperService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VariantValuesController(
            HelperService helperService,
            VariantValueService VariantValueService,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _helperService = helperService;
            _VariantValueService = VariantValueService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VariantValueRes>>> GetVariantValues([FromQuery]VariantValuesQuery filters)
        {
            var VariantValues = await _VariantValueService.GetVariantValuesAsync(filters);

            var results = _mapper.Map<IEnumerable<VariantValue>, IEnumerable<VariantValueRes>>(VariantValues);
            return Ok(results);
        }


        
        [HttpGet("paged")]
        //return VariantValues for dashboard
        public async Task<ActionResult> GetPagedVariantValuesAsync([FromQuery]VariantValuesQuery filters, [FromQuery]PagingParams pagingParams)
        {
            var VariantValues = await _VariantValueService.GetPagedVariantValuesAsync(filters, pagingParams);
            var result = _helperService.ToPageListResource<VariantValue, VariantValueRes>(VariantValues);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetVariantValueById(int id)
        {
            var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
            if (VariantValue == null)
                return NotFound("VariantValue is not found");

            var result = _mapper.Map<VariantValue, VariantValueRes>(VariantValue);

            return Ok(result);
        }

        
        [HttpPost]
        public async Task<ActionResult> CreateVariantValue([FromBody] CreateVariantValueRes resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            VariantValue VariantValue = _mapper.Map<CreateVariantValueRes, VariantValue>(resource);

            await _VariantValueService.Add(VariantValue);

            return Ok();
        }

        
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVariantValue([FromRoute] int id, [FromBody] UpdateVariantValueRes resource)
        {
            var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
            if (VariantValue == null)
                return NotFound("VariantValue is not found");

           /* if(resource.CategoryId == null)
            {
                resource.CategoryId = VariantValue.CategoryId;
            }

            if (resource.ImageId == null)
            {
                resource.ImageId = VariantValue.ImageId;
            }

            if (resource.Image2Id == null)
            {
                resource.Image2Id = VariantValue.Image2Id;
            }
            if (resource.Price == null)
            {
                resource.Price = VariantValue.Price;
            }
            if (resource.Name == null)
            {
                resource.Name = VariantValue.Name;
            }
            if (resource.NameAr == null)
            {
                resource.NameAr = VariantValue.NameAr;
            }

            if (resource.Desc == null)
            {
                resource.Desc = VariantValue.Desc;
            }

            if (resource.Barcode == null)
            {
                resource.Barcode = VariantValue.Barcode;
            }
            if (resource.inStock == null)
            {
                resource.inStock = VariantValue.inStock;
            }
           */

            _mapper.Map(resource, VariantValue);

            await _unitOfWork.CompleteAsync();

            return Ok();
        }


       
    
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVariantValue([FromRoute] int id)
        {
            var VariantValue = await _VariantValueService.GetVariantValueByIdAsync(id);
            if (VariantValue == null)
                return NotFound("VariantValue is not found");

            await _VariantValueService.RemoveVariantValue(VariantValue);

            return Ok();
        }


    }
}