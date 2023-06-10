using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductImageDTO
    {
        public int ProductImageId { get; set; }
        public int? ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
    }
}
