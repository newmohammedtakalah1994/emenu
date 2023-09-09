using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using emenu.Core.Contracts;
using emenu.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace emenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 //   [EnableCors("MyPolicy")]
    public class ImagesController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        private IImageRepository _imageRepository;
        private IUnitOfWork _unitOfWork;
        public ImagesController(
                IWebHostEnvironment hostingEnvironment,
                IImageRepository    imageRepository,
                IUnitOfWork unitOfWork)
        {
            _hostingEnvironment = hostingEnvironment;
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("Upload")]
        
        public async Task<ActionResult> UploadImage(IFormFile image)
        {
            string fName = image.FileName;
            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "images/" + image.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            Image image1 = new Image()
            {
                ImageInDb = null,
                ImageUrl = "images/" + image.FileName
            };

               _imageRepository.AddImage(image1);
               await _unitOfWork.CompleteAsync();

               return Ok(new { imageId = image1.Id  , imageUrl = image1.ImageUrl});
           // return Ok();
        }
    }
}
