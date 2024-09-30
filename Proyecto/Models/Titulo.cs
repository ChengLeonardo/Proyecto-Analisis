namespace Proyecto.Models;

public class Titulo
{
    public int IdTitulo { get; set; }
    public string titulo { get; set; }

    public ICollection<AutorTitulo> AutorTitulos { get; set; } // Relación 1:N con AutorTitulo
    public ICollection<Libro> Libros { get; set; } // Relación 1:N con Libro
    public ICollection<GeneroTitulo> GeneroTitulos { get; set; } // Relación 1:N con GeneroTitulo
}