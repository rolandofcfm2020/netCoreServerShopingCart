using System;
using System.Collections.Generic;

namespace ApiLMP12.DataAccess
{
    public partial class Clients
    {
        public Clients()
        {
            Invoices = new HashSet<Invoices>();
        }

        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Invoices> Invoices { get; set; }
    }
}
