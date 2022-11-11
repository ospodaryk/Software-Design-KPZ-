using ShoesStore.DbContexts;
using ShoesStore.DTOs;
using ShoesStore.Models;
using ShoesStore.ViewModels;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingCreators
{
    public class DatabaseShoppingCreator : IShoppingCreator
    {
        private readonly ShoesStoreDbContextFactory _dbContextFactory;

        public DatabaseShoppingCreator(ShoesStoreDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateReservation(Shopping shopping, ObservableCollection<ExistingShoes> MyCollection)
        {
            using (ShoesStoreDbContext context = _dbContextFactory.CreateDbContext())
            {
                ShoppingDTO reservationDTO = ToReservationDTO(shopping,MyCollection);

                context.ShopingListTable.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ShoppingDTO ToReservationDTO(Shopping shopping, ObservableCollection<ExistingShoes> MyCollection)
        {
            return new ShoppingDTO()
            {
                IsSelected = shopping.ShoesID.isBought,

                Description = findDescription(shopping, MyCollection),
                Username = shopping.Username,
            };
        }
        private string findDescription(Shopping shopping, ObservableCollection<ExistingShoes> MyCollection) {
            string tmp="";
            int l = 0;
            foreach (ExistingShoes existingShoes in MyCollection)
            {
                if (l == 0)
                {
                    if (existingShoes.IsSelected) { tmp += existingShoes.Description; l++; }
                }
                else
                {
                    if (existingShoes.IsSelected) { tmp +=" , " +existingShoes.Description; }
                }
                
            }
            if (tmp.Length == 0) { throw Exception(); }
            return tmp;
        }

        private Exception Exception()
        {
            throw new NotImplementedException();
        }
    }
}
