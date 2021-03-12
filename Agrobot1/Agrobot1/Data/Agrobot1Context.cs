using Microsoft.EntityFrameworkCore;

namespace Agrobot1.Data
{
    public class Agrobot1Context : DbContext
    {
        public Agrobot1Context(DbContextOptions<Agrobot1Context> options)
            : base(options)
        {
        }

        public DbSet<Agrobot1.Models.parte> parte { get; set; }
    }
}
