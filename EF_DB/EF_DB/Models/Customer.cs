using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EF_DB.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int IdCustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        [JsonIgnore]
        public int? IdCard { get; set; }
        public long? Balance { get; set; }
    
        public virtual DiscountCard? IdCardNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
