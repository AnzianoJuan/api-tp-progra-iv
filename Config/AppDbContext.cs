using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<ObraSocial> ObrasSociales { get; set; }

        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Turno> Turnos { get; set; }

        public DbSet<Consultorio> Consultorios { get; set; }



        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ObraSocial>()
                .HasIndex(o => o.Nombre)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Dni)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Consultorio>()
                .HasIndex(c => c.Nombre)
                .IsUnique();
        }
       


    }
}
