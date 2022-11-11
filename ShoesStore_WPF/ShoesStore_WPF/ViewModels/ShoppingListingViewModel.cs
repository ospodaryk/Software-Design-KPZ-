using ShoesStore.Commands;
using ShoesStore.Models;
using ShoesStore.Services;
using ShoesStore.Stores;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShoesStore.ViewModels
{
    public class ShoppingListingViewModel : ViewModelBase
    {

     
        private readonly ObservableCollection<ShoppingViewModel> _items;

        public IEnumerable<ShoppingViewModel> Reservations => _items;

        public ICommand LoadCommand { get; }
        public ICommand BuyShoesCommand { get; }

        public ShoppingListingViewModel(Shop hotel, NavigationService buyShoesNavigationService)
        {      _items = new ObservableCollection<ShoppingViewModel>();

            LoadCommand = new LoadCommand(this, hotel);
            BuyShoesCommand = new NavigateCommand(buyShoesNavigationService);
        }

        public static ShoppingListingViewModel LoadViewModel(Shop hotel, NavigationService buyShoesNavigationService)
        {
            ShoppingListingViewModel viewModel = new ShoppingListingViewModel(hotel, buyShoesNavigationService);

            viewModel.LoadCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Shopping> reservations)
        {
            _items.Clear();

            foreach (Shopping shopping in reservations)
            {
                ShoppingViewModel reservationViewModel = new ShoppingViewModel(shopping);
                _items.Add(reservationViewModel);
            }
        }
    }
}
