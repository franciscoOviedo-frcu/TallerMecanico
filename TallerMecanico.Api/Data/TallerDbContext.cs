using Microsoft.EntityFrameworkCore;
using TallerMecanico.Api.Models;

namespace TallerMecanico.Api.Data
{
    public class TallerDbContext : DbContext
    {
        // Constructor
        public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options)
        {
        }

        // Define tus "tablas" (DbSets)
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Trabajo> Trabajos { get; set; }

    }
}
