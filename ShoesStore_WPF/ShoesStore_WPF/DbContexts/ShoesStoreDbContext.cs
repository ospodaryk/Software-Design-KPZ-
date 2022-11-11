using Microsoft.EntityFrameworkCore;
using ShoesStore.DTOs;
using ShoesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.DbContexts
{
    public class ShoesStoreDbContext : DbContext
    {
        public ShoesStoreDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ShoppingDTO> ShopingListTable { get; set; }
    }
}
