using Microsoft.EntityFrameworkCore;
using ShoesStore.DbContexts;
using ShoesStore.DTOs;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingConflictValidators
{
    public class DatabaseShoppingConflictValidator : IShoppingConflictValidator
    {
        private readonly ShoesStoreDbContextFactory _dbContextFactory;

        public DatabaseShoppingConflictValidator(ShoesStoreDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Shopping> GetConflictingReservation(Shopping shopping)
        {
            using (ShoesStoreDbContext context = _dbContextFactory.CreateDbContext())
            {
                ShoppingDTO reservationDTO = await context.ShopingListTable
                    .Where(r => r.IsSelected == shopping.ShoesID.isBought)
                    .Where(r => r.Description == shopping.ShoesID.Description)
                    
                    .FirstOrDefaultAsync();

                if (reservationDTO == null)
                {
                    return null;
                }    

                return ToReservation(reservationDTO);
            }
        }

        private static Shopping ToReservation(ShoppingDTO dto)
        {
            return new Shopping(new ShoesID(dto.IsSelected, dto.Description), dto.Username);
        }
    }
}
