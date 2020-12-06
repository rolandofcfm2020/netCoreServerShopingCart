using System;
using System.Collections.Generic;

namespace ApiLMP12.DataAccess
{
    public partial class Products
    {
        public Products()
        {
            InvoiceProductItems = new HashSet<InvoiceProductItems>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Sku { get; set; }
        public decimal? Cost { get; set; }
        public string CurrencyCode { get; set; }

        public virtual ICollection<InvoiceProductItems> InvoiceProductItems { get; set; }
    }
}
