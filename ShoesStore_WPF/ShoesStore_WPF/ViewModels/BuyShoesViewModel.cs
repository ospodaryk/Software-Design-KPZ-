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
    public class BuyShoesViewModel : ViewModelBase
    {
        private bool _st = false;
        public bool IsSelected
        {
            get { return _st; }
            set
            {
                _st = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private ObservableCollection<ExistingShoes> _myCollection;
        public ObservableCollection<ExistingShoes> MyCollection
        {
            get { return _myCollection ?? (_myCollection = new ObservableCollection<ExistingShoes>()); }
            set
            {
                _myCollection = value;
                OnPropertyChanged(nameof(MyCollection));
            }
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private bool _isBought;
        public bool isBought
        {
            get
            {
                return _isBought;
            }
            set
            {
                _isBought = value;
                OnPropertyChanged(nameof(isBought));
            }
        }

        private string _des;
        public string Description
        {
            get
            {
                return _des;
            }
            set
            {
                _des = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public BuyShoesViewModel(Shop hotel, NavigationService reservationViewNavigationService)
        {
            var person1 = new ExistingShoes {Image= "C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Brands\\Adidas.jpg", IsSelected = false, Description = "Adidas",Price=100 };
            var person2 = new ExistingShoes { Image = "C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Brands\\Nike.jpg", IsSelected = false, Description = "Nike", Price = 200 };
            var person3 = new ExistingShoes { Image = "C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Brands\\Puma.jpg", IsSelected = false, Description = "Puma", Price = 400 };
            var person5 = new ExistingShoes { Image = "C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Brands\\Gucci.jpg", IsSelected = false, Description = "Gucci", Price = 140 };
            var person6 = new ExistingShoes { Image = "C:\\Users\\Oks\\Downloads\\GIT\\ShoesStore_WPF\\ShoesStore_WPF\\Images\\Brands\\Prada.jpg", IsSelected = false, Description = "Prada", Price = 100 };

            MyCollection.Add(person1);
            MyCollection.Add(person2);
            MyCollection.Add(person3);
            MyCollection.Add(person5);
            MyCollection.Add(person6);


            SubmitCommand = new BuyShoesCommand(this, hotel, reservationViewNavigationService,MyCollection);
            CancelCommand = new NavigateCommand(reservationViewNavigationService);
        }
    }
}
