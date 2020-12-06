using System;
using System.Collections.Generic;

namespace ApiLMP12.DataAccess
{
    public partial class InvoiceProductItems
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid InvoiceId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public virtual Invoices Invoice { get; set; }
        public virtual Products Product { get; set; }
    }
}
