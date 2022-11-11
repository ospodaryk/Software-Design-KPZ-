using System;
using System.Collections.Generic;

namespace EF_DB.Models
{
    public partial class Order
    {
        public int IdOrder { get; set; }
        public int IdCustomer { get; set; }
        public int IdShoes { get; set; }
        public DateTime DateOrder { get; set; }
        public int? IdCard { get; set; }
        public int IdEmployee { get; set; }
        public int? IdProduct { get; set; }

        public virtual DiscountCard? IdCardNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual Crew IdEmployeeNavigation { get; set; } = null!;
        public virtual AdditionalProduct? IdProductNavigation { get; set; }
        public virtual Shoe IdShoesNavigation { get; set; } = null!;
    }
}
