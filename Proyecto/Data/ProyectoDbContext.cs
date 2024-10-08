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
    public DbSet<Ejemplar> Ejemplar { get; set; }
    public DbSet<Operador> Operador { get; set; }
    public DbSet<Prestamo> Prestamo { get; set; }
    public DbSet<Genero> Genero { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

    public ProyectoDbContext(DbContextOptions<ProyectoDbContext> options) : base(options)
    {
    }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.IdUsuario);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Operador)
            .WithOne(o => o.Usuario)
            .HasForeignKey<Operador>(o => o.IdUsuario);

        modelBuilder.Entity<Usuario>()
            .HasOne(u => u.Socio)
            .WithOne(s => s.Usuario)
            .HasForeignKey<Socio>(s => s.IdUsuario);

        modelBuilder.Entity<Usuario>()
            .Property(u => u.TipoUsuario)
            .HasColumnName("TipoUsuario");

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
            .HasMany(a => a.Titulos)
            .WithMany(t => t.Autores)
            .UsingEntity<Dictionary<string, object>>(
                "AutorTitulo", // Nombre de la tabla intermedia
                j => j.HasOne<Titulo>().WithMany().HasForeignKey("IdTitulo"),
                j => j.HasOne<Autor>().WithMany().HasForeignKey("IdAutor"));


        // Configuración para Titulo
        modelBuilder.Entity<Titulo>()
            .HasKey(t => t.IdTitulo);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.Autores)
            .WithMany(at => at.Titulos)
            .UsingEntity(j => j.ToTable("AutorTitulo"));

            
        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.Libros)
            .WithOne(l => l.Titulo)
            .HasForeignKey(l => l.IdTitulo);

        modelBuilder.Entity<Titulo>()
            .HasMany(t => t.Generos)
            .WithMany(gt => gt.Titulos)
            .UsingEntity(j => j.ToTable("GeneroTitulo"));


        // Configuración para Libro
        modelBuilder.Entity<Libro>()
            .HasKey(l => l.IdLibro);

        modelBuilder.Entity<Libro>()
            .HasMany(l => l.Ejemplares)
            .WithOne(e => e.Libro)
            .HasForeignKey(e => e.IdLibro);

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
            .HasMany(g => g.Titulos)
            .WithMany(t => t.Generos)
            .UsingEntity<Dictionary<string, object>>(
                "GeneroTitulo", // Nombre de la tabla intermedia
                j => j.HasOne<Titulo>().WithMany().HasForeignKey("IdTitulo"),
                j => j.HasOne<Genero>().WithMany().HasForeignKey("IdGenero"));


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
