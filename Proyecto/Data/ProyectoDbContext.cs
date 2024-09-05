using Proyecto.Models;

namespace Proyecto.Data;

public class ProyectoDbContext : DbContext
{
    public Dbset<Autor> Autor { get; set; }
    public DbSet<Libro> Libro { get; set; }

}