using Microsoft.EntityFrameworkCore;

namespace GoldenCalculator.Models
{
    public class OperacionesDbContext : DbContext
    {
        public OperacionesDbContext(DbContextOptions<OperacionesDbContext> options) : base(options) { }

        public DbSet<Operacion> Operaciones { get; set; }
    }
} 