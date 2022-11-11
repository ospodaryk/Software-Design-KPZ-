using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Models
{
    public class ExistingShoes
    {
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
       


    }
   
   
}
