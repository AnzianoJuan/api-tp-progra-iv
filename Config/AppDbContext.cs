using Microsoft.EntityFrameworkCore;
using api.Models;

namespace api.Config
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){ }

        public DbSet<Paciente> Pacientes { get; set; }
       


    }
}
