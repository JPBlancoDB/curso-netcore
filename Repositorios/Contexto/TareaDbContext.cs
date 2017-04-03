using Curso.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Curso.Repositorios.Contexto
{
    public class TareaDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }

        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarea>()
                .HasKey("Id");
        }
    }
}