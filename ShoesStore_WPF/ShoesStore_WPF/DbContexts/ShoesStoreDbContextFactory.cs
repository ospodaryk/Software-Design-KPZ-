using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesStore.DbContexts
{
    public class ShoesStoreDbContextFactory
    {
        private readonly string _connectionString;

        public ShoesStoreDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ShoesStoreDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new ShoesStoreDbContext(options);
        }
    }
}
