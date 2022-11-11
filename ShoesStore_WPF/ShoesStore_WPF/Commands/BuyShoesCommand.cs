using ShoesStore.Models;
using ShoesStore.Services;
using ShoesStore.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace ShoesStore.Commands
{
    public class BuyShoesCommand : AsyncCommandBase
    {

        private readonly BuyShoesViewModel _buyShoesViewModel;
        private readonly Shop _shop;
        private readonly NavigationService _shoppingViewNavigationService;
        private readonly string _description;
     private readonly   ObservableCollection<ExistingShoes> MyCollection;
        public BuyShoesCommand(BuyShoesViewModel makeReservationViewModel,Shop hotel,NavigationService reservationViewNavigationService, ObservableCollection<ExistingShoes> myCollectio)
        {
            _buyShoesViewModel = makeReservationViewModel;
            _shop = hotel;
            _shoppingViewNavigationService = reservationViewNavigationService;            
            _buyShoesViewModel.PropertyChanged += OnViewModelPropertyChanged;
            MyCollection=myCollectio;
        }

        public override bool CanExecute(object parameter)
        {
          
            return !string.IsNullOrEmpty(_buyShoesViewModel.Username) &&
                
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
           
            Shopping shopping = new Shopping(
                new ShoesID(_buyShoesViewModel.IsSelected, _description),
                _buyShoesViewModel.Username);

            try
            {
                await _shop.MakeReservation(shopping,MyCollection);
                MessageBox.Show("Successfully bought shoes.", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                _shoppingViewNavigationService.Navigate();
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Failed to buy shoes.\n Choose something!", "Error",
                   MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(BuyShoesViewModel.Username) ||
                e.PropertyName == nameof(BuyShoesViewModel.IsSelected))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
