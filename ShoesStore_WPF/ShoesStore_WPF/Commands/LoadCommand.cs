using ShoesStore.Models;
using ShoesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShoesStore.Commands
{
    public class LoadCommand : AsyncCommandBase
    {
        private readonly ShoppingListingViewModel _viewModel;
        private readonly Shop _shop;

        public LoadCommand(ShoppingListingViewModel viewModel, Shop hotel)
        {
            _viewModel = viewModel;
            _shop = hotel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Shopping> reservations = await _shop.GetAllReservations();

                _viewModel.UpdateReservations(reservations);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to load reservations.", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
