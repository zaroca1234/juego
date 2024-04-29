using juego.Modelos;
using Microsoft.EntityFrameworkCore;

namespace juego.Contexto
{
    public class VideoJuegoContext : DbContext
    {
        public VideoJuegoContext(DbContextOptions<VideoJuegoContext> options)
            : base(options)
        {
        }

        public DbSet<FuenteEnergia> FuentesEnergia { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Planta> Plantas { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<PlantaJugador> PlantasJugador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuenteEnergia>()
                .HasOne(fe => fe.Region)
                .WithMany(r => r.FuentesEnergia)
                .HasForeignKey(fe => fe.RegionId);

            modelBuilder.Entity<Planta>()
                .HasOne(p => p.FuenteEnergia)
                .WithMany(fe => fe.Plantas)
                .HasForeignKey(p => p.FuenteEnergiaId);

            modelBuilder.Entity<Jugador>()
                .HasMany(j => j.PlantasJugador)
                .WithOne(pj => pj.Jugador)
                .HasForeignKey(pj => pj.JugadorId);

            modelBuilder.Entity<Planta>()
                .HasMany(p => p.PlantasJugador)
                .WithOne(pj => pj.Planta)
                .HasForeignKey(pj => pj.PlantaId);
        }
    }
}
