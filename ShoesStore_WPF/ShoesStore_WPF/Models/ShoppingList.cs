using ShoesStore.Services.ShoppingConflictValidators;
using ShoesStore.Services.ShoppingCreators;
using ShoesStore.Services.ShoppingProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Models
{
    public class ShoppingList
    {
        private readonly IShoppingProvider _reservationProvider;
        private readonly IShoppingCreator _reservationCreator;
        private readonly IShoppingConflictValidator _reservationConflictValidator;

        public ShoppingList(IShoppingProvider reservationProvider, IShoppingCreator reservationCreator, IShoppingConflictValidator reservationConflictValidator)
        {
            _reservationProvider = reservationProvider;
            _reservationCreator = reservationCreator;
            _reservationConflictValidator = reservationConflictValidator;
        }

       
        public async Task<IEnumerable<Shopping>> GetAllReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

        public async Task BuyShoes(Shopping shopping, System.Collections.ObjectModel.ObservableCollection<ExistingShoes> MyCollection)
        {
           
            await _reservationCreator.CreateReservation(shopping,MyCollection);
        }
    }
}
