using emenu.Controllers.Resources.Variants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace emenu.Controllers.Resources.VariantValues
{
    public class UpdateVariantValueRes
    {
      
        public string ValueEn { get; set; }
        public string ValueAr { get; set; }

        public int VariantId { get; set; }
    }
}
