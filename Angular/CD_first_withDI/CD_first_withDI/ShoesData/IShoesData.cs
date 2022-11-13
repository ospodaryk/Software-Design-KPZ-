using CD_first_withDI.Models;
using CD_first_withDI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CD_first_withDI.ShoesData
{
    public interface IShoesData
    {
        List<Shoes> GetPairofShoesList();
        void AddShoes(ShoesViewModel cus);
         Shoes EditShoes(ShoesViewModel customerview);
        void DeleteShoes(int shoesId);
        Shoes GetShoes(int shoesId);

    }
}
