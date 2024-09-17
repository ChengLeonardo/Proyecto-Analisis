using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Models;

public class ProyectoDBContext : DbContext
{
    public DbSet<Editorial> Editoriales { get; set; }
    public DbSet<Autor> Autores { get; set; }
    public DbSet<Socio> Socios { get; set; }
    public DbSet<Titulo> Titulos { get; set; }
    public DbSet<Libro> Libros { get; set; }
    public DbSet<AutorTitulo> AutoresTitulos { get; set; }
    public DbSet<Ejemplar> Ejemplares { get; set; }
    public DbSet<Operador> Operadores { get; set; }
    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<Genero> Generos { get; set; }
    public DbSet<GeneroTitulo> GenerosTitulos { get; set; }

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
    }
}
