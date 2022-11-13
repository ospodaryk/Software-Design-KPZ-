using System.ComponentModel.DataAnnotations;

namespace CD_first_withDI.Models
{
    public class Customer
    {
        [Key]
        public int IdCustomer { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
    }
}
