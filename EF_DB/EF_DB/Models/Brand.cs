using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Providers = new HashSet<Provider>();
            Shoes = new HashSet<Shoe>();
        }

        public int IdBrand { get; set; }
        public string Name { get; set; } = null!;
        public long Price { get; set; }
        public string Email { get; set; } = null!;
        public string? TypeShoes { get; set; }

        public virtual ICollection<Provider> Providers { get; set; }
        public virtual ICollection<Shoe> Shoes { get; set; }
    }
}
