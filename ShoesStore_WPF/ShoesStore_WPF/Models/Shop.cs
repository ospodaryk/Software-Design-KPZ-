using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoesStore.Models;

namespace ShoesStore.Models
{
    public class Shop
    {
        private readonly ShoppingList _reservationBook;

        public string Name { get; }

        public Shop(string name, ShoppingList reservationBook)
        {
            Name = name;
            _reservationBook = reservationBook;
        }
        public async Task<IEnumerable<Shopping>> GetAllReservations()
        {
            return await _reservationBook.GetAllReservations();
        }

        public async Task MakeReservation(Shopping shopping, System.Collections.ObjectModel.ObservableCollection<ExistingShoes> MyCollection)
        {
            await _reservationBook.BuyShoes(shopping,MyCollection);
        }
    }
}
