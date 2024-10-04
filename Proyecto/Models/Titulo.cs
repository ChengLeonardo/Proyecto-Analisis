namespace Proyecto.Models;

public class Titulo
{
    public int IdTitulo { get; set; }
    public string titulo { get; set; }

    public ICollection<Autor> Autores{ get; set; } // Relación 1:N con AutorTitulo
    public ICollection<Libro> Libros { get; set; } // Relación 1:N con Libro
    public ICollection<Genero> Generos { get; set; } // Relación 1:N con GeneroTitulo
}