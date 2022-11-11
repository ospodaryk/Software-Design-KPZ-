using Microsoft.EntityFrameworkCore;
using ShoesStore.DbContexts;
using ShoesStore.Models;
using ShoesStore.Services;
using ShoesStore.Services.ShoppingConflictValidators;
using ShoesStore.Services.ShoppingCreators;
using ShoesStore.Services.ShoppingProviders;
using ShoesStore.Stores;
using ShoesStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShoesStore_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source=reservoom.db";

        private readonly Shop _shop;
        private readonly NavigationStore _navigationStore;
        private readonly ShoesStoreDbContextFactory _reservoomDbContextFactory;

        public App()
        {
            _reservoomDbContextFactory = new ShoesStoreDbContextFactory(CONNECTION_STRING);
            IShoppingProvider reservationProvider = new DatabaseShoppingProvider(_reservoomDbContextFactory);
            IShoppingCreator reservationCreator = new DatabaseShoppingCreator(_reservoomDbContextFactory);
            IShoppingConflictValidator reservationConflictValidator = new DatabaseShoppingConflictValidator(_reservoomDbContextFactory);

            ShoppingList reservationBook = new ShoppingList(reservationProvider, reservationCreator, reservationConflictValidator);

            _shop = new Shop("SingletonSean Suites", reservationBook);
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            using (ShoesStoreDbContext dbContext = _reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            _navigationStore.CurrentViewModel = CreateReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
           

            MainWindow.Show();
            base.OnStartup(e);

        }

        private BuyShoesViewModel CreateMakeReservationViewModel()
        {
            return new BuyShoesViewModel(_shop, new NavigationService(_navigationStore, CreateReservationViewModel));
        }

        private ShoppingListingViewModel CreateReservationViewModel()
        {
            return ShoppingListingViewModel.LoadViewModel(_shop, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}
