using Microsoft.EntityFrameworkCore;

namespace MagosHogwarts.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Magos> Magos { get; set; }
        public DbSet<Casas> Casas { get; set; }
    }
    
    
}
