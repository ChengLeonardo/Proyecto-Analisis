using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

public class ProyectoDbContext : DbContext
{
    public DbSet<Editorial> Editorial { get; set; }
    public DbSet<Autor> Autor { get; set; }
    public DbSet<Socio> Socio { get; set; }
    public DbSet<Titulo> Titulo { get; set; }
    public DbSet<Libro> Libro { get; set; }
    public DbSet<AutorTitulo> AutorTitulo { get; set; }
    public DbSet<Ejemplar> Ejemplare { get; set; }
    public DbSet<Operador> Operador { get; set; }
    public DbSet<Prestamo> Prestamo { get; set; }
    public DbSet<Genero> Genero { get; set; }
    public DbSet<GeneroTitulo> GeneroTitulo { get; set; }

    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de claves primarias y relaciones
        modelBuilder.Entity<Editorial>().HasKey(e => e.IdEditorial);
        modelBuilder.Entity<Autor>().HasKey(a => a.IdAutor);
        modelBuilder.Entity<Socio>().HasKey(s => s.IdSocio);
        modelBuilder.Entity<Titulo>().HasKey(t => t.IdTitulo);
        modelBuilder.Entity<Libro>()
            .HasKey(l => l.IdLibro);
        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Editorial)
            .WithMany()
            .HasForeignKey(l => l.IdEditorial);
        modelBuilder.Entity<Libro>()
            .HasOne(l => l.Titulo)
            .WithMany()
            .HasForeignKey(l => l.IdTitulo);
        modelBuilder.Entity<AutorTitulo>()
            .HasKey(at => new { at.IdAutor, at.IdTitulo });
        modelBuilder.Entity<Ejemplar>()
            .HasKey(e => e.IdEjemplar);
        modelBuilder.Entity<Prestamo>()
            .HasKey(p => p.IdPrestamo);
        modelBuilder.Entity<Genero>()
            .HasKey(g => g.IdGenero);
        modelBuilder.Entity<GeneroTitulo>()
            .HasKey(gt => new { gt.IdGenero, gt.IdTitulo });
        modelBuilder.Entity<Operador>()
            .HasKey(o => o.IdOperador);
    }
}
