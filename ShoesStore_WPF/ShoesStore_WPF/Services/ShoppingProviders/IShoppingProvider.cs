using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.Services.ShoppingProviders
{
    public interface IShoppingProvider
    {
        Task<IEnumerable<Shopping>> GetAllReservations();
    }
}
