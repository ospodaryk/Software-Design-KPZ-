using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.DTOs
{
    public class ShoppingDTO
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
    }
}
