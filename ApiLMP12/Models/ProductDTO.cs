using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLMP12.Models
{
    public class ProductDTO
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public string  Description { get; set; }
        public Guid Id { get;  set; }
        public decimal Quantity { get; set; }
    }
}
