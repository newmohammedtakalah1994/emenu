using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources.Products
{
    public class UpdateProductRes
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string DescEn { get; set; }
        public string DescAr { get; set; }

        public int? ImageId { get; set; }

    }
}
