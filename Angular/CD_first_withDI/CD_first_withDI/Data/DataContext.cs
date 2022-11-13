using CD_first_withDI.Models;
using CD_first_withDI.Models;
using Microsoft.EntityFrameworkCore;

namespace CD_first_withDI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Employee> Crew => Set<Employee>();
        public DbSet<Shoes> Pairs => Set<Shoes>();


    }
}
