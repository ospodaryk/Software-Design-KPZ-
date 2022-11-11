using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.ViewModels
{
    public class ShoppingViewModel : ViewModelBase
    {
        private readonly Shopping _shopping;

        public string ShoesID => _shopping.ShoesID?.ToString();
        public string Username => _shopping.Username;

        public ShoppingViewModel(Shopping shopping)
        {
            _shopping = shopping;
        }
    }
}
