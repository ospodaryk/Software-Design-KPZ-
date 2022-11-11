using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Models
{
    public class ShoesID
    {
        public bool isBought { get; }
        public string Description { get; }

        public ShoesID(bool isSelct, string description)
        {
            isBought = isSelct;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Description}";
        }

        public override bool Equals(object obj)
        {
            return obj is ShoesID shoesID &&
                Description.Equals(shoesID.Description);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(isBought, Description);
        }

        public static bool operator ==(ShoesID shoesID1, ShoesID shoesID2)
        {
            if(shoesID1 is null && shoesID2 is null)
            {
                return true;
            }

            return !(shoesID1 is null) && shoesID1.Equals(shoesID2);
        }

        public static bool operator !=(ShoesID shoesID1, ShoesID shoesID2)
        {
            return !(shoesID1 == shoesID2);
        }

    }
}
