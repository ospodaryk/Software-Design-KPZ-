using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.DbContexts
{
    public class ShoesStoreDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShoesStoreDbContext>
    {
        public ShoesStoreDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=table.db").Options;

            return new ShoesStoreDbContext(options);
        }
    }
}
