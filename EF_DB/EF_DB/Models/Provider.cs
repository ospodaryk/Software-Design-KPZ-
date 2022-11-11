using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class Provider
    {
        public int IdProvider { get; set; }
        public int? IdBrand { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public long? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? DeliveryTime { get; set; }

        public virtual Brand? IdBrandNavigation { get; set; }
    }
}
