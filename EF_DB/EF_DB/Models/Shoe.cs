using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class Shoe
    {
        public Shoe()
        {
            AdditionalProducts = new HashSet<AdditionalProduct>();
            Orders = new HashSet<Order>();
        }

        public int IdShoes { get; set; }
        public int IdBrand { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        public string Color { get; set; } = null!;

        public virtual Brand IdBrandNavigation { get; set; } = null!;
        public virtual ICollection<AdditionalProduct> AdditionalProducts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
