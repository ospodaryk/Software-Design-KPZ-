using System.ComponentModel.DataAnnotations;

namespace CD_first_withDI.ViewModel
{
    public class ShoesViewModel
    {
        [Required]
        public int IdShoes { get; set; }
        public string BrandName { get; set; }
        public int Amount { get; set; }
        public int Size { get; set; }
        [Required]
        public string Color { get; set; } = null!;
    }
}
