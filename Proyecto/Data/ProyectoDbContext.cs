using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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
    public DbSet<Ejemplar> Ejemplar { get; set; }
    public DbSet<Operador> Operador { get; set; }
    public DbSet<Prestamo> Prestamo { get; set; }
    public DbSet<Genero> Genero { get; set; }
    public DbSet<GeneroTitulo> GeneroTitulo { get; set; }

    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración para Editorial
        modelBuilder.Entity<Editorial>()
            .HasKey(e => e.IdEditorial);

        modelBuilder.Entity<Editorial>()
            .HasMany(e => e.Libros)
            .WithOne(l => l.Editorial)
            .HasForeignKey(l => l.IdEditorial);

        // Configuración para Autor
        modelBuilder.Entity<Autor>()
            .HasKey(a => a.IdAutor);

        modelBuilder.Entity<Autor>()
            .HasMany(a => a.AutorTitulos)
            .WithOne(at => at.Autor)
            .HasForeignKey(at => at.IdAutor);

        // Configuración para Titulo
        modelBuilder.Entity<Titulo>()
            .HasKey(t => t.IdTitulo);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.AutorTitulos)
            .WithOne(at => at.Titulo)
            .HasForeignKey(at => at.IdTitulo);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.Libros)
            .WithOne(l => l.Titulo)
            .HasForeignKey(l => l.IdTitulo);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.GeneroTitulos)
            .WithOne(gt => gt.Titulo)
            .HasForeignKey(gt => gt.IdTitulo);

        // Configuración para Libro
        modelBuilder.Entity<Libro>()
            .HasKey(l => l.IdLibro);

        modelBuilder.Entity<Libro>()
            .HasMany(l => l.Ejemplares)
            .WithOne(e => e.Libro)
            .HasForeignKey(e => e.IdLibro);

        // Configuración para AutorTitulo
        modelBuilder.Entity<AutorTitulo>()
            .HasKey(at => new { at.IdAutor, at.IdTitulo });

        // Configuración para Ejemplar
        modelBuilder.Entity<Ejemplar>()
            .HasKey(e => e.IdEjemplar);

        modelBuilder.Entity<Ejemplar>()
            .HasMany(e => e.Prestamos)
            .WithOne(p => p.Ejemplar)
            .HasForeignKey(p => p.IdEjemplar);

        // Configuración para Genero
        modelBuilder.Entity<Genero>()
            .HasKey(g => g.IdGenero);

        modelBuilder.Entity<Genero>()
            .HasMany(g => g.GeneroTitulos)
            .WithOne(gt => gt.Genero)
            .HasForeignKey(gt => gt.IdGenero);

        // Configuración para GeneroTitulo
        modelBuilder.Entity<GeneroTitulo>()
            .HasKey(gt => new { gt.IdGenero, gt.IdTitulo });

        // Configuración para Operador
        modelBuilder.Entity<Operador>()
            .HasKey(o => o.IdOperador);

        modelBuilder.Entity<Operador>()
            .HasMany(o => o.PrestamosEntregados)
            .WithOne(p => p.OperadorEntrega)
            .HasForeignKey(p => p.IdOperadorEntrega);

        modelBuilder.Entity<Operador>()
            .HasMany(o => o.PrestamosRegresados)
            .WithOne(p => p.OperadorRegreso)
            .HasForeignKey(p => p.IdOperadorRegreso);

        // Configuración para Socio
        modelBuilder.Entity<Socio>()
            .HasKey(s => s.IdSocio);

        modelBuilder.Entity<Socio>()
            .HasMany(s => s.Prestamos)
            .WithOne(p => p.Socio)
            .HasForeignKey(p => p.IdSocio);

        // Configuración para Prestamo
        modelBuilder.Entity<Prestamo>()
            .HasKey(p => p.IdPrestamo);
    }
}
