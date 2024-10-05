namespace Proyecto.Models;

public class Editorial
{
    public int IdEditorial { get; set; }

    public string editorial { get; set; }

    public ICollection<Libro> Libros { get; set; } // Relación 1:N con Libro
}