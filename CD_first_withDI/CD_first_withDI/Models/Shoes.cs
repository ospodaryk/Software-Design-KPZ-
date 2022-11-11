using System.ComponentModel.DataAnnotations;

namespace CD_first_withDI.Models
{
    public class Shoes
    {
        [Key]
        public int IdShoes { get; set; }
        public string BrandName { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        public string Color { get; set; } = null!;
    }
}
