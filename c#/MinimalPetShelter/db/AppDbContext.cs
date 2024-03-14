using Microsoft.EntityFrameworkCore;
using MinimalPetShelter.Modelos;

namespace MinimalPetShelter.db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Adopcion> Adopciones { get; set; }
        public DbSet<Adoptador> Adoptadores { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<Raza> Razas { get; set; }
        public DbSet<TipoMascota> TipoMascotas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
