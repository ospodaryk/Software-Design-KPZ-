using System.ComponentModel.DataAnnotations;

namespace CD_first_withDI.Models
{
    public class Employee
    {
        [Key]
        public int IdEmployee { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public long PhoneNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
