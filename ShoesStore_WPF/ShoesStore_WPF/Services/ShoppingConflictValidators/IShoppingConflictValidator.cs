using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingConflictValidators
{
    public interface IShoppingConflictValidator
    {
        Task<Shopping> GetConflictingReservation(Shopping shopping);
    }
}
