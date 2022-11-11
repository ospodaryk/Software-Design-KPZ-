using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class AdditionalProduct
    {
        public AdditionalProduct()
        {
            Orders = new HashSet<Order>();
        }

        public int IdProduct { get; set; }
        public int IdShoes { get; set; }
        public int Price { get; set; }
        public string? Type { get; set; }
        public int? Amount { get; set; }

        public virtual Shoe IdShoesNavigation { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
