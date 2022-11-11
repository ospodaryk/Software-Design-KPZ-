using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EF_DB.Models
{
    public partial class Crew
    {
        public Crew()
        {
            Orders = new HashSet<Order>();
        }

        public int IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
