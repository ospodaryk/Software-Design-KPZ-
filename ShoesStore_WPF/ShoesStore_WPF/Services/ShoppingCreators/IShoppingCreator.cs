using ShoesStore.Models;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingCreators
{
    public interface IShoppingCreator
    {
        Task CreateReservation(Shopping shopping, System.Collections.ObjectModel.ObservableCollection<ExistingShoes> MyCollection);
    }
}
