using Microsoft.EntityFrameworkCore;
using lab2tarea_Ariass.Models;

namespace lab2tarea_Ariass.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Auto> Autos { get; set; }
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Empresa> Empresas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Datos iniciales (Seed) para que la tabla Autos no arranque vacía
        modelBuilder.Entity<Auto>().HasData(
            new Auto { Id = 1, Placa = "ABC-123", Marca = "Toyota", SedeTransito = "Lima" },
            new Auto { Id = 2, Placa = "XYZ-789", Marca = "Hyundai", SedeTransito = "Arequipa" }
        );
    }
}