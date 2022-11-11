using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class DiscountCard
    {
        public DiscountCard()
        {
            Customers = new HashSet<Customer>();
            Orders = new HashSet<Order>();
        }

        public int IdCard { get; set; }
        public DateTime? Startdate { get; set; }
        public int Discount { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
