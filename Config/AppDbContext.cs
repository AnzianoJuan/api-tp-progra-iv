using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<ObraSocial> ObrasSociales { get; set; }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            //validacion para que haya una sola obra social
            modelBuilder.Entity<ObraSocial>().HasIndex(o => o.Nombre).IsUnique();
        }
       


    }
}
