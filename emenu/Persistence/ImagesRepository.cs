using emenu.Core.Contracts;
using emenu.Core.Models;
using emenu.Core.Models.Helper;
using emenu.Core.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Persistence
{
    public class ImagesRepository : IImageRepository
    {
        private readonly ApplicationDbContext _context;

        public ImagesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddImage(Image image)
        {
            _context.Add(image);
        }

        public void RemoveImage(Image image)
        {
            _context.Remove(image);
        }


    }
}
