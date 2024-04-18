using CP2.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace CP2.Net.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserCP2> Usuarios { get; set; }
    }
}
