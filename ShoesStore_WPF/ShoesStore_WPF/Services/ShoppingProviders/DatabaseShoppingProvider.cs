using Microsoft.EntityFrameworkCore;
using ShoesStore.DbContexts;
using ShoesStore.DTOs;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingProviders
{
    public class DatabaseShoppingProvider : IShoppingProvider
    {
        private readonly ShoesStoreDbContextFactory _dbContextFactory;

        public DatabaseShoppingProvider(ShoesStoreDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Shopping>> GetAllReservations()
        {
            using (ShoesStoreDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<ShoppingDTO> reservationDTOs = await context.ShopingListTable.ToListAsync();

                return reservationDTOs.Select(r => ToReservation(r));
            }
        }

        private static Shopping ToReservation(ShoppingDTO dto)
        {
            return new Shopping(new ShoesID(dto.IsSelected, dto.Description), dto.Username);
        }
    }
}
